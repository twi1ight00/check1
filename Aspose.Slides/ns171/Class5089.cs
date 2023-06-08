using System;
using System.Collections;
using System.Drawing;
using System.Xml;
using ns176;
using ns178;
using ns195;

namespace ns171;

internal abstract class Class5089 : Class5088, Interface169
{
	private Interface236 interface236_0;

	protected XmlElement xmlElement_0;

	protected XmlDocument xmlDocument_0;

	protected string string_2;

	private static Hashtable hashtable_0;

	public Class5089(Class5088 parent)
		: base(parent)
	{
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			method_11(loc, nsURI, localName);
		}
	}

	public override void vmethod_6(string elementName, Interface243 locatoR, Interface236 attlist, Class5634 propertyList)
	{
		method_0(locatoR);
		string_2 = elementName;
		interface236_0 = attlist;
	}

	public XmlDocument method_25()
	{
		return xmlDocument_0;
	}

	public virtual PointF vmethod_30(Point view, string baseDir)
	{
		return PointF.Empty;
	}

	public Interface182 method_26()
	{
		return null;
	}

	public override string vmethod_21()
	{
		return string_2;
	}

	static Class5089()
	{
		hashtable_0 = new Hashtable();
		hashtable_0.Add("xlink", "http://www.w3.org/1999/xlink");
	}

	public void method_27(XmlDocument doC, XmlElement parenT)
	{
		xmlDocument_0 = doC;
		xmlElement_0 = doC.CreateElement(string_2, vmethod_23());
		smethod_9(xmlElement_0, interface236_0);
		interface236_0 = null;
		parenT.AppendChild(xmlElement_0);
	}

	private static void smethod_9(XmlElement element, Interface236 attr)
	{
		for (int i = 0; i < attr.imethod_0(); i++)
		{
			string value = attr.imethod_4(i);
			string text = attr.imethod_1(i);
			int num = text.IndexOf(":");
			if (num == -1)
			{
				element.SetAttribute(text, value);
				continue;
			}
			string text2 = Class5479.smethod_0(text, 0, num);
			string text3 = text.Substring(num + 1);
			if (text2.Equals("xmlns"))
			{
				hashtable_0.Add(text3, value);
			}
			else
			{
				element.SetAttribute(text3, (string)hashtable_0[text2], value);
			}
		}
	}

	public void method_28(XmlDocument doc, XmlElement svgRoot)
	{
		smethod_9(xmlElement_0, interface236_0);
	}

	public XmlDocument method_29()
	{
		xmlDocument_0 = null;
		xmlElement_0 = null;
		try
		{
			xmlDocument_0 = new XmlDocument();
			XmlElement newChild = xmlDocument_0.CreateElement(string_2, vmethod_23());
			xmlDocument_0.AppendChild(newChild);
			xmlElement_0 = xmlDocument_0.DocumentElement;
			method_28(xmlDocument_0, xmlElement_0);
			if (!xmlElement_0.HasAttribute("xmlns", "http://www.w3.org/2000/xmlns/"))
			{
				xmlElement_0.SetAttribute("xmlns", "http://www.w3.org/2000/xmlns/", vmethod_23());
			}
			xmlElement_0.SetAttribute("xmlns:xlink", "http://www.w3.org/1999/xlink");
		}
		catch (Exception)
		{
		}
		return xmlDocument_0;
	}

	internal override void vmethod_12(Class5088 child)
	{
		if (child is Class5089)
		{
			((Class5089)child).method_27(xmlDocument_0, xmlElement_0);
		}
	}

	internal override void vmethod_9(char[] data, int start, int length, Class5634 pList, Interface243 locator)
	{
		base.vmethod_9(data, start, length, pList, locator);
		string text = new string(data, start, length);
		XmlText newChild = xmlDocument_0.CreateTextNode(text);
		xmlElement_0.AppendChild(newChild);
	}

	public void imethod_0(object obj)
	{
		xmlDocument_0 = (XmlDocument)obj;
		xmlElement_0 = xmlDocument_0.DocumentElement;
	}
}
