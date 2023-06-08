using System.Collections;
using System.Drawing;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Tables;
using ns2;
using ns22;
using ns27;

namespace ns16;

internal class Class1590
{
	private Workbook workbook_0;

	private Class1536 class1536_0;

	private Class1539 class1539_0;

	internal Class1590(Workbook workbook_1, Class1539 class1539_1)
	{
		workbook_0 = workbook_1;
		class1539_0 = class1539_1;
	}

	internal void Write(XmlTextWriter xmlTextWriter_0)
	{
		class1536_0 = Class1536.smethod_0(workbook_0);
		xmlTextWriter_0.WriteStartDocument(standalone: true);
		xmlTextWriter_0.WriteStartElement("styleSheet");
		method_0(xmlTextWriter_0);
		method_6(xmlTextWriter_0);
		method_7(xmlTextWriter_0);
		method_8(xmlTextWriter_0, class1539_0);
		method_11(xmlTextWriter_0, class1539_0);
		method_13(xmlTextWriter_0, class1539_0);
		method_14(xmlTextWriter_0, class1539_0);
		method_12(xmlTextWriter_0, class1539_0);
		method_20(xmlTextWriter_0);
		method_2(xmlTextWriter_0);
		method_4(xmlTextWriter_0);
		method_1(xmlTextWriter_0);
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
	}

	[Attribute0(true)]
	private void method_0(XmlTextWriter xmlTextWriter_0)
	{
		if (Class1618.bool_0)
		{
			xmlTextWriter_0.WriteAttributeString("xmlns", Class1618.string_0);
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("xmlns", Class1618.string_1);
		}
		if (workbook_0.class1558_0 == null)
		{
			return;
		}
		object obj = workbook_0.class1558_0.class1363_0.method_0(Enum129.const_3);
		if (obj == null)
		{
			return;
		}
		foreach (object item in (ArrayList)obj)
		{
			Class927 @class = (Class927)item;
			xmlTextWriter_0.WriteAttributeString(@class.string_0, @class.string_1);
		}
	}

	[Attribute0(true)]
	private void method_1(XmlTextWriter xmlTextWriter_0)
	{
		if (workbook_0.class1558_0 != null)
		{
			object obj = workbook_0.class1558_0.class1363_0.method_0(Enum129.const_4);
			if (obj != null)
			{
				xmlTextWriter_0.WriteRaw((string)obj);
			}
		}
	}

