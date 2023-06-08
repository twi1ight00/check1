using System;
using Aspose.Cells.Charts;

namespace ns27;

internal class Class697 : Class538
{
	internal Class697()
	{
		method_2(4171);
		method_0(28);
		byte_0 = new byte[28];
	}

	internal void method_4(Trendline trendline_0)
	{
		byte_0[1] = 1;
		switch (trendline_0.Type)
		{
		case TrendlineType.Exponential:
			byte_0[0] = 1;
			break;
		case TrendlineType.Logarithmic:
			byte_0[0] = 2;
			break;
		case TrendlineType.MovingAverage:
			byte_0[0] = 4;
			byte_0[1] = (byte)trendline_0.Period;
			break;
		case TrendlineType.Polynomial:
			byte_0[1] = (byte)trendline_0.Order;
			break;
		case TrendlineType.Power:
			byte_0[0] = 3;
			break;
		}
		Array.Copy(BitConverter.GetBytes(trendline_0.Intercept), 0, byte_0, 2, 8);
		if (!trendline_0.method_37())
		{
			for (int i = 2; i < 6; i++)
			{
				byte_0[i] = byte.MaxValue;
			}
			byte_0[7] = 1;
			byte_0[8] = byte.MaxValue;
			byte_0[9] = byte.MaxValue;
		}
		if (trendline_0.DisplayEquation)
		{
			byte_0[10] = 1;
		}
		if (trendline_0.DisplayRSquared)
		{
			byte_0[11] = 1;
		}
		Array.Copy(BitConverter.GetBytes(trendline_0.Forward), 0, byte_0, 12, 8);
		Array.Copy(BitConverter.GetBytes(trendline_0.Backward), 0, byte_0, 20, 8);
	}
}
