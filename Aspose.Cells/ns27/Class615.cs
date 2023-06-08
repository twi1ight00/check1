using System;
using Aspose.Cells;
using Aspose.Cells.Charts;

namespace ns27;

internal class Class615 : Class538
{
	internal Class615(Chart chart_0)
	{
		method_2(4098);
		method_0(16);
		byte_0 = new byte[16];
		if (chart_0.method_15().Type == SheetType.Chart)
		{
			method_4(chart_0, chart_0.ChartObject.method_38(), 0);
			method_4(chart_0, chart_0.ChartObject.method_36(), 4);
		}
		method_4(chart_0, chart_0.ChartObject.Width, 8);
		method_4(chart_0, chart_0.ChartObject.Height, 12);
	}

	internal void method_4(Chart chart_0, int int_0, int int_1)
	{
		double num = (float)int_0 * 72f / (float)chart_0.method_14().method_75();
		Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, int_1 + 2, 2);
		num -= (double)(int)num;
		Array.Copy(BitConverter.GetBytes((ushort)(num * 65535.0 + 0.5)), 0, byte_0, int_1, 2);
	}
}
