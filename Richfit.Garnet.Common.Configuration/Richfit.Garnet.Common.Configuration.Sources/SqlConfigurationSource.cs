using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Configuration.Designs;
using Richfit.Garnet.Common.Data;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Watching;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// SQL语句配置源
/// </summary>
public class SqlConfigurationSource : DotNetConfigurationSource, ISqlConfiguration, IConfiguration, ISqlConfigurationSource, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// SQL语句配置节
	/// </summary>
	private ConfigurationSettingGroupSection section;

	/// <summary>
	/// 获取或者设置原始配置文本
	/// </summary>
	public override string Text
	{
		get
		{
			return base.SyncRoot.Read(delegate
			{
				this.GuardNotDisposed();
				return section.IsNull() ? null : section.SectionInformation.GetRawXml();
			});
		}
		set
		{
			base.SyncRoot.Write(delegate
			{
				this.GuardNotDisposed();
				if (section.IsNotNull())
				{
					section.SectionInformation.SetRawXml(value.IfNull(string.Empty));
					Save();
				}
			});
		}
	}

	/// <summary>
	/// 获取指定名称的数据库SQL语句
	/// </summary>
	/// <param name="name">SQL语句名称</param>
	/// <returns>只返回名称匹配的第一条语句，如果没有找到匹配的SQL语句，则返回null</returns>
	public SqlStatement this[string name] => GetSql(name);

	/// <summary>
	/// 创建SQL语句配置源对象
	/// </summary>
	/// <param name="sourceGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="watcher">配置源监控器</param>
	public SqlConfigurationSource(IConfigurationSourceGroup sourceGroup, string sourceName, string sourceFile, IWatcher watcher)
		: base(sourceGroup, sourceName, sourceFile, watcher)
	{
	}

	/// <summary>
	/// 创建SQL语句配置源对象
	/// </summary>
	/// <param name="sourceGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="timer">配置源监控定时器</param>
	public SqlConfigurationSource(IConfigurationSourceGroup sourceGroup, string sourceName, string sourceFile, IWatchingTimer timer)
		: base(sourceGroup, sourceName, sourceFile, timer)
	{
	}

	/// <summary>
	/// 析构
	/// </summary>
	~SqlConfigurationSource()
	{
		Dispose(disposing: false);
	}

	/// <summary>
	/// 清理对象方法
	/// </summary>
	/// <param name="disposing"></param>
	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			section = null;
		}
		base.Dispose(disposing);
	}

	/// <summary>
	/// 加载配置源
	/// </summary>
	/// <returns>加载成功返回true，否则返回false</returns>
	protected override bool LoadConfiguration()
	{
		try
		{
			base.LoadConfiguration();
			section = base.Configuration.GetFirstSection<SqlConfigurationSection>();
			return base.IsValid = section.IsNotNull();
		}
		catch
		{
			throw;
		}
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
			return section.Groups.Select((ConfigurationSettingGroupElement g) => g.Settings.Count).Sum();
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
			ConfigurationSettingGroupElement configurationSettingGroupElement = section.Groups.Get(databaseName);
			return (!configurationSettingGroupElement.IsNull()) ? configurationSettingGroupElement.Settings.Count : 0;
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
			if (section.IsNull())
			{
				return null;
			}
			List<SqlStatement> list = new List<SqlStatement>();
			foreach (ConfigurationSettingGroupElement current in section.Groups)
			{
				foreach (ConfigurationSettingElement current2 in current.Settings)
				{
					list.Add(new SqlStatement(current.Name, current2.Name, current2.Value));
				}
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
			if (section.IsNull())
			{
				return null;
			}
			List<SqlStatement> list = new List<SqlStatement>();
			ConfigurationSettingGroupElement configurationSettingGroupElement = section.Groups.Get(databaseName);
			if (configurationSettingGroupElement.IsNotNull())
			{
				foreach (ConfigurationSettingElement current in configurationSettingGroupElement.Settings)
				{
					list.Add(new SqlStatement(configurationSettingGroupElement.Name, current.Name, current.Value));
				}
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
			if (section.IsNull())
			{
				return null;
			}
			foreach (ConfigurationSettingGroupElement current in section.Groups)
			{
				ConfigurationSettingElement configurationSettingElement = current.Settings.Get(name);
				if (configurationSettingElement.IsNotNull())
				{
					return new SqlStatement(current.Name, configurationSettingElement.Name, configurationSettingElement.Value);
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
			if (section.IsNull())
			{
				return null;
			}
			ConfigurationSettingGroupElement configurationSettingGroupElement = section.Groups.Get(databaseName);
			if (configurationSettingGroupElement.IsNotNull())
			{
				ConfigurationSettingElement configurationSettingElement = configurationSettingGroupElement.Settings.Get(name);
				if (configurationSettingElement.IsNotNull())
				{
					return new SqlStatement(configurationSettingGroupElement.Name, configurationSettingElement.Name, configurationSettingElement.Value);
				}
			}
			return null;
		});
	}

	/// <summary>
	/// 添加SQL语句
	/// </summary>
	/// <param name="databaseType">数据库类型</param>
	/// <param name="name">SQL语句名称</param>
	/// <param name="sql">SQL语句</param>
	/// <returns>添加成功返回true，否则返回false</returns>
	public bool AddSql(DBType databaseType, string name, string sql)
	{
		return AddSql(databaseType.ToString(), name, sql);
	}

	/// <summary>
	/// 添加SQL语句
	/// </summary>
	/// <param name="databaseName">数据库名称</param>
	/// <param name="name">SQL语句名称</param>
	/// <param name="sql">SQL语句</param>
	/// <returns>添加成功返回true，否则返回false</returns>
	public bool AddSql(string databaseName, string name, string sql)
	{
		databaseName.GuardNotNull();
		name.GuardNotNull();
		sql.GuardNotNull();
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNull())
			{
				return false;
			}
			ConfigurationSettingGroupElement configurationSettingGroupElement = section.Groups.Get(databaseName);
			if (configurationSettingGroupElement.IsNull())
			{
				configurationSettingGroupElement = new ConfigurationSettingGroupElement
				{
					Name = databaseName
				};
				section.Groups.Add(configurationSettingGroupElement);
			}
			ConfigurationSettingElement item = configurationSettingGroupElement.Settings.Get(name);
			if (item.IsNull())
			{
				item = new ConfigurationSettingElement
				{
					Name = name,
					Value = sql
				};
				configurationSettingGroupElement.Settings.Add(item);
				return true;
			}
			return false;
		});
	}

	/// <summary>
	/// 移除指定名称的SQL语句
	/// </summary>
	/// <param name="name">SQL语句名称</param>
	/// <returns>移除成功返回true，否则返回false</returns>
	public bool RemoveSql(string name)
	{
		name.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNull())
			{
				return false;
			}
			bool result = false;
			foreach (ConfigurationSettingGroupElement current in section.Groups)
			{
				if (current.Settings.Get(name).IsNotNull())
				{
					current.Settings.Remove(name);
					result = true;
				}
			}
			return result;
		});
	}

	/// <summary>
	/// 移除指定类型的SQL语句
	/// </summary>
	/// <param name="type">数据库类型</param>
	/// <param name="name">SQL语句名称</param>
	/// <returns>移除成功返回true，否则返回false</returns>
	public bool RemoveSql(DBType type, string name)
	{
		return RemoveSql(type.ToString(), name);
	}

	/// <summary>
	/// 移除指定类型的SQL语句
	/// </summary>
	/// <param name="databaseName">数据库名称</param>
	/// <param name="name">SQL语句名称</param>
	/// <returns>移除成功返回true，否则返回false</returns>
	public bool RemoveSql(string databaseName, string name)
	{
		databaseName.GuardNotNull();
		name.GuardNotNull();
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNull())
			{
				return false;
			}
			ConfigurationSettingGroupElement configurationSettingGroupElement = section.Groups.Get(databaseName);
			if (configurationSettingGroupElement.IsNull())
			{
				return false;
			}
			if (configurationSettingGroupElement.Settings.Get(name).IsNull())
			{
				return false;
			}
			configurationSettingGroupElement.Settings.Remove(name);
			return true;
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
			if (section.IsNull())
			{
				return false;
			}
			foreach (ConfigurationSettingGroupElement current in section.Groups)
			{
				if (current.Settings.Get(name).IsNotNull())
				{
					return true;
				}
			}
			return false;
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
			if (section.IsNull())
			{
				return false;
			}
			ConfigurationSettingGroupElement configurationSettingGroupElement = section.Groups.Get(databaseName);
			return !configurationSettingGroupElement.IsNull() && configurationSettingGroupElement.Settings.Get(name).IsNotNull();
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
			return !section.IsNull() && section.Groups.Get(databaseName).IsNotNull();
		});
	}
}
