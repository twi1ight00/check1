using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Richfit.Garnet.Common.Data;
using Richfit.Garnet.Common.Dynamic;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Common.Logging;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Domain.Models;
using Richfit.Garnet.Module.Base.Domain.Specifications;
using Richfit.Garnet.Module.Base.Infrastructure.Data;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;

namespace Richfit.Garnet.Module.Base.Application.Services;

/// <summary>
/// 应用服务基类
/// </summary>
/// <remarks>
/// 所有应用层（Application）的服务实现都要继承此类
/// </remarks>
public abstract class ServiceBase : IServiceBase
{
	/// <summary>
	/// 日志对象，可从继承类中调用
	/// </summary>
	protected static readonly ILogger log = LoggerManager.GetLogger();

	/// <summary>
	/// 根据SQL键值和查询条件查询
	/// </summary>
	/// <typeparam name="TDTO">查询返回的DTO类型</typeparam>
	/// <typeparam name="TEntity">POCO类型，从Entity继承<see cref="T:Richfit.Garnet.Module.Base.Domain.Entity" /></typeparam>
	/// <param name="sqlKey">Sql配置键值</param>
	/// <param name="queryCondition">查询参数对象<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryCondition" /></param>
	/// <param name="repository">数据仓储对象</param>
	/// <returns>查询结果对象<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryResult`1" /><typeparamref name="TDTO" /></returns>
	public QueryResult<TDTO> SqlQuery<TDTO, TEntity>(string sqlKey, QueryCondition queryCondition, IRepository<TEntity> repository) where TEntity : Entity
	{
		return SqlQuery<TDTO, TEntity>(sqlKey, queryCondition, repository, 0, null);
	}

	/// <summary>
	/// 根据SQL键值和查询条件查询
	/// </summary>
	/// <typeparam name="TDTO">查询返回的DTO类型</typeparam>
	/// <typeparam name="TEntity">POCO类型，从Entity继承<see cref="T:Richfit.Garnet.Module.Base.Domain.Entity" /></typeparam>
	/// <param name="sqlKey">Sql配置键值</param>
	/// <param name="queryCondition">查询参数对象<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryCondition" /></param>
	/// <param name="formatParameters">自定义的Sql字符串格式化替换参数，默认为null</param>
	/// <param name="repository">数据仓储对象</param>
	/// <param name="parameterStartIndex">查询条件中参与组织Sql查询条件的起始索引位置，默认为0</param>
	/// <returns>查询结果对象<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryResult`1" /><typeparamref name="TDTO" /></returns>
	public QueryResult<TDTO> SqlQuery<TDTO, TEntity>(string sqlKey, QueryCondition queryCondition, IRepository<TEntity> repository, int parameterStartIndex = 0, string[] formatParameters = null) where TEntity : Entity
	{
		QueryResult<TDTO> queryResult = new QueryResult<TDTO>();
		if (queryCondition == null)
		{
			queryCondition = new QueryCondition();
		}
		if (!string.IsNullOrEmpty(sqlKey) && queryCondition != null)
		{
			string sql = string.Empty;
			object[] sqlParams = null;
			try
			{
				SqlStatement sqlStatement = repository.GetSqlStatement(sqlKey, GetType());
				string sqlExpress = sqlStatement.Sql;
				int defaultParameterCount = sqlStatement.GetParameterMaxNo();
				defaultParameterCount = ((defaultParameterCount >= 0) ? (defaultParameterCount + 1) : 0);
				int paramentIndex = Math.Max(defaultParameterCount, parameterStartIndex);
				sql = repository.GetSql(sqlExpress, queryCondition, paramentIndex, queryCondition.QueryItems.Count, formatParameters, paramentIndex);
				sqlParams = repository.GetWhereSqlParamValue(queryCondition.QueryItems, 0, defaultParameterCount);
				IList<TDTO> collectionDTO = (queryResult.List = repository.ExecuteQuery<TDTO>(sql, sqlParams));
				queryResult.RecordCount = collectionDTO.Count();
				if (queryCondition.PagingSetting != null)
				{
					string sqlCount = repository.GetTotalCountSql(sqlExpress, queryCondition, paramentIndex, queryCondition.QueryItems.Count, formatParameters, paramentIndex);
					int count = repository.GetCount(sqlCount, sqlParams);
					queryResult.RecordCount = count;
				}
			}
			catch (Exception e)
			{
				SqlExecuteException sqlException = new SqlExecuteException(sql, sqlParams, e);
				throw sqlException;
			}
		}
		return queryResult;
	}

