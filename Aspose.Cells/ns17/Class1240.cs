using Aspose.Cells;

namespace ns17;

internal class Class1240
{
	internal static float smethod_0(Cells cells_0, int int_0, int int_1, int int_2, int int_3, BorderType borderType_0, int int_4, int int_5, BorderType borderType_1)
	{
		Border border_ = null;
		Border border_2 = null;
		Border border_3 = null;
		Cell cell = null;
		Cell cell2 = null;
		Cell cell3 = null;
		switch (borderType_0)
		{
		case BorderType.BottomBorder:
			cell = cells_0.CheckCell(int_0, int_1);
			if (cell != null)
			{
				border_ = smethod_1(cell, BorderType.BottomBorder);
			}
			else
			{
				cell = cells_0.CheckCell(int_0 + 1, int_1);
				border_ = smethod_1(cell, BorderType.TopBorder);
			}
			cell2 = cells_0.CheckCell(int_2, int_3);
			if (cell2 != null)
			{
				border_2 = smethod_1(cell2, BorderType.BottomBorder);
				break;
			}
			cell2 = cells_0.CheckCell(int_2 + 1, int_3);
			border_2 = smethod_1(cell2, BorderType.TopBorder);
			break;
		case BorderType.LeftBorder:
			cell = cells_0.CheckCell(int_0, int_1);
			if (cell != null)
			{
				border_ = smethod_1(cell, BorderType.LeftBorder);
			}
			else
			{
				cell = cells_0.CheckCell(int_0, int_1 - 1);
				border_ = smethod_1(cell, BorderType.RightBorder);
			}
			cell2 = cells_0.CheckCell(int_2, int_3);
			if (cell2 != null)
			{
				border_2 = smethod_1(cell2, BorderType.LeftBorder);
				break;
			}
			cell2 = cells_0.CheckCell(int_2, int_3 - 1);
			border_2 = smethod_1(cell2, BorderType.RightBorder);
			break;
		case BorderType.RightBorder:
			cell = cells_0.CheckCell(int_0, int_1);
			if (cell != null)
			{
				border_ = smethod_1(cell, BorderType.RightBorder);
			}
			else
			{
				cell = cells_0.CheckCell(int_0, int_1 + 1);
				border_ = smethod_1(cell, BorderType.LeftBorder);
			}
			cell2 = cells_0.CheckCell(int_2, int_3);
			if (cell2 != null)
			{
				border_2 = smethod_1(cell2, BorderType.RightBorder);
				break;
			}
			cell2 = cells_0.CheckCell(int_2, int_3 + 1);
			border_2 = smethod_1(cell2, BorderType.LeftBorder);
			break;
		case BorderType.TopBorder:
			cell = cells_0.CheckCell(int_0, int_1);
			if (cell != null)
			{
				border_ = smethod_1(cell, BorderType.TopBorder);
			}
			else
			{
				cell = cells_0.CheckCell(int_0 - 1, int_1);
				border_ = smethod_1(cell, BorderType.BottomBorder);
			}
			cell2 = cells_0.CheckCell(int_2, int_3);
			if (cell2 != null)
			{
				border_2 = smethod_1(cell2, BorderType.TopBorder);
				break;
			}
			cell2 = cells_0.CheckCell(int_2 - 1, int_3);
			border_2 = smethod_1(cell2, BorderType.BottomBorder);
			break;
		}
		switch (borderType_1)
		{
		case BorderType.BottomBorder:
			cell3 = cells_0.CheckCell(int_4, int_5);
			if (cell3 != null)
			{
				border_3 = smethod_1(cell3, BorderType.BottomBorder);
				break;
			}
			cell3 = cells_0.CheckCell(int_4 + 1, int_5);
			border_3 = smethod_1(cell3, BorderType.TopBorder);
			break;
		case BorderType.LeftBorder:
			cell3 = cells_0.CheckCell(int_4, int_5);
			if (cell3 != null)
			{
				border_3 = smethod_1(cell3, BorderType.LeftBorder);
				break;
			}
			cell3 = cells_0.CheckCell(int_4, int_5 - 1);
			border_3 = smethod_1(cell3, BorderType.RightBorder);
			break;
		case BorderType.RightBorder:
			cell3 = cells_0.CheckCell(int_4, int_5);
			if (cell3 != null)
			{
				border_3 = smethod_1(cell3, BorderType.RightBorder);
				break;
			}
			cell3 = cells_0.CheckCell(int_4, int_5 + 1);
			border_3 = smethod_1(cell3, BorderType.LeftBorder);
			break;
		case BorderType.TopBorder:
			cell3 = cells_0.CheckCell(int_4, int_5);
			if (cell3 != null)
			{
				border_3 = smethod_1(cell3, BorderType.TopBorder);
				break;
			}
			cell3 = cells_0.CheckCell(int_4 - 1, int_5);
			border_3 = smethod_1(cell3, BorderType.BottomBorder);
			break;
		}
		return smethod_4(border_, border_2, border_3);
	}

