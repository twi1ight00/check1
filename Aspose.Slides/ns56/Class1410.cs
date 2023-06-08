using System;
using System.Xml;

namespace ns56;

internal class Class1410 : Class1351
{
	public delegate Class1410 Delegate192();

	public delegate void Delegate193(Class1410 elementData);

	public delegate void Delegate194(Class1410 elementData);

	public Class1411.Delegate195 delegate195_0;

	public Class1411.Delegate197 delegate197_0;

	public Class1412.Delegate198 delegate198_0;

	public Class1412.Delegate200 delegate200_0;

	public Class1437.Delegate273 delegate273_0;

	public Class1437.Delegate275 delegate275_0;

	public Class1607.Delegate700 delegate700_0;

	public Class1607.Delegate702 delegate702_0;

	public Class1435.Delegate267 delegate267_0;

	public Class1435.Delegate269 delegate269_0;

	public Class1546.Delegate517 delegate517_0;

	public Class1546.Delegate519 delegate519_0;

	public Class1561.Delegate562 delegate562_0;

	public Class1561.Delegate564 delegate564_0;

	public Class1561.Delegate562 delegate562_1;

	public Class1561.Delegate564 delegate564_1;

	public Class1686.Delegate937 delegate937_0;

	public Class1686.Delegate939 delegate939_0;

	public Class1741.Delegate1102 delegate1102_0;

	public Class1741.Delegate1104 delegate1104_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private Class1411 class1411_0;

	private Class1414 class1414_0;

	private Class1412 class1412_0;

	private Class1437 class1437_0;

	private Class1607 class1607_0;

	private Class1435 class1435_0;

	private Class1546 class1546_0;

	private Class1497 class1497_0;

	private Class1561 class1561_0;

	private Class1561 class1561_1;

	private Class1686 class1686_0;

	private Class1741 class1741_0;

	private Class1502 class1502_0;

	public Class1411 SheetPr => class1411_0;

	public Class1414 SheetViews => class1414_0;

	public Class1412 SheetProtection => class1412_0;

	public Class1437 CustomSheetViews => class1437_0;

	public Class1607 PageMargins => class1607_0;

	public Class1435 PageSetup => class1435_0;

	public Class1546 HeaderFooter => class1546_0;

	public Class1497 Drawing => class1497_0;

	public Class1561 LegacyDrawing => class1561_0;

	public Class1561 LegacyDrawingHF => class1561_1;

	public Class1686 Picture => class1686_0;

	public Class1741 WebPublishItems => class1741_0;

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
					class1411_0 = new Class1411(reader);
					break;
				case "sheetViews":
					class1414_0 = new Class1414(reader);
					break;
				case "sheetProtection":
					class1412_0 = new Class1412(reader);
					break;
				case "customSheetViews":
					class1437_0 = new Class1437(reader);
					break;
				case "pageMargins":
					class1607_0 = new Class1607(reader);
					break;
				case "pageSetup":
					class1435_0 = new Class1435(reader);
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
				case "picture":
					class1686_0 = new Class1686(reader);
					break;
				case "webPublishItems":
					class1741_0 = new Class1741(reader);
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

	public Class1410(XmlReader reader)
		: base(reader)
	{
	}

