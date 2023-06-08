using Aspose.Cells;
using Aspose.Cells.Charts;

namespace ns27;

internal class Class597 : Class538
{
	internal Class597()
	{
		method_2(4108);
		method_0(2);
		byte_0 = new byte[2];
	}

	internal void method_4(DataLabels dataLabels_0, FileFormatType fileFormatType_1)
	{
		if (dataLabels_0.ShowValue)
		{
			byte_0[0] |= 1;
		}
		if (dataLabels_0.ShowPercentage && ChartCollection.smethod_3(dataLabels_0.Type))
		{
			byte_0[0] |= 2;
			if (dataLabels_0.ShowCategoryName)
			{
				byte_0[0] |= 4;
			}
		}
		if (dataLabels_0.ShowCategoryName)
		{
			byte_0[0] |= 16;
		}
		if (dataLabels_0.ShowSeriesName && ChartCollection.smethod_16(dataLabels_0.Chart.Type))
		{
			byte_0[0] |= 16;
		}
		if (dataLabels_0.ShowBubbleSize && ChartCollection.smethod_17(dataLabels_0.Type))
		{
			byte_0[0] |= 32;
		}
	}
}
