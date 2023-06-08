using System;

namespace Richfit.Garnet.Common.Watching;

/// <summary>
/// 监控定时器停止事件处理
/// </summary>
public class WatchingTimerStoppingEventArgs : EventArgs
{
	/// <summary>
	/// 获取定时器启动事件
	/// </summary>
	public DateTime StoppingTime { get; private set; }

	/// <summary>
	/// 是否已经取消启动
	/// </summary>
	public bool Cancelled { get; set; }

	/// <summary>
	/// 初始化监控定时器启动事件参数
	/// </summary>
	public WatchingTimerStoppingEventArgs()
	{
		Cancelled = false;
		StoppingTime = DateTime.Now;
	}

	/// <summary>
	/// 初始化监控定时器启动事件参数
	/// </summary>
	/// <param name="stoppingTime"></param>
	public WatchingTimerStoppingEventArgs(DateTime stoppingTime)
		: this()
	{
		StoppingTime = stoppingTime;
	}
}
