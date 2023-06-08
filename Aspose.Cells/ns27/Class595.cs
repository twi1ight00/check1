using Aspose.Cells.Charts;

namespace ns27;

internal class Class595 : Class538
{
	internal Class595()
	{
		method_2(4122);
		method_0(2);
		byte_0 = new byte[2];
	}

	internal void method_4(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		case ChartType.AreaStacked:
		case ChartType.Area3DStacked:
			byte_0[0] = 1;
			break;
		case ChartType.Area100PercentStacked:
		case ChartType.Area3D100PercentStacked:
			byte_0[0] = 3;
			break;
		case ChartType.Area3D:
			break;
		}
	}
}
