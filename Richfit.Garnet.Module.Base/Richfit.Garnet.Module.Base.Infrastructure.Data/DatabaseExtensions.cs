#define DEBUG
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using Richfit.Garnet.Common.Dynamic;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Base.Infrastructure.Logging;
using Richfit.Garnet.Module.Base.Infrastructure.TimeZone;

namespace Richfit.Garnet.Module.Base.Infrastructure.Data;

/// <summary>
/// <see cref="T:System.Data.Entity.Database" /> 类型扩展方法类
/// </summary>
public static class DatabaseExtensions
{
	/// <summary>
	/// 判断当前数据库是否是Oracle
	/// </summary>
	/// <param name="database">当前数据库对象</param>
	/// <returns>如果当前数据库为Oracle返回true；否则返回false。</returns>
	/// <seealso cref="T:System.Data.Entity.Database" />
	public static bool IsOralce(this Database database)
	{
		database.GuardNotNull("Database");
		return database.Connection.ToString().IndexOf("OracleConnection") > -1;
	}

	/// <summary>
	/// 判断当前数据库是否是SqlServer
	/// </summary>
	/// <param name="database">当前数据库对象</param>
	/// <returns>如果当前数据库为SqlServer返回true；否则返回false。</returns>
	public static bool IsSqlServer(this Database database)
	{
		database.GuardNotNull("Database");
		return database.Connection.ToString().IndexOf("SqlConnection") > -1;
	}

	/// <summary>
	/// 执行SQL语句，根据查询结果集返回动态生成的结果对象列表
	/// </summary>
	/// <param name="database">当前数据库对象</param>
	/// <param name="sql">执行的SQL语句</param>
	/// <param name="dbParameters">SQL语句参数</param>
	/// <param name="parameters">SQL语句参数值</param>
	/// <returns>结果对象列表</returns>
	/// <remarks>
	/// Reads database schema from query, generates assembly in the memory, and returns dynamic object.
	/// </remarks>
	public static IList<IDataObject> DynamicSqlQuery(this Database database, string sql, DbParameter[] dbParameters = null, params object[] parameters)
	{
		WriteSqlLog(sql, parameters);
		return DynamicSqlQueryByReader(database, sql, dbParameters);
	}

	/// <summary>
	/// 执行SQL语句，根据查询一个或者多个结果集返回动态生成的结果对象列表数组
	/// </summary>
	/// <param name="database">当前数据库对象</param>
	/// <param name="sql">执行的SQL语句</param>
	/// <param name="dbParameters">SQL语句参数</param>
	/// <param name="parameters">SQL语句参数值</param>
	/// <returns>结果对象列表数组</returns>
	/// <remarks>
	/// Reads database schema from query, generates assembly in the memory, and returns dynamic object.
	/// </remarks>
	public static IList<IDataObject>[] DynamicSqlQueryResults(this Database database, string sql, DbParameter[] dbParameters = null, params object[] parameters)
	{
		WriteSqlLog(sql, parameters);
		return DynamicSqlQueryResultsByReader(database, sql, dbParameters);
	}

	public static int ExecuteCommand(this Database database, string sql, DbParameter[] dbParameters = null, params object[] parameters)
	{
		WriteSqlLog(sql, parameters);
		return ExecuteCommand(database, sql, dbParameters);
	}

	private static int ExecuteCommand(Database database, string sql, DbParameter[] dbParameters = null)
	{
		using IDbCommand command = database.Connection.CreateCommand();
		try
		{
			database.Connection.Open();
			command.CommandText = sql;
			command.CommandTimeout = command.Connection.ConnectionTimeout;
			if (database.IsOralce())
			{
				((OracleCommand)command).BindByName = true;
			}
			if (dbParameters != null && dbParameters.Length > 0)
			{
				foreach (DbParameter param in dbParameters)
				{
					command.Parameters.Add(param);
				}
			}
			return command.ExecuteNonQuery();
		}
		finally
		{
			command.Parameters.Clear();
			database.Connection.Close();
		}
	}

