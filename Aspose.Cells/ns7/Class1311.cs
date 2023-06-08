using System;
using Aspose.Cells;
using Aspose.Cells.Charts;
using ns16;

namespace ns7;

internal class Class1311
{
	internal static SparklinePresetStyleType GetStyle(SparklineGroup sparklineGroup_0)
	{
		if (smethod_2(sparklineGroup_0, 4, 5))
		{
			return SparklinePresetStyleType.Style1;
		}
		if (smethod_2(sparklineGroup_0, 5, 6))
		{
			return SparklinePresetStyleType.Style2;
		}
		if (smethod_2(sparklineGroup_0, 6, 7))
		{
			return SparklinePresetStyleType.Style3;
		}
		if (smethod_2(sparklineGroup_0, 7, 8))
		{
			return SparklinePresetStyleType.Style4;
		}
		if (smethod_2(sparklineGroup_0, 8, 9))
		{
			return SparklinePresetStyleType.Style5;
		}
		if (smethod_2(sparklineGroup_0, 9, 4))
		{
			return SparklinePresetStyleType.Style6;
		}
		if (smethod_4(sparklineGroup_0, 4, 5))
		{
			return SparklinePresetStyleType.Style7;
		}
		if (smethod_4(sparklineGroup_0, 5, 6))
		{
			return SparklinePresetStyleType.Style8;
		}
		if (smethod_4(sparklineGroup_0, 6, 7))
		{
			return SparklinePresetStyleType.Style9;
		}
		if (smethod_4(sparklineGroup_0, 7, 8))
		{
			return SparklinePresetStyleType.Style10;
		}
		if (smethod_4(sparklineGroup_0, 8, 9))
		{
			return SparklinePresetStyleType.Style11;
		}
		if (smethod_4(sparklineGroup_0, 9, 4))
		{
			return SparklinePresetStyleType.Style12;
		}
		if (smethod_6(sparklineGroup_0, 4, 5))
		{
			return SparklinePresetStyleType.Style13;
		}
		if (smethod_6(sparklineGroup_0, 5, 6))
		{
			return SparklinePresetStyleType.Style14;
		}
		if (smethod_6(sparklineGroup_0, 6, 7))
		{
			return SparklinePresetStyleType.Style15;
		}
		if (smethod_6(sparklineGroup_0, 7, 8))
		{
			return SparklinePresetStyleType.Style16;
		}
		if (smethod_6(sparklineGroup_0, 8, 9))
		{
			return SparklinePresetStyleType.Style17;
		}
		if (smethod_6(sparklineGroup_0, 9, 4))
		{
			return SparklinePresetStyleType.Style18;
		}
		if (smethod_8(sparklineGroup_0, 4, 0))
		{
			return SparklinePresetStyleType.Style19;
		}
		if (smethod_8(sparklineGroup_0, 5, 0))
		{
			return SparklinePresetStyleType.Style20;
		}
		if (smethod_8(sparklineGroup_0, 6, 0))
		{
			return SparklinePresetStyleType.Style21;
		}
		if (smethod_8(sparklineGroup_0, 7, 0))
		{
			return SparklinePresetStyleType.Style22;
		}
		if (smethod_8(sparklineGroup_0, 8, 0))
		{
			return SparklinePresetStyleType.Style23;
		}
		if (smethod_8(sparklineGroup_0, 9, 0))
		{
			return SparklinePresetStyleType.Style24;
		}
		if (smethod_10(sparklineGroup_0))
		{
			return SparklinePresetStyleType.Style25;
		}
		if (smethod_12(sparklineGroup_0))
		{
			return SparklinePresetStyleType.Style26;
		}
		if (smethod_14(sparklineGroup_0, "FF323232", "FFD00000"))
		{
			return SparklinePresetStyleType.Style27;
		}
		if (smethod_14(sparklineGroup_0, "FF000000", "FF0070C0"))
		{
			return SparklinePresetStyleType.Style28;
		}
		if (smethod_14(sparklineGroup_0, "FF376092", "FFD00000"))
		{
			return SparklinePresetStyleType.Style29;
		}
		if (smethod_14(sparklineGroup_0, "FF0070C0", "FF000000"))
		{
			return SparklinePresetStyleType.Style30;
		}
		if (smethod_16(sparklineGroup_0, "FF5F5F5F", "FFFFB620", "FFD70077", "FF5687C2", "FF359CEB", "FF56BE79", "FFFF5055"))
		{
			return SparklinePresetStyleType.Style31;
		}
		if (smethod_16(sparklineGroup_0, "FF5687C2", "FFFFB620", "FFD70077", "FF777777", "FF359CEB", "FF56BE79", "FFFF5055"))
		{
			return SparklinePresetStyleType.Style32;
		}
		if (smethod_16(sparklineGroup_0, "FFC6EFCE", "FFFFC7CE", "FF8CADD6", "FFFFDC47", "FFFFEB9C", "FF60D276", "FFFF5367"))
		{
			return SparklinePresetStyleType.Style33;
		}
		if (smethod_16(sparklineGroup_0, "FF00B050", "FFFF0000", "FF0070C0", "FFFFC000", "FFFFC000", "FF00B050", "FFFF0000"))
		{
			return SparklinePresetStyleType.Style34;
		}
		if (smethod_18(sparklineGroup_0, 3))
		{
			return SparklinePresetStyleType.Style35;
		}
		if (smethod_18(sparklineGroup_0, 1))
		{
			return SparklinePresetStyleType.Style36;
		}
		return SparklinePresetStyleType.Custom;
	}

