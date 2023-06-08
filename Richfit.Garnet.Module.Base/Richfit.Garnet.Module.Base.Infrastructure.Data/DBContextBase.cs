#define DEBUG
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using AutoMapper;
using Oracle.DataAccess.Client;
using Richfit.Garnet.Common.Data;
using Richfit.Garnet.Common.Dynamic;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Logging;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.Base.Infrastructure.Logging;

namespace Richfit.Garnet.Module.Base.Infrastructure.Data;

/// <summary>
/// DbContext基类
/// </summary>
public abstract class DBContextBase : DbContext, IEntityFrameworkDBContext, IDBContext, IUnitOfWork, IDisposable, ISql, ISqlQueryConverter
{
	/// <summary>
	/// 错误日志对象
	/// </summary>
	private static readonly ILogger errorLog = LoggerManager.GetLogger("Exception");

	/// <summary>
	/// 操作日志对象
	/// </summary>
	private static readonly ILogger log = LoggerManager.GetLogger();

	/// <inheritdoc />
	public IDbConnection Connection => base.Database.Connection;

	/// <summary>
	/// 构造函数
	/// </summary>
	/// <param name="moduleName">模型名称{0}Oracle.edmx或者{0}Sql.edmx中{0}代表的字符</param>
	public DBContextBase(string moduleName)
		: base(EntityFrameworkConnection.GetEntityFrameworkConnectionString(moduleName))
	{
		log.Debug(moduleName + "-DBContextBase实例化成功！");
	}

	/// <inheritdoc />
	public DBType GetDatabaseType()
	{
		if (base.Database.IsOralce())
		{
			return DBType.Oracle;
		}
		if (base.Database.IsSqlServer())
		{
			return DBType.SqlServer;
		}
		return DBType.Unspecified;
	}

	/// <inheritdoc />
	public DbSet<TEntity> CreateSet<TEntity>() where TEntity : class
	{
		return Set<TEntity>();
	}

	/// <inheritdoc />
	public void Attach<TEntity>(TEntity entity) where TEntity : class
	{
		Entry(entity).State = EntityState.Unchanged;
	}

	/// <inheritdoc />
	public void SetModified<TEntity>(TEntity entity) where TEntity : class
	{
		Entry(entity).State = EntityState.Modified;
	}

	/// <inheritdoc />
	public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class
	{
		Entry(original).CurrentValues.SetValues(current);
	}

	/// <inheritdoc />
	public ObjectContext GetObjectContext()
	{
		return ((IObjectContextAdapter)this).ObjectContext;
	}

	/// <inheritdoc />
	public void Commit()
	{
		try
		{
			base.SaveChanges();
			SystemLogEntry logEntry = new SystemLogEntry();
			logEntry.Data = "数据提交完成！";
			log.Info(logEntry.ToJson());
		}
		catch (DbEntityValidationException ex)
		{
			throw ex;
		}
	}

	/// <inheritdoc />
	public void CommitAndRefreshChanges()
	{
		bool saveFailed = false;
		do
		{
			try
			{
				base.SaveChanges();
				saveFailed = false;
			}
			catch (DbUpdateConcurrencyException ex)
			{
				saveFailed = true;
				ex.Entries.ToList().ForEach(delegate(DbEntityEntry entry)
				{
					entry.OriginalValues.SetValues(entry.GetDatabaseValues());
				});
			}
		}
		while (saveFailed);
	}

	/// <inheritdoc />
	public void RollbackChanges()
	{
		base.ChangeTracker.Entries().ToList().ForEach(delegate(DbEntityEntry entry)
		{
			entry.State = EntityState.Unchanged;
		});
	}

	/// <inheritdoc />
	public IList<IDataObject> DynamicSqlQuery(string sql, params object[] parameters)
	{
		IList<DbParameter> parameterList = new List<DbParameter>();
		if (parameters != null && parameters.Any())
		{
			int index = 0;
			object[] array = parameters;
			foreach (object para in array)
			{
				parameterList.Add(CreateParameter("p" + index, para, ParameterDirection.Input));
				index++;
			}
		}
		parameters = ConvertParameter(parameters);
		return base.Database.DynamicSqlQuery(sql, parameterList.ToArray(), parameters);
	}

	public IList<IDataObject>[] DynamicSqlQueryResults(string sql, params object[] parameters)
	{
		IList<DbParameter> parameterList = new List<DbParameter>();
		if (parameters != null && parameters.Any())
		{
			int index = 0;
			object[] array = parameters;
			foreach (object para in array)
			{
				parameterList.Add(CreateParameter("p" + index, para, ParameterDirection.Input));
				index++;
			}
		}
		parameters = ConvertParameter(parameters);
		return base.Database.DynamicSqlQueryResults(sql, parameterList.ToArray(), parameters);
	}

