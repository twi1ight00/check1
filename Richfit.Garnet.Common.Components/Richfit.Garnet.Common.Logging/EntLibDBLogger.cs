namespace Richfit.Garnet.Common.Logging;

/// <summary>
/// 通过企业库日志组件往数据库中存放日志信息
/// </summary>
public class EntLibDBLogger : ILogger
{
	/// <summary>
	/// 记录日志的模块名称
	/// </summary>
	private string moduleName;

	/// <summary>
	/// 初始化moduleName属性值
	/// </summary>
	/// <param name="moduleName">模块名</param>
	public EntLibDBLogger(string moduleName)
	{
		this.moduleName = moduleName;
	}

	/// <summary>
	/// 通过企业库日志组件往数据库中插入基本信息
	/// </summary>
	/// <param name="message">基本信息</param>
	public void Info(object message)
	{
	}

	/// <summary>
	/// 通过企业库日志组件往数据库中插入错误信息
	/// </summary>
	/// <param name="message"></param>
	public void Error(object message)
	{
	}

	/// <summary>
	/// 通过企业库日志组件往数据库中插入调试信息
	/// </summary>
	/// <param name="message">调试信息</param>
	public void Debug(object message)
	{
	}
}
