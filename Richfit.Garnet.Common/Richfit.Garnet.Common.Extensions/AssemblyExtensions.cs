using System;
using System.Linq;
using System.Reflection;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Reflection.Assembly" /> 类型扩展方法类
///
/// 包括：
/// 1.Assembly类型的扩展方法
/// 2.以Assembly类型为约束的泛型的扩展方法
/// 3.Assembly类型数组或者泛型数组的扩展方法
/// 4.以Assembly类型为约束的泛型或者泛型数组的扩展方法
/// </summary>
public static class AssemblyExtensions
{
	/// <summary>
	/// 创建当前程序集中所有可实例化类型的实例
	/// </summary>
	/// <param name="assembly">当前程序集</param>
	/// <param name="creator">类型实例创建方法</param>
	/// <returns>所有符合条件类型的实例序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集为空。</exception>
	/// <remarks>如果未指定类型实例化方法则默认调用类型的无参数构造函数，如果没有无参数构造函数则忽略该类型。</remarks>
	public static object[] CreateInstance(this Assembly assembly, Func<Type, object> creator = null)
	{
		assembly.GuardNotNull("assembly");
		creator = creator.IfNull((Type t) => t.CreateInstance());
		return (from t in assembly.GetTypes()
			select creator(t)).ToArray();
	}

	/// <summary>
	/// 创建当前程序集中所有可实例化类型的实例
	/// </summary>
	/// <typeparam name="T">从当前程序集中选取的类型的基类类型</typeparam>
	/// <param name="assembly">当前程序集</param>
	/// <param name="creator">类型实例创建方法</param>
	/// <returns>所有符合条件类型的实例序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集为空。</exception>
	/// <remarks>如果未指定类型实例化方法则默认调用类型的无参数构造函数，如果没有无参数构造函数则忽略该类型。</remarks>
	public static T[] CreateInstance<T>(this Assembly assembly, Func<Type, T> creator = null)
	{
		assembly.GuardNotNull("assembly");
		creator = creator.IfNull((Type t) => t.CreateInstance<T>());
		return (from t in assembly.GetTypes()
			select creator(t)).ToArray();
	}

	/// <summary>
	/// 创建当前程序集中所有可实例化类型的实例
	/// </summary>
	/// <param name="assembly">当前程序集</param>
	/// <param name="predicate">当前程序集中类型的过滤条件</param>
	/// <param name="creator">类型实例创建方法</param>
	/// <returns>所有符合条件类型的实例序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <remarks>如果未指定类型实例化方法则默认调用类型的无参数构造函数，如果没有无参数构造函数则忽略该类型。</remarks>
	public static object[] CreateInstance(this Assembly assembly, Func<Type, bool> predicate, Func<Type, object> creator = null)
	{
		assembly.GuardNotNull("assembly");
		predicate.GuardNotNull("predicate");
		creator = creator.IfNull((Type t) => t.CreateInstance());
		return (from t in assembly.GetTypes().Where(predicate)
			select creator(t)).ToArray();
	}

	/// <summary>
	/// 创建当前程序集中所有可实例化类型的实例
	/// </summary>
	/// <typeparam name="T">从当前程序集中选取的类型的基类类型</typeparam>
	/// <param name="assembly">当前程序集</param>
	/// <param name="predicate">当前程序集中类型的过滤条件</param>
	/// <param name="creator">类型实例创建方法</param>
	/// <returns>所有符合条件类型的实例序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <remarks>如果未指定类型实例化方法则默认调用类型的无参数构造函数，如果没有无参数构造函数则忽略该类型。</remarks>
	public static T[] CreateInstance<T>(this Assembly assembly, Func<Type, bool> predicate, Func<Type, T> creator = null)
	{
		assembly.GuardNotNull("assembly");
		predicate.GuardNotNull("predicate");
		creator = creator.IfNull((Type t) => t.CreateInstance<T>());
		return (from t in assembly.GetTypes().Where(predicate)
			select creator(t)).ToArray();
	}

