using System.Drawing.Imaging;
using Aspose.Cells.Rendering;

namespace Aspose.Cells;

public class ImageSaveOptions : SaveOptions
{
	private ImageOrPrintOptions imageOrPrintOptions_0;

	public ImageOrPrintOptions ImageOrPrintOptions => imageOrPrintOptions_0;

	public ImageSaveOptions()
	{
		m_SaveFormat = SaveFormat.TIFF;
		imageOrPrintOptions_0 = new ImageOrPrintOptions();
		imageOrPrintOptions_0.ImageFormat = ImageFormat.Tiff;
	}

	public ImageSaveOptions(SaveFormat saveFormat)
	{
		m_SaveFormat = saveFormat;
		imageOrPrintOptions_0 = new ImageOrPrintOptions();
		imageOrPrintOptions_0.ImageFormat = ImageFormat.Tiff;
	}

	internal void Copy(ImageSaveOptions imageSaveOptions_0)
	{
		Copy((SaveOptions)imageSaveOptions_0);
		imageOrPrintOptions_0 = imageSaveOptions_0.imageOrPrintOptions_0;
	}

	internal static ImageSaveOptions smethod_0(SaveOptions saveOptions_0)
	{
		if (saveOptions_0 is ImageSaveOptions)
		{
			return (ImageSaveOptions)saveOptions_0;
		}
		return new ImageSaveOptions(saveOptions_0.SaveFormat);
	}
}
