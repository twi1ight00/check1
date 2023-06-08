using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[Guid("9c749dac-b520-4d7e-8290-384f04a1bb63")]
[ComVisible(true)]
public interface IChartLinesFormat
{
	ILineFormat Line { get; }

	IEffectFormat Effect { get; }
}
