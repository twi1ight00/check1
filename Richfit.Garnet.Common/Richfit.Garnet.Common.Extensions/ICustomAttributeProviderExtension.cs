using System;
using System.Linq;
using System.Reflection;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Reflection.ICustomAttributeProvider" /> 接口扩展方法类
/// </summary>
public static class ICustomAttributeProviderExtension
{
	/// <summary>
	/// 获取当前对象上满足特性筛选条件的自定义特性
	/// </summary>
	/// <param name="provider">当前对象</param>
	/// <param name="predicate">特性筛选条件</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>符合条件的自定义特性的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者特性筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static Attribute[] GetCustomAttributes(this ICustomAttributeProvider provider, Func<Attribute, bool> predicate, bool inherit = false)
	{
		provider.GuardNotNull("attribute provider");
		predicate.GuardNotNull("attribute predicate");
		return provider.GetCustomAttributes(inherit).OfType<Attribute>().Where(predicate)
			.ToArray();
	}

	/// <summary>
	/// 获取当前对象上与特性基类型相同或者从特性基类型继承的，满足特性筛选条件的自定义特性
	/// </summary>
	/// <param name="provider">当前对象</param>
	/// <param name="attributeType">获取的自定义特性的基类型</param>
	/// <param name="predicate">特性筛选条件</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>符合条件的自定义特性的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者特性基类型 <paramref name="attributeType" /> 为空；或者特性筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">自定义特性的基类型 <paramref name="attributeType" /> 不是从 <see cref="T:System.Attribute" /> 继承的。</exception>
	public static Attribute[] GetCustomAttributes(this ICustomAttributeProvider provider, Type attributeType, Func<Attribute, bool> predicate, bool inherit = false)
	{
		provider.GuardNotNull("attribute provider");
		attributeType.GuardNotNull("attribute type").GuardInheritedType<Attribute>("attribute, type");
		predicate.GuardNotNull("attribute predicate");
		return provider.GetCustomAttributes(attributeType, inherit).OfType<Attribute>().Where(predicate)
			.ToArray();
	}

	/// <summary>
	/// 获取当前对象上与特性基类型相同或者从特性基类型继承的自定义特性
	/// </summary>
	/// <typeparam name="T">获取的自定义特性的基类型</typeparam>
	/// <param name="provider">当前对象</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>符合条件的自定义特性的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static T[] GetCustomAttributes<T>(this ICustomAttributeProvider provider, bool inherit = false) where T : Attribute
	{
		provider.GuardNotNull("attribute provider");
		return provider.GetCustomAttributes(typeof(T), inherit).OfType<T>().ToArray();
	}

	/// <summary>
	/// 获取当前对象上与特性基类型相同或者从特性基类型继承的，满足特性筛选条件的自定义特性
	/// </summary>
	/// <typeparam name="T">获取的自定义特性的基类型</typeparam>
	/// <param name="provider">当前对象</param>
	/// <param name="predicate">特性筛选条件</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>符合条件的自定义特性的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者特性筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static T[] GetCustomAttributes<T>(this ICustomAttributeProvider provider, Func<T, bool> predicate, bool inherit = false) where T : Attribute
	{
		provider.GuardNotNull("attribute provider");
		predicate.GuardNotNull("attribute predicate");
		return provider.GetCustomAttributes(typeof(T), inherit).OfType<T>().Where(predicate)
			.ToArray();
	}

	/// <summary>
	/// 获取当前对象上找到的第一个自定义特性
	/// </summary>
	/// <param name="provider">当前对象</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>当前对象找到的第一个自定义特性；如果没有则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static Attribute GetCustomAttribute(this ICustomAttributeProvider provider, bool inherit = false)
	{
		provider.GuardNotNull("attribute provider");
		return provider.GetCustomAttributes(inherit).OfType<Attribute>().FirstOrDefault();
	}

	/// <summary>
	/// 获取当前对象上与特性基类型相同或者从特性基类型继承的自定义特性
	/// </summary>
	/// <param name="provider">当前对象</param>
	/// <param name="attributeType">获取的自定义特性的基类型</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>符合条件的第一个自定义特性；如果没有符合条件的特性，返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者自定义特性的基类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">自定义特性的基类型 <paramref name="attributeType" /> 不是从 <see cref="T:System.Attribute" /> 继承的。</exception>
	public static Attribute GetCustomAttribute(this ICustomAttributeProvider provider, Type attributeType, bool inherit = false)
	{
		provider.GuardNotNull("attribute provider");
		attributeType.GuardNotNull("attribute type").GuardInheritedType<Attribute>("attribute type");
		return provider.GetCustomAttributes(attributeType, inherit).OfType<Attribute>().FirstOrDefault();
	}

