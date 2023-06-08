using System;
using System.Xml;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Xml.XmlDocument" /> 类型扩展方法对象
/// </summary>
public static class XmlDocumentExtensions
{
	/// <summary>
	/// 将当前Xml文档反序列化为对象
	/// </summary>
	/// <param name="xmldoc">当前Xml文档对象</param>
	/// <param name="type">反序列化的目标对象类型</param>
	/// <returns>反序列化生成的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前Xml文档对象为空；或者反序列化的目标类型 <paramref name="type" /> 为空。</exception>
	public static object XmlDeserialize(this XmlDocument xmldoc, Type type)
	{
		xmldoc.GuardNotNull("xmldoc");
		type.GuardNotNull("type");
		return xmldoc.InnerXml.XmlDeserialize(type);
	}

	/// <summary>
	/// 将当前Xml文档反序列化为对象
	/// </summary>
	/// <param name="xmldoc">当前Xml文档对象</param>
	/// <param name="type">反序列化的目标对象类型</param>
	/// <param name="defaultValue">无法反序列化时返回的对象</param>
	/// <returns>反序列化生成的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前Xml文档对象为空；或者反序列化的目标类型 <paramref name="type" /> 为空。</exception>
	public static object XmlDeserialize(this XmlDocument xmldoc, Type type, object defaultValue)
	{
		xmldoc.GuardNotNull("xmldoc");
		type.GuardNotNull("type");
		return xmldoc.InnerXml.XmlDeserialize(type, defaultValue);
	}

	/// <summary>
	/// 将当前Xml文档反序列化为对象
	/// </summary>
	/// <typeparam name="T">反序列化的目标对象类型</typeparam>
	/// <param name="xmldoc">当前Xml文档对象</param>
	/// <returns>反序列化生成的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前Xml文件对象为空。</exception>
	public static T XmlDeserialize<T>(this XmlDocument xmldoc)
	{
		xmldoc.GuardNotNull("xmldoc");
		return xmldoc.InnerXml.XmlDeserialize<T>();
	}

	/// <summary>
	/// 将当前Xml文档反序列化为对象
	/// </summary>
	/// <typeparam name="T">反序列化的目标对象类型</typeparam>
	/// <param name="xmldoc">当前Xml文档对象</param>
	/// <param name="defaultValue">无法反序列化时返回的对象</param>
	/// <returns>反序列化生成的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前Xml文件对象为空。</exception>
	public static T XmlDeserialize<T>(this XmlDocument xmldoc, T defaultValue)
	{
		xmldoc.GuardNotNull("xmldoc");
		return xmldoc.InnerXml.XmlDeserialize(defaultValue);
	}
}
