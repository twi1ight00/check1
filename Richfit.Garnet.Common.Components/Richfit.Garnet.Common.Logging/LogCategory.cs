namespace Richfit.Garnet.Common.Logging;

/// <summary>
/// 日志接口4种不同的实现方式
/// </summary>
public enum LogCategory
{
	/// <summary>
	/// 用于写入数据库日志通过Log4Net
	/// </summary>
	Log4NetDB,
	/// <summary>
	/// 用于写入日志文件通过Log4Net
	/// </summary>
	Log4NetFile,
	/// <summary>
	/// 用于写入数据库日志通过企业库
	/// </summary>
	EntLibDB,
	/// <summary>
	/// 用于写入日志文件通过企业库
	/// </summary>
	EntLibFile
}
