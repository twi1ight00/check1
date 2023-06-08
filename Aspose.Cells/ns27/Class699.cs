using System;
using System.Collections;
using Aspose.Cells;
using Aspose.Cells.Charts;
using ns7;

namespace ns27;

internal class Class699 : Class538
{
	internal Class699(FileFormatType fileFormatType_1)
	{
		method_2(4099);
		method_0(12);
		byte_0 = new byte[12];
		byte_0[0] = 1;
		byte_0[2] = 1;
		byte_0[8] = 1;
	}

	internal void method_4(Trendline trendline_0)
	{
		TrendlineType type = trendline_0.Type;
		if (type == TrendlineType.Linear)
		{
			byte_0[4] = 2;
			byte_0[6] = 2;
		}
	}

	internal void method_5(ErrorBar errorBar_0)
	{
		if (errorBar_0.Type != 0)
		{
			return;
		}
		ushort num = 0;
		Interface45 @interface = null;
		@interface = ((errorBar_0.DisplayType != ErrorBarDisplayType.Plus) ? errorBar_0.method_37() : errorBar_0.method_35());
		if (@interface != null)
		{
			num = (ushort)@interface.imethod_11();
			if (@interface.imethod_13() == Enum126.const_6)
			{
				byte_0[2] = 3;
			}
			Array.Copy(BitConverter.GetBytes(num), 0, byte_0, 6, 2);
			Array.Copy(BitConverter.GetBytes(num), 0, byte_0, 4, 2);
		}
	}

	internal void method_6(Series series_0, ChartType chartType_0)
	{
		ushort num = 0;
		ushort num2 = 0;
		if (series_0.method_16() != null)
		{
			num2 = (ushort)series_0.method_16().imethod_11();
			if (series_0.method_16().imethod_13() == Enum126.const_6)
			{
				byte_0[2] = 3;
			}
			Array.Copy(BitConverter.GetBytes(num2), 0, byte_0, 6, 2);
		}
		num = 0;
		if (series_0.method_18() != null)
		{
			num = (ushort)series_0.method_18().imethod_11();
			if (num > num2 && !ChartCollection.smethod_12(chartType_0) && series_0.method_18().imethod_13() != Enum126.const_6 && series_0.method_18().imethod_13() != Enum126.const_1 && series_0.method_16() != null && series_0.method_16().imethod_0())
			{
				num = num2;
			}
			if (series_0.method_18().imethod_13() == Enum126.const_6)
			{
				byte_0[0] = 3;
			}
			else if (series_0.method_18().imethod_13() != Enum126.const_1 && series_0.method_18().imethod_2() != null)
			{
				ArrayList arrayList = series_0.method_18().imethod_2();
				for (int i = 0; i < arrayList.Count; i++)
				{
					if (arrayList[i] is string)
					{
						byte_0[0] = 3;
						break;
					}
				}
			}
		}
		if (num == 0)
		{
			num = num2;
		}
		Array.Copy(BitConverter.GetBytes(num), 0, byte_0, 4, 2);
		if (!ChartCollection.smethod_17(chartType_0))
		{
			return;
		}
		num = 0;
		if (series_0.method_20() != null)
		{
			num = (ushort)series_0.method_20().imethod_11();
			if (series_0.method_20().imethod_13() == Enum126.const_6)
			{
				byte_0[8] = 3;
			}
		}
		if (num == 0)
		{
			num = num2;
		}
		Array.Copy(BitConverter.GetBytes(num), 0, byte_0, 10, 2);
	}
}
