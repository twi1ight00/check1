using System.Xml;

namespace ns56;

internal class Class1559 : Class1351
{
	public delegate Class1559 Delegate556();

	public delegate void Delegate557(Class1559 elementData);

	public delegate void Delegate558(Class1559 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = true;

	public const bool bool_3 = false;

	public const bool bool_4 = false;

	public const bool bool_5 = false;

	public const uint uint_0 = uint.MaxValue;

	public const bool bool_6 = false;

	public const bool bool_7 = true;

	private string string_0;

	private Enum216 enum216_0;

	private bool bool_8;

	private bool bool_9;

	private bool bool_10;

	private bool bool_11;

	private bool bool_12;

	private bool bool_13;

	private uint uint_1;

	private bool bool_14;

	private bool bool_15;

	public static readonly Enum216 enum216_1 = Class2383.smethod_0("data");

	public string N
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

	public Enum216 T
	{
		get
		{
			return enum216_0;
		}
		set
		{
			enum216_0 = value;
		}
	}

	public bool H
	{
		get
		{
			return bool_8;
		}
		set
		{
			bool_8 = value;
		}
	}

	public bool S
	{
		get
		{
			return bool_9;
		}
		set
		{
			bool_9 = value;
		}
	}

	public bool Sd
	{
		get
		{
			return bool_10;
		}
		set
		{
			bool_10 = value;
		}
	}

	public bool F
	{
		get
		{
			return bool_11;
		}
		set
		{
			bool_11 = value;
		}
	}

	public bool M
	{
		get
		{
			return bool_12;
		}
		set
		{
			bool_12 = value;
		}
	}

	public bool C
	{
		get
		{
			return bool_13;
		}
		set
		{
			bool_13 = value;
		}
	}

	public uint X
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

	public bool D
	{
		get
		{
			return bool_14;
		}
		set
		{
			bool_14 = value;
		}
	}

	public bool E
	{
		get
		{
			return bool_15;
		}
		set
		{
			bool_15 = value;
		}
	}

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
				_ = reader.LocalName;
				reader.Skip();
				flag = true;
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
				case "n":
					string_0 = reader.Value;
					break;
				case "t":
					enum216_0 = Class2383.smethod_0(reader.Value);
					break;
				case "h":
					bool_8 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "s":
					bool_9 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "sd":
					bool_10 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "f":
					bool_11 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "m":
					bool_12 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "c":
					bool_13 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "x":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "d":
					bool_14 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "e":
					bool_15 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1559(XmlReader reader)
		: base(reader)
	{
	}

	public Class1559()
	{
	}

	protected override void vmethod_1()
	{
		enum216_0 = enum216_1;
		bool_8 = false;
		bool_9 = false;
		bool_10 = true;
		bool_11 = false;
		bool_12 = false;
		bool_13 = false;
		uint_1 = uint.MaxValue;
		bool_14 = false;
		bool_15 = true;
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (string_0 != null)
		{
			writer.WriteAttributeString("n", string_0);
		}
		if (enum216_0 != enum216_1)
		{
			writer.WriteAttributeString("t", Class2383.smethod_1(enum216_0));
		}
		if (bool_8)
		{
			writer.WriteAttributeString("h", bool_8 ? "1" : "0");
		}
		if (bool_9)
		{
			writer.WriteAttributeString("s", bool_9 ? "1" : "0");
		}
		if (!bool_10)
		{
			writer.WriteAttributeString("sd", bool_10 ? "1" : "0");
		}
		if (bool_11)
		{
			writer.WriteAttributeString("f", bool_11 ? "1" : "0");
		}
		if (bool_12)
		{
			writer.WriteAttributeString("m", bool_12 ? "1" : "0");
		}
		if (bool_13)
		{
			writer.WriteAttributeString("c", bool_13 ? "1" : "0");
		}
		if (uint_1 != uint.MaxValue)
		{
			writer.WriteAttributeString("x", XmlConvert.ToString(uint_1));
		}
		if (bool_14)
		{
			writer.WriteAttributeString("d", bool_14 ? "1" : "0");
		}
		if (!bool_15)
		{
			writer.WriteAttributeString("e", bool_15 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
