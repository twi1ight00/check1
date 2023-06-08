using System.Collections.Generic;
using System.Text;
using Aspose.Cells;
using Aspose.Cells.Pivot;
using ns1;
using ns16;

namespace ns45;

internal class Class1156
{
	internal static string smethod_0(PivotConditionFormatScopeType pivotConditionFormatScopeType_0)
	{
		return pivotConditionFormatScopeType_0 switch
		{
			PivotConditionFormatScopeType.data => "data", 
			PivotConditionFormatScopeType.field => "field", 
			PivotConditionFormatScopeType.selection => "selection", 
			_ => "", 
		};
	}

	internal static PivotConditionFormatScopeType smethod_1(string string_0)
	{
		return string_0 switch
		{
			"selection" => PivotConditionFormatScopeType.selection, 
			"field" => PivotConditionFormatScopeType.field, 
			"data" => PivotConditionFormatScopeType.data, 
			_ => PivotConditionFormatScopeType.selection, 
		};
	}

	internal static PivotGroupByType smethod_2(int int_0)
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

	internal static string smethod_3(PivotGroupByType pivotGroupByType_0)
	{
		return pivotGroupByType_0 switch
		{
			PivotGroupByType.RangeOfValues => "range", 
			PivotGroupByType.Seconds => "seconds", 
			PivotGroupByType.Minutes => "minutes", 
			PivotGroupByType.Hours => "hours", 
			PivotGroupByType.Days => "days", 
			PivotGroupByType.Months => "months", 
			PivotGroupByType.Quarters => "quarters", 
			PivotGroupByType.Years => "years", 
			_ => "", 
		};
	}

	internal static int smethod_4(PivotGroupByType pivotGroupByType_0)
	{
		return pivotGroupByType_0 switch
		{
			PivotGroupByType.RangeOfValues => 0, 
			PivotGroupByType.Seconds => 1, 
			PivotGroupByType.Minutes => 2, 
			PivotGroupByType.Hours => 3, 
			PivotGroupByType.Days => 4, 
			PivotGroupByType.Months => 5, 
			PivotGroupByType.Quarters => 6, 
			PivotGroupByType.Years => 7, 
			_ => 0, 
		};
	}

