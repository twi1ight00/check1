using System;

namespace Richfit.Garnet.Common.Watching;

/// <summary>
/// 监控事件参数
/// </summary>
public class WatchingEventArgs : EventArgs
{
	/// <summary>
	/// 监控对象
	/// </summary>
	public object WatchingObject { get; protected set; }

	/// <summary>
	/// 监控状态
	/// </summary>
	public WatchingStatus WatchingStatus { get; protected set; }

	/// <summary>
	/// 监控事件发生时间
	/// </summary>
	public DateTime WatchingTime { get; protected set; }

	/// <summary>
	/// 创建监控事件参数
	/// </summary>
	/// <param name="watchingObject">监控对象</param>
	/// <param name="watchingStatus">监控状态</param>
	/// <param name="watchingTime">监控时间</param>
	public WatchingEventArgs(object watchingObject, WatchingStatus watchingStatus, DateTime watchingTime)
	{
		WatchingObject = watchingObject;
		WatchingStatus = watchingStatus;
		WatchingTime = watchingTime;
	}
}
