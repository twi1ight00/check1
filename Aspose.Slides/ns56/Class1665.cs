using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1665 : Class1351
{
	public delegate Class1665 Delegate874();

	public delegate void Delegate875(Class1665 elementData);

	public delegate void Delegate876(Class1665 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const uint uint_0 = 0u;

	public Class2605.Delegate2773 delegate2773_0;

	private uint uint_1;

	private bool bool_2;

	private bool bool_3;

	private uint uint_2;

	private string string_0;

	private string string_1;

	private uint uint_3;

	private List<Class2605> list_0;

	public uint RId
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

	public bool Ua
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool Ra
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public uint SheetId
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
		}
	}

	public string Source
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

	public string Destination
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

	public uint SourceSheetId
	{
		get
		{
			return uint_3;
		}
		set
		{
			uint_3 = value;
		}
	}

	public Class2605[] ChangeInfoList => list_0.ToArray();

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
				case "rfmt":
				{
					Class1661 obj3 = new Class1661(reader);
					list_0.Add(new Class2605("rfmt", obj3));
					break;
				}
				case "rcc":
				{
					Class1771 obj2 = new Class1771(reader);
					list_0.Add(new Class2605("rcc", obj2));
					break;
				}
				case "undo":
				{
					Class1730 obj = new Class1730(reader);
					list_0.Add(new Class2605("undo", obj));
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
			if (!(reader.Prefix == "xmlns"))
			{
				switch (method_0(reader))
				{
				case "rId":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "ua":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "ra":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "sheetId":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "source":
					string_0 = reader.Value;
					break;
				case "destination":
					string_1 = reader.Value;
					break;
				case "sourceSheetId":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1665(XmlReader reader)
		: base(reader)
	{
	}

	public Class1665()
	{
	}

	protected override void vmethod_1()
	{
		bool_2 = false;
		bool_3 = false;
		uint_3 = 0u;
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
		writer.WriteAttributeString("rId", XmlConvert.ToString(uint_1));
		if (bool_2)
		{
			writer.WriteAttributeString("ua", bool_2 ? "1" : "0");
		}
		if (bool_3)
		{
			writer.WriteAttributeString("ra", bool_3 ? "1" : "0");
		}
		writer.WriteAttributeString("sheetId", XmlConvert.ToString(uint_2));
		writer.WriteAttributeString("source", string_0);
		writer.WriteAttributeString("destination", string_1);
		if (uint_3 != 0)
		{
			writer.WriteAttributeString("sourceSheetId", XmlConvert.ToString(uint_3));
		}
		foreach (Class2605 item in list_0)
		{
			switch (item.Name)
			{
			case "rfmt":
				((Class1661)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "rcc":
				((Class1771)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "undo":
				((Class1730)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		Class2605 @class = elementName switch
		{
			"rfmt" => new Class2605("rfmt", new Class1661()), 
			"rcc" => new Class2605("rcc", new Class1771()), 
			"undo" => new Class2605("undo", new Class1730()), 
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
