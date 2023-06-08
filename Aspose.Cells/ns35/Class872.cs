using System.Drawing;
using System.Drawing.Imaging;

namespace ns35;

internal class Class872
{
	public static ImageFormat smethod_0(string string_0, ImageFormat imageFormat_0)
	{
		string_0 = string_0.ToLower();
		switch (string_0)
		{
		case ".png":
			return ImageFormat.Png;
		case ".emf":
			return ImageFormat.Emf;
		case ".gif":
			return ImageFormat.Gif;
		default:
			if (imageFormat_0 != null && imageFormat_0 != ImageFormat.Icon && imageFormat_0 != ImageFormat.MemoryBmp && imageFormat_0 != ImageFormat.Wmf && imageFormat_0 != ImageFormat.Exif)
			{
				return imageFormat_0;
			}
			return ImageFormat.Bmp;
		case ".bmp":
		case ".dib":
		case ".rle":
			return ImageFormat.Bmp;
		case ".tiff":
		case ".tif":
			return ImageFormat.Tiff;
		case ".jpg":
		case ".jpeg":
		case ".jpe":
		case ".jfif":
			return ImageFormat.Jpeg;
		}
	}

	public static PointF smethod_1(PointF pointF_0)
	{
		return new PointF(pointF_0.X, pointF_0.Y);
	}
}
