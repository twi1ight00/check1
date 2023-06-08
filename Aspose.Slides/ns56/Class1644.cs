using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1644 : Class1351
{
	public delegate Class1644 Delegate811();

	public delegate void Delegate812(Class1644 elementData);

	public delegate void Delegate813(Class1644 elementData);

	public const bool bool_0 = true;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = true;

	public const bool bool_4 = false;

	public const bool bool_5 = false;

	public const bool bool_6 = false;

	public const bool bool_7 = false;

	public const bool bool_8 = false;

	public const bool bool_9 = true;

	public const bool bool_10 = true;

	public const bool bool_11 = false;

	public const uint uint_0 = uint.MaxValue;

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	public const NullableBool nullableBool_1 = NullableBool.NotDefined;

	public const NullableBool nullableBool_2 = NullableBool.NotDefined;

	public const NullableBool nullableBool_3 = NullableBool.NotDefined;

	public const NullableBool nullableBool_4 = NullableBool.NotDefined;

	public const NullableBool nullableBool_5 = NullableBool.NotDefined;

	public Class1648.Delegate823 delegate823_0;

	public Class1648.Delegate825 delegate825_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private string string_0;

	private bool bool_12;

	private bool bool_13;

	private bool bool_14;

	private bool bool_15;

	private bool bool_16;

	private bool bool_17;

	private Enum212 enum212_0;

	private bool bool_18;

	private bool bool_19;

	private bool bool_20;

	private bool bool_21;

	private bool bool_22;

	private bool bool_23;

	private uint uint_1;

	private uint uint_2;

	private NullableBool nullableBool_6;

	private NullableBool nullableBool_7;

	private NullableBool nullableBool_8;

	private NullableBool nullableBool_9;

	private NullableBool nullableBool_10;

	private NullableBool nullableBool_11;

	private Class1648 class1648_0;

	private Class1502 class1502_0;

	public static readonly Enum212 enum212_1 = Class2379.smethod_0("insertDelete");

	public string Name
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

	public bool Headers
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

	public bool RowNumbers
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

	public bool DisableRefresh
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

	public bool BackgroundRefresh
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

	public bool FirstBackgroundRefresh
	{
		get
		{
			return bool_16;
		}
		set
		{
			bool_16 = value;
		}
	}

	public bool RefreshOnLoad
	{
		get
		{
			return bool_17;
		}
		set
		{
			bool_17 = value;
		}
	}

	public Enum212 GrowShrinkType
	{
		get
		{
			return enum212_0;
		}
		set
		{
			enum212_0 = value;
		}
	}

	public bool FillFormulas
	{
		get
		{
			return bool_18;
		}
		set
		{
			bool_18 = value;
		}
	}

	public bool RemoveDataOnSave
	{
		get
		{
			return bool_19;
		}
		set
		{
			bool_19 = value;
		}
	}

	public bool DisableEdit
	{
		get
		{
			return bool_20;
		}
		set
		{
			bool_20 = value;
		}
	}

	public bool PreserveFormatting
	{
		get
		{
			return bool_21;
		}
		set
		{
			bool_21 = value;
		}
	}

	public bool AdjustColumnWidth
	{
		get
		{
			return bool_22;
		}
		set
		{
			bool_22 = value;
		}
	}

	public bool Intermediate
	{
		get
		{
			return bool_23;
		}
		set
		{
			bool_23 = value;
		}
	}

	public uint ConnectionId
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

	public Class1648 QueryTableRefresh => class1648_0;

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
				case "queryTableRefresh":
					class1648_0 = new Class1648(reader);
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
				case "name":
					string_0 = reader.Value;
					break;
				case "headers":
					bool_12 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "rowNumbers":
					bool_13 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "disableRefresh":
					bool_14 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "backgroundRefresh":
					bool_15 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "firstBackgroundRefresh":
					bool_16 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "refreshOnLoad":
					bool_17 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "growShrinkType":
					enum212_0 = Class2379.smethod_0(reader.Value);
					break;
				case "fillFormulas":
					bool_18 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "removeDataOnSave":
					bool_19 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "disableEdit":
					bool_20 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "preserveFormatting":
					bool_21 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "adjustColumnWidth":
					bool_22 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "intermediate":
					bool_23 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "connectionId":
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
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1644(XmlReader reader)
		: base(reader)
	{
	}

	public Class1644()
	{
	}

	protected override void vmethod_1()
	{
		bool_12 = true;
		bool_13 = false;
		bool_14 = false;
		bool_15 = true;
		bool_16 = false;
		bool_17 = false;
		enum212_0 = enum212_1;
		bool_18 = false;
		bool_19 = false;
		bool_20 = false;
		bool_21 = true;
		bool_22 = true;
		bool_23 = false;
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
		delegate823_0 = method_3;
		delegate825_0 = method_4;
		delegate385_0 = method_5;
		delegate387_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("ssml", elementName, "http://schemas.openxmlformats.org/spreadsheetml/2006/main");
		writer.WriteAttributeString("name", string_0);
		if (!bool_12)
		{
			writer.WriteAttributeString("headers", bool_12 ? "1" : "0");
		}
		if (bool_13)
		{
			writer.WriteAttributeString("rowNumbers", bool_13 ? "1" : "0");
		}
		if (bool_14)
		{
			writer.WriteAttributeString("disableRefresh", bool_14 ? "1" : "0");
		}
		if (!bool_15)
		{
			writer.WriteAttributeString("backgroundRefresh", bool_15 ? "1" : "0");
		}
		if (bool_16)
		{
			writer.WriteAttributeString("firstBackgroundRefresh", bool_16 ? "1" : "0");
		}
		if (bool_17)
		{
			writer.WriteAttributeString("refreshOnLoad", bool_17 ? "1" : "0");
		}
		if (enum212_0 != enum212_1)
		{
			writer.WriteAttributeString("growShrinkType", Class2379.smethod_1(enum212_0));
		}
		if (bool_18)
		{
			writer.WriteAttributeString("fillFormulas", bool_18 ? "1" : "0");
		}
		if (bool_19)
		{
			writer.WriteAttributeString("removeDataOnSave", bool_19 ? "1" : "0");
		}
		if (bool_20)
		{
			writer.WriteAttributeString("disableEdit", bool_20 ? "1" : "0");
		}
		if (!bool_21)
		{
			writer.WriteAttributeString("preserveFormatting", bool_21 ? "1" : "0");
		}
		if (!bool_22)
		{
			writer.WriteAttributeString("adjustColumnWidth", bool_22 ? "1" : "0");
		}
		if (bool_23)
		{
			writer.WriteAttributeString("intermediate", bool_23 ? "1" : "0");
		}
		writer.WriteAttributeString("connectionId", XmlConvert.ToString(uint_1));
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
		if (class1648_0 != null)
		{
			class1648_0.vmethod_4("ssml", writer, "queryTableRefresh");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1648 method_3()
	{
		if (class1648_0 != null)
		{
			throw new Exception("Only one <queryTableRefresh> element can be added.");
		}
		class1648_0 = new Class1648();
		return class1648_0;
	}

	private void method_4(Class1648 _queryTableRefresh)
	{
		class1648_0 = _queryTableRefresh;
	}

	private Class1502 method_5()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_6(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
