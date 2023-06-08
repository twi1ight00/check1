using System.Runtime.InteropServices;

namespace Aspose.Slides.Effects;

[Guid("C48A4D66-14D5-4145-85A7-458EC2766E6A")]
[ComVisible(true)]
public interface IImageTransformOperationFactory
{
	IAlphaBiLevel CreateAlphaBiLevel(float threshold);

	IAlphaCeiling CreateAlphCeiling();

	IAlphaFloor CreateAlphaFloor();

	IAlphaInverse CreateAlphaInverse();

	IAlphaModulate CreateAlphaModulate();

	IAlphaModulateFixed CreateAlphaModulateFixed(float amount);

	IAlphaReplace CreateAlphaReplace(float alpha);

	IBiLevel CreateBiLevel(float threshold);

	IBlur CreateBlur(double radius, bool grow);

	IColorChange CreateColorChange();

	IColorReplace CreateColorReplace();

	IDuotone CreateDuotone();

	IFillOverlay CreateFillOverlay();

	IGrayScale CreateGrayScale();

	IHSL CreateHSL(float hue, float saturation, float luminance);

	ILuminance CreateLuminance(float brightness, float contrast);

	ITint CreateTint(float hue, float amount);
}
