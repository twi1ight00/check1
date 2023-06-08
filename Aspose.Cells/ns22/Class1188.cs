using System.IO;
using System.Xml;

namespace ns22;

internal class Class1188
{
	internal static XmlDocument smethod_0(string string_0)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(string_0);
		return xmlDocument;
	}

	internal static XmlDocument smethod_1(string string_0)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(string_0);
		return xmlDocument;
	}

	internal static XmlDocument smethod_2(Stream stream_0)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(stream_0);
		return xmlDocument;
	}

	internal static XmlDocument smethod_3(Stream stream_0)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.PreserveWhitespace = true;
		xmlDocument.Load(stream_0);
		return xmlDocument;
	}

	public static bool smethod_4(XmlElement xmlElement_0)
	{
		return xmlElement_0.IsEmpty;
	}

	internal static XmlNodeList smethod_5(XmlElement xmlElement_0, string string_0, string string_1)
	{
		return xmlElement_0.GetElementsByTagName(string_0, string_1);
	}

	internal static XmlAttribute smethod_6(XmlElement xmlElement_0, string string_0)
	{
		XmlAttributeCollection attributes = xmlElement_0.Attributes;
		int num = 0;
		XmlAttribute xmlAttribute;
		while (true)
		{
			if (num < attributes.Count)
			{
				xmlAttribute = attributes[num];
				if (xmlAttribute.LocalName == string_0)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return xmlAttribute;
	}

	internal static XmlAttribute smethod_7(XmlElement xmlElement_0, string string_0, string string_1)
	{
		return xmlElement_0.Attributes[string_0, string_1];
	}

	internal static XmlNode smethod_8(XmlNode xmlNode_0)
	{
		return xmlNode_0.FirstChild;
	}

	internal static XmlNode smethod_9(XmlNode xmlNode_0, XmlNode xmlNode_1, XmlNode xmlNode_2)
	{
		return xmlNode_0.InsertBefore(xmlNode_1, xmlNode_2);
	}

	internal static void smethod_10(XmlNode xmlNode_0, string string_0)
	{
		xmlNode_0.InnerXml = string_0;
	}

	internal static string smethod_11(XmlNode xmlNode_0)
	{
		return xmlNode_0.InnerXml;
	}

	internal static void smethod_12(XmlNode xmlNode_0, string string_0)
	{
		xmlNode_0.InnerText = string_0;
	}

	internal static string smethod_13(XmlNode xmlNode_0)
	{
		return xmlNode_0.InnerText;
	}

	internal static void smethod_14(XmlElement xmlElement_0, string string_0)
	{
		xmlElement_0.RemoveAttribute(string_0);
	}

	internal static bool smethod_15(XmlTextReader xmlTextReader_0)
	{
		while (true)
		{
			switch (xmlTextReader_0.NodeType)
			{
			case XmlNodeType.EndElement:
				xmlTextReader_0.ReadEndElement();
				return false;
			case XmlNodeType.None:
				return false;
			case XmlNodeType.Element:
				return true;
			}
			xmlTextReader_0.Skip();
		}
	}
}
