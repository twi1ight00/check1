using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ns35;

internal class Class796 : Class794
{
	private int int_0;

	private int int_1;

	private Class806 class806_0;

	private Stream stream_0;

	private Interface4 interface4_0;

	internal Class796(int width, int height, Class806 imageOption, Stream stream, Interface4 shapeDrawing)
	{
		stream_0 = stream;
		int_0 = width;
		int_1 = height;
		if (imageOption == null)
		{
			class806_0 = new Class806();
		}
		else
		{
			class806_0 = imageOption;
		}
		interface4_0 = shapeDrawing;
	}

	public override void imethod_0()
	{
		if (stream_0 == null)
		{
			return;
		}
		Bitmap bitmap = null;
		Graphics graphics = null;
		IntPtr intPtr = IntPtr.Zero;
		Metafile metafile = null;
		try
		{
			bitmap = new Bitmap(1, 1);
			bitmap.SetResolution(class806_0.HorizontalResolution, class806_0.VerticalResolution);
			graphics = Graphics.FromImage(bitmap);
			intPtr = graphics.GetHdc();
			metafile = new Metafile(stream_0, intPtr, new RectangleF(0f, 0f, int_0, int_1), MetafileFrameUnit.Pixel, EmfType.EmfPlusDual);
			graphics_0 = Graphics.FromImage(metafile);
			base.GraphicsTools = new Class797(graphics_0);
			graphics_0.FillRectangle(new SolidBrush(Color.Empty), 0, 0, int_0, int_1);
			interface4_0.imethod_0();
		}
		finally
		{
			metafile?.Dispose();
			if (intPtr != IntPtr.Zero)
			{
				graphics.ReleaseHdc(intPtr);
			}
			graphics?.Dispose();
			bitmap?.Dispose();
			stream_0.Seek(0L, SeekOrigin.Begin);
			Dispose();
		}
	}

	public override Bitmap imethod_1()
	{
		throw new InvalidOperationException("Calls wrong method!");
	}

	public override void imethod_2()
	{
		if (graphics_0 != null)
		{
			graphics_0.Dispose();
			graphics_0 = null;
		}
	}

	public override void Dispose()
	{
		imethod_2();
	}
}
