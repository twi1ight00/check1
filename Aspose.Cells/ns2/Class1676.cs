using System.Web.UI.WebControls;
using Aspose.Cells;

namespace ns2;

internal class Class1676
{
	internal static Aspose.Cells.Style smethod_0(Cells cells_0, GridView gridView_0, int int_0)
	{
		Aspose.Cells.Style style = cells_0.method_19().Workbook.CreateStyle();
		smethod_2(style.Font, gridView_0.Font, int_0);
		style.ForegroundColor = gridView_0.ForeColor;
		style.BackgroundColor = gridView_0.BackColor;
		style.IsTextWrapped = true;
		return style;
	}

	internal static double smethod_1(double double_0, Unit unit_0, int int_0)
	{
		if (unit_0.IsEmpty)
		{
			return -1.0;
		}
		switch (unit_0.Type)
		{
		default:
			return -1.0;
		case UnitType.Pixel:
			return unit_0.Value * 72.0 / (double)int_0;
		case UnitType.Point:
			return unit_0.Value;
		case UnitType.Pica:
			return unit_0.Value * 12.0;
		case UnitType.Inch:
			return unit_0.Value * 72.0;
		case UnitType.Mm:
			return unit_0.Value * 0.254 / 72.0;
		case UnitType.Cm:
			return unit_0.Value * 2.54 / 72.0;
		case UnitType.Percentage:
			return double_0 * unit_0.Value;
		case UnitType.Em:
		case UnitType.Ex:
			return -1.0;
		}
	}

	internal static void smethod_2(Font font_0, FontInfo fontInfo_0, int int_0)
	{
		font_0.method_13(fontInfo_0.Name);
		double num = smethod_1(0.0, fontInfo_0.Size.Unit, int_0);
		if (num > 0.0)
		{
			font_0.Size = (int)(num + 0.5);
		}
		font_0.IsBold = fontInfo_0.Bold;
		font_0.IsItalic = fontInfo_0.Italic;
		font_0.IsStrikeout = fontInfo_0.Strikeout;
		if (fontInfo_0.Underline)
		{
			font_0.Underline = FontUnderlineType.Single;
		}
	}
}
