using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[Guid("1397ed5a-dd10-473e-80e1-6fe51414a142")]
[ComVisible(true)]
public interface IStringChartValue : IBaseChartValue, IMultipleCellChartValue
{
	string AsLiteralString { get; set; }

	IMultipleCellChartValue AsIMultipleCellChartValue { get; }

	new string ToString();

	void SetFromOneCell(IChartDataCell cell);

	string GetCellsAddressInWorkbook();
}
