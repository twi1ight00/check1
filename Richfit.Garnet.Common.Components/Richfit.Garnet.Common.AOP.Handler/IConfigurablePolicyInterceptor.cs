using Microsoft.Practices.Unity.InterceptionExtension;

namespace Richfit.Garnet.Common.AOP.Handler;

/// <summary>
/// 可配置策略拦截器接口
/// </summary>
public interface IConfigurablePolicyInterceptor : IMatchingRule, ICallHandler
{
}
