using System.Xml;

namespace ns56;

internal class Class1435 : Class1351
{
	public delegate Class1435 Delegate267();

	public delegate void Delegate269(Class1435 elementData);

	public delegate void Delegate268(Class1435 elementData);

	public const uint uint_0 = 1u;

	public const uint uint_1 = 1u;

	public const bool bool_0 = true;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const uint uint_2 = 600u;

	public const uint uint_3 = 600u;

	public const uint uint_4 = 1u;

	private uint uint_5;

	private uint uint_6;

	private Enum222 enum222_0;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private uint uint_7;

	private uint uint_8;

	private uint uint_9;

	private string string_0;

	public static readonly Enum222 enum222_1 = Class2389.smethod_0("default");

	public uint PaperSize
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

	public uint FirstPageNumber
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

	public Enum222 Orientation
	{
		get
		{
			return enum222_0;
		}
		set
		{
			enum222_0 = value;
		}
	}

	public bool UsePrinterDefaults
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

	public bool BlackAndWhite
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

	public bool Draft
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

	public bool UseFirstPageNumber
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

	public uint HorizontalDpi
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

	public uint VerticalDpi
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

	public uint Copies
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

	public string R_Id
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
				case "paperSize":
					uint_5 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "firstPageNumber":
					uint_6 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "orientation":
					enum222_0 = Class2389.smethod_0(reader.Value);
					break;
				case "usePrinterDefaults":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "blackAndWhite":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "draft":
					bool_6 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "useFirstPageNumber":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "horizontalDpi":
					uint_7 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "verticalDpi":
					uint_8 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "copies":
					uint_9 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "r:id":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1435(XmlReader reader)
		: base(reader)
	{
	}

	public Class1435()
	{
	}

	protected override void vmethod_1()
	{
		uint_5 = 1u;
		uint_6 = 1u;
		enum222_0 = enum222_1;
		bool_4 = true;
		bool_5 = false;
		bool_6 = false;
		bool_7 = false;
		uint_7 = 600u;
		uint_8 = 600u;
		uint_9 = 1u;
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
		if (uint_5 != 1)
		{
			writer.WriteAttributeString("paperSize", XmlConvert.ToString(uint_5));
		}
		if (uint_6 != 1)
		{
			writer.WriteAttributeString("firstPageNumber", XmlConvert.ToString(uint_6));
		}
		if (enum222_0 != enum222_1)
		{
			writer.WriteAttributeString("orientation", Class2389.smethod_1(enum222_0));
		}
		if (!bool_4)
		{
			writer.WriteAttributeString("usePrinterDefaults", bool_4 ? "1" : "0");
		}
		if (bool_5)
		{
			writer.WriteAttributeString("blackAndWhite", bool_5 ? "1" : "0");
		}
		if (bool_6)
		{
			writer.WriteAttributeString("draft", bool_6 ? "1" : "0");
		}
		if (bool_7)
		{
			writer.WriteAttributeString("useFirstPageNumber", bool_7 ? "1" : "0");
		}
		if (uint_7 != 600)
		{
			writer.WriteAttributeString("horizontalDpi", XmlConvert.ToString(uint_7));
		}
		if (uint_8 != 600)
		{
			writer.WriteAttributeString("verticalDpi", XmlConvert.ToString(uint_8));
		}
		if (uint_9 != 1)
		{
			writer.WriteAttributeString("copies", XmlConvert.ToString(uint_9));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("r:id", string_0);
		}
		writer.WriteEndElement();
	}
}
