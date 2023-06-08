using System.Drawing;
using System.Runtime.InteropServices;
using ns5;

namespace Aspose.Slides.Effects;

[Guid("1ed8918d-d8bd-412a-90d2-d23dd4a81585")]
[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
public class AlphaInverse : ImageTransformOperation, IImageTransformOperation, IAlphaInverse, IEffect
{
	private ColorFormat colorFormat_0;

	internal ColorFormat Color => colorFormat_0;

	internal override uint Version => base.Version + colorFormat_0.Version;

	IImageTransformOperation IAlphaInverse.AsIImageTransformOperation => this;

	internal AlphaInverse(IPresentationComponent parent)
		: base(parent)
	{
		colorFormat_0 = new ColorFormat(base.Parent as ISlideComponent);
	}

	private Color method_1(Color color)
	{
		return System.Drawing.Color.FromArgb(255 - color.A, color);
	}

	internal override Class190 vmethod_0(Class190 img, IBaseSlide slide, FloatColor styleColor)
	{
		for (int i = 0; i < img.Bits.Length; i++)
		{
			int num = img.Bits[i];
			int num2 = (num >> 24) & 0xFF;
			num2 = 255 - num2;
			img.Bits[i] = (num2 << 24) | (img.Bits[i] & 0xFFFFFF);
		}
		return img;
	}

	internal override ImageTransformOperation Clone()
	{
		AlphaInverse alphaInverse = new AlphaInverse(null);
		alphaInverse.colorFormat_0 = new ColorFormat(null);
		alphaInverse.colorFormat_0.method_0(colorFormat_0);
		return alphaInverse;
	}

	internal override void vmethod_2(IPresentationComponent parent)
	{
		base.vmethod_2(parent);
		colorFormat_0.Parent = base.Parent as ISlideComponent;
		method_0();
	}

	EffectEffectiveData IEffect.GetReadonly(BaseSlide slide, FloatColor styleColor)
	{
		return new AlphaInverseEffectiveData(colorFormat_0.method_5(slide, styleColor));
	}

	EffectEffectiveDataPVITemp IEffect.GetReadonly()
	{
		return new Class26(colorFormat_0.method_5);
	}
}
