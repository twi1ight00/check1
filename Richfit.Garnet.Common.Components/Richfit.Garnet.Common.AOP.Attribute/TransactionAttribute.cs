using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Richfit.Garnet.Common.AOP.Handler;

namespace Richfit.Garnet.Common.AOP.Attribute;

/// <summary>
/// 用于事务拦截的策略拦截特性
/// </summary>
public class TransactionAttribute : HandlerAttribute
{
	/// <summary>
	/// 初始化事务拦截特性
	/// </summary>
	public TransactionAttribute()
	{
	}

	/// <summary>
	/// 创建事务拦截处理器
	/// </summary>
	/// <param name="container">Unity容器对象</param>
	/// <returns>事务拦截处理器</returns>
	public override ICallHandler CreateHandler(IUnityContainer container)
	{
		TransactionCallHandler transactionCallHandler = new TransactionCallHandler();
		transactionCallHandler.Order = base.Order;
		return transactionCallHandler;
	}
}
