using System;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Watching;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 受监控的配置源接口
/// </summary>
public interface IWatchingConfigurationSource : IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 获取或者设置是否正在监控配置源
	/// </summary>
	bool IsWatching { get; set; }

	/// <summary>
	/// 获取配置源监控器
	/// </summary>
	IWatcher Watcher { get; }

	/// <summary>
	/// 配置变更事件
	/// </summary>
	event ConfigurationSourceChangedEventHandler SourceChanged;

	/// <summary>
	/// 配置源清理前事件
	/// </summary>
	event ConfigurationSourceDisposingEventHandler SourceDisposing;

	/// <summary>
	/// 配置源清理事件
	/// </summary>
	event ConfigurationSourceDisposedEventHandler SourceDisposed;
}
