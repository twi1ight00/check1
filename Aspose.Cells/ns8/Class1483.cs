using Aspose.Cells;

namespace ns8;

internal class Class1483
{
	private Style style_0;

	private Style style_1;

	private Style style_2;

	internal Class1483(Style style_3, Style style_4, Style style_5)
	{
		style_0 = ((style_4 == null) ? style_3 : style_4);
		style_1 = ((style_5 == null) ? style_3 : style_5);
		style_2 = style_3;
	}

	internal bool method_0()
	{
		TextAlignmentType textAlignmentType = (style_0.method_21() ? style_0.HorizontalAlignment : style_2.HorizontalAlignment);
		TextAlignmentType textAlignmentType2 = (style_1.method_21() ? style_1.HorizontalAlignment : style_2.HorizontalAlignment);
		if (textAlignmentType == TextAlignmentType.CenterAcross && textAlignmentType2 != TextAlignmentType.CenterAcross)
		{
			return false;
		}
		if (textAlignmentType != TextAlignmentType.Right && textAlignmentType != TextAlignmentType.Center)
		{
			return true;
		}
		return false;
	}

	internal bool method_1()
	{
		if (!style_0.method_25() && !style_1.method_25())
		{
			return true;
		}
		Style style = (style_0.method_25() ? style_0 : style_2);
		Style style2 = (style_1.method_25() ? style_1 : style_2);
		if (style.Pattern == style2.Pattern && style.ForeInternalColor.method_9(style2.ForeInternalColor) && style.BackgroundInternalColor.Equals(style2.BackgroundInternalColor))
		{
			return true;
		}
		return false;
	}

	internal bool method_2()
	{
		Style style = (style_0.method_23() ? style_0 : style_2);
		Style style2 = (style_1.method_23() ? style_1 : style_2);
		bool flag = method_9(style2);
		if (!method_9(style) && !flag)
		{
			return true;
		}
		if (!flag && style.Borders[BorderType.TopBorder].LineStyle == CellBorderType.None && style.Borders[BorderType.RightBorder].LineStyle == CellBorderType.None && style.Borders[BorderType.BottomBorder].LineStyle == CellBorderType.None && style.Borders[BorderType.DiagonalDown].LineStyle == CellBorderType.None && style.Borders[BorderType.DiagonalUp].LineStyle == CellBorderType.None)
		{
			return true;
		}
		if (method_5(style) && method_3(style2) && style.Borders[BorderType.BottomBorder].LineStyle == style2.Borders[BorderType.BottomBorder].LineStyle && style.Borders[BorderType.BottomBorder].InternalColor.method_9(style2.Borders[BorderType.BottomBorder].InternalColor))
		{
			return true;
		}
		if (method_6(style) && method_4(style2) && style.Borders[BorderType.TopBorder].LineStyle == style2.Borders[BorderType.TopBorder].LineStyle && style.Borders[BorderType.TopBorder].InternalColor.method_9(style2.Borders[BorderType.TopBorder].InternalColor))
		{
			return true;
		}
		if (method_7(style) && method_8(style2) && style.Borders[BorderType.TopBorder].LineStyle == style2.Borders[BorderType.TopBorder].LineStyle && style.Borders[BorderType.TopBorder].InternalColor.method_9(style2.Borders[BorderType.TopBorder].InternalColor) && style.Borders[BorderType.BottomBorder].LineStyle == style2.Borders[BorderType.BottomBorder].LineStyle && style.Borders[BorderType.BottomBorder].InternalColor.method_9(style2.Borders[BorderType.BottomBorder].InternalColor))
		{
			return true;
		}
		return false;
	}

	private bool method_3(Style style_3)
	{
		if (style_3.Borders[BorderType.TopBorder].LineStyle == CellBorderType.None && style_3.Borders[BorderType.RightBorder].LineStyle == CellBorderType.None && style_3.Borders[BorderType.LeftBorder].LineStyle == CellBorderType.None && style_3.Borders[BorderType.BottomBorder].LineStyle != 0 && style_3.Borders[BorderType.DiagonalDown].LineStyle == CellBorderType.None && style_3.Borders[BorderType.DiagonalUp].LineStyle == CellBorderType.None)
		{
			return true;
		}
		return false;
	}

