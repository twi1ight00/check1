using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Configuration.Designs;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Threading;

namespace Richfit.Garnet.Common.IoC;

/// <summary>
/// 拦截策略解析器
/// </summary>
public class PolicyInterceptionResolver : IPolicyInterceptionResolver, IDisposable
{
	/// <summary>
	/// 拦截策略映射
	/// 1. 服务类型
	/// 2. 服务名称
	/// 3. 拦截器类型
	/// 4. 拦截方法名称
	/// 5. 拦截器参数
	/// </summary>
	private Dictionary<Type, Dictionary<string, Dictionary<Type, Dictionary<object, Dictionary<string, object>>>>> policyInterception = new Dictionary<Type, Dictionary<string, Dictionary<Type, Dictionary<object, Dictionary<string, object>>>>>();

	/// <summary>
	/// 拦截策略配置
	/// </summary>
	private IConfiguration configuration;

	/// <summary>
	/// 拦截策略配置标识
	/// </summary>
	private Guid configurationID;

	/// <summary>
	/// 同步锁
	/// </summary>
	private ISyncLocker locker;

	/// <summary>
	/// 初始化拦截策略解析器
	/// </summary>
	/// <param name="configuration">配置源</param>
	public PolicyInterceptionResolver(IConfiguration configuration)
	{
		configuration.Guard((IConfiguration x) => x is IInterceptionGroupConfiguration);
		locker = configuration.SyncRoot;
		configurationID = configuration.SourceID;
		this.configuration = configuration;
		LoadPolicyInterceptions(this.configuration.As<IInterceptionGroupConfiguration>().GetConfiguration());
	}

	/// <summary>
	/// 清理
	/// </summary>
	public void Dispose()
	{
		locker.Write(delegate
		{
			policyInterception.Clear();
			configuration = null;
			configurationID = Guid.Empty;
		});
	}

	/// <summary>
	/// 加载拦截策略定义
	/// </summary>
	/// <param name="section"></param>
	private void LoadPolicyInterceptions(PolicyInterceptionSection section)
	{
		if (section.IsNull())
		{
			return;
		}
		Dictionary<object, Dictionary<string, object>> defaultSettings = new Dictionary<object, Dictionary<string, object>>();
		foreach (InterceptionTargetInterceptorElement interceptor in section.Interceptors)
		{
			defaultSettings.Add(interceptor.Type, interceptor.Settings.ToDictionary());
		}
		policyInterception.Clear();
		foreach (InterceptionTargetElement target in section.Targets)
		{
			target.Type.GuardNotNull();
			if (!policyInterception.ContainsKey(target.Type))
			{
				policyInterception.Add(target.Type, new Dictionary<string, Dictionary<Type, Dictionary<object, Dictionary<string, object>>>>());
			}
			Dictionary<string, Dictionary<Type, Dictionary<object, Dictionary<string, object>>>> targetNameMapping = policyInterception[target.Type];
			if (!targetNameMapping.ContainsKey(target.TargetName))
			{
				targetNameMapping.Add(target.TargetName, new Dictionary<Type, Dictionary<object, Dictionary<string, object>>>());
			}
			foreach (InterceptionTargetInterceptorElement interceptor in target.Interceptors)
			{
				Dictionary<Type, Dictionary<object, Dictionary<string, object>>> interceptorMapping = targetNameMapping[target.TargetName];
				if (!interceptorMapping.ContainsKey(interceptor.Type))
				{
					interceptorMapping.Add(interceptor.Type, new Dictionary<object, Dictionary<string, object>>());
				}
				Dictionary<object, Dictionary<string, object>> targetMethodMapping = interceptorMapping[interceptor.Type];
				object targetMethod = (target.MethodName.IsNullOrEmpty() ? ((IConvertible)DBNull.Value) : ((IConvertible)target.MethodName));
				if (!targetMethodMapping.ContainsKey(targetMethod))
				{
					targetMethodMapping.Add(targetMethod, interceptor.Settings.ToDictionary());
				}
			}
		}
		foreach (Dictionary<string, Dictionary<Type, Dictionary<object, Dictionary<string, object>>>> targetNameMapping in policyInterception.Values)
		{
			foreach (Dictionary<Type, Dictionary<object, Dictionary<string, object>>> interceptorMapping in targetNameMapping.Values)
			{
				foreach (KeyValuePair<Type, Dictionary<object, Dictionary<string, object>>> interceptorKvp in interceptorMapping)
				{
					Dictionary<string, object> setting = new Dictionary<string, object>();
					if (defaultSettings.ContainsKey(interceptorKvp.Key))
					{
						setting.Merge(defaultSettings[interceptorKvp.Key], overwrite: true);
					}
					if (interceptorKvp.Value.ContainsKey(DBNull.Value))
					{
						setting.Merge(interceptorKvp.Value[DBNull.Value], overwrite: true);
					}
					foreach (KeyValuePair<object, Dictionary<string, object>> targetMethodKvp in interceptorKvp.Value)
					{
						if (targetMethodKvp.Key != DBNull.Value)
						{
							targetMethodKvp.Value.Merge(setting);
						}
					}
				}
			}
		}
	}

	/// <summary>
	/// 获取拦截策略
	/// </summary>
	/// <param name="method">被拦截的方法对象</param>
	/// <param name="interceptorType">拦截器类型</param>
	/// <returns>拦截策略</returns>
	public Dictionary<string, object> GetSettings(MethodBase method, Type interceptorType)
	{
		if (method.IsNull() || interceptorType.IsNull())
		{
			return null;
		}
		return locker.Read(delegate
		{
			if (configuration.SourceID != configurationID)
			{
				locker.Write(delegate
				{
					if (configuration.SourceID != configurationID)
					{
						configurationID = configuration.SourceID;
						LoadPolicyInterceptions(configuration.As<IInterceptionGroupConfiguration>().GetConfiguration());
					}
				});
			}
			Type interceptionType = method.DeclaringType;
			if (!policyInterception.ContainsKey(interceptionType) && (interceptionType = policyInterception.Keys.FirstOrDefault((Type t) => interceptionType.IsType(t))).IsNull())
			{
				return null;
			}
			Dictionary<string, Dictionary<Type, Dictionary<object, Dictionary<string, object>>>> dictionary = policyInterception[interceptionType];
			if (!dictionary.ContainsKey(string.Empty))
			{
				return null;
			}
			Dictionary<Type, Dictionary<object, Dictionary<string, object>>> dictionary2 = dictionary[string.Empty];
			if (!dictionary2.ContainsKey(interceptorType))
			{
				return null;
			}
			Dictionary<object, Dictionary<string, object>> dictionary3 = dictionary2[interceptorType];
			if (dictionary3.ContainsKey(method.Name))
			{
				return dictionary3[method.Name];
			}
			object key;
			if ((key = dictionary3.Keys.FirstOrDefault((object k) => method.Name.IsMatch(k.ToString(), wholeMatching: true))).IsNotNull())
			{
				return dictionary3[key];
			}
			return dictionary3.ContainsKey(DBNull.Value) ? dictionary3[DBNull.Value] : null;
		});
	}
}
