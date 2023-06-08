using System;

namespace Richfit.Garnet.Common.IoC;

/// <summary>
/// 服务定位器接口
/// </summary>
public interface IServiceLocator : IServiceProvider, IDisposable
{
	/// <summary>
	/// 获取服务实例
	/// </summary>
	/// <typeparam name="T">服务类型</typeparam>
	/// <returns>服务实例</returns>
	T GetService<T>();

	/// <summary>
	/// 获取服务实例
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="name"></param>
	/// <returns></returns>
	T GetService<T>(string name);

	/// <summary>
	/// 获取服务实例
	/// </summary>
	/// <typeparam name="T">服务类型</typeparam>
	/// <param name="arguments">重载参数对象</param>
	/// <returns>服务实例</returns>
	T GetService<T>(object arguments);

	/// <summary>
	/// 获取服务实例
	/// </summary>
	/// <typeparam name="T">服务类型</typeparam>
	/// <param name="name">服务名称</param>
	/// <param name="arguments">重载参数对象</param>
	/// <returns>服务实例</returns>
	T GetService<T>(string name, object arguments);

	/// <summary>
	/// 获取服务实例
	/// </summary>
	/// <param name="type">服务类型</param>
	/// <param name="name">服务名称</param>
	/// <returns>服务实例</returns>
	object GetService(Type type, string name);

	/// <summary>
	/// 获取服务实例
	/// </summary>
	/// <param name="type"></param>
	/// <param name="arguments"></param>
	/// <returns></returns>
	object GetService(Type type, object arguments);

	/// <summary>
	/// 获取服务实例
	/// </summary>
	/// <param name="type">服务类型</param>
	/// <param name="name">服务名称</param>
	/// <param name="arguments">重载参数对象</param>
	/// <returns>服务实例</returns>
	object GetService(Type type, string name, object arguments);

	/// <summary>
	/// 填充服务实例
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="instance"></param>
	/// <returns>填充过的对象实例</returns>
	T BuildService<T>(T instance);

	/// <summary>
	/// 填充服务实例
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="instance"></param>
	/// <param name="name"></param>
	/// <returns>填充过的对象实例</returns>
	T BuildService<T>(T instance, string name);

	/// <summary>
	/// 填充服务实例
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="instance"></param>
	/// <param name="arguments"></param>
	/// <returns>填充过的对象实例</returns>
	T BuildService<T>(T instance, object arguments);

	/// <summary>
	/// 填充服务实例
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="instance"></param>
	/// <param name="name"></param>
	/// <param name="arguments"></param>
	/// <returns>填充过的对象实例</returns>
	T BuildService<T>(T instance, string name, object arguments);

	/// <summary>
	/// 填充服务实例
	/// </summary>
	/// <param name="instance"></param>
	/// <returns>填充过的对象实例</returns>
	object BuildService(object instance);

	/// <summary>
	/// 填充服务实例
	/// </summary>
	/// <param name="instance"></param>
	/// <param name="type"></param>
	/// <returns>填充过的对象实例</returns>
	object BuildService(object instance, Type type);

	/// <summary>
	/// 填充服务实例
	/// </summary>
	/// <param name="instance"></param>
	/// <param name="type"></param>
	/// <param name="name"></param>
	/// <returns></returns>
	object BuildService(object instance, Type type, string name);

	/// <summary>
	/// 填充服务实例
	/// </summary>
	/// <param name="instance"></param>
	/// <param name="type"></param>
	/// <param name="arguments"></param>
	/// <returns></returns>
	object BuildService(object instance, Type type, object arguments);

	/// <summary>
	/// 填充服务实例
	/// </summary>
	/// <param name="instance"></param>
	/// <param name="type"></param>
	/// <param name="name"></param>
	/// <param name="arguments"></param>
	/// <returns></returns>
	object BuildService(object instance, Type type, string name, object arguments);

	/// <summary>
	/// 获取映射类型
	/// 根据服务类型,获取当前映射到该类型的类型
	/// 无法获取则返回null
	/// </summary>
	/// <param name="type">服务类型</param>
	/// <param name="serviceName">服务名称</param>
	/// <returns>服务的基础类型</returns>
	Type ResolveMappedType(Type type, string serviceName = null);

	/// <summary>
	/// 获取拦截策略解析器
	/// </summary>
	/// <returns>拦截策略解析器</returns>
	IPolicyInterceptionResolver GetInterceptionResolver();
}
