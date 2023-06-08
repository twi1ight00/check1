namespace Richfit.Garnet.Common.Watching;

/// <summary>
/// 监控状态
/// </summary>
public enum WatchingStatus
{
	/// <summary>
	/// 状态未改变
	/// </summary>
	Unchanged,
	/// <summary>
	/// 新增状态
	/// </summary>
	New,
	/// <summary>
	/// 状态改变
	/// </summary>
	Changed,
	/// <summary>
	/// 缺失状态
	/// </summary>
	Missing
}
