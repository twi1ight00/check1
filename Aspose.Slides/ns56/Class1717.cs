using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1717 : Class1351
{
	public delegate Class1717 Delegate1030();

	public delegate void Delegate1031(Class1717 elementData);

	public delegate void Delegate1032(Class1717 elementData);

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

	public Class2605[] TableReferenceList => list_0.ToArray();

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
				case "x":
				{
					Class1556 obj3 = new Class1556(reader);
					list_0.Add(new Class2605("x", obj3));
					break;
				}
				case "s":
				{
					Class1754 obj2 = new Class1754(reader);
					list_0.Add(new Class2605("s", obj2));
					break;
				}
				case "m":
				{
					Class1714 obj = new Class1714(reader);
					list_0.Add(new Class2605("m", obj));
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

	public Class1717(XmlReader reader)
		: base(reader)
	{
	}

	public Class1717()
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
			case "x":
				((Class1556)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "s":
				((Class1754)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "m":
				((Class1714)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		Class2605 @class = elementName switch
		{
			"x" => new Class2605("x", new Class1556()), 
			"s" => new Class2605("s", new Class1754()), 
			"m" => new Class2605("m", new Class1714()), 
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
