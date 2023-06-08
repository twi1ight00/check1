using System.Drawing;

namespace ns19;

internal class Class1042 : Interface43
{
	private Bitmap bitmap_0;

	private Graphics graphics_0;

	internal Class1042()
	{
		bitmap_0 = new Bitmap(1, 1);
		graphics_0 = Graphics.FromImage(bitmap_0);
	}

	internal Class1042(Graphics graphics_1)
	{
		graphics_0 = graphics_1;
	}

	public RectangleF imethod_0(Region region_0)
	{
		return region_0.GetBounds(graphics_0);
	}

	public bool imethod_1(Region region_0)
	{
		return region_0.IsEmpty(graphics_0);
	}

	public float imethod_2(Font font_0)
	{
		return font_0.GetHeight(graphics_0);
	}

	public SizeF imethod_3(string string_0, Font font_0)
	{
		return graphics_0.MeasureString(string_0, font_0);
	}

	public SizeF imethod_4(string string_0, Font font_0, SizeF sizeF_0)
	{
		return graphics_0.MeasureString(string_0, font_0, sizeF_0);
	}

	public SizeF imethod_5(string string_0, Font font_0, PointF pointF_0, StringFormat stringFormat_0)
	{
		return graphics_0.MeasureString(string_0, font_0, pointF_0, stringFormat_0);
	}

	public SizeF imethod_6(string string_0, Font font_0, SizeF sizeF_0, StringFormat stringFormat_0)
	{
		return graphics_0.MeasureString(string_0, font_0, sizeF_0, stringFormat_0);
	}

	public SizeF imethod_7(string string_0, Font font_0, int int_0, StringFormat stringFormat_0)
	{
		return graphics_0.MeasureString(string_0, font_0, int_0, stringFormat_0);
	}

	public void Dispose()
	{
		if (graphics_0 != null)
		{
			graphics_0.Dispose();
			graphics_0 = null;
		}
		if (bitmap_0 != null)
		{
			bitmap_0.Dispose();
			bitmap_0 = null;
		}
	}
}