	private static Border smethod_1(Cell cell_0, BorderType borderType_0)
	{
		Style style = null;
		Border result = null;
		if (cell_0 != null)
		{
			style = cell_0.GetStyle();
		}
		if (style != null)
		{
			result = (style.method_9() ? style.method_4()[borderType_0] : null);
		}
		return result;
	}

	internal static float smethod_2(Cells cells_0, int int_0, int int_1, int int_2, int int_3, BorderType borderType_0)
	{
		Border border_ = null;
		Border border_2 = null;
		Cell cell = null;
		Cell cell2 = null;
		switch (borderType_0)
		{
		case BorderType.BottomBorder:
			cell = cells_0.CheckCell(int_0, int_1);
			if (cell != null)
			{
				border_ = smethod_1(cell, BorderType.BottomBorder);
			}
			else
			{
				cell = cells_0.CheckCell(int_0 + 1, int_1);
				border_ = smethod_1(cell, BorderType.TopBorder);
			}
			cell2 = cells_0.CheckCell(int_2, int_3);
			if (cell2 != null)
			{
				border_2 = smethod_1(cell2, BorderType.BottomBorder);
				break;
			}
			cell2 = cells_0.CheckCell(int_2 + 1, int_3);
			border_2 = smethod_1(cell2, BorderType.TopBorder);
			break;
		case BorderType.LeftBorder:
			cell = cells_0.CheckCell(int_0, int_1);
			if (cell != null)
			{
				border_ = smethod_1(cell, BorderType.LeftBorder);
			}
			else
			{
				cell = cells_0.CheckCell(int_0, int_1 - 1);
				border_ = smethod_1(cell, BorderType.RightBorder);
			}
			cell2 = cells_0.CheckCell(int_2, int_3);
			if (cell2 != null)
			{
				border_2 = smethod_1(cell2, BorderType.LeftBorder);
				break;
			}
			cell2 = cells_0.CheckCell(int_2, int_3 - 1);
			border_2 = smethod_1(cell2, BorderType.RightBorder);
			break;
		case BorderType.RightBorder:
			cell = cells_0.CheckCell(int_0, int_1);
			if (cell != null)
			{
				border_ = smethod_1(cell, BorderType.RightBorder);
			}
			else
			{
				cell = cells_0.CheckCell(int_0, int_1 + 1);
				border_ = smethod_1(cell, BorderType.LeftBorder);
			}
			cell2 = cells_0.CheckCell(int_2, int_3);
			if (cell2 != null)
			{
				border_2 = smethod_1(cell2, BorderType.RightBorder);
				break;
			}
			cell2 = cells_0.CheckCell(int_2, int_3 + 1);
			border_2 = smethod_1(cell2, BorderType.LeftBorder);
			break;
		case BorderType.TopBorder:
			cell = cells_0.CheckCell(int_0, int_1);
			if (cell != null)
			{
				border_ = smethod_1(cell, BorderType.TopBorder);
			}
			else
			{
				cell = cells_0.CheckCell(int_0 - 1, int_1);
				border_ = smethod_1(cell, BorderType.BottomBorder);
			}
			cell2 = cells_0.CheckCell(int_2, int_3);
			if (cell2 != null)
			{
				border_2 = smethod_1(cell2, BorderType.TopBorder);
				break;
			}
			cell2 = cells_0.CheckCell(int_2 - 1, int_3);
			border_2 = smethod_1(cell2, BorderType.BottomBorder);
			break;
		}
		return smethod_5(border_, border_2);
	}