	internal static void SetStyle(SparklineGroup sparklineGroup_0, SparklinePresetStyleType sparklinePresetStyleType_0)
	{
		switch (sparklinePresetStyleType_0)
		{
		case SparklinePresetStyleType.Style1:
			smethod_1(sparklineGroup_0, 4, 5);
			break;
		case SparklinePresetStyleType.Style2:
			smethod_1(sparklineGroup_0, 5, 6);
			break;
		case SparklinePresetStyleType.Style3:
			smethod_1(sparklineGroup_0, 6, 7);
			break;
		case SparklinePresetStyleType.Style4:
			smethod_1(sparklineGroup_0, 7, 8);
			break;
		case SparklinePresetStyleType.Style5:
			smethod_1(sparklineGroup_0, 8, 9);
			break;
		case SparklinePresetStyleType.Style6:
			smethod_1(sparklineGroup_0, 9, 4);
			break;
		case SparklinePresetStyleType.Style7:
			smethod_3(sparklineGroup_0, 4, 5);
			break;
		case SparklinePresetStyleType.Style8:
			smethod_3(sparklineGroup_0, 5, 6);
			break;
		case SparklinePresetStyleType.Style9:
			smethod_3(sparklineGroup_0, 6, 7);
			break;
		case SparklinePresetStyleType.Style10:
			smethod_3(sparklineGroup_0, 7, 8);
			break;
		case SparklinePresetStyleType.Style11:
			smethod_3(sparklineGroup_0, 8, 9);
			break;
		case SparklinePresetStyleType.Style12:
			smethod_3(sparklineGroup_0, 9, 4);
			break;
		case SparklinePresetStyleType.Style13:
			smethod_5(sparklineGroup_0, 4, 5);
			break;
		case SparklinePresetStyleType.Style14:
			smethod_5(sparklineGroup_0, 5, 6);
			break;
		case SparklinePresetStyleType.Style15:
			smethod_5(sparklineGroup_0, 6, 7);
			break;
		case SparklinePresetStyleType.Style16:
			smethod_5(sparklineGroup_0, 7, 8);
			break;
		case SparklinePresetStyleType.Style17:
			smethod_5(sparklineGroup_0, 8, 9);
			break;
		case SparklinePresetStyleType.Style18:
			smethod_5(sparklineGroup_0, 9, 4);
			break;
		case SparklinePresetStyleType.Style19:
			smethod_7(sparklineGroup_0, 4, 0);
			break;
		case SparklinePresetStyleType.Style20:
			smethod_7(sparklineGroup_0, 5, 0);
			break;
		case SparklinePresetStyleType.Style21:
			smethod_7(sparklineGroup_0, 6, 0);
			break;
		case SparklinePresetStyleType.Style22:
			smethod_7(sparklineGroup_0, 7, 0);
			break;
		case SparklinePresetStyleType.Style23:
			smethod_7(sparklineGroup_0, 8, 0);
			break;
		case SparklinePresetStyleType.Style24:
			smethod_7(sparklineGroup_0, 9, 0);
			break;
		case SparklinePresetStyleType.Style25:
			smethod_9(sparklineGroup_0);
			break;
		case SparklinePresetStyleType.Style26:
			smethod_11(sparklineGroup_0);
			break;
		case SparklinePresetStyleType.Style27:
			smethod_13(sparklineGroup_0, "FF323232", "FFD00000");
			break;
		case SparklinePresetStyleType.Style28:
			smethod_13(sparklineGroup_0, "FF000000", "FF0070C0");
			break;
		case SparklinePresetStyleType.Style29:
			smethod_13(sparklineGroup_0, "FF376092", "FFD00000");
			break;
		case SparklinePresetStyleType.Style30:
			smethod_13(sparklineGroup_0, "FF0070C0", "FF000000");
			break;
		case SparklinePresetStyleType.Style31:
			smethod_15(sparklineGroup_0, "FF5F5F5F", "FFFFB620", "FFD70077", "FF5687C2", "FF359CEB", "FF56BE79", "FFFF5055");
			break;
		case SparklinePresetStyleType.Style32:
			smethod_15(sparklineGroup_0, "FF5687C2", "FFFFB620", "FFD70077", "FF777777", "FF359CEB", "FF56BE79", "FFFF5055");
			break;
		case SparklinePresetStyleType.Style33:
			smethod_15(sparklineGroup_0, "FFC6EFCE", "FFFFC7CE", "FF8CADD6", "FFFFDC47", "FFFFEB9C", "FF60D276", "FFFF5367");
			break;
		case SparklinePresetStyleType.Style34:
			smethod_15(sparklineGroup_0, "FF00B050", "FFFF0000", "FF0070C0", "FFFFC000", "FFFFC000", "FF00B050", "FFFF0000");
			break;
		case SparklinePresetStyleType.Style35:
			smethod_17(sparklineGroup_0, 3);
			break;
		case SparklinePresetStyleType.Style36:
			smethod_17(sparklineGroup_0, 1);
			break;
		case SparklinePresetStyleType.Custom:
			break;
		}
	}

