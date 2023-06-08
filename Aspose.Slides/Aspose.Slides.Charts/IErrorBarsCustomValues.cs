using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[Guid("f0f17329-b68e-421d-ad1e-ffeae3da87f5")]
[ComVisible(true)]
public interface IErrorBarsCustomValues
{
	IDoubleChartValue XMinus { get; }

	IDoubleChartValue YMinus { get; }

	IDoubleChartValue XPlus { get; }

	IDoubleChartValue YPlus { get; }
}
