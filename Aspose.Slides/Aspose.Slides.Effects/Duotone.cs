using System.Drawing;
using System.Runtime.InteropServices;
using ns5;

namespace Aspose.Slides.Effects;

[Guid("3bd9de96-f11f-47f7-9f47-572ca5ca7f07")]
[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
public class Duotone : ImageTransformOperation, IImageTransformOperation, IDuotone, IEffect
{
	private ColorFormat colorFormat_0;

	private ColorFormat colorFormat_1;

	public IColorFormat Color1 => colorFormat_0;

	public IColorFormat Color2 => colorFormat_1;

	internal override uint Version => base.Version + colorFormat_0.Version + colorFormat_1.Version;

	IImageTransformOperation IDuotone.AsIImageTransformOperation => this;

	internal Duotone(IPresentationComponent parent)
		: base(parent)
	{
		colorFormat_0 = new ColorFormat(base.Parent as ISlideComponent);
		colorFormat_1 = new ColorFormat(base.Parent as ISlideComponent);
	}

	internal override Class190 vmethod_0(Class190 img, IBaseSlide slide, FloatColor styleColor)
	{
		Color color = colorFormat_0.method_5(slide, styleColor);
		Color color2 = colorFormat_1.method_5(slide, styleColor);
		int r = color.R;
		int num = color2.R - r;
		int g = color.G;
		int num2 = color2.G - g;
		int b = color.B;
		int num3 = color2.B - b;
		for (int i = 0; i < img.Bits.Length; i++)
		{
			int num4 = img.Bits[i];
			int num5 = (num4 >> 24) & 0xFF;
			int num6 = (num4 >> 16) & 0xFF;
			int num7 = (num4 >> 8) & 0xFF;
			int num8 = num4 & 0xFF;
			float num9 = ((float)num6 * 0.2126f + (float)num7 * 0.7151f + (float)num8 * 0.0722f) / 255f;
			img.Bits[i] = (num5 << 24) + ((int)((float)r + (float)num * num9) << 16) + ((int)((float)g + (float)num2 * num9) << 8) + (int)((float)b + (float)num3 * num9);
		}
		return img;
	}

	internal override ImageTransformOperation Clone()
	{
		Duotone duotone = new Duotone(null);
		duotone.colorFormat_0 = new ColorFormat(null);
		duotone.colorFormat_0.method_0(colorFormat_0);
		duotone.colorFormat_1 = new ColorFormat(null);
		duotone.colorFormat_1.method_0(colorFormat_1);
		return duotone;
	}

	internal override void vmethod_2(IPresentationComponent parent)
	{
		base.vmethod_2(parent);
		colorFormat_0.Parent = base.Parent as ISlideComponent;
		colorFormat_1.Parent = base.Parent as ISlideComponent;
		method_0();
	}

	EffectEffectiveData IEffect.GetReadonly(BaseSlide slide, FloatColor styleColor)
	{
		return new DuotoneEffectiveData(colorFormat_0.method_5(slide, styleColor), colorFormat_0.method_5(slide, styleColor));
	}

	EffectEffectiveDataPVITemp IEffect.GetReadonly()
	{
		return new Class34(colorFormat_0.method_5, colorFormat_0.method_5);
	}

	internal override string vmethod_1(IBaseSlide slide, FloatColor styleColor)
	{
		return string.Concat(base.vmethod_1(slide, styleColor), colorFormat_0.method_5(slide, styleColor), ' ', colorFormat_1.method_5(slide, styleColor));
	}
}
