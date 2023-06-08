using System;
using Aspose.Cells.Charts;

namespace ns27;

internal class Class591 : Class538
{
	internal long long_0;

	internal Class591(Chart chart_0)
	{
		method_2(4164);
		method_0(4);
		byte_0 = new byte[4];
		int num = chart_0.method_10();
		if (!chart_0.PlotArea.method_17() || !chart_0.PlotArea.IsAutoSize)
		{
			num |= 0x18;
		}
		if (chart_0.class1388_0.Count > 1)
		{
			num |= 1;
		}
		Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, 0, 2);
		chart_0.method_11((byte)num);
		switch (chart_0.PlotEmptyCellsType)
		{
		case PlotEmptyCellsType.Zero:
			byte_0[2] = 1;
			break;
		case PlotEmptyCellsType.Interpolated:
			byte_0[2] = 2;
			break;
		}
	}

	internal void method_4(Chart chart_0)
	{
		byte_0 = new byte[4];
		int num = chart_0.method_10();
		if (!chart_0.PlotArea.method_17() || !chart_0.PlotArea.IsAutoSize)
		{
			num |= 0x18;
		}
		if (chart_0.class1388_0.Count > 1)
		{
			num |= 1;
		}
		Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, 0, 2);
		chart_0.method_11((byte)num);
		switch (chart_0.PlotEmptyCellsType)
		{
		case PlotEmptyCellsType.Zero:
			byte_0[2] = 1;
			break;
		case PlotEmptyCellsType.Interpolated:
			byte_0[2] = 2;
			break;
		}
	}
}
