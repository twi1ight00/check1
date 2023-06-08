using System;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Watching;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 组配置源
/// </summary>
public class GroupConfigurationSource : DotNetGroupConfigurationSource, IGroupConfiguration, IConfiguration, IGroupConfigurationSource, IRefreshableConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 创建配置源对象
	/// </summary>
	/// <param name="parentGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="watcher">配置源监控器</param>
	public GroupConfigurationSource(IConfigurationSourceGroup parentGroup, string sourceName, string sourceFile, IWatcher watcher)
		: base(parentGroup, sourceName, sourceFile, watcher)
	{
	}

	/// <summary>
	/// 创建配置源对象
	/// </summary>
	/// <param name="parentGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="timer">配置源监控定时器</param>
	public GroupConfigurationSource(IConfigurationSourceGroup parentGroup, string sourceName, string sourceFile, IWatchingTimer timer)
		: base(parentGroup, sourceName, sourceFile, timer)
	{
	}
}