	private static CellsColor GetColor(Workbook workbook_0, string string_0, int int_0, double double_0)
	{
		InternalColor internalColor = new InternalColor(bool_0: false);
		if (string_0 != null)
		{
			internalColor.SetColor(ColorType.RGB, Class1618.smethod_63(string_0).ToArgb());
		}
		else
		{
			internalColor.SetColor(ColorType.Theme, int_0);
		}
		if (double_0 != 0.0)
		{
			internalColor.Tint = double_0;
		}
		CellsColor cellsColor = workbook_0.CreateCellsColor();
		cellsColor.internalColor_0 = internalColor;
		return cellsColor;
	}

	private static bool smethod_0(CellsColor cellsColor_0, string string_0, int int_0, double double_0)
	{
		InternalColor internalColor_ = cellsColor_0.internalColor_0;
		if (internalColor_.ColorType == ColorType.Theme)
		{
			if (internalColor_.method_4() == int_0 && Math.Abs(double_0 - internalColor_.Tint) < 0.0001)
			{
				return true;
			}
		}
		else
		{
			string text = "FF" + Class1618.smethod_64(cellsColor_0.Color);
			if (text.Equals(string_0) && Math.Abs(double_0 - internalColor_.Tint) < 0.0001)
			{
				return true;
			}
		}
		return false;
	}

	private static void smethod_1(SparklineGroup sparklineGroup_0, int int_0, int int_1)
	{
		Workbook workbook = sparklineGroup_0.SparklineGroupCollection.method_0().Workbook;
		sparklineGroup_0.SeriesColor = GetColor(workbook, null, int_0, -0.499984740745262);
		sparklineGroup_0.NegativePointsColor = GetColor(workbook, null, int_1, 0.0);
		sparklineGroup_0.HorizontalAxisColor = GetColor(workbook, "FF000000", -1, 0.0);
		sparklineGroup_0.MarkersColor = GetColor(workbook, null, int_0, -0.499984740745262);
		sparklineGroup_0.FirstPointColor = GetColor(workbook, null, int_0, 0.3999755851924192);
		sparklineGroup_0.LastPointColor = GetColor(workbook, null, int_0, 0.3999755851924192);
		sparklineGroup_0.HighPointColor = GetColor(workbook, null, int_0, 0.0);
		sparklineGroup_0.LowPointColor = GetColor(workbook, null, int_0, 0.0);
	}

