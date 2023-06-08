using ns25;

namespace Aspose.Slides.Charts;

public class ChartLinesFormat : IChartLinesFormat
{
	private Class311 class311_0 = new Class311();

	private LineFormat lineFormat_0 = new LineFormat(null);

	private EffectFormat effectFormat_0 = new EffectFormat(null);

	public ILineFormat Line => lineFormat_0;

	public IEffectFormat Effect => effectFormat_0;

	internal Class311 PPTXUnsupportedProps => class311_0;

	internal uint Version => lineFormat_0.Version + effectFormat_0.Version;

	internal ChartLinesFormat()
	{
	}
}
