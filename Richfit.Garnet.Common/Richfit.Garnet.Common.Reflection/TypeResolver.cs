using System;
using System.Reflection;
using System.Threading;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

namespace Richfit.Garnet.Common.Reflection;

/// <summary>
/// 类型解析器；根据解析器的初始化类型不同，支持将类型名称、全名或者别名解析为类型对象
/// </summary>
public static class TypeResolver
{
	/// <summary>
	/// 类型解析器实现
	/// </summary>
	private static ITypeResolver resolver;

	/// <summary>
	/// 使用默认类型解析器初始化
	/// </summary>
	static TypeResolver()
	{
		resolver = null;
		LoadSystemResolver();
	}

	/// <summary>
	/// 加载系统类型解析器
	/// </summary>
	public static void LoadSystemResolver()
	{
		Interlocked.Exchange(ref resolver, new SystemTypeResolver());
	}

	/// <summary>
	/// 加载系统类型解析器
	/// </summary>
	/// <param name="assemblyResolving">解析器使用的程序集解析方法</param>
	/// <param name="typeResolving">解析器使用的类型解析方法</param>
	public static void LoadSystemResolver(Func<AssemblyName, Assembly> assemblyResolving, Func<Assembly, string, bool, Type> typeResolving)
	{
		Interlocked.Exchange(ref resolver, new SystemTypeResolver(assemblyResolving, typeResolving));
	}

	/// <summary>
	/// 加载基于容器的类型解析器
	/// </summary>
	public static void LoadContainerResolver(TypeResolverImpl unityResolver)
	{
		Interlocked.Exchange(ref resolver, new UnityTypeResolver(unityResolver));
	}

	/// <summary>
	/// 获取当前的类型解析器
	/// </summary>
	/// <returns>当前使用的类型解析器</returns>
	public static ITypeResolver GetResolver()
	{
		return resolver;
	}

	/// <summary>
	/// 获取当前的类型解析器
	/// </summary>
	/// <typeparam name="T">获取的解析器类型</typeparam>
	/// <returns>当前使用的类型解析器；如果当前解析器不是指定类型则返回空。</returns>
	public static T GetResolver<T>() where T : class, ITypeResolver
	{
		return resolver as T;
	}

	/// <summary>
	/// 将类型名称或者别名解析为类型对象
	/// </summary>
	/// <param name="name">类型名称或者别名</param>
	/// <returns>解析出的类型对象，如果无法解析返回空。</returns>
	/// <exception cref="T:System.ArgumentNullException">类型名称或者别名为空。</exception>
	public static Type Resolve(string name)
	{
		return resolver.ResolveType(name);
	}

	/// <summary>
	/// 将类型名称或者别名解析为类型对象
	/// </summary>
	/// <param name="name">类型名称或者别名</param>
	/// <param name="throwError">无法解析类型时是否抛出异常</param>
	/// <returns>解析出的类型对象，或者无法解析时，根据 <paramref name="throwError" /> 的设置返回空或者抛出异常。</returns>
	/// <exception cref="T:System.ArgumentNullException">类型名称或者别名为空。</exception>
	/// <exception cref="T:System.Exception">当 <paramref name="throwError" /> 为true时，无法解析类型名称或者别名。</exception>
	public static Type Resolve(string name, bool throwError)
	{
		return resolver.ResolveType(name, throwError);
	}

	/// <summary>
	/// 将类型名称或者别名解析为类型对象
	/// </summary>
	/// <param name="name">类型名称或者别名</param>
	/// <param name="throwError">无法解析类型时是否抛出异常</param>
	/// <param name="ignoreCase">解析类型名时是否区分大小写</param>
	/// <returns>解析出的类型对象，或者无法解析时，根据 <paramref name="throwError" /> 的设置返回空或者抛出异常。</returns>
	/// <exception cref="T:System.ArgumentNullException">类型名称或者别名为空。</exception>
	/// <exception cref="T:System.Exception">当 <paramref name="throwError" /> 为true时，无法解析类型名称或者别名。</exception>
	public static Type Resolve(string name, bool throwError, bool ignoreCase)
	{
		return resolver.ResolveType(name, throwError, ignoreCase);
	}
}