	private static bool smethod_2(SparklineGroup sparklineGroup_0, int int_0, int int_1)
	{
		if (smethod_0(sparklineGroup_0.SeriesColor, null, int_0, -0.499984740745262) && smethod_0(sparklineGroup_0.NegativePointsColor, null, int_1, 0.0) && smethod_0(sparklineGroup_0.HorizontalAxisColor, "FF000000", -1, 0.0) && smethod_0(sparklineGroup_0.MarkersColor, null, int_0, -0.499984740745262) && smethod_0(sparklineGroup_0.FirstPointColor, null, int_0, 0.3999755851924192) && smethod_0(sparklineGroup_0.LastPointColor, null, int_0, 0.3999755851924192) && smethod_0(sparklineGroup_0.HighPointColor, null, int_0, 0.0) && smethod_0(sparklineGroup_0.LowPointColor, null, int_0, 0.0))
		{
			return true;
		}
		return false;
	}

	private static void smethod_3(SparklineGroup sparklineGroup_0, int int_0, int int_1)
	{
		Workbook workbook = sparklineGroup_0.SparklineGroupCollection.method_0().Workbook;
		sparklineGroup_0.SeriesColor = GetColor(workbook, null, int_0, -0.249977111117893);
		sparklineGroup_0.NegativePointsColor = GetColor(workbook, null, int_1, 0.0);
		sparklineGroup_0.HorizontalAxisColor = GetColor(workbook, "FF000000", -1, 0.0);
		sparklineGroup_0.MarkersColor = GetColor(workbook, null, int_1, -0.249977111117893);
		sparklineGroup_0.FirstPointColor = GetColor(workbook, null, int_1, -0.249977111117893);
		sparklineGroup_0.LastPointColor = GetColor(workbook, null, int_1, -0.249977111117893);
		sparklineGroup_0.HighPointColor = GetColor(workbook, null, int_1, -0.249977111117893);
		sparklineGroup_0.LowPointColor = GetColor(workbook, null, int_1, -0.249977111117893);
	}

	private static bool smethod_4(SparklineGroup sparklineGroup_0, int int_0, int int_1)
	{
		if (smethod_0(sparklineGroup_0.SeriesColor, null, int_0, -0.249977111117893) && smethod_0(sparklineGroup_0.NegativePointsColor, null, int_1, 0.0) && smethod_0(sparklineGroup_0.HorizontalAxisColor, "FF000000", -1, 0.0) && smethod_0(sparklineGroup_0.MarkersColor, null, int_1, -0.249977111117893) && smethod_0(sparklineGroup_0.FirstPointColor, null, int_1, -0.249977111117893) && smethod_0(sparklineGroup_0.LastPointColor, null, int_1, -0.249977111117893) && smethod_0(sparklineGroup_0.HighPointColor, null, int_1, -0.249977111117893) && smethod_0(sparklineGroup_0.LowPointColor, null, int_1, -0.249977111117893))
		{
			return true;
		}
		return false;
	}

	private static void smethod_5(SparklineGroup sparklineGroup_0, int int_0, int int_1)
	{
		Workbook workbook = sparklineGroup_0.SparklineGroupCollection.method_0().Workbook;
		sparklineGroup_0.SeriesColor = GetColor(workbook, null, int_0, 0.0);
		sparklineGroup_0.NegativePointsColor = GetColor(workbook, null, int_1, 0.0);
		sparklineGroup_0.HorizontalAxisColor = GetColor(workbook, "FF000000", -1, 0.0);
		sparklineGroup_0.MarkersColor = GetColor(workbook, null, int_0, -0.249977111117893);
		sparklineGroup_0.FirstPointColor = GetColor(workbook, null, int_0, -0.249977111117893);
		sparklineGroup_0.LastPointColor = GetColor(workbook, null, int_0, -0.249977111117893);
		sparklineGroup_0.HighPointColor = GetColor(workbook, null, int_0, -0.249977111117893);
		sparklineGroup_0.LowPointColor = GetColor(workbook, null, int_0, -0.249977111117893);
	}

