using System;
using System.Timers;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Threading;

namespace Richfit.Garnet.Common.Watching;

/// <summary>
/// 监控定时器接口
/// </summary>
public interface IWatchingTimer : ISyncableObject, IReferencable, IDisposableObject, IDisposable
{
	/// <summary>
	/// 获取或者设置轮询时间间隔
	/// 如果设置的轮询时间间隔小于等于0，则恢复默认的时间间隔
	/// </summary>
	int PollingInterval { get; set; }

	/// <summary>
	/// 定时器定时事件
	/// </summary>
	event ElapsedEventHandler TimerElapsed;

	/// <summary>
	/// 定时器启动事件
	/// </summary>
	event EventHandler<WatchingTimerStartingEventArgs> TimerStarting;

	/// <summary>
	/// 定时器停止事件
	/// </summary>
	event EventHandler<WatchingTimerStoppingEventArgs> TimerStopping;

	/// <summary>
	/// 定时器清理事件
	/// </summary>
	event EventHandler TimerDisposed;

	/// <summary>
	/// 启动定时器
	/// </summary>
	void Start();

	/// <summary>
	/// 停止定时器
	/// </summary>
	void Stop();
}
