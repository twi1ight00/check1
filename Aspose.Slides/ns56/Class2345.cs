using System;
using System.Xml;

namespace ns56;

internal class Class2345 : Class1351
{
	public Class2315.Delegate2692 delegate2692_0;

	public Class2019.Delegate1846 delegate1846_0;

	public Class2214.Delegate2378 delegate2378_0;

	public Class1352.Delegate18 delegate18_0;

	private string string_0;

	private XmlDocumentFragment xmlDocumentFragment_0;

	private Class2315 class2315_0;

	private Class2019 class2019_0;

	private Class2214 class2214_0;

	private Class1352 class1352_0;

	public XmlDocumentFragment XmlDocumentFragment
	{
		get
		{
			return xmlDocumentFragment_0;
		}
		set
		{
			xmlDocumentFragment_0 = value;
			class2315_0 = null;
			class2019_0 = null;
		}
	}

	public string Uri
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Class2315 Table => class2315_0;

	public Class2019 ChartRef => class2019_0;

	public Class2214 SmartArtRelIds => class2214_0;

	public Class1352 OleObj => class1352_0;

	protected override void vmethod_0(XmlReader reader)
	{
		string localName = reader.LocalName;
		method_2(reader);
		if (reader.IsEmptyElement)
		{
			return;
		}
		switch (string_0)
		{
		case "http://schemas.openxmlformats.org/drawingml/2006/table":
		case "http://schemas.openxmlformats.org/drawingml/2006/chart":
		case "http://schemas.openxmlformats.org/drawingml/2006/diagram":
		case "http://schemas.openxmlformats.org/presentationml/2006/ole":
		{
			bool flag = false;
			while (((flag && !reader.EOF) || reader.Read()) && (reader.NodeType != XmlNodeType.EndElement || !(reader.LocalName == localName)))
			{
				flag = false;
				if (reader.NodeType == XmlNodeType.Element)
				{
					switch (reader.LocalName)
					{
					case "oleObj":
						class1352_0 = new Class1352(reader);
						break;
					case "relIds":
						class2214_0 = new Class2214(reader);
						break;
					case "chart":
						class2019_0 = new Class2019(reader);
						break;
					case "tbl":
						class2315_0 = new Class2315(reader);
						break;
					default:
						throw new Exception("Unknown element \"" + reader.LocalName + "\"");
					}
				}
			}
			break;
		}
		default:
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocumentFragment_0 = xmlDocument.CreateDocumentFragment();
			xmlDocumentFragment_0.InnerXml = reader.ReadInnerXml();
			break;
		}
		}
	}

	private void method_2(XmlReader reader)
	{
		string namespaceURI = reader.NamespaceURI;
		while (reader.MoveToNextAttribute())
		{
			if (!(reader.Prefix == "xmlns"))
			{
				string text;
				if ((text = ((reader.LookupNamespace(reader.Prefix) == namespaceURI) ? reader.LocalName : reader.Name)) == null || !(text == "uri"))
				{
					throw new Exception("Unknown attribute \"" + reader.Name + "\"");
				}
				string_0 = reader.Value;
			}
		}
		reader.MoveToElement();
	}

	internal Class2345(XmlReader reader)
		: base(reader)
	{
	}

	internal Class2345()
	{
	}

	protected override void vmethod_1()
	{
		string_0 = "";
	}

	protected override void vmethod_2()
	{
		delegate2692_0 = method_3;
		delegate1846_0 = method_4;
		delegate2378_0 = method_5;
		delegate18_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (string_0 != null)
		{
			writer.WriteAttributeString("uri", string_0);
		}
		if (class2019_0 != null)
		{
			class2019_0.vmethod_4("c", writer, "chart");
		}
		if (class2315_0 != null)
		{
			class2315_0.vmethod_4("a", writer, "tbl");
		}
		if (class2214_0 != null)
		{
			class2214_0.vmethod_4("dgm", writer, "relIds");
		}
		if (class1352_0 != null)
		{
			class1352_0.vmethod_4("p", writer, "oleObj");
		}
		if (xmlDocumentFragment_0 != null)
		{
			xmlDocumentFragment_0.WriteTo(writer);
		}
		writer.WriteEndElement();
	}

	private Class2315 method_3()
	{
		if (class2315_0 != null)
		{
			throw new Exception("Only one <table> element can be added.");
		}
		class2315_0 = new Class2315();
		xmlDocumentFragment_0 = null;
		class2019_0 = null;
		class2214_0 = null;
		class1352_0 = null;
		return class2315_0;
	}

	private Class2019 method_4()
	{
		if (class2019_0 != null)
		{
			throw new Exception("Only one <chart> element can be added.");
		}
		class2019_0 = new Class2019();
		class2214_0 = null;
		class2315_0 = null;
		class1352_0 = null;
		xmlDocumentFragment_0 = null;
		return class2019_0;
	}

	private Class2214 method_5()
	{
		if (class2214_0 != null)
		{
			throw new Exception("Only one <chart> element can be added.");
		}
		class2214_0 = new Class2214();
		class2019_0 = null;
		class2315_0 = null;
		class1352_0 = null;
		xmlDocumentFragment_0 = null;
		return class2214_0;
	}

	private Class1352 method_6()
	{
		if (class1352_0 != null)
		{
			throw new Exception("Only one <chart> element can be added.");
		}
		class1352_0 = new Class1352();
		class2019_0 = null;
		class2315_0 = null;
		class2214_0 = null;
		xmlDocumentFragment_0 = null;
		return class1352_0;
	}
}
