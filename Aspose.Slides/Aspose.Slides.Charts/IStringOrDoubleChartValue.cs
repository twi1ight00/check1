using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[Guid("7aa08b6d-0c79-4a5f-86d1-3f8d18088ce8")]
[ComVisible(true)]
public interface IStringOrDoubleChartValue : IBaseChartValue, ISingleCellChartValue
{
	string AsLiteralString { get; set; }

	double AsLiteralDouble { get; set; }

	ISingleCellChartValue AsISingleCellChartValue { get; }

	double ToDouble();
}
