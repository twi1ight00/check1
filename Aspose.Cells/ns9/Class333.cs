using System;
using Aspose.Cells;
using ns10;

namespace ns9;

internal class Class333 : Class316
{
	internal Class333()
	{
		int_0 = 463;
	}

	internal void method_6(FormatCondition formatCondition_0)
	{
		int num = 42;
		byte[] array = null;
		byte[] array2 = null;
		FormatConditionType type = formatCondition_0.Type;
		array = formatCondition_0.method_0();
		array2 = formatCondition_0.method_4();
		byte[] array3 = null;
		string text = formatCondition_0.Text;
		if (array != null)
		{
			num += array.Length;
		}
		if (array2 != null)
		{
			num += array2.Length;
		}
		if (array3 != null)
		{
			num += array3.Length;
		}
		num = ((text == null) ? (num + 4) : (num + (4 + text.Length * 2)));
		byte_0 = new byte[num];
		switch (type)
		{
		case FormatConditionType.CellValue:
			byte_0[0] = 1;
			byte_0[4] = 0;
			byte_0[16] = (byte)Class1224.smethod_1(formatCondition_0.Operator);
			break;
		case FormatConditionType.Expression:
			byte_0[0] = 2;
			byte_0[4] = 0;
			break;
		case FormatConditionType.ColorScale:
			byte_0[0] = 3;
			byte_0[4] = 2;
			break;
		case FormatConditionType.DataBar:
			byte_0[0] = 4;
			byte_0[4] = 3;
			break;
		case FormatConditionType.IconSet:
			byte_0[0] = 6;
			byte_0[4] = 4;
			break;
		case FormatConditionType.Top10:
			byte_0[0] = 5;
			byte_0[4] = 5;
			byte_0[16] = (byte)formatCondition_0.Top10.Rank;
			break;
		case FormatConditionType.UniqueValues:
			byte_0[0] = 2;
			byte_0[4] = 7;
			break;
		case FormatConditionType.DuplicateValues:
			byte_0[0] = 2;
			byte_0[4] = 27;
			break;
		case FormatConditionType.ContainsText:
			byte_0[0] = 2;
			byte_0[4] = 8;
			byte_0[16] = 0;
			break;
		case FormatConditionType.NotContainsText:
			byte_0[0] = 2;
			byte_0[4] = 8;
			byte_0[16] = 1;
			break;
		case FormatConditionType.BeginsWith:
			byte_0[0] = 2;
			byte_0[4] = 8;
			byte_0[16] = 2;
			break;
		case FormatConditionType.EndsWith:
			byte_0[0] = 2;
			byte_0[4] = 8;
			byte_0[16] = 3;
			break;
		case FormatConditionType.ContainsBlanks:
			byte_0[0] = 2;
			byte_0[4] = 9;
			break;
		case FormatConditionType.NotContainsBlanks:
			byte_0[0] = 2;
			byte_0[4] = 10;
			break;
		case FormatConditionType.ContainsErrors:
			byte_0[0] = 2;
			byte_0[4] = 11;
			break;
		case FormatConditionType.NotContainsErrors:
			byte_0[0] = 2;
			byte_0[4] = 12;
			break;
		case FormatConditionType.TimePeriod:
			switch (formatCondition_0.TimePeriod)
			{
			default:
				byte_0[0] = 2;
				byte_0[4] = 15;
				break;
			case TimePeriodType.Today:
				byte_0[0] = 2;
				byte_0[4] = 15;
				break;
			case TimePeriodType.Yesterday:
				byte_0[0] = 2;
				byte_0[4] = 17;
				break;
			case TimePeriodType.Tomorrow:
				byte_0[0] = 2;
				byte_0[4] = 16;
				break;
			case TimePeriodType.Last7Days:
				byte_0[0] = 2;
				byte_0[4] = 18;
				break;
			case TimePeriodType.ThisMonth:
				byte_0[0] = 2;
				byte_0[4] = 24;
				break;
			case TimePeriodType.LastMonth:
				byte_0[0] = 2;
				byte_0[4] = 19;
				break;
			case TimePeriodType.NextMonth:
				byte_0[0] = 2;
				byte_0[4] = 20;
				break;
			case TimePeriodType.ThisWeek:
				byte_0[0] = 2;
				byte_0[4] = 21;
				break;
			case TimePeriodType.LastWeek:
				byte_0[0] = 2;
				byte_0[4] = 23;
				break;
			case TimePeriodType.NextWeek:
				byte_0[0] = 2;
				byte_0[4] = 22;
				break;
			}
			break;
		case FormatConditionType.AboveAverage:
		{
			AboveAverage aboveAverage = formatCondition_0.AboveAverage;
			Array.Copy(BitConverter.GetBytes(aboveAverage.StdDev), 0, byte_0, 16, 4);
			if (aboveAverage.IsAboveAverage)
			{
				if (aboveAverage.IsEqualAverage)
				{
					byte_0[0] = 2;
					byte_0[4] = 29;
				}
				else
				{
					byte_0[0] = 2;
					byte_0[4] = 25;
				}
			}
			else if (aboveAverage.IsEqualAverage)
			{
				byte_0[0] = 2;
				byte_0[4] = 30;
			}
			else
			{
				byte_0[0] = 2;
				byte_0[4] = 26;
			}
			break;
		}
		}
		Array.Copy(BitConverter.GetBytes(formatCondition_0.method_6()), 0, byte_0, 8, 4);
		Array.Copy(BitConverter.GetBytes(formatCondition_0.Priority), 0, byte_0, 12, 4);
		byte b = 0;
		if (formatCondition_0.StopIfTrue)
		{
			b = (byte)(b | 2u);
		}
		if (formatCondition_0.Top10 != null && formatCondition_0.Top10.IsBottom)
		{
			b = (byte)(b | 8u);
		}
		if (formatCondition_0.Top10 != null && formatCondition_0.Top10.IsPercent)
		{
			b = (byte)(b | 0x10u);
		}
		byte_0[28] = b;
		if (array != null)
		{
			Array.Copy(array, 0, byte_0, 30, 4);
		}
		if (array2 != null)
		{
			Array.Copy(array2, 0, byte_0, 34, 4);
		}
		if (array3 != null)
		{
			Array.Copy(array3, 0, byte_0, 38, 4);
		}
		int num2 = 42;
		if (text != null)
		{
			Class1217.smethod_7(byte_0, ref num2, text);
		}
		else
		{
			byte[] sourceArray = new byte[4] { 255, 255, 255, 255 };
			Array.Copy(sourceArray, 0, byte_0, num2, 4);
			num2 += 4;
		}
		if (array != null)
		{
			Array.Copy(array, 0, byte_0, num2, array.Length);
			num2 += array.Length;
		}
		if (array2 != null)
		{
			Array.Copy(array2, 0, byte_0, num2, array2.Length);
			num2 += array2.Length;
		}
		if (array3 != null)
		{
			Array.Copy(array3, 0, byte_0, num2, array3.Length);
			num2 += array3.Length;
		}
	}
}
