using System;
using System.Collections.Generic;
using Aspose.Cells;
using Aspose.Cells.Pivot;
using Aspose.Cells.Tables;
using ns1;
using ns2;
using ns58;

namespace ns10;

internal class Class1224
{
	internal static OperatorType smethod_0(int int_0)
	{
		return int_0 switch
		{
			0 => OperatorType.None, 
			1 => OperatorType.Between, 
			2 => OperatorType.NotBetween, 
			3 => OperatorType.Equal, 
			4 => OperatorType.NotEqual, 
			5 => OperatorType.GreaterThan, 
			6 => OperatorType.LessThan, 
			7 => OperatorType.GreaterOrEqual, 
			8 => OperatorType.LessOrEqual, 
			_ => OperatorType.None, 
		};
	}

	internal static int smethod_1(OperatorType operatorType_0)
	{
		return operatorType_0 switch
		{
			OperatorType.Between => 1, 
			OperatorType.Equal => 3, 
			OperatorType.GreaterThan => 5, 
			OperatorType.GreaterOrEqual => 7, 
			OperatorType.LessThan => 6, 
			OperatorType.LessOrEqual => 8, 
			OperatorType.None => 0, 
			OperatorType.NotBetween => 2, 
			OperatorType.NotEqual => 4, 
			_ => 0, 
		};
	}

	internal static string smethod_2(int int_0, int int_1)
	{
		switch (int_0)
		{
		case 0:
			return "Normal";
		case 1:
			return "RowLevel_" + int_1;
		case 2:
			return "ColLevel_" + int_1;
		case 3:
			return "Comma";
		case 4:
			return "Currency";
		case 5:
			return "Percent";
		case 6:
			return "Comma [0]";
		case 7:
			return "Currency [0]";
		case 8:
			return "Hyperlink";
		case 9:
			return "Followed Hyperlink";
		case 10:
			return "Note";
		case 11:
			return "Warning Text";
		default:
			return null;
		case 15:
			return "Title";
		case 16:
		case 17:
		case 18:
		case 19:
			return "Head " + (int_0 - 15);
		}
	}

