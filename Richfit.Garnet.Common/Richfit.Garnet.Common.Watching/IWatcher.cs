using System;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Threading;

namespace Richfit.Garnet.Common.Watching;

/// <summary>
/// 监控器接口
/// </summary>
public interface IWatcher : ISyncableObject, IReferencable, IDisposableObject, IDisposable
{
	/// <summary>
	/// 获取或者设置监控器定时器
	/// </summary>
	IWatchingTimer WatchingTimer { get; set; }

	/// <summary>
	/// 获取或者设置监控轮询时间间隔
	/// 如果设置的时间间隔小于等于0，则恢复为默认的时间间隔
	/// </summary>
	int WatchingInterval { get; set; }

	/// <summary>
	/// 监控事件
	/// </summary>
	event WatchingEventHandler WatchingNotify;

	/// <summary>
	/// 启动监控器
	/// </summary>
	void Start();

	/// <summary>
	/// 停止监控器
	/// </summary>
	void Stop();

	/// <summary>
	/// 刷新监控状态
	/// </summary>
	/// <param name="notify">是否触发通知事件</param>
	void Refresh(bool notify = true);
}
