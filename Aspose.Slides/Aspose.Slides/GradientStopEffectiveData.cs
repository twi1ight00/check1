using System.Drawing;

namespace Aspose.Slides;

public class GradientStopEffectiveData : IGradientStopEffectiveData, IEffectiveData
{
	private float float_0;

	private Color color_0;

	public float Position => float_0;

	public Color Color => color_0;

	internal GradientStopEffectiveData(float position, Color color)
	{
		float_0 = position;
		color_0 = color;
	}
}
