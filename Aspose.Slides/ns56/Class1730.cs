using System.Xml;

namespace ns56;

internal class Class1730 : Class1351
{
	public delegate Class1730 Delegate1069();

	public delegate void Delegate1070(Class1730 elementData);

	public delegate void Delegate1071(Class1730 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const bool bool_4 = false;

	public const uint uint_0 = uint.MaxValue;

	private uint uint_1;

	private Enum209 enum209_0;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	private string string_0;

	private string string_1;

	private string string_2;

	private uint uint_2;

	public uint Index
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

	public Enum209 Exp
	{
		get
		{
			return enum209_0;
		}
		set
		{
			enum209_0 = value;
		}
	}

	public bool Ref3D
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

	public bool Array
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

	public bool V
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

	public bool Nf
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

	public bool Cs
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

	public string Dr
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

	public string Dn
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

	public string R
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

	public uint SId
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
				case "index":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "exp":
					enum209_0 = Class2376.smethod_0(reader.Value);
					break;
				case "ref3D":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "array":
					bool_6 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "v":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "nf":
					bool_8 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "cs":
					bool_9 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "dr":
					string_0 = reader.Value;
					break;
				case "dn":
					string_1 = reader.Value;
					break;
				case "r":
					string_2 = reader.Value;
					break;
				case "sId":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1730(XmlReader reader)
		: base(reader)
	{
	}

	public Class1730()
	{
	}

	protected override void vmethod_1()
	{
		enum209_0 = Enum209.const_0;
		bool_5 = false;
		bool_6 = false;
		bool_7 = false;
		bool_8 = false;
		bool_9 = false;
		uint_2 = uint.MaxValue;
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
		writer.WriteAttributeString("index", XmlConvert.ToString(uint_1));
		writer.WriteAttributeString("exp", Class2376.smethod_1(enum209_0));
		if (bool_5)
		{
			writer.WriteAttributeString("ref3D", bool_5 ? "1" : "0");
		}
		if (bool_6)
		{
			writer.WriteAttributeString("array", bool_6 ? "1" : "0");
		}
		if (bool_7)
		{
			writer.WriteAttributeString("v", bool_7 ? "1" : "0");
		}
		if (bool_8)
		{
			writer.WriteAttributeString("nf", bool_8 ? "1" : "0");
		}
		if (bool_9)
		{
			writer.WriteAttributeString("cs", bool_9 ? "1" : "0");
		}
		writer.WriteAttributeString("dr", string_0);
		if (string_1 != null)
		{
			writer.WriteAttributeString("dn", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("r", string_2);
		}
		if (uint_2 != uint.MaxValue)
		{
			writer.WriteAttributeString("sId", XmlConvert.ToString(uint_2));
		}
		writer.WriteEndElement();
	}
}
