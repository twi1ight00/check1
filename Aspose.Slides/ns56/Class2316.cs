using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2316 : Class1351
{
	public delegate Class2316 Delegate2695();

	public delegate void Delegate2696(Class2316 elementData);

	public delegate void Delegate2697(Class2316 elementData);

	public Class1942.Delegate1693 delegate1693_0;

	public Class1942.Delegate1694 delegate1694_0;

	private Guid guid_0;

	private List<Class1942> list_0;

	public Guid Def
	{
		get
		{
			return guid_0;
		}
		set
		{
			guid_0 = value;
		}
	}

	public Class1942[] TblStyleList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "tblStyle")
				{
					Class1942 item = new Class1942(reader);
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
		while (reader.MoveToNextAttribute())
		{
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "def")
			{
				guid_0 = new Guid(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2316(XmlReader reader)
		: base(reader)
	{
	}

	public Class2316()
	{
	}

	protected override void vmethod_1()
	{
		guid_0 = Guid.Empty;
		list_0 = new List<Class1942>();
	}

	protected override void vmethod_2()
	{
		delegate1693_0 = method_3;
		delegate1694_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("a", elementName, "http://schemas.openxmlformats.org/drawingml/2006/main");
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/officeDocument/2006/relationships") == null)
		{
			writer.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		}
		writer.WriteAttributeString("def", "{" + XmlConvert.ToString(guid_0).ToUpper() + "}");
		foreach (Class1942 item in list_0)
		{
			item.vmethod_4("a", writer, "tblStyle");
		}
		writer.WriteEndElement();
	}

	private Class1942 method_3()
	{
		Class1942 @class = new Class1942();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1942 elementData)
	{
		list_0.Add(elementData);
	}
}
