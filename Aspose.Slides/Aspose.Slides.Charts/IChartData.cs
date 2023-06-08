using System.IO;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[Guid("912b4df7-7aa8-4c62-a637-4cfa35db1bc4")]
[ComVisible(true)]
public interface IChartData
{
	IChartDataWorkbook ChartDataWorkbook { get; }

	IChartSeriesCollection Series { get; }

	IChartSeriesGroupCollection SeriesGroups { get; }

	IChartCategoryCollection Categories { get; }

	bool UseSecondaryCategories { get; set; }

	IChartCategoryCollection SecondaryCategories { get; }

	MemoryStream ReadWorkbookStream();

	void WriteWorkbookStream(MemoryStream ms);
}
