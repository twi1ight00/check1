using System.Collections;
using System.Drawing;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using ns2;
using ns22;
using ns26;

namespace ns15;

internal class Class1519
{
	private XmlTextWriter xmlTextWriter_0;

	private Class1498 class1498_0;

	public Class1519(Class1498 class1498_1)
	{
		class1498_0 = class1498_1;
	}

	internal Class1519(Class1498 class1498_1, XmlTextWriter xmlTextWriter_1)
	{
		class1498_0 = class1498_1;
		xmlTextWriter_0 = xmlTextWriter_1;
	}

	internal void Write(XmlTextWriter xmlTextWriter_1)
	{
		xmlTextWriter_0 = xmlTextWriter_1;
		method_0();
		xmlTextWriter_1.WriteStartElement("office:automatic-styles");
		method_1();
		method_2();
		method_3();
		method_4();
		method_5();
		method_6();
		xmlTextWriter_1.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_0()
	{
		xmlTextWriter_0.WriteStartElement("office:font-face-decls");
		foreach (Class1500 item in class1498_0.arrayList_0)
		{
			method_7(item);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_1()
	{
		foreach (Class1497 item in class1498_0.arrayList_1)
		{
			method_8(item);
		}
	}

	private void method_2()
	{
		foreach (Class1503 item in class1498_0.arrayList_2)
		{
			method_9(item);
		}
	}

	private void method_3()
	{
		foreach (Worksheet worksheet in class1498_0.workbook_0.Worksheets)
		{
			method_10(worksheet);
		}
	}

	internal void method_4()
	{
		foreach (Class1496 item in class1498_0.arrayList_4)
		{
			if (item.style_0.Name == null)
			{
				method_11(item);
			}
		}
	}

	private void method_5()
	{
		ArrayList arrayList = class1498_0.workbook_0.Worksheets.method_52();
		for (int i = 0; i < arrayList.Count; i++)
		{
			Aspose.Cells.Font font = (Aspose.Cells.Font)arrayList[i];
			method_12(font.method_21(), font);
		}
	}

	private void method_6()
	{
		if (class1498_0.arrayList_5 == null || class1498_0.arrayList_5.Count <= 0)
		{
			return;
		}
		foreach (Class1499 item in class1498_0.arrayList_5)
		{
			method_13(item);
		}
	}

	[Attribute0(true)]
	private void method_7(Class1500 class1500_0)
	{
		xmlTextWriter_0.WriteStartElement("style:font-face");
		xmlTextWriter_0.WriteAttributeString("style", "name", null, class1500_0.Name);
		xmlTextWriter_0.WriteAttributeString("svg", "font-family", null, class1500_0.Name);
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_8(Class1497 class1497_0)
	{
		xmlTextWriter_0.WriteStartElement("style:style");
		xmlTextWriter_0.WriteAttributeString("style", "name", null, class1497_0.Name);
		xmlTextWriter_0.WriteAttributeString("style", "family", null, "table-column");
		xmlTextWriter_0.WriteStartElement("style:table-column-properties");
		xmlTextWriter_0.WriteAttributeString("fo", "break-before", null, Class1515.smethod_0(class1497_0.method_0()));
		xmlTextWriter_0.WriteAttributeString("style", "column-width", null, Class1516.smethod_15(class1497_0.Width) + "in");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_9(Class1503 class1503_0)
	{
		xmlTextWriter_0.WriteStartElement("style:style");
		xmlTextWriter_0.WriteAttributeString("style", "name", null, class1503_0.Name);
		xmlTextWriter_0.WriteAttributeString("style", "family", null, "table-row");
		xmlTextWriter_0.WriteStartElement("style:table-row-properties");
		xmlTextWriter_0.WriteAttributeString("style", "row-height", null, Class1516.smethod_15(class1503_0.RowHeight) + "in");
		xmlTextWriter_0.WriteAttributeString("fo", "break-before", null, Class1515.smethod_0(class1503_0.method_2()));
		xmlTextWriter_0.WriteAttributeString("style", "use-optimal-row-height", null, Class1516.smethod_18(class1503_0.method_0()));
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_10(Worksheet worksheet_0)
	{
		xmlTextWriter_0.WriteStartElement("style:style");
		int num = worksheet_0.Index + 1;
		xmlTextWriter_0.WriteAttributeString("style", "name", null, "ta" + num);
		xmlTextWriter_0.WriteAttributeString("style", "family", null, "table");
		xmlTextWriter_0.WriteAttributeString("style", "master-page-name", null, "PageStyle_5f_" + worksheet_0.Name);
		xmlTextWriter_0.WriteStartElement("style:table-properties");
		xmlTextWriter_0.WriteAttributeString("table", "display", null, worksheet_0.IsVisible ? "true" : "false");
		xmlTextWriter_0.WriteAttributeString("style", "writing-mode", null, "lr-tb");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	internal void method_11(Class1496 class1496_0)
	{
		xmlTextWriter_0.WriteStartElement("style:style");
		xmlTextWriter_0.WriteAttributeString("style", "name", null, class1496_0.Name);
		xmlTextWriter_0.WriteAttributeString("style", "family", null, "table-cell");
		if (!Class1516.smethod_0(class1496_0.method_0()))
		{
			xmlTextWriter_0.WriteAttributeString("style", "parent-style-name", null, class1496_0.method_0());
		}
		if (!Class1516.smethod_0(class1496_0.string_0))
		{
			xmlTextWriter_0.WriteAttributeString("style", "data-style-name", null, class1496_0.string_0);
		}
		if (class1496_0.bool_3 || class1496_0.bool_2 || class1496_0.bool_1 || class1496_0.bool_0)
		{
			method_15(class1496_0, class1496_0.style_0);
		}
		if (class1496_0.class1501_0 != null)
		{
			method_18(class1496_0.class1501_0, bool_0: true);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_12(int int_0, Aspose.Cells.Font font_0)
	{
		xmlTextWriter_0.WriteStartElement("style:style");
		xmlTextWriter_0.WriteAttributeString("style", "name", null, "T" + int_0);
		xmlTextWriter_0.WriteAttributeString("style", "family", null, "text");
		method_18(new Class1501(font_0), bool_0: false);
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_13(Class1499 class1499_0)
	{
		if (class1499_0 == null || class1499_0.arrayList_7 == null || class1499_0.arrayList_7.Count <= 0)
		{
			return;
		}
		foreach (Class1493 item in class1499_0.arrayList_7)
		{
			xmlTextWriter_0.WriteStartElement("style:style");
			int num = class1499_0.worksheet_0.Index + item.shape_0.Index + 1;
			xmlTextWriter_0.WriteAttributeString("style", "name", null, "S" + num);
			xmlTextWriter_0.WriteAttributeString("style", "family", null, "graphic");
			method_14(item);
			method_17(item.shape_0.method_63().TextHorizontalAlignment, new Style(item.shape_0.method_25()));
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private void method_14(Class1493 class1493_0)
	{
		if (class1493_0 == null)
		{
			return;
		}
		Shape shape_ = class1493_0.shape_0;
		xmlTextWriter_0.WriteStartElement("style:graphic-properties");
		Class1737 @class = shape_.method_63();
		xmlTextWriter_0.WriteAttributeString("fo", "wrap-option", null, Class1516.smethod_29(@class.bool_1));
		if (@class.bool_1)
		{
			xmlTextWriter_0.WriteAttributeString("draw", "textarea-vertical-align", null, Class1516.smethod_22(@class.TextVerticalAlignment));
			xmlTextWriter_0.WriteAttributeString("draw", "textarea-horizontal-align", null, Class1516.smethod_24(@class.TextHorizontalAlignment));
		}
		FillFormat fill = shape_.Fill;
		if (fill.ImageData != null)
		{
			FillType type = fill.Type;
			if (type == FillType.Texture)
			{
				xmlTextWriter_0.WriteAttributeString("draw", "fill", null, "bitmap");
			}
			int num = shape_.method_26().Index + shape_.Index + 1;
			xmlTextWriter_0.WriteAttributeString("draw", "fill-image-name", null, "D" + num);
			if (!shape_.bool_0)
			{
				xmlTextWriter_0.WriteAttributeString("style", "repeat", null, "stretch");
			}
		}
		MsoLineFormat lineFormat = shape_.LineFormat;
		if (lineFormat.IsVisible)
		{
			xmlTextWriter_0.WriteAttributeString("draw", "stroke", null, "solid");
			xmlTextWriter_0.WriteAttributeString("svg", "stroke-width", null, Class1516.smethod_42(shape_.method_25().method_75(), (int)lineFormat.Weight));
			xmlTextWriter_0.WriteAttributeString("svg", "stroke-color", null, Class1516.smethod_9(lineFormat.ForeColor));
			xmlTextWriter_0.WriteAttributeString("svg", "stroke-opacity", null, Class1516.smethod_27(lineFormat.method_2()));
		}
		MsoTextFrame textFrame = shape_.TextFrame;
		if (!textFrame.IsAutoMargin)
		{
			xmlTextWriter_0.WriteAttributeString("fo", "padding-top", null, Class1516.smethod_42(shape_.method_25().method_75(), textFrame.method_5()));
			xmlTextWriter_0.WriteAttributeString("fo", "padding-bottom", null, Class1516.smethod_42(shape_.method_25().method_75(), textFrame.method_7()));
			xmlTextWriter_0.WriteAttributeString("fo", "padding-left", null, Class1516.smethod_42(shape_.method_25().method_75(), textFrame.method_1()));
			xmlTextWriter_0.WriteAttributeString("fo", "padding-right", null, Class1516.smethod_42(shape_.method_25().method_75(), textFrame.method_3()));
			xmlTextWriter_0.WriteAttributeString("draw", "auto-grow-width", null, "false");
			xmlTextWriter_0.WriteAttributeString("draw", "auto-grow-height", null, "false");
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_15(Class1496 class1496_0, Style style_0)
	{
		xmlTextWriter_0.WriteStartElement("style:table-cell-properties");
		if (class1496_0.bool_2)
		{
			if (style_0.method_9())
			{
				method_16(style_0.Borders[BorderType.LeftBorder], "fo", "border-left");
				method_16(style_0.Borders[BorderType.RightBorder], "fo", "border-right");
				method_16(style_0.Borders[BorderType.TopBorder], "fo", "border-top");
				method_16(style_0.Borders[BorderType.BottomBorder], "fo", "border-bottom");
				method_16(style_0.Borders[BorderType.DiagonalUp], "style", "diagonal-bl-tr");
				method_16(style_0.Borders[BorderType.DiagonalDown], "style", "diagonal-tl-br");
			}
			else
			{
				xmlTextWriter_0.WriteAttributeString("style", "border", null, "none");
			}
		}
		TextAlignmentType horizontalAlignment = style_0.HorizontalAlignment;
		if (class1496_0.bool_3)
		{
			int rotationAngle = style_0.RotationAngle;
			string text = null;
			string value = "ltr";
			if (rotationAngle != 0)
			{
				if (rotationAngle != 255)
				{
					text = ((rotationAngle >= 0) ? rotationAngle.ToString() : (360 + rotationAngle).ToString());
				}
				else
				{
					value = "ttb";
					text = "0";
				}
				xmlTextWriter_0.WriteAttributeString("style", "rotation-angle", null, text);
				xmlTextWriter_0.WriteAttributeString("style", "rotation-align", null, "none");
				xmlTextWriter_0.WriteAttributeString("style", "direction", null, value);
			}
			if (style_0.ShrinkToFit)
			{
				xmlTextWriter_0.WriteAttributeString("style", "shrink-to-fit", null, "true");
			}
			if (style_0.IsTextWrapped)
			{
				xmlTextWriter_0.WriteAttributeString("fo", "wrap-option", null, "wrap");
			}
			string value2 = null;
			TextAlignmentType verticalAlignment = style_0.VerticalAlignment;
			if (verticalAlignment != TextAlignmentType.General)
			{
				switch (verticalAlignment)
				{
				case TextAlignmentType.Top:
					value2 = "top";
					break;
				case TextAlignmentType.Bottom:
					value2 = "bottom";
					break;
				case TextAlignmentType.Center:
					value2 = "middle";
					break;
				}
				xmlTextWriter_0.WriteAttributeString("style", "vertical-align", null, value2);
			}
			if (horizontalAlignment == TextAlignmentType.Fill)
			{
				xmlTextWriter_0.WriteAttributeString("style", "repeat-content", null, "true");
			}
		}
		if (class1496_0.bool_0)
		{
			Color foregroundColor = style_0.ForegroundColor;
			if (style_0.Pattern != 0 && !foregroundColor.IsEmpty)
			{
				string value3 = Class1516.smethod_9(foregroundColor);
				xmlTextWriter_0.WriteAttributeString("fo", "background-color", null, value3);
			}
			else
			{
				xmlTextWriter_0.WriteAttributeString("fo", "background-color", null, "transparent");
			}
		}
		if (class1496_0.bool_1 && (style_0.Name == null || style_0.method_27()))
		{
			if (style_0.IsFormulaHidden)
			{
				if (style_0.IsLocked)
				{
					xmlTextWriter_0.WriteAttributeString("style", "cell-protect", null, "protected formula-hidden");
				}
				else
				{
					xmlTextWriter_0.WriteAttributeString("style", "cell-protect", null, "formula-hidden");
				}
			}
			else if (style_0.IsLocked)
			{
				xmlTextWriter_0.WriteAttributeString("style", "cell-protect", null, "protected");
			}
			else
			{
				xmlTextWriter_0.WriteAttributeString("style", "cell-protect", null, "none");
			}
		}
		xmlTextWriter_0.WriteEndElement();
		if (class1496_0.bool_3)
		{
			method_17(horizontalAlignment, style_0);
		}
	}

	internal void method_16(Border border_0, string string_0, string string_1)
	{
		if (border_0.LineStyle != 0)
		{
			string text = Class1516.smethod_17(border_0.LineStyle);
			if (!border_0.InternalColor.method_2())
			{
				text += Class1516.smethod_9(border_0.Color);
			}
			xmlTextWriter_0.WriteAttributeString(string_0, string_1, null, text);
		}
	}

	[Attribute0(true)]
	private void method_17(TextAlignmentType textAlignmentType_0, Style style_0)
	{
		xmlTextWriter_0.WriteStartElement("style:paragraph-properties");
		string text = null;
		switch (textAlignmentType_0)
		{
		case TextAlignmentType.Center:
		case TextAlignmentType.CenterAcross:
			text = "center";
			break;
		case TextAlignmentType.Distributed:
		case TextAlignmentType.Justify:
			text = "justify";
			break;
		case TextAlignmentType.Fill:
		case TextAlignmentType.Left:
			text = "start";
			break;
		case TextAlignmentType.Right:
			text = "end";
			break;
		}
		string text2 = null;
		if (textAlignmentType_0 == TextAlignmentType.Left)
		{
			double double_ = (double)style_0.IndentLevel * 0.353;
			text2 = Class1516.smethod_15(double_) + "cm";
		}
		if (text2 != null)
		{
			if (text != null)
			{
				xmlTextWriter_0.WriteAttributeString("fo", "text-align", null, text);
				xmlTextWriter_0.WriteAttributeString("fo", "margin-left", null, text2);
			}
			else
			{
				xmlTextWriter_0.WriteAttributeString("fo", "margin-left", null, text2);
			}
		}
		else if (text != null)
		{
			xmlTextWriter_0.WriteAttributeString("fo", "text-align", null, text);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_18(Class1501 class1501_0, bool bool_0)
	{
		FontUnderlineType underline = class1501_0.Underline;
		xmlTextWriter_0.WriteStartElement("style:text-properties ");
		if (bool_0 || (!Class1516.smethod_0(class1501_0.Name) && class1501_0.font_0.IsModified(StyleModifyFlag.FontName)))
		{
			xmlTextWriter_0.WriteAttributeString("style", "font-name", null, class1501_0.Name);
			xmlTextWriter_0.WriteAttributeString("style", "font-name-asian", null, class1501_0.Name);
		}
		if (class1501_0.IsBold)
		{
			xmlTextWriter_0.WriteAttributeString("fo", "font-weight", null, "bold");
			xmlTextWriter_0.WriteAttributeString("style", "font-weight-asian", null, "bold");
			xmlTextWriter_0.WriteAttributeString("style", "font-weight-complex", null, "bold");
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("fo", "font-weight", null, "normal");
			xmlTextWriter_0.WriteAttributeString("style", "font-weight-asian", null, "normal");
			xmlTextWriter_0.WriteAttributeString("style", "font-weight-complex", null, "normal");
		}
		if (class1501_0.IsItalic)
		{
			xmlTextWriter_0.WriteAttributeString("fo", "font-style", null, "italic");
			xmlTextWriter_0.WriteAttributeString("style", "font-style-asian", null, "italic");
			xmlTextWriter_0.WriteAttributeString("style", "font-style-complex", null, "italic");
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("fo", "font-style", null, "normal");
			xmlTextWriter_0.WriteAttributeString("style", "font-style-asian", null, "normal");
			xmlTextWriter_0.WriteAttributeString("style", "font-style-complex", null, "normal");
		}
		if (class1501_0.IsStrikeout)
		{
			xmlTextWriter_0.WriteAttributeString("style", "text-line-through-style", null, "solid");
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("style", "text-line-through-style", null, "none");
		}
		if (class1501_0.Size != 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("fo", "font-size", null, Class1516.smethod_12(class1501_0.Size) + "pt");
			xmlTextWriter_0.WriteAttributeString("style", "font-size-asian", null, Class1516.smethod_12(class1501_0.Size) + "pt");
			xmlTextWriter_0.WriteAttributeString("style", "font-size-complex", null, Class1516.smethod_12(class1501_0.Size) + "pt");
		}
		if (!class1501_0.bool_5)
		{
			string value = Class1516.smethod_9(class1501_0.Color);
			xmlTextWriter_0.WriteAttributeString("fo", "color", null, value);
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("style", "use-window-font-color", null, "true");
		}
		switch (underline)
		{
		default:
			xmlTextWriter_0.WriteAttributeString("style", "text-underline-style", null, "none");
			break;
		case FontUnderlineType.Single:
		case FontUnderlineType.Accounting:
			xmlTextWriter_0.WriteAttributeString("style", "text-underline-style", null, "solid");
			xmlTextWriter_0.WriteAttributeString("style", "text-underline-type", null, "single");
			break;
		case FontUnderlineType.Double:
		case FontUnderlineType.DoubleAccounting:
			xmlTextWriter_0.WriteAttributeString("style", "text-underline-style", null, "solid");
			xmlTextWriter_0.WriteAttributeString("style", "text-underline-type", null, "double");
			break;
		}
		if (class1501_0.IsSuperscript)
		{
			xmlTextWriter_0.WriteAttributeString("style", "text-position", null, "33% 58%");
		}
		if (class1501_0.IsSubscript)
		{
			xmlTextWriter_0.WriteAttributeString("style", "text-position", null, "-33% 58%");
		}
		xmlTextWriter_0.WriteEndElement();
	}
}
