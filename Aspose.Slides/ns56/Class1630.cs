using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1630 : Class1351
{
	public delegate Class1630 Delegate769();

	public delegate void Delegate770(Class1630 elementData);

	public delegate void Delegate771(Class1630 elementData);

	public const Enum183 enum183_0 = Enum183.const_0;

	public const bool bool_0 = false;

	public const bool bool_1 = true;

	public const bool bool_2 = false;

	public const bool bool_3 = true;

	public const bool bool_4 = false;

	public const uint uint_0 = uint.MaxValue;

	public const bool bool_5 = true;

	public const bool bool_6 = true;

	public const bool bool_7 = true;

	public const bool bool_8 = true;

	public const bool bool_9 = false;

	public const bool bool_10 = true;

	public const bool bool_11 = true;

	public const bool bool_12 = true;

	public const bool bool_13 = true;

	public const bool bool_14 = false;

	public const bool bool_15 = false;

	public const bool bool_16 = false;

	public const bool bool_17 = false;

	public const bool bool_18 = true;

	public const bool bool_19 = false;

	public const bool bool_20 = false;

	public const bool bool_21 = false;

	public const uint uint_1 = 10u;

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	public const bool bool_22 = false;

	public const uint uint_2 = uint.MaxValue;

	public const bool bool_23 = true;

	public const bool bool_24 = false;

	public const bool bool_25 = false;

	public const bool bool_26 = false;

	public const bool bool_27 = false;

	public const bool bool_28 = false;

	public const bool bool_29 = false;

	public const bool bool_30 = false;

	public const bool bool_31 = false;

	public const bool bool_32 = false;

	public const bool bool_33 = false;

	public const bool bool_34 = false;

	public const bool bool_35 = false;

	public const bool bool_36 = false;

	public const bool bool_37 = false;

	public const bool bool_38 = false;

	public Class1560.Delegate559 delegate559_0;

	public Class1560.Delegate561 delegate561_0;

	public Class1372.Delegate78 delegate78_0;

	public Class1372.Delegate80 delegate80_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private string string_0;

	private Enum183 enum183_1;

	private bool bool_39;

	private string string_1;

	private bool bool_40;

	private bool bool_41;

	private string string_2;

	private bool bool_42;

	private bool bool_43;

	private uint uint_3;

	private bool bool_44;

	private bool bool_45;

	private bool bool_46;

	private bool bool_47;

	private bool bool_48;

	private bool bool_49;

	private bool bool_50;

	private bool bool_51;

	private bool bool_52;

	private bool bool_53;

	private bool bool_54;

	private bool bool_55;

	private bool bool_56;

	private bool bool_57;

	private bool bool_58;

	private bool bool_59;

	private bool bool_60;

	private uint uint_4;

	private Enum204 enum204_0;

	private NullableBool nullableBool_1;

	private bool bool_61;

	private uint uint_5;

	private bool bool_62;

	private bool bool_63;

	private bool bool_64;

	private bool bool_65;

	private bool bool_66;

	private bool bool_67;

	private bool bool_68;

	private bool bool_69;

	private bool bool_70;

	private bool bool_71;

	private bool bool_72;

	private bool bool_73;

	private bool bool_74;

	private bool bool_75;

	private bool bool_76;

	private bool bool_77;

	private Class1560 class1560_0;

	private Class1372 class1372_0;

	private Class1502 class1502_0;

	public static readonly Enum204 enum204_1 = Class2371.smethod_0("manual");

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

	public Enum183 Axis
	{
		get
		{
			return enum183_1;
		}
		set
		{
			enum183_1 = value;
		}
	}

	public bool DataField
	{
		get
		{
			return bool_39;
		}
		set
		{
			bool_39 = value;
		}
	}

	public string SubtotalCaption
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

	public bool ShowDropDowns
	{
		get
		{
			return bool_40;
		}
		set
		{
			bool_40 = value;
		}
	}

	public bool HiddenLevel
	{
		get
		{
			return bool_41;
		}
		set
		{
			bool_41 = value;
		}
	}

	public string UniqueMemberProperty
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

	public bool Compact
	{
		get
		{
			return bool_42;
		}
		set
		{
			bool_42 = value;
		}
	}

	public bool AllDrilled
	{
		get
		{
			return bool_43;
		}
		set
		{
			bool_43 = value;
		}
	}

	public uint NumFmtId
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

	public bool Outline
	{
		get
		{
			return bool_44;
		}
		set
		{
			bool_44 = value;
		}
	}

	public bool SubtotalTop
	{
		get
		{
			return bool_45;
		}
		set
		{
			bool_45 = value;
		}
	}

	public bool DragToRow
	{
		get
		{
			return bool_46;
		}
		set
		{
			bool_46 = value;
		}
	}

	public bool DragToCol
	{
		get
		{
			return bool_47;
		}
		set
		{
			bool_47 = value;
		}
	}

	public bool MultipleItemSelectionAllowed
	{
		get
		{
			return bool_48;
		}
		set
		{
			bool_48 = value;
		}
	}

	public bool DragToPage
	{
		get
		{
			return bool_49;
		}
		set
		{
			bool_49 = value;
		}
	}

	public bool DragToData
	{
		get
		{
			return bool_50;
		}
		set
		{
			bool_50 = value;
		}
	}

	public bool DragOff
	{
		get
		{
			return bool_51;
		}
		set
		{
			bool_51 = value;
		}
	}

	public bool ShowAll
	{
		get
		{
			return bool_52;
		}
		set
		{
			bool_52 = value;
		}
	}

	public bool InsertBlankRow
	{
		get
		{
			return bool_53;
		}
		set
		{
			bool_53 = value;
		}
	}

	public bool ServerField
	{
		get
		{
			return bool_54;
		}
		set
		{
			bool_54 = value;
		}
	}

	public bool InsertPageBreak
	{
		get
		{
			return bool_55;
		}
		set
		{
			bool_55 = value;
		}
	}

	public bool AutoShow
	{
		get
		{
			return bool_56;
		}
		set
		{
			bool_56 = value;
		}
	}

	public bool TopAutoShow
	{
		get
		{
			return bool_57;
		}
		set
		{
			bool_57 = value;
		}
	}

	public bool HideNewItems
	{
		get
		{
			return bool_58;
		}
		set
		{
			bool_58 = value;
		}
	}

	public bool MeasureFilter
	{
		get
		{
			return bool_59;
		}
		set
		{
			bool_59 = value;
		}
	}

	public bool IncludeNewItemsInFilter
	{
		get
		{
			return bool_60;
		}
		set
		{
			bool_60 = value;
		}
	}

	public uint ItemPageCount
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

	public Enum204 SortType
	{
		get
		{
			return enum204_0;
		}
		set
		{
			enum204_0 = value;
		}
	}

	public NullableBool DataSourceSort
	{
		get
		{
			return nullableBool_1;
		}
		set
		{
			nullableBool_1 = value;
		}
	}

	public bool NonAutoSortDefault
	{
		get
		{
			return bool_61;
		}
		set
		{
			bool_61 = value;
		}
	}

	public uint RankBy
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

	public bool DefaultSubtotal
	{
		get
		{
			return bool_62;
		}
		set
		{
			bool_62 = value;
		}
	}

	public bool SumSubtotal
	{
		get
		{
			return bool_63;
		}
		set
		{
			bool_63 = value;
		}
	}

	public bool CountASubtotal
	{
		get
		{
			return bool_64;
		}
		set
		{
			bool_64 = value;
		}
	}

	public bool AvgSubtotal
	{
		get
		{
			return bool_65;
		}
		set
		{
			bool_65 = value;
		}
	}

	public bool MaxSubtotal
	{
		get
		{
			return bool_66;
		}
		set
		{
			bool_66 = value;
		}
	}

	public bool MinSubtotal
	{
		get
		{
			return bool_67;
		}
		set
		{
			bool_67 = value;
		}
	}

	public bool ProductSubtotal
	{
		get
		{
			return bool_68;
		}
		set
		{
			bool_68 = value;
		}
	}

	public bool CountSubtotal
	{
		get
		{
			return bool_69;
		}
		set
		{
			bool_69 = value;
		}
	}

	public bool StdDevSubtotal
	{
		get
		{
			return bool_70;
		}
		set
		{
			bool_70 = value;
		}
	}

	public bool StdDevPSubtotal
	{
		get
		{
			return bool_71;
		}
		set
		{
			bool_71 = value;
		}
	}

	public bool VarSubtotal
	{
		get
		{
			return bool_72;
		}
		set
		{
			bool_72 = value;
		}
	}

	public bool VarPSubtotal
	{
		get
		{
			return bool_73;
		}
		set
		{
			bool_73 = value;
		}
	}

	public bool ShowPropCell
	{
		get
		{
			return bool_74;
		}
		set
		{
			bool_74 = value;
		}
	}

	public bool ShowPropTip
	{
		get
		{
			return bool_75;
		}
		set
		{
			bool_75 = value;
		}
	}

	public bool ShowPropAsCaption
	{
		get
		{
			return bool_76;
		}
		set
		{
			bool_76 = value;
		}
	}

	public bool DefaultAttributeDrillState
	{
		get
		{
			return bool_77;
		}
		set
		{
			bool_77 = value;
		}
	}

	public Class1560 Items => class1560_0;

	public Class1372 AutoSortScope => class1372_0;

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
				case "autoSortScope":
					class1372_0 = new Class1372(reader);
					break;
				case "items":
					class1560_0 = new Class1560(reader);
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
				case "axis":
					enum183_1 = Class2349.smethod_0(reader.Value);
					break;
				case "dataField":
					bool_39 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "subtotalCaption":
					string_1 = reader.Value;
					break;
				case "showDropDowns":
					bool_40 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "hiddenLevel":
					bool_41 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "uniqueMemberProperty":
					string_2 = reader.Value;
					break;
				case "compact":
					bool_42 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "allDrilled":
					bool_43 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "numFmtId":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "outline":
					bool_44 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "subtotalTop":
					bool_45 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "dragToRow":
					bool_46 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "dragToCol":
					bool_47 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "multipleItemSelectionAllowed":
					bool_48 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "dragToPage":
					bool_49 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "dragToData":
					bool_50 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "dragOff":
					bool_51 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showAll":
					bool_52 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "insertBlankRow":
					bool_53 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "serverField":
					bool_54 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "insertPageBreak":
					bool_55 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "autoShow":
					bool_56 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "topAutoShow":
					bool_57 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "hideNewItems":
					bool_58 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "measureFilter":
					bool_59 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "includeNewItemsInFilter":
					bool_60 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "itemPageCount":
					uint_4 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "sortType":
					enum204_0 = Class2371.smethod_0(reader.Value);
					break;
				case "dataSourceSort":
					nullableBool_1 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "nonAutoSortDefault":
					bool_61 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "rankBy":
					uint_5 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "defaultSubtotal":
					bool_62 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "sumSubtotal":
					bool_63 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "countASubtotal":
					bool_64 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "avgSubtotal":
					bool_65 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "maxSubtotal":
					bool_66 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "minSubtotal":
					bool_67 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "productSubtotal":
					bool_68 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "countSubtotal":
					bool_69 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "stdDevSubtotal":
					bool_70 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "stdDevPSubtotal":
					bool_71 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "varSubtotal":
					bool_72 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "varPSubtotal":
					bool_73 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showPropCell":
					bool_74 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showPropTip":
					bool_75 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showPropAsCaption":
					bool_76 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "defaultAttributeDrillState":
					bool_77 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1630(XmlReader reader)
		: base(reader)
	{
	}

	public Class1630()
	{
	}

	protected override void vmethod_1()
	{
		enum183_1 = Enum183.const_0;
		bool_39 = false;
		bool_40 = true;
		bool_41 = false;
		bool_42 = true;
		bool_43 = false;
		uint_3 = uint.MaxValue;
		bool_44 = true;
		bool_45 = true;
		bool_46 = true;
		bool_47 = true;
		bool_48 = false;
		bool_49 = true;
		bool_50 = true;
		bool_51 = true;
		bool_52 = true;
		bool_53 = false;
		bool_54 = false;
		bool_55 = false;
		bool_56 = false;
		bool_57 = true;
		bool_58 = false;
		bool_59 = false;
		bool_60 = false;
		uint_4 = 10u;
		enum204_0 = enum204_1;
		nullableBool_1 = NullableBool.NotDefined;
		bool_61 = false;
		uint_5 = uint.MaxValue;
		bool_62 = true;
		bool_63 = false;
		bool_64 = false;
		bool_65 = false;
		bool_66 = false;
		bool_67 = false;
		bool_68 = false;
		bool_69 = false;
		bool_70 = false;
		bool_71 = false;
		bool_72 = false;
		bool_73 = false;
		bool_74 = false;
		bool_75 = false;
		bool_76 = false;
		bool_77 = false;
	}

	protected override void vmethod_2()
	{
		delegate559_0 = method_3;
		delegate561_0 = method_4;
		delegate78_0 = method_5;
		delegate80_0 = method_6;
		delegate385_0 = method_7;
		delegate387_0 = method_8;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (string_0 != null)
		{
			writer.WriteAttributeString("name", string_0);
		}
		if (enum183_1 != 0)
		{
			writer.WriteAttributeString("axis", Class2349.smethod_1(enum183_1));
		}
		if (bool_39)
		{
			writer.WriteAttributeString("dataField", bool_39 ? "1" : "0");
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("subtotalCaption", string_1);
		}
		if (!bool_40)
		{
			writer.WriteAttributeString("showDropDowns", bool_40 ? "1" : "0");
		}
		if (bool_41)
		{
			writer.WriteAttributeString("hiddenLevel", bool_41 ? "1" : "0");
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("uniqueMemberProperty", string_2);
		}
		if (!bool_42)
		{
			writer.WriteAttributeString("compact", bool_42 ? "1" : "0");
		}
		if (bool_43)
		{
			writer.WriteAttributeString("allDrilled", bool_43 ? "1" : "0");
		}
		if (uint_3 != uint.MaxValue)
		{
			writer.WriteAttributeString("numFmtId", XmlConvert.ToString(uint_3));
		}
		if (!bool_44)
		{
			writer.WriteAttributeString("outline", bool_44 ? "1" : "0");
		}
		if (!bool_45)
		{
			writer.WriteAttributeString("subtotalTop", bool_45 ? "1" : "0");
		}
		if (!bool_46)
		{
			writer.WriteAttributeString("dragToRow", bool_46 ? "1" : "0");
		}
		if (!bool_47)
		{
			writer.WriteAttributeString("dragToCol", bool_47 ? "1" : "0");
		}
		if (bool_48)
		{
			writer.WriteAttributeString("multipleItemSelectionAllowed", bool_48 ? "1" : "0");
		}
		if (!bool_49)
		{
			writer.WriteAttributeString("dragToPage", bool_49 ? "1" : "0");
		}
		if (!bool_50)
		{
			writer.WriteAttributeString("dragToData", bool_50 ? "1" : "0");
		}
		if (!bool_51)
		{
			writer.WriteAttributeString("dragOff", bool_51 ? "1" : "0");
		}
		if (!bool_52)
		{
			writer.WriteAttributeString("showAll", bool_52 ? "1" : "0");
		}
		if (bool_53)
		{
			writer.WriteAttributeString("insertBlankRow", bool_53 ? "1" : "0");
		}
		if (bool_54)
		{
			writer.WriteAttributeString("serverField", bool_54 ? "1" : "0");
		}
		if (bool_55)
		{
			writer.WriteAttributeString("insertPageBreak", bool_55 ? "1" : "0");
		}
		if (bool_56)
		{
			writer.WriteAttributeString("autoShow", bool_56 ? "1" : "0");
		}
		if (!bool_57)
		{
			writer.WriteAttributeString("topAutoShow", bool_57 ? "1" : "0");
		}
		if (bool_58)
		{
			writer.WriteAttributeString("hideNewItems", bool_58 ? "1" : "0");
		}
		if (bool_59)
		{
			writer.WriteAttributeString("measureFilter", bool_59 ? "1" : "0");
		}
		if (bool_60)
		{
			writer.WriteAttributeString("includeNewItemsInFilter", bool_60 ? "1" : "0");
		}
		if (uint_4 != 10)
		{
			writer.WriteAttributeString("itemPageCount", XmlConvert.ToString(uint_4));
		}
		if (enum204_0 != enum204_1)
		{
			writer.WriteAttributeString("sortType", Class2371.smethod_1(enum204_0));
		}
		if (nullableBool_1 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("dataSourceSort", (nullableBool_1 == NullableBool.True) ? "1" : "0");
		}
		if (bool_61)
		{
			writer.WriteAttributeString("nonAutoSortDefault", bool_61 ? "1" : "0");
		}
		if (uint_5 != uint.MaxValue)
		{
			writer.WriteAttributeString("rankBy", XmlConvert.ToString(uint_5));
		}
		if (!bool_62)
		{
			writer.WriteAttributeString("defaultSubtotal", bool_62 ? "1" : "0");
		}
		if (bool_63)
		{
			writer.WriteAttributeString("sumSubtotal", bool_63 ? "1" : "0");
		}
		if (bool_64)
		{
			writer.WriteAttributeString("countASubtotal", bool_64 ? "1" : "0");
		}
		if (bool_65)
		{
			writer.WriteAttributeString("avgSubtotal", bool_65 ? "1" : "0");
		}
		if (bool_66)
		{
			writer.WriteAttributeString("maxSubtotal", bool_66 ? "1" : "0");
		}
		if (bool_67)
		{
			writer.WriteAttributeString("minSubtotal", bool_67 ? "1" : "0");
		}
		if (bool_68)
		{
			writer.WriteAttributeString("productSubtotal", bool_68 ? "1" : "0");
		}
		if (bool_69)
		{
			writer.WriteAttributeString("countSubtotal", bool_69 ? "1" : "0");
		}
		if (bool_70)
		{
			writer.WriteAttributeString("stdDevSubtotal", bool_70 ? "1" : "0");
		}
		if (bool_71)
		{
			writer.WriteAttributeString("stdDevPSubtotal", bool_71 ? "1" : "0");
		}
		if (bool_72)
		{
			writer.WriteAttributeString("varSubtotal", bool_72 ? "1" : "0");
		}
		if (bool_73)
		{
			writer.WriteAttributeString("varPSubtotal", bool_73 ? "1" : "0");
		}
		if (bool_74)
		{
			writer.WriteAttributeString("showPropCell", bool_74 ? "1" : "0");
		}
		if (bool_75)
		{
			writer.WriteAttributeString("showPropTip", bool_75 ? "1" : "0");
		}
		if (bool_76)
		{
			writer.WriteAttributeString("showPropAsCaption", bool_76 ? "1" : "0");
		}
		if (bool_77)
		{
			writer.WriteAttributeString("defaultAttributeDrillState", bool_77 ? "1" : "0");
		}
		if (class1560_0 != null)
		{
			class1560_0.vmethod_4("ssml", writer, "items");
		}
		if (class1372_0 != null)
		{
			class1372_0.vmethod_4("ssml", writer, "autoSortScope");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1560 method_3()
	{
		if (class1560_0 != null)
		{
			throw new Exception("Only one <items> element can be added.");
		}
		class1560_0 = new Class1560();
		return class1560_0;
	}

	private void method_4(Class1560 _items)
	{
		class1560_0 = _items;
	}

	private Class1372 method_5()
	{
		if (class1372_0 != null)
		{
			throw new Exception("Only one <autoSortScope> element can be added.");
		}
		class1372_0 = new Class1372();
		return class1372_0;
	}

	private void method_6(Class1372 _autoSortScope)
	{
		class1372_0 = _autoSortScope;
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