	/// <summary>
	/// 从当前的程序集中获取满足指定条件的类型
	/// </summary>
	/// <param name="assembly">当前程序集</param>
	/// <param name="predicate">类型筛选条件</param>
	/// <returns>返回当前程序集中符合条件的所有类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集为空；<paramref name="predicate" /> 为空。</exception>
	public static Type[] GetTypes(this Assembly assembly, Func<Type, bool> predicate)
	{
		assembly.GuardNotNull("assembly");
		predicate.GuardNotNull("predicate");
		return assembly.GetTypes().Where(predicate).ToArray();
	}

	/// <summary>
	/// 从当前的程序集中获取等于指定类型或者以指定类型为基类的类型
	/// </summary>
	/// <param name="assembly">当前程序集</param>
	/// <param name="baseType">类型的基类</param>
	/// <returns>当前程序集中与指定的基类类型相同或者是该基类的子类的所有类型的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集为空；<paramref name="baseType" /> 为空。</exception>
	public static Type[] GetTypes(this Assembly assembly, Type baseType)
	{
		assembly.GuardNotNull("assembly");
		baseType.GuardNotNull("base type");
		return assembly.GetTypes().WhereInheritedType(baseType).ToArray();
	}

	/// <summary>
	/// 从当前的程序集中获取以指定类型或者以指定类型为基类的类型
	/// </summary>
	/// <typeparam name="T">指定的类型基类</typeparam>
	/// <param name="assembly">当前程序集</param>
	/// <returns>当前程序集中与指定的基类类型相同或者是该基类的子类的所有类型的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集为空。</exception>
	public static Type[] GetTypes<T>(this Assembly assembly)
	{
		assembly.GuardNotNull("assembly");
		return assembly.GetTypes().WhereInheritedType<T>().ToArray();
	}

	/// <summary>
	/// 从当前程序集中获取以指定类型为基类且满足指定条件的类型
	/// </summary>
	/// <typeparam name="T">指定的类型基类</typeparam>
	/// <param name="assembly">当前程序集</param>
	/// <param name="predicate">类型筛选条件</param>
	/// <returns>返回指定程序集中符合条件的所有类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集为空；<paramref name="predicate" /> 为空。</exception>
	public static Type[] GetTypes<T>(this Assembly assembly, Func<Type, bool> predicate)
	{
		assembly.GuardNotNull("assembly");
		predicate.GuardNotNull("predicate");
		return assembly.GetTypes().WhereInheritedType<T>().Where(predicate)
			.ToArray();
	}

	/// <summary>
	/// 获取当前程序集完全名称
	/// </summary>
	/// <param name="assembly">当前程序集</param>
	/// <returns>获取的程序集完全名称。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集为空。</exception>
	public static string GetFullName(this Assembly assembly)
	{
		assembly.GuardNotNull("assembly");
		return assembly.GetName().FullName;
	}

	/// <summary>
	/// 获取当前程序集的版本号
	/// </summary>
	/// <param name="assembly">当前程序集</param>
	/// <returns>获取的程序集版本号</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集为空。</exception>
	public static Version GetVersion(this Assembly assembly)
	{
		assembly.GuardNotNull("assembly");
		return assembly.GetName().Version;
	}

	/// <summary>
	/// 获取当前程序集的版本完整字符表达式
	/// </summary>
	/// <param name="assembly">当前程序集</param>
	/// <returns>获取的程序集版本号</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集为空。</exception>
	public static string GetFullVersion(this Assembly assembly)
	{
		return assembly.GetVersion().ToString(4);
	}

	/// <summary>
	/// 获取当前程序集的版本简短字符表达式
	/// </summary>
	/// <param name="assembly">当前程序集</param>
	/// <returns>获取的程序集版本号</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集为空。</exception>
	public static string GetShortVersion(this Assembly assembly)
	{
		return assembly.GetVersion().ToString(2);
	}
}