	internal static float smethod_3(Cells cells_0, int int_0, int int_1, int int_2, int int_3, BorderType borderType_0)
	{
		Border border_ = null;
		Border border_2 = null;
		Cell cell = null;
		Cell cell2 = null;
		switch (borderType_0)
		{
		case BorderType.BottomBorder:
			cell = cells_0.CheckCell(int_0, int_1);
			if (cell != null)
			{
				border_ = smethod_1(cell, BorderType.BottomBorder);
			}
			else
			{
				cell = cells_0.CheckCell(int_0 + 1, int_1);
				border_ = smethod_1(cell, BorderType.TopBorder);
			}
			cell2 = cells_0.CheckCell(int_2, int_3);
			if (cell2 != null)
			{
				border_2 = smethod_1(cell2, BorderType.BottomBorder);
				break;
			}
			cell2 = cells_0.CheckCell(int_2 + 1, int_3);
			border_2 = smethod_1(cell2, BorderType.TopBorder);
			break;
		case BorderType.LeftBorder:
			cell = cells_0.CheckCell(int_0, int_1);
			if (cell != null)
			{
				border_ = smethod_1(cell, BorderType.LeftBorder);
			}
			else
			{
				cell = cells_0.CheckCell(int_0, int_1 - 1);
				border_ = smethod_1(cell, BorderType.RightBorder);
			}
			cell2 = cells_0.CheckCell(int_2, int_3);
			if (cell2 != null)
			{
				border_2 = smethod_1(cell2, BorderType.LeftBorder);
				break;
			}
			cell2 = cells_0.CheckCell(int_2, int_3 - 1);
			border_2 = smethod_1(cell2, BorderType.RightBorder);
			break;
		case BorderType.RightBorder:
			cell = cells_0.CheckCell(int_0, int_1);
			if (cell != null)
			{
				border_ = smethod_1(cell, BorderType.RightBorder);
			}
			else
			{
				cell = cells_0.CheckCell(int_0, int_1 + 1);
				border_ = smethod_1(cell, BorderType.LeftBorder);
			}
			cell2 = cells_0.CheckCell(int_2, int_3);
			if (cell2 != null)
			{
				border_2 = smethod_1(cell2, BorderType.RightBorder);
				break;
			}
			cell2 = cells_0.CheckCell(int_2, int_3 + 1);
			border_2 = smethod_1(cell2, BorderType.LeftBorder);
			break;
		case BorderType.TopBorder:
			cell = cells_0.CheckCell(int_0, int_1);
			if (cell != null)
			{
				border_ = smethod_1(cell, BorderType.TopBorder);
			}
			else
			{
				cell = cells_0.CheckCell(int_0 - 1, int_1);
				border_ = smethod_1(cell, BorderType.BottomBorder);
			}
			cell2 = cells_0.CheckCell(int_2, int_3);
			if (cell2 != null)
			{
				border_2 = smethod_1(cell2, BorderType.TopBorder);
				break;
			}
			cell2 = cells_0.CheckCell(int_2 - 1, int_3);
			border_2 = smethod_1(cell2, BorderType.BottomBorder);
			break;
		}
		return smethod_6(border_, border_2);
	}

