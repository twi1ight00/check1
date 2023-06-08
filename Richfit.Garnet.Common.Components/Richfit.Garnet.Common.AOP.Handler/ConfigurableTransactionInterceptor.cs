using Microsoft.Practices.Unity.InterceptionExtension;

namespace Richfit.Garnet.Common.AOP.Handler;

/// <summary>
/// 可配置的用于事务拦截的策略拦截器
/// </summary>
public class ConfigurableTransactionInterceptor : ConfigurablePolicyInterceptor
{
	/// <summary>
	/// 事务拦截处理器
	/// </summary>
	private TransactionCallHandler handler = new TransactionCallHandler();

	/// <summary>
	/// 初始化
	/// </summary>
	public ConfigurableTransactionInterceptor()
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
		return handler.Invoke(input, getNext);
	}
}
