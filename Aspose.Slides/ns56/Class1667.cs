using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1667 : Class1351
{
	public delegate Class1667 Delegate880();

	public delegate void Delegate881(Class1667 elementData);

	public delegate void Delegate882(Class1667 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public Class2605.Delegate2773 delegate2773_0;

	private uint uint_0;

	private bool bool_4;

	private bool bool_5;

	private uint uint_1;

	private bool bool_6;

	private string string_0;

	private Enum236 enum236_0;

	private bool bool_7;

	private List<Class2605> list_0;

	public uint RId
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public bool Ua
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public bool Ra
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	public uint SId
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

	public bool Eol
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	public string Ref
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

	public Enum236 Action
	{
		get
		{
			return enum236_0;
		}
		set
		{
			enum236_0 = value;
		}
	}

	public bool Edge
	{
		get
		{
			return bool_7;
		}
		set
		{
			bool_7 = value;
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
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "ua":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "ra":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "sId":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "eol":
					bool_6 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "ref":
					string_0 = reader.Value;
					break;
				case "action":
					enum236_0 = Class2403.smethod_0(reader.Value);
					break;
				case "edge":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1667(XmlReader reader)
		: base(reader)
	{
	}

	public Class1667()
	{
	}

	protected override void vmethod_1()
	{
		bool_4 = false;
		bool_5 = false;
		bool_6 = false;
		enum236_0 = Enum236.const_0;
		bool_7 = false;
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
		writer.WriteAttributeString("rId", XmlConvert.ToString(uint_0));
		if (bool_4)
		{
			writer.WriteAttributeString("ua", bool_4 ? "1" : "0");
		}
		if (bool_5)
		{
			writer.WriteAttributeString("ra", bool_5 ? "1" : "0");
		}
		writer.WriteAttributeString("sId", XmlConvert.ToString(uint_1));
		if (bool_6)
		{
			writer.WriteAttributeString("eol", bool_6 ? "1" : "0");
		}
		writer.WriteAttributeString("ref", string_0);
		writer.WriteAttributeString("action", Class2403.smethod_1(enum236_0));
		if (bool_7)
		{
			writer.WriteAttributeString("edge", bool_7 ? "1" : "0");
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