	/// <inheritdoc />
	public int ExecuteCommand(string sql, params object[] parameters)
	{
		string sqlLog = string.Empty;
		string paraLog = string.Empty;
		try
		{
			sqlLog = "SQL:" + sql;
			TraceDebug.Write(sqlLog);
			if (parameters != null && parameters.Any())
			{
				StringBuilder sbParas = new StringBuilder();
				int i = 0;
				parameters.ForEach(delegate(object x)
				{
					sbParas.AppendLine("p" + i + ":" + x.ToString());
					i++;
				});
				paraLog = "Parameters:" + sbParas.ToString();
				TraceDebug.Write(paraLog);
			}
			SystemLogEntry logEntry = new SystemLogEntry();
			logEntry.Data = sqlLog + ";" + paraLog;
			log.Info(logEntry.ToJson());
			parameters = ConvertParameter(parameters);
			if (base.Database.IsOralce() && (parameters == null || parameters.Any()))
			{
				int[] paraIndex = Utility.GetOracleSqlParaIndex(sql);
				if (paraIndex.Any())
				{
					IList<object> parameterList = new List<object>();
					paraIndex.ForEach(delegate(int x)
					{
						parameterList.Add(parameters[x]);
					});
					parameters = parameterList.ToArray();
				}
			}
			return base.Database.ExecuteSqlCommand(sql, parameters);
		}
		catch (Exception e)
		{
			SystemLogEntry logEntry = new SystemLogEntry();
			logEntry.Data = sqlLog + ";" + paraLog + ";" + e.Message;
			errorLog.Error(logEntry.ToJson());
			throw;
		}
	}

	/// <inheritdoc />
	public IList<TObject> ExecuteQuery<TObject>(string sql, params object[] parameters)
	{
		string sqlLog = string.Empty;
		string paraLog = string.Empty;
		try
		{
			sqlLog = "SQL:" + sql;
			TraceDebug.Write(sqlLog);
			if (parameters != null && parameters.Any())
			{
				StringBuilder sbParas = new StringBuilder();
				int i = 0;
				parameters.ForEach(delegate(object x)
				{
					sbParas.AppendLine("p" + i + ":" + x.ToString());
					i++;
				});
				paraLog = "Parameters:" + sbParas.ToString();
				TraceDebug.Write(paraLog);
			}
			SystemLogEntry logEntry = new SystemLogEntry();
			logEntry.Data = sqlLog + ";" + paraLog;
			log.Info(logEntry.ToJson());
			if (base.Database.IsOralce())
			{
				IList<TObject> objReturnList = new List<TObject>();
				IList<IDataObject> objList = DynamicSqlQuery(sql, parameters);
				if (objList != null && objList.Any())
				{
					objReturnList = objList.Select((IDataObject x) => Mapper.DynamicMap<TObject>(x)).ToList();
				}
				return objReturnList;
			}
			return base.Database.SqlQuery<TObject>(sql, parameters).ToList();
		}
		catch (Exception e)
		{
			SystemLogEntry logEntry = new SystemLogEntry();
			logEntry.Data = sqlLog + ";" + paraLog + ";" + e.Message;
			errorLog.Error(logEntry.ToJson());
			throw;
		}
	}

	private bool isfullequal(string ss, string s)
	{
		string myContainer = ":";
		if (ss.IndexOf(myContainer + s) == -1)
		{
			myContainer = "@";
		}
		myContainer += s;
		if (ss.IndexOf(myContainer) == ss.Length - myContainer.Length)
		{
			return true;
		}
		string[] sa = ss.Replace(myContainer, "$").Split('$');
		if (sa.Length == 1)
		{
			return true;
		}
		for (int i = 1; i < sa.Length; i++)
		{
			if (sa[i].Length <= 0)
			{
				continue;
			}
			string tmp = sa[i].Substring(0, 1);
			switch (tmp)
			{
			default:
				if (!(tmp == "\n"))
				{
					continue;
				}
				break;
			case ",":
			case "\r":
			case ")":
			case "=":
			case ">":
			case "<":
			case ";":
			case "(":
			case " ":
				break;
			}
			return true;
		}
		return false;
	}

