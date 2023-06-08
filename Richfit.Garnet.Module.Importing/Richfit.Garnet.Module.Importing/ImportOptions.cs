using System;
using System.Reflection;
using System.Xml.Linq;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Module.Importing;

/// <summary>
/// 导入选项
/// </summary>
public class ImportOptions
{
	/// <summary>
	/// 初始化默认选项
	/// </summary>
	public ImportOptions()
	{
	}

	/// <summary>
	/// 使用指定值初始化选项
	/// </summary>
	/// <param name="xml">Xml配置数据</param>
	public ImportOptions(string xml)
	{
		LoadOptions(xml);
	}

	/// <summary>
	/// 使用指定值初始化选项
	/// </summary>
	/// <param name="xml">Xml配置数据对象</param>
	public ImportOptions(XElement xml)
	{
		LoadOptions(xml);
	}

	/// <summary>
	/// 加载导入选项
	/// </summary>
	/// <param name="xml">Xml配置数据</param>
	public void LoadOptions(string xml)
	{
		xml.GuardNotNullAndEmpty();
		LoadOptions(XElement.Parse(xml));
	}

	/// <summary>
	/// 加载导入选项
	/// </summary>
	/// <param name="xml">Xml配置对象</param>
	public void LoadOptions(XElement xml)
	{
		xml.GuardNotNull();
		Type type = GetType();
		foreach (XAttribute attribute in xml.Attributes())
		{
			PropertyInfo pinfo = type.GetProperty(attribute.Name.LocalName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
			if (pinfo.IsNotNull())
			{
				pinfo.SetValue(this, attribute.Value.ConvertTo(pinfo.PropertyType), null);
			}
		}
	}
}
