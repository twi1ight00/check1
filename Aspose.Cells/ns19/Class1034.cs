using System.Drawing;

namespace ns19;

internal class Class1034 : Interface43
{
	private Class1032 class1032_0;

	private Graphics graphics_0;

	private Bitmap bitmap_0;

	internal Class1034(Class1032 class1032_1)
	{
		class1032_0 = class1032_1;
		bitmap_0 = new Bitmap(class1032_1.Width, class1032_1.Height);
		graphics_0 = Graphics.FromImage(bitmap_0);
	}

	public RectangleF imethod_0(Region region_0)
	{
		graphics_0.Transform = class1032_0.vmethod_8();
		graphics_0.PageUnit = class1032_0.imethod_53();
		graphics_0.PageScale = class1032_0.vmethod_7();
		return region_0.GetBounds(graphics_0);
	}

	public float imethod_2(Font font_0)
	{
		return font_0.GetHeight(graphics_0);
	}

	public bool imethod_1(Region region_0)
	{
		return region_0.IsEmpty(graphics_0);
	}

	public SizeF imethod_3(string string_0, Font font_0)
	{
		graphics_0.PageUnit = class1032_0.imethod_53();
		graphics_0.PageScale = class1032_0.vmethod_7();
		return graphics_0.MeasureString(string_0, font_0);
	}

	public SizeF imethod_4(string string_0, Font font_0, SizeF sizeF_0)
	{
		graphics_0.PageUnit = class1032_0.imethod_53();
		graphics_0.PageScale = class1032_0.vmethod_7();
		return graphics_0.MeasureString(string_0, font_0, sizeF_0);
	}

	public SizeF imethod_5(string string_0, Font font_0, PointF pointF_0, StringFormat stringFormat_0)
	{
		graphics_0.PageUnit = class1032_0.imethod_53();
		graphics_0.PageScale = class1032_0.vmethod_7();
		return graphics_0.MeasureString(string_0, font_0, pointF_0, stringFormat_0);
	}

	public SizeF imethod_6(string string_0, Font font_0, SizeF sizeF_0, StringFormat stringFormat_0)
	{
		graphics_0.PageUnit = class1032_0.imethod_53();
		graphics_0.PageScale = class1032_0.vmethod_7();
		return graphics_0.MeasureString(string_0, font_0, sizeF_0, stringFormat_0);
	}

	public SizeF imethod_7(string string_0, Font font_0, int int_0, StringFormat stringFormat_0)
	{
		graphics_0.PageUnit = class1032_0.imethod_53();
		graphics_0.PageScale = class1032_0.vmethod_7();
		return graphics_0.MeasureString(string_0, font_0, int_0, stringFormat_0);
	}

	public void Dispose()
	{
		graphics_0.Dispose();
		bitmap_0.Dispose();
	}
}
