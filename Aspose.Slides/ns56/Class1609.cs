using System.Xml;

namespace ns56;

internal class Class1609 : Class1351
{
	public delegate void Delegate708(Class1609 elementData);

	public delegate Class1609 Delegate706();

	public delegate void Delegate707(Class1609 elementData);

	public const uint uint_0 = 1u;

	public const uint uint_1 = 100u;

	public const uint uint_2 = 1u;

	public const uint uint_3 = 1u;

	public const uint uint_4 = 1u;

	public const bool bool_0 = true;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const uint uint_5 = 600u;

	public const uint uint_6 = 600u;

	public const uint uint_7 = 1u;

	private uint uint_8;

	private uint uint_9;

	private uint uint_10;

	private uint uint_11;

	private uint uint_12;

	private Enum223 enum223_0;

	private Enum222 enum222_0;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private Enum187 enum187_0;

	private bool bool_7;

	private Enum232 enum232_0;

	private uint uint_13;

	private uint uint_14;

	private uint uint_15;

	private string string_0;

	public static readonly Enum223 enum223_1 = Class2390.smethod_0("downThenOver");

	public static readonly Enum222 enum222_1 = Class2389.smethod_0("default");

	public static readonly Enum187 enum187_1 = Class2353.smethod_0("none");

	public static readonly Enum232 enum232_1 = Class2399.smethod_0("displayed");

	public uint PaperSize
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

	public uint Scale
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

	public uint FirstPageNumber
	{
		get
		{
			return uint_10;
		}
		set
		{
			uint_10 = value;
		}
	}

	public uint FitToWidth
	{
		get
		{
			return uint_11;
		}
		set
		{
			uint_11 = value;
		}
	}

	public uint FitToHeight
	{
		get
		{
			return uint_12;
		}
		set
		{
			uint_12 = value;
		}
	}

	public Enum223 PageOrder
	{
		get
		{
			return enum223_0;
		}
		set
		{
			enum223_0 = value;
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

	public Enum187 CellComments
	{
		get
		{
			return enum187_0;
		}
		set
		{
			enum187_0 = value;
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

	public Enum232 Errors
	{
		get
		{
			return enum232_0;
		}
		set
		{
			enum232_0 = value;
		}
	}

	public uint HorizontalDpi
	{
		get
		{
			return uint_13;
		}
		set
		{
			uint_13 = value;
		}
	}

	public uint VerticalDpi
	{
		get
		{
			return uint_14;
		}
		set
		{
			uint_14 = value;
		}
	}

	public uint Copies
	{
		get
		{
			return uint_15;
		}
		set
		{
			uint_15 = value;
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
					uint_8 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "scale":
					uint_9 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "firstPageNumber":
					uint_10 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "fitToWidth":
					uint_11 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "fitToHeight":
					uint_12 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "pageOrder":
					enum223_0 = Class2390.smethod_0(reader.Value);
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
				case "cellComments":
					enum187_0 = Class2353.smethod_0(reader.Value);
					break;
				case "useFirstPageNumber":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "errors":
					enum232_0 = Class2399.smethod_0(reader.Value);
					break;
				case "horizontalDpi":
					uint_13 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "verticalDpi":
					uint_14 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "copies":
					uint_15 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "r:id":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1609(XmlReader reader)
		: base(reader)
	{
	}

	public Class1609()
	{
	}

	protected override void vmethod_1()
	{
		uint_8 = 1u;
		uint_9 = 100u;
		uint_10 = 1u;
		uint_11 = 1u;
		uint_12 = 1u;
		enum223_0 = enum223_1;
		enum222_0 = enum222_1;
		bool_4 = true;
		bool_5 = false;
		bool_6 = false;
		enum187_0 = enum187_1;
		bool_7 = false;
		enum232_0 = enum232_1;
		uint_13 = 600u;
		uint_14 = 600u;
		uint_15 = 1u;
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
		if (uint_8 != 1)
		{
			writer.WriteAttributeString("paperSize", XmlConvert.ToString(uint_8));
		}
		if (uint_9 != 100)
		{
			writer.WriteAttributeString("scale", XmlConvert.ToString(uint_9));
		}
		if (uint_10 != 1)
		{
			writer.WriteAttributeString("firstPageNumber", XmlConvert.ToString(uint_10));
		}
		if (uint_11 != 1)
		{
			writer.WriteAttributeString("fitToWidth", XmlConvert.ToString(uint_11));
		}
		if (uint_12 != 1)
		{
			writer.WriteAttributeString("fitToHeight", XmlConvert.ToString(uint_12));
		}
		if (enum223_0 != enum223_1)
		{
			writer.WriteAttributeString("pageOrder", Class2390.smethod_1(enum223_0));
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
		if (enum187_0 != enum187_1)
		{
			writer.WriteAttributeString("cellComments", Class2353.smethod_1(enum187_0));
		}
		if (bool_7)
		{
			writer.WriteAttributeString("useFirstPageNumber", bool_7 ? "1" : "0");
		}
		if (enum232_0 != enum232_1)
		{
			writer.WriteAttributeString("errors", Class2399.smethod_1(enum232_0));
		}
		if (uint_13 != 600)
		{
			writer.WriteAttributeString("horizontalDpi", XmlConvert.ToString(uint_13));
		}
		if (uint_14 != 600)
		{
			writer.WriteAttributeString("verticalDpi", XmlConvert.ToString(uint_14));
		}
		if (uint_15 != 1)
		{
			writer.WriteAttributeString("copies", XmlConvert.ToString(uint_15));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("r:id", string_0);
		}
		writer.WriteEndElement();
	}
}