	/// <inheritdoc />
	public int ExecuteCommand(string sql, object parameters)
	{
		string sqlLog = string.Empty;
		string paraLog = string.Empty;
		try
		{
			return base.Database.ExecuteCommand(sql.Replace("@", ":"), GenerateParm(sql, parameters));
		}
		catch (Exception e)
		{
			SystemLogEntry logEntry = new SystemLogEntry();
			logEntry.Data = sqlLog + ";" + paraLog + ";" + e.Message;
			errorLog.Error(logEntry.ToJson());
			throw;
		}
	}

	private OracleParameter[] GenerateParm(string sql, object parameters)
	{
		if (parameters == null)
		{
			return null;
		}
		Type t = parameters.GetType();
		PropertyInfo[] propertyInfo = t.GetProperties();
		int i = 0;
		IList<OracleParameter> parms = new List<OracleParameter>();
		PropertyInfo[] plist = t.GetProperties();
		PropertyInfo[] array = plist;
		foreach (PropertyInfo item in array)
		{
			if ((!sql.Contains("@" + item.Name) && !sql.Contains(":" + item.Name)) || !isfullequal(sql, item.Name))
			{
				continue;
			}
			OracleParameter oracleParameter = new OracleParameter();
			oracleParameter.ParameterName = ":" + item.Name;
			OracleParameter sp = oracleParameter;
			object obj = PropertyInfoExtensions.GetValue(item, parameters);
			if (obj is Guid || obj is Guid?)
			{
				if ((Guid)obj == Guid.Empty)
				{
					sp.OracleDbType = OracleDbType.Raw;
					sp.Size = 16;
					sp.Value = DBNull.Value;
				}
				else
				{
					sp.OracleDbType = OracleDbType.Raw;
					sp.Size = 16;
					sp.Value = ((Guid)obj).ToByteArray();
				}
			}
			else if (obj is DateTime)
			{
				sp.OracleDbType = OracleDbType.Date;
				sp.Value = (DateTime)obj;
			}
			else if (obj is decimal)
			{
				if (obj == null)
				{
					sp.Value = DBNull.Value;
				}
				else if ((decimal)obj == -1m)
				{
					sp.Value = DBNull.Value;
				}
				else
				{
					sp.Value = (decimal)obj;
				}
			}
			else if (obj == null)
			{
				sp.Value = DBNull.Value;
			}
			else if (string.IsNullOrEmpty(obj.ToString().Trim()))
			{
				sp.Value = DBNull.Value;
			}
			else
			{
				sp.Value = obj.ToString();
			}
			parms.Add(sp);
		}
		return parms.ToArray();
	}

	public IList<TObject> ExecuteQuery<TObject>(string sql, object parameters)
	{
		string sqlLog = string.Empty;
		string paraLog = string.Empty;
		try
		{
			IList<IDataObject> objList = base.Database.DynamicSqlQuery(sql.Replace("@", ":"), GenerateParm(sql, parameters));
			return objList.Select((IDataObject x) => Mapper.DynamicMap<TObject>(x)).ToList();
		}
		catch (Exception e)
		{
			SystemLogEntry logEntry = new SystemLogEntry();
			logEntry.Data = sqlLog + ";" + paraLog + ";" + e.Message;
			errorLog.Error(logEntry.ToJson());
			throw;
		}
	}

	/// <summary>
	/// 根据SQL键值和查询条件查询
	/// </summary>
	/// <typeparam name="TDTO">查询返回的DTO类型</typeparam>
	/// <param name="sqlKey">Sql配置键值</param>
	/// <param name="connectionKey">数据库连接键值</param>
	/// <param name="queryCondition">查询参数对象<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryCondition" /></param> 
	/// <param name="parameterStartIndex">查询条件中参与组织Sql查询条件的起始索引位置，默认为0</param>
	/// <param name="formatParameters">自定义的Sql字符串格式化替换参数，默认为null</param>
	/// <returns>查询结果对象<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryResult`1" /><typeparamref name="TDTO" /></returns>
	public QueryResult<TDTO> SqlQueryPager<TDTO>(string sqlKey, object parms, CallBackSql callBackSql = null)
	{
		string sql = "";
		QueryResult<TDTO> queryResult = new QueryResult<TDTO>();
		if (!string.IsNullOrEmpty(sqlKey))
		{
			object[] sqlParams = null;
			try
			{
				Type t = parms.GetType();
				PropertyInfo pi = t.GetProperty("SortBy");
				string SortBy = "";
				string SortOrder = "";
				bool flag = false;
				if (pi != null)
				{
					flag = true;
					SortBy = PropertyInfoExtensions.GetValue(pi, parms).ToString();
				}
				pi = t.GetProperty("SortOrder");
				if (pi != null)
				{
					SortOrder = PropertyInfoExtensions.GetValue(pi, parms).ToString();
				}
				string sqlResult = sqlKey;
				if (callBackSql != null)
				{
					sqlResult = callBackSql(sqlResult);
				}
				sql = (flag ? string.Format("select * from ( select row_number()  over(order by {0} {1} ) as no, t.* from ({2})t) where no between @StartRow and @EndRow order by {0} {1}", SortBy, SortOrder, sqlResult) : $"select * from ( select row_number()  as no, t.* from ({sqlResult})t) where no between @StartRow and @EndRow ");
				string sqlpager = $"select count(*) as RecordCount from ({sqlResult})";
				queryResult.RecordCount = ExecuteQuery<int>($"select count(*) from ({sqlResult})T", parms)[0];
				queryResult.List = ExecuteQuery<TDTO>(sql, parms);
				return queryResult;
			}
			catch (Exception e)
			{
				SqlExecuteException sqlException = new SqlExecuteException(sql, sqlParams, e);
				throw sqlException;
			}
		}
		return null;
	}

