using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using ns234;
using ns33;

namespace ns62;

internal class Class2636 : Class2634
{
	internal const int int_8 = 61466;

	internal Class2636()
		: base(61466, 980)
	{
	}

	public Class2636(Metafile srcMetafile)
		: base(61466, 980)
	{
		Rectangle bounds = srcMetafile.GetMetafileHeader().Bounds;
		Bitmap image;
		while (true)
		{
			try
			{
				image = new Bitmap(bounds.Width, bounds.Height, srcMetafile.PixelFormat);
			}
			catch (Exception ex)
			{
				if (bounds.Width < 300 && bounds.Height < 300)
				{
					throw new Exception("Can't create Bitmap", ex);
				}
				Class1165.smethod_28(ex);
				bounds.X = bounds.Left / 10;
				bounds.Y = bounds.Top / 10;
				bounds.Width /= 10;
				bounds.Height /= 10;
				continue;
			}
			break;
		}
		Graphics graphics = Graphics.FromImage(image);
		graphics.CompositingQuality = CompositingQuality.HighQuality;
		graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
		graphics.SmoothingMode = SmoothingMode.HighQuality;
		IntPtr hdc = graphics.GetHdc();
		MemoryStream memoryStream = new MemoryStream();
		Metafile metafile = new Metafile(memoryStream, hdc, EmfType.EmfPlusDual);
		graphics.ReleaseHdc(hdc);
		Graphics graphics2 = Graphics.FromImage(metafile);
		graphics2.CompositingQuality = CompositingQuality.HighQuality;
		graphics2.InterpolationMode = InterpolationMode.HighQualityBicubic;
		graphics2.SmoothingMode = SmoothingMode.HighQuality;
		graphics2.DrawImage(srcMetafile, bounds);
		metafile.Dispose();
		byte[] array = memoryStream.ToArray();
		base.BLIPFileData = Class6171.smethod_2(array, Enum794.const_1);
		method_1(array);
		uint_1 = (uint)array.Length;
		int_2 = bounds.Left;
		int_3 = bounds.Top;
		int_4 = bounds.Right;
		int_5 = bounds.Bottom;
		int_6 = bounds.Width * 12700;
		int_7 = bounds.Height * 12700;
		enum387_0 = Enum387.const_0;
		byte_1 = 254;
	}
}
