using System;
using System.Collections;
using System.Text;
using Aspose.Cells;
using ns16;
using ns2;

namespace ns8;

internal class Class1469
{
	private Class1478 class1478_0;

	private Style style_0;

	internal Class1469(Class1478 class1478_1)
	{
		class1478_0 = class1478_1;
		style_0 = class1478_0.method_7();
	}

	internal void Write(Class1487 class1487_0)
	{
		class1487_0.Write("tr");
		class1487_0.method_8(" {mso-height-source:auto;");
		class1487_0.method_8(" mso-ruby-visibility:none;}");
		class1487_0.method_8("col");
		class1487_0.method_8(" {mso-width-source:auto;");
		class1487_0.method_8(" mso-ruby-visibility:none;}");
		class1487_0.method_8("br");
		class1487_0.method_8(" {mso-data-placement:same-cell;}");
		class1487_0.method_8("ruby");
		class1487_0.method_8(" {ruby-align:left;}");
		method_0(class1487_0);
		method_1(class1487_0);
		method_2(class1487_0);
		method_3(class1487_0);
		class1487_0.Flush();
	}

	private void method_0(Class1487 class1487_0)
	{
		Style style = style_0;
		class1487_0.method_8(".style0");
		class1487_0.method_8(" {");
		method_6(class1487_0, style, bool_0: true);
		method_7(class1487_0, style);
		method_9(class1487_0, style);
		method_10(class1487_0, style.Font, bool_0: true);
		method_11(class1487_0, style);
		method_5(class1487_0, style);
		class1487_0.method_8(" mso-style-name:Normal;");
		class1487_0.method_8(" mso-style-id:0;}");
	}

	private void method_1(Class1487 class1487_0)
	{
		ArrayList arrayList_ = class1478_0.method_4().arrayList_0;
		for (int i = 0; i < arrayList_.Count; i++)
		{
			Font font_ = (Font)arrayList_[i];
			class1487_0.method_8(".font" + Class1618.smethod_80(i));
			class1487_0.method_8(" {");
			method_10(class1487_0, font_, bool_0: true);
			class1487_0.Write(" }");
		}
	}

	private void method_2(Class1487 class1487_0)
	{
		Style style = style_0;
		class1487_0.method_8("td");
		class1487_0.method_8(" {mso-style-parent:style0;");
		method_6(class1487_0, style, bool_0: true);
		method_7(class1487_0, style);
		method_9(class1487_0, style);
		method_10(class1487_0, style.Font, bool_0: true);
		method_11(class1487_0, style);
		method_5(class1487_0, style);
		class1487_0.method_8(" mso-ignore:padding;}");
	}

	private void method_3(Class1487 class1487_0)
	{
		Class1683 @class = class1478_0.workbook_0.Worksheets.method_58();
		for (int i = 0; i < @class.Count; i++)
		{
			Style style_ = @class[i];
			method_4(class1487_0, style_, i);
		}
	}

	private void method_4(Class1487 class1487_0, Style style_1, int int_0)
	{
		if (!style_1.method_10())
		{
			class1487_0.method_8(".style" + Class1618.smethod_80(int_0));
		}
		else
		{
			class1487_0.method_8(".x" + Class1618.smethod_80(int_0));
		}
		class1487_0.method_8(" {");
		if (style_1.method_10())
		{
			string string_ = " mso-style-parent:style0;";
			if (style_1.method_12() > 0)
			{
				string_ = " mso-style-parent:style" + Class1618.smethod_80(style_1.method_12()) + ";";
			}
			class1487_0.method_8(string_);
		}
		method_6(class1487_0, style_1, style_1.method_10());
		method_7(class1487_0, style_1);
		method_9(class1487_0, style_1);
		if (style_1.method_40() != null)
		{
			method_10(class1487_0, style_1.Font, bool_0: false);
		}
		if (style_1.method_4() != null)
		{
			method_11(class1487_0, style_1);
		}
		method_5(class1487_0, style_1);
		if (!style_1.method_10())
		{
			string name = style_1.Name;
			if (name != null && name.Length > 0)
			{
				class1487_0.method_8(" mso-style-name:" + name + ";");
			}
		}
		class1487_0.method_8(" }");
	}

	private void method_5(Class1487 class1487_0, Style style_1)
	{
		class1487_0.method_8(" mso-protection:" + (style_1.IsLocked ? "locked " : "unlocked ") + (style_1.IsFormulaHidden ? "hidden" : "visible") + ";");
	}

	private void method_6(Class1487 class1487_0, Style style_1, bool bool_0)
	{
		string text = style_1.Custom;
		if ((text == null || text.Length == 0) && style_1.Number > 0)
		{
			text = style_1.method_5().Workbook.Settings.method_3().method_8(style_1.Number);
		}
		if (text != null && text.Length > 0)
		{
			text = Class1486.smethod_15(text);
			class1487_0.method_8(" mso-number-format:\"" + text.ToString() + "\";");
		}
		else if (bool_0)
		{
			class1487_0.method_8(" mso-number-format:General;");
		}
	}

