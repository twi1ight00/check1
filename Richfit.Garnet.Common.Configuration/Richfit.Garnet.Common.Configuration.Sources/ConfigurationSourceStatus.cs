namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 配置源状态
/// </summary>
public enum ConfigurationSourceStatus
{
	/// <summary>
	/// 未改变
	/// </summary>
	Unchanged,
	/// <summary>
	/// 刷新
	/// </summary>
	Refreshing,
	/// <summary>
	/// 新增
	/// </summary>
	New,
	/// <summary>
	/// 移除
	/// </summary>
	Remove,
	/// <summary>
	/// 变更
	/// </summary>
	Changed,
	/// <summary>
	/// 遗失
	/// </summary>
	Missing,
	/// <summary>
	/// 失效
	/// </summary>
	Invalid,
	/// <summary>
	/// 已清理
	/// </summary>
	Disposed
}
