using System.Xml;

namespace ns56;

internal class Class1395 : Class1351
{
	public delegate Class1395 Delegate147();

	public delegate void Delegate149(Class1395 elementData);

	public delegate void Delegate148(Class1395 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const bool bool_4 = false;

	public const bool bool_5 = false;

	public const uint uint_0 = uint.MaxValue;

	public const bool bool_6 = false;

	private Enum188 enum188_0;

	private bool bool_7;

	private string string_0;

	private bool bool_8;

	private bool bool_9;

	private bool bool_10;

	private bool bool_11;

	private string string_1;

	private string string_2;

	private bool bool_12;

	private uint uint_1;

	private bool bool_13;

	private string string_3;

	public static readonly Enum188 enum188_1 = Class2354.smethod_0("normal");

	public Enum188 T
	{
		get
		{
			return enum188_0;
		}
		set
		{
			enum188_0 = value;
		}
	}

	public bool Aca
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

	public bool Dt2D
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

	public bool Dtr
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

	public bool Del1
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

	public bool Del2
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

	public string R1
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

	public string R2
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

	public bool Ca
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

	public uint Si
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

	public bool Bx
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

	public string Value
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	protected override void vmethod_0(XmlReader reader)
	{
		_ = reader.LocalName;
		method_2(reader);
		if (!reader.IsEmptyElement)
		{
			reader.Read();
			string_3 = reader.Value;
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
				case "t":
					enum188_0 = Class2354.smethod_0(reader.Value);
					break;
				case "aca":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "ref":
					string_0 = reader.Value;
					break;
				case "dt2D":
					bool_8 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "dtr":
					bool_9 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "del1":
					bool_10 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "del2":
					bool_11 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "r1":
					string_1 = reader.Value;
					break;
				case "r2":
					string_2 = reader.Value;
					break;
				case "ca":
					bool_12 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "si":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "bx":
					bool_13 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1395(XmlReader reader)
		: base(reader)
	{
	}

	public Class1395()
	{
	}

	protected override void vmethod_1()
	{
		enum188_0 = enum188_1;
		bool_7 = false;
		bool_8 = false;
		bool_9 = false;
		bool_10 = false;
		bool_11 = false;
		bool_12 = false;
		uint_1 = uint.MaxValue;
		bool_13 = false;
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
		if (enum188_0 != enum188_1)
		{
			writer.WriteAttributeString("t", Class2354.smethod_1(enum188_0));
		}
		if (bool_7)
		{
			writer.WriteAttributeString("aca", bool_7 ? "1" : "0");
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("ref", string_0);
		}
		if (bool_8)
		{
			writer.WriteAttributeString("dt2D", bool_8 ? "1" : "0");
		}
		if (bool_9)
		{
			writer.WriteAttributeString("dtr", bool_9 ? "1" : "0");
		}
		if (bool_10)
		{
			writer.WriteAttributeString("del1", bool_10 ? "1" : "0");
		}
		if (bool_11)
		{
			writer.WriteAttributeString("del2", bool_11 ? "1" : "0");
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("r1", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("r2", string_2);
		}
		if (bool_12)
		{
			writer.WriteAttributeString("ca", bool_12 ? "1" : "0");
		}
		if (uint_1 != uint.MaxValue)
		{
			writer.WriteAttributeString("si", XmlConvert.ToString(uint_1));
		}
		if (bool_13)
		{
			writer.WriteAttributeString("bx", bool_13 ? "1" : "0");
		}
		writer.WriteString(string_3);
		writer.WriteEndElement();
	}
}
