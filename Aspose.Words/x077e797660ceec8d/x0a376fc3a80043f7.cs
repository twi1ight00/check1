using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Aspose;
using Aspose.Words;
using Aspose.Words.Saving;
using x1c8faa688b1f0b0c;
using x28925c9b27b37a46;
using x38a89dee67fc7a16;
using x6c95d9cf46ff5f25;
using x85732faf56f7825d;
using xf9a9481c3f63a419;

namespace x077e797660ceec8d;

internal class x0a376fc3a80043f7
{
	internal static void x53c5cdce403a6243(x4fdf549af9de6b97 xdb732bbde4502b4e, SizeF xa03db8a5ee939042, Stream xcf18e5243f8d5fd3, ImageSaveOptions xc27f01f21f67608c)
	{
		if (xdb732bbde4502b4e == null)
		{
			throw new ArgumentNullException("aps");
		}
		if (xcf18e5243f8d5fd3 == null)
		{
			throw new ArgumentNullException("stream");
		}
		if (xc27f01f21f67608c == null)
		{
			throw new ArgumentNullException("saveOptions");
		}
		switch (xc27f01f21f67608c.SaveFormat)
		{
		case SaveFormat.Emf:
			xe3210938a0b445e0(xdb732bbde4502b4e, xa03db8a5ee939042, xc27f01f21f67608c, xcf18e5243f8d5fd3);
			break;
		case SaveFormat.Tiff:
		{
			using x3cd5d648729cd9b6 x3cd5d648729cd9b4 = xf5af41f85264e71d(xdb732bbde4502b4e, xa03db8a5ee939042, xc27f01f21f67608c);
			x3cd5d648729cd9b4.x295e4a690e69bfab(xcf18e5243f8d5fd3, xc27f01f21f67608c.x858159a2ee718ca5);
			break;
		}
		case SaveFormat.Png:
		{
			using x3cd5d648729cd9b6 x3cd5d648729cd9b3 = xf5af41f85264e71d(xdb732bbde4502b4e, xa03db8a5ee939042, xc27f01f21f67608c);
			x3cd5d648729cd9b3.x76d9d85825f57cda(xcf18e5243f8d5fd3);
			break;
		}
		case SaveFormat.Bmp:
		{
			using x3cd5d648729cd9b6 x3cd5d648729cd9b2 = xf5af41f85264e71d(xdb732bbde4502b4e, xa03db8a5ee939042, xc27f01f21f67608c);
			x3cd5d648729cd9b2.xccd8261f31df114c(xcf18e5243f8d5fd3);
			break;
		}
		case SaveFormat.Jpeg:
		{
			using x3cd5d648729cd9b6 x3cd5d648729cd9b = xf5af41f85264e71d(xdb732bbde4502b4e, xa03db8a5ee939042, xc27f01f21f67608c);
			x3cd5d648729cd9b.x2746a43e49feca2f(xcf18e5243f8d5fd3, xc27f01f21f67608c.JpegQuality);
			break;
		}
		default:
			throw new InvalidOperationException("Unexpected image save format requested.");
		}
	}

	internal static x3cd5d648729cd9b6 xf5af41f85264e71d(x4fdf549af9de6b97 xdb732bbde4502b4e, SizeF xdb421875a5f5258b, ImageSaveOptions xc27f01f21f67608c)
	{
		Size xd46829d4aee3eb5e = x4574ea26106f0edb.x4bec21b1de9d1b5b(xdb421875a5f5258b, xc27f01f21f67608c.Scale, xc27f01f21f67608c.Resolution);
		x3cd5d648729cd9b6 x3cd5d648729cd9b = new x3cd5d648729cd9b6(xd46829d4aee3eb5e.Width, xd46829d4aee3eb5e.Height, xc27f01f21f67608c.Resolution, xc27f01f21f67608c.Resolution, xc27f01f21f67608c.xc8eead30a36b30c5);
		using (x3dacf8cbb5aec9f0 xf15f3ed674f04b8e = new x3dacf8cbb5aec9f0(x3cd5d648729cd9b))
		{
			x30c8ca6bc9c65a2b(xdb732bbde4502b4e, xf15f3ed674f04b8e, xd46829d4aee3eb5e, xc27f01f21f67608c);
		}
		x3cd5d648729cd9b.x729755e64b399531(new x24fae39da17573bb(xc27f01f21f67608c.xb56653ec61f2ac36, xc27f01f21f67608c.ImageBrightness, xc27f01f21f67608c.ImageContrast));
		return x3cd5d648729cd9b;
	}

