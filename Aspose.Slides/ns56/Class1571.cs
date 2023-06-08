using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace ns56;

internal class Class1571 : Class1351
{
	public delegate Class1571 Delegate592();

	public delegate void Delegate593(Class1571 elementData);

	public delegate void Delegate594(Class1571 elementData);

	public const uint uint_0 = 0u;

	public const uint uint_1 = uint.MaxValue;

	public const uint uint_2 = uint.MaxValue;

	public const uint uint_3 = uint.MaxValue;

	public const uint uint_4 = uint.MaxValue;

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public Class1586.Delegate637 delegate637_0;

	public Class1586.Delegate638 delegate638_0;

	private uint uint_5;

	private string string_0;

	private uint uint_6;

	private uint uint_7;

	private uint uint_8;

	private uint uint_9;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private List<Class1586> list_0;

	public uint C
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

	public string Ct
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

	public uint Si
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

	public uint Fi
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

	public uint Bc
	{
		get
		{
			return uint_8;
		}
		set
		{
			uint_8 = value;
		}
	}

	public uint Fc
	{
		get
		{
			return uint_9;
		}
		set
		{
			uint_9 = value;
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

	public bool U
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

	public Class1586[] NList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "n")
				{
					Class1586 item = new Class1586(reader);
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
			if (!(reader.Prefix == "xmlns"))
			{
				switch (method_0(reader))
				{
				case "c":
					uint_5 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "ct":
					string_0 = reader.Value;
					break;
				case "si":
					uint_6 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "fi":
					uint_7 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "bc":
					uint_8 = uint.Parse(reader.Value, NumberStyles.HexNumber);
					break;
				case "fc":
					uint_9 = uint.Parse(reader.Value, NumberStyles.HexNumber);
					break;
				case "i":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "u":
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

	public Class1571(XmlReader reader)
		: base(reader)
	{
	}

	public Class1571()
	{
	}

	protected override void vmethod_1()
	{
		uint_5 = 0u;
		uint_6 = uint.MaxValue;
		uint_7 = uint.MaxValue;
		uint_8 = uint.MaxValue;
		uint_9 = uint.MaxValue;
		bool_4 = false;
		bool_5 = false;
		bool_6 = false;
		bool_7 = false;
		list_0 = new List<Class1586>();
	}

	protected override void vmethod_2()
	{
		delegate637_0 = method_3;
		delegate638_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (uint_5 != 0)
		{
			writer.WriteAttributeString("c", XmlConvert.ToString(uint_5));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("ct", string_0);
		}
		if (uint_6 != uint.MaxValue)
		{
			writer.WriteAttributeString("si", XmlConvert.ToString(uint_6));
		}
		if (uint_7 != uint.MaxValue)
		{
			writer.WriteAttributeString("fi", XmlConvert.ToString(uint_7));
		}
		if (uint_8 != uint.MaxValue)
		{
			writer.WriteAttributeString("bc", (uint_8 & 0xFFFFFFFFu).ToString("X8"));
		}
		if (uint_9 != uint.MaxValue)
		{
			writer.WriteAttributeString("fc", (uint_9 & 0xFFFFFFFFu).ToString("X8"));
		}
		if (bool_4)
		{
			writer.WriteAttributeString("i", bool_4 ? "1" : "0");
		}
		if (bool_5)
		{
			writer.WriteAttributeString("u", bool_5 ? "1" : "0");
		}
		if (bool_6)
		{
			writer.WriteAttributeString("st", bool_6 ? "1" : "0");
		}
		if (bool_7)
		{
			writer.WriteAttributeString("b", bool_7 ? "1" : "0");
		}
		foreach (Class1586 item in list_0)
		{
			item.vmethod_4("ssml", writer, "n");
		}
		writer.WriteEndElement();
	}

	private Class1586 method_3()
	{
		Class1586 @class = new Class1586();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1586 elementData)
	{
		list_0.Add(elementData);
	}
}
