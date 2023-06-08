using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using Richfit.Garnet.Common.Configuration.Designs;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Watching;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// Quartz定时任务组件配置源
/// </summary>
public class QuartzConfigurationSource : SettingsConfigurationSource, IQuartzConfiguration, IConfiguration, IQuartzConfigurationSource, ISettingsConfigurationSource, IEnumerable<KeyValuePair<string, object>>, IEnumerable, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 初始化扩展设置配置源对象
	/// </summary>
	/// <param name="sourceGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="watcher">配置源监控器</param>
	public QuartzConfigurationSource(IConfigurationSourceGroup sourceGroup, string sourceName, string sourceFile, IWatcher watcher)
		: base(sourceGroup, sourceName, sourceFile, watcher)
	{
	}

	/// <summary>
	/// 初始化扩展设置配置源对象
	/// </summary>
	/// <param name="sourceGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="timer">配置源监控定时器</param>
	public QuartzConfigurationSource(IConfigurationSourceGroup sourceGroup, string sourceName, string sourceFile, IWatchingTimer timer)
		: base(sourceGroup, sourceName, sourceFile, timer)
	{
	}

	/// <summary>
	/// 析构
	/// </summary>
	~QuartzConfigurationSource()
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
		}
		base.Dispose(disposing);
	}

	/// <summary>
	/// 获取配置节
	/// </summary>
	/// <returns></returns>
	protected override ConfigurationSection GetSection()
	{
		return base.Configuration.GetFirstSection<QuartzConfigurationSection>();
	}

	/// <summary>
	/// 获取Unity配置节
	/// </summary>
	/// <returns></returns>
	public NameValueCollection GetConfiguration()
	{
		NameValueCollection collection = new NameValueCollection();
		ConfigurationSettingSection section = GetSection() as ConfigurationSettingSection;
		if (section.IsNotNull())
		{
			foreach (ConfigurationSettingElement setting in section.Settings)
			{
				collection.Add(setting.Name, setting.Value);
			}
		}
		return collection;
	}
}