	/// <summary>
	/// 获取当前对象上满足特性筛选条件的自定义特性
	/// </summary>
	/// <param name="provider">当前对象</param>
	/// <param name="predicate">特性筛选条件</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>符合条件的第一个自定义特性；如果没有符合条件的特性，返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者特性筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static Attribute GetCustomAttribute(this ICustomAttributeProvider provider, Func<Attribute, bool> predicate, bool inherit = false)
	{
		provider.GuardNotNull("attribute provider");
		predicate.GuardNotNull("attribute predicate");
		return provider.GetCustomAttributes(inherit).OfType<Attribute>().Where(predicate)
			.FirstOrDefault();
	}

	/// <summary>
	/// 获取当前对象上与特性基类型相同或者从特性基类型继承的，满足特性筛选条件的自定义特性
	/// </summary>
	/// <param name="provider">当前对象</param>
	/// <param name="attributeType">获取的自定义特性的基类型</param>
	/// <param name="predicate">特性筛选条件</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>符合条件的第一个自定义特性；如果没有符合条件的特性，返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者自定义特性的基类型 <paramref name="attributeType" /> 为空；或者特性筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">自定义特性的基类型 <paramref name="attributeType" /> 不是从 <see cref="T:System.Attribute" /> 继承的。</exception>
	public static Attribute GetCustomAttribute(this ICustomAttributeProvider provider, Type attributeType, Func<Attribute, bool> predicate, bool inherit = false)
	{
		provider.GuardNotNull("attribute provider");
		attributeType.GuardNotNull("attribute type").GuardInheritedType<Attribute>("attribute type");
		predicate.GuardNotNull("attribute predicate");
		return provider.GetCustomAttributes(attributeType, inherit).OfType<Attribute>().Where(predicate)
			.FirstOrDefault();
	}

	/// <summary>
	/// 获取当前对象上与特性基类型相同或者从特性基类型继承的自定义特性
	/// </summary>
	/// <typeparam name="T">获取的自定义特性的基类型</typeparam>
	/// <param name="provider">当前对象</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>符合条件的第一个自定义特性；如果没有符合条件的特性，返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static T GetCustomAttribute<T>(this ICustomAttributeProvider provider, bool inherit = false) where T : Attribute
	{
		provider.GuardNotNull("attribute provider");
		return provider.GetCustomAttributes(typeof(T), inherit).OfType<T>().FirstOrDefault();
	}

	/// <summary>
	/// 获取当前对象上与特性基类型相同或者从特性基类型继承的，满足特性筛选条件的自定义特性
	/// </summary>
	/// <typeparam name="T">获取的自定义特性的基类型</typeparam>
	/// <param name="provider">当前对象</param>
	/// <param name="predicate">特性筛选条件</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>符合条件的第一个自定义特性；如果没有符合条件的特性，返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者特性筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static T GetCustomAttribute<T>(this ICustomAttributeProvider provider, Func<T, bool> predicate, bool inherit = false) where T : Attribute
	{
		provider.GuardNotNull("attribute provider");
		predicate.GuardNotNull("attribute predicate");
		return provider.GetCustomAttributes(typeof(T), inherit).OfType<T>().Where(predicate)
			.FirstOrDefault();
	}

	/// <summary>
	/// 检测当前对象上是否定义了与特性基类型相同或者继承于该基类型的自定义特性
	/// </summary>
	/// <param name="provider">当前对象</param>
	/// <param name="attributeType">自定义特性的基类型</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>如果定义了符合条件的特性返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者自定义特性的基类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">自定义特性的基类型 <paramref name="attributeType" /> 不是从 <see cref="T:System.Attribute" /> 继承的。</exception>
	public static bool HasCustomAttribute(this ICustomAttributeProvider provider, Type attributeType, bool inherit = false)
	{
		provider.GuardNotNull("attribute provider");
		attributeType.GuardNotNull("attribute type");
		return provider.IsDefined(attributeType, inherit);
	}

	/// <summary>
	/// 检测当前对象上是否定义了与特性基类型相同或者继承于该基类型的自定义特性
	/// </summary>
	/// <typeparam name="T">自定义特性的基类型</typeparam>
	/// <param name="provider">当前对象</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>如果定义了符合条件的特性返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前反射的对象为空。</exception>
	public static bool HasCustomAttribute<T>(this ICustomAttributeProvider provider, bool inherit = false) where T : Attribute
	{
		provider.GuardNotNull("attribute provider");
		return provider.IsDefined(typeof(T), inherit);
	}
}