	private static bool smethod_6(SparklineGroup sparklineGroup_0, int int_0, int int_1)
	{
		if (smethod_0(sparklineGroup_0.SeriesColor, null, int_0, 0.0) && smethod_0(sparklineGroup_0.NegativePointsColor, null, int_1, 0.0) && smethod_0(sparklineGroup_0.HorizontalAxisColor, "FF000000", -1, 0.0) && smethod_0(sparklineGroup_0.MarkersColor, null, int_0, -0.249977111117893) && smethod_0(sparklineGroup_0.FirstPointColor, null, int_0, -0.249977111117893) && smethod_0(sparklineGroup_0.LastPointColor, null, int_0, -0.249977111117893) && smethod_0(sparklineGroup_0.HighPointColor, null, int_0, -0.249977111117893) && smethod_0(sparklineGroup_0.LowPointColor, null, int_0, -0.249977111117893))
		{
			return true;
		}
		return false;
	}

	private static void smethod_7(SparklineGroup sparklineGroup_0, int int_0, int int_1)
	{
		Workbook workbook = sparklineGroup_0.SparklineGroupCollection.method_0().Workbook;
		sparklineGroup_0.SeriesColor = GetColor(workbook, null, int_0, 0.3999755851924192);
		sparklineGroup_0.NegativePointsColor = GetColor(workbook, null, int_1, -0.499984740745262);
		sparklineGroup_0.HorizontalAxisColor = GetColor(workbook, "FF000000", -1, 0.0);
		sparklineGroup_0.MarkersColor = GetColor(workbook, null, int_0, 0.7999816888943144);
		sparklineGroup_0.FirstPointColor = GetColor(workbook, null, int_0, -0.249977111117893);
		sparklineGroup_0.LastPointColor = GetColor(workbook, null, int_0, -0.249977111117893);
		sparklineGroup_0.HighPointColor = GetColor(workbook, null, int_0, -0.499984740745262);
		sparklineGroup_0.LowPointColor = GetColor(workbook, null, int_0, -0.499984740745262);
	}

	private static bool smethod_8(SparklineGroup sparklineGroup_0, int int_0, int int_1)
	{
		if (smethod_0(sparklineGroup_0.SeriesColor, null, int_0, 0.3999755851924192) && smethod_0(sparklineGroup_0.NegativePointsColor, null, int_1, -0.499984740745262) && smethod_0(sparklineGroup_0.HorizontalAxisColor, "FF000000", -1, 0.0) && smethod_0(sparklineGroup_0.MarkersColor, null, int_0, 0.7999816888943144) && smethod_0(sparklineGroup_0.FirstPointColor, null, int_0, -0.249977111117893) && smethod_0(sparklineGroup_0.LastPointColor, null, int_0, -0.249977111117893) && smethod_0(sparklineGroup_0.HighPointColor, null, int_0, -0.499984740745262) && smethod_0(sparklineGroup_0.LowPointColor, null, int_0, -0.499984740745262))
		{
			return true;
		}
		return false;
	}

	private static void smethod_9(SparklineGroup sparklineGroup_0)
	{
		Workbook workbook = sparklineGroup_0.SparklineGroupCollection.method_0().Workbook;
		sparklineGroup_0.SeriesColor = GetColor(workbook, null, 1, 0.499984740745262);
		sparklineGroup_0.NegativePointsColor = GetColor(workbook, null, 1, 0.249977111117893);
		sparklineGroup_0.HorizontalAxisColor = GetColor(workbook, "FF000000", -1, 0.0);
		sparklineGroup_0.MarkersColor = GetColor(workbook, null, 1, 0.249977111117893);
		sparklineGroup_0.FirstPointColor = GetColor(workbook, null, 1, 0.249977111117893);
		sparklineGroup_0.LastPointColor = GetColor(workbook, null, 1, 0.249977111117893);
		sparklineGroup_0.HighPointColor = GetColor(workbook, null, 1, 0.249977111117893);
		sparklineGroup_0.LowPointColor = GetColor(workbook, null, 1, 0.249977111117893);
	}

