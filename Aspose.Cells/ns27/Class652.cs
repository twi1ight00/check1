using Aspose.Cells.Charts;

namespace ns27;

internal class Class652 : Class538
{
	internal Class652()
	{
		method_2(4120);
		method_0(2);
		byte_0 = new byte[2];
	}

	internal void method_4(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		case ChartType.LineStacked:
		case ChartType.LineStackedWithDataMarkers:
			byte_0[0] = 1;
			break;
		case ChartType.Line100PercentStacked:
		case ChartType.Line100PercentStackedWithDataMarkers:
			byte_0[0] = 3;
			break;
		case ChartType.LineWithDataMarkers:
			break;
		}
	}
}