	/// <summary>
	/// 根据SQL键值和查询条件查询
	/// </summary>
	/// <typeparam name="TDTO">查询返回的DTO类型</typeparam>
	/// <param name="sqlKey">Sql配置键值</param>
	/// <param name="queryCondition">查询参数对象<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryCondition" /></param> 
	/// <param name="parameterStartIndex">查询条件中参与组织Sql查询条件的起始索引位置，默认为0</param>
	/// <param name="formatParameters">自定义的Sql字符串格式化替换参数，默认为null</param>
	/// <returns>查询结果对象<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryResult`1" /><typeparamref name="TDTO" /></returns>
	public QueryResult<TDTO> SqlQueryResult<TDTO>(string sqlKey, QueryCondition queryCondition, int parameterStartIndex = 0, string[] formatParameters = null)
	{
		return SqlQueryResult<TDTO>(sqlKey, null, queryCondition, parameterStartIndex, formatParameters);
	}

	/// <summary>
	/// 根据SQL键值和查询条件查询
	/// </summary>
	/// <typeparam name="TDTO">查询返回的DTO类型</typeparam>
	/// <param name="sqlKey">Sql配置键值</param>
	/// <param name="queryCondition">查询参数对象<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryCondition" /></param> 
	/// <param name="parameterStartIndex">查询条件中参与组织Sql查询条件的起始索引位置，默认为0</param>
	/// <param name="formatParameters">自定义的Sql字符串格式化替换参数，默认为null</param>
	/// <returns>查询结果对象<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryResult`1" /><typeparamref name="TDTO" /></returns>
	public QueryResult<TDTO> SqlQueryResult<TDTO>(string sqlKey, QueryCondition queryCondition, Type type, int parameterStartIndex = 0, string[] formatParameters = null)
	{
		return SqlQueryResult<TDTO>(sqlKey, null, queryCondition, parameterStartIndex, null, type);
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
	public QueryResult<TDTO> SqlQueryResult<TDTO>(string sqlKey, string connectionKey, QueryCondition queryCondition, int parameterStartIndex = 0, string[] formatParameters = null, Type type = null)
	{
		QueryResult<TDTO> queryResult = new QueryResult<TDTO>();
		if (queryCondition == null)
		{
			queryCondition = new QueryCondition();
		}
		if (!string.IsNullOrEmpty(sqlKey) && queryCondition != null)
		{
			string sql = string.Empty;
			object[] sqlParams = null;
			try
			{
				SqlRepository repository = new SqlRepository(connectionKey);
				SqlStatement sqlStatement = repository.GetSqlStatement(sqlKey, (type == null) ? GetType() : type);
				string sqlExpress = sqlStatement.Sql;
				int defaultParameterCount = sqlStatement.GetParameterMaxNo();
				defaultParameterCount = ((defaultParameterCount >= 0) ? (defaultParameterCount + 1) : 0);
				int parameterIndex = Math.Max(defaultParameterCount, parameterStartIndex);
				sql = repository.GetSql(sqlExpress, queryCondition, parameterIndex, queryCondition.QueryItems.Count, formatParameters, parameterIndex);
				sqlParams = repository.GetWhereSqlParamValue(queryCondition.QueryItems, 0, defaultParameterCount);
				IList<TDTO> collectionDTO = (queryResult.List = repository.ExecuteQuery<TDTO>(sql, sqlParams));
				queryResult.RecordCount = collectionDTO.Count();
				if (queryCondition.PagingSetting != null)
				{
					string sqlCount = repository.GetTotalCountSql(sqlExpress, queryCondition, parameterIndex, queryCondition.QueryItems.Count, formatParameters, parameterIndex);
					int count = repository.GetCount(sqlCount, sqlParams);
					queryResult.RecordCount = count;
				}
			}
			catch (Exception e)
			{
				SqlExecuteException sqlException = new SqlExecuteException(sql, sqlParams, e);
				throw sqlException;
			}
		}
		return queryResult;
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
	public IList<TDTO> SqlQuery<TDTO>(string sqlKey, object parms, CallBackSql callBackSql = null)
	{
		if (!string.IsNullOrEmpty(sqlKey))
		{
			string sql = string.Empty;
			object[] sqlParams = null;
			try
			{
				SqlRepository repository = new SqlRepository(null);
				SqlStatement sqlStatement = repository.GetSqlStatement(sqlKey, GetType());
				sql = sqlStatement.Sql;
				if (callBackSql != null)
				{
					sql = callBackSql(sql);
				}
				return repository.ExecuteQuery<TDTO>(sql, parms);
			}
			catch (Exception e)
			{
				SqlExecuteException sqlException = new SqlExecuteException(sql, sqlParams, e);
				throw sqlException;
			}
		}
		return null;
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
	public IList<TDTO> SqlQueryList<TDTO>(string sql, object parms)
	{
		if (!string.IsNullOrEmpty(sql))
		{
			try
			{
				SqlRepository repository = new SqlRepository(null);
				return repository.ExecuteQuery<TDTO>(sql, parms);
			}
			catch (Exception e)
			{
				SqlExecuteException sqlException = new SqlExecuteException(sql, null, e);
				throw sqlException;
			}
		}
		return null;
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
				SqlRepository repository = new SqlRepository(null);
				SqlStatement sqlStatement = repository.GetSqlStatement(sqlKey, GetType());
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
				string sqlResult = sqlStatement.Sql;
				if (callBackSql != null)
				{
					sqlResult = callBackSql(sqlResult);
				}
				sql = (flag ? string.Format("select * from ( select row_number()  over(order by {0} {1} ) as no, t.* from ({2})t) where no between @StartRow and @EndRow order by {0} {1}", SortBy, SortOrder, sqlResult) : $"select * from ( select row_number()  as no, t.* from ({sqlResult})t) where no between @StartRow and @EndRow ");
				string sqlpager = $"select count(*) as RecordCount from ({sqlResult})";
				queryResult.RecordCount = repository.ExecuteQuery<int>($"select count(*) from ({sqlResult})T", parms)[0];
				queryResult.List = repository.ExecuteQuery<TDTO>(sql, parms);
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

	/// <summary>
	/// 根据SQL键值和查询条件查询，指定查询条件参数解析规则和值解析规则
	/// </summary>
	/// <typeparam name="TDTO">查询返回的DTO类型</typeparam>
	/// <param name="sqlKey">Sql配置键值</param>
	/// <param name="queryCondition">查询参数对象<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryCondition" /></param>
	/// <param name="parameterResolveRule">查询条件对应的生成参数的解析规则<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.ParameterResolveRule" /></param>
	/// <param name="valueResolveRule">查询条件对应的生成参数值的解析规则<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.ValueResolveRule" /></param>
	/// <param name="formatParameters">自定义的Sql字符串格式化替换参数，默认为null</param>
	/// <returns>查询结果对象<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryResult`1" /><typeparamref name="TDTO" /></returns>
	public QueryResult<TDTO> SqlQuery<TDTO>(string sqlKey, QueryCondition queryCondition, ParameterResolveRule parameterResolveRule, ValueResolveRule valueResolveRule, string[] formatParameters = null)
	{
		return SqlQuery<TDTO>(sqlKey, null, queryCondition, parameterResolveRule, valueResolveRule, formatParameters);
	}

	/// <summary>
	/// 根据SQL键值和查询条件查询，指定查询条件参数解析规则和值解析规则
	/// </summary>
	/// <typeparam name="TDTO">查询返回的DTO类型</typeparam>
	/// <param name="sqlKey">Sql配置键值</param>
	/// <param name="connectionKey">数据库连接键值</param>
	/// <param name="queryCondition">查询参数对象<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryCondition" /></param>
	/// <param name="parameterResolveRule">查询条件对应的生成参数的解析规则<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.ParameterResolveRule" /></param>
	/// <param name="valueResolveRule">查询条件对应的生成参数值的解析规则<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.ValueResolveRule" /></param>
	/// <param name="formatParameters">自定义的Sql字符串格式化替换参数，默认为null</param>
	/// <returns>查询结果对象<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryResult`1" /><typeparamref name="TDTO" /></returns>
	public QueryResult<TDTO> SqlQuery<TDTO>(string sqlKey, string connectionKey, QueryCondition queryCondition, ParameterResolveRule parameterResolveRule, ValueResolveRule valueResolveRule, string[] formatParameters = null)
	{
		QueryResult<TDTO> queryResult = new QueryResult<TDTO>();
		if (queryCondition == null)
		{
			queryCondition = new QueryCondition();
		}
		if (!string.IsNullOrEmpty(sqlKey) && queryCondition != null)
		{
			string sql = string.Empty;
			object[] sqlParams = null;
			try
			{
				SqlRepository repository = new SqlRepository(connectionKey);
				SqlStatement sqlStatement = repository.GetSqlStatement(sqlKey, GetType());
				string sqlExpress = sqlStatement.Sql;
				int defaultParameterCount = sqlStatement.GetParameterMaxNo();
				defaultParameterCount = ((defaultParameterCount >= 0) ? (defaultParameterCount + 1) : 0);
				if (valueResolveRule != null && valueResolveRule.DefaultParameterCount < defaultParameterCount)
				{
					valueResolveRule.DefaultParameterCount = defaultParameterCount;
				}
				sql = ((parameterResolveRule == null) ? repository.GetSql(sqlExpress, queryCondition, formatParameters) : ((parameterResolveRule.IndexOrder == null) ? repository.GetSql(sqlExpress, queryCondition, parameterResolveRule.BeginIndex, parameterResolveRule.Length, formatParameters, parameterResolveRule.ParameterStartIndex) : repository.GetSql(sqlExpress, queryCondition, parameterResolveRule.IndexOrder, formatParameters, parameterResolveRule.ParameterStartIndex)));
				sqlParams = ((valueResolveRule == null) ? repository.GetWhereSqlParamValue(queryCondition.QueryItems) : ((valueResolveRule.IndexOrder == null) ? repository.GetWhereSqlParamValue(queryCondition.QueryItems, valueResolveRule.BeginIndex, valueResolveRule.Length, valueResolveRule.DefaultParameterCount) : repository.GetWhereSqlParamValue(queryCondition.QueryItems, valueResolveRule.IndexOrder, valueResolveRule.DefaultParameterCount)));
				IList<TDTO> collectionDTO = (queryResult.List = repository.ExecuteQuery<TDTO>(sql, sqlParams));
				queryResult.RecordCount = collectionDTO.Count();
				if (queryCondition.PagingSetting != null)
				{
					string sqlCount = string.Empty;
					sqlCount = ((parameterResolveRule == null) ? repository.GetTotalCountSql(sqlExpress, queryCondition, formatParameters) : ((parameterResolveRule.IndexOrder == null) ? repository.GetTotalCountSql(sqlExpress, queryCondition, parameterResolveRule.BeginIndex, parameterResolveRule.Length, formatParameters, parameterResolveRule.ParameterStartIndex) : repository.GetTotalCountSql(sqlExpress, queryCondition, parameterResolveRule.IndexOrder, formatParameters, parameterResolveRule.ParameterStartIndex)));
					int count = repository.GetCount(sqlCount, sqlParams);
					queryResult.RecordCount = count;
				}
			}
			catch (Exception e)
			{
				SqlExecuteException sqlException = new SqlExecuteException(sql, sqlParams, e);
				throw sqlException;
			}
		}
		return queryResult;
	}

	/// <summary>
	/// Sql语句动态查询
	/// </summary>
	/// <param name="sql">sql语句</param>
	/// <param name="queryCondition">查询参数对象<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryCondition" /></param>
	/// <param name="parameterResolveRule">查询条件对应的生成参数的解析规则<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.ParameterResolveRule" /></param>
	/// <param name="valueResolveRule">查询条件对应的生成参数值的解析规则<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.ValueResolveRule" /></param>
	/// <param name="formatParameters">自定义的Sql字符串格式化替换参数，默认为null</param>
	/// <returns>查询结果对象<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryResult`1" />，对象类型为IDataObject接口类型 <see cref="T:Richfit.Garnet.Common.Dynamic.IDataObject" /></returns>
	public QueryResult<IDataObject> DynamicSqlQuery(string sql, QueryCondition queryCondition, ParameterResolveRule parameterResolveRule, ValueResolveRule valueResolveRule, string[] formatParameters = null)
	{
		QueryResult<IDataObject> queryResult = new QueryResult<IDataObject>();
		if (queryCondition == null)
		{
			queryCondition = new QueryCondition();
		}
		if (!string.IsNullOrEmpty(sql) && queryCondition != null)
		{
			object[] sqlParams = null;
			try
			{
				SqlRepository repository = ServiceLocator.Instance.GetService<SqlRepository>();
				string sqlExpress = sql;
				sql = ((parameterResolveRule == null) ? repository.GetSql(sqlExpress, queryCondition, formatParameters) : ((parameterResolveRule.IndexOrder == null) ? repository.GetSql(sqlExpress, queryCondition, parameterResolveRule.BeginIndex, parameterResolveRule.Length, formatParameters, parameterResolveRule.ParameterStartIndex) : repository.GetSql(sqlExpress, queryCondition, parameterResolveRule.IndexOrder, formatParameters, parameterResolveRule.ParameterStartIndex)));
				sqlParams = ((valueResolveRule == null) ? repository.GetWhereSqlParamValue(queryCondition.QueryItems) : ((valueResolveRule.IndexOrder == null) ? repository.GetWhereSqlParamValue(queryCondition.QueryItems, valueResolveRule.BeginIndex, valueResolveRule.Length) : repository.GetWhereSqlParamValue(queryCondition.QueryItems, valueResolveRule.IndexOrder)));
				IList<IDataObject> collectionDTO = (queryResult.List = repository.DynamicSqlQuery(sql, sqlParams));
				queryResult.RecordCount = collectionDTO.Count;
				if (queryCondition.PagingSetting != null)
				{
					string sqlCount = string.Empty;
					sqlCount = ((parameterResolveRule == null) ? repository.GetTotalCountSql(sqlExpress, queryCondition, formatParameters) : ((parameterResolveRule.IndexOrder == null) ? repository.GetTotalCountSql(sqlExpress, queryCondition, parameterResolveRule.BeginIndex, parameterResolveRule.Length, formatParameters, parameterResolveRule.ParameterStartIndex) : repository.GetTotalCountSql(sqlExpress, queryCondition, parameterResolveRule.IndexOrder, formatParameters, parameterResolveRule.ParameterStartIndex)));
					int count = repository.GetCount(sqlCount, sqlParams);
					queryResult.RecordCount = count;
				}
			}
			catch (Exception e)
			{
				SqlExecuteException sqlException = new SqlExecuteException(sql, sqlParams, e);
				throw sqlException;
			}
		}
		return queryResult;
	}

	/// <summary>
	/// 根据Sql配置键值动态查询
	/// </summary>
	/// <param name="sqlKey">Sql配置键值</param>
	/// <param name="queryCondition">查询参数对象<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryCondition" /></param>
	/// <param name="parameterResolveRule">查询条件对应的生成参数的解析规则<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.ParameterResolveRule" /></param>
	/// <param name="valueResolveRule">查询条件对应的生成参数值的解析规则<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.ValueResolveRule" /></param>
	/// <param name="formatParameters">自定义的Sql字符串格式化替换参数，默认为null</param>
	/// <returns>查询结果对象<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryResult`1" />，对象类型为IDataObject接口类型<see cref="T:Richfit.Garnet.Common.Dynamic.IDataObject" /></returns>
	public QueryResult<IDataObject> DynamicSqlQueryByKey(string sqlKey, QueryCondition queryCondition, ParameterResolveRule parameterResolveRule, ValueResolveRule valueResolveRule, string[] formatParameters = null)
	{
		QueryResult<IDataObject> queryResult = new QueryResult<IDataObject>();
		if (queryCondition == null)
		{
			queryCondition = new QueryCondition();
		}
		if (!string.IsNullOrEmpty(sqlKey) && queryCondition != null)
		{
			SqlRepository repository = ServiceLocator.Instance.GetService<SqlRepository>();
			SqlStatement sqlStatement = repository.GetSqlStatement(sqlKey, GetType());
			string sqlExpress = sqlStatement.Sql;
			int defaultParameterCount = sqlStatement.GetParameterMaxNo();
			defaultParameterCount = ((defaultParameterCount >= 0) ? (defaultParameterCount + 1) : 0);
			if (valueResolveRule != null && valueResolveRule.DefaultParameterCount < defaultParameterCount)
			{
				valueResolveRule.DefaultParameterCount = defaultParameterCount;
			}
			queryResult = DynamicSqlQuery(sqlExpress, queryCondition, parameterResolveRule, valueResolveRule, formatParameters);
		}
		return queryResult;
	}

	/// <summary>
	/// 根据实体主键查询单个对象实体
	/// </summary>
	/// <typeparam name="TDTO">查询返回的DTO类型，从DTOBase继承<see cref="T:Richfit.Garnet.Module.Base.Application.DTO.DTOBase" /></typeparam>
	/// <typeparam name="TEntity">POCO类型，从Entity继承<see cref="T:Richfit.Garnet.Module.Base.Domain.Entity" /></typeparam>
	/// <param name="id">主键ID,<see cref="T:System.Object" /></param>
	/// <param name="repository">数据仓储对象</param>
	/// <returns>DTO结果对象<typeparamref name="TDTO" /></returns>
	public TDTO GetDTOById<TDTO, TEntity>(object id, IRepository<TEntity> repository) where TDTO : DTOBase, new() where TEntity : Entity
	{
		TEntity entity = repository.GetByKey(id);
		if (entity != null)
		{
			return entity.AdaptAsDTO<TDTO>();
		}
		return null;
	}

	/// <summary>
	/// 根据查询条件进行实体查找，通过Linq2Entity的方式，注意此种方式查询条件中的Key要在TEntity的属性中存在
	/// </summary>
	/// <typeparam name="TDTO">查询返回的DTO类型，从DTOBase继承<see cref="T:Richfit.Garnet.Module.Base.Application.DTO.DTOBase" /></typeparam>
	/// <typeparam name="TEntity">POCO类型，从Entity继承<see cref="T:Richfit.Garnet.Module.Base.Domain.Entity" /></typeparam>
	/// <param name="queryCondition">查询参数对象<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryCondition" /></param>
	/// <param name="repository">数据仓储对象</param>
	/// <returns>查询结果对象<see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryResult`1" /><typeparamref name="TDTO" /></returns>
	public QueryResult<TDTO> EntityQuery<TDTO, TEntity>(QueryCondition queryCondition, IRepository<TEntity> repository) where TDTO : DTOBase, new() where TEntity : Entity
	{
		QueryResult<TDTO> queryResult = new QueryResult<TDTO>();
		if (queryCondition != null)
		{
			ISpecification<TEntity> specification = LinqQueryConverter<TEntity>.ConvertSpecification(queryCondition.QueryItems);
			IList<TEntity> entitys = null;
			if (queryCondition.PagingSetting != null)
			{
				int pageIndex = queryCondition.PagingSetting.PageIndex;
				int pageCount = queryCondition.PagingSetting.PageCount;
				entitys = repository.FindAll(specification, queryCondition.PagingSetting.GetSortDesc(), pageIndex, pageCount);
			}
			else
			{
				entitys = repository.FindAll(specification);
			}
			queryResult.List = entitys.AdaptAsDTO<TDTO>();
			queryResult.RecordCount = entitys.Count();
			if (queryCondition.PagingSetting != null)
			{
				int count = repository.GetCount(specification);
				queryResult.RecordCount = count;
			}
		}
		return queryResult;
	}

	/// <summary>
	/// 根据SQL键值和查询条件查询并将结果以二进制流方式传出
	/// </summary>
	/// <param name="sqlKey">sqlKey</param>
	/// <param name="fileName">读取的文件名</param>
	/// <param name="queryCondition">查询参数对象</param>
	/// <returns>字节流</returns>
	public Stream ReadDatabaseToFile(string sqlKey, string fileName, QueryCondition queryCondition)
	{
		Stream stream = new MemoryStream();
		if (queryCondition == null)
		{
			queryCondition = new QueryCondition();
		}
		if (!string.IsNullOrEmpty(sqlKey) && queryCondition != null)
		{
			string sql = string.Empty;
			object[] sqlParams = null;
			try
			{
				SqlRepository repository = ServiceLocator.Instance.GetService<SqlRepository>();
				SqlStatement sqlStatement = repository.GetSqlStatement(sqlKey, GetType());
				string sqlExpress = sqlStatement.Sql;
				sqlParams = repository.GetWhereSqlParamValue(queryCondition.QueryItems);
				stream = repository.ReadDatabaseToFile(repository.GetSql(sqlExpress, queryCondition), fileName, sqlParams);
			}
			catch (Exception e)
			{
				SqlExecuteException sqlException = new SqlExecuteException(sql, sqlParams, e);
				throw sqlException;
			}
		}
		return stream;
	}

	/// <summary>
	/// 选中树的节点
	/// </summary>
	/// <param name="sourceTreeList">树节点列表<see cref="T:Richfit.Garnet.Module.Base.Application.DTO.TREE_NODE" /></param>
	/// <param name="keys">要选中的节点的键值列表</param>
	protected void CheckTreeNode(IList<TREE_NODE> sourceTreeList, IList<Guid> keys)
	{
		if (sourceTreeList == null || !sourceTreeList.Any() || keys == null || !keys.Any())
		{
			return;
		}
		keys.ForEachParallel(delegate(Guid x)
		{
			IEnumerable<TREE_NODE> enumerable = sourceTreeList.Where((TREE_NODE y) => y.ID.Equals(x));
			if (enumerable != null && enumerable.Any())
			{
				enumerable.ForEachParallel(delegate(TREE_NODE z)
				{
					z.IS_CHECK = 1m;
				});
			}
		});
	}

	/// <summary>
	/// 选中树的节点
	/// </summary>
	/// <typeparam name="T">树节点键类型</typeparam>
	/// <param name="sourceTreeList">数据节点列表</param>
	/// <param name="keys">树节点键值列表</param>
	protected void CheckTreeNode<T>(IList<TREE_NODE<T>> sourceTreeList, IList<T> keys) where T : struct
	{
		if (sourceTreeList == null || !sourceTreeList.Any() || keys == null || !keys.Any())
		{
			return;
		}
		keys.ForEachParallel(delegate(T x)
		{
			IEnumerable<TREE_NODE<T>> enumerable = sourceTreeList.Where((TREE_NODE<T> y) => y.ID.Equals(x));
			if (enumerable != null && enumerable.Any())
			{
				enumerable.ForEachParallel(delegate(TREE_NODE<T> z)
				{
					z.IS_CHECK = 1m;
				});
			}
		});
	}

	/// <summary>
	/// 将字符分割的string字串转换为Guid列表形式
	/// </summary>
	/// <param name="Ids">ID字符串</param>
	/// <param name="splitFlag">分隔标识，默认逗号</param>
	/// <returns></returns>
	protected List<Guid> SplitToGuid(string Ids, string splitFlag = ",")
	{
		List<Guid> idList = new List<Guid>();
		string[] array = Ids.Split(splitFlag);
		foreach (string idStr in array)
		{
			if (!string.IsNullOrWhiteSpace(idStr) && Guid.TryParse(idStr, out var id))
			{
				idList.Add(id);
			}
		}
		return idList;
	}

	/// <summary>
	/// 处理Sql查询参数，用于Oracle数据库查询Guid参数的特殊处理，不通过QueryItem形式，直接传递参数值的情况
	/// </summary>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\Application\Services\UserManagement\SystemUserService.cs" region="Example.QueryOrgRoleTree" />
	///             </example>
	/// <param name="parameters">参数对象</param>
	/// <param name="dbContext">数据库上下文</param>
	/// <returns>处理后的对象参数</returns>
	protected object[] ProcessParameters(object[] parameters, IDBContext dbContext)
	{
		DBType dbType = dbContext.GetDatabaseType();
		if (dbType == DBType.Oracle)
		{
			List<object> objReturn = new List<object>();
			parameters.ForEach(delegate(object x)
			{
				if (x is Guid || (x is Guid? && x != null))
				{
					if (x is Guid)
					{
						objReturn.Add(((Guid)x).ToByteArray());
					}
					else
					{
						objReturn.Add(((Guid?)x).Value.ToByteArray());
					}
				}
				else
				{
					objReturn.Add(x);
				}
			});
			return objReturn.ToArray();
		}
		return parameters;
	}

	/// <summary>
	/// 获取Guid值在不同数据库中的存储内容
	/// 应用于：
	/// 1、用于多数据库支持的情况下，Guid与字符串类型相等比较的问题，如：多语言中的StringKey
	/// 2、拼写Sql字符串中的Guid查询条件值，如IN、=等场景
	/// </summary>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.CodeTableManagement\Application\Services\CodeTableAppService.cs" region="Example.UpdateCodeTable" />
	///             </example>
	/// <param name="guid">Guid值</param>
	/// <param name="dbContext">数据库上下文</param>
	/// <returns>数据库存储内容</returns>
	protected string GetGuidString(Guid guid, IDBContext dbContext)
	{
		DBType dbType = dbContext.GetDatabaseType();
		if (dbType == DBType.Oracle)
		{
			return guid.ToOracleHex();
		}
		return guid.ToString();
	}
}
