using System;
using Aspose.Cells.Charts;
using ns7;

namespace ns27;

internal class Class607 : Class538
{
	internal Class607(Class1387 class1387_0)
	{
		method_2(4193);
		method_0(22);
		byte_0 = new byte[22];
		switch (class1387_0.method_11())
		{
		case ChartType.PieBar:
			byte_0[0] = 2;
			break;
		case ChartType.PiePie:
			byte_0[0] = 1;
			break;
		}
		if (class1387_0.IsAutoSplit)
		{
			byte_0[1] = 1;
		}
		else
		{
			byte_0[1] = 0;
		}
		switch (class1387_0.SplitType)
		{
		case ChartSplitType.Position:
			byte_0[2] = 0;
			Array.Copy(BitConverter.GetBytes((ushort)class1387_0.SplitValue), 0, byte_0, 4, 2);
			break;
		case ChartSplitType.Value:
			byte_0[2] = 1;
			Array.Copy(BitConverter.GetBytes(class1387_0.SplitValue), 0, byte_0, 12, 8);
			break;
		case ChartSplitType.PercentValue:
			byte_0[2] = 2;
			Array.Copy(BitConverter.GetBytes((ushort)class1387_0.SplitValue), 0, byte_0, 6, 2);
			break;
		case ChartSplitType.Custom:
			byte_0[2] = 3;
			break;
		}
		Array.Copy(BitConverter.GetBytes((ushort)class1387_0.SecondPlotSize), 0, byte_0, 8, 2);
		Array.Copy(BitConverter.GetBytes((ushort)class1387_0.GapWidth), 0, byte_0, 10, 2);
	}
}