	private static IList<IDataObject> DynamicSqlQueryByReader(Database database, string sql, DbParameter[] dbParameters = null)
	{
		IList<IDataObject> result;
		using (IDbCommand command = database.Connection.CreateCommand())
		{
			try
			{
				database.Connection.Open();
				command.CommandText = sql;
				command.CommandTimeout = command.Connection.ConnectionTimeout;
				if (database.IsOralce())
				{
					((OracleCommand)command).BindByName = true;
				}
				if (dbParameters != null && dbParameters.Length > 0)
				{
					foreach (DbParameter param in dbParameters)
					{
						command.Parameters.Add(param);
					}
				}
				using IDataReader reader = command.ExecuteReader();
				result = ((IEnumerable<IDataObject>)DataObject.CreateObjects(reader, delegate(DataPropertyInfo dp)
				{
					dp.Name = dp.Name.ToUpper();
					if (dp.Type == typeof(byte[]) && dp.Size == 16)
					{
						if (dp.Nullable)
						{
							dp.Type = typeof(Guid?);
							if (dp.Value.IsNotNull())
							{
								byte[] array = dp.Value as byte[];
								dp.Value = (array.IsNull() ? null : new Guid?(new Guid(array)));
							}
						}
						else
						{
							dp.Type = typeof(Guid);
							if (dp.Value.IsNotNull())
							{
								byte[] array = dp.Value as byte[];
								dp.Value = (array.IsNull() ? Guid.Empty : new Guid(array));
							}
						}
					}
					return dp;
				})).ToList();
			}
			finally
			{
				command.Parameters.Clear();
				database.Connection.Close();
			}
		}
		result.ForEachParallel(delegate(IDataObject x)
		{
			TimeZoneHelper.UtcTimeToLocal(x);
		});
		return result;
	}

	private static IList<IDataObject> DynamicSqlQueryByEF(Database database, string sql, DbParameter[] dbParameters = null, params object[] parameters)
	{
		Type dataType = database.CreateDynamicDataType(sql, dbParameters);
		parameters = SortOracleParameters(database, sql, parameters);
		IEnumerable<IDataObject> queryResult = database.SqlQuery(dataType, sql, parameters).OfType<IDataObject>();
		queryResult.ForEachParallel(delegate(IDataObject x)
		{
			TimeZoneHelper.UtcTimeToLocal(x);
		});
		if (database.IsOralce())
		{
			return queryResult.Select((IDataObject x) => x.Map(delegate(DataPropertyInfo dp)
			{
				if (dp.Type == typeof(byte[]) && dp.Size == 16)
				{
					byte[] array = dp.Value as byte[];
					if (dp.Nullable)
					{
						dp.Type = typeof(Guid?);
						dp.Value = (array.IsNull() ? null : new Guid?(new Guid(array)));
					}
					else
					{
						dp.Type = typeof(Guid);
						dp.Value = (array.IsNull() ? Guid.Empty : new Guid(array));
					}
				}
				return dp;
			})).ToList();
		}
		return queryResult.ToList();
	}

	private static IList<IDataObject>[] DynamicSqlQueryResultsByReader(Database database, string sql, DbParameter[] dbParameters = null)
	{
		List<IList<IDataObject>> results = new List<IList<IDataObject>>();
		using (IDbCommand command = database.Connection.CreateCommand())
		{
			try
			{
				database.Connection.Open();
				command.CommandText = sql;
				command.CommandTimeout = command.Connection.ConnectionTimeout;
				if (database.IsOralce())
				{
					((OracleCommand)command).BindByName = true;
				}
				if (dbParameters != null && dbParameters.Length > 0)
				{
					foreach (DbParameter param in dbParameters)
					{
						command.Parameters.Add(param);
					}
				}
				using IDataReader reader = command.ExecuteReader();
				do
				{
					IList<IDataObject> result = ((IEnumerable<IDataObject>)DataObject.CreateObjects(reader, delegate(DataPropertyInfo dp)
					{
						dp.Name = dp.Name.ToUpper();
						if (dp.Type == typeof(byte[]) && dp.Size == 16)
						{
							if (dp.Nullable)
							{
								dp.Type = typeof(Guid?);
								if (dp.Value.IsNotNull())
								{
									byte[] array = dp.Value as byte[];
									dp.Value = (array.IsNull() ? null : new Guid?(new Guid(array)));
								}
							}
							else
							{
								dp.Type = typeof(Guid);
								if (dp.Value.IsNotNull())
								{
									byte[] array = dp.Value as byte[];
									dp.Value = (array.IsNull() ? Guid.Empty : new Guid(array));
								}
							}
						}
						return dp;
					})).ToList();
					results.Add(result);
				}
				while (reader.NextResult());
				if (results.Count == 1 && results[0].Count == 0)
				{
					results.Clear();
				}
			}
			finally
			{
				command.Parameters.Clear();
				database.Connection.Close();
			}
		}
		foreach (IList<IDataObject> r in results)
		{
			r.ForEachParallel(delegate(IDataObject x)
			{
				TimeZoneHelper.UtcTimeToLocal(x);
			});
		}
		return results.ToArray();
	}

