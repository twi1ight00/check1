using System;
using System.Xml;

namespace ns56;

internal class Class1494 : Class1351
{
	public delegate Class1494 Delegate359();

	public delegate void Delegate360(Class1494 elementData);

	public delegate void Delegate361(Class1494 elementData);

	public Class1694.Delegate961 delegate961_0;

	public Class1694.Delegate963 delegate963_0;

	public Class1698.Delegate973 delegate973_0;

	public Class1698.Delegate975 delegate975_0;

	public Class1691.Delegate952 delegate952_0;

	public Class1691.Delegate954 delegate954_0;

	public Class1695.Delegate964 delegate964_0;

	public Class1695.Delegate966 delegate966_0;

	public Class1443.Delegate291 delegate291_0;

	public Class1443.Delegate293 delegate293_0;

	public Class1639.Delegate796 delegate796_0;

	public Class1639.Delegate798 delegate798_0;

	public Class1607.Delegate700 delegate700_0;

	public Class1607.Delegate702 delegate702_0;

	public Class1609.Delegate706 delegate706_0;

	public Class1609.Delegate708 delegate708_0;

	public Class1546.Delegate517 delegate517_0;

	public Class1546.Delegate519 delegate519_0;

	public Class1497.Delegate368 delegate368_0;

	public Class1497.Delegate370 delegate370_0;

	public Class1561.Delegate562 delegate562_0;

	public Class1561.Delegate564 delegate564_0;

	public Class1561.Delegate562 delegate562_1;

	public Class1561.Delegate564 delegate564_1;

	public Class1600.Delegate679 delegate679_0;

	public Class1600.Delegate681 delegate681_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private Class1694 class1694_0;

	private Class1698 class1698_0;

	private Class1691 class1691_0;

	private Class1695 class1695_0;

	private Class1443 class1443_0;

	private Class1639 class1639_0;

	private Class1607 class1607_0;

	private Class1609 class1609_0;

	private Class1546 class1546_0;

	private Class1497 class1497_0;

	private Class1561 class1561_0;

	private Class1561 class1561_1;

	private Class1600 class1600_0;

	private Class1502 class1502_0;

	public Class1694 SheetPr => class1694_0;

	public Class1698 SheetViews => class1698_0;

	public Class1691 SheetFormatPr => class1691_0;

	public Class1695 SheetProtection => class1695_0;

	public Class1443 CustomSheetViews => class1443_0;

	public Class1639 PrintOptions => class1639_0;

	public Class1607 PageMargins => class1607_0;

	public Class1609 PageSetup => class1609_0;

	public Class1546 HeaderFooter => class1546_0;

	public Class1497 Drawing => class1497_0;

	public Class1561 LegacyDrawing => class1561_0;

	public Class1561 LegacyDrawingHF => class1561_1;

	public Class1600 OleObjects => class1600_0;

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
				case "sheetViews":
					class1698_0 = new Class1698(reader);
					break;
				case "sheetFormatPr":
					class1691_0 = new Class1691(reader);
					break;
				case "sheetProtection":
					class1695_0 = new Class1695(reader);
					break;
				case "customSheetViews":
					class1443_0 = new Class1443(reader);
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
				case "drawing":
					class1497_0 = new Class1497(reader);
					break;
				case "legacyDrawing":
					class1561_0 = new Class1561(reader);
					break;
				case "legacyDrawingHF":
					class1561_1 = new Class1561(reader);
					break;
				case "oleObjects":
					class1600_0 = new Class1600(reader);
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

	public Class1494(XmlReader reader)
		: base(reader)
	{
	}