	private static bool smethod_10(SparklineGroup sparklineGroup_0)
	{
		if (smethod_0(sparklineGroup_0.SeriesColor, null, 1, 0.499984740745262) && smethod_0(sparklineGroup_0.NegativePointsColor, null, 1, 0.249977111117893) && smethod_0(sparklineGroup_0.HorizontalAxisColor, "FF000000", -1, 0.0) && smethod_0(sparklineGroup_0.MarkersColor, null, 1, 0.249977111117893) && smethod_0(sparklineGroup_0.FirstPointColor, null, 1, 0.249977111117893) && smethod_0(sparklineGroup_0.LastPointColor, null, 1, 0.249977111117893) && smethod_0(sparklineGroup_0.HighPointColor, null, 1, 0.249977111117893) && smethod_0(sparklineGroup_0.LowPointColor, null, 1, 0.249977111117893))
		{
			return true;
		}
		return false;
	}

	private static void smethod_11(SparklineGroup sparklineGroup_0)
	{
		Workbook workbook = sparklineGroup_0.SparklineGroupCollection.method_0().Workbook;
		sparklineGroup_0.SeriesColor = GetColor(workbook, null, 1, 0.3499862666707358);
		sparklineGroup_0.NegativePointsColor = GetColor(workbook, null, 0, -0.249977111117893);
		sparklineGroup_0.HorizontalAxisColor = GetColor(workbook, "FF000000", -1, 0.0);
		sparklineGroup_0.MarkersColor = GetColor(workbook, null, 0, -0.249977111117893);
		sparklineGroup_0.FirstPointColor = GetColor(workbook, null, 0, -0.249977111117893);
		sparklineGroup_0.LastPointColor = GetColor(workbook, null, 0, -0.249977111117893);
		sparklineGroup_0.HighPointColor = GetColor(workbook, null, 0, -0.249977111117893);
		sparklineGroup_0.LowPointColor = GetColor(workbook, null, 0, -0.249977111117893);
	}

	private static bool smethod_12(SparklineGroup sparklineGroup_0)
	{
		if (smethod_0(sparklineGroup_0.SeriesColor, null, 1, 0.3499862666707358) && smethod_0(sparklineGroup_0.NegativePointsColor, null, 0, -0.249977111117893) && smethod_0(sparklineGroup_0.HorizontalAxisColor, "FF000000", -1, 0.0) && smethod_0(sparklineGroup_0.MarkersColor, null, 0, -0.249977111117893) && smethod_0(sparklineGroup_0.FirstPointColor, null, 0, -0.249977111117893) && smethod_0(sparklineGroup_0.LastPointColor, null, 0, -0.249977111117893) && smethod_0(sparklineGroup_0.HighPointColor, null, 0, -0.249977111117893) && smethod_0(sparklineGroup_0.LowPointColor, null, 0, -0.249977111117893))
		{
			return true;
		}
		return false;
	}

	private static void smethod_13(SparklineGroup sparklineGroup_0, string string_0, string string_1)
	{
		Workbook workbook = sparklineGroup_0.SparklineGroupCollection.method_0().Workbook;
		sparklineGroup_0.SeriesColor = GetColor(workbook, string_0, -1, 0.0);
		sparklineGroup_0.NegativePointsColor = GetColor(workbook, string_1, -1, 0.0);
		sparklineGroup_0.HorizontalAxisColor = GetColor(workbook, "FF000000", -1, 0.0);
		sparklineGroup_0.MarkersColor = GetColor(workbook, string_1, -1, 0.0);
		sparklineGroup_0.FirstPointColor = GetColor(workbook, string_1, -1, 0.0);
		sparklineGroup_0.LastPointColor = GetColor(workbook, string_1, -1, 0.0);
		sparklineGroup_0.HighPointColor = GetColor(workbook, string_1, -1, 0.0);
		sparklineGroup_0.LowPointColor = GetColor(workbook, string_1, -1, 0.0);
	}

	private static bool smethod_14(SparklineGroup sparklineGroup_0, string string_0, string string_1)
	{
		if (smethod_0(sparklineGroup_0.SeriesColor, string_0, -1, 0.0) && smethod_0(sparklineGroup_0.NegativePointsColor, string_1, -1, 0.0) && smethod_0(sparklineGroup_0.HorizontalAxisColor, "FF000000", -1, 0.0) && smethod_0(sparklineGroup_0.MarkersColor, string_1, -1, 0.0) && smethod_0(sparklineGroup_0.FirstPointColor, string_1, -1, 0.0) && smethod_0(sparklineGroup_0.LastPointColor, string_1, -1, 0.0) && smethod_0(sparklineGroup_0.HighPointColor, string_1, -1, 0.0) && smethod_0(sparklineGroup_0.LowPointColor, string_1, -1, 0.0))
		{
			return true;
		}
		return false;
	}

