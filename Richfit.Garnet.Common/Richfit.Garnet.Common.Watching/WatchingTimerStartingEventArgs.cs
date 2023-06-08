using System;

namespace Richfit.Garnet.Common.Watching;

/// <summary>
/// 监控定时器启动事件参数
/// </summary>
public class WatchingTimerStartingEventArgs : EventArgs
{
	/// <summary>
	/// 获取定时器启动事件
	/// </summary>
	public DateTime StartingTime { get; private set; }

	/// <summary>
	/// 是否已经取消启动
	/// </summary>
	public bool Cancelled { get; set; }

	/// <summary>
	/// 初始化监控定时器启动事件参数
	/// </summary>
	public WatchingTimerStartingEventArgs()
	{
		Cancelled = false;
		StartingTime = DateTime.Now;
	}

	/// <summary>
	/// 初始化监控定时器启动事件参数
	/// </summary>
	/// <param name="startingTime"></param>
	public WatchingTimerStartingEventArgs(DateTime startingTime)
		: this()
	{
		StartingTime = startingTime;
	}
}
