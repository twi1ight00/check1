using System;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Reflection;

/// <summary>
/// 基于Unity容器的类型解析器
/// </summary>
public class UnityTypeResolver : ITypeResolver, IDisposable
{
	/// <summary>
	/// Unity容器解析器实例
	/// </summary>
	private TypeResolverImpl unityResolver = null;

	/// <summary>
	/// 使用指定的Unity容器解析器初始化类型解析器
	/// </summary>
	/// <param name="unityResolver">Unity容器解析器</param>
	/// <exception cref="T:System.ArgumentNullException">Unity容器解析器为空。</exception>
	public UnityTypeResolver(TypeResolverImpl unityResolver)
	{
		unityResolver.GuardNotNull("unity resolver");
		this.unityResolver = unityResolver;
	}

	/// <summary>
	/// 将类型名称或者别名解析为类型对象
	/// </summary>
	/// <param name="name">类型名称或者别名</param>
	/// <returns>解析出的类型对象，如果无法解析返回空。</returns>
	/// <exception cref="T:System.ArgumentNullException">类型名称或者别名为空。</exception>
	public Type ResolveType(string name)
	{
		name.GuardNotNull("name");
		return (Type)(object)unityResolver.ResolveType(name, throwIfResolveFails: false);
	}

	/// <summary>
	/// 将类型名称或者别名解析为类型对象
	/// </summary>
	/// <param name="name">类型名称或者别名</param>
	/// <param name="throwError">无法解析类型时是否抛出异常</param>
	/// <returns>解析出的类型对象，或者无法解析时，根据 <paramref name="throwError" /> 的设置返回空或者抛出异常。</returns>
	/// <exception cref="T:System.ArgumentNullException">类型名称或者别名为空。</exception>
	/// <exception cref="T:System.Exception">当 <paramref name="throwError" /> 为true时，无法解析类型名称或者别名。</exception>
	public Type ResolveType(string name, bool throwError)
	{
		name.GuardNotNull("name");
		return (Type)(object)unityResolver.ResolveType(name, throwError);
	}

	/// <summary>
	/// 将类型名称或者别名解析为类型对象
	/// </summary>
	/// <param name="name">类型名称或者别名</param>
	/// <param name="throwError">无法解析类型时是否抛出异常</param>
	/// <param name="ignoreCase">解析类型名时是否区分大小写，忽略该参数的任何设置</param>
	/// <returns>解析出的类型对象，或者无法解析时，根据 <paramref name="throwError" /> 的设置返回空或者抛出异常。</returns>
	/// <exception cref="T:System.ArgumentNullException">类型名称或者别名为空。</exception>
	/// <exception cref="T:System.Exception">当 <paramref name="throwError" /> 为true时，无法解析类型名称或者别名。</exception>
	public Type ResolveType(string name, bool throwError, bool ignoreCase)
	{
		name.GuardNotNull("name");
		return (Type)(object)unityResolver.ResolveType(name, throwError);
	}

	/// <summary>
	/// 清理对象
	/// </summary>
	public void Dispose()
	{
		unityResolver = null;
	}
}
