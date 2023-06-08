using System;
using System.Text;
using Aspose.Cells;
using ns16;
using ns2;

namespace ns27;

internal class Class579 : Class538
{
	private FormatCondition formatCondition_0;

	internal Class579()
	{
		method_2(2170);
	}

	internal void method_4(Class995 class995_0)
	{
		formatCondition_0 = class995_0.formatCondition_0;
		int num = 18;
		byte[] array = null;
		byte[] array2 = null;
		byte b;
		switch (formatCondition_0.Type)
		{
		case FormatConditionType.CellValue:
			b = 1;
			formatCondition_0.method_11();
			array = formatCondition_0.method_0();
			array2 = formatCondition_0.method_4();
			break;
		default:
			b = 2;
			if (class995_0.byte_0 != null)
			{
				array = class995_0.byte_0;
				break;
			}
			formatCondition_0.method_11();
			array = formatCondition_0.method_0();
			break;
		case FormatConditionType.ColorScale:
			b = 3;
			num += method_7(formatCondition_0.ColorScale);
			break;
		case FormatConditionType.DataBar:
			b = 4;
			num += method_5(formatCondition_0.DataBar);
			break;
		case FormatConditionType.IconSet:
			b = 6;
			num += method_9(formatCondition_0.IconSet);
			break;
		case FormatConditionType.Top10:
			b = 5;
			num += 6;
			break;
		}
		if (array != null)
		{
			num += array.Length - 2;
			if (array2 != null)
			{
				num += array2.Length - 2;
			}
		}
		num += class995_0.method_2();
		num += 24;
		method_0((short)num);
		byte_0 = new byte[num];
		byte_0[0] = 122;
		byte_0[1] = 8;
		int num2 = 12;
		byte_0[12] = b;
		byte_0[12 + 1] = Class580.smethod_0((b != 1) ? OperatorType.None : formatCondition_0.Operator);
		num2 += 2;
		if (array != null)
		{
			Array.Copy(BitConverter.GetBytes((short)(array.Length - 2)), 0, byte_0, num2, 2);
			if (array2 != null)
			{
				Array.Copy(BitConverter.GetBytes((short)(array2.Length - 2)), 0, byte_0, num2 + 2, 2);
			}
		}
		num2 += 4;
		num2 = smethod_0(class995_0.class578_0, class995_0.class1685_0, byte_0, num2);
		if (array != null)
		{
			Array.Copy(array, 2, byte_0, num2, array.Length - 2);
			num2 += array.Length - 2;
			if (array2 != null)
			{
				Array.Copy(array2, 2, byte_0, num2, array2.Length - 2);
				num2 += array2.Length - 2;
			}
		}
		num2 += 2;
		if (formatCondition_0.StopIfTrue)
		{
			byte_0[num2] = 2;
		}
		num2++;
		Array.Copy(BitConverter.GetBytes((ushort)formatCondition_0.Priority), 0, byte_0, num2, 2);
		num2 += 2;
		Array.Copy(BitConverter.GetBytes((ushort)smethod_1(formatCondition_0)), 0, byte_0, num2, 2);
		num2 += 2;
		num2 = smethod_2(formatCondition_0, byte_0, num2);
		switch (formatCondition_0.Type)
		{
		case FormatConditionType.ColorScale:
			num2 = method_8(formatCondition_0.ColorScale, byte_0, num2);
			break;
		case FormatConditionType.DataBar:
			num2 = method_6(formatCondition_0.DataBar, byte_0, num2);
			break;
		case FormatConditionType.IconSet:
			num2 = method_10(formatCondition_0.IconSet, byte_0, num2);
			break;
		case FormatConditionType.Top10:
			num2 = smethod_3(formatCondition_0.Top10, byte_0, num2);
			break;
		}
	}

	internal static int smethod_0(Class578 class578_0, Class1685 class1685_0, byte[] byte_1, int int_0)
	{
		int_0 += 4;
		int num = int_0;
		if (class578_0 != null)
		{
			Array.Copy(class578_0.Data, 0, byte_1, int_0, class578_0.Length);
			int_0 += class578_0.Length;
		}
		if (class1685_0 != null)
		{
			byte_1[int_0 + 2] = byte.MaxValue;
			byte_1[int_0 + 3] = byte.MaxValue;
			int_0 += 6;
			Array.Copy(BitConverter.GetBytes((ushort)class1685_0.Count), 0, byte_1, int_0, 2);
			int_0 += 2;
			int_0 = Class588.Write(class1685_0, byte_1, int_0);
		}
		if (int_0 > num)
		{
			Array.Copy(BitConverter.GetBytes(int_0 - num), 0, byte_1, num - 4, 4);
		}
		else
		{
			int_0 += 2;
		}
		return int_0;
	}