	/// <inheritdoc />
	public TObject ExecuteScalar<TObject>(string sql, params object[] parameters)
	{
		throw new NotImplementedException();
	}

	/// <inheritdoc />
	public int GetCount(string sql, params object[] parameters)
	{
		if (string.IsNullOrEmpty(sql))
		{
			return 0;
		}
		if (base.Database.IsOralce())
		{
			return (int)ExecuteQuery<decimal>(sql, parameters).Single();
		}
		return ExecuteQuery<int>(sql, parameters).Single();
	}

	/// <inheritdoc />
	public DbParameter CreateParameter(string parameterName, object value, ParameterDirection direction)
	{
		if (base.Database.IsOralce())
		{
			if (value is Guid || (value is Guid? && value != null))
			{
				value = ((Guid)value).ToByteArray();
			}
			OracleParameter oracleParameter = new OracleParameter();
			oracleParameter.ParameterName = parameterName;
			oracleParameter.Value = value;
			oracleParameter.Direction = direction;
			return oracleParameter;
		}
		SqlParameter sqlParameter = new SqlParameter();
		sqlParameter.ParameterName = parameterName;
		sqlParameter.Value = value;
		sqlParameter.Direction = direction;
		return sqlParameter;
	}

	/// <summary>
	/// 从当前数据库中读取字节流并保存到临时文件
	/// </summary>
	/// <param name="sql">执行的SQL语句</param>
	/// <param name="fileName">保存的临时文件的完整名称</param>
	/// <param name="parameters">SQL语句参数</param>
	/// <returns>保存的临时文件</returns>
	public Stream ReadDatabaseToFile(string sql, string fileName, params object[] parameters)
	{
		IList<DbParameter> parameterList = new List<DbParameter>();
		if (parameters != null && parameters.Any())
		{
			int index = 0;
			foreach (object para in parameters)
			{
				parameterList.Add(CreateParameter("p" + index, para, ParameterDirection.Input));
				index++;
			}
		}
		return base.Database.ReadDatabaseToFile(sql, fileName, parameterList.ToArray());
	}

	/// <inheritdoc />
	public string GetWhereSqlClause(IList<QueryItem> queryItemList, int parameterStartIndex = 0)
	{
		ISqlQueryConverter convert = GetSqlQueryConverter();
		if (convert != null)
		{
			return convert.GetWhereSqlClause(queryItemList, parameterStartIndex);
		}
		return string.Empty;
	}

	/// <inheritdoc />
	public string GetWhereSqlClause(IList<QueryItem> queryItemList, int[] indexOrder, int parameterStartIndex = 0)
	{
		ISqlQueryConverter convert = GetSqlQueryConverter();
		if (convert != null)
		{
			return convert.GetWhereSqlClause(queryItemList, indexOrder, parameterStartIndex);
		}
		return string.Empty;
	}

	/// <inheritdoc />
	public string GetWhereSqlClause(IList<QueryItem> queryItemList, int beginIndex, int length, int parameterStartIndex = 0)
	{
		ISqlQueryConverter convert = GetSqlQueryConverter();
		if (convert != null)
		{
			return convert.GetWhereSqlClause(queryItemList, beginIndex, length, parameterStartIndex);
		}
		return string.Empty;
	}

