using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[Guid("285869c4-f917-4533-8fbe-8e6e4a48c941")]
[ComVisible(true)]
public interface IChartSeriesGroup
{
	CombinableSeriesTypesGroup Type { get; }

	bool PlotOnSecondAxis { get; }

	IChartSeriesReadonlyCollection Series { get; }

	IChartSeries this[int index] { get; }

	IUpDownBarsManager UpDownBars { get; }

	ushort GapWidth { get; set; }

	ushort GapDepth { get; set; }

	ushort FirstSliceAngle { get; set; }

	bool IsColorVaried { get; set; }

	bool HasSeriesLines { get; set; }

	sbyte Overlap { get; set; }
}
