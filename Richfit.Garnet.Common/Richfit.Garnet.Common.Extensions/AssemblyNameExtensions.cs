using System;
using System.Reflection;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Reflection.AssemblyName" /> 类型扩展方法类
///
/// 包括：
/// 1.AssemblyName类型的扩展方法
/// 2.以AssemblyName类型为约束的泛型的扩展方法
/// 3.AssemblyName类型数组或者泛型数组的扩展方法
/// 4.以AssemblyName类型为约束的泛型或者泛型数组的扩展方法
/// </summary>
public static class AssemblyNameExtensions
{
	/// <summary>
	/// 根据当前程序集名称加载程序集到当前应用程序域
	/// </summary>
	/// <param name="name">当前程序集名称</param>
	/// <returns>已加载的程序集对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集名称为空。</exception>
	public static Assembly Load(this AssemblyName name)
	{
		name.GuardNotNull("name");
		return Assembly.Load(name);
	}

	/// <summary>
	/// 根据当前程序集名称加载程序集到指定的应用程序域中；
	/// </summary>
	/// <param name="name">当前程序集名称</param>
	/// <param name="domain">加载的目标应用程序域</param>
	/// <returns>已加载的程序集对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集为空；或者 <paramref name="domain" /> 为空。</exception>
	/// <remarks>在将当前的程序集加载到指定的应用程序域中的同时，也会将该程序集加载到当前应用程序域中，并且返回加载到当前应用程序域中的程序集。</remarks>
	public static Assembly Load(this AssemblyName name, AppDomain domain)
	{
		name.GuardNotNull("name");
		domain.GuardNotNull("domain");
		return domain.Load(name);
	}
}
