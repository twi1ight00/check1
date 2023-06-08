using System.Drawing;
using System.Runtime.InteropServices;
using ns5;

namespace Aspose.Slides.Effects;

[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
[Guid("50116f54-8757-49d2-9497-95798b222653")]
public class ColorReplace : ImageTransformOperation, IImageTransformOperation, IColorReplace, IEffect
{
	private ColorFormat colorFormat_0;

	public IColorFormat Color => colorFormat_0;

	internal override uint Version => base.Version + colorFormat_0.Version;

	IImageTransformOperation IColorReplace.AsIImageTransformOperation => this;

	internal ColorReplace(IPresentationComponent parent)
		: base(parent)
	{
		colorFormat_0 = new ColorFormat(base.Parent as ISlideComponent);
	}

	internal override Class190 vmethod_0(Class190 img, IBaseSlide slide, FloatColor styleColor)
	{
		Color color = colorFormat_0.method_5(slide, styleColor);
		int num = (color.R << 16) | (color.G << 8) | color.B;
		for (int i = 0; i < img.Bits.Length; i++)
		{
			int num2 = img.Bits[i];
			img.Bits[i] = num | (num2 & -16777216);
		}
		return img;
	}

	internal override ImageTransformOperation Clone()
	{
		ColorReplace colorReplace = (ColorReplace)MemberwiseClone();
		colorReplace.colorFormat_0 = new ColorFormat(null);
		colorReplace.colorFormat_0.method_0(colorFormat_0);
		return colorReplace;
	}

	internal override void vmethod_2(IPresentationComponent parent)
	{
		base.vmethod_2(parent);
		colorFormat_0.Parent = base.Parent as ISlideComponent;
		method_0();
	}

	EffectEffectiveData IEffect.GetReadonly(BaseSlide slide, FloatColor styleColor)
	{
		return new ColorReplaceEffectiveData(colorFormat_0.method_5(slide, styleColor));
	}

	EffectEffectiveDataPVITemp IEffect.GetReadonly()
	{
		return new Class33(colorFormat_0.method_5);
	}

	internal override string vmethod_1(IBaseSlide slide, FloatColor styleColor)
	{
		return base.vmethod_1(slide, styleColor) + colorFormat_0.method_5(slide, styleColor);
	}
}
