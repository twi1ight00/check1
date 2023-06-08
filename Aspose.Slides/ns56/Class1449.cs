using System;
using System.Xml;

namespace ns56;

internal class Class1449 : Class1447
{
	public delegate void Delegate384(Class1449 elementData);

	public delegate Class1449 Delegate383();

	private XmlDocument xmlDocument_0;

	public XmlDocument XmlDocument
	{
		get
		{
			return xmlDocument_0;
		}
		set
		{
			xmlDocument_0 = value;
			base.OuterXml = xmlDocument_0.OuterXml;
		}
	}

	public override string OuterXml
	{
		get
		{
			base.OuterXml = xmlDocument_0.OuterXml;
			return base.OuterXml;
		}
		set
		{
			xmlDocument_0 = new XmlDocument();
			XmlDocumentFragment xmlDocumentFragment = xmlDocument_0.CreateDocumentFragment();
			xmlDocumentFragment.InnerXml = value;
			xmlDocument_0.AppendChild(xmlDocumentFragment);
			base.OuterXml = value;
		}
	}

	internal Class1449(XmlReader reader)
		: base(reader)
	{
		xmlDocument_0 = new XmlDocument();
		XmlDocumentFragment xmlDocumentFragment = xmlDocument_0.CreateDocumentFragment();
		xmlDocumentFragment.InnerXml = base.OuterXml;
		xmlDocument_0.AppendChild(xmlDocumentFragment);
	}

	internal Class1449()
	{
	}

	public void method_2(Class1449 elementData)
	{
		throw new NotImplementedException();
	}
}
