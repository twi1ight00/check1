using log4net;

namespace Richfit.Garnet.Common.Logging;

/// <summary>
/// 通过Log4Net组件往日志文件中存放日志信息
/// </summary>
public class Log4NetFileLogger : ILogger
{
	/// <summary>
	/// 记录日志的模块名称
	/// </summary>
	private string moduleName;

	/// <summary>
	/// 日志接口
	/// </summary>
	private ILog log;

	/// <summary>
	/// 初始化moduleName属性值
	/// </summary>
	/// <param name="moduleName">模块名</param>
	public Log4NetFileLogger(string moduleName)
	{
		this.moduleName = moduleName;
		log = LogManager.GetLogger(moduleName);
	}

	/// <summary>
	/// 通过Log4Net组件往日志文件中插入插入基本信息
	/// </summary>
	/// <param name="message">基本信息</param>
	public void Info(object message)
	{
		if (log.IsInfoEnabled)
		{
			log.Info(message);
		}
	}

	/// <summary>
	/// 通过Log4Net组件往日志文件中插入错误信息
	/// </summary>
	/// <param name="message">错误信息</param>
	public void Error(object message)
	{
		if (log.IsErrorEnabled)
		{
			log.Error(message);
		}
	}

	/// <summary>
	/// 通过Log4Net组件往日志文件中插入调试信息
	/// </summary>
	/// <param name="message">调试信息</param>
	public void Debug(object message)
	{
		if (log.IsDebugEnabled)
		{
			log.Debug(message);
		}
	}
}