	internal static int smethod_3(string string_0)
	{
		string key;
		if ((key = string_0) != null)
		{
			if (Class1742.dictionary_58 == null)
			{
				Class1742.dictionary_58 = new Dictionary<string, int>(17)
				{
					{ "Normal", 0 },
					{ "RowLevel", 1 },
					{ "ColLevel", 2 },
					{ "Comma", 3 },
					{ "Currency", 4 },
					{ "Percent", 5 },
					{ "Comma [0]", 6 },
					{ "Currency [0]", 7 },
					{ "Hyperlink", 8 },
					{ "Followed Hyperlink", 9 },
					{ "Note", 10 },
					{ "Warning Text", 11 },
					{ "Title", 12 },
					{ "Head 1", 13 },
					{ "Head 2", 14 },
					{ "Head 3", 15 },
					{ "Head 4", 16 }
				};
			}
			if (Class1742.dictionary_58.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return 0;
				case 1:
					return 1;
				case 2:
					return 2;
				case 3:
					return 3;
				case 4:
					return 4;
				case 5:
					return 5;
				case 6:
					return 6;
				case 7:
					return 7;
				case 8:
					return 8;
				case 9:
					return 9;
				case 10:
					return 10;
				case 11:
					return 11;
				case 12:
					return 15;
				case 13:
					return 16;
				case 14:
					return 17;
				case 15:
					return 18;
				case 16:
					return 19;
				}
			}
		}
		return -1;
	}

	internal static FontUnderlineType smethod_4(int int_0)
	{
		FontUnderlineType fontUnderlineType = FontUnderlineType.None;
		return int_0 switch
		{
			33 => FontUnderlineType.Accounting, 
			34 => FontUnderlineType.DoubleAccounting, 
			1 => FontUnderlineType.Single, 
			2 => FontUnderlineType.Double, 
			_ => FontUnderlineType.None, 
		};
	}

	internal static int smethod_5(FontUnderlineType fontUnderlineType_0)
	{
		byte result = 0;
		switch (fontUnderlineType_0)
		{
		case FontUnderlineType.Single:
			result = 1;
			break;
		case FontUnderlineType.Double:
			result = 2;
			break;
		case FontUnderlineType.Accounting:
			result = 33;
			break;
		case FontUnderlineType.DoubleAccounting:
			result = 34;
			break;
		}
		return result;
	}

	internal static TextAlignmentType smethod_6(int int_0)
	{
		TextAlignmentType result = TextAlignmentType.Center;
		switch (int_0)
		{
		case 0:
			result = TextAlignmentType.Top;
			break;
		case 1:
			result = TextAlignmentType.Center;
			break;
		case 2:
			result = TextAlignmentType.Bottom;
			break;
		case 3:
			result = TextAlignmentType.Justify;
			break;
		case 4:
			result = TextAlignmentType.Distributed;
			break;
		}
		return result;
	}

	internal static int smethod_7(TextAlignmentType textAlignmentType_0)
	{
		int result = 1;
		switch (textAlignmentType_0)
		{
		case TextAlignmentType.Top:
			result = 0;
			break;
		case TextAlignmentType.Bottom:
			result = 2;
			break;
		case TextAlignmentType.Center:
			result = 1;
			break;
		case TextAlignmentType.Distributed:
			result = 4;
			break;
		case TextAlignmentType.Justify:
			result = 3;
			break;
		}
		return result;
	}

	internal static TextAlignmentType smethod_8(int int_0)
	{
		TextAlignmentType textAlignmentType = TextAlignmentType.General;
		return int_0 switch
		{
			1 => TextAlignmentType.Left, 
			2 => TextAlignmentType.Center, 
			3 => TextAlignmentType.Right, 
			4 => TextAlignmentType.Fill, 
			5 => TextAlignmentType.Justify, 
			6 => TextAlignmentType.CenterAcross, 
			7 => TextAlignmentType.Distributed, 
			_ => TextAlignmentType.General, 
		};
	}

	internal static int smethod_9(TextAlignmentType textAlignmentType_0)
	{
		int result = 0;
		switch (textAlignmentType_0)
		{
		case TextAlignmentType.Center:
			result = 2;
			break;
		case TextAlignmentType.CenterAcross:
			result = 6;
			break;
		case TextAlignmentType.Distributed:
			result = 7;
			break;
		case TextAlignmentType.Fill:
			result = 4;
			break;
		case TextAlignmentType.Justify:
			result = 5;
			break;
		case TextAlignmentType.Left:
			result = 1;
			break;
		case TextAlignmentType.Right:
			result = 3;
			break;
		}
		return result;
	}

	internal static CellBorderType smethod_10(int int_0)
	{
		CellBorderType cellBorderType = CellBorderType.None;
		return int_0 switch
		{
			1 => CellBorderType.Thin, 
			2 => CellBorderType.Medium, 
			3 => CellBorderType.Dashed, 
			4 => CellBorderType.Dotted, 
			5 => CellBorderType.Thick, 
			6 => CellBorderType.Double, 
			7 => CellBorderType.Hair, 
			8 => CellBorderType.MediumDashed, 
			9 => CellBorderType.DashDot, 
			10 => CellBorderType.MediumDashDot, 
			11 => CellBorderType.DashDotDot, 
			12 => CellBorderType.MediumDashDotDot, 
			13 => CellBorderType.SlantedDashDot, 
			_ => CellBorderType.None, 
		};
	}

	internal static int smethod_11(CellBorderType cellBorderType_0)
	{
		int result = 0;
		switch (cellBorderType_0)
		{
		case CellBorderType.Thin:
			result = 1;
			break;
		case CellBorderType.Medium:
			result = 2;
			break;
		case CellBorderType.Dashed:
			result = 3;
			break;
		case CellBorderType.Dotted:
			result = 4;
			break;
		case CellBorderType.Thick:
			result = 5;
			break;
		case CellBorderType.Double:
			result = 6;
			break;
		case CellBorderType.Hair:
			result = 7;
			break;
		case CellBorderType.MediumDashed:
			result = 8;
			break;
		case CellBorderType.DashDot:
			result = 9;
			break;
		case CellBorderType.MediumDashDot:
			result = 10;
			break;
		case CellBorderType.DashDotDot:
			result = 11;
			break;
		case CellBorderType.MediumDashDotDot:
			result = 12;
			break;
		case CellBorderType.SlantedDashDot:
			result = 13;
			break;
		}
		return result;
	}

	internal static int smethod_12(BackgroundType backgroundType_0)
	{
		int num = 0;
		return backgroundType_0 switch
		{
			BackgroundType.None => 0, 
			BackgroundType.Solid => 1, 
			BackgroundType.Gray50 => 2, 
			BackgroundType.Gray75 => 3, 
			BackgroundType.Gray25 => 4, 
			BackgroundType.HorizontalStripe => 5, 
			BackgroundType.VerticalStripe => 6, 
			BackgroundType.ReverseDiagonalStripe => 7, 
			BackgroundType.DiagonalStripe => 8, 
			BackgroundType.DiagonalCrosshatch => 9, 
			BackgroundType.ThickDiagonalCrosshatch => 10, 
			BackgroundType.ThinHorizontalStripe => 11, 
			BackgroundType.ThinVerticalStripe => 12, 
			BackgroundType.ThinReverseDiagonalStripe => 13, 
			BackgroundType.ThinDiagonalStripe => 14, 
			BackgroundType.ThinHorizontalCrosshatch => 15, 
			BackgroundType.ThinDiagonalCrosshatch => 16, 
			BackgroundType.Gray12 => 17, 
			BackgroundType.Gray6 => 18, 
			_ => 0, 
		};
	}

	internal static BackgroundType smethod_13(int int_0)
	{
		BackgroundType backgroundType = BackgroundType.None;
		return int_0 switch
		{
			0 => BackgroundType.None, 
			1 => BackgroundType.Solid, 
			2 => BackgroundType.Gray50, 
			3 => BackgroundType.Gray75, 
			4 => BackgroundType.Gray25, 
			5 => BackgroundType.HorizontalStripe, 
			6 => BackgroundType.VerticalStripe, 
			7 => BackgroundType.ReverseDiagonalStripe, 
			8 => BackgroundType.DiagonalStripe, 
			9 => BackgroundType.DiagonalCrosshatch, 
			10 => BackgroundType.ThickDiagonalCrosshatch, 
			11 => BackgroundType.ThinHorizontalStripe, 
			12 => BackgroundType.ThinVerticalStripe, 
			13 => BackgroundType.ThinReverseDiagonalStripe, 
			14 => BackgroundType.ThinDiagonalStripe, 
			15 => BackgroundType.ThinHorizontalCrosshatch, 
			16 => BackgroundType.ThinDiagonalCrosshatch, 
			17 => BackgroundType.Gray12, 
			18 => BackgroundType.Gray6, 
			_ => BackgroundType.None, 
		};
	}

	internal static IconSetType smethod_14(int int_0)
	{
		return int_0 switch
		{
			0 => IconSetType.Arrows3, 
			1 => IconSetType.ArrowsGray3, 
			2 => IconSetType.Flags3, 
			3 => IconSetType.TrafficLights31, 
			4 => IconSetType.TrafficLights32, 
			5 => IconSetType.Signs3, 
			6 => IconSetType.Symbols3, 
			7 => IconSetType.Symbols32, 
			8 => IconSetType.Arrows4, 
			9 => IconSetType.ArrowsGray4, 
			10 => IconSetType.RedToBlack4, 
			11 => IconSetType.Rating4, 
			12 => IconSetType.TrafficLights4, 
			13 => IconSetType.Arrows5, 
			14 => IconSetType.ArrowsGray5, 
			15 => IconSetType.Rating5, 
			16 => IconSetType.Quarters5, 
			_ => IconSetType.Arrows3, 
		};
	}

	internal static int smethod_15(IconSetType iconSetType_0)
	{
		return iconSetType_0 switch
		{
			IconSetType.Arrows3 => 0, 
			IconSetType.ArrowsGray3 => 1, 
			IconSetType.Flags3 => 2, 
			IconSetType.Signs3 => 5, 
			IconSetType.Symbols3 => 6, 
			IconSetType.Symbols32 => 7, 
			IconSetType.TrafficLights31 => 3, 
			IconSetType.TrafficLights32 => 4, 
			IconSetType.Arrows4 => 8, 
			IconSetType.ArrowsGray4 => 9, 
			IconSetType.Rating4 => 11, 
			IconSetType.RedToBlack4 => 10, 
			IconSetType.TrafficLights4 => 12, 
			IconSetType.Arrows5 => 13, 
			IconSetType.ArrowsGray5 => 14, 
			IconSetType.Quarters5 => 16, 
			IconSetType.Rating5 => 15, 
			_ => -1, 
		};
	}

	internal static string smethod_16(int int_0)
	{
		return int_0 switch
		{
			1 => "gregorian", 
			2 => "gregorianUs", 
			3 => "japan", 
			4 => "taiwan", 
			5 => "korea", 
			6 => "hijri", 
			7 => "thai", 
			8 => "hebrew", 
			9 => "gregorianMeFrench", 
			10 => "gregorianArabic", 
			11 => "gregorianXlitEnglish", 
			12 => "gregorianXlitFrench", 
			_ => "none", 
		};
	}

	internal static DynamicFilterType smethod_17(int int_0)
	{
		return int_0 switch
		{
			1 => DynamicFilterType.AboveAverage, 
			2 => DynamicFilterType.BelowAverage, 
			8 => DynamicFilterType.Tomorrow, 
			9 => DynamicFilterType.Today, 
			10 => DynamicFilterType.Yesterday, 
			11 => DynamicFilterType.NextWeek, 
			12 => DynamicFilterType.ThisWeek, 
			13 => DynamicFilterType.LastWeek, 
			14 => DynamicFilterType.NextMonth, 
			15 => DynamicFilterType.ThisMonth, 
			16 => DynamicFilterType.LastMonth, 
			17 => DynamicFilterType.NextQuarter, 
			18 => DynamicFilterType.ThisQuarter, 
			19 => DynamicFilterType.LastQuarter, 
			20 => DynamicFilterType.NextYear, 
			21 => DynamicFilterType.ThisYear, 
			22 => DynamicFilterType.LastYear, 
			23 => DynamicFilterType.YearToDate, 
			24 => DynamicFilterType.Quarter1, 
			25 => DynamicFilterType.Quarter2, 
			26 => DynamicFilterType.Quarter3, 
			27 => DynamicFilterType.Quarter4, 
			28 => DynamicFilterType.January, 
			29 => DynamicFilterType.Februray, 
			30 => DynamicFilterType.March, 
			31 => DynamicFilterType.April, 
			32 => DynamicFilterType.May, 
			33 => DynamicFilterType.June, 
			34 => DynamicFilterType.July, 
			35 => DynamicFilterType.August, 
			36 => DynamicFilterType.September, 
			37 => DynamicFilterType.October, 
			38 => DynamicFilterType.November, 
			39 => DynamicFilterType.December, 
			_ => DynamicFilterType.None, 
		};
	}

	internal static int smethod_18(DynamicFilterType dynamicFilterType_0)
	{
		return dynamicFilterType_0 switch
		{
			DynamicFilterType.AboveAverage => 1, 
			DynamicFilterType.BelowAverage => 2, 
			DynamicFilterType.LastMonth => 16, 
			DynamicFilterType.LastQuarter => 19, 
			DynamicFilterType.LastWeek => 13, 
			DynamicFilterType.LastYear => 22, 
			DynamicFilterType.January => 28, 
			DynamicFilterType.October => 37, 
			DynamicFilterType.November => 38, 
			DynamicFilterType.December => 39, 
			DynamicFilterType.Februray => 29, 
			DynamicFilterType.March => 30, 
			DynamicFilterType.April => 31, 
			DynamicFilterType.May => 32, 
			DynamicFilterType.June => 33, 
			DynamicFilterType.July => 34, 
			DynamicFilterType.August => 35, 
			DynamicFilterType.September => 36, 
			DynamicFilterType.NextMonth => 14, 
			DynamicFilterType.NextQuarter => 17, 
			DynamicFilterType.NextWeek => 11, 
			DynamicFilterType.NextYear => 20, 
			DynamicFilterType.Quarter1 => 24, 
			DynamicFilterType.Quarter2 => 25, 
			DynamicFilterType.Quarter3 => 26, 
			DynamicFilterType.Quarter4 => 27, 
			DynamicFilterType.ThisMonth => 15, 
			DynamicFilterType.ThisQuarter => 18, 
			DynamicFilterType.ThisWeek => 12, 
			DynamicFilterType.ThisYear => 21, 
			DynamicFilterType.Today => 9, 
			DynamicFilterType.Tomorrow => 8, 
			DynamicFilterType.YearToDate => 23, 
			DynamicFilterType.Yesterday => 10, 
			_ => 0, 
		};
	}

	internal static FilterOperatorType smethod_19(int int_0)
	{
		return int_0 switch
		{
			1 => FilterOperatorType.LessThan, 
			2 => FilterOperatorType.Equal, 
			3 => FilterOperatorType.LessOrEqual, 
			4 => FilterOperatorType.GreaterThan, 
			5 => FilterOperatorType.NotEqual, 
			6 => FilterOperatorType.GreaterOrEqual, 
			_ => FilterOperatorType.Equal, 
		};
	}

	internal static byte smethod_20(FilterOperatorType filterOperatorType_0)
	{
		return filterOperatorType_0 switch
		{
			FilterOperatorType.LessOrEqual => 3, 
			FilterOperatorType.LessThan => 1, 
			FilterOperatorType.Equal => 2, 
			FilterOperatorType.GreaterThan => 4, 
			FilterOperatorType.NotEqual => 5, 
			FilterOperatorType.GreaterOrEqual => 6, 
			_ => 0, 
		};
	}

	internal static DateTimeGroupingType smethod_21(int int_0)
	{
		return int_0 switch
		{
			-1 => DateTimeGroupingType.Day, 
			0 => DateTimeGroupingType.Year, 
			1 => DateTimeGroupingType.Month, 
			2 => DateTimeGroupingType.Day, 
			3 => DateTimeGroupingType.Hour, 
			4 => DateTimeGroupingType.Minute, 
			5 => DateTimeGroupingType.Second, 
			_ => DateTimeGroupingType.Day, 
		};
	}

	internal static int smethod_22(DateTimeGroupingType dateTimeGroupingType_0)
	{
		return dateTimeGroupingType_0 switch
		{
			DateTimeGroupingType.Day => 2, 
			DateTimeGroupingType.Hour => 3, 
			DateTimeGroupingType.Minute => 4, 
			DateTimeGroupingType.Month => 1, 
			DateTimeGroupingType.Second => 5, 
			DateTimeGroupingType.Year => 0, 
			_ => -1, 
		};
	}

	internal static void smethod_23(byte[] byte_0, int int_0, int int_1, int int_2, FormatCondition formatCondition_0)
	{
		switch (int_0)
		{
		default:
			throw new CellsException(ExceptionType.InvalidData, "Invalid FormatConditionType string val");
		case 1:
			formatCondition_0.Type = FormatConditionType.CellValue;
			break;
		case 2:
			switch (int_1)
			{
			case 7:
				formatCondition_0.Type = FormatConditionType.UniqueValues;
				break;
			case 8:
				switch (int_2)
				{
				default:
					formatCondition_0.Type = FormatConditionType.ContainsText;
					break;
				case 0:
					formatCondition_0.Type = FormatConditionType.ContainsText;
					break;
				case 1:
					formatCondition_0.Type = FormatConditionType.NotContainsText;
					break;
				case 2:
					formatCondition_0.Type = FormatConditionType.BeginsWith;
					break;
				case 3:
					formatCondition_0.Type = FormatConditionType.EndsWith;
					break;
				}
				break;
			case 9:
				formatCondition_0.Type = FormatConditionType.ContainsBlanks;
				break;
			case 10:
				formatCondition_0.Type = FormatConditionType.NotContainsBlanks;
				break;
			case 11:
				formatCondition_0.Type = FormatConditionType.ContainsErrors;
				break;
			case 12:
				formatCondition_0.Type = FormatConditionType.NotContainsErrors;
				break;
			case 15:
				formatCondition_0.TimePeriod = TimePeriodType.Today;
				formatCondition_0.Type = FormatConditionType.TimePeriod;
				break;
			case 16:
				formatCondition_0.TimePeriod = TimePeriodType.Tomorrow;
				formatCondition_0.Type = FormatConditionType.TimePeriod;
				break;
			case 17:
				formatCondition_0.TimePeriod = TimePeriodType.Yesterday;
				formatCondition_0.Type = FormatConditionType.TimePeriod;
				break;
			case 18:
				formatCondition_0.TimePeriod = TimePeriodType.Last7Days;
				formatCondition_0.Type = FormatConditionType.TimePeriod;
				break;
			case 19:
				formatCondition_0.TimePeriod = TimePeriodType.LastMonth;
				formatCondition_0.Type = FormatConditionType.TimePeriod;
				break;
			case 20:
				formatCondition_0.TimePeriod = TimePeriodType.NextMonth;
				formatCondition_0.Type = FormatConditionType.TimePeriod;
				break;
			case 21:
				formatCondition_0.TimePeriod = TimePeriodType.ThisWeek;
				formatCondition_0.Type = FormatConditionType.TimePeriod;
				break;
			case 22:
				formatCondition_0.TimePeriod = TimePeriodType.NextWeek;
				formatCondition_0.Type = FormatConditionType.TimePeriod;
				break;
			case 23:
				formatCondition_0.TimePeriod = TimePeriodType.LastWeek;
				formatCondition_0.Type = FormatConditionType.TimePeriod;
				break;
			case 24:
				formatCondition_0.TimePeriod = TimePeriodType.ThisMonth;
				formatCondition_0.Type = FormatConditionType.TimePeriod;
				break;
			case 25:
				formatCondition_0.Type = FormatConditionType.AboveAverage;
				formatCondition_0.AboveAverage.IsAboveAverage = true;
				formatCondition_0.AboveAverage.IsEqualAverage = false;
				formatCondition_0.AboveAverage.StdDev = BitConverter.ToInt32(byte_0, 16);
				break;
			case 26:
				formatCondition_0.Type = FormatConditionType.AboveAverage;
				formatCondition_0.AboveAverage.IsAboveAverage = false;
				formatCondition_0.AboveAverage.IsEqualAverage = false;
				formatCondition_0.AboveAverage.StdDev = BitConverter.ToInt32(byte_0, 16);
				break;
			case 27:
				formatCondition_0.Type = FormatConditionType.DuplicateValues;
				break;
			default:
				formatCondition_0.Type = FormatConditionType.Expression;
				break;
			case 29:
				formatCondition_0.Type = FormatConditionType.AboveAverage;
				formatCondition_0.AboveAverage.IsAboveAverage = true;
				formatCondition_0.AboveAverage.IsEqualAverage = true;
				formatCondition_0.AboveAverage.StdDev = BitConverter.ToInt32(byte_0, 16);
				break;
			case 30:
				formatCondition_0.Type = FormatConditionType.AboveAverage;
				formatCondition_0.AboveAverage.IsAboveAverage = false;
				formatCondition_0.AboveAverage.IsEqualAverage = true;
				formatCondition_0.AboveAverage.StdDev = BitConverter.ToInt32(byte_0, 16);
				break;
			}
			break;
		case 3:
			formatCondition_0.Type = FormatConditionType.ColorScale;
			break;
		case 4:
			formatCondition_0.Type = FormatConditionType.DataBar;
			break;
		case 5:
		{
			formatCondition_0.Type = FormatConditionType.Top10;
			Top10 top = new Top10();
			formatCondition_0.method_21(top);
			top.IsBottom = (byte_0[28] & 8) != 0;
			top.IsPercent = (byte_0[28] & 0x10) != 0;
			top.Rank = BitConverter.ToInt32(byte_0, 16);
			break;
		}
		case 6:
			formatCondition_0.Type = FormatConditionType.IconSet;
			break;
		}
	}

	internal static FormatConditionValueType smethod_24(int int_0)
	{
		return int_0 switch
		{
			1 => FormatConditionValueType.Number, 
			2 => FormatConditionValueType.Min, 
			3 => FormatConditionValueType.Max, 
			4 => FormatConditionValueType.Percent, 
			5 => FormatConditionValueType.Percentile, 
			7 => FormatConditionValueType.Formula, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid FormatConditionType val"), 
		};
	}

	internal static int smethod_25(FormatConditionValueType formatConditionValueType_0)
	{
		return formatConditionValueType_0 switch
		{
			FormatConditionValueType.Formula => 7, 
			FormatConditionValueType.Max => 3, 
			FormatConditionValueType.Min => 2, 
			FormatConditionValueType.Number => 1, 
			FormatConditionValueType.Percent => 4, 
			FormatConditionValueType.Percentile => 5, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid FormatConditionType val"), 
		};
	}

	internal static Enum234 smethod_26(int int_0)
	{
		return int_0 switch
		{
			1 => Enum234.const_1, 
			2 => Enum234.const_2, 
			3 => Enum234.const_3, 
			_ => Enum234.const_0, 
		};
	}

	internal static int smethod_27(Enum234 enum234_0)
	{
		return enum234_0 switch
		{
			Enum234.const_1 => 1, 
			Enum234.const_2 => 2, 
			Enum234.const_3 => 3, 
			_ => 0, 
		};
	}

	internal static TotalsCalculation smethod_28(int int_0)
	{
		return int_0 switch
		{
			0 => TotalsCalculation.None, 
			1 => TotalsCalculation.Average, 
			2 => TotalsCalculation.Count, 
			3 => TotalsCalculation.CountNums, 
			4 => TotalsCalculation.Max, 
			5 => TotalsCalculation.Min, 
			6 => TotalsCalculation.Sum, 
			7 => TotalsCalculation.StdDev, 
			8 => TotalsCalculation.Var, 
			9 => TotalsCalculation.Custom, 
			_ => TotalsCalculation.None, 
		};
	}

	internal static int smethod_29(TotalsCalculation totalsCalculation_0)
	{
		return totalsCalculation_0 switch
		{
			TotalsCalculation.None => 0, 
			TotalsCalculation.Average => 1, 
			TotalsCalculation.Count => 2, 
			TotalsCalculation.CountNums => 3, 
			TotalsCalculation.Max => 4, 
			TotalsCalculation.Min => 5, 
			TotalsCalculation.Sum => 6, 
			TotalsCalculation.StdDev => 7, 
			TotalsCalculation.Var => 8, 
			TotalsCalculation.Custom => 9, 
			_ => 0, 
		};
	}

	internal static TableStyleElementType smethod_30(int int_0)
	{
		return int_0 switch
		{
			0 => TableStyleElementType.WholeTable, 
			1 => TableStyleElementType.HeaderRow, 
			2 => TableStyleElementType.TotalRow, 
			3 => TableStyleElementType.FirstColumn, 
			4 => TableStyleElementType.LastColumn, 
			5 => TableStyleElementType.FirstRowStripe, 
			6 => TableStyleElementType.SecondRowStripe, 
			7 => TableStyleElementType.FirstColumnStripe, 
			8 => TableStyleElementType.SecondColumnStripe, 
			9 => TableStyleElementType.FirstHeaderCell, 
			10 => TableStyleElementType.LastHeaderCell, 
			11 => TableStyleElementType.FirstTotalCell, 
			12 => TableStyleElementType.LastTotalCell, 
			13 => TableStyleElementType.FirstSubtotalColumn, 
			14 => TableStyleElementType.SecondSubtotalColumn, 
			15 => TableStyleElementType.ThirdSubtotalColumn, 
			16 => TableStyleElementType.FirstSubtotalRow, 
			17 => TableStyleElementType.SecondSubtotalRow, 
			18 => TableStyleElementType.ThirdSubtotalRow, 
			19 => TableStyleElementType.BlankRow, 
			20 => TableStyleElementType.FirstColumnSubheading, 
			21 => TableStyleElementType.SecondColumnSubheading, 
			22 => TableStyleElementType.ThirdColumnSubheading, 
			23 => TableStyleElementType.FirstRowSubheading, 
			24 => TableStyleElementType.SecondRowSubheading, 
			25 => TableStyleElementType.ThirdRowSubheading, 
			26 => TableStyleElementType.PageFieldLabels, 
			27 => TableStyleElementType.PageFieldValues, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Error TableStyleElementType value"), 
		};
	}

	internal static int smethod_31(TableStyleElementType tableStyleElementType_0)
	{
		return tableStyleElementType_0 switch
		{
			TableStyleElementType.WholeTable => 0, 
			TableStyleElementType.PageFieldLabels => 26, 
			TableStyleElementType.PageFieldValues => 27, 
			TableStyleElementType.FirstColumnStripe => 7, 
			TableStyleElementType.SecondColumnStripe => 8, 
			TableStyleElementType.FirstRowStripe => 5, 
			TableStyleElementType.SecondRowStripe => 6, 
			TableStyleElementType.LastColumn => 4, 
			TableStyleElementType.FirstColumn => 3, 
			TableStyleElementType.HeaderRow => 1, 
			TableStyleElementType.TotalRow => 2, 
			TableStyleElementType.FirstHeaderCell => 9, 
			TableStyleElementType.LastHeaderCell => 10, 
			TableStyleElementType.FirstTotalCell => 11, 
			TableStyleElementType.LastTotalCell => 12, 
			TableStyleElementType.FirstSubtotalColumn => 13, 
			TableStyleElementType.SecondSubtotalColumn => 14, 
			TableStyleElementType.ThirdSubtotalColumn => 15, 
			TableStyleElementType.BlankRow => 19, 
			TableStyleElementType.FirstSubtotalRow => 16, 
			TableStyleElementType.SecondSubtotalRow => 17, 
			TableStyleElementType.ThirdSubtotalRow => 18, 
			TableStyleElementType.FirstColumnSubheading => 20, 
			TableStyleElementType.SecondColumnSubheading => 21, 
			TableStyleElementType.ThirdColumnSubheading => 22, 
			TableStyleElementType.FirstRowSubheading => 23, 
			TableStyleElementType.SecondRowSubheading => 24, 
			TableStyleElementType.ThirdRowSubheading => 25, 
			TableStyleElementType.GrandTotalColumn => 28, 
			TableStyleElementType.GrandTotalRow => 29, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Error TableStyleElementType value"), 
		};
	}

	internal static PivotFieldSubtotalType smethod_32(byte byte_0)
	{
		return byte_0 switch
		{
			2 => PivotFieldSubtotalType.Sum, 
			3 => PivotFieldSubtotalType.CountNums, 
			4 => PivotFieldSubtotalType.Average, 
			5 => PivotFieldSubtotalType.Max, 
			6 => PivotFieldSubtotalType.Min, 
			7 => PivotFieldSubtotalType.Product, 
			8 => PivotFieldSubtotalType.Count, 
			9 => PivotFieldSubtotalType.Stdev, 
			10 => PivotFieldSubtotalType.Stdevp, 
			11 => PivotFieldSubtotalType.Var, 
			12 => PivotFieldSubtotalType.Varp, 
			_ => PivotFieldSubtotalType.Automatic, 
		};
	}

	internal static PivotTableSourceType smethod_33(int int_0)
	{
		return int_0 switch
		{
			0 => PivotTableSourceType.ListDatabase, 
			1 => PivotTableSourceType.External, 
			2 => PivotTableSourceType.Consilidation, 
			3 => PivotTableSourceType.PivotTable, 
			_ => PivotTableSourceType.ListDatabase, 
		};
	}

	internal static PivotFilterType smethod_34(int int_0)
	{
		return int_0 switch
		{
			1 => PivotFilterType.Count, 
			2 => PivotFilterType.Percent, 
			3 => PivotFilterType.Sum, 
			4 => PivotFilterType.CaptionEqual, 
			5 => PivotFilterType.CaptionNotEqual, 
			6 => PivotFilterType.CaptionBeginsWith, 
			7 => PivotFilterType.CaptionNotBeginsWith, 
			8 => PivotFilterType.CaptionEndsWith, 
			9 => PivotFilterType.CaptionNotEndsWith, 
			10 => PivotFilterType.CaptionContains, 
			11 => PivotFilterType.CaptionNotContains, 
			12 => PivotFilterType.CaptionGreaterThan, 
			13 => PivotFilterType.CaptionGreaterThanOrEqual, 
			14 => PivotFilterType.CaptionLessThan, 
			15 => PivotFilterType.CaptionLessThanOrEqual, 
			16 => PivotFilterType.CaptionBetween, 
			17 => PivotFilterType.CaptionNotBetween, 
			18 => PivotFilterType.ValueEqual, 
			19 => PivotFilterType.ValueNotEqual, 
			20 => PivotFilterType.ValueGreaterThan, 
			21 => PivotFilterType.ValueGreaterThanOrEqual, 
			22 => PivotFilterType.ValueLessThan, 
			23 => PivotFilterType.ValueLessThanOrEqual, 
			24 => PivotFilterType.ValueBetween, 
			25 => PivotFilterType.ValueNotBetween, 
			26 => PivotFilterType.DateEqual, 
			27 => PivotFilterType.DateOlderThan, 
			28 => PivotFilterType.DateNewerThan, 
			29 => PivotFilterType.DateBetween, 
			30 => PivotFilterType.Tomorrow, 
			31 => PivotFilterType.Today, 
			32 => PivotFilterType.Yesterday, 
			33 => PivotFilterType.NextWeek, 
			34 => PivotFilterType.ThisWeek, 
			35 => PivotFilterType.LastWeek, 
			36 => PivotFilterType.NextMonth, 
			37 => PivotFilterType.ThisMonth, 
			38 => PivotFilterType.LastMonth, 
			39 => PivotFilterType.NextQuarter, 
			40 => PivotFilterType.ThisQuarter, 
			41 => PivotFilterType.LastQuarter, 
			42 => PivotFilterType.NextYear, 
			43 => PivotFilterType.ThisYear, 
			44 => PivotFilterType.LastYear, 
			45 => PivotFilterType.YearToDate, 
			46 => PivotFilterType.Q1, 
			47 => PivotFilterType.Q2, 
			48 => PivotFilterType.Q3, 
			49 => PivotFilterType.Q4, 
			50 => PivotFilterType.M1, 
			51 => PivotFilterType.M2, 
			52 => PivotFilterType.M3, 
			53 => PivotFilterType.M4, 
			54 => PivotFilterType.M5, 
			55 => PivotFilterType.M6, 
			56 => PivotFilterType.M7, 
			57 => PivotFilterType.M8, 
			58 => PivotFilterType.M9, 
			59 => PivotFilterType.M10, 
			60 => PivotFilterType.M11, 
			61 => PivotFilterType.M12, 
			62 => PivotFilterType.DateNotEqual, 
			63 => PivotFilterType.DateOlderThanOrEqual, 
			64 => PivotFilterType.DateNewerThanOrEqual, 
			65 => PivotFilterType.DateNotBetween, 
			_ => PivotFilterType.Unknown, 
		};
	}

	internal static PivotConditionFormatScopeType smethod_35(int int_0)
	{
		return int_0 switch
		{
			0 => PivotConditionFormatScopeType.selection, 
			1 => PivotConditionFormatScopeType.data, 
			2 => PivotConditionFormatScopeType.field, 
			_ => PivotConditionFormatScopeType.selection, 
		};
	}

	internal static PivotGroupByType smethod_36(int int_0)
	{
		return int_0 switch
		{
			0 => PivotGroupByType.RangeOfValues, 
			1 => PivotGroupByType.Seconds, 
			2 => PivotGroupByType.Minutes, 
			3 => PivotGroupByType.Hours, 
			4 => PivotGroupByType.Days, 
			5 => PivotGroupByType.Months, 
			6 => PivotGroupByType.Quarters, 
			7 => PivotGroupByType.Years, 
			_ => PivotGroupByType.RangeOfValues, 
		};
	}

	internal static Enum193 smethod_37(byte byte_0)
	{
		return byte_0 switch
		{
			1 => Enum193.const_1, 
			2 => Enum193.const_2, 
			_ => Enum193.const_0, 
		};
	}

	internal static string smethod_38(byte byte_0)
	{
		return byte_0 switch
		{
			0 => null, 
			1 => "major", 
			2 => "minor", 
			_ => null, 
		};
	}

	internal static byte smethod_39(string string_0)
	{
		return string_0 switch
		{
			"minor" => 2, 
			"major" => 1, 
			null => 0, 
			_ => 0, 
		};
	}
}
