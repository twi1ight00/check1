using System;
using System.Collections;
using System.IO;
using System.Xml;
using ns221;
using ns234;

namespace ns218;

internal class Class5944
{
	private readonly XmlTextReader xmlTextReader_0;

	public string Prefix => xmlTextReader_0.Prefix;

	public string LocalName => xmlTextReader_0.LocalName;

	private bool IsEmptyElement => xmlTextReader_0.IsEmptyElement;

	public string Value => xmlTextReader_0.Value;

	public int ValueAsInt => Class6159.smethod_7(Value);

	public double ValueAsDouble => Class6159.smethod_8(Value);

	internal virtual bool ValueAsBool => smethod_0(Value);

	public int ValueAsTruncatedInt => (int)(Class6159.smethod_19(xmlTextReader_0.Value) & 0xFFFFFFFFL);

	public string NamespaceURI => xmlTextReader_0.NamespaceURI;

	public Class5944(Stream stream)
	{
		stream.Position = 0L;
		xmlTextReader_0 = Class6169.smethod_1(stream);
		xmlTextReader_0.MoveToContent();
	}

	public Class5944(string xml, Hashtable namespaces)
	{
		xmlTextReader_0 = Class6169.smethod_2(xml, namespaces);
		xmlTextReader_0.MoveToContent();
	}

	public bool method_0(string parentElement)
	{
		return method_1(parentElement, Enum740.flag_0);
	}

	public bool method_1(string parentElement, Enum740 textHandling)
	{
		xmlTextReader_0.MoveToElement();
		if (IsEmptyElement && LocalName == parentElement)
		{
			return false;
		}
		while (xmlTextReader_0.Read())
		{
			switch (xmlTextReader_0.NodeType)
			{
			case XmlNodeType.Whitespace:
				if ((textHandling & Enum740.flag_3) != 0)
				{
					return true;
				}
				break;
			case XmlNodeType.SignificantWhitespace:
				if ((textHandling & Enum740.flag_2) != 0)
				{
					return true;
				}
				break;
			case XmlNodeType.EndElement:
				if (method_3(parentElement))
				{
					return false;
				}
				break;
			case XmlNodeType.Text:
				if ((textHandling & Enum740.flag_1) != 0)
				{
					return true;
				}
				break;
			case XmlNodeType.Element:
				return true;
			}
		}
		return false;
	}

	public void method_2()
	{
		xmlTextReader_0.MoveToElement();
		if (IsEmptyElement)
		{
			return;
		}
		string localName = LocalName;
		while (!method_3(localName))
		{
			xmlTextReader_0.Read();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
		}
	}

	public bool method_3(string elemName)
	{
		if (xmlTextReader_0.NodeType == XmlNodeType.EndElement)
		{
			return LocalName == elemName;
		}
		return false;
	}

	public string method_4(string localName, string defaultValue)
	{
		string result = defaultValue;
		while (xmlTextReader_0.MoveToNextAttribute())
		{
			if (LocalName == localName)
			{
				result = xmlTextReader_0.Value;
				break;
			}
		}
		xmlTextReader_0.MoveToElement();
		return result;
	}

	public int method_5(string localName, int defaultValue)
	{
		string text = method_4(localName, null);
		if (text == null)
		{
			return defaultValue;
		}
		return Class6159.smethod_7(text);
	}

	public double method_6(string localName, double defaultValue)
	{
		string text = method_4(localName, null);
		if (text == null)
		{
			return defaultValue;
		}
		return Class6159.smethod_8(text);
	}

	public bool method_7(string localName, bool defaultValue)
	{
		string text = method_4(localName, null);
		if (text == null)
		{
			return defaultValue;
		}
		return smethod_0(text);
	}

	private static bool smethod_0(string s)
	{
		if (!(s == "1") && !(s == "true"))
		{
			return s == "t";
		}
		return true;
	}

	public Guid method_8(string localName, Guid defaultValue)
	{
		string text = method_4(localName, null);
		if (text == null)
		{
			return defaultValue;
		}
		return new Guid(text);
	}

	public bool method_9()
	{
		return xmlTextReader_0.MoveToElement();
	}

	public bool method_10()
	{
		do
		{
			if (!xmlTextReader_0.MoveToNextAttribute())
			{
				return false;
			}
		}
		while (!(xmlTextReader_0.Prefix != "xmlns"));
		return true;
	}

	public string method_11()
	{
		return xmlTextReader_0.ReadString();
	}

	public int method_12()
	{
		return Class6159.smethod_7(method_11());
	}

	public bool method_13()
	{
		return Class6159.smethod_22(method_11());
	}

	public string method_14()
	{
		string result = xmlTextReader_0.ReadOuterXml();
		while (xmlTextReader_0.NodeType == XmlNodeType.Whitespace || xmlTextReader_0.NodeType == XmlNodeType.Text)
		{
			xmlTextReader_0.Read();
		}
		return result;
	}
}
