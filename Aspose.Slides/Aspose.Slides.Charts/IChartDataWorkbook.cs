using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[ComVisible(true)]
[Guid("2621c20a-7a7c-4a32-bf76-ef4ef5aeff2f")]
public interface IChartDataWorkbook
{
	IChartCellCollection GetCellCollection(string formula, bool skipHiddenCells);

	IChartDataCell GetCell(string worksheetName, int row, int column);

	IChartDataCell GetCell(int worksheetIndex, int row, int column);

	IChartDataCell GetCell(int worksheetIndex, string cellName);

	IChartDataCell GetCell(int worksheetIndex, string cellName, object value);

	IChartDataCell GetCell(int worksheetIndex, int row, int column, object value);

	void Clear(int sheetIndex);
}