	[Attribute0(true)]
	private void method_2(XmlTextWriter xmlTextWriter_0)
	{
		TableStyleCollection tableStyleCollection = workbook_0.Worksheets.method_91();
		if (tableStyleCollection != null)
		{
			int count = tableStyleCollection.Count;
			xmlTextWriter_0.WriteStartElement("tableStyles");
			xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(count));
			string text = tableStyleCollection.method_0();
			if (text != null)
			{
				xmlTextWriter_0.WriteAttributeString("defaultTableStyle", tableStyleCollection.method_0());
			}
			if (tableStyleCollection.method_2() != null)
			{
				xmlTextWriter_0.WriteAttributeString("defaultPivotStyle", tableStyleCollection.method_2());
			}
			for (int i = 0; i < count; i++)
			{
				TableStyle tableStyle_ = tableStyleCollection[i];
				method_3(tableStyle_, xmlTextWriter_0);
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_3(TableStyle tableStyle_0, XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("tableStyle");
		xmlTextWriter_0.WriteAttributeString("name", tableStyle_0.Name);
		if (!tableStyle_0.method_2())
		{
			xmlTextWriter_0.WriteAttributeString("pivot", "0");
		}
		if (!tableStyle_0.method_4())
		{
			xmlTextWriter_0.WriteAttributeString("table", "0");
		}
		TableStyleElementCollection tableStyleElements = tableStyle_0.TableStyleElements;
		if (tableStyleElements != null && tableStyleElements.Count != 0)
		{
			int count = tableStyleElements.Count;
			xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(count));
			for (int i = 0; i < count; i++)
			{
				TableStyleElement tableStyleElement = tableStyleElements[i];
				TableStyleElementType tableStyleElementType = tableStyleElement.Type;
				if (tableStyle_0.method_2() || !tableStyle_0.method_4())
				{
					switch (tableStyleElementType)
					{
					case TableStyleElementType.GrandTotalColumn:
						tableStyleElementType = TableStyleElementType.LastColumn;
						break;
					case TableStyleElementType.GrandTotalRow:
						tableStyleElementType = TableStyleElementType.TotalRow;
						break;
					}
				}
				xmlTextWriter_0.WriteStartElement("tableStyleElement");
				xmlTextWriter_0.WriteAttributeString("type", Class1618.smethod_211(tableStyleElementType));
				if (tableStyleElement.Size != 1)
				{
					xmlTextWriter_0.WriteAttributeString("size", Class1618.smethod_80(tableStyleElement.Size));
				}
				if (tableStyleElement.int_1 != -1)
				{
					xmlTextWriter_0.WriteAttributeString("dxfId", Class1618.smethod_80(tableStyleElement.int_1));
				}
				xmlTextWriter_0.WriteEndElement();
			}
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_4(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("colors");
		xmlTextWriter_0.WriteStartElement("indexedColors");
		method_5(xmlTextWriter_0, 0, 64);
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_5(XmlTextWriter xmlTextWriter_0, int int_0, int int_1)
	{
		for (int i = int_0; i < int_1; i++)
		{
			int int_2 = workbook_0.Worksheets.method_24().method_7(i).ToArgb();
			string value = "00" + Class1025.smethod_7(int_2).Substring(2);
			xmlTextWriter_0.WriteStartElement("rgbColor");
			xmlTextWriter_0.WriteAttributeString("rgb", value);
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_6(XmlTextWriter xmlTextWriter_0)
	{
		ArrayList arrayList = workbook_0.Worksheets.method_55();
		int count = arrayList.Count;
		if (count == 0)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("numFmts");
		xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(count));
		foreach (Class639 item in arrayList)
		{
			xmlTextWriter_0.WriteStartElement("numFmt");
			xmlTextWriter_0.WriteAttributeString("numFmtId", Class1618.smethod_80(item.Index));
			xmlTextWriter_0.WriteAttributeString("formatCode", item.Custom);
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	internal static void smethod_0(Aspose.Cells.Font font_0, XmlTextWriter xmlTextWriter_0, string string_0)
	{
		if (font_0.IsBold)
		{
			xmlTextWriter_0.WriteElementString("b", null);
		}
		if (font_0.IsItalic)
		{
			xmlTextWriter_0.WriteElementString("i", null);
		}
		if (font_0.Underline != 0)
		{
			xmlTextWriter_0.WriteStartElement("u");
			xmlTextWriter_0.WriteAttributeString("val", Class1618.smethod_9(font_0.Underline));
			xmlTextWriter_0.WriteEndElement();
		}
		if (font_0.IsStrikeout)
		{
			xmlTextWriter_0.WriteElementString("strike", null);
		}
		if (font_0.IsSubscript || font_0.IsSuperscript)
		{
			string value = null;
			if (font_0.IsSubscript)
			{
				value = "subscript";
			}
			if (font_0.IsSuperscript)
			{
				value = "superscript";
			}
			xmlTextWriter_0.WriteStartElement("vertAlign");
			xmlTextWriter_0.WriteAttributeString("val", value);
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteStartElement("sz");
		xmlTextWriter_0.WriteAttributeString("val", Class1618.smethod_79(font_0.DoubleSize));
		xmlTextWriter_0.WriteEndElement();
		if (!font_0.InternalColor.method_2())
		{
			smethod_1(xmlTextWriter_0, font_0.InternalColor, "color");
		}
		if (font_0.Name != null)
		{
			xmlTextWriter_0.WriteStartElement(string_0);
			xmlTextWriter_0.WriteAttributeString("val", Class1618.smethod_4(font_0.Name));
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteStartElement("family");
		xmlTextWriter_0.WriteAttributeString("val", Class1618.smethod_84(font_0.method_11()));
		xmlTextWriter_0.WriteEndElement();
		if (font_0.method_0() != null)
		{
			xmlTextWriter_0.WriteStartElement("scheme");
			xmlTextWriter_0.WriteAttributeString("val", font_0.method_0());
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_7(XmlTextWriter xmlTextWriter_0)
	{
		ArrayList arrayList_ = class1536_0.arrayList_0;
		xmlTextWriter_0.WriteStartElement("fonts");
		xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(arrayList_.Count));
		foreach (Aspose.Cells.Font item in arrayList_)
		{
			xmlTextWriter_0.WriteStartElement("font");
			smethod_0(item, xmlTextWriter_0, "name");
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_8(XmlTextWriter xmlTextWriter_0, Class1539 class1539_1)
	{
		ArrayList arrayList_ = class1539_1.arrayList_0;
		xmlTextWriter_0.WriteStartElement("fills");
		xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(arrayList_.Count));
		foreach (Class1535 item in arrayList_)
		{
			method_9(xmlTextWriter_0, item);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_9(XmlTextWriter xmlTextWriter_0, Class1535 class1535_0)
	{
		xmlTextWriter_0.WriteStartElement("fill");
		if (class1535_0.class1528_0 != null)
		{
			method_10(xmlTextWriter_0, class1535_0);
		}
		else
		{
			xmlTextWriter_0.WriteStartElement("patternFill");
			switch (class1535_0.class1561_0.string_0)
			{
			case "solid":
				xmlTextWriter_0.WriteAttributeString("patternType", "solid");
				smethod_1(xmlTextWriter_0, class1535_0.class1561_0.internalColor_0, "fgColor");
				xmlTextWriter_0.WriteStartElement("bgColor");
				xmlTextWriter_0.WriteAttributeString("indexed", "64");
				xmlTextWriter_0.WriteEndElement();
				break;
			default:
				xmlTextWriter_0.WriteAttributeString("patternType", class1535_0.class1561_0.string_0);
				if (!class1535_0.class1561_0.internalColor_0.method_2())
				{
					smethod_1(xmlTextWriter_0, class1535_0.class1561_0.internalColor_0, "fgColor");
				}
				if (!class1535_0.class1561_0.internalColor_1.method_2())
				{
					smethod_1(xmlTextWriter_0, class1535_0.class1561_0.internalColor_1, "bgColor");
				}
				break;
			case "none":
				break;
			}
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_10(XmlTextWriter xmlTextWriter_0, Class1535 class1535_0)
	{
		Class1528 class1528_ = class1535_0.class1528_0;
		xmlTextWriter_0.WriteStartElement("gradientFill");
		if (class1528_.int_0 != 0)
		{
			xmlTextWriter_0.WriteAttributeString("degree", Class1618.smethod_80(class1528_.int_0));
		}
		if (class1528_.string_0 != null)
		{
			xmlTextWriter_0.WriteAttributeString("type", class1528_.string_0);
		}
		if (class1528_.double_0 != 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("left", Class1618.smethod_79(class1528_.double_0));
		}
		if (class1528_.double_1 != 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("right", Class1618.smethod_79(class1528_.double_1));
		}
		if (class1528_.double_2 != 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("top", Class1618.smethod_79(class1528_.double_2));
		}
		if (class1528_.double_3 != 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("bottom", Class1618.smethod_79(class1528_.double_3));
		}
		if (class1528_.double_4 != null)
		{
			int num = class1528_.double_4.Length;
			for (int i = 0; i < num; i++)
			{
				xmlTextWriter_0.WriteStartElement("stop");
				xmlTextWriter_0.WriteAttributeString("position", Class1618.smethod_79(class1528_.double_4[i]));
				smethod_1(xmlTextWriter_0, class1528_.internalColor_0[i], "color");
				xmlTextWriter_0.WriteEndElement();
			}
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_11(XmlTextWriter xmlTextWriter_0, Class1539 class1539_1)
	{
		ArrayList arrayList_ = class1539_1.arrayList_1;
		xmlTextWriter_0.WriteStartElement("borders");
		xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(arrayList_.Count));
		foreach (Class1526 item in arrayList_)
		{
			xmlTextWriter_0.WriteStartElement("border");
			if (item.bool_1)
			{
				xmlTextWriter_0.WriteAttributeString("diagonalUp", "1");
			}
			if (item.bool_0)
			{
				xmlTextWriter_0.WriteAttributeString("diagonalDown", "1");
			}
			method_15(xmlTextWriter_0, item.class1527_1, "left");
			method_15(xmlTextWriter_0, item.class1527_3, "right");
			method_15(xmlTextWriter_0, item.class1527_0, "top");
			method_15(xmlTextWriter_0, item.class1527_2, "bottom");
			method_15(xmlTextWriter_0, item.class1527_4, "diagonal");
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_12(XmlTextWriter xmlTextWriter_0, Class1539 class1539_1)
	{
		ArrayList arrayList_ = class1539_1.arrayList_4;
		xmlTextWriter_0.WriteStartElement("cellStyles");
		xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(arrayList_.Count));
		foreach (Class1529 item in arrayList_)
		{
			xmlTextWriter_0.WriteStartElement("cellStyle");
			xmlTextWriter_0.WriteAttributeString("name", item.string_0);
			xmlTextWriter_0.WriteAttributeString("xfId", Class1618.smethod_80(item.int_0));
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_13(XmlTextWriter xmlTextWriter_0, Class1539 class1539_1)
	{
		ArrayList arrayList_ = class1539_1.arrayList_2;
		xmlTextWriter_0.WriteStartElement("cellStyleXfs");
		xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(arrayList_.Count));
		foreach (Class1571 item in arrayList_)
		{
			method_16(xmlTextWriter_0, item);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_14(XmlTextWriter xmlTextWriter_0, Class1539 class1539_1)
	{
		ArrayList arrayList_ = class1539_1.arrayList_3;
		xmlTextWriter_0.WriteStartElement("cellXfs");
		xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(arrayList_.Count));
		foreach (Class1571 item in arrayList_)
		{
			method_16(xmlTextWriter_0, item);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	internal static void smethod_1(XmlTextWriter xmlTextWriter_0, InternalColor internalColor_0, string string_0)
	{
		smethod_2(xmlTextWriter_0, internalColor_0, string_0, bool_0: false);
	}

	[Attribute0(true)]
	private static void smethod_2(XmlTextWriter xmlTextWriter_0, InternalColor internalColor_0, string string_0, bool bool_0)
	{
		if (internalColor_0.method_2() && internalColor_0.ColorType != ColorType.AutomaticIndex)
		{
			if (bool_0)
			{
				xmlTextWriter_0.WriteStartElement(string_0);
				xmlTextWriter_0.WriteAttributeString("auto", "1");
				xmlTextWriter_0.WriteEndElement();
			}
			return;
		}
		string localName = null;
		string value = null;
		switch (internalColor_0.ColorType)
		{
		case ColorType.RGB:
			localName = "rgb";
			value = "FF" + Class1618.smethod_64(Color.FromArgb(internalColor_0.method_4()));
			break;
		case ColorType.AutomaticIndex:
		case ColorType.IndexedColor:
			localName = "indexed";
			value = Class1618.smethod_80(internalColor_0.method_4());
			break;
		case ColorType.Theme:
			localName = "theme";
			value = Class1618.smethod_80(internalColor_0.method_4());
			break;
		}
		xmlTextWriter_0.WriteStartElement(string_0);
		xmlTextWriter_0.WriteAttributeString(localName, value);
		if (internalColor_0.Tint != 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("tint", Class1618.smethod_79(internalColor_0.Tint));
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_15(XmlTextWriter xmlTextWriter_0, Class1527 class1527_0, string string_0)
	{
		if (class1527_0 != null)
		{
			xmlTextWriter_0.WriteStartElement(string_0);
			if (class1527_0.string_0 != null && class1527_0.string_0 != "none")
			{
				xmlTextWriter_0.WriteAttributeString("style", class1527_0.string_0);
			}
			if (!class1527_0.internalColor_0.method_2())
			{
				smethod_1(xmlTextWriter_0, class1527_0.internalColor_0, "color");
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_16(XmlTextWriter xmlTextWriter_0, Class1571 class1571_0)
	{
		xmlTextWriter_0.WriteStartElement("xf");
		string value = Class1618.smethod_80(class1571_0.int_1);
		if (class1571_0.int_1 == -1)
		{
			value = "0";
		}
		xmlTextWriter_0.WriteAttributeString("numFmtId", value);
		if (class1536_0.hashtable_0.ContainsKey(class1571_0.int_2))
		{
			int int_ = (int)class1536_0.hashtable_0[class1571_0.int_2];
			xmlTextWriter_0.WriteAttributeString("fontId", Class1618.smethod_80(int_));
		}
		if (class1571_0.int_3 != -1)
		{
			xmlTextWriter_0.WriteAttributeString("fillId", Class1618.smethod_80(class1571_0.int_3));
		}
		if (class1571_0.int_4 != -1)
		{
			xmlTextWriter_0.WriteAttributeString("borderId", Class1618.smethod_80(class1571_0.int_4));
		}
		if (class1571_0.bool_0)
		{
			xmlTextWriter_0.WriteAttributeString("xfId", Class1618.smethod_80(class1571_0.int_5));
		}
		if (class1571_0.bool_0)
		{
			Style style_ = class1571_0.style_0;
			if (style_.method_17())
			{
				xmlTextWriter_0.WriteAttributeString("applyNumberFormat", "1");
			}
			if (style_.method_19())
			{
				xmlTextWriter_0.WriteAttributeString("applyFont", "1");
			}
			if (style_.method_25())
			{
				xmlTextWriter_0.WriteAttributeString("applyFill", "1");
			}
			if (style_.method_23())
			{
				xmlTextWriter_0.WriteAttributeString("applyBorder", "1");
			}
			if (style_.method_21())
			{
				xmlTextWriter_0.WriteAttributeString("applyAlignment", "1");
			}
			if (style_.method_27())
			{
				xmlTextWriter_0.WriteAttributeString("applyProtection", "1");
			}
		}
		else
		{
			Style style_2 = class1571_0.style_0;
			if (!style_2.method_17())
			{
				xmlTextWriter_0.WriteAttributeString("applyNumberFormat", "0");
			}
			if (!style_2.method_19())
			{
				xmlTextWriter_0.WriteAttributeString("applyFont", "0");
			}
			if (!style_2.method_25())
			{
				xmlTextWriter_0.WriteAttributeString("applyFill", "0");
			}
			if (!style_2.method_23())
			{
				xmlTextWriter_0.WriteAttributeString("applyBorder", "0");
			}
			if (!style_2.method_21())
			{
				xmlTextWriter_0.WriteAttributeString("applyAlignment", "0");
			}
			if (!style_2.method_27())
			{
				xmlTextWriter_0.WriteAttributeString("applyProtection", "0");
			}
		}
		if (class1571_0.style_0.method_47())
		{
			xmlTextWriter_0.WriteAttributeString("quotePrefix", "1");
		}
		if (class1571_0.bool_6)
		{
			method_18(xmlTextWriter_0, class1571_0.class1525_0, bool_0: false);
		}
		if (class1571_0.bool_7)
		{
			method_19(xmlTextWriter_0, class1571_0.class1563_0, bool_0: false);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_17(XmlTextWriter xmlTextWriter_0, Class1525 class1525_0, Style style_0)
	{
		xmlTextWriter_0.WriteStartElement("alignment");
		if (class1525_0.string_0 != null && style_0.IsModified(StyleModifyFlag.HorizontalAlignment))
		{
			xmlTextWriter_0.WriteAttributeString("horizontal", class1525_0.string_0);
		}
		if (class1525_0.string_1 != null && style_0.IsModified(StyleModifyFlag.VerticalAlignment))
		{
			xmlTextWriter_0.WriteAttributeString("vertical", class1525_0.string_1);
		}
		if (style_0.IsModified(StyleModifyFlag.Rotation))
		{
			xmlTextWriter_0.WriteAttributeString("textRotation", Class1618.smethod_80(class1525_0.int_0));
		}
		if (style_0.IsModified(StyleModifyFlag.WrapText))
		{
			xmlTextWriter_0.WriteAttributeString("wrapText", "1");
		}
		if (style_0.IsModified(StyleModifyFlag.Indent))
		{
			xmlTextWriter_0.WriteAttributeString("indent", Class1618.smethod_80(class1525_0.int_1));
		}
		if (style_0.IsModified(StyleModifyFlag.ShrinkToFit))
		{
			xmlTextWriter_0.WriteAttributeString("shrinkToFit", "1");
		}
		if (style_0.IsModified(StyleModifyFlag.TextDirection))
		{
			xmlTextWriter_0.WriteAttributeString("readingOrder", Class1618.smethod_74(class1525_0.textDirectionType_0));
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_18(XmlTextWriter xmlTextWriter_0, Class1525 class1525_0, bool bool_0)
	{
		xmlTextWriter_0.WriteStartElement("alignment");
		if (class1525_0.string_0 != null && (bool_0 || class1525_0.string_0 != "general"))
		{
			xmlTextWriter_0.WriteAttributeString("horizontal", class1525_0.string_0);
		}
		if (class1525_0.string_1 != null && (bool_0 || class1525_0.string_1 != "bottom"))
		{
			xmlTextWriter_0.WriteAttributeString("vertical", class1525_0.string_1);
		}
		if (bool_0 || class1525_0.int_0 > 0)
		{
			xmlTextWriter_0.WriteAttributeString("textRotation", Class1618.smethod_80(class1525_0.int_0));
		}
		if (bool_0 || class1525_0.bool_0)
		{
			xmlTextWriter_0.WriteAttributeString("wrapText", "1");
		}
		if (bool_0 || class1525_0.int_1 > 0)
		{
			xmlTextWriter_0.WriteAttributeString("indent", Class1618.smethod_80(class1525_0.int_1));
		}
		if (bool_0 || class1525_0.bool_1)
		{
			xmlTextWriter_0.WriteAttributeString("shrinkToFit", "1");
		}
		if (bool_0 || class1525_0.textDirectionType_0 != 0)
		{
			xmlTextWriter_0.WriteAttributeString("readingOrder", Class1618.smethod_74(class1525_0.textDirectionType_0));
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_19(XmlTextWriter xmlTextWriter_0, Class1563 class1563_0, bool bool_0)
	{
		if (class1563_0 != null)
		{
			xmlTextWriter_0.WriteStartElement("protection");
			if (bool_0 || class1563_0.bool_1)
			{
				xmlTextWriter_0.WriteAttributeString("hidden", "1");
			}
			if (bool_0 || !class1563_0.bool_0)
			{
				xmlTextWriter_0.WriteAttributeString("locked", "0");
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private void method_20(XmlTextWriter xmlTextWriter_0)
	{
		Class1337 @class = workbook_0.Worksheets.method_56();
		int count = @class.Count;
		if (count != 0)
		{
			xmlTextWriter_0.WriteStartElement("dxfs");
			xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(count));
			for (int i = 0; i < @class.Count; i++)
			{
				Style style_ = @class[i];
				method_22(xmlTextWriter_0, style_, null);
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	internal static void smethod_3(Style style_0, Aspose.Cells.Font font_0, XmlTextWriter xmlTextWriter_0, string string_0)
	{
		if (style_0.IsModified(StyleModifyFlag.FontWeight))
		{
			if (font_0.IsBold)
			{
				xmlTextWriter_0.WriteElementString("b", null);
			}
			else
			{
				smethod_4(xmlTextWriter_0, "b", "0");
			}
		}
		if (style_0.IsModified(StyleModifyFlag.FontItalic))
		{
			if (font_0.IsItalic)
			{
				xmlTextWriter_0.WriteElementString("i", null);
			}
			else
			{
				smethod_4(xmlTextWriter_0, "i", "0");
			}
		}
		if (style_0.IsModified(StyleModifyFlag.FontUnderline))
		{
			smethod_4(xmlTextWriter_0, "u", Class1618.smethod_9(font_0.Underline));
		}
		if (style_0.IsModified(StyleModifyFlag.FontStrike))
		{
			if (font_0.IsStrikeout)
			{
				xmlTextWriter_0.WriteElementString("strike", null);
			}
			else
			{
				smethod_4(xmlTextWriter_0, "strike", "0");
			}
		}
		if (style_0.IsModified(StyleModifyFlag.FontScript) && (font_0.IsSubscript || font_0.IsSuperscript))
		{
			string value = null;
			if (font_0.IsSubscript)
			{
				value = "subscript";
			}
			if (font_0.IsSuperscript)
			{
				value = "superscript";
			}
			xmlTextWriter_0.WriteStartElement("vertAlign");
			xmlTextWriter_0.WriteAttributeString("val", value);
			xmlTextWriter_0.WriteEndElement();
		}
		if (style_0.IsModified(StyleModifyFlag.FontSize))
		{
			smethod_4(xmlTextWriter_0, "sz", Class1618.smethod_80(font_0.Size));
		}
		if (style_0.IsModified(StyleModifyFlag.FontName) && font_0.Name != null)
		{
			smethod_4(xmlTextWriter_0, string_0, Class1618.smethod_4(font_0.Name));
		}
		if (style_0.IsModified(StyleModifyFlag.FontFamily))
		{
			smethod_4(xmlTextWriter_0, "family", Class1618.smethod_84(font_0.method_11()));
		}
		if (style_0.IsModified(StyleModifyFlag.FontColor))
		{
			smethod_2(xmlTextWriter_0, font_0.InternalColor, "color", bool_0: true);
		}
	}

	[Attribute0(true)]
	private static void smethod_4(XmlTextWriter xmlTextWriter_0, string string_0, string string_1)
	{
		xmlTextWriter_0.WriteStartElement(string_0);
		xmlTextWriter_0.WriteAttributeString("val", string_1);
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_21(Style style_0, XmlTextWriter xmlTextWriter_0, Class1535 class1535_0)
	{
		xmlTextWriter_0.WriteStartElement("fill");
		if (class1535_0.class1528_0 != null)
		{
			method_10(xmlTextWriter_0, class1535_0);
		}
		else
		{
			xmlTextWriter_0.WriteStartElement("patternFill");
			if (style_0.IsModified(StyleModifyFlag.Pattern))
			{
				xmlTextWriter_0.WriteAttributeString("patternType", class1535_0.class1561_0.string_0);
			}
			if (style_0.IsModified(StyleModifyFlag.ForegroundColor))
			{
				smethod_1(xmlTextWriter_0, class1535_0.class1561_0.internalColor_0, "fgColor");
			}
			if (style_0.IsModified(StyleModifyFlag.BackgroundColor))
			{
				smethod_1(xmlTextWriter_0, class1535_0.class1561_0.internalColor_1, "bgColor");
			}
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	internal void method_22(XmlTextWriter xmlTextWriter_0, Style style_0, string string_0)
	{
		if (string_0 != null)
		{
			xmlTextWriter_0.WriteStartElement(string_0 + ":dxf");
		}
		else
		{
			xmlTextWriter_0.WriteStartElement("dxf");
		}
		if (style_0.method_40() != null && style_0.IsModified(StyleModifyFlag.Font))
		{
			xmlTextWriter_0.WriteStartElement("font");
			smethod_3(style_0, style_0.Font, xmlTextWriter_0, "name");
			xmlTextWriter_0.WriteEndElement();
		}
		if (style_0.IsModified(StyleModifyFlag.NumberFormat))
		{
			int num = style_0.method_44();
			if (num != -1 && num != 0)
			{
				xmlTextWriter_0.WriteStartElement("numFmt");
				xmlTextWriter_0.WriteAttributeString("numFmtId", Class1618.smethod_80(num));
				string text = style_0.Custom;
				if (text == null || text.Length == 0)
				{
					text = ((num >= 59) ? "" : Class1618.smethod_78(num));
				}
				xmlTextWriter_0.WriteAttributeString("formatCode", text);
				xmlTextWriter_0.WriteEndElement();
			}
		}
		if (style_0.IsModified(StyleModifyFlag.Pattern) || style_0.IsModified(StyleModifyFlag.ForegroundColor) || style_0.IsModified(StyleModifyFlag.BackgroundColor) || style_0.IsGradient)
		{
			Class1535 class1535_ = Class1535.smethod_0(style_0);
			method_21(style_0, xmlTextWriter_0, class1535_);
		}
		if (style_0.IsModified(StyleModifyFlag.AlignmentSettings))
		{
			Class1525 @class = Class1525.smethod_0(style_0);
			if (@class != null)
			{
				method_17(xmlTextWriter_0, @class, style_0);
			}
		}
		if (style_0.method_4() != null)
		{
			Class1526 class2 = Class1526.smethod_0(style_0);
			xmlTextWriter_0.WriteStartElement("border");
			if (style_0.IsModified(StyleModifyFlag.Borders))
			{
				if (style_0.IsModified(StyleModifyFlag.Diagonal) && !style_0.IsModified(StyleModifyFlag.DiagonalUpBorder))
				{
					xmlTextWriter_0.WriteAttributeString("diagonalUp", "0");
				}
				if (style_0.IsModified(StyleModifyFlag.Diagonal) && !style_0.IsModified(StyleModifyFlag.DiagonalDownBorder))
				{
					xmlTextWriter_0.WriteAttributeString("diagonalDown", "0");
				}
				if (style_0.IsModified(StyleModifyFlag.LeftBorder))
				{
					method_15(xmlTextWriter_0, class2.class1527_1, "left");
				}
				if (style_0.IsModified(StyleModifyFlag.RightBorder))
				{
					method_15(xmlTextWriter_0, class2.class1527_3, "right");
				}
				if (style_0.IsModified(StyleModifyFlag.TopBorder))
				{
					method_15(xmlTextWriter_0, class2.class1527_0, "top");
				}
				if (style_0.IsModified(StyleModifyFlag.BottomBorder))
				{
					method_15(xmlTextWriter_0, class2.class1527_2, "bottom");
				}
				if (style_0.IsModified(StyleModifyFlag.Diagonal) || style_0.IsModified(StyleModifyFlag.DiagonalDownBorder) || style_0.IsModified(StyleModifyFlag.DiagonalUpBorder))
				{
					method_15(xmlTextWriter_0, class2.class1527_4, "diagonal");
				}
			}
			if (class2.class1527_6 != null)
			{
				method_15(xmlTextWriter_0, class2.class1527_6, "vertical");
			}
			if (class2.class1527_5 != null)
			{
				method_15(xmlTextWriter_0, class2.class1527_5, "horizontal");
			}
			xmlTextWriter_0.WriteEndElement();
		}
		if (style_0.IsModified(StyleModifyFlag.Locked))
		{
			Class1563 class1563_ = Class1563.smethod_0(style_0);
			method_19(xmlTextWriter_0, class1563_, bool_0: true);
		}
		xmlTextWriter_0.WriteEndElement();
	}
}