	internal static int smethod_1(FormatCondition formatCondition_1)
	{
		switch (formatCondition_1.Type)
		{
		case FormatConditionType.CellValue:
			return 0;
		case FormatConditionType.Expression:
			return 1;
		case FormatConditionType.ColorScale:
			return 2;
		case FormatConditionType.DataBar:
			return 3;
		case FormatConditionType.IconSet:
			return 4;
		case FormatConditionType.Top10:
			return 5;
		case FormatConditionType.UniqueValues:
			return 7;
		case FormatConditionType.DuplicateValues:
			return 27;
		case FormatConditionType.ContainsText:
		case FormatConditionType.NotContainsText:
		case FormatConditionType.BeginsWith:
		case FormatConditionType.EndsWith:
			return 8;
		case FormatConditionType.ContainsBlanks:
			return 9;
		case FormatConditionType.NotContainsBlanks:
			return 10;
		case FormatConditionType.ContainsErrors:
			return 11;
		case FormatConditionType.NotContainsErrors:
			return 12;
		case FormatConditionType.TimePeriod:
			switch (formatCondition_1.TimePeriod)
			{
			case TimePeriodType.Today:
				return 15;
			case TimePeriodType.Yesterday:
				return 17;
			case TimePeriodType.Tomorrow:
				return 16;
			case TimePeriodType.Last7Days:
				return 18;
			case TimePeriodType.ThisMonth:
				return 24;
			case TimePeriodType.LastMonth:
				return 19;
			case TimePeriodType.NextMonth:
				return 20;
			case TimePeriodType.ThisWeek:
				return 21;
			case TimePeriodType.LastWeek:
				return 23;
			case TimePeriodType.NextWeek:
				return 22;
			}
			goto default;
		default:
			return 1;
		case FormatConditionType.AboveAverage:
		{
			AboveAverage aboveAverage = formatCondition_1.AboveAverage;
			if (aboveAverage.IsAboveAverage)
			{
				if (aboveAverage.IsEqualAverage)
				{
					return 29;
				}
				return 25;
			}
			if (aboveAverage.IsEqualAverage)
			{
				return 30;
			}
			return 26;
		}
		}
	}

	internal static int smethod_2(FormatCondition formatCondition_1, byte[] byte_1, int int_0)
	{
		byte_1[int_0] = 16;
		int_0++;
		switch (formatCondition_1.Type)
		{
		case FormatConditionType.Top10:
		{
			Top10 top = formatCondition_1.Top10;
			byte b = 0;
			if (!top.IsBottom)
			{
				b = (byte)(b | 1u);
			}
			if (top.IsPercent)
			{
				b = (byte)(b | 2u);
			}
			byte_1[int_0] = b;
			Array.Copy(BitConverter.GetBytes((short)top.Rank), 0, byte_1, int_0 + 1, 2);
			break;
		}
		case FormatConditionType.ContainsText:
			byte_1[int_0] = 0;
			break;
		case FormatConditionType.NotContainsText:
			byte_1[int_0] = 1;
			break;
		case FormatConditionType.BeginsWith:
			byte_1[int_0] = 2;
			break;
		case FormatConditionType.EndsWith:
			byte_1[int_0] = 3;
			break;
		case FormatConditionType.TimePeriod:
		{
			short value = 0;
			switch (formatCondition_1.TimePeriod)
			{
			case TimePeriodType.Today:
				value = 0;
				break;
			case TimePeriodType.Yesterday:
				value = 1;
				break;
			case TimePeriodType.Tomorrow:
				value = 6;
				break;
			case TimePeriodType.Last7Days:
				value = 2;
				break;
			case TimePeriodType.ThisMonth:
				value = 9;
				break;
			case TimePeriodType.LastMonth:
				value = 5;
				break;
			case TimePeriodType.NextMonth:
				value = 8;
				break;
			case TimePeriodType.ThisWeek:
				value = 3;
				break;
			case TimePeriodType.LastWeek:
				value = 4;
				break;
			case TimePeriodType.NextWeek:
				value = 7;
				break;
			}
			Array.Copy(BitConverter.GetBytes(value), 0, byte_1, int_0, 2);
			break;
		}
		case FormatConditionType.AboveAverage:
		{
			AboveAverage aboveAverage = formatCondition_1.AboveAverage;
			Array.Copy(BitConverter.GetBytes((short)aboveAverage.StdDev), 0, byte_1, int_0, 2);
			break;
		}
		}
		return int_0 + 16;
	}

	private int method_5(DataBar dataBar_0)
	{
		int num = 22;
		num = 22 + method_11(dataBar_0.conditionalFormattingValue_0);
		return num + method_11(dataBar_0.conditionalFormattingValue_1);
	}

