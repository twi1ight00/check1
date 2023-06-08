using Aspose.Cells.Charts;

namespace ns27;

internal class Class623 : Class538
{
	internal Class623()
	{
		method_2(4195);
		method_0(2);
		byte_0 = new byte[2];
		byte_0[0] = 15;
	}

	internal void method_4(ChartDataTable chartDataTable_0)
	{
		if (!chartDataTable_0.HasBorderHorizontal)
		{
			byte_0[0] &= 254;
		}
		if (!chartDataTable_0.HasBorderVertical)
		{
			byte_0[0] &= 253;
		}
		if (!chartDataTable_0.HasBorderOutline)
		{
			byte_0[0] &= 251;
		}
		if (!chartDataTable_0.ShowLegendKey)
		{
			byte_0[0] &= 7;
		}
	}
}
