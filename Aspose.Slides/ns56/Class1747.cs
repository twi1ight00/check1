using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1747 : Class1351
{
	public delegate Class1747 Delegate1120();

	public delegate void Delegate1121(Class1747 elementData);

	public delegate void Delegate1122(Class1747 elementData);

	public Class1694.Delegate961 delegate961_0;

	public Class1694.Delegate963 delegate963_0;

	public Class1689.Delegate946 delegate946_0;

	public Class1689.Delegate948 delegate948_0;

	public Class1698.Delegate973 delegate973_0;

	public Class1698.Delegate975 delegate975_0;

	public Class1691.Delegate952 delegate952_0;

	public Class1691.Delegate954 delegate954_0;

	public Class1423.Delegate231 delegate231_0;

	public Class1423.Delegate232 delegate232_0;

	public Class1687.Delegate940 delegate940_0;

	public Class1687.Delegate942 delegate942_0;

	public Class1695.Delegate964 delegate964_0;

	public Class1695.Delegate966 delegate966_0;

	public Class1641.Delegate802 delegate802_0;

	public Class1641.Delegate804 delegate804_0;

	public Class1678.Delegate913 delegate913_0;

	public Class1678.Delegate915 delegate915_0;

	public Class1371.Delegate75 delegate75_0;

	public Class1371.Delegate77 delegate77_0;

	public Class1706.Delegate997 delegate997_0;

	public Class1706.Delegate999 delegate999_0;

	public Class1476.Delegate305 delegate305_0;

	public Class1476.Delegate307 delegate307_0;

	public Class1443.Delegate291 delegate291_0;

	public Class1443.Delegate293 delegate293_0;

	public Class1581.Delegate622 delegate622_0;

	public Class1581.Delegate624 delegate624_0;

	public Class1619.Delegate736 delegate736_0;

	public Class1619.Delegate738 delegate738_0;

	public Class1429.Delegate249 delegate249_0;

	public Class1429.Delegate250 delegate250_0;

	public Class1482.Delegate323 delegate323_0;

	public Class1482.Delegate325 delegate325_0;

	public Class1549.Delegate526 delegate526_0;

	public Class1549.Delegate528 delegate528_0;

	public Class1639.Delegate796 delegate796_0;

	public Class1639.Delegate798 delegate798_0;

	public Class1607.Delegate700 delegate700_0;

	public Class1607.Delegate702 delegate702_0;

	public Class1609.Delegate706 delegate706_0;

	public Class1609.Delegate708 delegate708_0;

	public Class1546.Delegate517 delegate517_0;

	public Class1546.Delegate519 delegate519_0;

	public Class1603.Delegate688 delegate688_0;

	public Class1603.Delegate690 delegate690_0;

	public Class1603.Delegate688 delegate688_1;

	public Class1603.Delegate690 delegate690_1;

	public Class1440.Delegate282 delegate282_0;

	public Class1440.Delegate284 delegate284_0;

	public Class1404.Delegate174 delegate174_0;

	public Class1404.Delegate176 delegate176_0;

	public Class1554.Delegate541 delegate541_0;

	public Class1554.Delegate543 delegate543_0;

	public Class1702.Delegate985 delegate985_0;

	public Class1702.Delegate987 delegate987_0;

	public Class1497.Delegate368 delegate368_0;

	public Class1497.Delegate370 delegate370_0;

	public Class1561.Delegate562 delegate562_0;

	public Class1561.Delegate564 delegate564_0;

	public Class1561.Delegate562 delegate562_1;

	public Class1561.Delegate564 delegate564_1;

	public Class1686.Delegate937 delegate937_0;

	public Class1686.Delegate939 delegate939_0;

	public Class1600.Delegate679 delegate679_0;

	public Class1600.Delegate681 delegate681_0;

	public Class1434.Delegate264 delegate264_0;

	public Class1434.Delegate266 delegate266_0;

	public Class1741.Delegate1102 delegate1102_0;

	public Class1741.Delegate1104 delegate1104_0;

	public Class1716.Delegate1027 delegate1027_0;

	public Class1716.Delegate1029 delegate1029_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private Class1694 class1694_0;

	private Class1689 class1689_0;

	private Class1698 class1698_0;

	private Class1691 class1691_0;

	private List<Class1423> list_0;

	private Class1688 class1688_0;

	private Class1687 class1687_0;

	private Class1695 class1695_0;

	private Class1641 class1641_0;

	private Class1678 class1678_0;

	private Class1371 class1371_0;

	private Class1706 class1706_0;

	private Class1476 class1476_0;

	private Class1443 class1443_0;

	private Class1581 class1581_0;

	private Class1619 class1619_0;

	private List<Class1429> list_1;

	private Class1482 class1482_0;

	private Class1549 class1549_0;

	private Class1639 class1639_0;

	private Class1607 class1607_0;

	private Class1609 class1609_0;

	private Class1546 class1546_0;

	private Class1603 class1603_0;

	private Class1603 class1603_1;

	private Class1440 class1440_0;

	private Class1404 class1404_0;

	private Class1554 class1554_0;

	private Class1702 class1702_0;

	private Class1497 class1497_0;

	private Class1561 class1561_0;

	private Class1561 class1561_1;

	private Class1686 class1686_0;

	private Class1600 class1600_0;

	private Class1434 class1434_0;

	private Class1741 class1741_0;

	private Class1716 class1716_0;

	private Class1502 class1502_0;

	public Class1694 SheetPr => class1694_0;

	public Class1689 Dimension => class1689_0;

	public Class1698 SheetViews => class1698_0;

	public Class1691 SheetFormatPr => class1691_0;

	public Class1423[] ColsList => list_0.ToArray();

	public Class1688 SheetData => class1688_0;

	public Class1687 SheetCalcPr => class1687_0;

	public Class1695 SheetProtection => class1695_0;

	public Class1641 ProtectedRanges => class1641_0;

	public Class1678 Scenarios => class1678_0;

	public Class1371 AutoFilter => class1371_0;

	public Class1706 SortState => class1706_0;

	public Class1476 DataConsolidate => class1476_0;

	public Class1443 CustomSheetViews => class1443_0;

	public Class1581 MergeCells => class1581_0;

	public Class1619 PhoneticPr => class1619_0;

	public Class1429[] ConditionalFormattingList => list_1.ToArray();

	public Class1482 DataValidations => class1482_0;

	public Class1549 Hyperlinks => class1549_0;

	public Class1639 PrintOptions => class1639_0;

	public Class1607 PageMargins => class1607_0;

	public Class1609 PageSetup => class1609_0;

	public Class1546 HeaderFooter => class1546_0;

	public Class1603 RowBreaks => class1603_0;

	public Class1603 ColBreaks => class1603_1;

	public Class1440 CustomProperties => class1440_0;

	public Class1404 CellWatches => class1404_0;

	public Class1554 IgnoredErrors => class1554_0;

	public Class1702 SmartTags => class1702_0;

	public Class1497 Drawing => class1497_0;

	public Class1561 LegacyDrawing => class1561_0;

	public Class1561 LegacyDrawingHF => class1561_1;

	public Class1686 Picture => class1686_0;

	public Class1600 OleObjects => class1600_0;

	public Class1434 Controls => class1434_0;

	public Class1741 WebPublishItems => class1741_0;

	public Class1716 TableParts => class1716_0;

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
				case "sheetPr":
					class1694_0 = new Class1694(reader);
					break;
				case "dimension":
					class1689_0 = new Class1689(reader);
					break;
				case "sheetViews":
					class1698_0 = new Class1698(reader);
					break;
				case "sheetFormatPr":
					class1691_0 = new Class1691(reader);
					break;
				case "cols":
				{
					Class1423 item2 = new Class1423(reader);
					list_0.Add(item2);
					break;
				}
				case "sheetData":
					class1688_0 = new Class1688(reader);
					break;
				case "sheetCalcPr":
					class1687_0 = new Class1687(reader);
					break;
				case "sheetProtection":
					class1695_0 = new Class1695(reader);
					break;
				case "protectedRanges":
					class1641_0 = new Class1641(reader);
					break;
				case "scenarios":
					class1678_0 = new Class1678(reader);
					break;
				case "autoFilter":
					class1371_0 = new Class1371(reader);
					break;
				case "sortState":
					class1706_0 = new Class1706(reader);
					break;
				case "dataConsolidate":
					class1476_0 = new Class1476(reader);
					break;
				case "customSheetViews":
					class1443_0 = new Class1443(reader);
					break;
				case "mergeCells":
					class1581_0 = new Class1581(reader);
					break;
				case "phoneticPr":
					class1619_0 = new Class1619(reader);
					break;
				case "conditionalFormatting":
				{
					Class1429 item = new Class1429(reader);
					list_1.Add(item);
					break;
				}
				case "dataValidations":
					class1482_0 = new Class1482(reader);
					break;
				case "hyperlinks":
					class1549_0 = new Class1549(reader);
					break;
				case "printOptions":
					class1639_0 = new Class1639(reader);
					break;
				case "pageMargins":
					class1607_0 = new Class1607(reader);
					break;
				case "pageSetup":
					class1609_0 = new Class1609(reader);
					break;
				case "headerFooter":
					class1546_0 = new Class1546(reader);
					break;
				case "rowBreaks":
					class1603_0 = new Class1603(reader);
					break;
				case "colBreaks":
					class1603_1 = new Class1603(reader);
					break;
				case "customProperties":
					class1440_0 = new Class1440(reader);
					break;
				case "cellWatches":
					class1404_0 = new Class1404(reader);
					break;
				case "ignoredErrors":
					class1554_0 = new Class1554(reader);
					break;
				case "smartTags":
					class1702_0 = new Class1702(reader);
					break;
				case "drawing":
					class1497_0 = new Class1497(reader);
					break;
				case "legacyDrawing":
					class1561_0 = new Class1561(reader);
					break;
				case "legacyDrawingHF":
					class1561_1 = new Class1561(reader);
					break;
				case "picture":
					class1686_0 = new Class1686(reader);
					break;
				case "oleObjects":
					class1600_0 = new Class1600(reader);
					break;
				case "controls":
					class1434_0 = new Class1434(reader);
					break;
				case "webPublishItems":
					class1741_0 = new Class1741(reader);
					break;
				case "tableParts":
					class1716_0 = new Class1716(reader);
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
	}

	public Class1747(XmlReader reader)
		: base(reader)
	{
	}

	public Class1747()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1423>();
		list_1 = new List<Class1429>();
	}

	protected override void vmethod_2()
	{
		delegate961_0 = method_3;
		delegate963_0 = method_4;
		delegate946_0 = method_5;
		delegate948_0 = method_6;
		delegate973_0 = method_7;
		delegate975_0 = method_8;
		delegate952_0 = method_9;
		delegate954_0 = method_10;
		delegate231_0 = method_11;
		delegate232_0 = method_12;
		delegate940_0 = method_13;
		delegate942_0 = method_14;
		delegate964_0 = method_15;
		delegate966_0 = method_16;
		delegate802_0 = method_17;
		delegate804_0 = method_18;
		delegate913_0 = method_19;
		delegate915_0 = method_20;
		delegate75_0 = method_21;
		delegate77_0 = method_22;
		delegate997_0 = method_23;
		delegate999_0 = method_24;
		delegate305_0 = method_25;
		delegate307_0 = method_26;
		delegate291_0 = method_27;
		delegate293_0 = method_28;
		delegate622_0 = method_29;
		delegate624_0 = method_30;
		delegate736_0 = method_31;
		delegate738_0 = method_32;
		delegate249_0 = method_33;
		delegate250_0 = method_34;
		delegate323_0 = method_35;
		delegate325_0 = method_36;
		delegate526_0 = method_37;
		delegate528_0 = method_38;
		delegate796_0 = method_39;
		delegate798_0 = method_40;
		delegate700_0 = method_41;
		delegate702_0 = method_42;
		delegate706_0 = method_43;
		delegate708_0 = method_44;
		delegate517_0 = method_45;
		delegate519_0 = method_46;
		delegate688_0 = method_47;
		delegate690_0 = method_48;
		delegate688_1 = method_49;
		delegate690_1 = method_50;
		delegate282_0 = method_51;
		delegate284_0 = method_52;
		delegate174_0 = method_53;
		delegate176_0 = method_54;
		delegate541_0 = method_55;
		delegate543_0 = method_56;
		delegate985_0 = method_57;
		delegate987_0 = method_58;
		delegate368_0 = method_59;
		delegate370_0 = method_60;
		delegate562_0 = method_61;
		delegate564_0 = method_62;
		delegate562_1 = method_63;
		delegate564_1 = method_64;
		delegate937_0 = method_65;
		delegate939_0 = method_66;
		delegate679_0 = method_67;
		delegate681_0 = method_68;
		delegate264_0 = method_69;
		delegate266_0 = method_70;
		delegate1102_0 = method_71;
		delegate1104_0 = method_72;
		delegate1027_0 = method_73;
		delegate1029_0 = method_74;
		delegate385_0 = method_75;
		delegate387_0 = method_76;
	}

	protected override void vmethod_3()
	{
		class1688_0 = new Class1688();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("ssml", elementName, "http://schemas.openxmlformats.org/spreadsheetml/2006/main");
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/officeDocument/2006/relationships") == null)
		{
			writer.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		}
		if (class1694_0 != null)
		{
			class1694_0.vmethod_4("ssml", writer, "sheetPr");
		}
		if (class1689_0 != null)
		{
			class1689_0.vmethod_4("ssml", writer, "dimension");
		}
		if (class1698_0 != null)
		{
			class1698_0.vmethod_4("ssml", writer, "sheetViews");
		}
		if (class1691_0 != null)
		{
			class1691_0.vmethod_4("ssml", writer, "sheetFormatPr");
		}
		foreach (Class1423 item in list_0)
		{
			item.vmethod_4("ssml", writer, "cols");
		}
		class1688_0.vmethod_4("ssml", writer, "sheetData");
		if (class1687_0 != null)
		{
			class1687_0.vmethod_4("ssml", writer, "sheetCalcPr");
		}
		if (class1695_0 != null)
		{
			class1695_0.vmethod_4("ssml", writer, "sheetProtection");
		}
		if (class1641_0 != null)
		{
			class1641_0.vmethod_4("ssml", writer, "protectedRanges");
		}
		if (class1678_0 != null)
		{
			class1678_0.vmethod_4("ssml", writer, "scenarios");
		}
		if (class1371_0 != null)
		{
			class1371_0.vmethod_4("ssml", writer, "autoFilter");
		}
		if (class1706_0 != null)
		{
			class1706_0.vmethod_4("ssml", writer, "sortState");
		}
		if (class1476_0 != null)
		{
			class1476_0.vmethod_4("ssml", writer, "dataConsolidate");
		}
		if (class1443_0 != null)
		{
			class1443_0.vmethod_4("ssml", writer, "customSheetViews");
		}
		if (class1581_0 != null)
		{
			class1581_0.vmethod_4("ssml", writer, "mergeCells");
		}
		if (class1619_0 != null)
		{
			class1619_0.vmethod_4("ssml", writer, "phoneticPr");
		}
		foreach (Class1429 item2 in list_1)
		{
			item2.vmethod_4("ssml", writer, "conditionalFormatting");
		}
		if (class1482_0 != null)
		{
			class1482_0.vmethod_4("ssml", writer, "dataValidations");
		}
		if (class1549_0 != null)
		{
			class1549_0.vmethod_4("ssml", writer, "hyperlinks");
		}
		if (class1639_0 != null)
		{
			class1639_0.vmethod_4("ssml", writer, "printOptions");
		}
		if (class1607_0 != null)
		{
			class1607_0.vmethod_4("ssml", writer, "pageMargins");
		}
		if (class1609_0 != null)
		{
			class1609_0.vmethod_4("ssml", writer, "pageSetup");
		}
		if (class1546_0 != null)
		{
			class1546_0.vmethod_4("ssml", writer, "headerFooter");
		}
		if (class1603_0 != null)
		{
			class1603_0.vmethod_4("ssml", writer, "rowBreaks");
		}
		if (class1603_1 != null)
		{
			class1603_1.vmethod_4("ssml", writer, "colBreaks");
		}
		if (class1440_0 != null)
		{
			class1440_0.vmethod_4("ssml", writer, "customProperties");
		}
		if (class1404_0 != null)
		{
			class1404_0.vmethod_4("ssml", writer, "cellWatches");
		}
		if (class1554_0 != null)
		{
			class1554_0.vmethod_4("ssml", writer, "ignoredErrors");
		}
		if (class1702_0 != null)
		{
			class1702_0.vmethod_4("ssml", writer, "smartTags");
		}
		if (class1497_0 != null)
		{
			class1497_0.vmethod_4("ssml", writer, "drawing");
		}
		if (class1561_0 != null)
		{
			class1561_0.vmethod_4("ssml", writer, "legacyDrawing");
		}
		if (class1561_1 != null)
		{
			class1561_1.vmethod_4("ssml", writer, "legacyDrawingHF");
		}
		if (class1686_0 != null)
		{
			class1686_0.vmethod_4("ssml", writer, "picture");
		}
		if (class1600_0 != null)
		{
			class1600_0.vmethod_4("ssml", writer, "oleObjects");
		}
		if (class1434_0 != null)
		{
			class1434_0.vmethod_4("ssml", writer, "controls");
		}
		if (class1741_0 != null)
		{
			class1741_0.vmethod_4("ssml", writer, "webPublishItems");
		}
		if (class1716_0 != null)
		{
			class1716_0.vmethod_4("ssml", writer, "tableParts");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1694 method_3()
	{
		if (class1694_0 != null)
		{
			throw new Exception("Only one <sheetPr> element can be added.");
		}
		class1694_0 = new Class1694();
		return class1694_0;
	}

	private void method_4(Class1694 _sheetPr)
	{
		class1694_0 = _sheetPr;
	}

	private Class1689 method_5()
	{
		if (class1689_0 != null)
		{
			throw new Exception("Only one <dimension> element can be added.");
		}
		class1689_0 = new Class1689();
		return class1689_0;
	}

	private void method_6(Class1689 _dimension)
	{
		class1689_0 = _dimension;
	}

	private Class1698 method_7()
	{
		if (class1698_0 != null)
		{
			throw new Exception("Only one <sheetViews> element can be added.");
		}
		class1698_0 = new Class1698();
		return class1698_0;
	}

	private void method_8(Class1698 _sheetViews)
	{
		class1698_0 = _sheetViews;
	}

	private Class1691 method_9()
	{
		if (class1691_0 != null)
		{
			throw new Exception("Only one <sheetFormatPr> element can be added.");
		}
		class1691_0 = new Class1691();
		return class1691_0;
	}

	private void method_10(Class1691 _sheetFormatPr)
	{
		class1691_0 = _sheetFormatPr;
	}

	private Class1423 method_11()
	{
		Class1423 @class = new Class1423();
		list_0.Add(@class);
		return @class;
	}

	private void method_12(Class1423 elementData)
	{
		list_0.Add(elementData);
	}

	private Class1687 method_13()
	{
		if (class1687_0 != null)
		{
			throw new Exception("Only one <sheetCalcPr> element can be added.");
		}
		class1687_0 = new Class1687();
		return class1687_0;
	}

	private void method_14(Class1687 _sheetCalcPr)
	{
		class1687_0 = _sheetCalcPr;
	}

	private Class1695 method_15()
	{
		if (class1695_0 != null)
		{
			throw new Exception("Only one <sheetProtection> element can be added.");
		}
		class1695_0 = new Class1695();
		return class1695_0;
	}

	private void method_16(Class1695 _sheetProtection)
	{
		class1695_0 = _sheetProtection;
	}

	private Class1641 method_17()
	{
		if (class1641_0 != null)
		{
			throw new Exception("Only one <protectedRanges> element can be added.");
		}
		class1641_0 = new Class1641();
		return class1641_0;
	}

	private void method_18(Class1641 _protectedRanges)
	{
		class1641_0 = _protectedRanges;
	}

	private Class1678 method_19()
	{
		if (class1678_0 != null)
		{
			throw new Exception("Only one <scenarios> element can be added.");
		}
		class1678_0 = new Class1678();
		return class1678_0;
	}

	private void method_20(Class1678 _scenarios)
	{
		class1678_0 = _scenarios;
	}

	private Class1371 method_21()
	{
		if (class1371_0 != null)
		{
			throw new Exception("Only one <autoFilter> element can be added.");
		}
		class1371_0 = new Class1371();
		return class1371_0;
	}

	private void method_22(Class1371 _autoFilter)
	{
		class1371_0 = _autoFilter;
	}

	private Class1706 method_23()
	{
		if (class1706_0 != null)
		{
			throw new Exception("Only one <sortState> element can be added.");
		}
		class1706_0 = new Class1706();
		return class1706_0;
	}

	private void method_24(Class1706 _sortState)
	{
		class1706_0 = _sortState;
	}

	private Class1476 method_25()
	{
		if (class1476_0 != null)
		{
			throw new Exception("Only one <dataConsolidate> element can be added.");
		}
		class1476_0 = new Class1476();
		return class1476_0;
	}

	private void method_26(Class1476 _dataConsolidate)
	{
		class1476_0 = _dataConsolidate;
	}

	private Class1443 method_27()
	{
		if (class1443_0 != null)
		{
			throw new Exception("Only one <customSheetViews> element can be added.");
		}
		class1443_0 = new Class1443();
		return class1443_0;
	}

	private void method_28(Class1443 _customSheetViews)
	{
		class1443_0 = _customSheetViews;
	}

	private Class1581 method_29()
	{
		if (class1581_0 != null)
		{
			throw new Exception("Only one <mergeCells> element can be added.");
		}
		class1581_0 = new Class1581();
		return class1581_0;
	}

	private void method_30(Class1581 _mergeCells)
	{
		class1581_0 = _mergeCells;
	}

	private Class1619 method_31()
	{
		if (class1619_0 != null)
		{
			throw new Exception("Only one <phoneticPr> element can be added.");
		}
		class1619_0 = new Class1619();
		return class1619_0;
	}

	private void method_32(Class1619 _phoneticPr)
	{
		class1619_0 = _phoneticPr;
	}

	private Class1429 method_33()
	{
		Class1429 @class = new Class1429();
		list_1.Add(@class);
		return @class;
	}

	private void method_34(Class1429 elementData)
	{
		list_1.Add(elementData);
	}

	private Class1482 method_35()
	{
		if (class1482_0 != null)
		{
			throw new Exception("Only one <dataValidations> element can be added.");
		}
		class1482_0 = new Class1482();
		return class1482_0;
	}

	private void method_36(Class1482 _dataValidations)
	{
		class1482_0 = _dataValidations;
	}

	private Class1549 method_37()
	{
		if (class1549_0 != null)
		{
			throw new Exception("Only one <hyperlinks> element can be added.");
		}
		class1549_0 = new Class1549();
		return class1549_0;
	}

	private void method_38(Class1549 _hyperlinks)
	{
		class1549_0 = _hyperlinks;
	}

	private Class1639 method_39()
	{
		if (class1639_0 != null)
		{
			throw new Exception("Only one <printOptions> element can be added.");
		}
		class1639_0 = new Class1639();
		return class1639_0;
	}

	private void method_40(Class1639 _printOptions)
	{
		class1639_0 = _printOptions;
	}

	private Class1607 method_41()
	{
		if (class1607_0 != null)
		{
			throw new Exception("Only one <pageMargins> element can be added.");
		}
		class1607_0 = new Class1607();
		return class1607_0;
	}

	private void method_42(Class1607 _pageMargins)
	{
		class1607_0 = _pageMargins;
	}

	private Class1609 method_43()
	{
		if (class1609_0 != null)
		{
			throw new Exception("Only one <pageSetup> element can be added.");
		}
		class1609_0 = new Class1609();
		return class1609_0;
	}

	private void method_44(Class1609 _pageSetup)
	{
		class1609_0 = _pageSetup;
	}

	private Class1546 method_45()
	{
		if (class1546_0 != null)
		{
			throw new Exception("Only one <headerFooter> element can be added.");
		}
		class1546_0 = new Class1546();
		return class1546_0;
	}

	private void method_46(Class1546 _headerFooter)
	{
		class1546_0 = _headerFooter;
	}

	private Class1603 method_47()
	{
		if (class1603_0 != null)
		{
			throw new Exception("Only one <rowBreaks> element can be added.");
		}
		class1603_0 = new Class1603();
		return class1603_0;
	}

	private void method_48(Class1603 _rowBreaks)
	{
		class1603_0 = _rowBreaks;
	}

	private Class1603 method_49()
	{
		if (class1603_1 != null)
		{
			throw new Exception("Only one <colBreaks> element can be added.");
		}
		class1603_1 = new Class1603();
		return class1603_1;
	}

	private void method_50(Class1603 _colBreaks)
	{
		class1603_1 = _colBreaks;
	}

	private Class1440 method_51()
	{
		if (class1440_0 != null)
		{
			throw new Exception("Only one <customProperties> element can be added.");
		}
		class1440_0 = new Class1440();
		return class1440_0;
	}

	private void method_52(Class1440 _customProperties)
	{
		class1440_0 = _customProperties;
	}

	private Class1404 method_53()
	{
		if (class1404_0 != null)
		{
			throw new Exception("Only one <cellWatches> element can be added.");
		}
		class1404_0 = new Class1404();
		return class1404_0;
	}

	private void method_54(Class1404 _cellWatches)
	{
		class1404_0 = _cellWatches;
	}

	private Class1554 method_55()
	{
		if (class1554_0 != null)
		{
			throw new Exception("Only one <ignoredErrors> element can be added.");
		}
		class1554_0 = new Class1554();
		return class1554_0;
	}

	private void method_56(Class1554 _ignoredErrors)
	{
		class1554_0 = _ignoredErrors;
	}

	private Class1702 method_57()
	{
		if (class1702_0 != null)
		{
			throw new Exception("Only one <smartTags> element can be added.");
		}
		class1702_0 = new Class1702();
		return class1702_0;
	}

	private void method_58(Class1702 _smartTags)
	{
		class1702_0 = _smartTags;
	}

	private Class1497 method_59()
	{
		if (class1497_0 != null)
		{
			throw new Exception("Only one <drawing> element can be added.");
		}
		class1497_0 = new Class1497();
		return class1497_0;
	}

	private void method_60(Class1497 _drawing)
	{
		class1497_0 = _drawing;
	}

	private Class1561 method_61()
	{
		if (class1561_0 != null)
		{
			throw new Exception("Only one <legacyDrawing> element can be added.");
		}
		class1561_0 = new Class1561();
		return class1561_0;
	}

	private void method_62(Class1561 _legacyDrawing)
	{
		class1561_0 = _legacyDrawing;
	}

	private Class1561 method_63()
	{
		if (class1561_1 != null)
		{
			throw new Exception("Only one <legacyDrawingHF> element can be added.");
		}
		class1561_1 = new Class1561();
		return class1561_1;
	}

	private void method_64(Class1561 _legacyDrawingHF)
	{
		class1561_1 = _legacyDrawingHF;
	}

	private Class1686 method_65()
	{
		if (class1686_0 != null)
		{
			throw new Exception("Only one <picture> element can be added.");
		}
		class1686_0 = new Class1686();
		return class1686_0;
	}

	private void method_66(Class1686 _picture)
	{
		class1686_0 = _picture;
	}

	private Class1600 method_67()
	{
		if (class1600_0 != null)
		{
			throw new Exception("Only one <oleObjects> element can be added.");
		}
		class1600_0 = new Class1600();
		return class1600_0;
	}

	private void method_68(Class1600 _oleObjects)
	{
		class1600_0 = _oleObjects;
	}

	private Class1434 method_69()
	{
		if (class1434_0 != null)
		{
			throw new Exception("Only one <controls> element can be added.");
		}
		class1434_0 = new Class1434();
		return class1434_0;
	}

	private void method_70(Class1434 _controls)
	{
		class1434_0 = _controls;
	}

	private Class1741 method_71()
	{
		if (class1741_0 != null)
		{
			throw new Exception("Only one <webPublishItems> element can be added.");
		}
		class1741_0 = new Class1741();
		return class1741_0;
	}

	private void method_72(Class1741 _webPublishItems)
	{
		class1741_0 = _webPublishItems;
	}

	private Class1716 method_73()
	{
		if (class1716_0 != null)
		{
			throw new Exception("Only one <tableParts> element can be added.");
		}
		class1716_0 = new Class1716();
		return class1716_0;
	}

	private void method_74(Class1716 _tableParts)
	{
		class1716_0 = _tableParts;
	}

	private Class1502 method_75()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_76(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
