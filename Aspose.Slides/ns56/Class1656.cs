using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1656 : Class1351
{
	public delegate Class1656 Delegate847();

	public delegate void Delegate848(Class1656 elementData);

	public delegate void Delegate849(Class1656 elementData);

	public const uint uint_0 = uint.MaxValue;

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	public const NullableBool nullableBool_1 = NullableBool.NotDefined;

	public const NullableBool nullableBool_2 = NullableBool.NotDefined;

	public const NullableBool nullableBool_3 = NullableBool.NotDefined;

	public const NullableBool nullableBool_4 = NullableBool.NotDefined;

	public const NullableBool nullableBool_5 = NullableBool.NotDefined;

	private uint uint_1;

	private uint uint_2;

	private NullableBool nullableBool_6;

	private NullableBool nullableBool_7;

	private NullableBool nullableBool_8;

	private NullableBool nullableBool_9;

	private NullableBool nullableBool_10;

	private NullableBool nullableBool_11;

	private string string_0;

	public uint SheetId
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

	public uint AutoFormatId
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

	public NullableBool ApplyNumberFormats
	{
		get
		{
			return nullableBool_6;
		}
		set
		{
			nullableBool_6 = value;
		}
	}

	public NullableBool ApplyBorderFormats
	{
		get
		{
			return nullableBool_7;
		}
		set
		{
			nullableBool_7 = value;
		}
	}

	public NullableBool ApplyFontFormats
	{
		get
		{
			return nullableBool_8;
		}
		set
		{
			nullableBool_8 = value;
		}
	}

	public NullableBool ApplyPatternFormats
	{
		get
		{
			return nullableBool_9;
		}
		set
		{
			nullableBool_9 = value;
		}
	}

	public NullableBool ApplyAlignmentFormats
	{
		get
		{
			return nullableBool_10;
		}
		set
		{
			nullableBool_10 = value;
		}
	}

	public NullableBool ApplyWidthHeightFormats
	{
		get
		{
			return nullableBool_11;
		}
		set
		{
			nullableBool_11 = value;
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
				case "sheetId":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "autoFormatId":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "applyNumberFormats":
					nullableBool_6 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "applyBorderFormats":
					nullableBool_7 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "applyFontFormats":
					nullableBool_8 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "applyPatternFormats":
					nullableBool_9 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "applyAlignmentFormats":
					nullableBool_10 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "applyWidthHeightFormats":
					nullableBool_11 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "ref":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1656(XmlReader reader)
		: base(reader)
	{
	}

	public Class1656()
	{
	}

	protected override void vmethod_1()
	{
		uint_2 = uint.MaxValue;
		nullableBool_6 = NullableBool.NotDefined;
		nullableBool_7 = NullableBool.NotDefined;
		nullableBool_8 = NullableBool.NotDefined;
		nullableBool_9 = NullableBool.NotDefined;
		nullableBool_10 = NullableBool.NotDefined;
		nullableBool_11 = NullableBool.NotDefined;
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
		writer.WriteAttributeString("sheetId", XmlConvert.ToString(uint_1));
		if (uint_2 != uint.MaxValue)
		{
			writer.WriteAttributeString("autoFormatId", XmlConvert.ToString(uint_2));
		}
		if (nullableBool_6 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("applyNumberFormats", (nullableBool_6 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_7 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("applyBorderFormats", (nullableBool_7 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_8 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("applyFontFormats", (nullableBool_8 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_9 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("applyPatternFormats", (nullableBool_9 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_10 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("applyAlignmentFormats", (nullableBool_10 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_11 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("applyWidthHeightFormats", (nullableBool_11 == NullableBool.True) ? "1" : "0");
		}
		writer.WriteAttributeString("ref", string_0);
		writer.WriteEndElement();
	}
}