	public Class1410()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate195_0 = method_3;
		delegate197_0 = method_4;
		delegate198_0 = method_5;
		delegate200_0 = method_6;
		delegate273_0 = method_7;
		delegate275_0 = method_8;
		delegate700_0 = method_9;
		delegate702_0 = method_10;
		delegate267_0 = method_11;
		delegate269_0 = method_12;
		delegate517_0 = method_13;
		delegate519_0 = method_14;
		delegate562_0 = method_15;
		delegate564_0 = method_16;
		delegate562_1 = method_17;
		delegate564_1 = method_18;
		delegate937_0 = method_19;
		delegate939_0 = method_20;
		delegate1102_0 = method_21;
		delegate1104_0 = method_22;
		delegate385_0 = method_23;
		delegate387_0 = method_24;
	}

	protected override void vmethod_3()
	{
		class1414_0 = new Class1414();
		class1497_0 = new Class1497();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("ssml", elementName, "http://schemas.openxmlformats.org/spreadsheetml/2006/main");
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/officeDocument/2006/relationships") == null)
		{
			writer.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		}
		if (class1411_0 != null)
		{
			class1411_0.vmethod_4("ssml", writer, "sheetPr");
		}
		class1414_0.vmethod_4("ssml", writer, "sheetViews");
		if (class1412_0 != null)
		{
			class1412_0.vmethod_4("ssml", writer, "sheetProtection");
		}
		if (class1437_0 != null)
		{
			class1437_0.vmethod_4("ssml", writer, "customSheetViews");
		}
		if (class1607_0 != null)
		{
			class1607_0.vmethod_4("ssml", writer, "pageMargins");
		}
		if (class1435_0 != null)
		{
			class1435_0.vmethod_4("ssml", writer, "pageSetup");
		}
		if (class1546_0 != null)
		{
			class1546_0.vmethod_4("ssml", writer, "headerFooter");
		}
		class1497_0.vmethod_4("ssml", writer, "drawing");
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
		if (class1741_0 != null)
		{
			class1741_0.vmethod_4("ssml", writer, "webPublishItems");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1411 method_3()
	{
		if (class1411_0 != null)
		{
			throw new Exception("Only one <sheetPr> element can be added.");
		}
		class1411_0 = new Class1411();
		return class1411_0;
	}

	private void method_4(Class1411 _sheetPr)
	{
		class1411_0 = _sheetPr;
	}

	private Class1412 method_5()
	{
		if (class1412_0 != null)
		{
			throw new Exception("Only one <sheetProtection> element can be added.");
		}
		class1412_0 = new Class1412();
		return class1412_0;
	}

	private void method_6(Class1412 _sheetProtection)
	{
		class1412_0 = _sheetProtection;
	}

	private Class1437 method_7()
	{
		if (class1437_0 != null)
		{
			throw new Exception("Only one <customSheetViews> element can be added.");
		}
		class1437_0 = new Class1437();
		return class1437_0;
	}

	private void method_8(Class1437 _customSheetViews)
	{
		class1437_0 = _customSheetViews;
	}

	private Class1607 method_9()
	{
		if (class1607_0 != null)
		{
			throw new Exception("Only one <pageMargins> element can be added.");
		}
		class1607_0 = new Class1607();
		return class1607_0;
	}

	private void method_10(Class1607 _pageMargins)
	{
		class1607_0 = _pageMargins;
	}

	private Class1435 method_11()
	{
		if (class1435_0 != null)
		{
			throw new Exception("Only one <pageSetup> element can be added.");
		}
		class1435_0 = new Class1435();
		return class1435_0;
	}

	private void method_12(Class1435 _pageSetup)
	{
		class1435_0 = _pageSetup;
	}

	private Class1546 method_13()
	{
		if (class1546_0 != null)
		{
			throw new Exception("Only one <headerFooter> element can be added.");
		}
		class1546_0 = new Class1546();
		return class1546_0;
	}

	private void method_14(Class1546 _headerFooter)
	{
		class1546_0 = _headerFooter;
	}

	private Class1561 method_15()
	{
		if (class1561_0 != null)
		{
			throw new Exception("Only one <legacyDrawing> element can be added.");
		}
		class1561_0 = new Class1561();
		return class1561_0;
	}

	private void method_16(Class1561 _legacyDrawing)
	{
		class1561_0 = _legacyDrawing;
	}

	private Class1561 method_17()
	{
		if (class1561_1 != null)
		{
			throw new Exception("Only one <legacyDrawingHF> element can be added.");
		}
		class1561_1 = new Class1561();
		return class1561_1;
	}

	private void method_18(Class1561 _legacyDrawingHF)
	{
		class1561_1 = _legacyDrawingHF;
	}

	private Class1686 method_19()
	{
		if (class1686_0 != null)
		{
			throw new Exception("Only one <picture> element can be added.");
		}
		class1686_0 = new Class1686();
		return class1686_0;
	}

	private void method_20(Class1686 _picture)
	{
		class1686_0 = _picture;
	}

	private Class1741 method_21()
	{
		if (class1741_0 != null)
		{
			throw new Exception("Only one <webPublishItems> element can be added.");
		}
		class1741_0 = new Class1741();
		return class1741_0;
	}

	private void method_22(Class1741 _webPublishItems)
	{
		class1741_0 = _webPublishItems;
	}

	private Class1502 method_23()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_24(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
