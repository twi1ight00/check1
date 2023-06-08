using System;
using System.Xml;

namespace ns56;

internal class Class1442 : Class1351
{
	public delegate Class1442 Delegate288();

	public delegate void Delegate289(Class1442 elementData);

	public delegate void Delegate290(Class1442 elementData);

	public const uint uint_0 = 100u;

	public const uint uint_1 = 64u;

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = true;

	public const bool bool_3 = true;

	public const bool bool_4 = true;

	public const bool bool_5 = true;

	public const bool bool_6 = false;

	public const bool bool_7 = false;

	public const bool bool_8 = false;

	public const bool bool_9 = false;

	public const bool bool_10 = false;

	public const bool bool_11 = false;

	public const bool bool_12 = false;

	public const bool bool_13 = true;

	public Class1611.Delegate712 delegate712_0;

	public Class1611.Delegate714 delegate714_0;

	public Class1679.Delegate916 delegate916_0;

	public Class1679.Delegate918 delegate918_0;

	public Class1603.Delegate688 delegate688_0;

	public Class1603.Delegate690 delegate690_0;

	public Class1603.Delegate688 delegate688_1;

	public Class1603.Delegate690 delegate690_1;

	public Class1607.Delegate700 delegate700_0;

	public Class1607.Delegate702 delegate702_0;

	public Class1639.Delegate796 delegate796_0;

	public Class1639.Delegate798 delegate798_0;

	public Class1609.Delegate706 delegate706_0;

	public Class1609.Delegate708 delegate708_0;

	public Class1546.Delegate517 delegate517_0;

	public Class1546.Delegate519 delegate519_0;

	public Class1371.Delegate75 delegate75_0;

	public Class1371.Delegate77 delegate77_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private Guid guid_0;

	private uint uint_2;

	private uint uint_3;

	private bool bool_14;

	private bool bool_15;

	private bool bool_16;

	private bool bool_17;

	private bool bool_18;

	private bool bool_19;

	private bool bool_20;

	private bool bool_21;

	private bool bool_22;

	private bool bool_23;

	private bool bool_24;

	private bool bool_25;

	private Enum238 enum238_0;

	private bool bool_26;

	private Enum239 enum239_0;

	private bool bool_27;

	private string string_0;

	private Class1611 class1611_0;

	private Class1679 class1679_0;

	private Class1603 class1603_0;

	private Class1603 class1603_1;

	private Class1607 class1607_0;

	private Class1639 class1639_0;

	private Class1609 class1609_0;

	private Class1546 class1546_0;

	private Class1371 class1371_0;

	private Class1502 class1502_0;

	public static readonly Enum238 enum238_1 = Class2405.smethod_0("visible");

	public static readonly Enum239 enum239_1 = Class2406.smethod_0("normal");

	public Guid Guid
	{
		get
		{
			return guid_0;
		}
		set
		{
			guid_0 = value;
		}
	}

	public uint Scale
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

	public uint ColorId
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

	public bool ShowPageBreaks
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

	public bool ShowFormulas
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

	public bool ShowGridLines
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

	public bool ShowRowCol
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

	public bool OutlineSymbols
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

	public bool ZeroValues
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

	public bool FitToPage
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

	public bool PrintArea
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

	public bool Filter
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

	public bool ShowAutoFilter
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

	public bool HiddenRows
	{
		get
		{
			return bool_24;
		}
		set
		{
			bool_24 = value;
		}
	}

	public bool HiddenColumns
	{
		get
		{
			return bool_25;
		}
		set
		{
			bool_25 = value;
		}
	}

	public Enum238 State
	{
		get
		{
			return enum238_0;
		}
		set
		{
			enum238_0 = value;
		}
	}

	public bool FilterUnique
	{
		get
		{
			return bool_26;
		}
		set
		{
			bool_26 = value;
		}
	}

	public Enum239 View
	{
		get
		{
			return enum239_0;
		}
		set
		{
			enum239_0 = value;
		}
	}

	public bool ShowRuler
	{
		get
		{
			return bool_27;
		}
		set
		{
			bool_27 = value;
		}
	}

	public string TopLeftCell
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

	public Class1611 Pane => class1611_0;

	public Class1679 Selection => class1679_0;

	public Class1603 RowBreaks => class1603_0;

	public Class1603 ColBreaks => class1603_1;

	public Class1607 PageMargins => class1607_0;

	public Class1639 PrintOptions => class1639_0;

	public Class1609 PageSetup => class1609_0;

	public Class1546 HeaderFooter => class1546_0;

