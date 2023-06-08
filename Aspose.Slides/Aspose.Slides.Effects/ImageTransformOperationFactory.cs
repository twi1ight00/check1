using System.Runtime.InteropServices;

namespace Aspose.Slides.Effects;

[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
[Guid("1FE3B39F-5F06-47D2-B919-2031BCCB6F97")]
public class ImageTransformOperationFactory : IImageTransformOperationFactory
{
	public IAlphaBiLevel CreateAlphaBiLevel(float threshold)
	{
		return new AlphaBiLevel(threshold, null);
	}

	public IAlphaCeiling CreateAlphCeiling()
	{
		return new AlphaCeiling(null);
	}

	public IAlphaFloor CreateAlphaFloor()
	{
		return new AlphaFloor(null);
	}

	public IAlphaInverse CreateAlphaInverse()
	{
		return new AlphaInverse(null);
	}

	public IAlphaModulate CreateAlphaModulate()
	{
		return new AlphaModulate(null);
	}

	public IAlphaModulateFixed CreateAlphaModulateFixed(float amount)
	{
		return new AlphaModulateFixed(amount, null);
	}

	public IAlphaReplace CreateAlphaReplace(float alpha)
	{
		return new AlphaReplace(alpha, null);
	}

	public IBiLevel CreateBiLevel(float threshold)
	{
		return new BiLevel(threshold, null);
	}

	public IBlur CreateBlur(double radius, bool grow)
	{
		return new Blur(radius, grow, null);
	}

	public IColorChange CreateColorChange()
	{
		return new ColorChange(null);
	}

	public IColorReplace CreateColorReplace()
	{
		return new ColorReplace(null);
	}

	public IDuotone CreateDuotone()
	{
		return new Duotone(null);
	}

	public IFillOverlay CreateFillOverlay()
	{
		return new FillOverlay(null);
	}

	public IGrayScale CreateGrayScale()
	{
		return new GrayScale(null);
	}

	public IHSL CreateHSL(float hue, float saturation, float luminance)
	{
		return new HSL(hue, saturation, luminance, null);
	}

	public ILuminance CreateLuminance(float brightness, float contrast)
	{
		return new Luminance(brightness, contrast, null);
	}

	public ITint CreateTint(float hue, float amount)
	{
		return new Tint(hue, amount, null);
	}
}