	private bool method_4(Style style_3)
	{
		if (style_3.Borders[BorderType.TopBorder].LineStyle != 0 && style_3.Borders[BorderType.RightBorder].LineStyle == CellBorderType.None && style_3.Borders[BorderType.BottomBorder].LineStyle == CellBorderType.None && style_3.Borders[BorderType.LeftBorder].LineStyle == CellBorderType.None && style_3.Borders[BorderType.DiagonalDown].LineStyle == CellBorderType.None && style_3.Borders[BorderType.DiagonalUp].LineStyle == CellBorderType.None)
		{
			return true;
		}
		return false;
	}

	private bool method_5(Style style_3)
	{
		if (style_3.Borders[BorderType.TopBorder].LineStyle == CellBorderType.None && style_3.Borders[BorderType.RightBorder].LineStyle == CellBorderType.None && style_3.Borders[BorderType.BottomBorder].LineStyle != 0 && style_3.Borders[BorderType.DiagonalDown].LineStyle == CellBorderType.None && style_3.Borders[BorderType.DiagonalUp].LineStyle == CellBorderType.None)
		{
			return true;
		}
		return false;
	}

	private bool method_6(Style style_3)
	{
		if (style_3.Borders[BorderType.TopBorder].LineStyle != 0 && style_3.Borders[BorderType.RightBorder].LineStyle == CellBorderType.None && style_3.Borders[BorderType.BottomBorder].LineStyle == CellBorderType.None && style_3.Borders[BorderType.DiagonalDown].LineStyle == CellBorderType.None && style_3.Borders[BorderType.DiagonalUp].LineStyle == CellBorderType.None)
		{
			return true;
		}
		return false;
	}

	private bool method_7(Style style_3)
	{
		if (style_3.Borders[BorderType.TopBorder].LineStyle != 0 && style_3.Borders[BorderType.RightBorder].LineStyle == CellBorderType.None && style_3.Borders[BorderType.BottomBorder].LineStyle != 0 && style_3.Borders[BorderType.DiagonalDown].LineStyle == CellBorderType.None && style_3.Borders[BorderType.DiagonalUp].LineStyle == CellBorderType.None)
		{
			return true;
		}
		return false;
	}

	private bool method_8(Style style_3)
	{
		if (style_3.Borders[BorderType.TopBorder].LineStyle != 0 && style_3.Borders[BorderType.BottomBorder].LineStyle != 0 && style_3.Borders[BorderType.LeftBorder].LineStyle == CellBorderType.None && style_3.Borders[BorderType.DiagonalDown].LineStyle == CellBorderType.None && style_3.Borders[BorderType.DiagonalUp].LineStyle == CellBorderType.None)
		{
			return true;
		}
		return false;
	}

	private bool method_9(Style style_3)
	{
		if (style_3 != null && style_3.method_23())
		{
			if (style_3.Borders[BorderType.TopBorder].LineStyle == CellBorderType.None && style_3.Borders[BorderType.RightBorder].LineStyle == CellBorderType.None && style_3.Borders[BorderType.BottomBorder].LineStyle == CellBorderType.None && style_3.Borders[BorderType.LeftBorder].LineStyle == CellBorderType.None && style_3.Borders[BorderType.DiagonalDown].LineStyle == CellBorderType.None && style_3.Borders[BorderType.DiagonalUp].LineStyle == CellBorderType.None)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	internal Border method_10()
	{
		Style style = (style_1.method_23() ? style_1 : style_2);
		Border border = style.Borders[BorderType.LeftBorder];
		if (border.LineStyle == CellBorderType.None)
		{
			return null;
		}
		return border;
	}
}
