using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Data;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// Sql配置原集合
/// </summary>
public class SqlConfigurationSourceGroup : ConfigurationSourceGroup, ISqlGroupConfiguration, IConfiguration, ISqlGroupConfigurationSource, IGroupConfigurationSource, IRefreshableConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 获取指定名称的数据库SQL语句
	/// </summary>
	/// <param name="name">SQL语句名称</param>
	/// <returns>只返回名称匹配的第一条语句，如果没有找到匹配的SQL语句，则返回null</returns>
	public SqlStatement this[string name] => GetSql(name);

	/// <summary>
	/// 使用配置源组初始化
	/// </summary>
	/// <param name="group">配置组</param>
	/// <param name="recursive">是否递归查找所有的子配置源</param>
	public SqlConfigurationSourceGroup(IConfigurationSourceGroup group, bool recursive = false)
		: base(group, recursive)
	{
	}

	/// <summary>
	/// 验证配置源
	/// </summary>
	/// <param name="source"></param>
	/// <returns></returns>
	protected override bool ValidateSource(IConfigurationSource source)
	{
		if (!base.ValidateSource(source))
		{
			return false;
		}
		return source is ISqlConfiguration;
	}

	/// <summary>
	/// 获取所有的SQL配置源
	/// </summary>
	/// <returns>SQL配置源数组</returns>
	public ISqlConfiguration[] GetConfigurations()
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return GetSources<ISqlConfiguration>();
		});
	}

	/// <summary>
	/// 获取指定名称的SQL配置源
	/// </summary>
	/// <param name="name">SQL配置源名称</param>
	/// <returns>SQL配置源</returns>
	public ISqlConfiguration GetConfiguration(string name)
	{
		name.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return GetSource<ISqlConfiguration>(name);
		});
	}

	/// <summary>
	/// 获取SQL语句数量
	/// </summary>
	/// <returns>SQL语句数量</returns>
	public int GetSqlCount()
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return (from source in base.ValidCachedSources.OfType<ISqlConfiguration>()
				select source.GetSqlCount()).Sum();
		});
	}

	/// <summary>
	/// 获取指定数据库类型的SQL语句数量
	/// </summary>
	/// <param name="databaseType">数据库类型</param>
	/// <returns>SQL语句数量</returns>
	public int GetSqlCount(DBType databaseType)
	{
		return GetSqlCount(databaseType.ToString());
	}

	/// <summary>
	/// 获取指定数据库的SQL语句数量
	/// </summary>
	/// <param name="databaseName">数据库名称</param>
	/// <returns>SQL语句数量</returns>
	public int GetSqlCount(string databaseName)
	{
		databaseName.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return (from source in base.ValidCachedSources.OfType<ISqlConfiguration>()
				select source.GetSqlCount(databaseName)).Sum();
		});
	}

	/// <summary>
	/// 获取所有的SQL语句
	/// </summary>
	/// <returns>SQL语句对象数组</returns>
	public SqlStatement[] GetSqls()
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			List<SqlStatement> list = new List<SqlStatement>();
			foreach (ISqlConfigurationSource sqlConfigurationSource in base.ValidCachedSources)
			{
				list.AddRange(sqlConfigurationSource.GetSqls());
			}
			return list.ToArray();
		});
	}

	/// <summary>
	/// 获取指定数据库类型的所有SQL语句
	/// </summary>
	/// <param name="databaseType">数据库类型</param>
	/// <returns>SQL语句对象数组</returns>
	public SqlStatement[] GetSqls(DBType databaseType)
	{
		return GetSqls(databaseType.ToString());
	}

	/// <summary>
	/// 获取指定数据库名称的所有SQL语句
	/// </summary>
	/// <param name="databaseName">数据库名称</param>
	/// <returns>SQL语句的字典</returns>
	public SqlStatement[] GetSqls(string databaseName)
	{
		databaseName.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			List<SqlStatement> list = new List<SqlStatement>();
			foreach (ISqlConfigurationSource sqlConfigurationSource in base.ValidCachedSources)
			{
				list.AddRange(sqlConfigurationSource.GetSqls(databaseName));
			}
			return list.ToArray();
		});
	}

	/// <summary>
	/// 获取指定名称的数据库SQL语句
	/// </summary>
	/// <param name="name">SQL语句名称</param>
	/// <returns>只返回名称匹配的第一条语句，如果没有找到匹配的SQL语句，则返回null</returns>
	public SqlStatement GetSql(string name)
	{
		name.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			foreach (ISqlConfigurationSource sqlConfigurationSource in base.ValidCachedSources)
			{
				if (sqlConfigurationSource.ContainsSql(name))
				{
					return sqlConfigurationSource.GetSql(name);
				}
			}
			return null;
		});
	}

	/// <summary>
	/// 获取指定数据库类型和名称的SQL语句
	/// </summary>
	/// <param name="databaseType">数据库类型</param>
	/// <param name="name">SQL语句名称</param>
	/// <returns>SQL语句</returns>
	public SqlStatement GetSql(DBType databaseType, string name)
	{
		return GetSql(databaseType.ToString(), name);
	}

	/// <summary>
	/// 获取指定数据库名称和SQL语句名称的SQL语句
	/// </summary>
	/// <param name="databaseName">数据库名称</param>
	/// <param name="name">SQL语句名称</param>
	/// <returns>SQL语句</returns>
	public SqlStatement GetSql(string databaseName, string name)
	{
		databaseName.GuardNotNull();
		name.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			foreach (ISqlConfigurationSource sqlConfigurationSource in base.ValidCachedSources)
			{
				if (sqlConfigurationSource.ContainsSql(databaseName, name))
				{
					return sqlConfigurationSource.GetSql(databaseName, name);
				}
			}
			return null;
		});
	}

	/// <summary>
	/// 检测是否包含指定名称的SQL语句
	/// </summary>
	/// <param name="name">SQL语句名称</param>
	/// <returns>如果包含指定名称的SQL语句返回true，否则返回false</returns>
	public bool ContainsSql(string name)
	{
		name.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return base.ValidCachedSources.OfType<ISqlConfiguration>().Any((ISqlConfiguration s) => s.ContainsSql(name));
		});
	}

	/// <summary>
	/// 检测是否包含指定数据库和指定名称的SQL语句
	/// </summary>
	/// <param name="databaseType">数据库类型</param>
	/// <param name="name">SQL语句名称</param>
	/// <returns>如果包含则返回true，否则返回false</returns>
	public bool ContainsSql(DBType databaseType, string name)
	{
		return ContainsSql(databaseType.ToString(), name);
	}

	/// <summary>
	/// 检测是否包含指定数据库和指定名称的SQL语句
	/// </summary>
	/// <param name="databaseName">数据库名称</param>
	/// <param name="name">SQL语句名称</param>
	/// <returns>如果包含则返回true，否则返回false</returns>
	public bool ContainsSql(string databaseName, string name)
	{
		databaseName.GuardNotNull();
		name.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return base.ValidCachedSources.OfType<ISqlConfiguration>().Any((ISqlConfiguration s) => s.ContainsSql(databaseName, name));
		});
	}

	/// <summary>
	/// 检测是否包含指定数据库类型的SQL语句
	/// </summary>
	/// <param name="databaseType">数据库类型</param>
	/// <returns>如果包含指定类型的数据库的SQL语句返回true，否则返回false</returns>
	public bool ContainsDatabase(DBType databaseType)
	{
		return ContainsDatabase(databaseType.ToString());
	}

	/// <summary>
	/// 检测是否包含指定名称的数据库的SQL语句
	/// </summary>
	/// <param name="databaseName">数据库名称</param>
	/// <returns>如果包含指定名称的数据库的SQL语句返回true，否则返回false</returns>
	public bool ContainsDatabase(string databaseName)
	{
		databaseName.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return base.ValidCachedSources.OfType<ISqlConfiguration>().Any((ISqlConfiguration s) => s.ContainsDatabase(databaseName));
		});
	}
}
