using System.Drawing;
using Aspose.Cells;
using ns16;

namespace ns45;

internal class Class1138
{
	internal static int int_0 = 0;

	internal static int int_1 = 3;

	internal static int int_2 = 4;

	internal static int int_3 = 5;

	internal static int int_4 = 7;

	internal static int int_5 = 8;

	internal static Style smethod_0(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsItalic = true;
		return style;
	}

	internal static Style smethod_1(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.HorizontalAlignment = TextAlignmentType.Center;
		return style;
	}

	internal static Style smethod_2(WorksheetCollection worksheetCollection_0, int int_6)
	{
		Style style = new Style(worksheetCollection_0);
		style.HorizontalAlignment = TextAlignmentType.Left;
		style.IndentLevel = int_6;
		return style;
	}

	internal static Style smethod_3(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_4(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_5(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_6(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_7(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_4, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_8(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.Color = Color.White;
		style.Font.IsBold = true;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.Black;
		return style;
	}

	internal static Style smethod_9(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_10(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_11(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.Size = 9;
		style.Font.IsBold = true;
		style.HorizontalAlignment = TextAlignmentType.Center;
		return style;
	}

	internal static Style smethod_12(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_13(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_14(WorksheetCollection worksheetCollection_0)
	{
		return smethod_8(worksheetCollection_0);
	}

	internal static Style smethod_15(WorksheetCollection worksheetCollection_0, bool bool_0)
	{
		Style style = new Style(worksheetCollection_0);
		if (bool_0)
		{
			style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
			style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
			style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
			style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		}
		return style;
	}

	internal static Style smethod_16(WorksheetCollection worksheetCollection_0, bool bool_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		if (bool_0)
		{
			style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
			style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
			style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
			style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		}
		return style;
	}

	internal static Style smethod_17(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_18(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		return style;
	}

	internal static Style smethod_19(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_20(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_5, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_21(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.Color = Color.White;
		style.Font.IsBold = true;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.Black;
		style.method_57(int_1, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_22(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_23(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_24(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_5, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_25(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_26(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_27(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_28(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_29(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_30(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_1, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_31(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_5, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_32(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_33(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.FromArgb(51, 51, 153);
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(192, 192, 192);
		return style;
	}

	internal static Style smethod_34(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_35(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_36(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_37(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.FromArgb(51, 51, 153);
		style.Font.Size = 11;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(192, 192, 192);
		style.method_57(int_0, "thick", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_38(WorksheetCollection worksheetCollection_0, bool bool_0)
	{
		Style style = new Style(worksheetCollection_0);
		if (bool_0)
		{
			style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
			style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
			style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
			style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		}
		return style;
	}

	internal static Style smethod_39(WorksheetCollection worksheetCollection_0, bool bool_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		if (bool_0)
		{
			style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
			style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
			style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
			style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		}
		return style;
	}

	internal static Style smethod_40(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.White;
		style.Font.Size = 11;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(102, 102, 153);
		style.method_57(int_0, "thick", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_5, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_41(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(192, 192, 192);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_42(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_43(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.FromArgb(102, 102, 153);
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(192, 192, 192);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thick", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_4, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_5, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_44(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_45(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_46(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_47(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_48(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.HorizontalAlignment = TextAlignmentType.Center;
		style.method_57(int_3, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_49(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.HorizontalAlignment = TextAlignmentType.Center;
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_4, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_5, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_50(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.HorizontalAlignment = TextAlignmentType.Center;
		style.method_57(int_2, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_51(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.HorizontalAlignment = TextAlignmentType.Center;
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_52(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 11;
		return style;
	}

	internal static Style smethod_53(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_0, "medium", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_54(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_0, "medium", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_55(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(51, 51, 51);
		return style;
	}

	internal static Style smethod_56(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.Color = Color.White;
		style.Font.IsItalic = true;
		style.HorizontalAlignment = TextAlignmentType.Center;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(51, 51, 51);
		return style;
	}

	internal static Style smethod_57(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.Color = Color.White;
		style.Font.IsItalic = true;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(51, 51, 51);
		return style;
	}

	internal static Style smethod_58(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thick", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_59(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_3, "medium", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "medium", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_60(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_61(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "medium", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_62(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_63(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_64(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_65(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_66(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_67(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_1, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_68(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_4, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_5, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_69(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_2, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_70(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.HorizontalAlignment = TextAlignmentType.Center;
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_71(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(255, 255, 204);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_72(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.IsItalic = true;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(255, 255, 204);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thick", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_73(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_74(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_5, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_75(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(255, 255, 204);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thick", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_5, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_76(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		return style;
	}

	internal static Style smethod_77(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_78(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		return style;
	}

	internal static Style smethod_79(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(192, 192, 192);
		return style;
	}

	internal static Style smethod_80(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.HorizontalAlignment = TextAlignmentType.Right;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(192, 192, 192);
		return style;
	}

	internal static Style smethod_81(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_82(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_83(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_4, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_5, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_84(WorksheetCollection worksheetCollection_0)
	{
		return smethod_83(worksheetCollection_0);
	}

	internal static Style smethod_85(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		return style;
	}

	internal static Style smethod_86(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_87(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 12;
		style.RotationAngle = 90;
		return style;
	}

	internal static Style smethod_88(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_89(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_90(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.Color = Color.White;
		style.Font.IsBold = true;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.Black;
		return style;
	}

	internal static Style smethod_91(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_0, "medium", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_92(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		return style;
	}

	internal static Style smethod_93(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		return style;
	}

	internal static Style smethod_94(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_95(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_96(WorksheetCollection worksheetCollection_0, CellBorderType cellBorderType_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, Class1618.smethod_35(cellBorderType_0), ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_97(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "medium", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "medium", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_98(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thick", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_99(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_0, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_100(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.FromArgb(128, 128, 128).ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.FromArgb(128, 128, 128).ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.FromArgb(128, 128, 128).ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.FromArgb(128, 128, 128).ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_101(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_102(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.FromArgb(128, 128, 128).ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.FromArgb(128, 128, 128).ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.FromArgb(128, 128, 128).ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_103(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.FromArgb(128, 128, 128).ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.FromArgb(128, 128, 128).ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.FromArgb(128, 128, 128).ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_104(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_105(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_3, "thin", ColorType.RGB, Color.FromArgb(128, 128, 128).ToArgb(), 0.0);
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(128, 128, 0);
		return style;
	}

	internal static Style smethod_106(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.FromArgb(128, 128, 0);
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(51, 51, 0);
		return style;
	}

	internal static Style smethod_107(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_108(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_109(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_110(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(128, 128, 0);
		return style;
	}

	internal static Style smethod_111(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_112(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.FromArgb(128, 0, 0).ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.FromArgb(128, 0, 0).ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_113(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_3, "thick", ColorType.RGB, Color.FromArgb(128, 0, 0).ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.FromArgb(128, 0, 0).ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_114(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.FromArgb(128, 0, 0).ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_115(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_116(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_117(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_4, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_118(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		return style;
	}

	internal static Style smethod_119(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.White;
		style.method_57(int_1, "medium", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.Black;
		return style;
	}

	internal static Style smethod_120(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		return style;
	}

	internal static Style smethod_121(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(192, 192, 192);
		return style;
	}

	internal static Style smethod_122(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_123(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.Black;
		return style;
	}

	internal static Style smethod_124(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(192, 192, 192);
		return style;
	}

	internal static Style smethod_125(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_126(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_127(WorksheetCollection worksheetCollection_0, bool bool_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		if (bool_0)
		{
			style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
			style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
			style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		}
		return style;
	}

	internal static Style smethod_128(WorksheetCollection worksheetCollection_0, bool bool_0)
	{
		Style style = new Style(worksheetCollection_0);
		if (bool_0)
		{
			style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
			style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
			style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		}
		return style;
	}

	internal static Style smethod_129(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.HorizontalAlignment = TextAlignmentType.Center;
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_130(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "medium", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "medium", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.HorizontalAlignment = TextAlignmentType.Center;
		return style;
	}

	internal static Style smethod_131(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "medium", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_132(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_3, "medium", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "medium", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "medium", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_133(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "medium", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_134(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_135(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_136(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_137(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "medium", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "medium", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_138(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_139(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.FromArgb(128, 0, 0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.FromArgb(128, 0, 0).ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.FromArgb(128, 0, 0).ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.FromArgb(128, 0, 0).ToArgb(), 0.0);
		style.method_57(int_5, "thin", ColorType.RGB, Color.FromArgb(128, 0, 0).ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_140(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.FromArgb(128, 128, 0);
		style.Font.Size = 12;
		style.RotationAngle = 90;
		style.HorizontalAlignment = TextAlignmentType.Left;
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.FromArgb(128, 0, 0).ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_141(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.FromArgb(0, 0, 0);
		style.Font.Size = 12;
		style.RotationAngle = 90;
		style.HorizontalAlignment = TextAlignmentType.Left;
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.FromArgb(128, 0, 0).ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_142(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_143(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.Color = Color.Black;
		style.HorizontalAlignment = TextAlignmentType.Left;
		return style;
	}

	internal static Style smethod_144(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_145(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_1, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_5, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(192, 192, 192);
		return style;
	}

	internal static Style smethod_146(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_147(WorksheetCollection worksheetCollection_0, bool bool_0)
	{
		Style style = new Style(worksheetCollection_0);
		if (bool_0)
		{
			style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
			style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
			style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		}
		return style;
	}

	internal static Style smethod_148(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 11;
		style.method_57(int_1, "thin", ColorType.RGB, Color.FromArgb(128, 0, 0).ToArgb(), 0.0);
		style.method_57(int_3, "thick", ColorType.RGB, Color.FromArgb(128, 0, 0).ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.FromArgb(128, 0, 0).ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_149(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 12;
		style.RotationAngle = 90;
		style.method_57(int_3, "thin", ColorType.RGB, Color.FromArgb(128, 0, 0).ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.FromArgb(128, 0, 0).ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_150(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.FromArgb(128, 0, 0).ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.FromArgb(128, 0, 0).ToArgb(), 0.0);
		style.HorizontalAlignment = TextAlignmentType.Left;
		return style;
	}

	internal static Style smethod_151(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_152(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.FromArgb(128, 0, 0).ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_153(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "dotted", ColorType.RGB, Color.FromArgb(128, 0, 0).ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_154(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "hair", ColorType.RGB, Color.FromArgb(128, 0, 0).ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_155(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_156(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_157(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		return style;
	}

	internal static Style smethod_158(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_159(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_160(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(192, 192, 192);
		return style;
	}

	internal static Style smethod_161(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.RotationAngle = 90;
		style.HorizontalAlignment = TextAlignmentType.Left;
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_162(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_163(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.HorizontalAlignment = TextAlignmentType.Center;
		return style;
	}

	internal static Style smethod_164(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_165(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_166(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.White;
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_5, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(51, 51, 51);
		return style;
	}

	internal static Style smethod_167(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_168(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_169(WorksheetCollection worksheetCollection_0, bool bool_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		if (bool_0)
		{
			style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
			style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
			style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		}
		return style;
	}

	internal static Style smethod_170(WorksheetCollection worksheetCollection_0, bool bool_0)
	{
		Style style = new Style(worksheetCollection_0);
		if (bool_0)
		{
			style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
			style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
			style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		}
		return style;
	}

	internal static Style smethod_171(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.RotationAngle = 90;
		return style;
	}

	internal static Style smethod_172(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "medium", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "medium", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.HorizontalAlignment = TextAlignmentType.Left;
		return style;
	}

	internal static Style smethod_173(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_174(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "medium", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_175(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_176(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_177(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		return style;
	}

	internal static Style smethod_178(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_179(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_180(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.FromArgb(255, 204, 0);
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.Black;
		return style;
	}

	internal static Style smethod_181(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_182(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_183(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 9;
		style.HorizontalAlignment = TextAlignmentType.Center;
		return style;
	}

	internal static Style smethod_184(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_185(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_186(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_5, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(255, 204, 0);
		return style;
	}

	internal static Style smethod_187(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_188(WorksheetCollection worksheetCollection_0, bool bool_0)
	{
		Style style = new Style(worksheetCollection_0);
		if (bool_0)
		{
			style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
			style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
			style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		}
		return style;
	}

	internal static Style smethod_189(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.FromArgb(255, 204, 0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.Black;
		return style;
	}

	internal static Style smethod_190(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.HorizontalAlignment = TextAlignmentType.Center;
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_191(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "dotted", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_192(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "hair", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_193(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_194(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_195(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_196(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_5, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_197(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_198(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_199(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_200(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_201(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_202(WorksheetCollection worksheetCollection_0, bool bool_0)
	{
		Style style = new Style(worksheetCollection_0);
		if (bool_0)
		{
			style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
			style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
			style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		}
		return style;
	}

	internal static Style smethod_203(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_204(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_205(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_206(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_207(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_208(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.Black;
		return style;
	}

	internal static Style smethod_209(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.Black;
		style.HorizontalAlignment = TextAlignmentType.Right;
		return style;
	}

	internal static Style smethod_210(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 11;
		style.HorizontalAlignment = TextAlignmentType.Left;
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_211(WorksheetCollection worksheetCollection_0)
	{
		return smethod_210(worksheetCollection_0);
	}

	internal static Style smethod_212(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.HorizontalAlignment = TextAlignmentType.General;
		return style;
	}

	internal static Style smethod_213(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.Size = 11;
		style.HorizontalAlignment = TextAlignmentType.Left;
		return style;
	}

	internal static Style smethod_214(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.Size = 11;
		return style;
	}

	internal static Style smethod_215(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsItalic = true;
		style.HorizontalAlignment = TextAlignmentType.Left;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(192, 192, 192);
		return style;
	}

	internal static Style smethod_216(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.HorizontalAlignment = TextAlignmentType.Left;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(192, 192, 192);
		return style;
	}

	internal static Style smethod_217(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.HorizontalAlignment = TextAlignmentType.General;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(192, 192, 192);
		return style;
	}

	internal static Style smethod_218(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 11;
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_219(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.Black;
		return style;
	}

	internal static Style smethod_220(WorksheetCollection worksheetCollection_0)
	{
		return smethod_207(worksheetCollection_0);
	}

	internal static Style smethod_221(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 11;
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.Black;
		return style;
	}

	internal static Style smethod_222(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 11;
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.Black;
		style.HorizontalAlignment = TextAlignmentType.Right;
		return style;
	}

	internal static Style smethod_223(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 11;
		style.HorizontalAlignment = TextAlignmentType.Left;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(255, 255, 204);
		return style;
	}

	internal static Style smethod_224(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.HorizontalAlignment = TextAlignmentType.Left;
		return style;
	}

	internal static Style smethod_225(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		return style;
	}

	internal static Style smethod_226(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.FromArgb(51, 51, 51);
		style.HorizontalAlignment = TextAlignmentType.Left;
		return style;
	}

	internal static Style smethod_227(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.FromArgb(51, 51, 51);
		return style;
	}

	internal static Style smethod_228(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.Color = Color.FromArgb(51, 51, 51);
		style.HorizontalAlignment = TextAlignmentType.Left;
		return style;
	}

	internal static Style smethod_229(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.Color = Color.FromArgb(51, 51, 51);
		return style;
	}

	internal static Style smethod_230(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 11;
		style.method_57(int_0, "thick", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_231(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_232(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 11;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(255, 255, 204);
		return style;
	}

	internal static Style smethod_233(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		return style;
	}

	internal static Style smethod_234(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.FromArgb(51, 51, 51);
		style.method_57(int_0, "thin", ColorType.RGB, Color.FromArgb(51, 51, 51).ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_235(WorksheetCollection worksheetCollection_0)
	{
		return smethod_207(worksheetCollection_0);
	}

	internal static Style smethod_236(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 11;
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.Black;
		style.method_57(int_0, "thick", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_237(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 11;
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.Black;
		style.HorizontalAlignment = TextAlignmentType.Right;
		style.method_57(int_0, "thick", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_238(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(51, 51, 51);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_239(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_240(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		return style;
	}

	internal static Style smethod_241(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(192, 192, 192);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_242(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_243(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_244(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 11;
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(51, 51, 51);
		return style;
	}

	internal static Style smethod_245(WorksheetCollection worksheetCollection_0)
	{
		return smethod_207(worksheetCollection_0);
	}

	internal static Style smethod_246(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 11;
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(102, 102, 153);
		return style;
	}

	internal static Style smethod_247(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 11;
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(102, 102, 153);
		style.HorizontalAlignment = TextAlignmentType.Right;
		return style;
	}

	internal static Style smethod_248(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 11;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(204, 204, 255);
		return style;
	}

	internal static Style smethod_249(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_0, "thick", ColorType.RGB, Color.FromArgb(51, 51, 153).ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_250(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.FromArgb(51, 51, 153);
		style.method_57(int_3, "thin", ColorType.RGB, Color.FromArgb(51, 51, 153).ToArgb(), 0.0);
		style.method_57(int_0, "thick", ColorType.RGB, Color.FromArgb(51, 51, 153).ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_251(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 11;
		style.HorizontalAlignment = TextAlignmentType.Left;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(204, 204, 255);
		return style;
	}

	internal static Style smethod_252(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.HorizontalAlignment = TextAlignmentType.Left;
		style.method_57(int_0, "thick", ColorType.RGB, Color.FromArgb(102, 102, 153).ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_253(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.FromArgb(51, 51, 153);
		style.HorizontalAlignment = TextAlignmentType.Left;
		return style;
	}

	internal static Style smethod_254(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.FromArgb(51, 51, 153);
		return style;
	}

	internal static Style smethod_255(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.FromArgb(102, 102, 153);
		style.HorizontalAlignment = TextAlignmentType.Left;
		return style;
	}

	internal static Style smethod_256(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.FromArgb(102, 102, 153);
		return style;
	}

	internal static Style smethod_257(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 11;
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(102, 102, 153);
		return style;
	}

	internal static Style smethod_258(WorksheetCollection worksheetCollection_0)
	{
		return smethod_207(worksheetCollection_0);
	}

	internal static Style smethod_259(WorksheetCollection worksheetCollection_0)
	{
		return smethod_208(worksheetCollection_0);
	}

	internal static Style smethod_260(WorksheetCollection worksheetCollection_0)
	{
		return smethod_209(worksheetCollection_0);
	}

	internal static Style smethod_261(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(192, 192, 192);
		return style;
	}

	internal static Style smethod_262(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_263(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.FromArgb(128, 128, 128);
		style.method_57(int_3, "dashed", ColorType.RGB, Color.FromArgb(128, 128, 128).ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_264(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.HorizontalAlignment = TextAlignmentType.Left;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(192, 192, 192);
		return style;
	}

	internal static Style smethod_265(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.HorizontalAlignment = TextAlignmentType.Left;
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_266(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		return style;
	}

	internal static Style smethod_267(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.FromArgb(128, 128, 128);
		style.HorizontalAlignment = TextAlignmentType.Left;
		return style;
	}

	internal static Style smethod_268(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.FromArgb(128, 128, 128);
		return style;
	}

	internal static Style smethod_269(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.Color = Color.FromArgb(51, 51, 51);
		style.HorizontalAlignment = TextAlignmentType.Left;
		return style;
	}

	internal static Style smethod_270(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.Color = Color.FromArgb(51, 51, 51);
		return style;
	}

	internal static Style smethod_271(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.Black;
		return style;
	}

	internal static Style smethod_272(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thick", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thick", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_273(WorksheetCollection worksheetCollection_0)
	{
		return smethod_207(worksheetCollection_0);
	}

	internal static Style smethod_274(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 11;
		style.Font.Color = Color.FromArgb(153, 51, 0);
		return style;
	}

	internal static Style smethod_275(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 11;
		style.Font.Color = Color.FromArgb(153, 51, 0);
		style.HorizontalAlignment = TextAlignmentType.Right;
		return style;
	}

	internal static Style smethod_276(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.White;
		style.HorizontalAlignment = TextAlignmentType.Left;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(0, 0, 128);
		return style;
	}

	internal static Style smethod_277(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.White;
		style.HorizontalAlignment = TextAlignmentType.Left;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(0, 0, 128);
		return style;
	}

	internal static Style smethod_278(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.White;
		style.HorizontalAlignment = TextAlignmentType.General;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(0, 0, 128);
		return style;
	}

	internal static Style smethod_279(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.HorizontalAlignment = TextAlignmentType.Left;
		style.method_57(int_0, "thin", ColorType.RGB, Color.FromArgb(153, 51, 0).ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_280(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.HorizontalAlignment = TextAlignmentType.Left;
		style.method_57(int_0, "thin", ColorType.RGB, Color.FromArgb(153, 51, 0).ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_281(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.White;
		style.HorizontalAlignment = TextAlignmentType.General;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(128, 128, 128);
		style.method_57(int_0, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_282(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.FromArgb(0, 0, 128);
		style.HorizontalAlignment = TextAlignmentType.Left;
		style.method_57(int_0, "thick", ColorType.RGB, Color.FromArgb(51, 51, 153).ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_283(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.FromArgb(0, 0, 128);
		return style;
	}

	internal static Style smethod_284(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.Color = Color.FromArgb(0, 0, 128);
		style.HorizontalAlignment = TextAlignmentType.Left;
		style.method_57(int_1, "dashed", ColorType.RGB, Color.FromArgb(0, 0, 128).ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_285(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.Color = Color.FromArgb(0, 0, 128);
		style.method_57(int_2, "dashed", ColorType.RGB, Color.FromArgb(0, 0, 128).ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_286(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 11;
		style.Font.Color = Color.FromArgb(0, 0, 128);
		style.method_57(int_1, "thick", ColorType.RGB, Color.FromArgb(128, 128, 128).ToArgb(), 0.0);
		style.method_57(int_2, "thick", ColorType.RGB, Color.FromArgb(128, 128, 128).ToArgb(), 0.0);
		style.method_57(int_3, "thick", ColorType.RGB, Color.FromArgb(128, 128, 128).ToArgb(), 0.0);
		style.method_57(int_0, "thick", ColorType.RGB, Color.FromArgb(128, 128, 128).ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_287(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_288(WorksheetCollection worksheetCollection_0)
	{
		return smethod_207(worksheetCollection_0);
	}

	internal static Style smethod_289(WorksheetCollection worksheetCollection_0)
	{
		return smethod_221(worksheetCollection_0);
	}

	internal static Style smethod_290(WorksheetCollection worksheetCollection_0)
	{
		return smethod_222(worksheetCollection_0);
	}

	internal static Style smethod_291(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 12;
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.Black;
		return style;
	}

	internal static Style smethod_292(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(192, 192, 192);
		return style;
	}

	internal static Style smethod_293(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		return style;
	}

	internal static Style smethod_294(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 12;
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.Black;
		return style;
	}

	internal static Style smethod_295(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(192, 192, 192);
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_296(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_1, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_297(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		return style;
	}

	internal static Style smethod_298(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "dashed", ColorType.RGB, Color.FromArgb(0, 0, 128).ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_299(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_300(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 12;
		style.method_57(int_3, "thick", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thick", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_301(WorksheetCollection worksheetCollection_0)
	{
		return smethod_207(worksheetCollection_0);
	}

	internal static Style smethod_302(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(51, 51, 51);
		return style;
	}

	internal static Style smethod_303(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(51, 51, 51);
		style.HorizontalAlignment = TextAlignmentType.Right;
		return style;
	}

	internal static Style smethod_304(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(102, 102, 153);
		return style;
	}

	internal static Style smethod_305(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_306(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.FromArgb(128, 128, 128);
		style.method_57(int_3, "dashed", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "dashed", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_307(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.White;
		style.HorizontalAlignment = TextAlignmentType.Left;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(102, 102, 153);
		return style;
	}

	internal static Style smethod_308(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.HorizontalAlignment = TextAlignmentType.Left;
		return style;
	}

	internal static Style smethod_309(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.FromArgb(128, 128, 128);
		style.HorizontalAlignment = TextAlignmentType.Left;
		return style;
	}

	internal static Style smethod_310(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.FromArgb(128, 128, 128);
		return style;
	}

	internal static Style smethod_311(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.Color = Color.FromArgb(128, 128, 128);
		style.HorizontalAlignment = TextAlignmentType.Left;
		return style;
	}

	internal static Style smethod_312(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.Color = Color.FromArgb(128, 128, 128);
		return style;
	}

	internal static Style smethod_313(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.method_57(int_3, "dashed", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_314(WorksheetCollection worksheetCollection_0)
	{
		return smethod_207(worksheetCollection_0);
	}

	internal static Style smethod_315(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 11;
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.Black;
		return style;
	}

	internal static Style smethod_316(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 11;
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.Black;
		style.HorizontalAlignment = TextAlignmentType.Right;
		return style;
	}

	internal static Style smethod_317(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 11;
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(128, 128, 128);
		return style;
	}

	internal static Style smethod_318(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(192, 192, 192);
		style.method_57(int_1, "thick", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_319(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(192, 192, 192);
		return style;
	}

	internal static Style smethod_320(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.Black;
		style.method_57(int_1, "thick", ColorType.RGB, Color.FromArgb(150, 150, 150).ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_321(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_2, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_3, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		style.method_57(int_0, "thin", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_322(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsItalic = true;
		return style;
	}

	internal static Style smethod_323(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 11;
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.Black;
		return style;
	}

	internal static Style smethod_324(WorksheetCollection worksheetCollection_0)
	{
		return smethod_207(worksheetCollection_0);
	}

	internal static Style smethod_325(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 11;
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.Black;
		style.method_57(int_1, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_326(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 11;
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.Black;
		style.HorizontalAlignment = TextAlignmentType.Right;
		return style;
	}

	internal static Style smethod_327(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 16;
		style.HorizontalAlignment = TextAlignmentType.Left;
		return style;
	}

	internal static Style smethod_328(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 16;
		return style;
	}

	internal static Style smethod_329(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.White;
		style.HorizontalAlignment = TextAlignmentType.Left;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(128, 128, 0);
		style.method_57(int_0, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_330(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.HorizontalAlignment = TextAlignmentType.Left;
		style.method_57(int_0, "hair", ColorType.RGB, Color.FromArgb(128, 128, 0).ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_331(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Color = Color.White;
		style.HorizontalAlignment = TextAlignmentType.General;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.FromArgb(128, 128, 0);
		style.method_57(int_0, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_332(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.HorizontalAlignment = TextAlignmentType.Left;
		style.method_57(int_0, "medium", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_333(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.HorizontalAlignment = TextAlignmentType.General;
		style.method_57(int_0, "medium", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_334(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.Color = Color.FromArgb(128, 128, 0);
		style.HorizontalAlignment = TextAlignmentType.Left;
		return style;
	}

	internal static Style smethod_335(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.Color = Color.FromArgb(128, 128, 0);
		style.method_57(int_2, "hair", ColorType.RGB, Color.FromArgb(128, 128, 0).ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_336(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.IsBold = true;
		style.Font.Size = 11;
		style.Font.Color = Color.White;
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = Color.Black;
		style.method_57(int_1, "none", ColorType.RGB, Color.Black.ToArgb(), 0.0);
		return style;
	}

	internal static Style smethod_337(WorksheetCollection worksheetCollection_0)
	{
		Style style = new Style(worksheetCollection_0);
		style.method_57(int_1, "thin", ColorType.RGB, Color.FromArgb(128, 128, 0).ToArgb(), 0.0);
		return style;
	}
}
