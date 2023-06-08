using Aspose.Slides.Charts;
using ns16;
using ns56;

namespace ns17;

internal class Class919
{
	public static void smethod_0(IChart chart, Class2072 dTableElementData, Class1341 deserializationContext)
	{
		if (dTableElementData == null)
		{
			chart.HasDataTable = false;
			return;
		}
		chart.HasDataTable = true;
		IDataTable chartDataTable = chart.ChartDataTable;
		if (dTableElementData.ShowHorzBorder != null)
		{
			chartDataTable.HasBorderHorizontal = dTableElementData.ShowHorzBorder.Val;
		}
		if (dTableElementData.ShowVertBorder != null)
		{
			chartDataTable.HasBorderVertical = dTableElementData.ShowVertBorder.Val;
		}
		if (dTableElementData.ShowOutline != null)
		{
			chartDataTable.HasBorderOutline = dTableElementData.ShowOutline.Val;
		}
		if (dTableElementData.ShowKeys != null)
		{
			chartDataTable.ShowLegendKey = dTableElementData.ShowKeys.Val;
		}
		Class921.smethod_0(chartDataTable.Format, dTableElementData.SpPr, deserializationContext);
		Class916.smethod_0(chartDataTable.TextFormat, dTableElementData.TxPr, deserializationContext);
		((DataTable)chartDataTable).PPTXUnsupportedProps.ExtensionList = dTableElementData.ExtLst;
	}

	public static void smethod_1(IChart chart, Class2072.Delegate1930 addDTable, Class1346 serializationContext)
	{
		if (chart.HasDataTable)
		{
			Class2072 @class = addDTable();
			IDataTable chartDataTable = chart.ChartDataTable;
			@class.delegate2763_0().Val = chartDataTable.HasBorderHorizontal;
			@class.delegate2763_1().Val = chartDataTable.HasBorderVertical;
			@class.delegate2763_2().Val = chartDataTable.HasBorderOutline;
			@class.delegate2763_3().Val = chartDataTable.ShowLegendKey;
			Class921.smethod_1(chartDataTable.Format, @class.delegate1630_0, serializationContext);
			Class916.smethod_5(chartDataTable.TextFormat, @class.delegate1705_0, serializationContext);
			@class.delegate1535_0(((DataTable)chartDataTable).PPTXUnsupportedProps.ExtensionList);
		}
	}
}
