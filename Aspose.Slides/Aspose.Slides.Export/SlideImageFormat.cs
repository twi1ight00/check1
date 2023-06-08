using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using ns12;

namespace Aspose.Slides.Export;

[Guid("84de2e77-6510-4a9e-a9ee-f7b7dcebf1ff")]
[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
public class SlideImageFormat : ISlideImageFormat
{
	private Enum16 enum16_0;

	private SVGOptions svgoptions_0;

	private float float_0;

	private ImageFormat imageFormat_0;

	internal Enum16 SlideImageType => enum16_0;

	internal ImageFormat ImageFormat => imageFormat_0;

	internal SVGOptions SvgOptions => svgoptions_0;

	internal float BitmapScale => float_0;

	public static SlideImageFormat Svg(SVGOptions options)
	{
		SlideImageFormat slideImageFormat = new SlideImageFormat();
		slideImageFormat.enum16_0 = Enum16.const_0;
		slideImageFormat.svgoptions_0 = options;
		return slideImageFormat;
	}

	public static SlideImageFormat Bitmap(float scale, ImageFormat imgFormat)
	{
		SlideImageFormat slideImageFormat = new SlideImageFormat();
		slideImageFormat.enum16_0 = Enum16.const_1;
		slideImageFormat.float_0 = scale;
		slideImageFormat.imageFormat_0 = imgFormat;
		return slideImageFormat;
	}
}
