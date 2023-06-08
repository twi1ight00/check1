using System.Drawing;
using System.Drawing.Imaging;

namespace ns39;

internal class Class782
{
	public static ImageFormat smethod_0(string extName, ImageFormat imageFormat)
	{
		extName = extName.ToLower();
		switch (extName)
		{
		case ".png":
			return ImageFormat.Png;
		case ".emf":
			return ImageFormat.Emf;
		case ".gif":
			return ImageFormat.Gif;
		default:
			if (imageFormat != null && imageFormat != ImageFormat.Icon && imageFormat != ImageFormat.MemoryBmp && imageFormat != ImageFormat.Wmf && imageFormat != ImageFormat.Exif)
			{
				return imageFormat;
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

	public static void smethod_1(PointF[] points)
	{
		if (points != null)
		{
			for (int i = 0; i < points.Length; i++)
			{
				ref PointF reference = ref points[i];
				reference = new PointF(0f, 0f);
			}
		}
	}

	public static PointF smethod_2(PointF point)
	{
		return new PointF(point.X, point.Y);
	}
}
