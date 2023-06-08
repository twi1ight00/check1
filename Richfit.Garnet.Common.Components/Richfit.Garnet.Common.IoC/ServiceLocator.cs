using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Reflection;
using Richfit.Garnet.Common.Threading;

namespace Richfit.Garnet.Common.IoC;

/// <summary>
/// 服务定位器
/// </summary>
public sealed class ServiceLocator : IServiceLocator, IServiceProvider, IDisposable
{
	/// <summary>
	/// 同步锁
	/// </summary>
	private static ISyncLocker locker;

	/// <summary>
	/// 服务定位器静态实例
	/// </summary>
	private static IServiceLocator serviceLocator = null;

	/// <summary>
	/// Unity容器
	/// </summary>
	private IUnityContainer container;

	/// <summary>
	/// 拦截策略解析器
	/// </summary>
	private IPolicyInterceptionResolver policyResolver;

	/// <summary>
	/// 获取服务定位器实例
	/// 如果服务定位器未初始化，则返回null
	/// </summary>
	public static IServiceLocator Instance => locker.Read(() => serviceLocator);

	/// <summary>
	/// 初始化定位服务器
	/// </summary>
	/// <param name="configuration">主配置源</param>
	public static void Initialize(IMainConfiguration configuration)
	{
		configuration.GuardNotNull();
		locker = configuration.SyncRoot;
		locker.Write(delegate
		{
			if (ServiceLocator.serviceLocator.IsNull())
			{
				ServiceLocator serviceLocator = new ServiceLocator
				{
					container = new UnityContainer().LoadConfiguration(configuration.Unity.GetConfiguration())
				};
				FieldInfo fieldInfo = (from x in typeof(Microsoft.Practices.Unity.Configuration.ConfigurationHelpers.TypeResolver).GetFields(BindingFlags.Static | BindingFlags.NonPublic)
					where x.FieldType.ReferenceEquals(typeof(TypeResolverImpl))
					select x).FirstOrDefault();
				TypeResolverImpl unityResolver = (fieldInfo.IsNull() ? null : (fieldInfo.GetValue(null) as TypeResolverImpl));
				ServiceLocator.serviceLocator = serviceLocator;
				Richfit.Garnet.Common.Reflection.TypeResolver.LoadContainerResolver(unityResolver);
				serviceLocator.policyResolver = new PolicyInterceptionResolver(configuration.Interception);
			}
		});
	}

	/// <summary>
	/// 清理服务定位器
	/// </summary>
	public static void Dispose()
	{
		locker.Write(delegate
		{
			if (serviceLocator.IsNotNull())
			{
				serviceLocator.Dispose();
				serviceLocator = null;
			}
		});
	}

	/// <summary>
	/// 初始化服务定位器实例
	/// </summary>
	private ServiceLocator()
	{
	}

	/// <summary>
	/// 清理服务定位器
	/// </summary>
	void IDisposable.Dispose()
	{
		locker.Write(delegate
		{
			if (container.IsNotNull())
			{
				((IDisposable)container).Dispose();
				container = null;
			}
			if (policyResolver.IsNotNull())
			{
				policyResolver.Dispose();
				policyResolver = null;
			}
		});
	}

	/// <summary>
	/// 获取服务实例
	/// </summary>
	/// <param name="type">服务类型</param>
	/// <returns>服务实例对象</returns>
	public object GetService(Type type)
	{
		return GetService(type, null, null);
	}

	/// <summary>
	/// 获取服务实例
	/// </summary>
	/// <param name="type">服务类型</param>
	/// <param name="name">服务实例名称</param>
	/// <returns>服务实例对象</returns>
	public object GetService(Type type, string name)
	{
		return GetService(type, name, null);
	}

	/// <summary>
	/// 获取服务实例
	/// </summary>
	/// <param name="type">服务类型</param>
	/// <param name="arguments">服务实例初始化参数</param>
	/// <returns>服务实例对象</returns>
	public object GetService(Type type, object arguments)
	{
		return GetService(type, null, arguments);
	}

	/// <summary>
	/// 获取类型实例
	/// </summary>
	/// <param name="type">服务类型</param>
	/// <param name="name">服务实例名称</param>
	/// <param name="arguments">服务实例初始化参数</param>
	/// <returns>服务实例对象</returns>
	public object GetService(Type type, string name, object arguments)
	{
		type.GuardNotNull();
		return locker.Read(delegate
		{
			if (container.IsNotNull())
			{
				IEnumerable<ParameterOverride> parameterOverrides = GetParameterOverrides(arguments);
				return container.Resolve((Type)(object)type, name, parameterOverrides.ToArray());
			}
			return null;
		});
	}

	/// <summary>
	/// 获取服务实例
	/// </summary>
	/// <typeparam name="T">服务类型</typeparam>
	/// <returns>服务实例对象</returns>
	public T GetService<T>()
	{
		return (T)GetService(typeof(T));
	}

	/// <summary>
	/// 获取服务实例
	/// </summary>
	/// <typeparam name="T">服务类型</typeparam>
	/// <param name="name">服务实例名称</param>
	/// <returns>服务实例对象</returns>
	public T GetService<T>(string name)
	{
		return (T)GetService(typeof(T), name);
	}

	/// <summary>
	/// 获取服务实例
	/// </summary>
	/// <typeparam name="T">服务类型</typeparam>
	/// <param name="arguments">服务实例初始化参数</param>
	/// <returns>服务实例对象</returns>
	public T GetService<T>(object arguments)
	{
		return (T)GetService(typeof(T), arguments);
	}

