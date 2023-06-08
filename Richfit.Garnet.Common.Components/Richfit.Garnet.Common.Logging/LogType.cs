namespace Richfit.Garnet.Common.Logging;

/// <summary>
/// 系统日志的分类
/// </summary>
public class LogType
{
	/// <summary>
	/// 错误
	/// </summary>
	public const string Exception = "Exception";

	/// <summary>
	/// 数据载入缓存
	/// </summary>
	public const string DataCache = "DataCache";

	/// <summary>
	/// Quartz Server
	/// </summary>
	public const string Quartz = "Quartz";

	/// <summary>
	/// 瑞信 Mobile Server
	/// </summary>
	public const string RxMobile = "RxMobile";

	/// <summary>
	/// 盘点 Mobile Server
	/// </summary>
	public const string DeviceCheckMobile = "DeviceCheckMobile";
}
