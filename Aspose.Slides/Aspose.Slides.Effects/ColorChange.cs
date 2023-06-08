using System.Drawing;
using System.Runtime.InteropServices;
using ns5;

namespace Aspose.Slides.Effects;

[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
[Guid("0f0c10b0-8149-49b3-88e9-a7e5cc48aa88")]
public class ColorChange : ImageTransformOperation, IImageTransformOperation, IColorChange, IEffect
{
	private ColorFormat colorFormat_0;

	private ColorFormat colorFormat_1;

	private bool bool_0 = true;

	public IColorFormat FromColor => colorFormat_0;

	public IColorFormat ToColor => colorFormat_1;

	internal bool UseAlpha
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

	internal override uint Version => base.Version + colorFormat_0.Version + colorFormat_1.Version;

	IImageTransformOperation IColorChange.AsIImageTransformOperation => this;

	internal ColorChange(IPresentationComponent parent)
		: base(parent)
	{
		colorFormat_0 = new ColorFormat(base.Parent as ISlideComponent);
		colorFormat_1 = new ColorFormat(base.Parent as ISlideComponent);
	}

	internal ColorChange(Color colorFrom, Color colorTo, bool useAlpha, IPresentationComponent parent)
		: this(parent)
	{
		colorFormat_0.Color = colorFrom;
		colorFormat_1.Color = colorTo;
		bool_0 = useAlpha;
	}

	internal ColorChange(Color colorFrom, SchemeColor colorTo, bool useAlpha, IPresentationComponent parent)
		: this(parent)
	{
		colorFormat_0.Color = colorFrom;
		colorFormat_1.SchemeColor = colorTo;
		bool_0 = useAlpha;
	}

	internal override Class190 vmethod_0(Class190 img, IBaseSlide slide, FloatColor styleColor)
	{
		Color color = colorFormat_0.method_5(slide, styleColor);
		Color color2 = colorFormat_1.method_5(slide, styleColor);
		int num = color.R - 17;
		int num2 = color.R + 17;
		int num3 = color.G - 17;
		int num4 = color.G + 17;
		int num5 = color.B - 17;
		int num6 = color.B + 17;
		int num7 = (color2.R << 16) + (color2.G << 8) + color2.B;
		if (bool_0)
		{
			num7 += color2.A << 24;
			int num8 = color.A - 17;
			int num9 = color.A + 17;
			for (int i = 0; i < img.Bits.Length; i++)
			{
				int num10 = img.Bits[i];
				int num11 = (num10 >> 24) & 0xFF;
				int num12 = (num10 >> 16) & 0xFF;
				int num13 = (num10 >> 8) & 0xFF;
				int num14 = num10 & 0xFF;
				if (num8 < num11 && num11 < num9 && num < num12 && num12 < num2 && num3 < num13 && num13 < num4 && num5 < num14 && num14 < num6)
				{
					img.Bits[i] = num7;
				}
			}
		}
		else
		{
			for (int j = 0; j < img.Bits.Length; j++)
			{
				int num15 = img.Bits[j];
				int num16 = (num15 >> 24) & 0xFF;
				int num17 = (num15 >> 16) & 0xFF;
				int num18 = (num15 >> 8) & 0xFF;
				int num19 = num15 & 0xFF;
				if (num < num17 && num17 < num2 && num3 < num18 && num18 < num4 && num5 < num19 && num19 < num6)
				{
					img.Bits[j] = (num16 << 24) | num7;
				}
			}
		}
		return img;
	}

	EffectEffectiveData IEffect.GetReadonly(BaseSlide slide, FloatColor styleColor)
	{
		return new ColorChangeEffectiveData(colorFormat_0.method_5(slide, styleColor), colorFormat_1.method_5(slide, styleColor), bool_0);
	}

	EffectEffectiveDataPVITemp IEffect.GetReadonly()
	{
		return new Class32(colorFormat_0.method_5, colorFormat_1.method_5, bool_0);
	}

	internal override string vmethod_1(IBaseSlide slide, FloatColor styleColor)
	{
		return string.Concat(base.vmethod_1(slide, styleColor), colorFormat_0.method_5(slide, styleColor), " ", colorFormat_1.method_5(slide, styleColor), ' ', bool_0);
	}
}
