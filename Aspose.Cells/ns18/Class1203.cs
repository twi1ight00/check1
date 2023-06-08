using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class1203 : Class1201
{
	private Bitmap bitmap_0;

	private PixelFormat pixelFormat_0;

	private bool bool_0;

	internal override Image Image => bitmap_0;

	internal override int Width => bitmap_0.Width;

	internal override int Height => bitmap_0.Height;

	private Class1203()
	{
	}

	internal Class1203(Bitmap bitmap_1)
	{
		bitmap_0 = bitmap_1;
		method_3();
		method_4();
	}

	private void method_3()
	{
		Bitmap bitmap = null;
		if (bitmap_0.PixelFormat != PixelFormat.Format32bppArgb && bitmap_0.PixelFormat != PixelFormat.Format24bppRgb && bitmap_0.PixelFormat != PixelFormat.Format32bppRgb)
		{
			bitmap = Class1404.smethod_35(bitmap_0.Width, bitmap_0.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.DrawImage(bitmap_0, 0, 0);
			bitmap_0 = bitmap;
		}
		pixelFormat_0 = bitmap_0.PixelFormat;
	}

	private void method_4()
	{
		if (!method_8())
		{
			method_5();
		}
		else
		{
			method_6();
		}
	}

	private void method_5()
	{
		int num = bitmap_0.Width * bitmap_0.Height * 3;
		byte_0 = new byte[num];
		int num2 = (method_7() ? (bitmap_0.Width * bitmap_0.Height) : 0);
		byte_1 = new byte[num2];
		color_0 = new Color[0];
		byte[] bitmapData = new byte[0];
		int stride = 0;
		Class1344.smethod_0(bitmap_0, out bitmapData, out stride);
		_ = bitmap_0.Height;
		int num3 = ((stride < 0) ? (byte_0.Length - bitmap_0.Width * 3) : 0);
		int num4 = ((stride < 0) ? (byte_1.Length - bitmap_0.Width) : 0);
		int num5 = 0;
		for (int i = 0; i < bitmap_0.Height; i++)
		{
			for (int j = 0; j < bitmap_0.Width; j++)
			{
				byte_0[num3 + 2] = bitmapData[num5++];
				byte_0[num3 + 1] = bitmapData[num5++];
				byte_0[num3] = bitmapData[num5++];
				num3 += 3;
				if (bitmap_0.PixelFormat == PixelFormat.Format32bppRgb)
				{
					num5++;
				}
				else if (method_7())
				{
					byte b = bitmapData[num5++];
					if (b < byte.MaxValue)
					{
						bool_0 = true;
					}
					byte_1[num4++] = b;
				}
			}
			if (stride < 0)
			{
				num5 -= bitmap_0.Width * 3 * 2;
			}
		}
	}

	private void method_6()
	{
		int num = (int)Math.Ceiling((float)bitmap_0.Width * (float)vmethod_0() / 8f);
		int num2 = num * bitmap_0.Height;
		byte_0 = new byte[num2];
		int num3 = (method_7() ? (bitmap_0.Width * bitmap_0.Height) : 0);
		byte_1 = new byte[num3];
		color_0 = bitmap_0.Palette.Entries;
		int num4 = 0;
		int num5 = 0;
		Class1344.smethod_0(bitmap_0, out var bitmapData, out var stride);
		_ = bitmap_0.Height;
		int num6 = stride - num;
		if (!method_7())
		{
			for (int i = 0; i < bitmap_0.Height; i++)
			{
				for (int j = 0; j < num; j++)
				{
					byte_0[num4++] = bitmapData[num5++];
				}
				num5 += num6;
			}
			return;
		}
		int num7 = 0;
		int num8 = (1 << vmethod_0()) - 1;
		for (int k = 0; k < bitmap_0.Height; k++)
		{
			for (int l = 0; l < num; l++)
			{
				byte_0[num4] = bitmapData[num5++];
				for (int num9 = 8 - vmethod_0(); num9 > 0; num9 -= vmethod_0())
				{
					int num10 = (byte_0[num4] >> num9) & num8;
					Color color = color_0[num10];
					byte_1[num7++] = color.A;
					if (color.A < byte.MaxValue)
					{
						bool_0 = true;
					}
				}
				num4++;
			}
			num5 += num6;
		}
	}

	[SpecialName]
	internal override int vmethod_0()
	{
		switch (pixelFormat_0)
		{
		case PixelFormat.Format4bppIndexed:
			return 4;
		case PixelFormat.Format1bppIndexed:
			return 1;
		default:
			throw new Exception("Unexpected pixel format.");
		case PixelFormat.Format24bppRgb:
		case PixelFormat.Format32bppRgb:
		case PixelFormat.Format8bppIndexed:
		case PixelFormat.Format32bppPArgb:
		case PixelFormat.Format32bppArgb:
			return 8;
		case PixelFormat.Format48bppRgb:
		case PixelFormat.Format64bppPArgb:
		case PixelFormat.Format64bppArgb:
			return 16;
		}
	}

	[SpecialName]
	internal override Class1439 vmethod_1()
	{
		if (!method_8())
		{
			return Class1439.smethod_1();
		}
		return Class1439.smethod_2();
	}

	[SpecialName]
	internal override bool vmethod_2()
	{
		return bool_0;
	}

	[SpecialName]
	internal override bool vmethod_3()
	{
		if (method_9() < 4096)
		{
			return !bool_0;
		}
		return false;
	}

	[SpecialName]
	internal bool method_7()
	{
		if (!Image.IsAlphaPixelFormat(pixelFormat_0))
		{
			if (method_8())
			{
				return (bitmap_0.Palette.Flags & 1) == 1;
			}
			return false;
		}
		return true;
	}

	[SpecialName]
	internal bool method_8()
	{
		return (pixelFormat_0 & PixelFormat.Indexed) == PixelFormat.Indexed;
	}

	[SpecialName]
	internal int method_9()
	{
		return bitmap_0.Width * bitmap_0.Height * Image.GetPixelFormatSize(pixelFormat_0) / 8;
	}
}
