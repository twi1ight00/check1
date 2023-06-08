using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[Guid("50e9fe2c-6479-4819-bcd8-c84163955676")]
[ComVisible(true)]
public interface IDoubleChartValue : IBaseChartValue, ISingleCellChartValue
{
	double AsLiteralDouble { get; set; }

	ISingleCellChartValue AsISingleCellChartValue { get; }

	double ToDouble();
}
