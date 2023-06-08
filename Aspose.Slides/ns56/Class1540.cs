using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1540 : Class1351
{
	public delegate Class1540 Delegate499();

	public delegate void Delegate501(Class1540 elementData);

	public delegate void Delegate500(Class1540 elementData);

	public const uint uint_0 = uint.MaxValue;

	public Class2605.Delegate2773 delegate2773_0;

	private uint uint_1;

	private List<Class2605> list_0;

	public uint Count
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	public Class2605[] ValueList => list_0.ToArray();

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
				case "m":
				{
					Class1590 obj6 = new Class1590(reader);
					list_0.Add(new Class2605("m", obj6));
					break;
				}
				case "n":
				{
					Class1592 obj5 = new Class1592(reader);
					list_0.Add(new Class2605("n", obj5));
					break;
				}
				case "b":
				{
					Class1375 obj4 = new Class1375(reader);
					list_0.Add(new Class2605("b", obj4));
					break;
				}
				case "e":
				{
					Class1501 obj3 = new Class1501(reader);
					list_0.Add(new Class2605("e", obj3));
					break;
				}
				case "s":
				{
					Class1708 obj2 = new Class1708(reader);
					list_0.Add(new Class2605("s", obj2));
					break;
				}
				case "d":
				{
					Class1484 obj = new Class1484(reader);
					list_0.Add(new Class2605("d", obj));
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "count")
			{
				uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1540(XmlReader reader)
		: base(reader)
	{
	}

	public Class1540()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = uint.MaxValue;
		list_0 = new List<Class2605>();
	}

	protected override void vmethod_2()
	{
		delegate2773_0 = method_3;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (uint_1 != uint.MaxValue)
		{
			writer.WriteAttributeString("count", XmlConvert.ToString(uint_1));
		}
		foreach (Class2605 item in list_0)
		{
			switch (item.Name)
			{
			case "m":
				((Class1590)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "n":
				((Class1592)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "b":
				((Class1375)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "e":
				((Class1501)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "s":
				((Class1708)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "d":
				((Class1484)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		Class2605 @class = elementName switch
		{
			"m" => new Class2605("m", new Class1590()), 
			"n" => new Class2605("n", new Class1592()), 
			"b" => new Class2605("b", new Class1375()), 
			"e" => new Class2605("e", new Class1501()), 
			"s" => new Class2605("s", new Class1708()), 
			"d" => new Class2605("d", new Class1484()), 
			_ => throw new Exception("Wrong element: " + elementName), 
		};
		list_0.Add(@class);
		return @class;
	}

	public void method_4(Class2605 obj)
	{
		list_0.Add(obj);
	}
}
