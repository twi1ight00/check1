using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Data;
using Richfit.Garnet.Module.Base.Infrastructure.Data;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

namespace Richfit.Garnet.Module.Base.Domain.Models;

/// <summary>
/// 公共仓储，仓储没有具体的Entity，针对数据库可通用
/// </summary>
public class SqlRepository : DBContextBase, IRepositoryExtender, ISql, ISqlQueryConverter
{
	/// <summary>
	/// 初始化公共仓储
	/// </summary>
	public SqlRepository()
		: base("CommonDb")
	{
	}

	/// <summary>
	/// 初始化公共仓储
	/// </summary>
	/// <param name="name">使用的仓储名称（数据库连接名称）</param>
	public SqlRepository(object name)
		: base((object.ReferenceEquals(name, null) || name.GetType() == typeof(object)) ? "CommonDb" : name.ToString())
	{
	}

	/// <summary>
	/// 模型创建方法处理
	/// </summary>
	/// <param name="modelBuilder"></param>
	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepositoryExtender.GetSqlConfig(System.String,System.Type)" />
	public string GetSqlConfig(string sqlKey, Type type)
	{
		SqlStatement statement = ConfigurationManager.GetPackage(type).Sqls.GetSql(GetDatabaseType(), sqlKey);
		return statement.Sql;
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepositoryExtender.GetSqlStatement(System.String,System.Type)" />
	public SqlStatement GetSqlStatement(string sqlKey, Type type)
	{
		return ConfigurationManager.GetPackage(type).Sqls.GetSql(GetDatabaseType(), sqlKey);
	}
}