	/// <inheritdoc />
	public string GetSql(string sqlExpress, QueryCondition queryCondition, string[] formatParameters = null, int parameterStartIndex = 0)
	{
		ISqlQueryConverter convert = GetSqlQueryConverter();
		if (convert != null)
		{
			return convert.GetSql(sqlExpress, queryCondition, formatParameters, parameterStartIndex);
		}
		return string.Empty;
	}

	/// <inheritdoc />
	public string GetSql(string sqlExpress, QueryCondition queryCondition, int[] indexOrder, string[] formatParameters = null, int parameterStartIndex = 0)
	{
		ISqlQueryConverter convert = GetSqlQueryConverter();
		if (convert != null)
		{
			return convert.GetSql(sqlExpress, queryCondition, indexOrder, formatParameters, parameterStartIndex);
		}
		return string.Empty;
	}

	/// <inheritdoc />
	public string GetSql(string sqlExpress, QueryCondition queryCondition, int beginIndex, int length, string[] formatParameters = null, int parameterStartIndex = 0)
	{
		ISqlQueryConverter convert = GetSqlQueryConverter();
		if (convert != null)
		{
			return convert.GetSql(sqlExpress, queryCondition, beginIndex, length, formatParameters, parameterStartIndex);
		}
		return string.Empty;
	}

	/// <inheritdoc />
	public string GetTotalCountSql(string sqlExpress, QueryCondition queryCondition, string[] formatParameters = null, int parameterStartIndex = 0)
	{
		ISqlQueryConverter convert = GetSqlQueryConverter();
		if (convert != null)
		{
			return convert.GetTotalCountSql(sqlExpress, queryCondition, formatParameters, parameterStartIndex);
		}
		return string.Empty;
	}

	/// <inheritdoc />
	public string GetTotalCountSql(string sqlExpress, QueryCondition queryCondition, int[] indexOrder, string[] formatParameters = null, int parameterStartIndex = 0)
	{
		ISqlQueryConverter convert = GetSqlQueryConverter();
		if (convert != null)
		{
			return convert.GetTotalCountSql(sqlExpress, queryCondition, indexOrder, formatParameters, parameterStartIndex);
		}
		return string.Empty;
	}

	/// <inheritdoc />
	public string GetTotalCountSql(string sqlExpress, QueryCondition queryCondition, int beginIndex, int length, string[] formatParameters = null, int parameterStartIndex = 0)
	{
		ISqlQueryConverter convert = GetSqlQueryConverter();
		if (convert != null)
		{
			return convert.GetTotalCountSql(sqlExpress, queryCondition, beginIndex, length, formatParameters, parameterStartIndex);
		}
		return string.Empty;
	}

	/// <inheritdoc />
	public object[] GetWhereSqlParamValue(IList<QueryItem> queryItemList, int valueStartIndex = 0, int defaultParameterCount = 0)
	{
		return GetSqlQueryConverter()?.GetWhereSqlParamValue(queryItemList, valueStartIndex, defaultParameterCount);
	}

	/// <inheritdoc />
	public object[] GetWhereSqlParamValue(IList<QueryItem> queryItemList, int[] indexOrder, int defaultParameterCount = 0)
	{
		return GetSqlQueryConverter()?.GetWhereSqlParamValue(queryItemList, indexOrder, defaultParameterCount);
	}

	/// <inheritdoc />
	public object[] GetWhereSqlParamValue(IList<QueryItem> queryItemList, int beginIndex, int length, int defaultParameterCount)
	{
		return GetSqlQueryConverter()?.GetWhereSqlParamValue(queryItemList, beginIndex, length, defaultParameterCount);
	}

	/// <summary>
	/// 获得Sql语句查询转换器，负责转化查询条件
	/// </summary>
	/// <returns></returns>
	private ISqlQueryConverter GetSqlQueryConverter()
	{
		DBType DatabaseType = GetDatabaseType();
		return SqlQueryConverterFactory.Create(DatabaseType);
	}

	/// <summary>
	/// 转换SQL参数。
	/// <para>对于Oracle数据库，Guid类型的参数值将转换为字节数组</para>
	/// </summary>
	/// <param name="parameters"></param>
	private object[] ConvertParameter(object[] parameters)
	{
		if (base.Database.IsOralce() && parameters != null && parameters.Any())
		{
			IList<object> parameterList = new List<object>();
			parameters.ForEach(delegate(object x)
			{
				if (x is Guid || (x is Guid? && x != null))
				{
					x = ((Guid)x).ToByteArray();
				}
				parameterList.Add(x);
			});
			return parameterList.ToArray();
		}
		return parameters;
	}
}
