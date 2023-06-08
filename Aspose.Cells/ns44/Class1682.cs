using System.Drawing;
using Aspose.Cells;
using ns2;

namespace ns44;

internal class Class1682
{
	public static string smethod_0(int int_0)
	{
		return int_0 switch
		{
			0 => "General", 
			1 => "0", 
			2 => "0.00", 
			3 => "#,##0", 
			4 => "#,##0.00", 
			5 => "$#,##0_);($#,##0)", 
			6 => "$#,##0_);[Red]($#,##0)", 
			7 => "$#,##0.00_);($#,##0.00)", 
			8 => "$#,##0.00_);[Red]($#,##0.00)", 
			9 => "0%", 
			10 => "0.00%", 
			11 => "0.00E+00", 
			12 => "# ?/?", 
			13 => "# ??/??", 
			14 => "M/D/YYYY", 
			15 => "D-MMM-YY", 
			16 => "D-MMM", 
			17 => "MMM-YY", 
			18 => "h:mm AM/PM", 
			19 => "h:mm:ss AM/PM", 
			20 => "h:mm", 
			21 => "h:mm:ss", 
			22 => "M/D/YY h:mm", 
			37 => "_(#,##0_);(#,##0)", 
			38 => "_(#,##0_);[Red](#,##0)", 
			39 => "_(#,##0.00_);(#,##0.00)", 
			40 => "_(#,##0.00_);[Red](#,##0.00)", 
			41 => "_($* #,##0_);_($* (#,##0);_($*-_);_(@_)", 
			42 => "_(* #,##0_);_(* (#,##0);_(*-_);_(@_)", 
			43 => "_($* #,##0.00_);_($* (#,##0.00);_($*-??_);_(@_)", 
			44 => "_(* #,##0.00_);_(* (#,##0.00);_(*-??_);_(@_)", 
			45 => "mm:ss", 
			46 => "[h]:mm:", 
			47 => "mm:ss.", 
			48 => "##0.0E+", 
			49 => "@", 
			_ => null, 
		};
	}