	private static void smethod_15(SparklineGroup sparklineGroup_0, string string_0, string string_1, string string_2, string string_3, string string_4, string string_5, string string_6)
	{
		Workbook workbook = sparklineGroup_0.SparklineGroupCollection.method_0().Workbook;
		sparklineGroup_0.SeriesColor = GetColor(workbook, string_0, -1, 0.0);
		sparklineGroup_0.NegativePointsColor = GetColor(workbook, string_1, -1, 0.0);
		sparklineGroup_0.HorizontalAxisColor = GetColor(workbook, "FF000000", -1, 0.0);
		sparklineGroup_0.MarkersColor = GetColor(workbook, string_2, -1, 0.0);
		sparklineGroup_0.FirstPointColor = GetColor(workbook, string_3, -1, 0.0);
		sparklineGroup_0.LastPointColor = GetColor(workbook, string_4, -1, 0.0);
		sparklineGroup_0.HighPointColor = GetColor(workbook, string_5, -1, 0.0);
		sparklineGroup_0.LowPointColor = GetColor(workbook, string_6, -1, 0.0);
	}

	private static bool smethod_16(SparklineGroup sparklineGroup_0, string string_0, string string_1, string string_2, string string_3, string string_4, string string_5, string string_6)
	{
		if (smethod_0(sparklineGroup_0.SeriesColor, string_0, -1, 0.0) && smethod_0(sparklineGroup_0.NegativePointsColor, string_1, -1, 0.0) && smethod_0(sparklineGroup_0.HorizontalAxisColor, "FF000000", -1, 0.0) && smethod_0(sparklineGroup_0.MarkersColor, string_2, -1, 0.0) && smethod_0(sparklineGroup_0.FirstPointColor, string_3, -1, 0.0) && smethod_0(sparklineGroup_0.LastPointColor, string_4, -1, 0.0) && smethod_0(sparklineGroup_0.HighPointColor, string_5, -1, 0.0) && smethod_0(sparklineGroup_0.LowPointColor, string_6, -1, 0.0))
		{
			return true;
		}
		return false;
	}

	private static void smethod_17(SparklineGroup sparklineGroup_0, int int_0)
	{
		Workbook workbook = sparklineGroup_0.SparklineGroupCollection.method_0().Workbook;
		sparklineGroup_0.SeriesColor = GetColor(workbook, null, int_0, 0.0);
		sparklineGroup_0.NegativePointsColor = GetColor(workbook, null, 9, 0.0);
		sparklineGroup_0.HorizontalAxisColor = GetColor(workbook, "FF000000", -1, 0.0);
		sparklineGroup_0.MarkersColor = GetColor(workbook, null, 8, 0.0);
		sparklineGroup_0.FirstPointColor = GetColor(workbook, null, 4, 0.0);
		sparklineGroup_0.LastPointColor = GetColor(workbook, null, 5, 0.0);
		sparklineGroup_0.HighPointColor = GetColor(workbook, null, 6, 0.0);
		sparklineGroup_0.LowPointColor = GetColor(workbook, null, 7, 0.0);
	}

	private static bool smethod_18(SparklineGroup sparklineGroup_0, int int_0)
	{
		if (smethod_0(sparklineGroup_0.SeriesColor, null, int_0, 0.0) && smethod_0(sparklineGroup_0.NegativePointsColor, null, 9, 0.0) && smethod_0(sparklineGroup_0.HorizontalAxisColor, "FF000000", -1, 0.0) && smethod_0(sparklineGroup_0.MarkersColor, null, 8, 0.0) && smethod_0(sparklineGroup_0.FirstPointColor, null, 4, 0.0) && smethod_0(sparklineGroup_0.LastPointColor, null, 5, 0.0) && smethod_0(sparklineGroup_0.HighPointColor, null, 6, 0.0) && smethod_0(sparklineGroup_0.LowPointColor, null, 7, 0.0))
		{
			return true;
		}
		return false;
	}
}