	private static float smethod_4(Border border_0, Border border_1, Border border_2)
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		flag = border_0 != null && border_0.LineStyle == CellBorderType.Double;
		flag2 = border_1 != null && border_1.LineStyle == CellBorderType.Double;
		flag3 = border_2 != null && border_2.LineStyle == CellBorderType.Double;
		int num = smethod_10(flag, flag2, flag3);
		if (smethod_7(border_0) != 3f && smethod_7(border_1) != 3f)
		{
			if (smethod_7(border_0) != 2f && smethod_7(border_1) != 2f)
			{
				if (smethod_7(border_0) != 1f && smethod_7(border_1) != 1f)
				{
					if (smethod_7(border_0) != 0.5f && smethod_7(border_1) != 0.5f)
					{
						return 0f;
					}
					return (float)num * 0.25f;
				}
				return (float)num * 0.5f;
			}
			return (float)num * 1f;
		}
		return (float)num * 0.333f;
	}

	private static float smethod_5(Border border_0, Border border_1)
	{
		bool flag = false;
		bool flag2 = false;
		flag = border_0 != null && border_0.LineStyle == CellBorderType.Double;
		flag2 = border_1 != null && border_1.LineStyle == CellBorderType.Double;
		int num = smethod_8(flag, flag2);
		if (smethod_7(border_0) != 3f && smethod_7(border_1) != 3f)
		{
			if (smethod_7(border_0) != 2f && smethod_7(border_1) != 2f)
			{
				if (smethod_7(border_0) != 1f && smethod_7(border_1) != 1f)
				{
					if (smethod_7(border_0) != 0.5f && smethod_7(border_1) != 0.5f)
					{
						return 0f;
					}
					return (float)num * 0.25f;
				}
				return (float)num * 0.5f;
			}
			return (float)num * 1f;
		}
		return (float)num * 1f;
	}

	private static float smethod_6(Border border_0, Border border_1)
	{
		bool flag = false;
		bool flag2 = false;
		flag = border_0 != null && border_0.LineStyle == CellBorderType.Double;
		flag2 = border_1 != null && border_1.LineStyle == CellBorderType.Double;
		int num = smethod_9(flag, flag2);
		if (smethod_7(border_0) != 3f && smethod_7(border_1) != 3f)
		{
			if (smethod_7(border_0) != 2f && smethod_7(border_1) != 2f)
			{
				if (smethod_7(border_0) != 1f && smethod_7(border_1) != 1f)
				{
					if (smethod_7(border_0) != 0.5f && smethod_7(border_1) != 0.5f)
					{
						return 0f;
					}
					return (float)num * 0.25f;
				}
				return (float)num * 0.5f;
			}
			return (float)num * 1f;
		}
		return num;
	}

	internal static float smethod_7(Border border_0)
	{
		if (border_0 == null)
		{
			return 0f;
		}
		switch (border_0.LineStyle)
		{
		case CellBorderType.Thick:
			return 2f;
		case CellBorderType.Double:
			return 3f;
		case CellBorderType.Thin:
		case CellBorderType.Medium:
		case CellBorderType.MediumDashed:
		case CellBorderType.MediumDashDot:
			return 1f;
		default:
			return 0f;
		case CellBorderType.Dashed:
		case CellBorderType.Dotted:
		case CellBorderType.Hair:
		case CellBorderType.DashDot:
		case CellBorderType.DashDotDot:
		case CellBorderType.SlantedDashDot:
			return 0.5f;
		}
	}

	private static int smethod_8(bool bool_0, bool bool_1)
	{
		if (!bool_0 && !bool_1)
		{
			return 0;
		}
		if (bool_0 && !bool_1)
		{
			return 0;
		}
		if (bool_0 && bool_1)
		{
			return 0;
		}
		if (!bool_0 && bool_1)
		{
			return -1;
		}
		return 0;
	}

	private static int smethod_9(bool bool_0, bool bool_1)
	{
		if (!bool_0 && !bool_1)
		{
			return 0;
		}
		if (bool_0 && !bool_1)
		{
			return -1;
		}
		if (bool_0 && bool_1)
		{
			return 0;
		}
		if (!bool_0 && bool_1)
		{
			return 0;
		}
		return 0;
	}

	private static int smethod_10(bool bool_0, bool bool_1, bool bool_2)
	{
		if (!bool_0 && !bool_1)
		{
			if (bool_2)
			{
				return -1;
			}
			return 1;
		}
		if ((bool_0 && !bool_1) || (!bool_0 && bool_1))
		{
			return -1;
		}
		if (bool_0 && bool_1)
		{
			return 0;
		}
		return 1;
	}
}