	public Class1371 AutoFilter => class1371_0;

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
				case "pane":
					class1611_0 = new Class1611(reader);
					break;
				case "selection":
					class1679_0 = new Class1679(reader);
					break;
				case "rowBreaks":
					class1603_0 = new Class1603(reader);
					break;
				case "colBreaks":
					class1603_1 = new Class1603(reader);
					break;
				case "pageMargins":
					class1607_0 = new Class1607(reader);
					break;
				case "printOptions":
					class1639_0 = new Class1639(reader);
					break;
				case "pageSetup":
					class1609_0 = new Class1609(reader);
					break;
				case "headerFooter":
					class1546_0 = new Class1546(reader);
					break;
				case "autoFilter":
					class1371_0 = new Class1371(reader);
					break;
				case "extLst":
					class1502_0 = new Class1502(reader);
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
				case "guid":
					guid_0 = new Guid(reader.Value);
					break;
				case "scale":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "colorId":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "showPageBreaks":
					bool_14 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showFormulas":
					bool_15 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showGridLines":
					bool_16 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showRowCol":
					bool_17 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "outlineSymbols":
					bool_18 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "zeroValues":
					bool_19 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "fitToPage":
					bool_20 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "printArea":
					bool_21 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "filter":
					bool_22 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showAutoFilter":
					bool_23 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "hiddenRows":
					bool_24 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "hiddenColumns":
					bool_25 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "state":
					enum238_0 = Class2405.smethod_0(reader.Value);
					break;
				case "filterUnique":
					bool_26 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "view":
					enum239_0 = Class2406.smethod_0(reader.Value);
					break;
				case "showRuler":
					bool_27 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "topLeftCell":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1442(XmlReader reader)
		: base(reader)
	{
	}

	public Class1442()
	{
	}

	protected override void vmethod_1()
	{
		guid_0 = Guid.Empty;
		uint_2 = 100u;
		uint_3 = 64u;
		bool_14 = false;
		bool_15 = false;
		bool_16 = true;
		bool_17 = true;
		bool_18 = true;
		bool_19 = true;
		bool_20 = false;
		bool_21 = false;
		bool_22 = false;
		bool_23 = false;
		bool_24 = false;
		bool_25 = false;
		enum238_0 = enum238_1;
		bool_26 = false;
		enum239_0 = enum239_1;
		bool_27 = true;
	}

