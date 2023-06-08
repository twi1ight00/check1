using System.Xml;

namespace ns56;

internal class Class1739 : Class1351
{
	public delegate void Delegate1098(Class1739 elementData);

	public delegate Class1739 Delegate1096();

	public delegate void Delegate1097(Class1739 elementData);

	public const bool bool_0 = true;

	public const bool bool_1 = true;

	public const bool bool_2 = true;

	public const bool bool_3 = false;

	public const bool bool_4 = false;

	public const uint uint_0 = 96u;

	public const uint uint_1 = uint.MaxValue;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	private Enum248 enum248_0;

	private uint uint_2;

	private uint uint_3;

	public static readonly Enum248 enum248_1 = Class2415.smethod_0("800x600");

	public bool Css
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

	public bool Thicket
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

	public bool LongFileNames
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

	public bool Vml
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

	public bool AllowPng
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

	public Enum248 TargetScreenSize
	{
		get
		{
			return enum248_0;
		}
		set
		{
			enum248_0 = value;
		}
	}

	public uint Dpi
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

	public uint CodePage
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
				case "css":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "thicket":
					bool_6 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "longFileNames":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "vml":
					bool_8 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "allowPng":
					bool_9 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "targetScreenSize":
					enum248_0 = Class2415.smethod_0(reader.Value);
					break;
				case "dpi":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "codePage":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1739(XmlReader reader)
		: base(reader)
	{
	}

	public Class1739()
	{
	}

	protected override void vmethod_1()
	{
		bool_5 = true;
		bool_6 = true;
		bool_7 = true;
		bool_8 = false;
		bool_9 = false;
		enum248_0 = enum248_1;
		uint_2 = 96u;
		uint_3 = uint.MaxValue;
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
		if (!bool_5)
		{
			writer.WriteAttributeString("css", bool_5 ? "1" : "0");
		}
		if (!bool_6)
		{
			writer.WriteAttributeString("thicket", bool_6 ? "1" : "0");
		}
		if (!bool_7)
		{
			writer.WriteAttributeString("longFileNames", bool_7 ? "1" : "0");
		}
		if (bool_8)
		{
			writer.WriteAttributeString("vml", bool_8 ? "1" : "0");
		}
		if (bool_9)
		{
			writer.WriteAttributeString("allowPng", bool_9 ? "1" : "0");
		}
		if (enum248_0 != enum248_1)
		{
			writer.WriteAttributeString("targetScreenSize", Class2415.smethod_1(enum248_0));
		}
		if (uint_2 != 96)
		{
			writer.WriteAttributeString("dpi", XmlConvert.ToString(uint_2));
		}
		if (uint_3 != uint.MaxValue)
		{
			writer.WriteAttributeString("codePage", XmlConvert.ToString(uint_3));
		}
		writer.WriteEndElement();
	}
}
