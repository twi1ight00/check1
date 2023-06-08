using System.Drawing;
using Aspose.Slides;

namespace ns4;

internal class Class57 : IGradientStopEffectiveData, IEffectiveData
{
	private PatternFormat patternFormat_0;

	private bool bool_0;

	private Class21.Delegate3 delegate3_0;

	private IBaseSlide ibaseSlide_0;

	private float float_0;

	private Class18 class18_0;

	public float Position => float_0;

	public Color Color => class18_0.Color;

	internal Class57(float position, Class21.Delegate2 colorResolver)
	{
		float_0 = position;
		class18_0 = new Class18(colorResolver);
	}

	internal Class57(Class57 source)
	{
		float_0 = source.float_0;
		class18_0 = new Class18(source.class18_0.ColorResolver);
	}

	internal void method_0(IBaseSlide slide, FloatColor styleColor)
	{
		class18_0.method_0(slide, styleColor);
	}
}
