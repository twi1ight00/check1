using System;
using System.Configuration;
using System.Text;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Watching;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// .Net配置源对象
/// </summary>
public class DotNetConfigurationSource : FileConfigurationSource, IDotNetConfiguration, IConfiguration, IDotNetConfigurationSource, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 配置对象
	/// </summary>
	private System.Configuration.Configuration configuration;

	/// <summary>
	/// 获取.NET标准配置文件对象
	/// </summary>
	public System.Configuration.Configuration Configuration => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return configuration;
	});

	/// <summary>
	/// 获取或者设置原始配置数据
	/// </summary>
	public override object RawData
	{
		get
		{
			return base.SyncRoot.Read(delegate
			{
				this.GuardNotDisposed();
				return base.Text;
			});
		}
		set
		{
			base.SyncRoot.Write(delegate
			{
				this.GuardNotDisposed();
				string text = (value.IsNull() ? string.Empty : value.ToString());
				if (!base.Text.EqualOrdinal(text))
				{
					base.Text = text;
					base.Save();
				}
			});
		}
	}

	/// <summary>
	/// 获取或者设置配置的原始文本
	/// </summary>
	public override string Text
	{
		get
		{
			return base.SyncRoot.Read(delegate
			{
				this.GuardNotDisposed();
				return base.Text;
			});
		}
		set
		{
			base.SyncRoot.Write(delegate
			{
				this.GuardNotDisposed();
				if (!Text.EqualOrdinal(value))
				{
					base.Text = value.IfNull(string.Empty);
					base.Save();
				}
			});
		}
	}

	/// <summary>
	/// 指示配置源是否存在
	/// </summary>
	public override bool Exists => base.SyncRoot.Write(delegate
	{
		this.GuardNotDisposed();
		return configuration.HasFile;
	});

	/// <summary>
	/// 创建配置源对象
	/// </summary>
	/// <param name="parentGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="watcher">配置源监控器</param>
	public DotNetConfigurationSource(IConfigurationSourceGroup parentGroup, string sourceName, string sourceFile, IWatcher watcher)
		: base(parentGroup, sourceName, sourceFile, watcher)
	{
		Initialize();
	}

	/// <summary>
	/// 创建配置源对象
	/// </summary>
	/// <param name="parentGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="timer">配置源监控定时器</param>
	public DotNetConfigurationSource(IConfigurationSourceGroup parentGroup, string sourceName, string sourceFile, IWatchingTimer timer)
		: base(parentGroup, sourceName, sourceFile, timer)
	{
		Initialize();
	}

	/// <summary>
	/// 创建配置源对象
	/// </summary>
	/// <param name="parentGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="configuration">配置文件</param>
	/// <param name="watcher">配置源监控器</param>
	public DotNetConfigurationSource(IConfigurationSourceGroup parentGroup, string sourceName, System.Configuration.Configuration configuration, IWatcher watcher)
		: base(parentGroup, sourceName, configuration.FilePath, watcher)
	{
		Initialize();
	}

	/// <summary>
	/// 创建配置源对象
	/// </summary>
	/// <param name="parentGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="configuration">配置文件</param>
	/// <param name="timer">配置源监控定时器</param>
	public DotNetConfigurationSource(IConfigurationSourceGroup parentGroup, string sourceName, System.Configuration.Configuration configuration, IWatchingTimer timer)
		: base(parentGroup, sourceName, configuration.FilePath, timer)
	{
		Initialize();
	}

	/// <summary>
	/// 初始化
	/// </summary>
	private void Initialize()
	{
		base.Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);
	}

	/// <summary>
	/// 析构
	/// </summary>
	~DotNetConfigurationSource()
	{
		Dispose(disposing: false);
	}

	/// <summary>
	/// 清理对象方法
	/// </summary>
	/// <param name="disposing">是否已经执行了清理</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			configuration = null;
		}
		base.Dispose(disposing);
	}

	/// <summary>
	/// 加载配置
	/// </summary>
	/// <returns>如果加载成功返回true，或者返回null</returns>
	protected override bool LoadConfiguration()
	{
		try
		{
			base.LoadConfiguration();
			configuration = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap
			{
				ExeConfigFilename = base.FullName
			}, ConfigurationUserLevel.None);
			if (configuration.HasFile)
			{
				return base.IsValid = true;
			}
			return base.IsValid = false;
		}
		catch
		{
			throw;
		}
	}

	/// <summary>
	/// 保存配置源
	/// </summary>
	public override void Save()
	{
		base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			configuration.Save(ConfigurationSaveMode.Modified);
			LoadConfiguration();
		});
	}

	/// <summary>
	/// 获取所有配置节
	/// </summary>
	/// <returns>配置源中所有配置节的集合</returns>
	public ConfigurationSection[] GetSections()
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return configuration.GetSections<ConfigurationSection>();
		});
	}

	/// <summary>
	/// 获取所有指定类型的配置节对象
	/// 返回配置节数组，没有匹配的配置节，返回空数组。
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <returns>匹配的配置节对象数组</returns>
	public T[] GetSections<T>() where T : ConfigurationSection
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return configuration.GetSections<T>();
		});
	}

	/// <summary>
	/// 获取指定名称的配置节对象
	/// 没有匹配的配置节，则返回null
	/// </summary>
	/// <param name="sectionName">配置节名称</param>
	/// <returns>匹配的配置节对象</returns>
	public ConfigurationSection GetSection(string sectionName)
	{
		sectionName.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return configuration.GetSection(sectionName);
		});
	}

	/// <summary>
	/// 获取指定类型的配置节对象
	/// 只返回第一个类型匹配的配置节，没有匹配的配置节，则返回null
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <returns>匹配的配置节对象</returns>
	public T GetSection<T>() where T : ConfigurationSection
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return configuration.GetFirstSection<T>();
		});
	}

	/// <summary>
	/// 获取指定名称、指定类型的配置节对象
	/// 没有匹配的配置节，则返回null
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="sectionName">配置节名称</param>
	/// <returns>匹配的配置节对象</returns>
	public T GetSection<T>(string sectionName) where T : ConfigurationSection
	{
		sectionName.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return configuration.GetSection<T>(sectionName);
		});
	}

	/// <summary>
	/// 添加指定名称的配置节
	/// </summary>
	/// <param name="sectionName">配置节名称</param>
	/// <param name="section">配置节对象</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	public bool AddSection(string sectionName, ConfigurationSection section)
	{
		sectionName.GuardNotNull();
		section.GuardNotNull();
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (configuration.Sections.Get(sectionName).IsNull())
			{
				configuration.Sections.Add(sectionName, section);
				return true;
			}
			return false;
		});
	}

	/// <summary>
	/// 添加指定名称的配置节
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="sectionName">配置节名称</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	public bool AddSection<T>(string sectionName) where T : ConfigurationSection, new()
	{
		sectionName.GuardNotNull();
		return AddSection(sectionName, new T());
	}

	/// <summary>
	/// 移除指定名称的配置节
	/// </summary>
	/// <param name="sectionName">配置节名称</param>
	/// <returns>如果移除成功返回true，否则返回false</returns>
	public bool RemoveSection(string sectionName)
	{
		sectionName.GuardNotNull();
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (configuration.Sections.Get(sectionName).IsNull())
			{
				return false;
			}
			configuration.Sections.Remove(sectionName);
			return true;
		});
	}
}