	/// <summary>
	/// 获取服务实例
	/// </summary>
	/// <typeparam name="T">服务类型</typeparam>
	/// <param name="name">服务实例名称</param>
	/// <param name="arguments">服务实例初始化参数</param>
	/// <returns>服务实例对象</returns>
	public T GetService<T>(string name, object arguments)
	{
		return (T)GetService(typeof(T), name, arguments);
	}

	/// <summary>
	/// 填充服务实例
	/// </summary>
	/// <param name="instance">待填充服务实例</param>
	/// <returns>服务实例对象</returns>
	public object BuildService(object instance)
	{
		instance.GuardNotNull();
		return BuildService(instance, instance.GetType(), null, null);
	}

	/// <summary>
	/// 填充服务实例
	/// </summary>
	/// <param name="instance"></param>
	/// <param name="type"></param>
	/// <returns></returns>
	public object BuildService(object instance, Type type)
	{
		return BuildService(instance, type, null, null);
	}

	/// <summary>
	/// 填充服务实例
	/// </summary>
	/// <param name="instance"></param>
	/// <param name="type"></param>
	/// <param name="name"></param>
	/// <returns></returns>
	public object BuildService(object instance, Type type, string name)
	{
		return BuildService(instance, type, name, null);
	}

	/// <summary>
	/// 填充服务实例
	/// </summary>
	/// <param name="instance"></param>
	/// <param name="type"></param>
	/// <param name="arguments"></param>
	/// <returns></returns>
	public object BuildService(object instance, Type type, object arguments)
	{
		return BuildService(instance, type, null, arguments);
	}

	/// <summary>
	/// 填充服务实例
	/// </summary>
	/// <param name="instance">服务对象实例</param>
	/// <param name="type">服务类型</param>
	/// <param name="name">服务名称</param>
	/// <param name="arguments">重载参数对象</param>
	/// <returns>填充后的对象实例</returns>
	public object BuildService(object instance, Type type, string name, object arguments)
	{
		instance.GuardNotNull();
		type.GuardNotNull();
		return locker.Read(delegate
		{
			if (container.IsNotNull())
			{
				IEnumerable<ParameterOverride> parameterOverrides = GetParameterOverrides(arguments);
				return container.BuildUp((Type)(object)type, instance, name, parameterOverrides.ToArray());
			}
			return null;
		});
	}

	/// <summary>
	/// 填充服务实例
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="instance"></param>
	/// <returns>填充后的对象实例</returns>
	public T BuildService<T>(T instance)
	{
		return (T)BuildService(instance, typeof(T), null, null);
	}

	/// <summary>
	/// 填充服务实例
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="instance"></param>
	/// <param name="name"></param>
	/// <returns></returns>
	public T BuildService<T>(T instance, string name)
	{
		return (T)BuildService(instance, typeof(T), name, null);
	}

	/// <summary>
	/// 填充服务实例
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="instance"></param>
	/// <param name="arguments"></param>
	/// <returns></returns>
	public T BuildService<T>(T instance, object arguments)
	{
		return (T)BuildService(instance, typeof(T), null, arguments);
	}

	/// <summary>
	/// 填充服务实例
	/// </summary>
	/// <typeparam name="T">服务类型</typeparam>
	/// <param name="existing">服务对象实例</param>
	/// <param name="name">服务名称</param>
	/// <param name="arguments">重载参数对象</param>
	/// <returns>填充后的对象实例</returns>
	public T BuildService<T>(T existing, string name, object arguments)
	{
		return (T)BuildService(existing, typeof(T), name, arguments);
	}

	/// <summary>
	/// 获取映射类型
	/// 根据服务类型,获取当前映射到该类型的类型
	/// 无法获取则返回null
	/// </summary>
	/// <param name="type">服务类型</param>
	/// <param name="name">服务名称</param>
	/// <returns>服务的基础类型</returns>
	public Type ResolveMappedType(Type type, string name = null)
	{
		return locker.Read(delegate
		{
			foreach (ContainerRegistration current in (IEnumerable<ContainerRegistration>)container.Registrations)
			{
				if (((Type)(object)current.RegisteredType).ReferenceEquals(type) && (current.Name.EqualOrdinal(name) || (current.Name.IsNull() && name.IsNull())))
				{
					return (Type)(object)current.MappedToType;
				}
			}
			return null;
		});
	}

	/// <summary>
	/// 获取拦截策略解析器
	/// </summary>
	/// <returns>拦截策略解析器</returns>
	public IPolicyInterceptionResolver GetInterceptionResolver()
	{
		return locker.Read(() => policyResolver);
	}

	/// <summary>
	/// 获取参数重载列表
	/// </summary>
	/// <param name="overridedArguments">参数对象</param>
	/// <returns>重载的参数列表</returns>
	private IEnumerable<ParameterOverride> GetParameterOverrides(object overridedArguments)
	{
		List<ParameterOverride> overrides = new List<ParameterOverride>();
		if (overridedArguments.IsNotNull())
		{
			Type argumentsType = overridedArguments.GetType();
			PropertyInfo[] properties = argumentsType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (PropertyInfo pinfo in properties)
			{
				object propertyValue = pinfo.GetValue(overridedArguments, null);
				string propertyName = pinfo.Name;
				overrides.Add(new ParameterOverride(propertyName, propertyValue));
			}
		}
		return overrides;
	}
}