	public Class1494()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate961_0 = method_3;
		delegate963_0 = method_4;
		delegate973_0 = method_5;
		delegate975_0 = method_6;
		delegate952_0 = method_7;
		delegate954_0 = method_8;
		delegate964_0 = method_9;
		delegate966_0 = method_10;
		delegate291_0 = method_11;
		delegate293_0 = method_12;
		delegate796_0 = method_13;
		delegate798_0 = method_14;
		delegate700_0 = method_15;
		delegate702_0 = method_16;
		delegate706_0 = method_17;
		delegate708_0 = method_18;
		delegate517_0 = method_19;
		delegate519_0 = method_20;
		delegate368_0 = method_21;
		delegate370_0 = method_22;
		delegate562_0 = method_23;
		delegate564_0 = method_24;
		delegate562_1 = method_25;
		delegate564_1 = method_26;
		delegate679_0 = method_27;
		delegate681_0 = method_28;
		delegate385_0 = method_29;
		delegate387_0 = method_30;
	}

	protected override void vmethod_3()
	{
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
		if (class1698_0 != null)
		{
			class1698_0.vmethod_4("ssml", writer, "sheetViews");
		}
		if (class1691_0 != null)
		{
			class1691_0.vmethod_4("ssml", writer, "sheetFormatPr");
		}
		if (class1695_0 != null)
		{
			class1695_0.vmethod_4("ssml", writer, "sheetProtection");
		}
		if (class1443_0 != null)
		{
			class1443_0.vmethod_4("ssml", writer, "customSheetViews");
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
		if (class1600_0 != null)
		{
			class1600_0.vmethod_4("ssml", writer, "oleObjects");
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

	private Class1698 method_5()
	{
		if (class1698_0 != null)
		{
			throw new Exception("Only one <sheetViews> element can be added.");
		}
		class1698_0 = new Class1698();
		return class1698_0;
	}

	private void method_6(Class1698 _sheetViews)
	{
		class1698_0 = _sheetViews;
	}

	private Class1691 method_7()
	{
		if (class1691_0 != null)
		{
			throw new Exception("Only one <sheetFormatPr> element can be added.");
		}
		class1691_0 = new Class1691();
		return class1691_0;
	}

	private void method_8(Class1691 _sheetFormatPr)
	{
		class1691_0 = _sheetFormatPr;
	}

	private Class1695 method_9()
	{
		if (class1695_0 != null)
		{
			throw new Exception("Only one <sheetProtection> element can be added.");
		}
		class1695_0 = new Class1695();
		return class1695_0;
	}

	private void method_10(Class1695 _sheetProtection)
	{
		class1695_0 = _sheetProtection;
	}

	private Class1443 method_11()
	{
		if (class1443_0 != null)
		{
			throw new Exception("Only one <customSheetViews> element can be added.");
		}
		class1443_0 = new Class1443();
		return class1443_0;
	}

	private void method_12(Class1443 _customSheetViews)
	{
		class1443_0 = _customSheetViews;
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

	private Class1607 method_15()
	{
		if (class1607_0 != null)
		{
			throw new Exception("Only one <pageMargins> element can be added.");
		}
		class1607_0 = new Class1607();
		return class1607_0;
	}

	private void method_16(Class1607 _pageMargins)
	{
		class1607_0 = _pageMargins;
	}

	private Class1609 method_17()
	{
		if (class1609_0 != null)
		{
			throw new Exception("Only one <pageSetup> element can be added.");
		}
		class1609_0 = new Class1609();
		return class1609_0;
	}

	private void method_18(Class1609 _pageSetup)
	{
		class1609_0 = _pageSetup;
	}

	private Class1546 method_19()
	{
		if (class1546_0 != null)
		{
			throw new Exception("Only one <headerFooter> element can be added.");
		}
		class1546_0 = new Class1546();
		return class1546_0;
	}

	private void method_20(Class1546 _headerFooter)
	{
		class1546_0 = _headerFooter;
	}

	private Class1497 method_21()
	{
		if (class1497_0 != null)
		{
			throw new Exception("Only one <drawing> element can be added.");
		}
		class1497_0 = new Class1497();
		return class1497_0;
	}

	private void method_22(Class1497 _drawing)
	{
		class1497_0 = _drawing;
	}

	private Class1561 method_23()
	{
		if (class1561_0 != null)
		{
			throw new Exception("Only one <legacyDrawing> element can be added.");
		}
		class1561_0 = new Class1561();
		return class1561_0;
	}

	private void method_24(Class1561 _legacyDrawing)
	{
		class1561_0 = _legacyDrawing;
	}

	private Class1561 method_25()
	{
		if (class1561_1 != null)
		{
			throw new Exception("Only one <legacyDrawingHF> element can be added.");
		}
		class1561_1 = new Class1561();
		return class1561_1;
	}

	private void method_26(Class1561 _legacyDrawingHF)
	{
		class1561_1 = _legacyDrawingHF;
	}

	private Class1600 method_27()
	{
		if (class1600_0 != null)
		{
			throw new Exception("Only one <oleObjects> element can be added.");
		}
		class1600_0 = new Class1600();
		return class1600_0;
	}

	private void method_28(Class1600 _oleObjects)
	{
		class1600_0 = _oleObjects;
	}

	private Class1502 method_29()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_30(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
