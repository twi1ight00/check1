using ns5;

namespace Aspose.Slides.Effects;

public class Blur : ImageTransformOperation, IImageTransformOperation, IBlur, IEffect
{
	private double double_0;

	private bool bool_0;

	public double Radius
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
			method_0();
		}
	}

	public bool Grow
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			method_0();
		}
	}

	IImageTransformOperation IBlur.AsIImageTransformOperation => this;

	internal Blur(double radius, bool grow, IPresentationComponent parent)
		: base(parent)
	{
		double_0 = radius;
		bool_0 = grow;
	}

	internal override Class190 vmethod_0(Class190 img, IBaseSlide slide, FloatColor styleColor)
	{
		return img;
	}

	EffectEffectiveData IEffect.GetReadonly(BaseSlide slide, FloatColor styleColor)
	{
		return new BlurEffectiveData(double_0, bool_0);
	}

	EffectEffectiveDataPVITemp IEffect.GetReadonly()
	{
		return new Class31(double_0, bool_0);
	}

	internal override string vmethod_1(IBaseSlide slide, FloatColor styleColor)
	{
		return base.vmethod_1(slide, styleColor) + double_0 + bool_0;
	}
}
