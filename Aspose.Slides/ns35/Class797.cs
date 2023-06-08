using System.Drawing;
using System.Drawing.Drawing2D;
using ns33;

namespace ns35;

internal class Class797 : Interface34
{
	private Bitmap bitmap_0;

	private Graphics graphics_0;

	public GraphicsUnit PageUnit
	{
		get
		{
			return graphics_0.PageUnit;
		}
		set
		{
			graphics_0.PageUnit = value;
		}
	}

	public Matrix Transform
	{
		get
		{
			return graphics_0.Transform;
		}
		set
		{
			graphics_0.Transform = value;
		}
	}

	internal Class797()
	{
		bitmap_0 = new Bitmap(1, 1);
		graphics_0 = Graphics.FromImage(bitmap_0);
	}

	internal Class797(Graphics g)
	{
		graphics_0 = g;
	}

	public RectangleF imethod_0(Region region)
	{
		return region.GetBounds(graphics_0);
	}

	public bool imethod_1(Region region)
	{
		return region.IsEmpty(graphics_0);
	}

	public float imethod_2(Font font)
	{
		return font.GetHeight(graphics_0);
	}

	public Region[] imethod_3(string text, Font font, RectangleF layoutRect, StringFormat stringFormat)
	{
		return graphics_0.MeasureCharacterRanges(text, font, layoutRect, stringFormat);
	}

	public SizeF imethod_4(string text, Font font)
	{
		SizeF result = default(SizeF);
		lock (Class1164.Lock)
		{
			for (int i = 0; i < 3; i++)
			{
				try
				{
					result = graphics_0.MeasureString(text, font);
					return result;
				}
				catch
				{
					if (i == 2)
					{
						throw;
					}
				}
			}
		}
		return result;
	}

	public SizeF imethod_5(string text, Font font, SizeF layoutArea)
	{
		SizeF result = default(SizeF);
		lock (Class1164.Lock)
		{
			for (int i = 0; i < 3; i++)
			{
				try
				{
					result = graphics_0.MeasureString(text, font, layoutArea);
					return result;
				}
				catch
				{
					if (i == 2)
					{
						throw;
					}
				}
			}
		}
		return result;
	}

	public SizeF imethod_6(string text, Font font, int width)
	{
		SizeF result = default(SizeF);
		lock (Class1164.Lock)
		{
			for (int i = 0; i < 3; i++)
			{
				try
				{
					result = graphics_0.MeasureString(text, font, width);
					return result;
				}
				catch
				{
					if (i == 2)
					{
						throw;
					}
				}
			}
		}
		return result;
	}

	public SizeF imethod_7(string text, Font font, PointF origin, StringFormat stringFormat)
	{
		SizeF result = default(SizeF);
		lock (Class1164.Lock)
		{
			for (int i = 0; i < 3; i++)
			{
				try
				{
					result = graphics_0.MeasureString(text, font, origin, stringFormat);
					return result;
				}
				catch
				{
					if (i == 2)
					{
						throw;
					}
				}
			}
		}
		return result;
	}

	public SizeF imethod_8(string text, Font font, SizeF layoutArea, StringFormat stringFormat)
	{
		SizeF result = default(SizeF);
		lock (Class1164.Lock)
		{
			for (int i = 0; i < 3; i++)
			{
				try
				{
					result = graphics_0.MeasureString(text, font, layoutArea, stringFormat);
					return result;
				}
				catch
				{
					if (i == 2)
					{
						throw;
					}
				}
			}
		}
		return result;
	}

	public SizeF imethod_9(string text, Font font, int width, StringFormat format)
	{
		SizeF result = default(SizeF);
		lock (Class1164.Lock)
		{
			for (int i = 0; i < 3; i++)
			{
				try
				{
					result = graphics_0.MeasureString(text, font, width, format);
					return result;
				}
				catch
				{
					if (i == 2)
					{
						throw;
					}
				}
			}
		}
		return result;
	}

	public SizeF imethod_10(string text, Font font, SizeF layoutArea, StringFormat stringFormat, out int charactersFitted, out int linesFilled)
	{
		SizeF result = default(SizeF);
		charactersFitted = 0;
		linesFilled = 0;
		lock (Class1164.Lock)
		{
			for (int i = 0; i < 3; i++)
			{
				try
				{
					result = graphics_0.MeasureString(text, font, layoutArea, stringFormat, out charactersFitted, out linesFilled);
					return result;
				}
				catch
				{
					if (i == 2)
					{
						throw;
					}
				}
			}
		}
		return result;
	}

	public float imethod_11(Font font)
	{
		return 0f;
	}

	public float imethod_12(Font font)
	{
		return 0f;
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
