using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using ns322;

namespace ns215;

internal class Class5932
{
	private CultureInfo cultureInfo_0;

	private XmlNamespaceManager xmlNamespaceManager_0;

	private Class7685 class7685_0;

	private List<Class5782> list_0 = new List<Class5782>();

	public List<Class5782> PrototypedElements => list_0;

	public Class7685 JsEngine => class7685_0;

	public XmlNamespaceManager Nsmgr => xmlNamespaceManager_0;

	internal Class5932(XmlNamespaceManager nsmgr, Class7685 jsEngine)
	{
		cultureInfo_0 = (CultureInfo)CultureInfo.CurrentCulture.Clone();
		cultureInfo_0.NumberFormat.CurrencyDecimalSeparator = ".";
		xmlNamespaceManager_0 = nsmgr;
		class7685_0 = jsEngine;
	}

	internal XmlNodeList method_0(string tag, XmlNode node)
	{
		return node.SelectNodes($"tpl:{tag}", xmlNamespaceManager_0);
	}

	internal string[] method_1(XmlNode node, string[] specifiedTags)
	{
		ArrayList arrayList = new ArrayList();
		foreach (XmlNode childNode in node.ChildNodes)
		{
			bool flag = false;
			foreach (string text in specifiedTags)
			{
				if (text == childNode.Name)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				arrayList.Add(childNode.Name);
			}
		}
		return (string[])arrayList.ToArray(typeof(string));
	}

	internal static float smethod_0(string value)
	{
		try
		{
			if (value.EndsWith("pt"))
			{
				return float.Parse(value.Substring(0, value.IndexOf("pt")), NumberStyles.Any, CultureInfo.InvariantCulture);
			}
			if (value.EndsWith("in"))
			{
				return float.Parse(value.Substring(0, value.IndexOf("in")), NumberStyles.Any, CultureInfo.InvariantCulture) * 72f;
			}
			if (value.EndsWith("cm"))
			{
				return float.Parse(value.Substring(0, value.IndexOf("cm")), NumberStyles.Any, CultureInfo.InvariantCulture) * 28.35f;
			}
			if (value.EndsWith("mm"))
			{
				return float.Parse(value.Substring(0, value.IndexOf("mm")), NumberStyles.Any, CultureInfo.InvariantCulture) * 2.835f;
			}
			if (value.EndsWith("%"))
			{
				return float.Parse(value.Substring(0, value.IndexOf("%")), NumberStyles.Any, CultureInfo.InvariantCulture) * 1f;
			}
			return float.Parse(value, NumberStyles.Any, CultureInfo.InvariantCulture);
		}
		catch (Exception)
		{
			return 0f;
		}
	}

	internal bool method_2(XmlNode node)
	{
		if (string.IsNullOrEmpty(node.Value))
		{
			throw new ArgumentException();
		}
		int num = int.Parse(node.Value);
		return num != 0;
	}

	internal decimal method_3(XmlNode node)
	{
		if (string.IsNullOrEmpty(node.Value))
		{
			throw new ArgumentException();
		}
		return decimal.Parse(node.Value, NumberStyles.Any, cultureInfo_0);
	}

	internal float method_4(XmlNode node)
	{
		if (string.IsNullOrEmpty(node.Value))
		{
			return 0f;
		}
		try
		{
			return float.Parse(node.Value, NumberStyles.Any, cultureInfo_0);
		}
		catch (Exception ex)
		{
			if (!(ex is FormatException))
			{
				throw;
			}
			return smethod_0(node.Value);
		}
	}

	internal int method_5(XmlNode node)
	{
		try
		{
			if (node.InnerText == null || node.InnerText.Length == 0)
			{
				throw new ArgumentException();
			}
			return int.Parse(node.InnerText);
		}
		catch (Exception)
		{
		}
		return 0;
	}

	internal string method_6(XmlNode node)
	{
		return node.Value;
	}

	internal string method_7(XmlNode node)
	{
		if (node.InnerText.Length != 0)
		{
			return node.InnerText;
		}
		return null;
	}

	internal string method_8(XmlNode node)
	{
		return node.InnerXml;
	}
}
