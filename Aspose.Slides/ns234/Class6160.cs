using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using ns224;

namespace ns234;

internal class Class6160 : IDisposable
{
	private Graphics graphics_0;

	private readonly TextRenderingHint textRenderingHint_0;

	public Class6160(Class6150 palBitmap)
		: this(palBitmap.method_2())
	{
	}

	public Class6160(Image image)
	{
		graphics_0 = Graphics.FromImage(image);
		textRenderingHint_0 = graphics_0.TextRenderingHint;
	}

	public void Dispose()
	{
		Close();
		GC.SuppressFinalize(this);
	}

	public void Close()
	{
		if (graphics_0 != null)
		{
			graphics_0.TextRenderingHint = textRenderingHint_0;
			graphics_0.Dispose();
			graphics_0 = null;
		}
	}

	public void method_0()
	{
		method_2();
	}

	public void method_1()
	{
		graphics_0.SmoothingMode = SmoothingMode.HighQuality;
	}

	public void method_2()
	{
		graphics_0.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
	}

	public void method_3()
	{
		graphics_0.InterpolationMode = InterpolationMode.HighQualityBicubic;
	}

	public void method_4(float scale)
	{
		graphics_0.ScaleTransform(scale, scale);
	}

	public void method_5(Class5998 color, float x, float y, float width, float height)
	{
		using Brush brush = new SolidBrush(color.method_0());
		graphics_0.FillRectangle(brush, 0f, 0f, width, height);
	}

	public Graphics method_6()
	{
		return graphics_0;
	}
}
