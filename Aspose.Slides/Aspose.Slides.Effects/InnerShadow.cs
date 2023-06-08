using System.Runtime.InteropServices;
using ns5;

namespace Aspose.Slides.Effects;

[Guid("07CA9AB5-B340-4E90-AAEC-ECFA8D6F4278")]
[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
public class InnerShadow : IInnerShadow, IEffect
{
	private double double_0;

	private float float_0;

	private double double_1;

	private ColorFormat colorFormat_0;

	private IPresentationComponent ipresentationComponent_0;

	private uint uint_0;

	public double BlurRadius
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
			method_1();
		}
	}

	public float Direction
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
			method_1();
		}
	}

	public double Distance
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
			method_1();
		}
	}

	public IColorFormat ShadowColor => colorFormat_0;

	internal IPresentationComponent Parent => ipresentationComponent_0;

	internal uint Version => uint_0 + colorFormat_0.Version;

	internal InnerShadow(IPresentationComponent parent)
	{
		ipresentationComponent_0 = parent;
		colorFormat_0 = new ColorFormat(parent as ISlideComponent, PresetColor.Black);
	}

	internal InnerShadow Clone()
	{
		InnerShadow innerShadow = (InnerShadow)MemberwiseClone();
		innerShadow.colorFormat_0 = new ColorFormat(null);
		innerShadow.colorFormat_0.method_0(colorFormat_0);
		return innerShadow;
	}

	internal void method_0(IPresentationComponent parent)
	{
		ipresentationComponent_0 = parent;
		colorFormat_0.Parent = parent as ISlideComponent;
		method_1();
	}

	EffectEffectiveData IEffect.GetReadonly(BaseSlide slide, FloatColor styleColor)
	{
		return new InnerShadowEffectiveData(double_0, float_0, double_1, colorFormat_0.method_5(slide, styleColor));
	}

	EffectEffectiveDataPVITemp IEffect.GetReadonly()
	{
		return new Class39(double_0, float_0, double_1, colorFormat_0.method_5);
	}

	private void method_1()
	{
		uint_0++;
	}
}