	/// <summary>
	/// 根据查询结果集创建动态数据类型
	/// </summary>
	/// <param name="database">数据库上下文对象</param>
	/// <param name="sql">执行的查询SQL语句</param>
	/// <param name="dbParameters">查询参数</param>
	/// <returns>根据查询结果集生成的动态对象</returns>
	public static Type CreateDynamicDataType(this Database database, string sql, params DbParameter[] dbParameters)
	{
		using IDbCommand command = database.Connection.CreateCommand();
		try
		{
			database.Connection.Open();
			command.CommandText = sql.ToUpper();
			command.CommandTimeout = command.Connection.ConnectionTimeout;
			if (database.IsOralce())
			{
				((OracleCommand)command).BindByName = true;
			}
			if (dbParameters != null && dbParameters.Length > 0)
			{
				foreach (DbParameter param in dbParameters)
				{
					command.Parameters.Add(param);
				}
			}
			using IDataReader reader = command.ExecuteReader(CommandBehavior.KeyInfo);
			return DataObject.CreateType(reader);
		}
		finally
		{
			command.Parameters.Clear();
			database.Connection.Close();
		}
	}

	private static void WriteSqlLog(string sql, object[] parameters)
	{
		string sqlLog = string.Empty;
		string paraLog = string.Empty;
		sqlLog = "SQL:" + sql;
		TraceDebug.Write(sqlLog);
		if (parameters != null && parameters.Length > 0)
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
	}

	private static object[] SortOracleParameters(Database database, string sql, object[] parameters)
	{
		if (database.IsOralce() && parameters.Length > 0)
		{
			int[] paramIndices = Utility.GetOracleSqlParaIndex(sql);
			if (paramIndices.Length > 0)
			{
				List<object> sortedParameters = new List<object>();
				paramIndices.ForEach(delegate(int x)
				{
					sortedParameters.Add(parameters[x]);
				});
				return sortedParameters.ToArray();
			}
		}
		return parameters;
	}

	/// <summary>
	/// 从当前数据库中读取字节流并保存到临时文件
	/// </summary>
	/// <param name="database">当前数据库对象</param>
	/// <param name="sql">执行的SQL语句</param>
	/// <param name="fileName">保存的临时文件的完整名称</param>
	/// <param name="dbParameters">SQL语句参数</param>
	/// <returns>保存的临时文件</returns>
	public static Stream ReadDatabaseToFile(this Database database, string sql, string fileName, DbParameter[] dbParameters = null)
	{
		using IDbCommand command = database.Connection.CreateCommand();
		try
		{
			database.Connection.Open();
			command.CommandText = sql;
			if (database.IsOralce())
			{
				((OracleCommand)command).BindByName = true;
			}
			command.CommandTimeout = command.Connection.ConnectionTimeout;
			if (dbParameters != null && dbParameters.Any())
			{
				foreach (DbParameter param in dbParameters)
				{
					command.Parameters.Add(param);
				}
			}
			using IDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess);
			MemoryStream ms = new MemoryStream();
			Stream stream = ms;
			if (reader.Read())
			{
				byte[] buffer = new byte[8040];
				long readBytes = 0L;
				long count = 0L;
				while ((count = reader.GetBytes(0, readBytes, buffer, 0, buffer.Length)) > 0)
				{
					stream.Write(buffer, 0, (int)count);
					readBytes += count;
					if (readBytes > 1048576 && stream is MemoryStream)
					{
						string saveFileName = Guid.NewGuid().ToString() + Path.GetExtension(fileName);
						FileStream fs = new FileStream(Path.GetTempPath() + saveFileName, FileMode.Create);
						stream.Position = 0L;
						stream.CopyTo(fs);
						stream = fs;
					}
				}
			}
			reader.Close();
			stream.Position = 0L;
			return stream;
		}
		finally
		{
			command.Parameters.Clear();
			database.Connection.Close();
		}
	}
}