	private void method_7(Class1487 class1487_0, Style style_1)
	{
		class1487_0.method_8(" " + Class1486.smethod_10(style_1.HorizontalAlignment) + ";");
		class1487_0.method_8(" " + Class1486.smethod_11(style_1.VerticalAlignment) + ";");
		if (style_1.IsTextWrapped)
		{
			class1487_0.method_8(" white-space:normal;");
		}
		else
		{
			class1487_0.method_8(" white-space:nowrap;");
		}
		if (style_1.IndentLevel > 0)
		{
			class1487_0.method_8(" mso-char-indent-count:" + Class1618.smethod_80(style_1.IndentLevel) + ";");
			int int_ = method_8(style_1);
			switch (Class1486.smethod_10(style_1.HorizontalAlignment)[11])
			{
			case 'l':
				class1487_0.method_8(" padding-left:" + Class1618.smethod_80(int_) + "px;");
				break;
			case 'r':
				class1487_0.method_8(" padding-right:" + Class1618.smethod_80(int_) + "px;");
				break;
			}
		}
		if (style_1.RotationAngle == 255)
		{
			class1487_0.method_8(" layout-flow:vertical;");
		}
		else if (style_1.RotationAngle != 0)
		{
			class1487_0.method_8(" mso-rotate:" + Class1618.smethod_80(style_1.RotationAngle) + ";");
		}
	}

	private int method_8(Style style_1)
	{
		int num = class1478_0.method_3().method_0(style_1, "O");
		return num * style_1.IndentLevel;
	}

	public void method_9(Class1487 class1487_0, Style style_1)
	{
		string text = "auto";
		string text2 = "auto";
		string text3 = "";
		switch (style_1.Pattern)
		{
		default:
			if (!style_1.BackgroundInternalColor.method_2())
			{
				text = "#" + Class1618.smethod_64(style_1.BackgroundColor);
			}
			if (!style_1.ForeInternalColor.method_2())
			{
				text2 = "#" + Class1618.smethod_64(style_1.ForegroundColor);
			}
			text3 = " " + Class1130.smethod_1(style_1.Pattern);
			break;
		case BackgroundType.Solid:
			if (!style_1.ForeInternalColor.method_2())
			{
				text = "#" + Class1618.smethod_64(style_1.ForegroundColor);
			}
			text3 = " none";
			break;
		case BackgroundType.None:
			break;
		}
		class1487_0.method_8(" background:" + text + ";");
		class1487_0.method_8(" mso-pattern:" + text2 + text3 + ";");
	}

	private void method_10(Class1487 class1487_0, Font font_0, bool bool_0)
	{
		if (!font_0.InternalColor.method_2() || bool_0)
		{
			class1487_0.method_8(" color:#" + Class1618.smethod_64(font_0.Color) + ";");
		}
		class1487_0.method_8(" font-size:" + Class1618.smethod_80(font_0.Size) + "pt;");
		class1487_0.method_8(" font-weight:" + Class1618.smethod_80(font_0.Weight) + ";");
		if (font_0.IsItalic)
		{
			class1487_0.method_8(" font-style:italic;");
		}
		else
		{
			class1487_0.method_8(" font-style:normal;");
		}
		if (font_0.IsStrikeout)
		{
			class1487_0.method_8(" text-decoration:line-through;");
		}
		if (font_0.Underline != 0)
		{
			class1487_0.method_8(" " + Class1486.smethod_9(font_0.Underline));
		}
		if (font_0.method_11() != 0)
		{
			class1487_0.method_8(" font-family:\"" + font_0.Name + "\"," + Convert.ToString(font_0.method_11()) + ";");
		}
		else
		{
			class1487_0.method_8(" font-family:\"" + font_0.Name + "\";");
		}
	}

	private void method_11(Class1487 class1487_0, Style style_1)
	{
		if (style_1.method_9())
		{
			class1487_0.method_8(" border-top:" + method_12(style_1, BorderType.TopBorder) + ";");
			class1487_0.method_8(" border-right:" + method_12(style_1, BorderType.RightBorder) + ";");
			class1487_0.method_8(" border-bottom:" + method_12(style_1, BorderType.BottomBorder) + ";");
			class1487_0.method_8(" border-left:" + method_12(style_1, BorderType.LeftBorder) + ";");
			if (style_1.Borders[BorderType.DiagonalDown] != null)
			{
				class1487_0.method_8(" mso-diagonal-down:" + method_12(style_1, BorderType.DiagonalDown) + ";");
			}
			if (style_1.Borders[BorderType.DiagonalUp] != null)
			{
				class1487_0.method_8(" mso-diagonal-up:" + method_12(style_1, BorderType.DiagonalUp) + ";");
			}
		}
		else
		{
			class1487_0.method_8(" border:none;");
		}
	}

	private string method_12(Style style_1, BorderType borderType_0)
	{
		Border border = style_1.Borders[borderType_0];
		CellBorderType lineStyle = border.LineStyle;
		if (lineStyle == CellBorderType.None)
		{
			return "none";
		}
		StringBuilder stringBuilder = new StringBuilder(Class1130.smethod_0(lineStyle));
		if (!border.InternalColor.method_2())
		{
			stringBuilder.Append(" #" + Class1618.smethod_64(border.Color));
		}
		else
		{
			stringBuilder.Append(" windowtext");
		}
		return stringBuilder.ToString();
	}
}
