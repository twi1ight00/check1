namespace Richfit.Garnet.Common.Logging;

/// <summary>
/// 功能：定义一个往数据库或文件中存放日志信息的接口
/// </summary>
public interface ILogger
{
	/// <summary>
	/// 往日志文件或数据库中的日志表中插入基本信息
	/// </summary>
	/// <param name="message">基本信息</param>
	void Info(object message);

	/// <summary>
	/// 往日志文件或数据库中的日志表中插入错误信息
	/// </summary>
	/// <param name="message">错误信息</param>
	void Error(object message);

	/// <summary>
	/// 往日志文件或数据库中的日志表中插入调试信息
	/// </summary>
	/// <param name="message">调试信息</param>
	void Debug(object message);
}