	private int method_6(DataBar dataBar_0, byte[] byte_1, int int_0)
	{
		int_0 += 3;
		if (!dataBar_0.ShowValue)
		{
			byte_1[int_0] |= 2;
		}
		int_0++;
		byte_1[int_0] = 10;
		byte_1[int_0 + 1] = 90;
		int_0 += 2;
		int_0 = smethod_6(dataBar_0.method_4(), byte_1, int_0);
		int_0 = smethod_4(dataBar_0.MinCfvo, byte_1, int_0);
		int_0 = smethod_4(dataBar_0.MaxCfvo, byte_1, int_0);
		return int_0;
	}

	private int method_7(ColorScale colorScale_0)
	{
		int num = 6;
		num = 6 + (method_11(colorScale_0.conditionalFormattingValue_0) + 32);
		if (colorScale_0.method_0())
		{
			num += method_11(colorScale_0.conditionalFormattingValue_1) + 32;
		}
		return num + (method_11(colorScale_0.conditionalFormattingValue_2) + 32);
	}

	private int method_8(ColorScale colorScale_0, byte[] byte_1, int int_0)
	{
		int_0 += 3;
		bool flag = colorScale_0.method_0();
		byte_1[int_0] = (byte)(flag ? 3u : 2u);
		byte_1[int_0 + 1] = byte_1[int_0];
		int_0 += 2;
		byte_1[int_0] = 3;
		int_0++;
		int_0 = smethod_4(colorScale_0.MinCfvo, byte_1, int_0);
		int_0 += 8;
		if (flag)
		{
			int_0 = smethod_4(colorScale_0.MidCfvo, byte_1, int_0);
			Array.Copy(BitConverter.GetBytes(0.5), 0, byte_1, int_0, 8);
			int_0 += 8;
		}
		int_0 = smethod_4(colorScale_0.MaxCfvo, byte_1, int_0);
		Array.Copy(BitConverter.GetBytes(1.0), 0, byte_1, int_0, 8);
		int_0 += 8;
		int_0 += 8;
		int_0 = smethod_6(colorScale_0.internalColor_0, byte_1, int_0);
		if (flag)
		{
			Array.Copy(BitConverter.GetBytes(0.5), 0, byte_1, int_0, 8);
			int_0 += 8;
			int_0 = smethod_6(colorScale_0.internalColor_1, byte_1, int_0);
		}
		Array.Copy(BitConverter.GetBytes(1.0), 0, byte_1, int_0, 8);
		int_0 += 8;
		int_0 = smethod_6(colorScale_0.internalColor_2, byte_1, int_0);
		return int_0;
	}

	private int method_9(IconSet iconSet_0)
	{
		int num = 6;
		if (iconSet_0.Cfvos.Count > 0)
		{
			foreach (ConditionalFormattingValue cfvo in iconSet_0.Cfvos)
			{
				num += method_11(cfvo) + 5;
			}
		}
		return num;
	}

	private int method_10(IconSet iconSet_0, byte[] byte_1, int int_0)
	{
		int_0 += 3;
		byte_1[int_0] = (byte)iconSet_0.Cfvos.Count;
		int_0++;
		byte_1[int_0] = (byte)Class1673.smethod_14(iconSet_0.Type);
		int_0++;
		if (!iconSet_0.ShowValue)
		{
			byte_1[int_0] |= 1;
		}
		if (iconSet_0.Reverse)
		{
			byte_1[int_0] |= 4;
		}
		int_0++;
		int num = Class1618.smethod_144(iconSet_0.Type);
		if (iconSet_0.Cfvos.Count < num)
		{
			throw new CellsException(ExceptionType.ConditionalFormatting, method_12(null).Append("Need more CFVO for IconSet").ToString());
		}
		for (int i = 0; i < num; i++)
		{
			ConditionalFormattingValue conditionalFormattingValue = iconSet_0.Cfvos[i];
			int_0 = smethod_4(conditionalFormattingValue, byte_1, int_0);
			if (conditionalFormattingValue.IsGTE)
			{
				byte_1[int_0] = 1;
			}
			int_0 += 5;
		}
		return int_0;
	}

	private static int smethod_3(Top10 top10_0, byte[] byte_1, int int_0)
	{
		byte_1[int_0] = 4;
		int_0 += 3;
		if (!top10_0.IsBottom)
		{
			byte_1[int_0] |= 1;
		}
		if (top10_0.IsPercent)
		{
			byte_1[int_0] |= 2;
		}
		int_0++;
		Array.Copy(BitConverter.GetBytes((short)top10_0.Rank), 0, byte_1, int_0, 2);
		int_0 += 2;
		return int_0;
	}

