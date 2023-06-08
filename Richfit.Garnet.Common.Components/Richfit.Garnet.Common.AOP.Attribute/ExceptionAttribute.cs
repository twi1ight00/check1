using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Richfit.Garnet.Common.AOP.Handler;

namespace Richfit.Garnet.Common.AOP.Attribute;

/// <summary>
/// 用于异常拦截的策略拦截特性
/// </summary>
public class ExceptionAttribute : HandlerAttribute
{
	/// <summary>
	/// 异常编码
	/// </summary>
	public string ExceptionCode { get; set; }

	/// <summary>
	/// 使用指定的异常编码初始化异常拦截特性
	/// </summary>
	/// <param name="exceptionCode">异常编码</param>
	public ExceptionAttribute(string exceptionCode)
	{
		ExceptionCode = exceptionCode;
	}

	/// <summary>
	/// 创建异常拦截处理器
	/// </summary>
	/// <param name="container">Unity容器对象</param>
	/// <returns>异常拦截处理器</returns>
	public override ICallHandler CreateHandler(IUnityContainer container)
	{
		ExceptionCallHandler exceptionCallHandler = new ExceptionCallHandler(ExceptionCode);
		exceptionCallHandler.Order = base.Order;
		return exceptionCallHandler;
	}
}
