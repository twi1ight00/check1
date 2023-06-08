using Aspose.Slides.Effects;

namespace ns5;

internal class Class31 : EffectEffectiveDataPVITemp, IBlurEffectiveData
{
	private double double_0;

	private bool bool_0;

	public double Radius => double_0;

	public bool Grow => bool_0;

	internal Class31(double radius, bool grow)
	{
		double_0 = radius;
		bool_0 = grow;
	}

	internal override Class190 vmethod_0(Class190 img)
	{
		return img;
	}

	internal override string vmethod_1()
	{
		return base.vmethod_1() + double_0 + bool_0;
	}
}
