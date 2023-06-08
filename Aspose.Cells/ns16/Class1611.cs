using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Tables;
using ns1;
using ns2;
using ns22;
using ns27;

namespace ns16;

internal class Class1611
{
	private Class1547 class1547_0;

	private string string_0;

	private WorksheetCollection worksheetCollection_0;

	private ArrayList arrayList_0;

	private ArrayList arrayList_1;

	private ArrayList arrayList_2;

	private ArrayList arrayList_3;

	private ArrayList arrayList_4;

	private ArrayList arrayList_5;

	internal Class1611(Class1547 class1547_1)
	{
		class1547_0 = class1547_1;
		worksheetCollection_0 = class1547_0.workbook_0.Worksheets;
	}

	[Attribute0(true)]
	internal void method_0(XmlTextReader xmlTextReader_0)
	{
		method_31(xmlTextReader_0);
		if (xmlTextReader_0.IsEmptyElement)
		{
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "colors")
			{
				method_13(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
	}

	internal void Read(XmlTextReader xmlTextReader_0)
	{
		method_31(xmlTextReader_0);
		if (xmlTextReader_0.IsEmptyElement)
		{
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "numFmts")
			{
				method_14(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "fonts")
			{
				method_30(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "fills")
			{
				method_26(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "borders")
			{
				method_23(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "cellStyleXfs")
			{
				method_19(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "cellXfs")
			{
				method_18(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "cellStyles")
			{
				method_16(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "dxfs")
			{
				method_32(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "tableStyles")
			{
				method_2(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "extLst")
			{
				method_1(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		method_7();
		method_5();
	}

	[Attribute0(true)]
	private void method_1(XmlTextReader xmlTextReader_0)
	{
		class1547_0.workbook_0.class1558_0.class1363_0.Add(Enum129.const_4, xmlTextReader_0.ReadOuterXml());
	}

	[Attribute0(true)]
	private void method_2(XmlTextReader xmlTextReader_0)
	{
		TableStyleCollection tableStyles = worksheetCollection_0.TableStyles;
		tableStyles.method_1(xmlTextReader_0.GetAttribute("defaultTableStyle"));
		tableStyles.method_3(xmlTextReader_0.GetAttribute("defaultPivotStyle"));
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "tableStyle")
			{
				method_3(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_3(XmlTextReader xmlTextReader_0)
	{
		TableStyle tableStyle = null;
		string text = null;
		string text2 = null;
		string text3 = null;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "name")
				{
					text = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "pivot")
				{
					text2 = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "table")
				{
					text3 = xmlTextReader_0.Value;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (text != null)
		{
			int index = worksheetCollection_0.TableStyles.Add(text);
			tableStyle = worksheetCollection_0.TableStyles[index];
			if (text2 != null)
			{
				tableStyle.method_3((text2 == "1") ? true : false);
			}
			if (text3 != null)
			{
				tableStyle.method_5((text3 == "1") ? true : false);
			}
		}
		if (text != null && !xmlTextReader_0.IsEmptyElement)
		{
			tableStyle.method_1(new TableStyleElementCollection(tableStyle));
			xmlTextReader_0.Read();
			while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
			{
				xmlTextReader_0.MoveToContent();
				if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "tableStyleElement")
				{
					method_4(xmlTextReader_0, tableStyle);
				}
				else
				{
					xmlTextReader_0.Skip();
				}
			}
			xmlTextReader_0.ReadEndElement();
		}
		else
		{
			xmlTextReader_0.Skip();
		}
	}

	[Attribute0(true)]
	private void method_4(XmlTextReader xmlTextReader_0, TableStyle tableStyle_0)
	{
		string text = null;
		string text2 = null;
		string text3 = null;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "type")
				{
					text = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "dxfId")
				{
					text2 = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "size")
				{
					text3 = xmlTextReader_0.Value;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (text != null)
		{
			try
			{
				TableStyleElementType tableStyleElementType = Class1618.smethod_210(text);
				if (tableStyle_0.method_2() || !tableStyle_0.method_4())
				{
					switch (tableStyleElementType)
					{
					case TableStyleElementType.LastColumn:
						tableStyleElementType = TableStyleElementType.GrandTotalColumn;
						break;
					case TableStyleElementType.TotalRow:
						tableStyleElementType = TableStyleElementType.GrandTotalRow;
						break;
					}
				}
				TableStyleElement tableStyleElement = new TableStyleElement(tableStyle_0.TableStyleElements, tableStyleElementType);
				if (text3 != null)
				{
					tableStyleElement.Size = Class1618.smethod_87(text3);
				}
				if (text2 != null)
				{
					tableStyleElement.int_1 = Class1618.smethod_87(text2);
				}
				tableStyle_0.TableStyleElements.Add(tableStyleElement);
			}
			catch
			{
			}
		}
		xmlTextReader_0.Skip();
	}

	private void method_5()
	{
		WorksheetCollection worksheets = class1547_0.workbook_0.Worksheets;
		worksheets.method_74();
		int num = ((worksheets.method_72() * 8 + worksheets.method_73()) / 8 + 1) * 8;
		double double_ = (double)(num - worksheets.method_73()) / (double)worksheets.method_72();
		for (int i = 0; i < worksheets.Count; i++)
		{
			Cells cells = worksheets[i].Cells;
			cells.method_8(double_);
		}
	}

	private string[] method_6()
	{
		Class1683 @class = worksheetCollection_0.method_58();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < @class.Count; i++)
		{
			Style style = @class[i];
			if (style.method_2() != null)
			{
				arrayList.Add(style.method_2());
			}
		}
		string[] array = new string[arrayList.Count];
		for (int j = 0; j < array.Length; j++)
		{
			array[j] = (string)arrayList[j];
		}
		return array;
	}

	private void method_7()
	{
		method_11();
		Class1683 @class = worksheetCollection_0.method_58();
		string[] array = method_6();
		int num = ((arrayList_5 != null) ? arrayList_5.Count : 0);
		int num2 = ((arrayList_3 != null) ? arrayList_3.Count : 0);
		for (int i = 0; i < num; i++)
		{
			Class1529 class2 = (Class1529)arrayList_5[i];
			if (class2.int_0 < num2)
			{
				Class1571 class3 = (Class1571)arrayList_3[class2.int_0];
				class3.class1529_0 = class2;
			}
		}
		Hashtable hashtable = new Hashtable(num2);
		for (int j = 0; j < num2; j++)
		{
			Class1571 class4 = (Class1571)arrayList_3[j];
			Style style = new Style(worksheetCollection_0);
			method_8(class4, style, bool_0: false);
			style.method_11(bool_0: false);
			style.method_13(-1);
			string text = null;
			if (j == 0)
			{
				text = "Normal";
			}
			else if (class4.class1529_0 != null)
			{
				text = class4.class1529_0.string_0;
				if (text.Equals("Default"))
				{
					text = "Normal";
				}
			}
			if (text != null)
			{
				style.method_3(text);
				if (text.Equals("Normal"))
				{
					@class[0] = style;
					hashtable[j] = 0;
					if (!style.method_19())
					{
						style.Font.Copy((Aspose.Cells.Font)worksheetCollection_0.method_52()[0]);
						style.method_20(bool_0: true);
					}
					continue;
				}
				bool flag = false;
				for (int k = 0; k < array.Length; k++)
				{
					if (text == array[k])
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					hashtable[j] = worksheetCollection_0.method_58().method_5(style);
					continue;
				}
				hashtable[j] = worksheetCollection_0.method_58().method_4(style);
				worksheetCollection_0.Styles.method_0(style);
			}
			else
			{
				hashtable[j] = worksheetCollection_0.method_59(style);
			}
		}
		if (num == 0)
		{
			Style style2 = new Style(worksheetCollection_0);
			style2.method_11(bool_0: true);
			style2.method_13(0);
			@class[15] = style2;
		}
		class1547_0.hashtable_3 = new Hashtable(arrayList_4.Count);
		class1547_0.hashtable_4 = new Hashtable(arrayList_4.Count);
		int num3 = -1;
		for (int l = 0; l < arrayList_4.Count; l++)
		{
			Class1571 class5 = (Class1571)arrayList_4[l];
			int int_ = 0;
			if (class5.int_5 > 0)
			{
				int_ = (int)hashtable[class5.int_5];
			}
			Style style3 = new Style(worksheetCollection_0);
			style3.method_11(bool_0: true);
			style3.method_13(int_);
			method_8(class5, style3, bool_0: true);
			if (l == 0 && num2 > 0 && num > 0)
			{
				num3 = 0;
				@class[15] = style3;
				style3.method_13(0);
				class1547_0.hashtable_3.Add(0, 15);
				continue;
			}
			int num4 = @class.method_0(style3);
			class1547_0.hashtable_3.Add(l, num4);
			if (num3 != -1 && class5.method_0((Class1571)arrayList_4[num3]))
			{
				class1547_0.hashtable_4.Add(l, true);
			}
		}
	}

	private Style method_8(Class1571 class1571_0, Style style_0, bool bool_0)
	{
		if (class1571_0.int_2 != -1)
		{
			Class1542 @class = (Class1542)arrayList_0[class1571_0.int_2];
			style_0.Font.Copy((Aspose.Cells.Font)worksheetCollection_0.method_52()[@class.method_12()]);
		}
		if (class1571_0.int_1 != -1 && (class1571_0.bool_2 || bool_0))
		{
			Class639 class2 = worksheetCollection_0.method_47(class1571_0.int_1);
			if (class2 != null)
			{
				style_0.method_43(class1571_0.int_1, class2.Custom, class2.bool_0);
			}
			else
			{
				style_0.method_43(class1571_0.int_1, "", bool_0: false);
			}
		}
		if (class1571_0.int_4 != -1)
		{
			method_10(class1571_0, style_0);
		}
		if (class1571_0.int_3 != -1)
		{
			method_9(class1571_0, style_0);
		}
		style_0.VerticalAlignment = TextAlignmentType.Bottom;
		if (class1571_0.class1525_0 != null && (class1571_0.bool_6 || bool_0))
		{
			class1571_0.class1525_0.method_1(style_0, bool_2: false);
		}
		if (class1571_0.class1563_0 != null)
		{
			class1571_0.class1563_0.method_1(style_0);
		}
		style_0.method_22(class1571_0.bool_6 || class1571_0.class1525_0 != null);
		style_0.method_24(class1571_0.bool_5);
		style_0.method_20(class1571_0.bool_3);
		style_0.method_18(class1571_0.bool_2);
		style_0.method_26(class1571_0.bool_4);
		style_0.method_28(class1571_0.bool_7 || class1571_0.class1563_0 != null);
		style_0.method_48(class1571_0.bool_1);
		return style_0;
	}

	private void method_9(Class1571 class1571_0, Style style_0)
	{
		if (class1571_0.int_3 == -1 || arrayList_1.Count <= class1571_0.int_3)
		{
			return;
		}
		Class1535 @class = (Class1535)arrayList_1[class1571_0.int_3];
		if (@class != null)
		{
			if (@class.class1528_0 != null)
			{
				Class1528.smethod_1(@class.class1528_0, style_0);
			}
			else if (@class.class1561_0 != null)
			{
				@class.class1561_0.method_0(style_0);
			}
		}
	}

	private void method_10(Class1571 class1571_0, Style style_0)
	{
		if (class1571_0.int_4 != -1 && arrayList_2 != null && arrayList_2.Count != 0 && arrayList_2.Count > class1571_0.int_4)
		{
			Class1526 @class = (Class1526)arrayList_2[class1571_0.int_4];
			@class.method_1(style_0);
		}
	}

	private void method_11()
	{
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Class1542 class1542_ = (Class1542)arrayList_0[i];
			smethod_0(worksheetCollection_0, class1542_, (i == 0) ? true : false);
		}
	}

	private static void smethod_0(WorksheetCollection worksheetCollection_1, Class1542 class1542_0, bool bool_0)
	{
		if (class1542_0.bool_0)
		{
			class1542_0.method_13(0);
			return;
		}
		Aspose.Cells.Font font = new Aspose.Cells.Font(worksheetCollection_1, null, bool_0: false);
		class1542_0.method_19(font);
		if (bool_0)
		{
			font.method_22(0);
			class1542_0.method_13(0);
			worksheetCollection_1.method_52()[0] = font;
			return;
		}
		if (worksheetCollection_1.method_52().Count > 3)
		{
			font.method_22(worksheetCollection_1.method_52().Count + 1);
		}
		else
		{
			font.method_22(worksheetCollection_1.method_52().Count);
		}
		class1542_0.method_13(worksheetCollection_1.method_52().Count);
		worksheetCollection_1.method_52().Add(font);
	}

	[Attribute0(true)]
	private void method_12(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			throw new CellsException(ExceptionType.InvalidData, "Invalid indexedColors element");
		}
		xmlTextReader_0.Read();
		int num = 0;
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "rgbColor")
			{
				if (num < 8)
				{
					num++;
					xmlTextReader_0.Skip();
					continue;
				}
				string attribute = xmlTextReader_0.GetAttribute("rgb", "");
				if (attribute != null)
				{
					int argb = int.Parse(attribute, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
					class1547_0.workbook_0.ChangePalette(Color.FromArgb(argb), num - 8);
				}
				num++;
				xmlTextReader_0.Skip();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_13(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "indexedColors" && !xmlTextReader_0.IsEmptyElement)
			{
				method_12(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_14(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		Class1618.smethod_41(xmlTextReader_0);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "numFmt")
			{
				Class639 @class = method_15(xmlTextReader_0);
				if (@class.Data != null)
				{
					worksheetCollection_0.method_55().Add(@class);
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private Class639 method_15(XmlTextReader xmlTextReader_0)
	{
		Class639 @class = new Class639();
		if (xmlTextReader_0.HasAttributes)
		{
			ushort num = 0;
			string text = null;
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (!(xmlTextReader_0.NamespaceURI != ""))
				{
					if (xmlTextReader_0.LocalName == "numFmtId")
					{
						num = ushort.Parse(xmlTextReader_0.Value, CultureInfo.InvariantCulture);
					}
					else if (xmlTextReader_0.LocalName == "formatCode")
					{
						text = xmlTextReader_0.Value;
					}
				}
			}
			if (text != null)
			{
				@class.method_4(text, num);
				@class.bool_0 = Class1386.smethod_1(text);
				if (num > worksheetCollection_0.method_41())
				{
					worksheetCollection_0.method_42(num);
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
		return @class;
	}

	[Attribute0(true)]
	private void method_16(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		int capacity = Class1618.smethod_41(xmlTextReader_0);
		arrayList_5 = new ArrayList(capacity);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "cellStyle")
			{
				Class1529 value = method_17(xmlTextReader_0);
				arrayList_5.Add(value);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private Class1529 method_17(XmlTextReader xmlTextReader_0)
	{
		Class1529 @class = new Class1529();
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (!(xmlTextReader_0.NamespaceURI != ""))
				{
					if (xmlTextReader_0.LocalName == "name")
					{
						@class.string_0 = xmlTextReader_0.Value;
					}
					else if (xmlTextReader_0.LocalName == "xfId")
					{
						@class.int_0 = Class1618.smethod_87(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "builtinId")
					{
						@class.int_1 = Class1618.smethod_87(xmlTextReader_0.Value);
					}
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
		if (@class.int_0 < 0 || @class.int_0 >= arrayList_3.Count)
		{
			throw new CellsException(ExceptionType.InvalidData, "Invalid XfId");
		}
		return @class;
	}

	[Attribute0(true)]
	private void method_18(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		int capacity = Class1618.smethod_41(xmlTextReader_0);
		arrayList_4 = new ArrayList(capacity);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "xf")
			{
				Class1571 @class = method_20(xmlTextReader_0, bool_0: false);
				@class.bool_0 = false;
				arrayList_4.Add(@class);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_19(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		int capacity = Class1618.smethod_41(xmlTextReader_0);
		arrayList_3 = new ArrayList(capacity);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "xf")
			{
				Class1571 @class = method_20(xmlTextReader_0, bool_0: true);
				@class.bool_0 = false;
				arrayList_3.Add(@class);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private Class1571 method_20(XmlTextReader xmlTextReader_0, bool bool_0)
	{
		Class1571 @class = new Class1571();
		if (bool_0)
		{
			@class.bool_2 = true;
			@class.bool_3 = true;
			@class.bool_4 = true;
			@class.bool_5 = true;
			@class.bool_6 = true;
			@class.bool_7 = true;
		}
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string localName;
				if ((localName = xmlTextReader_0.LocalName) == null)
				{
					continue;
				}
				if (Class1742.dictionary_138 == null)
				{
					Class1742.dictionary_138 = new Dictionary<string, int>(12)
					{
						{ "numFmtId", 0 },
						{ "fontId", 1 },
						{ "fillId", 2 },
						{ "borderId", 3 },
						{ "xfId", 4 },
						{ "applyNumberFormat", 5 },
						{ "applyFont", 6 },
						{ "applyFill", 7 },
						{ "applyBorder", 8 },
						{ "applyAlignment", 9 },
						{ "applyProtection", 10 },
						{ "quotePrefix", 11 }
					};
				}
				if (Class1742.dictionary_138.TryGetValue(localName, out var value))
				{
					switch (value)
					{
					case 0:
						@class.int_1 = Class1618.smethod_87(xmlTextReader_0.Value);
						break;
					case 1:
						@class.int_2 = Class1618.smethod_87(xmlTextReader_0.Value);
						break;
					case 2:
						@class.int_3 = Class1618.smethod_87(xmlTextReader_0.Value);
						break;
					case 3:
						@class.int_4 = Class1618.smethod_87(xmlTextReader_0.Value);
						break;
					case 4:
						@class.int_5 = Class1618.smethod_87(xmlTextReader_0.Value);
						break;
					case 5:
						@class.bool_2 = Class1618.smethod_201(xmlTextReader_0.Value);
						break;
					case 6:
						@class.bool_3 = Class1618.smethod_201(xmlTextReader_0.Value);
						break;
					case 7:
						@class.bool_4 = Class1618.smethod_201(xmlTextReader_0.Value);
						break;
					case 8:
						@class.bool_5 = Class1618.smethod_201(xmlTextReader_0.Value);
						break;
					case 9:
						@class.bool_6 = Class1618.smethod_201(xmlTextReader_0.Value);
						break;
					case 10:
						@class.bool_7 = Class1618.smethod_201(xmlTextReader_0.Value);
						break;
					case 11:
						@class.bool_1 = Class1618.smethod_201(xmlTextReader_0.Value);
						break;
					}
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return @class;
		}
		xmlTextReader_0.Read();
		while (Class1188.smethod_15(xmlTextReader_0))
		{
			switch (xmlTextReader_0.LocalName)
			{
			case "protection":
				@class.class1563_0 = method_22(xmlTextReader_0);
				break;
			case "alignment":
				@class.class1525_0 = method_21(xmlTextReader_0);
				break;
			default:
				xmlTextReader_0.Skip();
				break;
			}
		}
		return @class;
	}

	[Attribute0(true)]
	private Class1525 method_21(XmlTextReader xmlTextReader_0)
	{
		if (!xmlTextReader_0.HasAttributes)
		{
			xmlTextReader_0.Skip();
			return null;
		}
		Class1525 @class = new Class1525();
		while (xmlTextReader_0.MoveToNextAttribute())
		{
			if (xmlTextReader_0.NamespaceURI != "")
			{
				continue;
			}
			if (xmlTextReader_0.LocalName == "horizontal")
			{
				@class.string_0 = xmlTextReader_0.Value;
			}
			else if (xmlTextReader_0.LocalName == "vertical")
			{
				@class.string_1 = xmlTextReader_0.Value;
			}
			else if (xmlTextReader_0.LocalName == "textRotation")
			{
				@class.int_0 = Class1618.smethod_87(xmlTextReader_0.Value);
				if (@class.int_0 != 255 && (@class.int_0 < 0 || @class.int_0 > 180))
				{
					throw new CellsException(ExceptionType.InvalidData, "style textRotation must between 0 and 180");
				}
			}
			else if (xmlTextReader_0.LocalName == "wrapText" && (xmlTextReader_0.Value == "1" || xmlTextReader_0.Value.ToLower() == "true"))
			{
				@class.bool_0 = true;
			}
			else if (xmlTextReader_0.LocalName == "indent")
			{
				@class.int_1 = Class1618.smethod_87(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "shrinkToFit" && xmlTextReader_0.Value == "1")
			{
				@class.bool_1 = true;
			}
			else if (xmlTextReader_0.LocalName == "readingOrder")
			{
				@class.textDirectionType_0 = Class1618.smethod_75(xmlTextReader_0.Value);
			}
		}
		xmlTextReader_0.MoveToElement();
		xmlTextReader_0.Skip();
		return @class;
	}

	[Attribute0(true)]
	private Class1563 method_22(XmlTextReader xmlTextReader_0)
	{
		if (!xmlTextReader_0.HasAttributes)
		{
			xmlTextReader_0.Skip();
			return null;
		}
		Class1563 @class = new Class1563();
		while (xmlTextReader_0.MoveToNextAttribute())
		{
			if (xmlTextReader_0.NamespaceURI != "")
			{
				continue;
			}
			if (xmlTextReader_0.LocalName == "hidden")
			{
				if (xmlTextReader_0.Value == "0")
				{
					@class.bool_1 = false;
				}
				else
				{
					@class.bool_1 = true;
				}
			}
			else if (xmlTextReader_0.LocalName == "locked")
			{
				if (xmlTextReader_0.Value == "0")
				{
					@class.bool_0 = false;
				}
				else
				{
					@class.bool_0 = true;
				}
			}
		}
		xmlTextReader_0.MoveToElement();
		xmlTextReader_0.Skip();
		return @class;
	}

	private void method_23(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		int capacity = Class1618.smethod_41(xmlTextReader_0);
		arrayList_2 = new ArrayList(capacity);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "border")
			{
				Class1526 @class = null;
				if (!xmlTextReader_0.IsEmptyElement)
				{
					@class = method_24(xmlTextReader_0, bool_0: false);
				}
				else
				{
					@class = new Class1526();
					xmlTextReader_0.Skip();
				}
				arrayList_2.Add(@class);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private Class1526 method_24(XmlTextReader xmlTextReader_0, bool bool_0)
	{
		Class1526 @class = new Class1526();
		string attribute = xmlTextReader_0.GetAttribute("diagonalDown");
		string attribute2 = xmlTextReader_0.GetAttribute("diagonalUp");
		@class.bool_0 = ((attribute == "1") ? true : false);
		@class.bool_1 = ((attribute2 == "1") ? true : false);
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return null;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_25(xmlTextReader_0, @class, bool_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		return @class;
	}

	private void method_25(XmlTextReader xmlTextReader_0, Class1526 class1526_0, bool bool_0)
	{
		Class1527 @class = new Class1527();
		if (xmlTextReader_0.LocalName == "left")
		{
			class1526_0.class1527_1 = @class;
		}
		else if (xmlTextReader_0.LocalName == "right")
		{
			class1526_0.class1527_3 = @class;
		}
		else if (xmlTextReader_0.LocalName == "top")
		{
			class1526_0.class1527_0 = @class;
		}
		else if (xmlTextReader_0.LocalName == "bottom")
		{
			class1526_0.class1527_2 = @class;
		}
		else if (xmlTextReader_0.LocalName == "diagonal")
		{
			class1526_0.class1527_4 = @class;
		}
		else if (xmlTextReader_0.LocalName == "horizontal")
		{
			class1526_0.class1527_5 = @class;
		}
		else
		{
			if (!(xmlTextReader_0.LocalName == "vertical"))
			{
				xmlTextReader_0.Skip();
				return;
			}
			class1526_0.class1527_6 = @class;
		}
		string attribute = xmlTextReader_0.GetAttribute("style", "");
		if (attribute != null)
		{
			@class.string_0 = attribute;
		}
		else if (bool_0)
		{
			@class.string_0 = "none";
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "color")
			{
				@class.internalColor_0 = smethod_2(xmlTextReader_0, class1547_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_26(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		int capacity = Class1618.smethod_41(xmlTextReader_0);
		arrayList_1 = new ArrayList(capacity);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "fill" && !xmlTextReader_0.IsEmptyElement)
			{
				Class1535 value = method_27(xmlTextReader_0);
				arrayList_1.Add(value);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private Class1535 method_27(XmlTextReader xmlTextReader_0)
	{
		Class1535 @class = new Class1535();
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				if (xmlTextReader_0.LocalName == "patternFill")
				{
					@class.class1561_0 = method_29(xmlTextReader_0);
				}
				else if (xmlTextReader_0.LocalName == "gradientFill")
				{
					@class.class1528_0 = method_28(xmlTextReader_0);
				}
				else
				{
					xmlTextReader_0.Skip();
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		if (@class.class1561_0 == null && @class.class1528_0 == null)
		{
			return null;
		}
		return @class;
	}

	private Class1528 method_28(XmlTextReader xmlTextReader_0)
	{
		Class1528 @class = new Class1528();
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (!(xmlTextReader_0.NamespaceURI != ""))
				{
					if (xmlTextReader_0.LocalName == "bottom")
					{
						@class.double_3 = Class1618.smethod_85(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "degree")
					{
						@class.int_0 = Class1618.smethod_87(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "left")
					{
						@class.double_0 = Class1618.smethod_85(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "right")
					{
						@class.double_1 = Class1618.smethod_85(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "top")
					{
						@class.double_2 = Class1618.smethod_85(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "type")
					{
						@class.string_0 = xmlTextReader_0.Value;
					}
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return @class;
		}
		ArrayList arrayList = new ArrayList(4);
		ArrayList arrayList2 = new ArrayList(4);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "stop" && !xmlTextReader_0.IsEmptyElement)
			{
				double num = 0.0;
				string attribute = xmlTextReader_0.GetAttribute("position");
				if (attribute != null)
				{
					num = Class1618.smethod_85(attribute);
				}
				if (xmlTextReader_0.IsEmptyElement)
				{
					xmlTextReader_0.Skip();
				}
				xmlTextReader_0.Read();
				while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
				{
					xmlTextReader_0.MoveToContent();
					if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "color")
					{
						InternalColor internalColor = smethod_2(xmlTextReader_0, class1547_0);
						if (internalColor.method_2())
						{
							internalColor.SetColor(ColorType.RGB, Color.White.ToArgb());
						}
						arrayList.Add(num);
						arrayList2.Add(internalColor);
					}
					else
					{
						xmlTextReader_0.Skip();
					}
				}
				xmlTextReader_0.ReadEndElement();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		int count = arrayList.Count;
		@class.double_4 = new double[count];
		@class.internalColor_0 = new InternalColor[count];
		for (int i = 0; i < count; i++)
		{
			@class.double_4[i] = (double)arrayList[i];
			@class.internalColor_0[i] = (InternalColor)arrayList2[i];
		}
		return @class;
	}

	private Class1561 method_29(XmlTextReader xmlTextReader_0)
	{
		Class1561 @class = new Class1561();
		string attribute = xmlTextReader_0.GetAttribute("patternType", "");
		if (attribute != null)
		{
			Class1618.smethod_34(attribute);
			@class.string_0 = attribute;
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return @class;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "fgColor")
			{
				@class.internalColor_0 = smethod_2(xmlTextReader_0, class1547_0);
			}
			else if (xmlTextReader_0.LocalName == "bgColor")
			{
				@class.internalColor_1 = smethod_2(xmlTextReader_0, class1547_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		return @class;
	}

	private void method_30(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		int capacity = Class1618.smethod_41(xmlTextReader_0);
		arrayList_0 = new ArrayList(capacity);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "font")
			{
				if (xmlTextReader_0.IsEmptyElement)
				{
					Class1542 @class = new Class1542();
					@class.bool_0 = true;
					arrayList_0.Add(@class);
					xmlTextReader_0.Skip();
				}
				else
				{
					Class1542 value = smethod_1(xmlTextReader_0, class1547_0, "name");
					arrayList_0.Add(value);
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	internal static Class1542 smethod_1(XmlTextReader xmlTextReader_0, Class1547 class1547_1, string string_1)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return null;
		}
		class1547_1.workbook_0.Worksheets.method_24();
		xmlTextReader_0.Read();
		Class1542 @class = new Class1542();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "sz")
			{
				string attribute = xmlTextReader_0.GetAttribute("val", "");
				if (attribute != null)
				{
					@class.Size = Class1618.smethod_85(attribute);
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == string_1)
			{
				string attribute2 = xmlTextReader_0.GetAttribute("val", "");
				if (attribute2 != null)
				{
					@class.Name = Class1618.smethod_8(attribute2);
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "family")
			{
				string attribute3 = xmlTextReader_0.GetAttribute("val", "");
				if (attribute3 != null)
				{
					@class.method_9(Class1618.smethod_87(attribute3));
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "b")
			{
				string attribute4 = xmlTextReader_0.GetAttribute("val", "");
				if (attribute4 == "0")
				{
					@class.IsBold = false;
				}
				else
				{
					@class.IsBold = true;
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "i")
			{
				string attribute5 = xmlTextReader_0.GetAttribute("val", "");
				if (attribute5 == "0")
				{
					@class.IsItalic = false;
				}
				else
				{
					@class.IsItalic = true;
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "u")
			{
				string attribute6 = xmlTextReader_0.GetAttribute("val", "");
				if (attribute6 != null)
				{
					@class.method_3(Class1618.smethod_10(attribute6));
				}
				else
				{
					@class.method_3(FontUnderlineType.Single);
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "color")
			{
				@class.method_11(smethod_2(xmlTextReader_0, class1547_1));
			}
			else if (xmlTextReader_0.LocalName == "charset")
			{
				string attribute7 = xmlTextReader_0.GetAttribute("val", "");
				if (attribute7 != null)
				{
					@class.method_14(Convert.ToInt16(attribute7));
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "strike")
			{
				string attribute8 = xmlTextReader_0.GetAttribute("val", "");
				if (attribute8 == "0")
				{
					@class.IsStrikeout = false;
				}
				else
				{
					@class.IsStrikeout = true;
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "vertAlign")
			{
				string attribute9 = xmlTextReader_0.GetAttribute("val", "");
				if (attribute9 == "subscript")
				{
					@class.IsSubscript = true;
				}
				else if (attribute9 == "superscript")
				{
					@class.IsSuperscript = true;
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "scheme")
			{
				@class.method_1(xmlTextReader_0.GetAttribute("val", ""));
				xmlTextReader_0.Skip();
				Workbook workbook_ = class1547_1.workbook_0;
				if (workbook_.Settings.Region != 0)
				{
					bool bool_ = true;
					if (@class.method_0().ToLower() == "minor")
					{
						bool_ = false;
					}
					string text = workbook_.class1569_0.class1193_0.method_1(workbook_.Settings.Region, bool_);
					if (text != null)
					{
						@class.Name = text;
					}
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		return @class;
	}

	internal static InternalColor smethod_2(XmlTextReader xmlTextReader_0, Class1547 class1547_1)
	{
		class1547_1.workbook_0.Worksheets.method_24();
		InternalColor internalColor = new InternalColor(bool_0: false);
		string attribute = xmlTextReader_0.GetAttribute("indexed");
		string attribute2 = xmlTextReader_0.GetAttribute("rgb");
		string attribute3 = xmlTextReader_0.GetAttribute("theme");
		string attribute4 = xmlTextReader_0.GetAttribute("tint");
		xmlTextReader_0.Skip();
		if (attribute != null)
		{
			int num = Class1618.smethod_87(attribute);
			if (num >= 0 && num < 64)
			{
				internalColor.SetColor(ColorType.IndexedColor, num);
			}
			else if (num != 65 && num != 64)
			{
				internalColor.method_3(bool_0: true);
			}
			else
			{
				internalColor.method_3(bool_0: true);
			}
		}
		else if (attribute2 != null)
		{
			internalColor.SetColor(ColorType.RGB, Class1618.smethod_63(attribute2).ToArgb());
		}
		else if (attribute3 != null)
		{
			int int_ = Class1618.smethod_87(attribute3);
			internalColor.SetColor(ColorType.Theme, int_);
		}
		else
		{
			internalColor.method_3(bool_0: true);
		}
		if (attribute4 != null)
		{
			internalColor.Tint = Class1618.smethod_85(attribute4);
		}
		return internalColor;
	}

	[Attribute0(true)]
	private void method_31(XmlTextReader xmlTextReader_0)
	{
		xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.None;
		xmlTextReader_0.MoveToContent();
		string namespaceURI = xmlTextReader_0.NamespaceURI;
		if (!Class1618.smethod_0(namespaceURI))
		{
			throw new CellsException(ExceptionType.InvalidData, "Error xml namespace " + namespaceURI);
		}
		if (xmlTextReader_0.NodeType == XmlNodeType.Element && !(xmlTextReader_0.LocalName != "styleSheet"))
		{
			XmlNameTable nameTable = xmlTextReader_0.NameTable;
			string_0 = nameTable.Add(namespaceURI);
			if (!xmlTextReader_0.HasAttributes)
			{
				return;
			}
			ArrayList arrayList = new ArrayList();
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (!(xmlTextReader_0.Name == "xmlns") && !(xmlTextReader_0.Name == "xmlns:r"))
				{
					arrayList.Add(new Class927(xmlTextReader_0.Name, xmlTextReader_0.Value));
				}
			}
			xmlTextReader_0.MoveToElement();
			if (arrayList.Count > 0)
			{
				class1547_0.workbook_0.class1558_0.class1363_0.Add(Enum129.const_3, arrayList);
			}
			return;
		}
		throw new CellsException(ExceptionType.InvalidData, "styleSheet root element eror");
	}

	private void method_32(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		Class1618.smethod_41(xmlTextReader_0);
		int num = 0;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "dxf" && !xmlTextReader_0.IsEmptyElement)
			{
				num++;
				Class1531 class1531_ = method_33(xmlTextReader_0);
				Style style_ = new Style(worksheetCollection_0);
				Class1617.smethod_9(style_, class1531_);
				worksheetCollection_0.method_56().method_1(style_);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	internal Class1531 method_33(XmlTextReader xmlTextReader_0)
	{
		Class1531 @class = new Class1531();
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return @class;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "font")
			{
				@class.class1542_0 = smethod_1(xmlTextReader_0, class1547_0, "name");
			}
			else if (xmlTextReader_0.LocalName == "fill")
			{
				@class.class1535_0 = method_27(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "border")
			{
				@class.class1526_0 = method_24(xmlTextReader_0, bool_0: true);
			}
			else if (xmlTextReader_0.LocalName == "numFmt")
			{
				@class.class639_0 = method_15(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "alignment")
			{
				@class.class1525_0 = method_21(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "protection")
			{
				@class.class1563_0 = method_22(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		return @class;
	}
}
