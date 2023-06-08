using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[Guid("96d8a4b7-179b-4313-a946-c0592d7e1c43")]
[ComVisible(true)]
public interface IChartDataCell
{
	int Row { get; }

	int Column { get; }

	object Value { get; set; }

	IChartDataWorksheet ChartDataWorksheet { get; }

	bool IsHidden { get; }

	string CustomNumberFormat { get; set; }

	byte PresetNumberFormat { get; set; }
}
