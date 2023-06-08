using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1590 : Class1351
{
	public delegate Class1590 Delegate649();

	public delegate void Delegate650(Class1590 elementData);

	public delegate void Delegate651(Class1590 elementData);

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	public const NullableBool nullableBool_1 = NullableBool.NotDefined;

	public const uint uint_0 = uint.MaxValue;

	public const uint uint_1 = uint.MaxValue;

	public const uint uint_2 = uint.MaxValue;

	public const uint uint_3 = uint.MaxValue;

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public Class1728.Delegate1063 delegate1063_0;

	public Class1728.Delegate1064 delegate1064_0;

	public Class1749.Delegate1126 delegate1126_0;

	public Class1749.Delegate1127 delegate1127_0;

	private NullableBool nullableBool_2;

	private NullableBool nullableBool_3;

	private string string_0;

	private uint uint_4;

	private uint uint_5;

	private uint uint_6;

	private uint uint_7;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private List<Class1728> list_0;

	private List<Class1749> list_1;

	public NullableBool U
	{
		get
		{
			return nullableBool_2;
		}
		set
		{
			nullableBool_2 = value;
		}
	}

	public NullableBool F
	{
		get
		{
			return nullableBool_3;
		}
		set
		{
			nullableBool_3 = value;
		}
	}

	public string C
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

	public uint Cp
	{
		get
		{
			return uint_4;
		}
		set
		{
			uint_4 = value;
		}
	}

	public uint In
	{
		get
		{
			return uint_5;
		}
		set
		{
			uint_5 = value;
		}
	}

	public uint Bc
	{
		get
		{
			return uint_6;
		}
		set
		{
			uint_6 = value;
		}
	}

	public uint Fc
	{
		get
		{
			return uint_7;
		}
		set
		{
			uint_7 = value;
		}
	}

	public bool I
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

	public bool Un
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

	public bool St
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

	public bool B
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

	public Class1728[] TplsList => list_0.ToArray();

	public Class1749[] XList => list_1.ToArray();

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
					Class1749 item2 = new Class1749(reader);
					list_1.Add(item2);
					break;
				}
				case "tpls":
				{
					Class1728 item = new Class1728(reader);
					list_0.Add(item);
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
				case "u":
					nullableBool_2 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "f":
					nullableBool_3 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "c":
					string_0 = reader.Value;
					break;
				case "cp":
					uint_4 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "in":
					uint_5 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "bc":
					uint_6 = uint.Parse(reader.Value, NumberStyles.HexNumber);
					break;
				case "fc":
					uint_7 = uint.Parse(reader.Value, NumberStyles.HexNumber);
					break;
				case "i":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "un":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "st":
					bool_6 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "b":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1590(XmlReader reader)
		: base(reader)
	{
	}

	public Class1590()
	{
	}

	protected override void vmethod_1()
	{
		nullableBool_2 = NullableBool.NotDefined;
		nullableBool_3 = NullableBool.NotDefined;
		uint_4 = uint.MaxValue;
		uint_5 = uint.MaxValue;
		uint_6 = uint.MaxValue;
		uint_7 = uint.MaxValue;
		bool_4 = false;
		bool_5 = false;
		bool_6 = false;
		bool_7 = false;
		list_0 = new List<Class1728>();
		list_1 = new List<Class1749>();
	}

	protected override void vmethod_2()
	{
		delegate1063_0 = method_3;
		delegate1064_0 = method_4;
		delegate1126_0 = method_5;
		delegate1127_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (nullableBool_2 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("u", (nullableBool_2 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_3 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("f", (nullableBool_3 == NullableBool.True) ? "1" : "0");
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("c", string_0);
		}
		if (uint_4 != uint.MaxValue)
		{
			writer.WriteAttributeString("cp", XmlConvert.ToString(uint_4));
		}
		if (uint_5 != uint.MaxValue)
		{
			writer.WriteAttributeString("in", XmlConvert.ToString(uint_5));
		}
		if (uint_6 != uint.MaxValue)
		{
			writer.WriteAttributeString("bc", (uint_6 & 0xFFFFFFFFu).ToString("X8"));
		}
		if (uint_7 != uint.MaxValue)
		{
			writer.WriteAttributeString("fc", (uint_7 & 0xFFFFFFFFu).ToString("X8"));
		}
		if (bool_4)
		{
			writer.WriteAttributeString("i", bool_4 ? "1" : "0");
		}
		if (bool_5)
		{
			writer.WriteAttributeString("un", bool_5 ? "1" : "0");
		}
		if (bool_6)
		{
			writer.WriteAttributeString("st", bool_6 ? "1" : "0");
		}
		if (bool_7)
		{
			writer.WriteAttributeString("b", bool_7 ? "1" : "0");
		}
		foreach (Class1728 item in list_0)
		{
			item.vmethod_4("ssml", writer, "tpls");
		}
		foreach (Class1749 item2 in list_1)
		{
			item2.vmethod_4("ssml", writer, "x");
		}
		writer.WriteEndElement();
	}

	private Class1728 method_3()
	{
		Class1728 @class = new Class1728();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1728 elementData)
	{
		list_0.Add(elementData);
	}

	private Class1749 method_5()
	{
		Class1749 @class = new Class1749();
		list_1.Add(@class);
		return @class;
	}

	private void method_6(Class1749 elementData)
	{
		list_1.Add(elementData);
	}
}
