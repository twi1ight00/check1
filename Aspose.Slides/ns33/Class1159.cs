using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using Aspose.Slides;
using ns233;

namespace ns33;

internal class Class1159
{
	public const int int_0 = 4;

	public const int int_1 = 4;

	private const int int_2 = 2097152;

	private Class1159()
	{
	}

	public static bool smethod_0(byte[] buf)
	{
		if (buf.Length < 4)
		{
			return false;
		}
		if (buf[0] == 215 && buf[1] == 205 && buf[2] == 198 && buf[3] == 154)
		{
			return true;
		}
		if (buf[0] == 1 && buf[1] == 0 && buf[2] == 9 && buf[3] == 0)
		{
			return true;
		}
		return false;
	}

	public static bool smethod_1(byte[] buf)
	{
		if (buf.Length < 48)
		{
			return false;
		}
		if (buf[40] == 32 && buf[41] == 69 && buf[42] == 77 && buf[43] == 70 && buf[44] == 0 && buf[45] == 0 && buf[46] == 1 && buf[47] == 0)
		{
			return true;
		}
		return false;
	}

	public static Bitmap smethod_2(Image metafile, SizeF destinationArea, Class6145 crop, ImageAttributes imgAttributes, bool isReturnIncreasedImage)
	{
		GraphicsUnit pageUnit = GraphicsUnit.Pixel;
		RectangleF srcRect = metafile.GetBounds(ref pageUnit);
		if (crop != null)
		{
			srcRect = crop.method_0(srcRect);
		}
		Size size = smethod_6(new Size((int)destinationArea.Width, (int)destinationArea.Height));
		Bitmap bitmap = new Bitmap(size.Width * 4, size.Height * 4);
		Graphics graphics = Graphics.FromImage(bitmap);
		graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
		graphics.FillRectangle(new SolidBrush(Color.Transparent), 0, 0, bitmap.Width, bitmap.Height);
		PointF[] destPoints = new PointF[3]
		{
			new PointF(0f, 0f),
			new PointF(bitmap.Width, 0f),
			new PointF(0f, bitmap.Height)
		};
		graphics.DrawImage(metafile, destPoints, srcRect, GraphicsUnit.Pixel, imgAttributes);
		graphics.Dispose();
		if (!isReturnIncreasedImage)
		{
			Bitmap bitmap2 = new Bitmap(size.Width, size.Height);
			graphics = Graphics.FromImage(bitmap2);
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			graphics.CompositingQuality = CompositingQuality.HighQuality;
			graphics.DrawImage(bitmap, 0, 0, size.Width, size.Height);
			graphics.Dispose();
			bitmap.Dispose();
			return bitmap2;
		}
		return bitmap;
	}

	public static byte[] smethod_3(byte[] imageBytes, SizeF imageSize, bool isReturnIncreasedImage)
	{
		MemoryStream stream = new MemoryStream(imageBytes, writable: false);
		Image metafile = Image.FromStream(stream);
		byte[] array = null;
		using Bitmap bitmap = smethod_2(metafile, imageSize, null, null, isReturnIncreasedImage);
		MemoryStream memoryStream = new MemoryStream();
		bitmap.Save(memoryStream, ImageFormat.Png);
		memoryStream.Position = 0L;
		array = new byte[memoryStream.Length];
		memoryStream.Read(array, 0, array.Length);
		memoryStream.SetLength(0L);
		return array;
	}

	public static byte[] smethod_4(Metafile img, SizeF imageSize, Class6145 crop, bool isReturnIncreasedImage)
	{
		byte[] array = null;
		using Bitmap bitmap = smethod_2(img, imageSize, crop, null, isReturnIncreasedImage);
		MemoryStream memoryStream = new MemoryStream();
		bitmap.Save(memoryStream, ImageFormat.Png);
		memoryStream.Position = 0L;
		array = new byte[memoryStream.Length];
		memoryStream.Read(array, 0, array.Length);
		memoryStream.SetLength(0L);
		return array;
	}

	public static ImageFormat smethod_5(PPImageFormat slidesImageFormat)
	{
		return slidesImageFormat switch
		{
			PPImageFormat.Bmp => ImageFormat.Bmp, 
			PPImageFormat.Emf => ImageFormat.Emf, 
			PPImageFormat.Exif => ImageFormat.Exif, 
			PPImageFormat.Gif => ImageFormat.Gif, 
			PPImageFormat.Icon => ImageFormat.Icon, 
			PPImageFormat.Jpeg => ImageFormat.Jpeg, 
			PPImageFormat.MemoryBmp => ImageFormat.MemoryBmp, 
			PPImageFormat.Png => ImageFormat.Png, 
			PPImageFormat.Tiff => ImageFormat.Tiff, 
			PPImageFormat.Wmf => ImageFormat.Wmf, 
			_ => throw new ArgumentOutOfRangeException("slidesImageFormat"), 
		};
	}

	private static Size smethod_6(Size imageSize)
	{
		float num = imageSize.Width * imageSize.Height;
		if (num > 2097152f)
		{
			float num2 = (float)Math.Sqrt(num / 2097152f);
			imageSize.Width = (int)((float)imageSize.Width / num2);
			imageSize.Height = (int)((float)imageSize.Height / num2);
		}
		return imageSize;
	}

	public static bool smethod_7(byte[] data)
	{
		if (data.Length < 6)
		{
			return false;
		}
		if (data[0] == 71 && data[1] == 73 && data[2] == 70 && data[3] == 56 && (data[4] == 55 || data[4] == 57) && data[5] == 97)
		{
			return true;
		}
		return false;
	}

	public static bool smethod_8(byte[] data)
	{
		if (!smethod_7(data))
		{
			return false;
		}
		Image image = Image.FromStream(new MemoryStream(data, writable: false));
		FrameDimension dimension = new FrameDimension(image.FrameDimensionsList[0]);
		return image.GetFrameCount(dimension) > 1;
	}

	public static Bitmap smethod_9(Bitmap sourceBitmap)
	{
		BitmapData bitmapData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
		int width = sourceBitmap.Width;
		int num = sourceBitmap.Width;
		int num2 = sourceBitmap.Height;
		int num3 = 0;
		int num4 = 0;
		try
		{
			int num5 = bitmapData.Stride * bitmapData.Height;
			byte[] array = new byte[num5];
			Marshal.Copy(bitmapData.Scan0, array, 0, num5);
			for (int i = 0; i < num5; i += 4)
			{
				if (array[i + 3] != 0)
				{
					int num6 = i / 4 % width;
					int num7 = i / 4 / width;
					if (num6 < num)
					{
						num = num6;
					}
					if (num6 > num3)
					{
						num3 = num6;
					}
					if (num7 < num2)
					{
						num2 = num7;
					}
					if (num7 > num4)
					{
						num4 = num7;
					}
				}
			}
		}
		finally
		{
			sourceBitmap.UnlockBits(bitmapData);
		}
		if (num3 == 0 && num4 == 0)
		{
			return null;
		}
		Bitmap bitmap = new Bitmap(num3 - num + 1, num4 - num2 + 1, PixelFormat.Format32bppArgb);
		bitmap.MakeTransparent(Color.White);
		using Graphics graphics = Graphics.FromImage(bitmap);
		RectangleF srcRect = new RectangleF(num, num2, num3 - num + 1, num4 - num2 + 1);
		RectangleF destRect = new RectangleF(0f, 0f, bitmap.Width, bitmap.Height);
		graphics.DrawImage(sourceBitmap, destRect, srcRect, GraphicsUnit.Pixel);
		return bitmap;
	}
}
