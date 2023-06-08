using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1393 : Class1351
{
	public delegate void Delegate143(Class1393 elementData);

	public delegate Class1393 Delegate141();

	public delegate void Delegate142(Class1393 elementData);

	public const Enum213 enum213_0 = Enum213.const_0;

	public const Enum254 enum254_0 = Enum254.const_0;

	public const uint uint_0 = uint.MaxValue;

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	public const uint uint_1 = uint.MaxValue;

	public const int int_0 = 0;

	public const NullableBool nullableBool_1 = NullableBool.NotDefined;

	public const NullableBool nullableBool_2 = NullableBool.NotDefined;

	public const uint uint_2 = uint.MaxValue;

	private Enum213 enum213_1;

	private Enum254 enum254_1;

	private uint uint_3;

	private NullableBool nullableBool_3;

	private uint uint_4;

	private int int_1;

	private NullableBool nullableBool_4;

	private NullableBool nullableBool_5;

	private uint uint_5;

	public Enum213 Horizontal
	{
		get
		{
			return enum213_1;
		}
		set
		{
			enum213_1 = value;
		}
	}

	public Enum254 Vertical
	{
		get
		{
			return enum254_1;
		}
		set
		{
			enum254_1 = value;
		}
	}

	public uint TextRotation
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

	public NullableBool WrapText
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

	public uint Indent
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

	public int RelativeIndent
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public NullableBool JustifyLastLine
	{
		get
		{
			return nullableBool_4;
		}
		set
		{
			nullableBool_4 = value;
		}
	}

	public NullableBool ShrinkToFit
	{
		get
		{
			return nullableBool_5;
		}
		set
		{
			nullableBool_5 = value;
		}
	}

	public uint ReadingOrder
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
				case "horizontal":
					enum213_1 = Class2380.smethod_0(reader.Value);
					break;
				case "vertical":
					enum254_1 = Class2421.smethod_0(reader.Value);
					break;
				case "textRotation":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "wrapText":
					nullableBool_3 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "indent":
					uint_4 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "relativeIndent":
					int_1 = XmlConvert.ToInt32(reader.Value);
					break;
				case "justifyLastLine":
					nullableBool_4 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "shrinkToFit":
					nullableBool_5 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "readingOrder":
					uint_5 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1393(XmlReader reader)
		: base(reader)
	{
	}

	public Class1393()
	{
	}

	protected override void vmethod_1()
	{
		enum213_1 = Enum213.const_0;
		enum254_1 = Enum254.const_0;
		uint_3 = uint.MaxValue;
		nullableBool_3 = NullableBool.NotDefined;
		uint_4 = uint.MaxValue;
		int_1 = 0;
		nullableBool_4 = NullableBool.NotDefined;
		nullableBool_5 = NullableBool.NotDefined;
		uint_5 = uint.MaxValue;
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
		if (enum213_1 != 0)
		{
			writer.WriteAttributeString("horizontal", Class2380.smethod_1(enum213_1));
		}
		if (enum254_1 != 0)
		{
			writer.WriteAttributeString("vertical", Class2421.smethod_1(enum254_1));
		}
		if (uint_3 != uint.MaxValue)
		{
			writer.WriteAttributeString("textRotation", XmlConvert.ToString(uint_3));
		}
		if (nullableBool_3 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("wrapText", (nullableBool_3 == NullableBool.True) ? "1" : "0");
		}
		if (uint_4 != uint.MaxValue)
		{
			writer.WriteAttributeString("indent", XmlConvert.ToString(uint_4));
		}
		if (int_1 != 0)
		{
			writer.WriteAttributeString("relativeIndent", XmlConvert.ToString(int_1));
		}
		if (nullableBool_4 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("justifyLastLine", (nullableBool_4 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_5 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("shrinkToFit", (nullableBool_5 == NullableBool.True) ? "1" : "0");
		}
		if (uint_5 != uint.MaxValue)
		{
			writer.WriteAttributeString("readingOrder", XmlConvert.ToString(uint_5));
		}
		writer.WriteEndElement();
	}
}
