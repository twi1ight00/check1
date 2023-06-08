using System;
using System.IO;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Watching;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// Quartz定时任务配置源
/// </summary>
public class QuartzJobConfigurationSource : FileConfigurationSource, IQuartzJobConfiguration, IConfiguration, IQuartzJobConfigurationSource, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 获取或者设置原始配置数据
	/// </summary>
	public override object RawData
	{
		get
		{
			return Text;
		}
		set
		{
			Text = (value.IsNull() ? string.Empty : value.ToString());
		}
	}

	/// <summary>
	/// 创建扩展设置配置源对象
	/// </summary>
	/// <param name="sourceGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="watcher">配置源监控器</param>
	public QuartzJobConfigurationSource(IConfigurationSourceGroup sourceGroup, string sourceName, string sourceFile, IWatcher watcher)
		: base(sourceGroup, sourceName, sourceFile, watcher)
	{
	}

	/// <summary>
	/// 创建扩展设置配置源对象
	/// </summary>
	/// <param name="sourceGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="timer">配置源监控定时器</param>
	public QuartzJobConfigurationSource(IConfigurationSourceGroup sourceGroup, string sourceName, string sourceFile, IWatchingTimer timer)
		: base(sourceGroup, sourceName, sourceFile, timer)
	{
	}

	/// <summary>
	/// 获取配置源
	/// </summary>
	/// <returns>配置数据</returns>
	public FileInfo GetConfiguration()
	{
		return base.File;
	}
}