	protected override void vmethod_2()
	{
		delegate712_0 = method_3;
		delegate714_0 = method_4;
		delegate916_0 = method_5;
		delegate918_0 = method_6;
		delegate688_0 = method_7;
		delegate690_0 = method_8;
		delegate688_1 = method_9;
		delegate690_1 = method_10;
		delegate700_0 = method_11;
		delegate702_0 = method_12;
		delegate796_0 = method_13;
		delegate798_0 = method_14;
		delegate706_0 = method_15;
		delegate708_0 = method_16;
		delegate517_0 = method_17;
		delegate519_0 = method_18;
		delegate75_0 = method_19;
		delegate77_0 = method_20;
		delegate385_0 = method_21;
		delegate387_0 = method_22;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("guid", "{" + XmlConvert.ToString(guid_0).ToUpper() + "}");
		if (uint_2 != 100)
		{
			writer.WriteAttributeString("scale", XmlConvert.ToString(uint_2));
		}
		if (uint_3 != 64)
		{
			writer.WriteAttributeString("colorId", XmlConvert.ToString(uint_3));
		}
		if (bool_14)
		{
			writer.WriteAttributeString("showPageBreaks", bool_14 ? "1" : "0");
		}
		if (bool_15)
		{
			writer.WriteAttributeString("showFormulas", bool_15 ? "1" : "0");
		}
		if (!bool_16)
		{
			writer.WriteAttributeString("showGridLines", bool_16 ? "1" : "0");
		}
		if (!bool_17)
		{
			writer.WriteAttributeString("showRowCol", bool_17 ? "1" : "0");
		}
		if (!bool_18)
		{
			writer.WriteAttributeString("outlineSymbols", bool_18 ? "1" : "0");
		}
		if (!bool_19)
		{
			writer.WriteAttributeString("zeroValues", bool_19 ? "1" : "0");
		}
		if (bool_20)
		{
			writer.WriteAttributeString("fitToPage", bool_20 ? "1" : "0");
		}
		if (bool_21)
		{
			writer.WriteAttributeString("printArea", bool_21 ? "1" : "0");
		}
		if (bool_22)
		{
			writer.WriteAttributeString("filter", bool_22 ? "1" : "0");
		}
		if (bool_23)
		{
			writer.WriteAttributeString("showAutoFilter", bool_23 ? "1" : "0");
		}
		if (bool_24)
		{
			writer.WriteAttributeString("hiddenRows", bool_24 ? "1" : "0");
		}
		if (bool_25)
		{
			writer.WriteAttributeString("hiddenColumns", bool_25 ? "1" : "0");
		}
		if (enum238_0 != enum238_1)
		{
			writer.WriteAttributeString("state", Class2405.smethod_1(enum238_0));
		}
		if (bool_26)
		{
			writer.WriteAttributeString("filterUnique", bool_26 ? "1" : "0");
		}
		if (enum239_0 != enum239_1)
		{
			writer.WriteAttributeString("view", Class2406.smethod_1(enum239_0));
		}
		if (!bool_27)
		{
			writer.WriteAttributeString("showRuler", bool_27 ? "1" : "0");
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("topLeftCell", string_0);
		}
		if (class1611_0 != null)
		{
			class1611_0.vmethod_4("ssml", writer, "pane");
		}
		if (class1679_0 != null)
		{
			class1679_0.vmethod_4("ssml", writer, "selection");
		}
		if (class1603_0 != null)
		{
			class1603_0.vmethod_4("ssml", writer, "rowBreaks");
		}
		if (class1603_1 != null)
		{
			class1603_1.vmethod_4("ssml", writer, "colBreaks");
		}
		if (class1607_0 != null)
		{
			class1607_0.vmethod_4("ssml", writer, "pageMargins");
		}
		if (class1639_0 != null)
		{
			class1639_0.vmethod_4("ssml", writer, "printOptions");
		}
		if (class1609_0 != null)
		{
			class1609_0.vmethod_4("ssml", writer, "pageSetup");
		}
		if (class1546_0 != null)
		{
			class1546_0.vmethod_4("ssml", writer, "headerFooter");
		}
		if (class1371_0 != null)
		{
			class1371_0.vmethod_4("ssml", writer, "autoFilter");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1611 method_3()
	{
		if (class1611_0 != null)
		{
			throw new Exception("Only one <pane> element can be added.");
		}
		class1611_0 = new Class1611();
		return class1611_0;
	}

	private void method_4(Class1611 _pane)
	{
		class1611_0 = _pane;
	}

	private Class1679 method_5()
	{
		if (class1679_0 != null)
		{
			throw new Exception("Only one <selection> element can be added.");
		}
		class1679_0 = new Class1679();
		return class1679_0;
	}

	private void method_6(Class1679 _selection)
	{
		class1679_0 = _selection;
	}

	private Class1603 method_7()
	{
		if (class1603_0 != null)
		{
			throw new Exception("Only one <rowBreaks> element can be added.");
		}
		class1603_0 = new Class1603();
		return class1603_0;
	}

	private void method_8(Class1603 _rowBreaks)
	{
		class1603_0 = _rowBreaks;
	}

	private Class1603 method_9()
	{
		if (class1603_1 != null)
		{
			throw new Exception("Only one <colBreaks> element can be added.");
		}
		class1603_1 = new Class1603();
		return class1603_1;
	}

	private void method_10(Class1603 _colBreaks)
	{
		class1603_1 = _colBreaks;
	}

	private Class1607 method_11()
	{
		if (class1607_0 != null)
		{
			throw new Exception("Only one <pageMargins> element can be added.");
		}
		class1607_0 = new Class1607();
		return class1607_0;
	}

	private void method_12(Class1607 _pageMargins)
	{
		class1607_0 = _pageMargins;
	}

	private Class1639 method_13()
	{
		if (class1639_0 != null)
		{
			throw new Exception("Only one <printOptions> element can be added.");
		}
		class1639_0 = new Class1639();
		return class1639_0;
	}

	private void method_14(Class1639 _printOptions)
	{
		class1639_0 = _printOptions;
	}

	private Class1609 method_15()
	{
		if (class1609_0 != null)
		{
			throw new Exception("Only one <pageSetup> element can be added.");
		}
		class1609_0 = new Class1609();
		return class1609_0;
	}

	private void method_16(Class1609 _pageSetup)
	{
		class1609_0 = _pageSetup;
	}

	private Class1546 method_17()
	{
		if (class1546_0 != null)
		{
			throw new Exception("Only one <headerFooter> element can be added.");
		}
		class1546_0 = new Class1546();
		return class1546_0;
	}

	private void method_18(Class1546 _headerFooter)
	{
		class1546_0 = _headerFooter;
	}

	private Class1371 method_19()
	{
		if (class1371_0 != null)
		{
			throw new Exception("Only one <autoFilter> element can be added.");
		}
		class1371_0 = new Class1371();
		return class1371_0;
	}

	private void method_20(Class1371 _autoFilter)
	{
		class1371_0 = _autoFilter;
	}

	private Class1502 method_21()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_22(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