	[JavaDelete("Rendering to EMF is not ported to Java.")]
	private static void xe3210938a0b445e0(x4fdf549af9de6b97 xdb732bbde4502b4e, SizeF xdb421875a5f5258b, ImageSaveOptions xc27f01f21f67608c, Stream xcf18e5243f8d5fd3)
	{
		Bitmap bitmap = null;
		Graphics graphics = null;
		IntPtr intPtr = IntPtr.Zero;
		Metafile metafile = null;
		try
		{
			bitmap = new Bitmap(1, 1);
			bitmap.SetResolution(96f, 96f);
			graphics = xaf1d5886bde15736.x2c0e2b36cc23e6ca(bitmap);
			intPtr = graphics.GetHdc();
			Size xd46829d4aee3eb5e = x4574ea26106f0edb.x4bec21b1de9d1b5b(xdb421875a5f5258b, xc27f01f21f67608c.Scale, 96.0);
			metafile = new Metafile(xcf18e5243f8d5fd3, intPtr, new RectangleF(0f, 0f, xd46829d4aee3eb5e.Width, xd46829d4aee3eb5e.Height), MetafileFrameUnit.Pixel, xc27f01f21f67608c.xa921e223ffb8ac41);
			using x3dacf8cbb5aec9f0 xf15f3ed674f04b8e = new x3dacf8cbb5aec9f0(metafile);
			x30c8ca6bc9c65a2b(xdb732bbde4502b4e, xf15f3ed674f04b8e, xd46829d4aee3eb5e, xc27f01f21f67608c);
		}
		finally
		{
			metafile?.Dispose();
			if (intPtr != IntPtr.Zero)
			{
				graphics?.ReleaseHdc(intPtr);
			}
			graphics?.Dispose();
			bitmap?.Dispose();
		}
		if (xcf18e5243f8d5fd3 == null)
		{
			throw new ArgumentNullException("stream");
		}
	}

	private static void x30c8ca6bc9c65a2b(x4fdf549af9de6b97 xdb732bbde4502b4e, x3dacf8cbb5aec9f0 xf15f3ed674f04b8e, Size xd46829d4aee3eb5e, ImageSaveOptions xc27f01f21f67608c)
	{
		if (xdb732bbde4502b4e == null)
		{
			throw new ArgumentNullException("aps");
		}
		if (xf15f3ed674f04b8e == null)
		{
			throw new ArgumentNullException("gfx");
		}
		xf15f3ed674f04b8e.x24670816c6fb8451();
		if (xc27f01f21f67608c.UseAntiAliasing)
		{
			xf15f3ed674f04b8e.xc265ae6c5754834c();
		}
		if (xc27f01f21f67608c.UseHighQualityRendering)
		{
			xf15f3ed674f04b8e.x4efda9e12bc505eb();
		}
		xf15f3ed674f04b8e.x7cfc143904bcbd0a(xc27f01f21f67608c.x64debce685f4c70c, 0f, 0f, xd46829d4aee3eb5e.Width, xd46829d4aee3eb5e.Height);
		xf15f3ed674f04b8e.x5152a5707921c783(xc27f01f21f67608c.Scale);
		x3a15c7024016ce52 x3a15c7024016ce = new x3a15c7024016ce52(new x7c8328a75e9baa2d(xc27f01f21f67608c.WarningCallback));
		x3a15c7024016ce.xe406325e56f74b46(xdb732bbde4502b4e, xf15f3ed674f04b8e.x0c16bcbc7d053d08());
	}
}
