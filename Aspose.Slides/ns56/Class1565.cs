using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1565 : Class1351
{
	public delegate Class1565 Delegate574();

	public delegate void Delegate575(Class1565 elementData);

	public delegate void Delegate576(Class1565 elementData);

	public Class1447.Delegate303 delegate303_0;

	public Class1564.Delegate571 delegate571_0;

	public Class1564.Delegate572 delegate572_0;

	private string string_0;

	private List<Class1455> list_0;

	private List<Class1564> list_1;

	public string SelectionNamespaces
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

	public Class1455[] SchemaList => list_0.ToArray();

	public Class1564[] MapList => list_1.ToArray();

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
				switch (reader.LocalName)
				{
				case "Map":
				{
					Class1564 item2 = new Class1564(reader);
					list_1.Add(item2);
					break;
				}
				case "Schema":
				{
					Class1455 item = new Class1455(reader);
					list_0.Add(item);
					flag = true;
					break;
				}
				default:
					reader.Skip();
					flag = true;
					break;
				}
			}
		}
	}

	private void method_2(XmlReader reader)
	{
		while (reader.MoveToNextAttribute())
		{
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "SelectionNamespaces")
			{
				string_0 = reader.Value;
			}
		}
		reader.MoveToElement();
	}

	public Class1565(XmlReader reader)
		: base(reader)
	{
	}

	public Class1565()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1455>();
		list_1 = new List<Class1564>();
	}

	protected override void vmethod_2()
	{
		delegate303_0 = method_3;
		delegate571_0 = method_5;
		delegate572_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("ssml", elementName, "http://schemas.openxmlformats.org/spreadsheetml/2006/main");
		writer.WriteAttributeString("SelectionNamespaces", string_0);
		foreach (Class1455 item in list_0)
		{
			item.vmethod_4("ssml", writer, "Schema");
		}
		foreach (Class1564 item2 in list_1)
		{
			item2.vmethod_4("ssml", writer, "Map");
		}
		writer.WriteEndElement();
	}

	private Class1447 method_3()
	{
		Class1455 @class = new Class1455();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1455 elementData)
	{
		list_0.Add(elementData);
	}

	private Class1564 method_5()
	{
		Class1564 @class = new Class1564();
		list_1.Add(@class);
		return @class;
	}

	private void method_6(Class1564 elementData)
	{
		list_1.Add(elementData);
	}
}
