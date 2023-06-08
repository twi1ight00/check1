using System.Collections.Generic;
using System.Reflection;
using Microsoft.Practices.Unity.InterceptionExtension;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.AOP.Handler;

/// <summary>
/// 可配置的用于异常拦截的策略拦截器
/// </summary>
public class ConfigurableExceptionInterceptor : ConfigurablePolicyInterceptor
{
	/// <summary>
	/// 异常拦截处理器
	/// </summary>
	private ExceptionCallHandler handler = new ExceptionCallHandler();

	/// <summary>
	/// 初始化
	/// </summary>
	public ConfigurableExceptionInterceptor()
	{
	}

	/// <summary>
	/// 执行拦截调用
	/// </summary>
	/// <param name="input">将进行拦截的被调用方法</param>
	/// <param name="getNext">拦截调用链处理委托</param>
	/// <returns>方法调用的返回结果</returns>
	public override IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
	{
		Dictionary<string, object> settings = GetSettings((MethodBase)(object)input.MethodBase);
		string exceptionCode = settings.GetOrDefault("ErrorCode", string.Empty).ToString();
		string loggerName = settings.GetOrDefault("LoggerName", string.Empty).ToString();
		return handler.Invoke(input, getNext, exceptionCode);
	}
}
