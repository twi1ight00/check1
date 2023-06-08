using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2338 : Class1351
{
	internal delegate Class2338 Delegate2761();

	internal delegate void Delegate2762(Class2338 elementData);

	public Class1780.Delegate1219 delegate1219_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private Enum309 enum309_0;

	private List<Class1780> list_0;

	public string Classid
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

	public string License
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public string R_Id
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public Enum309 Persistence
	{
		get
		{
			return enum309_0;
		}
		set
		{
			enum309_0 = value;
		}
	}

	public Class1780[] OcxPrList => list_0.ToArray();

	protected override void vmethod_0(XmlReader reader)
	{
		string localName = reader.LocalName;
		method_2(reader);
		if (reader.IsEmptyElement)
		{
			return;
		}
		bool flag = false;
		while (((flag && !reader.EOF) || reader.Read()) && (reader.NodeType != XmlNodeType.EndElement || !(reader.LocalName == localName)))
		{
			flag = false;
			if (reader.NodeType == XmlNodeType.Element)
			{
				string localName2;
				if ((localName2 = reader.LocalName) != null && localName2 == "ocxPr")
				{
					Class1780 item = new Class1780(reader);
					list_0.Add(item);
				}
				else
				{
					reader.Skip();
					flag = true;
				}
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
				switch ((reader.LookupNamespace(reader.Prefix) == namespaceURI) ? reader.LocalName : reader.Name)
				{
				case "persistence":
					enum309_0 = Class2437.smethod_0(reader.Value);
					break;
				case "r:id":
					string_2 = reader.Value;
					break;
				case "license":
					string_1 = reader.Value;
					break;
				case "classid":
					string_0 = reader.Value;
					break;
				default:
					throw new Exception("Unknown attribute \"" + reader.Name + "\"");
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2338(XmlReader reader)
		: base(reader)
	{
	}

	public Class2338()
	{
	}

	protected override void vmethod_1()
	{
		enum309_0 = Enum309.const_0;
		list_0 = new List<Class1780>();
	}

	protected override void vmethod_2()
	{
		delegate1219_0 = method_3;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("ax", elementName, "http://schemas.microsoft.com/office/2006/activeX");
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/officeDocument/2006/relationships") == null)
		{
			writer.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		}
		writer.WriteAttributeString("ax:classid", string_0);
		if (string_1 != null)
		{
			writer.WriteAttributeString("license", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("r:id", string_2);
		}
		writer.WriteAttributeString("ax:persistence", Class2437.smethod_1(enum309_0));
		foreach (Class1780 item in list_0)
		{
			item.vmethod_4("ax", writer, "ocxPr");
		}
		writer.WriteEndElement();
	}

	private Class1780 method_3()
	{
		Class1780 @class = new Class1780();
		list_0.Add(@class);
		return @class;
	}
}
