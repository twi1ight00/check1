namespace Richfit.Garnet.Common.Logging;

/// <summary>
/// 功能：建立一个简单工厂根据不同的业务需求实例化业务实体
/// </summary>
public class LoggerManager
{
	/// <summary>
	/// 返回日志实例类，模块名称如果为空，则按默认存放日志处理
	/// </summary>
	/// <param name="mouduleName">模块名称</param>
	/// <returns></returns>
	public static ILogger GetLogger(string mouduleName = "")
	{
		return GetLogger(LogCategory.Log4NetFile, mouduleName);
	}

	/// <summary>
	/// 按照业务类型，返回日志实例类，模块名称如果为空，则按默认存放日志处理
	/// </summary>
	/// <param name="category">日志业务实例类型</param>
	/// <param name="moduleName">模块名称</param>
	/// <returns></returns>
	public static ILogger GetLogger(LogCategory category, string moduleName = "")
	{
		return category switch
		{
			LogCategory.Log4NetFile => new Log4NetFileLogger(moduleName), 
			LogCategory.Log4NetDB => new Log4NetDBLogger(moduleName), 
			LogCategory.EntLibFile => new EntLibDBLogger(moduleName), 
			LogCategory.EntLibDB => new EntLibDBLogger(moduleName), 
			_ => new Log4NetFileLogger(moduleName), 
		};
	}
}
