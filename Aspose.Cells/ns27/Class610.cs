using System;
using Aspose.Cells;
using Aspose.Cells.Charts;

namespace ns27;

internal class Class610 : Class538
{
	internal Class610()
	{
		method_2(4128);
		method_0(8);
		byte_0 = new byte[8];
		byte_0[0] = 1;
		byte_0[2] = 1;
		byte_0[4] = 1;
		byte_0[6] = 1;
	}

	internal void method_4(FileFormatType fileFormatType_1, int int_0)
	{
		byte_0[6] = 0;
	}

	internal void method_5(Axis axis_0)
	{
		if (axis_0.CrossType == CrossType.Maximum)
		{
			byte_0[6] |= 2;
		}
		else if (axis_0.CrossType == CrossType.Custom && axis_0.CategoryType != CategoryType.TimeScale)
		{
			Array.Copy(BitConverter.GetBytes((ushort)axis_0.CrossAt), byte_0, 2);
		}
		Array.Copy(BitConverter.GetBytes((ushort)axis_0.TickLabelSpacing), 0, byte_0, 2, 2);
		Array.Copy(BitConverter.GetBytes((ushort)axis_0.TickMarkSpacing), 0, byte_0, 4, 2);
		if (axis_0.IsPlotOrderReversed)
		{
			byte_0[6] |= 4;
		}
		if (!axis_0.AxisBetweenCategories)
		{
			byte_0[6] &= 254;
		}
	}
}
