using System;
using System.Xml.Linq;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Xml.Linq.XElement" /> 类型扩展方法类
/// </summary>
public static class XElementExtension
{
	/// <summary>
	/// 获取当前Xml元素指定名称的属性的值
	/// </summary>
	/// <param name="element">当前Xml元素</param>
	/// <param name="attributeName">属性名称</param>
	/// <returns>返回指定名称的属性的值，如果指定名称的属性不存在则抛出异常。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前Xml元素为空；或者属性名称 <paramref name="attributeName" /> 为空或者空串。</exception>
	/// <exception cref="T:System.ArgumentException">由 <paramref name="attributeName" /> 指定的名称的属性不存在。</exception>
	public static string GetAttributeValue(this XElement element, string attributeName)
	{
		element.GuardNotNull("element");
		attributeName.GuardNotNullAndEmpty("attribute name");
		XAttribute attribute = element.Attribute(attributeName);
		if (attribute.IsNull())
		{
			throw new ArgumentException(Literals.MSG_XmlPropertyNotFound_2.FormatValue(attributeName, element.Name), "attribute name");
		}
		return attribute.Value;
	}

	/// <summary>
	/// 获取当前Xml元素指定名称的属性的值
	/// </summary>
	/// <param name="element">当前Xml元素</param>
	/// <param name="attributeName">属性名称</param>
	/// <param name="defaultValue">属性的默认值；如果指定名称的属性不存在返回的值</param>
	/// <returns>返回属性值，如果元素属性不存在则返回属性的默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前Xml元素为空；或者属性名称 <paramref name="attributeName" /> 为空或者空串。</exception>
	public static string GetAttributeValue(this XElement element, string attributeName, string defaultValue)
	{
		element.GuardNotNull("element");
		attributeName.GuardNotNullAndEmpty("attribute name");
		XAttribute attribute = element.Attribute(attributeName);
		return attribute.IsNull() ? defaultValue : attribute.Value;
	}

	/// <summary>
	/// 获取当前Xml元素指定名称的属性的值
	/// </summary>
	/// <typeparam name="T">元素属性值类型</typeparam>
	/// <param name="element">当前Xml元素</param>
	/// <param name="attributeName">属性名称</param>
	/// <returns>返回指定名称的属性的值，如果指定名称的属性不存在则抛出异常。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前Xml元素为空；或者属性名称 <paramref name="attributeName" /> 为空或者空串。</exception>
	/// <exception cref="T:System.ArgumentException">由 <paramref name="attributeName" /> 指定的名称的属性不存在。</exception>
	public static T GetAttributeValue<T>(this XElement element, string attributeName)
	{
		return element.GetAttributeValue(attributeName).ConvertTo<T>();
	}

	/// <summary>
	/// 获取当前Xml元素指定名称的属性的值
	/// </summary>
	/// <typeparam name="T">元素属性值类型</typeparam>
	/// <param name="element">当前Xml元素</param>
	/// <param name="attributeName">属性名称</param>
	/// <param name="defaultValue">元素属性值的默认值</param>
	/// <returns>返回指定名称的属性的值，如果元素属性不存在则返回指定的属性默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前Xml元素为空；或者属性名称 <paramref name="attributeName" /> 为空或者空串。</exception>
	public static T GetAttributeValue<T>(this XElement element, string attributeName, T defaultValue)
	{
		return element.GetAttributeValue(attributeName).ConvertTo(defaultValue);
	}
}
