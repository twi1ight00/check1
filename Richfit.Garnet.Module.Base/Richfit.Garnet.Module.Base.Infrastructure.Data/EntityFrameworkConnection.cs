using System.Data.EntityClient;
using System.Data.SqlClient;
using Oracle.DataAccess.Client;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Data;

namespace Richfit.Garnet.Module.Base.Infrastructure.Data;

/// <summary>
/// EntityFramework后台连接相关操作
/// </summary>
public static class EntityFrameworkConnection
{
	/// <summary>
	/// 获取Entity Framework连接字符串
	/// </summary>
	/// <param name="dbContextName">数据库连接名称</param>
	/// <returns>Entity Framework格式的连接字符串</returns>
	public static string GetEntityFrameworkConnectionString(string dbContextName)
	{
		DatabaseConnection databaseConnectionConfiguration = GetDbConnectionConfiguration(dbContextName);
		string connectionString = databaseConnectionConfiguration.ConnectionString;
		switch (databaseConnectionConfiguration.DatabaseType)
		{
		case DBType.Oracle:
		{
			OracleConnectionStringBuilder csb = new OracleConnectionStringBuilder(connectionString);
			EntityConnectionStringBuilder ecb = new EntityConnectionStringBuilder();
			ecb.Metadata = string.Format("res://*/Domain.Models.{0}Oracle.csdl|res://*/Domain.Models.{0}Oracle.ssdl|res://*/Domain.Models.{0}Oracle.msl", dbContextName);
			ecb.Provider = "Oracle.DataAccess.Client";
			ecb.ProviderConnectionString = csb.ConnectionString;
			return ecb.ConnectionString;
		}
		case DBType.SqlServer:
		{
			SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder(connectionString);
			EntityConnectionStringBuilder ecb = new EntityConnectionStringBuilder();
			ecb.Metadata = string.Format("res://*/Domain.Models.{0}Sql.csdl|res://*/Domain.Models.{0}Sql.ssdl|res://*/Domain.Models.{0}Sql.msl", dbContextName);
			ecb.Provider = "System.Data.SqlClient";
			ecb.ProviderConnectionString = scsb.ConnectionString;
			return ecb.ConnectionString;
		}
		default:
			return string.Empty;
		}
	}

	/// <summary>
	/// 获取数据库连接类型
	/// </summary>
	/// <param name="dbContextName">数据库连接名称</param>
	/// <returns>指定连接的数据库类型</returns>
	public static DBType GetDBType(string dbContextName)
	{
		DatabaseConnection databaseConnectionConfiguration = GetDbConnectionConfiguration(dbContextName);
		return databaseConnectionConfiguration.DatabaseType;
	}

	/// <summary>
	/// 获取数据库连接配置
	/// </summary>
	/// <param name="dbContextName">数据库连接名称</param>
	/// <returns>数据库连接配置对象</returns>
	public static DatabaseConnection GetDbConnectionConfiguration(string dbContextName)
	{
		if (!string.IsNullOrEmpty(dbContextName))
		{
			DatabaseConnection databaseConnectionConfiguration = ConfigurationManager.System.Database.GetConnection(dbContextName);
			if (databaseConnectionConfiguration == null)
			{
				databaseConnectionConfiguration = ConfigurationManager.System.Database.DefaultConnection;
			}
			return databaseConnectionConfiguration;
		}
		return ConfigurationManager.System.Database.DefaultConnection;
	}
}
