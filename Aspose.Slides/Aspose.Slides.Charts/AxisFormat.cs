using ns25;

namespace Aspose.Slides.Charts;

public class AxisFormat : IAxisFormat, IPVIObject
{
	private FillFormat fillFormat_0;

	private LineFormat lineFormat_0 = new LineFormat(null);

	private EffectFormat effectFormat_0 = new EffectFormat(null);

	private Class306 class306_0 = new Class306();

	private Axis axis_0;

	internal Class306 PPTXUnsupportedProps => class306_0;

	public IFillFormat Fill => fillFormat_0;

	public ILineFormat Line => lineFormat_0;

	public IEffectFormat Effect => effectFormat_0;

	uint IPVIObject.Version => Version;

	internal uint Version => fillFormat_0.Version + lineFormat_0.Version + effectFormat_0.Version;

	internal AxisFormat(Axis parentAxis)
	{
		axis_0 = parentAxis;
		fillFormat_0 = new FillFormat(parentAxis);
		lineFormat_0.FillFormat.SolidFillColor.ColorType = ColorType.RGB;
	}
}
