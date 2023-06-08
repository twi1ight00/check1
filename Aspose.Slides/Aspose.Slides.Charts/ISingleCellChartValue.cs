using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[ComVisible(true)]
[Guid("5ed9e8ce-3f2b-4efd-bd68-511d1d13c3f5")]
public interface ISingleCellChartValue : IBaseChartValue
{
	IChartDataCell AsCell { get; set; }

	IBaseChartValue AsIBaseChartValue { get; }
}
