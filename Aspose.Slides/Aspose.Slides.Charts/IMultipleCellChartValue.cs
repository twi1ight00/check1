using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[ComVisible(true)]
[Guid("4aff0a9e-65fc-4e23-ba4f-6dc984ae92ab")]
public interface IMultipleCellChartValue : IBaseChartValue
{
	IChartCellCollection AsCells { get; set; }

	IBaseChartValue AsIBaseChartValue { get; }
}
