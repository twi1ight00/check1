using System.Collections.Generic;
using System.Reflection;
using Microsoft.Practices.Unity.InterceptionExtension;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;

namespace Richfit.Garnet.Common.AOP.Handler;

/// <summary>
/// 可配置策略拦截器
/// 拦截器可同时用作匹配规则和调用拦截
/// </summary>
public class ConfigurablePolicyInterceptor : IConfigurablePolicyInterceptor, IMatchingRule, ICallHandler
{
	/// <summary>
	/// 获取或者设置拦截调用的执行次序
	/// </summary>
	public virtual int Order { get; set; }

	/// <summary>
	/// 初始化拦截器基类
	/// </summary>
	public ConfigurablePolicyInterceptor()
	{
	}

	/// <summary>
	/// 执行拦截调用
	/// </summary>
	/// <param name="input">将进行拦截的被调用方法</param>
	/// <param name="getNext">拦截调用链处理委托</param>
	/// <returns>方法调用的返回结果</returns>
	public virtual IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
	{
		IMethodReturn result = getNext()(input, getNext);
		if (result.Exception.IsNotNull())
		{
			throw result.Exception;
		}
		return result;
	}

	/// <summary>
	/// 检测指定的方法是否符合拦截规则
	/// </summary>
	/// <param name="method">方法对象</param>
	/// <returns>如果符合拦截规则返回true,否则返回false.</returns>
	public virtual bool Matches(MethodBase method)
	{
		if (method.IsNull())
		{
			return false;
		}
		return GetSettings(method) != null;
	}

	/// <summary>
	/// 获取拦截器设置
	/// 设置不存在则返回null
	/// </summary>
	/// <param name="method">需要获取设置的被拦截方法</param>
	/// <returns></returns>
	protected Dictionary<string, object> GetSettings(MethodBase method)
	{
		if (method.IsNull() || ServiceLocator.Instance.IsNull())
		{
			return null;
		}
		return ServiceLocator.Instance.GetInterceptionResolver().GetSettings(method, GetType());
	}
}
