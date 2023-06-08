using System;
using System.Reflection;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Reflection;

/// <summary>
/// 默认的类型解析器
/// </summary>
public class SystemTypeResolver : ITypeResolver, IDisposable
{
	/// <summary>
	/// 程序集解析方法
	/// </summary>
	private Func<AssemblyName, Assembly> assemblyResolving = null;

	/// <summary>
	/// 类型解析方法
	/// </summary>
	private Func<Assembly, string, bool, Type> typeResolving = null;

	/// <summary>
	/// 初始化系统类型解析器
	/// </summary>
	public SystemTypeResolver()
	{
	}

	/// <summary>
	/// 初始化系统类型解析器
	/// </summary>
	/// <param name="assemblyResolving">程序集解析方法</param>
	/// <param name="typeResolving">类型解析方法</param>
	public SystemTypeResolver(Func<AssemblyName, Assembly> assemblyResolving, Func<Assembly, string, bool, Type> typeResolving)
	{
		this.assemblyResolving = assemblyResolving;
		this.typeResolving = typeResolving;
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
		if (assemblyResolving.IsNotNull() || typeResolving.IsNotNull())
		{
			return Type.GetType(name, assemblyResolving, typeResolving);
		}
		return Type.GetType(name);
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
		if (assemblyResolving.IsNotNull() || typeResolving.IsNotNull())
		{
			return Type.GetType(name, assemblyResolving, typeResolving, throwError);
		}
		return Type.GetType(name, throwError);
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
	public Type ResolveType(string name, bool throwError, bool ignoreCase)
	{
		name.GuardNotNull("name");
		if (assemblyResolving.IsNotNull() || typeResolving.IsNotNull())
		{
			return Type.GetType(name, assemblyResolving, typeResolving, throwError, ignoreCase);
		}
		return Type.GetType(name, throwError, ignoreCase);
	}

	/// <summary>
	/// 清理对象
	/// </summary>
	public void Dispose()
	{
		assemblyResolving = null;
		typeResolving = null;
	}
}
