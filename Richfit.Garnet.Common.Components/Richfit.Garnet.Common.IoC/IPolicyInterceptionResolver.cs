using System;
using System.Collections.Generic;
using System.Reflection;

namespace Richfit.Garnet.Common.IoC;

/// <summary>
/// 拦截策略解析器接口
/// </summary>
public interface IPolicyInterceptionResolver : IDisposable
{
	/// <summary>
	/// 获取拦截策略
	/// </summary>
	/// <param name="method">被拦截的方法对象</param>
	/// <param name="interceptorType">拦截器类型</param>
	/// <returns>拦截策略</returns>
	Dictionary<string, object> GetSettings(MethodBase method, Type interceptorType);
}
