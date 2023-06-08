using System;
using System.Configuration;
using System.Linq;
using Richfit.Garnet.Common.Configuration.Designs;
using Richfit.Garnet.Common.Data;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Watching;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 数据库配置源
/// </summary>
public class DatabaseConfigurationSource : DotNetConfigurationSource, IDatabaseConfiguration, IConfiguration, IDatabaseConfigurationSource, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 数据库连接串配置节
	/// </summary>
	private ConfigurationSettingSection section;

	/// <summary>
	/// 获取或者设置配置源文本
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
	/// 获取系统默认使用的数据库连接名称
	/// </summary>
	public DatabaseConnection DefaultConnection => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		string @default = section.Default;
		return @default.IsNullOrEmpty() ? null : GetConnection(@default);
	});

	/// <summary>
	/// 创建数据库配置源对象
	/// </summary>
	/// <param name="sourceGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="watcher">配置源监控器</param>
	public DatabaseConfigurationSource(IConfigurationSourceGroup sourceGroup, string sourceName, string sourceFile, IWatcher watcher)
		: base(sourceGroup, sourceName, sourceFile, watcher)
	{
	}

	/// <summary>
	/// 创建数据库配置源对象
	/// </summary>
	/// <param name="sourceGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="timer">配置源监控定时器</param>
	public DatabaseConfigurationSource(IConfigurationSourceGroup sourceGroup, string sourceName, string sourceFile, IWatchingTimer timer)
		: base(sourceGroup, sourceName, sourceFile, timer)
	{
	}

	/// <summary>
	/// 析构
	/// </summary>
	~DatabaseConfigurationSource()
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
	/// <returns></returns>
	protected override bool LoadConfiguration()
	{
		try
		{
			base.LoadConfiguration();
			section = base.Configuration.GetFirstSection<DatabaseConfigurationSection>();
			return base.IsValid = section.IsNotNull();
		}
		catch
		{
			throw;
		}
	}

	/// <summary>
	/// 获取全部数据库连接对象列表，如果不存在指定名称的数据库连接对象，则返回null
	/// </summary>
	/// <returns>全部的数据库连接对象</returns>
	public DatabaseConnection[] GetConnections()
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return section.IsNull() ? null : (from setting in section.Settings.WhereNotNull()
				select new DatabaseConnection(setting.Name, setting.Value, GetDBType(setting))).ToArray();
		});
	}

	/// <summary>
	/// 获取指定数据库类型的所有数据库连接
	/// </summary>
	/// <param name="type">数据库类型</param>
	/// <returns>数据库连接对象数组</returns>
	public DatabaseConnection[] GetConnections(DBType type)
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return section.IsNull() ? null : (from s in section.Settings
				where GetDBType(s) == type
				select s into setting
				select new DatabaseConnection(setting.Name, setting.Value, GetDBType(setting))).ToArray();
		});
	}

	/// <summary>
	/// 获取指定名称的数据库连接对象
	/// </summary>
	/// <param name="name">数据库连接名称</param>
	/// <returns>指定名称的数据库连接对象</returns>
	public DatabaseConnection GetConnection(string name)
	{
		name.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNull())
			{
				return null;
			}
			ConfigurationSettingElement configurationSettingElement = section.Settings.Get(name);
			return configurationSettingElement.IsNull() ? null : new DatabaseConnection(configurationSettingElement.Name, configurationSettingElement.Value, GetDBType(configurationSettingElement));
		});
	}

	/// <summary>
	/// 添加数据库连接
	/// </summary>
	/// <param name="name">数据库连接名称</param>
	/// <param name="connection">数据库连接字符串</param>
	/// <param name="type">数据库连接类型</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	public bool AddConnection(string name, string connection, DBType type)
	{
		name.GuardNotNull();
		connection.GuardNotNull();
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNull() || section.Settings.Contains(name))
			{
				return false;
			}
			section.Settings.Add(new ConfigurationSettingElement
			{
				Name = name,
				Value = connection,
				TypeName = type.ToString()
			});
			return true;
		});
	}

	/// <summary>
	/// 添加数据库连接对象
	/// </summary>
	/// <param name="connection">数据库连接对象</param>
	/// <returns>添加成功返回true，否则返回false</returns>
	public bool AddConnection(DatabaseConnection connection)
	{
		connection.GuardNotNull();
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNull() || section.Settings.Contains(connection.DatabaseName))
			{
				return false;
			}
			section.Settings.Add(new ConfigurationSettingElement
			{
				Name = connection.DatabaseName,
				Value = connection.ConnectionString,
				TypeName = connection.DatabaseType.ToString()
			});
			return true;
		});
	}

	/// <summary>
	/// 删除指定名称的数据库连接
	/// </summary>
	/// <param name="name">数据库连接名称</param>
	/// <returns>如果删除成功返回true，否则返回false</returns>
	public bool RemoveConnection(string name)
	{
		name.GuardNotNull();
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNotNull() && section.Settings.Contains(name))
			{
				section.Settings.Remove(name);
				return true;
			}
			return false;
		});
	}

	/// <summary>
	/// 删除指定名称的数据库连接
	/// </summary>
	/// <param name="connection">数据库连接对象</param>
	/// <returns>如果删除成功返回true，否则返回false</returns>
	public bool RemoveConnection(DatabaseConnection connection)
	{
		connection.GuardNotNull();
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNotNull() && section.Settings.Contains(connection.DatabaseName))
			{
				section.Settings.Remove(connection.DatabaseName);
				return true;
			}
			return false;
		});
	}

	/// <summary>
	/// 设置默认数据连接名称
	/// </summary>
	/// <param name="name">数据库连接名称</param>
	public void SetDefaultConnection(string name)
	{
		name.GuardNotNullAndEmpty();
		base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNull())
			{
				throw new InvalidOperationException();
			}
			ConfigurationSettingElement item = section.Settings.Get(name);
			if (item.IsNull())
			{
				throw new InvalidOperationException();
			}
			section.Default = name;
		});
	}

	/// <summary>
	/// 获取数据库连接类型
	/// </summary>
	/// <param name="element"></param>
	/// <returns></returns>
	private DBType GetDBType(ConfigurationSettingElement element)
	{
		if (Enum.TryParse<DBType>(element.TypeName, out var type))
		{
			return type;
		}
		throw new ConfigurationErrorsException();
	}
}