	internal static PivotFilterType smethod_5(string string_0)
	{
		string key;
		if ((key = string_0) != null)
		{
			if (Class1742.dictionary_52 == null)
			{
				Class1742.dictionary_52 = new Dictionary<string, int>(65)
				{
					{ "captionBeginsWith", 0 },
					{ "captionBetween", 1 },
					{ "captionContains", 2 },
					{ "captionEndsWith", 3 },
					{ "captionEqual", 4 },
					{ "captionGreaterThan", 5 },
					{ "captionGreaterThanOrEqual", 6 },
					{ "captionLessThan", 7 },
					{ "captionLessThanOrEqual", 8 },
					{ "captionNotBeginsWith", 9 },
					{ "captionNotBetween", 10 },
					{ "captionNotContains", 11 },
					{ "captionNotEndsWith", 12 },
					{ "captionNotEqual", 13 },
					{ "count", 14 },
					{ "dateBetween", 15 },
					{ "dateEqual", 16 },
					{ "dateNewerThan", 17 },
					{ "dateNewerThanOrEqual", 18 },
					{ "dateNotBetween", 19 },
					{ "dateNotEqual", 20 },
					{ "dateOlderThan", 21 },
					{ "dateOlderThanOrEqual", 22 },
					{ "lastMonth", 23 },
					{ "lastQuarter", 24 },
					{ "lastWeek", 25 },
					{ "lastYear", 26 },
					{ "M1", 27 },
					{ "M10", 28 },
					{ "M11", 29 },
					{ "M12", 30 },
					{ "M2", 31 },
					{ "M3", 32 },
					{ "M4", 33 },
					{ "M5", 34 },
					{ "M6", 35 },
					{ "M7", 36 },
					{ "M8", 37 },
					{ "M9", 38 },
					{ "nextMonth", 39 },
					{ "nextQuarter", 40 },
					{ "nextWeek", 41 },
					{ "nextYear", 42 },
					{ "percent", 43 },
					{ "Q1", 44 },
					{ "Q2", 45 },
					{ "Q3", 46 },
					{ "Q4", 47 },
					{ "sum", 48 },
					{ "thisMonth", 49 },
					{ "thisQuarter", 50 },
					{ "thisWeek", 51 },
					{ "thisYear", 52 },
					{ "today", 53 },
					{ "tomorrow", 54 },
					{ "valueBetween", 55 },
					{ "valueEqual", 56 },
					{ "valueGreaterThan", 57 },
					{ "valueGreaterThanOrEqual", 58 },
					{ "valueLessThan", 59 },
					{ "valueLessThanOrEqual", 60 },
					{ "valueNotBetween", 61 },
					{ "valueNotEqual", 62 },
					{ "yearToDate", 63 },
					{ "yesterday", 64 }
				};
			}
			if (Class1742.dictionary_52.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return PivotFilterType.CaptionBeginsWith;
				case 1:
					return PivotFilterType.CaptionBetween;
				case 2:
					return PivotFilterType.CaptionContains;
				case 3:
					return PivotFilterType.CaptionEndsWith;
				case 4:
					return PivotFilterType.CaptionEqual;
				case 5:
					return PivotFilterType.CaptionGreaterThan;
				case 6:
					return PivotFilterType.CaptionGreaterThanOrEqual;
				case 7:
					return PivotFilterType.CaptionLessThan;
				case 8:
					return PivotFilterType.CaptionLessThanOrEqual;
				case 9:
					return PivotFilterType.CaptionNotBeginsWith;
				case 10:
					return PivotFilterType.CaptionNotBetween;
				case 11:
					return PivotFilterType.CaptionNotContains;
				case 12:
					return PivotFilterType.CaptionNotEndsWith;
				case 13:
					return PivotFilterType.CaptionNotEqual;
				case 14:
					return PivotFilterType.Count;
				case 15:
					return PivotFilterType.DateBetween;
				case 16:
					return PivotFilterType.DateEqual;
				case 17:
					return PivotFilterType.DateNewerThan;
				case 18:
					return PivotFilterType.DateNewerThanOrEqual;
				case 19:
					return PivotFilterType.DateNotBetween;
				case 20:
					return PivotFilterType.DateNotEqual;
				case 21:
					return PivotFilterType.DateOlderThan;
				case 22:
					return PivotFilterType.DateOlderThanOrEqual;
				case 23:
					return PivotFilterType.LastMonth;
				case 24:
					return PivotFilterType.LastQuarter;
				case 25:
					return PivotFilterType.LastWeek;
				case 26:
					return PivotFilterType.LastYear;
				case 27:
					return PivotFilterType.M1;
				case 28:
					return PivotFilterType.M10;
				case 29:
					return PivotFilterType.M11;
				case 30:
					return PivotFilterType.M12;
				case 31:
					return PivotFilterType.M2;
				case 32:
					return PivotFilterType.M3;
				case 33:
					return PivotFilterType.M4;
				case 34:
					return PivotFilterType.M5;
				case 35:
					return PivotFilterType.M6;
				case 36:
					return PivotFilterType.M7;
				case 37:
					return PivotFilterType.M8;
				case 38:
					return PivotFilterType.M9;
				case 39:
					return PivotFilterType.NextMonth;
				case 40:
					return PivotFilterType.NextQuarter;
				case 41:
					return PivotFilterType.NextWeek;
				case 42:
					return PivotFilterType.NextYear;
				case 43:
					return PivotFilterType.Percent;
				case 44:
					return PivotFilterType.Q1;
				case 45:
					return PivotFilterType.Q2;
				case 46:
					return PivotFilterType.Q3;
				case 47:
					return PivotFilterType.Q4;
				case 48:
					return PivotFilterType.Sum;
				case 49:
					return PivotFilterType.ThisMonth;
				case 50:
					return PivotFilterType.ThisQuarter;
				case 51:
					return PivotFilterType.ThisWeek;
				case 52:
					return PivotFilterType.ThisYear;
				case 53:
					return PivotFilterType.Today;
				case 54:
					return PivotFilterType.Tomorrow;
				case 55:
					return PivotFilterType.ValueBetween;
				case 56:
					return PivotFilterType.ValueEqual;
				case 57:
					return PivotFilterType.ValueGreaterThan;
				case 58:
					return PivotFilterType.ValueGreaterThanOrEqual;
				case 59:
					return PivotFilterType.ValueLessThan;
				case 60:
					return PivotFilterType.ValueLessThanOrEqual;
				case 61:
					return PivotFilterType.ValueNotBetween;
				case 62:
					return PivotFilterType.ValueNotEqual;
				case 63:
					return PivotFilterType.YearToDate;
				case 64:
					return PivotFilterType.Yesterday;
				}
			}
		}
		return PivotFilterType.Unknown;
	}

	internal static string smethod_6(PivotFilterType pivotFilterType_0)
	{
		return pivotFilterType_0 switch
		{
			PivotFilterType.CaptionBeginsWith => "captionBeginsWith", 
			PivotFilterType.CaptionBetween => "captionBetween", 
			PivotFilterType.CaptionContains => "captionContains", 
			PivotFilterType.CaptionEndsWith => "captionEndsWith", 
			PivotFilterType.CaptionEqual => "captionEqual", 
			PivotFilterType.CaptionGreaterThan => "captionGreaterThan", 
			PivotFilterType.CaptionGreaterThanOrEqual => "captionGreaterThanOrEqual", 
			PivotFilterType.CaptionLessThan => "captionLessThan", 
			PivotFilterType.CaptionLessThanOrEqual => "captionLessThanOrEqual", 
			PivotFilterType.CaptionNotBeginsWith => "captionNotBeginsWith", 
			PivotFilterType.CaptionNotBetween => "captionNotBetween", 
			PivotFilterType.CaptionNotContains => "captionNotContains", 
			PivotFilterType.CaptionNotEndsWith => "captionNotEndsWith", 
			PivotFilterType.CaptionNotEqual => "captionNotEqual", 
			PivotFilterType.Count => "count", 
			PivotFilterType.DateBetween => "dateBetween", 
			PivotFilterType.DateEqual => "dateEqual", 
			PivotFilterType.DateNewerThan => "dateNewerThan", 
			PivotFilterType.DateNewerThanOrEqual => "dateNewerThanOrEqual", 
			PivotFilterType.DateNotBetween => "dateNotBetween", 
			PivotFilterType.DateNotEqual => "dateNotEqual", 
			PivotFilterType.DateOlderThan => "dateOlderThan", 
			PivotFilterType.DateOlderThanOrEqual => "dateOlderThanOrEqual", 
			PivotFilterType.LastMonth => "lastMonth", 
			PivotFilterType.LastQuarter => "lastQuarter", 
			PivotFilterType.LastWeek => "lastWeek", 
			PivotFilterType.LastYear => "lastYear", 
			PivotFilterType.M1 => "M1", 
			PivotFilterType.M2 => "M2", 
			PivotFilterType.M3 => "M3", 
			PivotFilterType.M4 => "M4", 
			PivotFilterType.M5 => "M5", 
			PivotFilterType.M6 => "M6", 
			PivotFilterType.M7 => "M7", 
			PivotFilterType.M8 => "M8", 
			PivotFilterType.M9 => "M9", 
			PivotFilterType.M10 => "M10", 
			PivotFilterType.M11 => "M11", 
			PivotFilterType.M12 => "M12", 
			PivotFilterType.NextMonth => "nextMonth", 
			PivotFilterType.NextQuarter => "nextQuarter", 
			PivotFilterType.NextWeek => "nextWeek", 
			PivotFilterType.NextYear => "nextYear", 
			PivotFilterType.Percent => "percent", 
			PivotFilterType.Q1 => "Q1", 
			PivotFilterType.Q2 => "Q2", 
			PivotFilterType.Q3 => "Q3", 
			PivotFilterType.Q4 => "Q4", 
			PivotFilterType.Sum => "sum", 
			PivotFilterType.ThisMonth => "thisMonth", 
			PivotFilterType.ThisQuarter => "thisQuarter", 
			PivotFilterType.ThisWeek => "thisWeek", 
			PivotFilterType.ThisYear => "thisYear", 
			PivotFilterType.Today => "today", 
			PivotFilterType.Tomorrow => "tomorrow", 
			PivotFilterType.ValueBetween => "valueBetween", 
			PivotFilterType.ValueEqual => "valueEqual", 
			PivotFilterType.ValueGreaterThan => "valueGreaterThan", 
			PivotFilterType.ValueGreaterThanOrEqual => "valueGreaterThanOrEqual", 
			PivotFilterType.ValueLessThan => "valueLessThan", 
			PivotFilterType.ValueLessThanOrEqual => "valueLessThanOrEqual", 
			PivotFilterType.ValueNotBetween => "valueNotBetween", 
			PivotFilterType.ValueNotEqual => "valueNotEqual", 
			PivotFilterType.YearToDate => "yearToDate", 
			PivotFilterType.Yesterday => "yesterday", 
			_ => "", 
		};
	}

	internal static bool smethod_7(PivotFilterType pivotFilterType_0)
	{
		switch (pivotFilterType_0)
		{
		default:
			return false;
		case PivotFilterType.ValueBetween:
		case PivotFilterType.ValueEqual:
		case PivotFilterType.ValueGreaterThan:
		case PivotFilterType.ValueGreaterThanOrEqual:
		case PivotFilterType.ValueLessThan:
		case PivotFilterType.ValueLessThanOrEqual:
		case PivotFilterType.ValueNotBetween:
		case PivotFilterType.ValueNotEqual:
			return true;
		}
	}

	internal static string smethod_8(ref int int_0, int int_1, byte[] byte_0)
	{
		string text = null;
		if (byte_0[int_0] == 0)
		{
			text = Encoding.ASCII.GetString(byte_0, int_0 + 1, int_1);
			int_0 += int_1 + 1;
		}
		else
		{
			text = Encoding.Unicode.GetString(byte_0, int_0 + 1, int_1 * 2);
			int_0 += int_1 * 2 + 1;
		}
		return text;
	}

	internal static string smethod_9(CellArea cellArea_0, string string_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(string_0).Append("!");
		stringBuilder.Append('$');
		stringBuilder.Append(CellsHelper.ColumnIndexToName(cellArea_0.StartColumn));
		stringBuilder.Append('$');
		stringBuilder.Append(Class1618.smethod_80(cellArea_0.StartRow + 1));
		if (cellArea_0.StartColumn != cellArea_0.EndColumn || cellArea_0.StartRow != cellArea_0.EndRow)
		{
			stringBuilder.Append(":").Append("$");
			stringBuilder.Append(CellsHelper.ColumnIndexToName(cellArea_0.EndColumn));
			stringBuilder.Append('$');
			stringBuilder.Append(Class1618.smethod_80(cellArea_0.EndRow + 1));
		}
		return stringBuilder.ToString();
	}

	internal static string smethod_10(PivotTableStyleType pivotTableStyleType_0)
	{
		return pivotTableStyleType_0 switch
		{
			PivotTableStyleType.None => "None", 
			PivotTableStyleType.PivotTableStyleLight1 => "PivotStyleLight1", 
			PivotTableStyleType.PivotTableStyleLight2 => "PivotStyleLight2", 
			PivotTableStyleType.PivotTableStyleLight3 => "PivotStyleLight3", 
			PivotTableStyleType.PivotTableStyleLight4 => "PivotStyleLight4", 
			PivotTableStyleType.PivotTableStyleLight5 => "PivotStyleLight5", 
			PivotTableStyleType.PivotTableStyleLight6 => "PivotStyleLight6", 
			PivotTableStyleType.PivotTableStyleLight7 => "PivotStyleLight7", 
			PivotTableStyleType.PivotTableStyleLight8 => "PivotStyleLight8", 
			PivotTableStyleType.PivotTableStyleLight9 => "PivotStyleLight9", 
			PivotTableStyleType.PivotTableStyleLight10 => "PivotStyleLight10", 
			PivotTableStyleType.PivotTableStyleLight11 => "PivotStyleLight11", 
			PivotTableStyleType.PivotTableStyleLight12 => "PivotStyleLight12", 
			PivotTableStyleType.PivotTableStyleLight13 => "PivotStyleLight13", 
			PivotTableStyleType.PivotTableStyleLight14 => "PivotStyleLight14", 
			PivotTableStyleType.PivotTableStyleLight15 => "PivotStyleLight15", 
			PivotTableStyleType.PivotTableStyleLight16 => "PivotStyleLight16", 
			PivotTableStyleType.PivotTableStyleLight17 => "PivotStyleLight17", 
			PivotTableStyleType.PivotTableStyleLight18 => "PivotStyleLight18", 
			PivotTableStyleType.PivotTableStyleLight19 => "PivotStyleLight19", 
			PivotTableStyleType.PivotTableStyleLight20 => "PivotStyleLight20", 
			PivotTableStyleType.PivotTableStyleLight21 => "PivotStyleLight21", 
			PivotTableStyleType.PivotTableStyleLight22 => "PivotStyleLight22", 
			PivotTableStyleType.PivotTableStyleLight23 => "PivotStyleLight23", 
			PivotTableStyleType.PivotTableStyleLight24 => "PivotStyleLight24", 
			PivotTableStyleType.PivotTableStyleLight25 => "PivotStyleLight25", 
			PivotTableStyleType.PivotTableStyleLight26 => "PivotStyleLight26", 
			PivotTableStyleType.PivotTableStyleLight27 => "PivotStyleLight27", 
			PivotTableStyleType.PivotTableStyleLight28 => "PivotStyleLight28", 
			PivotTableStyleType.PivotTableStyleMedium1 => "PivotStyleMedium1", 
			PivotTableStyleType.PivotTableStyleMedium2 => "PivotStyleMedium2", 
			PivotTableStyleType.PivotTableStyleMedium3 => "PivotStyleMedium3", 
			PivotTableStyleType.PivotTableStyleMedium4 => "PivotStyleMedium4", 
			PivotTableStyleType.PivotTableStyleMedium5 => "PivotStyleMedium5", 
			PivotTableStyleType.PivotTableStyleMedium6 => "PivotStyleMedium6", 
			PivotTableStyleType.PivotTableStyleMedium7 => "PivotStyleMedium7", 
			PivotTableStyleType.PivotTableStyleMedium8 => "PivotStyleMedium8", 
			PivotTableStyleType.PivotTableStyleMedium9 => "PivotStyleMedium9", 
			PivotTableStyleType.PivotTableStyleMedium10 => "PivotStyleMedium10", 
			PivotTableStyleType.PivotTableStyleMedium11 => "PivotStyleMedium11", 
			PivotTableStyleType.PivotTableStyleMedium12 => "PivotStyleMedium12", 
			PivotTableStyleType.PivotTableStyleMedium13 => "PivotStyleMedium13", 
			PivotTableStyleType.PivotTableStyleMedium14 => "PivotStyleMedium14", 
			PivotTableStyleType.PivotTableStyleMedium15 => "PivotStyleMedium15", 
			PivotTableStyleType.PivotTableStyleMedium16 => "PivotStyleMedium16", 
			PivotTableStyleType.PivotTableStyleMedium17 => "PivotStyleMedium17", 
			PivotTableStyleType.PivotTableStyleMedium18 => "PivotStyleMedium18", 
			PivotTableStyleType.PivotTableStyleMedium19 => "PivotStyleMedium19", 
			PivotTableStyleType.PivotTableStyleMedium20 => "PivotStyleMedium20", 
			PivotTableStyleType.PivotTableStyleMedium21 => "PivotStyleMedium21", 
			PivotTableStyleType.PivotTableStyleMedium22 => "PivotStyleMedium22", 
			PivotTableStyleType.PivotTableStyleMedium23 => "PivotStyleMedium23", 
			PivotTableStyleType.PivotTableStyleMedium24 => "PivotStyleMedium24", 
			PivotTableStyleType.PivotTableStyleMedium25 => "PivotStyleMedium25", 
			PivotTableStyleType.PivotTableStyleMedium26 => "PivotStyleMedium26", 
			PivotTableStyleType.PivotTableStyleMedium27 => "PivotStyleMedium27", 
			PivotTableStyleType.PivotTableStyleMedium28 => "PivotStyleMedium28", 
			PivotTableStyleType.PivotTableStyleDark1 => "PivotStyleDark1", 
			PivotTableStyleType.PivotTableStyleDark2 => "PivotStyleDark2", 
			PivotTableStyleType.PivotTableStyleDark3 => "PivotStyleDark3", 
			PivotTableStyleType.PivotTableStyleDark4 => "PivotStyleDark4", 
			PivotTableStyleType.PivotTableStyleDark5 => "PivotStyleDark5", 
			PivotTableStyleType.PivotTableStyleDark6 => "PivotStyleDark6", 
			PivotTableStyleType.PivotTableStyleDark7 => "PivotStyleDark7", 
			PivotTableStyleType.PivotTableStyleDark8 => "PivotStyleDark8", 
			PivotTableStyleType.PivotTableStyleDark9 => "PivotStyleDark9", 
			PivotTableStyleType.PivotTableStyleDark10 => "PivotStyleDark10", 
			PivotTableStyleType.PivotTableStyleDark11 => "PivotStyleDark11", 
			PivotTableStyleType.PivotTableStyleDark12 => "PivotStyleDark12", 
			PivotTableStyleType.PivotTableStyleDark13 => "PivotStyleDark13", 
			PivotTableStyleType.PivotTableStyleDark14 => "PivotStyleDark14", 
			PivotTableStyleType.PivotTableStyleDark15 => "PivotStyleDark15", 
			PivotTableStyleType.PivotTableStyleDark16 => "PivotStyleDark16", 
			PivotTableStyleType.PivotTableStyleDark17 => "PivotStyleDark17", 
			PivotTableStyleType.PivotTableStyleDark18 => "PivotStyleDark18", 
			PivotTableStyleType.PivotTableStyleDark19 => "PivotStyleDark19", 
			PivotTableStyleType.PivotTableStyleDark20 => "PivotStyleDark20", 
			PivotTableStyleType.PivotTableStyleDark21 => "PivotStyleDark21", 
			PivotTableStyleType.PivotTableStyleDark22 => "PivotStyleDark22", 
			PivotTableStyleType.PivotTableStyleDark23 => "PivotStyleDark23", 
			PivotTableStyleType.PivotTableStyleDark24 => "PivotStyleDark24", 
			PivotTableStyleType.PivotTableStyleDark25 => "PivotStyleDark25", 
			PivotTableStyleType.PivotTableStyleDark26 => "PivotStyleDark26", 
			PivotTableStyleType.PivotTableStyleDark27 => "PivotStyleDark27", 
			PivotTableStyleType.PivotTableStyleDark28 => "PivotStyleDark28", 
			PivotTableStyleType.Custom => "Custom", 
			_ => "Custom", 
		};
	}

	internal static PivotTableStyleType smethod_11(string string_0)
	{
		string key;
		if ((key = string_0) != null)
		{
			if (Class1742.dictionary_53 == null)
			{
				Class1742.dictionary_53 = new Dictionary<string, int>(86)
				{
					{ "None", 0 },
					{ "PivotStyleLight1", 1 },
					{ "PivotStyleLight2", 2 },
					{ "PivotStyleLight3", 3 },
					{ "PivotStyleLight4", 4 },
					{ "PivotStyleLight5", 5 },
					{ "PivotStyleLight6", 6 },
					{ "PivotStyleLight7", 7 },
					{ "PivotStyleLight8", 8 },
					{ "PivotStyleLight9", 9 },
					{ "PivotStyleLight10", 10 },
					{ "PivotStyleLight11", 11 },
					{ "PivotStyleLight12", 12 },
					{ "PivotStyleLight13", 13 },
					{ "PivotStyleLight14", 14 },
					{ "PivotStyleLight15", 15 },
					{ "PivotStyleLight16", 16 },
					{ "PivotStyleLight17", 17 },
					{ "PivotStyleLight18", 18 },
					{ "PivotStyleLight19", 19 },
					{ "PivotStyleLight20", 20 },
					{ "PivotStyleLight21", 21 },
					{ "PivotStyleLight22", 22 },
					{ "PivotStyleLight23", 23 },
					{ "PivotStyleLight24", 24 },
					{ "PivotStyleLight25", 25 },
					{ "PivotStyleLight26", 26 },
					{ "PivotStyleLight27", 27 },
					{ "PivotStyleLight28", 28 },
					{ "PivotStyleMedium1", 29 },
					{ "PivotStyleMedium2", 30 },
					{ "PivotStyleMedium3", 31 },
					{ "PivotStyleMedium4", 32 },
					{ "PivotStyleMedium5", 33 },
					{ "PivotStyleMedium6", 34 },
					{ "PivotStyleMedium7", 35 },
					{ "PivotStyleMedium8", 36 },
					{ "PivotStyleMedium9", 37 },
					{ "PivotStyleMedium10", 38 },
					{ "PivotStyleMedium11", 39 },
					{ "PivotStyleMedium12", 40 },
					{ "PivotStyleMedium13", 41 },
					{ "PivotStyleMedium14", 42 },
					{ "PivotStyleMedium15", 43 },
					{ "PivotStyleMedium16", 44 },
					{ "PivotStyleMedium17", 45 },
					{ "PivotStyleMedium18", 46 },
					{ "PivotStyleMedium19", 47 },
					{ "PivotStyleMedium20", 48 },
					{ "PivotStyleMedium21", 49 },
					{ "PivotStyleMedium22", 50 },
					{ "PivotStyleMedium23", 51 },
					{ "PivotStyleMedium24", 52 },
					{ "PivotStyleMedium25", 53 },
					{ "PivotStyleMedium26", 54 },
					{ "PivotStyleMedium27", 55 },
					{ "PivotStyleMedium28", 56 },
					{ "PivotStyleDark1", 57 },
					{ "PivotStyleDark2", 58 },
					{ "PivotStyleDark3", 59 },
					{ "PivotStyleDark4", 60 },
					{ "PivotStyleDark5", 61 },
					{ "PivotStyleDark6", 62 },
					{ "PivotStyleDark7", 63 },
					{ "PivotStyleDark8", 64 },
					{ "PivotStyleDark9", 65 },
					{ "PivotStyleDark10", 66 },
					{ "PivotStyleDark11", 67 },
					{ "PivotStyleDark12", 68 },
					{ "PivotStyleDark13", 69 },
					{ "PivotStyleDark14", 70 },
					{ "PivotStyleDark15", 71 },
					{ "PivotStyleDark16", 72 },
					{ "PivotStyleDark17", 73 },
					{ "PivotStyleDark18", 74 },
					{ "PivotStyleDark19", 75 },
					{ "PivotStyleDark20", 76 },
					{ "PivotStyleDark21", 77 },
					{ "PivotStyleDark22", 78 },
					{ "PivotStyleDark23", 79 },
					{ "PivotStyleDark24", 80 },
					{ "PivotStyleDark25", 81 },
					{ "PivotStyleDark26", 82 },
					{ "PivotStyleDark27", 83 },
					{ "PivotStyleDark28", 84 },
					{ "Custom", 85 }
				};
			}
			if (Class1742.dictionary_53.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return PivotTableStyleType.None;
				case 1:
					return PivotTableStyleType.PivotTableStyleLight1;
				case 2:
					return PivotTableStyleType.PivotTableStyleLight2;
				case 3:
					return PivotTableStyleType.PivotTableStyleLight3;
				case 4:
					return PivotTableStyleType.PivotTableStyleLight4;
				case 5:
					return PivotTableStyleType.PivotTableStyleLight5;
				case 6:
					return PivotTableStyleType.PivotTableStyleLight6;
				case 7:
					return PivotTableStyleType.PivotTableStyleLight7;
				case 8:
					return PivotTableStyleType.PivotTableStyleLight8;
				case 9:
					return PivotTableStyleType.PivotTableStyleLight9;
				case 10:
					return PivotTableStyleType.PivotTableStyleLight10;
				case 11:
					return PivotTableStyleType.PivotTableStyleLight11;
				case 12:
					return PivotTableStyleType.PivotTableStyleLight12;
				case 13:
					return PivotTableStyleType.PivotTableStyleLight13;
				case 14:
					return PivotTableStyleType.PivotTableStyleLight14;
				case 15:
					return PivotTableStyleType.PivotTableStyleLight15;
				case 16:
					return PivotTableStyleType.PivotTableStyleLight16;
				case 17:
					return PivotTableStyleType.PivotTableStyleLight17;
				case 18:
					return PivotTableStyleType.PivotTableStyleLight18;
				case 19:
					return PivotTableStyleType.PivotTableStyleLight19;
				case 20:
					return PivotTableStyleType.PivotTableStyleLight20;
				case 21:
					return PivotTableStyleType.PivotTableStyleLight21;
				case 22:
					return PivotTableStyleType.PivotTableStyleLight22;
				case 23:
					return PivotTableStyleType.PivotTableStyleLight23;
				case 24:
					return PivotTableStyleType.PivotTableStyleLight24;
				case 25:
					return PivotTableStyleType.PivotTableStyleLight25;
				case 26:
					return PivotTableStyleType.PivotTableStyleLight26;
				case 27:
					return PivotTableStyleType.PivotTableStyleLight27;
				case 28:
					return PivotTableStyleType.PivotTableStyleLight28;
				case 29:
					return PivotTableStyleType.PivotTableStyleMedium1;
				case 30:
					return PivotTableStyleType.PivotTableStyleMedium2;
				case 31:
					return PivotTableStyleType.PivotTableStyleMedium3;
				case 32:
					return PivotTableStyleType.PivotTableStyleMedium4;
				case 33:
					return PivotTableStyleType.PivotTableStyleMedium5;
				case 34:
					return PivotTableStyleType.PivotTableStyleMedium6;
				case 35:
					return PivotTableStyleType.PivotTableStyleMedium7;
				case 36:
					return PivotTableStyleType.PivotTableStyleMedium8;
				case 37:
					return PivotTableStyleType.PivotTableStyleMedium9;
				case 38:
					return PivotTableStyleType.PivotTableStyleMedium10;
				case 39:
					return PivotTableStyleType.PivotTableStyleMedium11;
				case 40:
					return PivotTableStyleType.PivotTableStyleMedium12;
				case 41:
					return PivotTableStyleType.PivotTableStyleMedium13;
				case 42:
					return PivotTableStyleType.PivotTableStyleMedium14;
				case 43:
					return PivotTableStyleType.PivotTableStyleMedium15;
				case 44:
					return PivotTableStyleType.PivotTableStyleMedium16;
				case 45:
					return PivotTableStyleType.PivotTableStyleMedium17;
				case 46:
					return PivotTableStyleType.PivotTableStyleMedium18;
				case 47:
					return PivotTableStyleType.PivotTableStyleMedium19;
				case 48:
					return PivotTableStyleType.PivotTableStyleMedium20;
				case 49:
					return PivotTableStyleType.PivotTableStyleMedium21;
				case 50:
					return PivotTableStyleType.PivotTableStyleMedium22;
				case 51:
					return PivotTableStyleType.PivotTableStyleMedium23;
				case 52:
					return PivotTableStyleType.PivotTableStyleMedium24;
				case 53:
					return PivotTableStyleType.PivotTableStyleMedium25;
				case 54:
					return PivotTableStyleType.PivotTableStyleMedium26;
				case 55:
					return PivotTableStyleType.PivotTableStyleMedium27;
				case 56:
					return PivotTableStyleType.PivotTableStyleMedium28;
				case 57:
					return PivotTableStyleType.PivotTableStyleDark1;
				case 58:
					return PivotTableStyleType.PivotTableStyleDark2;
				case 59:
					return PivotTableStyleType.PivotTableStyleDark3;
				case 60:
					return PivotTableStyleType.PivotTableStyleDark4;
				case 61:
					return PivotTableStyleType.PivotTableStyleDark5;
				case 62:
					return PivotTableStyleType.PivotTableStyleDark6;
				case 63:
					return PivotTableStyleType.PivotTableStyleDark7;
				case 64:
					return PivotTableStyleType.PivotTableStyleDark8;
				case 65:
					return PivotTableStyleType.PivotTableStyleDark9;
				case 66:
					return PivotTableStyleType.PivotTableStyleDark10;
				case 67:
					return PivotTableStyleType.PivotTableStyleDark11;
				case 68:
					return PivotTableStyleType.PivotTableStyleDark12;
				case 69:
					return PivotTableStyleType.PivotTableStyleDark13;
				case 70:
					return PivotTableStyleType.PivotTableStyleDark14;
				case 71:
					return PivotTableStyleType.PivotTableStyleDark15;
				case 72:
					return PivotTableStyleType.PivotTableStyleDark16;
				case 73:
					return PivotTableStyleType.PivotTableStyleDark17;
				case 74:
					return PivotTableStyleType.PivotTableStyleDark18;
				case 75:
					return PivotTableStyleType.PivotTableStyleDark19;
				case 76:
					return PivotTableStyleType.PivotTableStyleDark20;
				case 77:
					return PivotTableStyleType.PivotTableStyleDark21;
				case 78:
					return PivotTableStyleType.PivotTableStyleDark22;
				case 79:
					return PivotTableStyleType.PivotTableStyleDark23;
				case 80:
					return PivotTableStyleType.PivotTableStyleDark24;
				case 81:
					return PivotTableStyleType.PivotTableStyleDark25;
				case 82:
					return PivotTableStyleType.PivotTableStyleDark26;
				case 83:
					return PivotTableStyleType.PivotTableStyleDark27;
				case 84:
					return PivotTableStyleType.PivotTableStyleDark28;
				case 85:
					return PivotTableStyleType.Custom;
				}
			}
		}
		return PivotTableStyleType.Custom;
	}
}