	private int method_11(ConditionalFormattingValue conditionalFormattingValue_0)
	{
		switch (conditionalFormattingValue_0.Type)
		{
		default:
			return 0;
		case FormatConditionValueType.Max:
		case FormatConditionValueType.Min:
			return 3;
		case FormatConditionValueType.Formula:
		case FormatConditionValueType.Number:
		case FormatConditionValueType.Percent:
		case FormatConditionValueType.Percentile:
			if (conditionalFormattingValue_0.IsFormula)
			{
				if (conditionalFormattingValue_0.method_6() == null)
				{
					throw new CellsException(ExceptionType.ConditionalFormatting, method_12(null).Append("Invalid formula for CFVO").ToString());
				}
				if (conditionalFormattingValue_0.method_6().Length > 2)
				{
					return 1 + conditionalFormattingValue_0.method_6().Length;
				}
			}
			return 11;
		}
	}

	private static int smethod_4(ConditionalFormattingValue conditionalFormattingValue_0, byte[] byte_1, int int_0)
	{
		switch (conditionalFormattingValue_0.Type)
		{
		case FormatConditionValueType.Formula:
			byte_1[int_0] = 7;
			int_0++;
			int_0 = smethod_5(conditionalFormattingValue_0, byte_1, int_0);
			break;
		case FormatConditionValueType.Max:
			byte_1[int_0] = 3;
			int_0 += 3;
			break;
		case FormatConditionValueType.Min:
			byte_1[int_0] = 2;
			int_0 += 3;
			break;
		case FormatConditionValueType.Number:
			byte_1[int_0] = 1;
			int_0++;
			int_0 = smethod_5(conditionalFormattingValue_0, byte_1, int_0);
			break;
		case FormatConditionValueType.Percent:
			byte_1[int_0] = 4;
			int_0++;
			int_0 = smethod_5(conditionalFormattingValue_0, byte_1, int_0);
			break;
		case FormatConditionValueType.Percentile:
			byte_1[int_0] = 5;
			int_0++;
			int_0 = smethod_5(conditionalFormattingValue_0, byte_1, int_0);
			break;
		}
		return int_0;
	}

	private static int smethod_5(ConditionalFormattingValue conditionalFormattingValue_0, byte[] byte_1, int int_0)
	{
		if (conditionalFormattingValue_0.IsFormula && conditionalFormattingValue_0.method_6() != null && conditionalFormattingValue_0.method_6().Length > 2)
		{
			Array.Copy(conditionalFormattingValue_0.method_6(), 0, byte_1, int_0, conditionalFormattingValue_0.method_6().Length);
			return int_0 + conditionalFormattingValue_0.method_6().Length;
		}
		int_0 += 2;
		Array.Copy(BitConverter.GetBytes(conditionalFormattingValue_0.method_5()), 0, byte_1, int_0, 8);
		int_0 += 8;
		return int_0;
	}

	internal static int smethod_6(InternalColor internalColor_0, byte[] byte_1, int int_0)
	{
		switch (internalColor_0.ColorType)
		{
		case ColorType.Automatic:
		case ColorType.AutomaticIndex:
			return int_0 + 16;
		default:
		{
			byte_1[int_0] = 2;
			int_0 += 4;
			int num = internalColor_0.method_4();
			byte_1[int_0] = (byte)((num & 0xFF0000) >> 16);
			byte_1[int_0 + 1] = (byte)((num & 0xFF00) >> 8);
			byte_1[int_0 + 2] = (byte)((uint)num & 0xFFu);
			break;
		}
		case ColorType.IndexedColor:
			byte_1[int_0] = 1;
			int_0 += 4;
			Array.Copy(BitConverter.GetBytes(internalColor_0.method_4()), 0, byte_1, int_0, 4);
			break;
		case ColorType.Theme:
			byte_1[int_0] = 3;
			int_0 += 4;
			Array.Copy(BitConverter.GetBytes(internalColor_0.method_4()), 0, byte_1, int_0, 4);
			break;
		}
		int_0 += 4;
		Array.Copy(BitConverter.GetBytes(internalColor_0.Tint), 0, byte_1, int_0, 8);
		int_0 += 8;
		return int_0;
	}

	private StringBuilder method_12(StringBuilder stringBuilder_0)
	{
		CellArea cellArea = (CellArea)formatCondition_0.formatConditionCollection_0.arrayList_1[0];
		if (stringBuilder_0 == null)
		{
			stringBuilder_0 = new StringBuilder();
		}
		stringBuilder_0.Append("FormatCondition at [").Append(formatCondition_0.formatConditionCollection_0.conditionalFormattingCollection_0.worksheet_0.Name).Append("!");
		stringBuilder_0.Append(CellsHelper.CellIndexToName(cellArea.StartRow, cellArea.StartColumn));
		stringBuilder_0.Append(":");
		stringBuilder_0.Append(CellsHelper.CellIndexToName(cellArea.EndRow, cellArea.EndColumn));
		stringBuilder_0.Append("]:");
		return stringBuilder_0;
	}
}
