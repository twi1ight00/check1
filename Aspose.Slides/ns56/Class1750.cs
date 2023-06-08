using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1750 : Class1351
{
	public delegate Class1750 Delegate1129();

	public delegate void Delegate1130(Class1750 elementData);

	public delegate void Delegate1131(Class1750 elementData);

	public const uint uint_0 = uint.MaxValue;

	public const uint uint_1 = uint.MaxValue;

	public const uint uint_2 = uint.MaxValue;

	public const uint uint_3 = uint.MaxValue;

	public const uint uint_4 = uint.MaxValue;

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	public const NullableBool nullableBool_1 = NullableBool.NotDefined;

	public const NullableBool nullableBool_2 = NullableBool.NotDefined;

	public const NullableBool nullableBool_3 = NullableBool.NotDefined;

	public const NullableBool nullableBool_4 = NullableBool.NotDefined;

	public const NullableBool nullableBool_5 = NullableBool.NotDefined;

	public Class1393.Delegate141 delegate141_0;

	public Class1393.Delegate143 delegate143_0;

	public Class1396.Delegate150 delegate150_0;

	public Class1396.Delegate152 delegate152_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private uint uint_5;

	private uint uint_6;

	private uint uint_7;

	private uint uint_8;

	private uint uint_9;

	private bool bool_2;

	private bool bool_3;

	private NullableBool nullableBool_6;

	private NullableBool nullableBool_7;

	private NullableBool nullableBool_8;

	private NullableBool nullableBool_9;

	private NullableBool nullableBool_10;

	private NullableBool nullableBool_11;

	private Class1393 class1393_0;

	private Class1396 class1396_0;

	private Class1502 class1502_0;

	public uint NumFmtId
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

	public uint FontId
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

	public uint FillId
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

	public uint BorderId
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

	public uint XfId
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

	public bool QuotePrefix
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool PivotButton
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public NullableBool ApplyNumberFormat
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

	public NullableBool ApplyFont
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

	public NullableBool ApplyFill
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

	public NullableBool ApplyBorder
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

	public NullableBool ApplyAlignment
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

	public NullableBool ApplyProtection
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

	public Class1393 Alignment => class1393_0;

	public Class1396 Protection => class1396_0;

	public Class1502 ExtLst => class1502_0;

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
				case "extLst":
					class1502_0 = new Class1502(reader);
					break;
				case "protection":
					class1396_0 = new Class1396(reader);
					break;
				case "alignment":
					class1393_0 = new Class1393(reader);
					break;
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
				case "numFmtId":
					uint_5 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "fontId":
					uint_6 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "fillId":
					uint_7 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "borderId":
					uint_8 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "xfId":
					uint_9 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "quotePrefix":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "pivotButton":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "applyNumberFormat":
					nullableBool_6 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "applyFont":
					nullableBool_7 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "applyFill":
					nullableBool_8 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "applyBorder":
					nullableBool_9 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "applyAlignment":
					nullableBool_10 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "applyProtection":
					nullableBool_11 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1750(XmlReader reader)
		: base(reader)
	{
	}

	public Class1750()
	{
	}

	protected override void vmethod_1()
	{
		uint_5 = uint.MaxValue;
		uint_6 = uint.MaxValue;
		uint_7 = uint.MaxValue;
		uint_8 = uint.MaxValue;
		uint_9 = uint.MaxValue;
		bool_2 = false;
		bool_3 = false;
		nullableBool_6 = NullableBool.NotDefined;
		nullableBool_7 = NullableBool.NotDefined;
		nullableBool_8 = NullableBool.NotDefined;
		nullableBool_9 = NullableBool.NotDefined;
		nullableBool_10 = NullableBool.NotDefined;
		nullableBool_11 = NullableBool.NotDefined;
	}

	protected override void vmethod_2()
	{
		delegate141_0 = method_3;
		delegate143_0 = method_4;
		delegate150_0 = method_5;
		delegate152_0 = method_6;
		delegate385_0 = method_7;
		delegate387_0 = method_8;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (uint_5 != uint.MaxValue)
		{
			writer.WriteAttributeString("numFmtId", XmlConvert.ToString(uint_5));
		}
		if (uint_6 != uint.MaxValue)
		{
			writer.WriteAttributeString("fontId", XmlConvert.ToString(uint_6));
		}
		if (uint_7 != uint.MaxValue)
		{
			writer.WriteAttributeString("fillId", XmlConvert.ToString(uint_7));
		}
		if (uint_8 != uint.MaxValue)
		{
			writer.WriteAttributeString("borderId", XmlConvert.ToString(uint_8));
		}
		if (uint_9 != uint.MaxValue)
		{
			writer.WriteAttributeString("xfId", XmlConvert.ToString(uint_9));
		}
		if (bool_2)
		{
			writer.WriteAttributeString("quotePrefix", bool_2 ? "1" : "0");
		}
		if (bool_3)
		{
			writer.WriteAttributeString("pivotButton", bool_3 ? "1" : "0");
		}
		if (nullableBool_6 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("applyNumberFormat", (nullableBool_6 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_7 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("applyFont", (nullableBool_7 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_8 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("applyFill", (nullableBool_8 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_9 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("applyBorder", (nullableBool_9 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_10 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("applyAlignment", (nullableBool_10 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_11 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("applyProtection", (nullableBool_11 == NullableBool.True) ? "1" : "0");
		}
		if (class1393_0 != null)
		{
			class1393_0.vmethod_4("ssml", writer, "alignment");
		}
		if (class1396_0 != null)
		{
			class1396_0.vmethod_4("ssml", writer, "protection");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1393 method_3()
	{
		if (class1393_0 != null)
		{
			throw new Exception("Only one <alignment> element can be added.");
		}
		class1393_0 = new Class1393();
		return class1393_0;
	}

	private void method_4(Class1393 _alignment)
	{
		class1393_0 = _alignment;
	}

	private Class1396 method_5()
	{
		if (class1396_0 != null)
		{
			throw new Exception("Only one <protection> element can be added.");
		}
		class1396_0 = new Class1396();
		return class1396_0;
	}

	private void method_6(Class1396 _protection)
	{
		class1396_0 = _protection;
	}

	private Class1502 method_7()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_8(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
