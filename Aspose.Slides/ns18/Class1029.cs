using System;
using System.Xml;

namespace ns18;

internal class Class1029
{
	public static string smethod_0(XmlElement elem, string localName, string namespaceURI, string defaultValue)
	{
		if (elem.HasAttribute(localName, namespaceURI))
		{
			return elem.GetAttribute(localName, namespaceURI);
		}
		return defaultValue;
	}

	public static float smethod_1(XmlElement elem, string localName, string namespaceURI, float defaultValue)
	{
		if (elem.HasAttribute(localName, namespaceURI))
		{
			return (float)XmlConvert.ToInt32(elem.GetAttribute(localName, namespaceURI)) / 60000f;
		}
		return defaultValue;
	}

	public static void smethod_2(XmlElement elem, string localName, string namespaceURI, float value)
	{
		elem.SetAttribute(localName, namespaceURI, XmlConvert.ToString((int)Math.Round(value * 60000f)));
	}

	public static float smethod_3(XmlElement elem, string localName, string namespaceURI, float defaultValue)
	{
		if (elem.HasAttribute(localName, namespaceURI))
		{
			return (float)XmlConvert.ToInt32(elem.GetAttribute(localName, namespaceURI)) / 1000f;
		}
		return defaultValue;
	}

	public static void smethod_4(XmlElement elem, string localName, string namespaceURI, float value)
	{
		elem.SetAttribute(localName, namespaceURI, XmlConvert.ToString((int)Math.Round(value * 1000f)));
	}

	public static void smethod_5(XmlElement elem, string localName, string namespaceURI, float value, float defaultValue)
	{
		int num = (int)Math.Round(value * 1000f);
		int num2 = (int)Math.Round(defaultValue * 1000f);
		if (num == num2)
		{
			elem.RemoveAttribute(localName, namespaceURI);
		}
		else
		{
			elem.SetAttribute(localName, namespaceURI, XmlConvert.ToString(num));
		}
	}

	public static void smethod_6(XmlElement elem, string localName, string namespaceURI, string value, string defaultValue)
	{
		if (!(value == defaultValue) && value != null)
		{
			elem.SetAttribute(localName, namespaceURI, value);
		}
		else
		{
			elem.RemoveAttribute(localName, namespaceURI);
		}
	}

	public static void smethod_7(XmlElement elem, string localName, string namespaceURI, int value)
	{
		elem.SetAttribute(localName, namespaceURI, XmlConvert.ToString(value));
	}

	public static void smethod_8(XmlElement elem, string localName, string namespaceURI, bool value)
	{
		elem.SetAttribute(localName, namespaceURI, value ? "1" : "0");
	}

	public static bool smethod_9(XmlElement element, string localName, string namespaceURI, bool defaultValue)
	{
		if (element.HasAttribute(localName, namespaceURI))
		{
			switch (element.GetAttribute(localName, namespaceURI))
			{
			default:
				return true;
			case "false":
			case "0":
			case "f":
				return false;
			}
		}
		return defaultValue;
	}

	public static XmlNode smethod_10(XmlDocumentFragment element, string localNameOfSubElement, string namespaceURI)
	{
		return smethod_12(element, localNameOfSubElement, namespaceURI);
	}

	public static XmlNode smethod_11(XmlElement element, string localNameOfSubElement, string namespaceURI)
	{
		return smethod_12(element, localNameOfSubElement, namespaceURI);
	}

	private static XmlNode smethod_12(XmlNode element, string localNameOfSubElement, string namespaceURI)
	{
		foreach (XmlNode childNode in element.ChildNodes)
		{
			if (childNode.LocalName == localNameOfSubElement && childNode.NamespaceURI == namespaceURI)
			{
				return childNode;
			}
		}
		return null;
	}

	public static XmlNode smethod_13(XmlNode element, string localName, string namespaceURI)
	{
		XmlNode xmlNode = smethod_12(element, localName, namespaceURI);
		if (xmlNode == null)
		{
			xmlNode = element.OwnerDocument.CreateElement(element.GetPrefixOfNamespace(namespaceURI), localName, namespaceURI);
			element.AppendChild(xmlNode);
		}
		return xmlNode;
	}

	public static int smethod_14(XmlElement element, string localName, string namespaceURI, int defaultValue)
	{
		if (element.HasAttribute(localName, namespaceURI))
		{
			return XmlConvert.ToInt32(element.GetAttribute(localName, namespaceURI));
		}
		return defaultValue;
	}
}