	internal static Style smethod_1(BuiltinStyleType builtinStyleType_0, WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_11(bool_0: false);
		Style defaultStyle = worksheetCollection_0.DefaultStyle;
		switch (builtinStyleType_0)
		{
		case BuiltinStyleType.Normal:
			style.Copy(defaultStyle);
			style.method_3("Normal");
			return style;
		case BuiltinStyleType.Comma:
			style.Number = 43;
			style.method_3("Comma");
			return style;
		case BuiltinStyleType.Currency:
			style.Number = 44;
			style.method_3("Currency");
			return style;
		case BuiltinStyleType.Percent:
			style.Number = 9;
			style.method_3("Percent");
			return style;
		case BuiltinStyleType.Comma1:
			style.Number = 41;
			style.method_3("Comma [0]");
			return style;
		case BuiltinStyleType.Currency1:
			style.Number = 42;
			style.method_3("Currency [0]");
			return style;
		case BuiltinStyleType.Hyperlink:
			style.method_3("Hyperlink");
			style.Font.method_14(defaultStyle.Font.Name, defaultStyle.Font.method_23());
			style.Font.Size = defaultStyle.Font.Size;
			style.Font.InternalColor.SetColor(ColorType.RGB, Color.Blue.ToArgb());
			style.method_36(StyleModifyFlag.FontColor);
			style.Font.Underline = FontUnderlineType.Single;
			return style;
		case BuiltinStyleType.FollowedHyperlink:
			style.method_3("Followed Hyperlink");
			style.Font.method_14(defaultStyle.Font.Name, defaultStyle.Font.method_23());
			style.Font.Size = defaultStyle.Font.Size;
			style.Font.InternalColor.SetColor(ColorType.RGB, Color.Blue.ToArgb());
			style.method_36(StyleModifyFlag.FontColor);
			style.Font.Underline = FontUnderlineType.Single;
			return style;
		case BuiltinStyleType.Note:
			style.method_3("Note");
			style.Font.method_14(defaultStyle.Font.Name, Enum193.const_2);
			style.Font.Size = defaultStyle.Font.Size;
			style.Font.method_12(2);
			style.Font.InternalColor.SetColor(ColorType.Theme, 1);
			style.method_36(StyleModifyFlag.FontColor);
			style.Pattern = BackgroundType.Solid;
			style.ForeInternalColor.SetColor(ColorType.RGB, 16777164);
			style.method_36(StyleModifyFlag.ForegroundColor);
			style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
			style.Borders[BorderType.LeftBorder].InternalColor.SetColor(ColorType.RGB, 11711154);
			style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
			style.Borders[BorderType.TopBorder].InternalColor.SetColor(ColorType.RGB, 11711154);
			style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
			style.Borders[BorderType.RightBorder].InternalColor.SetColor(ColorType.RGB, 11711154);
			style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
			style.Borders[BorderType.BottomBorder].InternalColor.SetColor(ColorType.RGB, 11711154);
			return style;
		case BuiltinStyleType.WarningText:
			style.method_3("Warning Text");
			style.Font.method_14(defaultStyle.Font.Name, Enum193.const_2);
			style.Font.Size = defaultStyle.Font.Size;
			style.Font.method_12(2);
			style.Font.InternalColor.SetColor(ColorType.RGB, Color.Red.ToArgb());
			style.method_36(StyleModifyFlag.FontColor);
			return style;
		default:
			return null;
		case BuiltinStyleType.Title:
			style.method_3("Title");
			style.Font.method_14("Cambria", Enum193.const_1);
			style.Font.IsBold = true;
			style.Font.Size = 18;
			style.Font.method_12(2);
			style.Font.InternalColor.SetColor(ColorType.Theme, 3);
			style.method_36(StyleModifyFlag.FontColor);
			return style;
		case BuiltinStyleType.Header1:
			style.method_3("Header 1");
			style.Font.method_14(defaultStyle.Font.Name, defaultStyle.Font.method_23());
			style.Font.IsBold = true;
			style.Font.Size = 15;
			style.Font.method_12(2);
			style.Font.InternalColor.SetColor(ColorType.Theme, 3);
			style.method_36(StyleModifyFlag.FontColor);
			style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thick;
			style.Borders[BorderType.BottomBorder].InternalColor.SetColor(ColorType.Theme, 4);
			style.method_36(StyleModifyFlag.BottomBorder);
			return style;
		case BuiltinStyleType.Header2:
			style.method_3("Header 2");
			style.Font.method_14(defaultStyle.Font.Name, defaultStyle.Font.method_23());
			style.Font.IsBold = true;
			style.Font.Size = 13;
			style.Font.method_12(2);
			style.Font.InternalColor.SetColor(ColorType.Theme, 3);
			style.method_36(StyleModifyFlag.FontColor);
			style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thick;
			style.Borders[BorderType.BottomBorder].InternalColor.SetColor(ColorType.Theme, 4);
			style.Borders[BorderType.BottomBorder].InternalColor.Tint = 0.499984740745262;
			style.method_36(StyleModifyFlag.BottomBorder);
			return style;
		case BuiltinStyleType.Header3:
			style.method_3("Header 3");
			style.Font.method_14(defaultStyle.Font.Name, defaultStyle.Font.method_23());
			style.Font.IsBold = true;
			style.Font.Size = 11;
			style.Font.method_12(2);
			style.Font.InternalColor.SetColor(ColorType.Theme, 3);
			style.method_36(StyleModifyFlag.FontColor);
			style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Medium;
			style.Borders[BorderType.BottomBorder].InternalColor.SetColor(ColorType.Theme, 4);
			style.Borders[BorderType.BottomBorder].InternalColor.Tint = 0.3999755851924192;
			style.method_36(StyleModifyFlag.BottomBorder);
			return style;
		case BuiltinStyleType.Header4:
			style.method_3("Header 4");
			style.Font.method_14(defaultStyle.Font.Name, defaultStyle.Font.method_23());
			style.Font.IsBold = true;
			style.Font.Size = defaultStyle.Font.Size;
			style.Font.method_12(2);
			style.Font.InternalColor.SetColor(ColorType.Theme, 3);
			style.method_36(StyleModifyFlag.FontColor);
			return style;
		case BuiltinStyleType.Input:
			style.method_3("Input");
			style.Font.IsBold = true;
			style.Font.method_14(defaultStyle.Font.Name, Enum193.const_2);
			style.Font.Size = defaultStyle.Font.Size;
			style.Font.method_12(2);
			style.Font.InternalColor.SetColor(ColorType.RGB, 4145014);
			style.method_36(StyleModifyFlag.FontColor);
			style.Pattern = BackgroundType.Solid;
			style.ForeInternalColor.SetColor(ColorType.RGB, 16764057);
			style.method_36(StyleModifyFlag.ForegroundColor);
			style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
			style.Borders[BorderType.LeftBorder].InternalColor.SetColor(ColorType.RGB, 8355711);
			style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
			style.Borders[BorderType.TopBorder].InternalColor.SetColor(ColorType.RGB, 8355711);
			style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
			style.Borders[BorderType.RightBorder].InternalColor.SetColor(ColorType.RGB, 8355711);
			style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
			style.Borders[BorderType.BottomBorder].InternalColor.SetColor(ColorType.RGB, 8355711);
			return style;
		case BuiltinStyleType.Output:
			style.method_3("Output");
			style.Font.IsBold = true;
			style.Font.method_14(defaultStyle.Font.Name, Enum193.const_2);
			style.Font.Size = defaultStyle.Font.Size;
			style.Font.method_12(2);
			style.Font.InternalColor.SetColor(ColorType.RGB, 4144959);
			style.method_36(StyleModifyFlag.FontColor);
			style.Pattern = BackgroundType.Solid;
			style.ForeInternalColor.SetColor(ColorType.RGB, 15921906);
			style.method_36(StyleModifyFlag.ForegroundColor);
			style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
			style.Borders[BorderType.LeftBorder].InternalColor.SetColor(ColorType.RGB, 4144959);
			style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
			style.Borders[BorderType.TopBorder].InternalColor.SetColor(ColorType.RGB, 4144959);
			style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
			style.Borders[BorderType.RightBorder].InternalColor.SetColor(ColorType.RGB, 4144959);
			style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
			style.Borders[BorderType.BottomBorder].InternalColor.SetColor(ColorType.RGB, 4144959);
			return style;
		case BuiltinStyleType.Calculation:
			style.method_3("Calculation");
			style.Font.IsBold = true;
			style.Font.method_14(defaultStyle.Font.Name, Enum193.const_2);
			style.Font.Size = defaultStyle.Font.Size;
			style.Font.method_12(2);
			style.Font.InternalColor.SetColor(ColorType.RGB, 16416000);
			style.method_36(StyleModifyFlag.FontColor);
			style.Pattern = BackgroundType.Solid;
			style.ForeInternalColor.SetColor(ColorType.RGB, 15921906);
			style.method_36(StyleModifyFlag.ForegroundColor);
			style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
			style.Borders[BorderType.LeftBorder].InternalColor.SetColor(ColorType.RGB, 4144959);
			style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
			style.Borders[BorderType.TopBorder].InternalColor.SetColor(ColorType.RGB, 4144959);
			style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
			style.Borders[BorderType.RightBorder].InternalColor.SetColor(ColorType.RGB, 4144959);
			style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
			style.Borders[BorderType.BottomBorder].InternalColor.SetColor(ColorType.RGB, 4144959);
			return style;
		case BuiltinStyleType.CheckCell:
			style.method_3("Check Cell");
			style.Font.IsBold = true;
			style.Font.method_14(defaultStyle.Font.Name, Enum193.const_2);
			style.Font.Size = defaultStyle.Font.Size;
			style.Font.method_12(2);
			style.Font.InternalColor.SetColor(ColorType.Theme, 0);
			style.method_36(StyleModifyFlag.FontColor);
			style.Pattern = BackgroundType.Solid;
			style.ForeInternalColor.SetColor(ColorType.RGB, 10855845);
			style.method_36(StyleModifyFlag.ForegroundColor);
			style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Double;
			style.Borders[BorderType.LeftBorder].InternalColor.SetColor(ColorType.RGB, 4144959);
			style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Double;
			style.Borders[BorderType.TopBorder].InternalColor.SetColor(ColorType.RGB, 4144959);
			style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Double;
			style.Borders[BorderType.RightBorder].InternalColor.SetColor(ColorType.RGB, 4144959);
			style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Double;
			style.Borders[BorderType.BottomBorder].InternalColor.SetColor(ColorType.RGB, 4144959);
			return style;
		case BuiltinStyleType.LinkedCell:
			style.method_3("Linked Cell");
			style.Font.method_14(defaultStyle.Font.Name, Enum193.const_2);
			style.Font.Size = defaultStyle.Font.Size;
			style.Font.method_12(2);
			style.Font.InternalColor.SetColor(ColorType.RGB, 16416000);
			style.method_36(StyleModifyFlag.FontColor);
			style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Double;
			style.Borders[BorderType.BottomBorder].InternalColor.SetColor(ColorType.RGB, 16744449);
			style.method_36(StyleModifyFlag.BottomBorder);
			return style;
		case BuiltinStyleType.Total:
			style.method_3("Total");
			style.Font.method_14(defaultStyle.Font.Name, defaultStyle.Font.method_23());
			style.Font.IsBold = true;
			style.Font.Size = defaultStyle.Font.Size;
			style.Font.method_12(2);
			style.Font.InternalColor.SetColor(ColorType.Theme, 3);
			style.method_36(StyleModifyFlag.FontColor);
			style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Double;
			style.Borders[BorderType.BottomBorder].InternalColor.SetColor(ColorType.Theme, 4);
			style.method_36(StyleModifyFlag.BottomBorder);
			style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
			style.Borders[BorderType.TopBorder].InternalColor.SetColor(ColorType.Theme, 4);
			style.method_36(StyleModifyFlag.TopBorder);
			return style;
		case BuiltinStyleType.Good:
			style.method_3("Good");
			style.Font.method_14(defaultStyle.Font.Name, defaultStyle.Font.method_23());
			style.Font.Size = defaultStyle.Font.Size;
			style.Font.InternalColor.SetColor(ColorType.RGB, 10249472);
			style.method_36(StyleModifyFlag.FontColor);
			style.Pattern = BackgroundType.Solid;
			style.ForeInternalColor.SetColor(ColorType.RGB, 16771996);
			style.method_36(StyleModifyFlag.ForegroundColor);
			return style;
		case BuiltinStyleType.Bad:
			style.method_3("Bad");
			style.Font.method_14(defaultStyle.Font.Name, defaultStyle.Font.method_23());
			style.Font.Size = defaultStyle.Font.Size;
			style.Font.InternalColor.SetColor(ColorType.RGB, 10223622);
			style.method_36(StyleModifyFlag.FontColor);
			style.Pattern = BackgroundType.Solid;
			style.ForeInternalColor.SetColor(ColorType.RGB, 16762830);
			style.method_36(StyleModifyFlag.ForegroundColor);
			return style;
		case BuiltinStyleType.Neutral:
			style.method_3("Neutral");
			style.Font.method_14(defaultStyle.Font.Name, defaultStyle.Font.method_23());
			style.Font.Size = defaultStyle.Font.Size;
			style.Font.InternalColor.SetColor(ColorType.RGB, 24832);
			style.method_36(StyleModifyFlag.FontColor);
			style.Pattern = BackgroundType.Solid;
			style.ForeInternalColor.SetColor(ColorType.RGB, 13037518);
			style.method_36(StyleModifyFlag.ForegroundColor);
			return style;
		case BuiltinStyleType.Accent1:
			smethod_3(style, defaultStyle, 0);
			smethod_2(style, 4, 0.0);
			style.method_3("Accent1");
			return style;
		case BuiltinStyleType.TwentyPercentAccent1:
			smethod_3(style, defaultStyle, 1);
			smethod_2(style, 4, 0.7999816888943144);
			style.method_3("20% - Accent1");
			return style;
		case BuiltinStyleType.FortyPercentAccent1:
			smethod_3(style, defaultStyle, 1);
			smethod_2(style, 4, 0.5999938962981048);
			style.method_3("40% - Accent1");
			return style;
		case BuiltinStyleType.SixtyPercentAccent1:
			smethod_3(style, defaultStyle, 0);
			smethod_2(style, 4, 0.3999755851924192);
			style.method_3("60% - Accent1");
			return style;
		case BuiltinStyleType.Accent2:
			smethod_3(style, defaultStyle, 0);
			smethod_2(style, 5, 0.0);
			style.method_3("Accent2");
			return style;
		case BuiltinStyleType.TwentyPercentAccent2:
			smethod_3(style, defaultStyle, 1);
			smethod_2(style, 5, 0.7999816888943144);
			style.method_3("20% - Accent2");
			return style;
		case BuiltinStyleType.FortyPercentAccent2:
			smethod_3(style, defaultStyle, 1);
			smethod_2(style, 5, 0.5999938962981048);
			style.method_3("40% - Accent2");
			return style;
		case BuiltinStyleType.SixtyPercentAccent2:
			smethod_3(style, defaultStyle, 0);
			smethod_2(style, 5, 0.3999755851924192);
			style.method_3("60% - Accent2");
			return style;
		case BuiltinStyleType.Accent3:
			smethod_3(style, defaultStyle, 0);
			smethod_2(style, 6, 0.0);
			style.method_3("Accent3");
			return style;
		case BuiltinStyleType.TwentyPercentAccent3:
			smethod_3(style, defaultStyle, 1);
			smethod_2(style, 6, 79998168889431440.0);
			style.method_3("20% - Accent3");
			return style;
		case BuiltinStyleType.FortyPercentAccent3:
			smethod_3(style, defaultStyle, 1);
			smethod_2(style, 6, 0.5999938962981048);
			style.method_3("40% - Accent3");
			return style;
		case BuiltinStyleType.SixtyPercentAccent3:
			smethod_3(style, defaultStyle, 0);
			smethod_2(style, 6, 0.3999755851924192);
			style.method_3("60% - Accent3");
			return style;
		case BuiltinStyleType.Accent4:
			smethod_3(style, defaultStyle, 0);
			smethod_2(style, 7, 0.0);
			style.method_3("Accent4");
			return style;
		case BuiltinStyleType.TwentyPercentAccent4:
			smethod_3(style, defaultStyle, 1);
			smethod_2(style, 7, 0.7999816888943144);
			style.method_3("20% - Accent4");
			return style;
		case BuiltinStyleType.FortyPercentAccent4:
			smethod_3(style, defaultStyle, 1);
			smethod_2(style, 7, 0.5999938962981048);
			style.method_3("40% - Accent4");
			return style;
		case BuiltinStyleType.SixtyPercentAccent4:
			smethod_3(style, defaultStyle, 0);
			smethod_2(style, 7, 0.3999755851924192);
			style.method_3("60% - Accent4");
			return style;
		case BuiltinStyleType.Accent5:
			smethod_3(style, defaultStyle, 0);
			smethod_2(style, 8, 0.0);
			style.method_3("Accent5");
			return style;
		case BuiltinStyleType.TwentyPercentAccent5:
			smethod_3(style, defaultStyle, 1);
			smethod_2(style, 8, 0.7999816888943144);
			style.method_3("20% - Accent5");
			return style;
		case BuiltinStyleType.FortyPercentAccent5:
			smethod_3(style, defaultStyle, 1);
			smethod_2(style, 8, 0.5999938962981048);
			style.method_3("40% - Accent5");
			return style;
		case BuiltinStyleType.SixtyPercentAccent5:
			smethod_3(style, defaultStyle, 0);
			smethod_2(style, 8, 0.3999755851924192);
			style.method_3("60% - Accent5");
			return style;
		case BuiltinStyleType.Accent6:
			smethod_3(style, defaultStyle, 0);
			smethod_2(style, 9, 0.0);
			style.method_3("Accent6");
			return style;
		case BuiltinStyleType.TwentyPercentAccent6:
			smethod_3(style, defaultStyle, 1);
			smethod_2(style, 9, 0.7999816888943144);
			style.method_3("20% - Accent6");
			return style;
		case BuiltinStyleType.FortyPercentAccent6:
			smethod_3(style, defaultStyle, 1);
			smethod_2(style, 9, 0.5999938962981048);
			style.method_3("40% - Accent6");
			return style;
		case BuiltinStyleType.SixtyPercentAccent6:
			smethod_3(style, defaultStyle, 0);
			smethod_2(style, 9, 0.3999755851924192);
			style.method_3("60% - Accent6");
			return style;
		case BuiltinStyleType.ExplanatoryText:
			style.method_3("Explanatory Text");
			style.Font.IsItalic = true;
			style.Font.method_14(defaultStyle.Font.Name, Enum193.const_2);
			style.Font.Size = defaultStyle.Font.Size;
			style.Font.method_12(2);
			style.Font.InternalColor.SetColor(ColorType.RGB, 8355711);
			style.method_36(StyleModifyFlag.FontColor);
			return style;
		}
	}

	internal static void smethod_2(Style style_0, int int_0, double double_0)
	{
		style_0.Pattern = BackgroundType.Solid;
		style_0.method_36(StyleModifyFlag.ForegroundColor);
		style_0.ForeInternalColor.SetColor(ColorType.Theme, int_0);
		style_0.ForeInternalColor.Tint = double_0;
	}

	internal static void smethod_3(Style style_0, Style style_1, int int_0)
	{
		style_0.Font.Size = style_1.Font.Size;
		style_0.Font.method_14(style_1.Font.Name, Enum193.const_2);
		style_0.Font.method_12(style_1.Font.method_11());
		style_0.Font.InternalColor.SetColor(ColorType.Theme, int_0);
		style_0.method_36(StyleModifyFlag.FontColor);
	}
}
