using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using ns33;

namespace ns5;

internal class Class190
{
	[SecuritySafeCritical]
	private abstract class Class191
	{
		internal static Bitmap smethod_0(Bitmap bmp, PixelFormat target)
		{
			if (bmp.PixelFormat == target)
			{
				return bmp;
			}
			Bitmap bitmap = new Bitmap(bmp.Width, bmp.Height, target);
			bitmap.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.Clear(Color.Red);
			graphics.CompositingMode = CompositingMode.SourceCopy;
			graphics.DrawImageUnscaled(bmp, 0, 0);
			graphics.Dispose();
			return bitmap;
		}

		[SecuritySafeCritical]
		internal abstract Class190 vmethod_0(Bitmap bitmap);

		[SecuritySafeCritical]
		internal abstract Bitmap vmethod_1(Class190 tcb);
	}

	[SecuritySafeCritical]
	private class Class192 : Class191
	{
		[SecuritySafeCritical]
		internal override Class190 vmethod_0(Bitmap bitmap)
		{
			int width = bitmap.Width;
			int height = bitmap.Height;
			Class190 @class = new Class190(width, height);
			bool flag;
			if (!(flag = Image.IsAlphaPixelFormat(bitmap.PixelFormat)))
			{
				@class.method_2();
			}
			int num = 0;
			if (flag)
			{
				for (int i = 0; i < height; i++)
				{
					for (int j = 0; j < width; j++)
					{
						Color pixel = bitmap.GetPixel(j, i);
						@class.int_2[num++] = (pixel.A << 24) + (pixel.R << 16) + (pixel.G << 8) + pixel.B;
					}
				}
			}
			else
			{
				for (int k = 0; k < height; k++)
				{
					for (int l = 0; l < width; l++)
					{
						Color pixel2 = bitmap.GetPixel(l, k);
						@class.int_2[num++] = -16777216 + (pixel2.R << 16) + (pixel2.G << 8) + pixel2.B;
					}
				}
			}
			return @class;
		}

		[SecuritySafeCritical]
		internal override Bitmap vmethod_1(Class190 tcb)
		{
			int int_ = tcb.int_0;
			int int_2 = tcb.int_1;
			tcb.method_0();
			Bitmap bitmap = new Bitmap(int_, int_2, tcb.Transparent ? PixelFormat.Format32bppArgb : PixelFormat.Format32bppRgb);
			int num = 0;
			if (tcb.Transparent)
			{
				for (int i = 0; i < int_2; i++)
				{
					for (int j = 0; j < int_; j++)
					{
						int num2 = tcb.int_2[num++];
						bitmap.SetPixel(j, i, Color.FromArgb((num2 >> 24) & 0xFF, (num2 >> 16) & 0xFF, (num2 >> 8) & 0xFF, num2 & 0xFF));
					}
				}
			}
			else
			{
				for (int k = 0; k < int_2; k++)
				{
					for (int l = 0; l < int_; l++)
					{
						int num3 = tcb.int_2[num++];
						bitmap.SetPixel(l, k, Color.FromArgb((num3 >> 16) & 0xFF, (num3 >> 8) & 0xFF, num3 & 0xFF));
					}
				}
			}
			return bitmap;
		}
	}

	[SecuritySafeCritical]
	private class Class193 : Class191
	{
		private struct Struct13
		{
			public int int_0;

			public int int_1;

			public int int_2;

			public int int_3;

			public byte[] byte_0;
		}

		private static readonly Class192 class192_0 = new Class192();

		private void method_0(ref Struct13 InfoStruct, int bytePerPixel)
		{
			InfoStruct.int_0 = BitConverter.ToInt32(InfoStruct.byte_0, 18);
			InfoStruct.int_1 = BitConverter.ToInt32(InfoStruct.byte_0, 22);
			InfoStruct.int_2 = InfoStruct.int_0 * bytePerPixel;
			if (InfoStruct.int_2 % 4 > 0)
			{
				InfoStruct.int_2 += 4 - InfoStruct.int_2 % 4;
			}
			InfoStruct.int_3 = BitConverter.ToInt32(InfoStruct.byte_0, 10) + (InfoStruct.int_1 - 1) * InfoStruct.int_2;
		}

		[SecuritySafeCritical]
		internal override Class190 vmethod_0(Bitmap bitmap)
		{
			PixelFormat pixelFormat = (Image.IsAlphaPixelFormat(bitmap.PixelFormat) ? PixelFormat.Format32bppArgb : PixelFormat.Format24bppRgb);
			if (bitmap.PixelFormat != pixelFormat)
			{
				bitmap = Class191.smethod_0(bitmap, pixelFormat);
			}
			if (bitmap.PixelFormat == PixelFormat.Format32bppArgb)
			{
				Class190 @class = new Class190(bitmap.Width, bitmap.Height);
				Struct13 InfoStruct = default(Struct13);
				using (MemoryStream memoryStream = new MemoryStream())
				{
					bitmap.Save(memoryStream, ImageFormat.Bmp);
					InfoStruct.byte_0 = memoryStream.ToArray();
					method_0(ref InfoStruct, 4);
					memoryStream.Close();
				}
				for (int i = 0; i < bitmap.Height; i++)
				{
					int num = InfoStruct.int_3 - InfoStruct.int_2 * i;
					int num2 = (i + 1) * @class.int_0;
					int num3 = i * @class.int_0;
					while (num3 < num2)
					{
						@class.int_2[num3] = BitConverter.ToInt32(InfoStruct.byte_0, num);
						num3++;
						num += 4;
					}
				}
				return @class;
			}
			Class190 class2 = new Class190(bitmap.Width, bitmap.Height);
			class2.method_2();
			Struct13 InfoStruct2 = default(Struct13);
			using (MemoryStream memoryStream2 = new MemoryStream())
			{
				bitmap.Save(memoryStream2, ImageFormat.Bmp);
				InfoStruct2.byte_0 = memoryStream2.ToArray();
				method_0(ref InfoStruct2, 3);
				memoryStream2.Close();
			}
			for (int j = 0; j < bitmap.Height; j++)
			{
				int num4 = InfoStruct2.int_3 - InfoStruct2.int_2 * j;
				int num5 = (j + 1) * class2.int_0;
				int num6 = j * class2.int_0;
				while (num6 < num5)
				{
					class2.int_2[num6] = BitConverter.ToInt32(InfoStruct2.byte_0, num4) | -16777216;
					num6++;
					num4 += 3;
				}
			}
			return class2;
		}

		[SecuritySafeCritical]
		internal override Bitmap vmethod_1(Class190 tcb)
		{
			return class192_0.vmethod_1(tcb);
		}
	}

	[SecuritySafeCritical]
	private class Class194 : Class191
	{
		[SecuritySafeCritical]
		internal override Class190 vmethod_0(Bitmap bitmap)
		{
			PixelFormat pixelFormat = (Image.IsAlphaPixelFormat(bitmap.PixelFormat) ? PixelFormat.Format32bppArgb : PixelFormat.Format32bppRgb);
			if (bitmap.PixelFormat != pixelFormat)
			{
				bitmap = Class191.smethod_0(bitmap, pixelFormat);
			}
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
			Class190 @class = new Class190(bitmap.Width, bitmap.Height);
			int num = Image.GetPixelFormatSize(bitmap.PixelFormat) / 8;
			int num2 = bitmap.Width * num;
			int num3 = bitmapData.Stride - num2;
			int num4 = bitmapData.Stride * bitmapData.Height;
			int[] array = ((num3 != 0) ? new int[num4 / 4] : @class.int_2);
			Marshal.Copy(bitmapData.Scan0, array, 0, num4 / 4);
			bitmap.UnlockBits(bitmapData);
			if (!Image.IsAlphaPixelFormat(bitmap.PixelFormat))
			{
				@class.method_2();
				if (num3 > 0)
				{
					int num5 = 0;
					int num6 = 0;
					for (int i = 0; i < @class.int_1; i++)
					{
						for (int j = 0; j < @class.int_0; j++)
						{
							@class.int_2[num6++] = array[num5++] | -16777216;
						}
						num5 += num3 / 4;
					}
				}
				else
				{
					for (int k = 0; k < @class.int_2.Length; k++)
					{
						@class.int_2[k] |= -16777216;
					}
				}
			}
			else if (num3 > 0)
			{
				int num7 = 0;
				int num8 = 0;
				for (int l = 0; l < @class.int_1; l++)
				{
					for (int m = 0; m < @class.int_0; m++)
					{
						@class.int_2[num8++] = array[num7++];
					}
					num7 += num3 / 4;
				}
			}
			return @class;
		}

		[SecuritySafeCritical]
		internal override Bitmap vmethod_1(Class190 tcb)
		{
			int int_ = tcb.int_0;
			int int_2 = tcb.int_1;
			tcb.method_0();
			Bitmap bitmap = new Bitmap(int_, int_2, tcb.Transparent ? PixelFormat.Format32bppArgb : PixelFormat.Format32bppRgb);
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);
			Marshal.Copy(tcb.int_2, 0, bitmapData.Scan0, tcb.int_2.Length);
			bitmap.UnlockBits(bitmapData);
			return bitmap;
		}
	}

	private readonly int int_0;

	private readonly int int_1;

	private float float_0;

	private float float_1;

	private readonly int[] int_2;

	private int int_3 = -1;

	private static readonly Class191 class191_0;

	public bool Transparent => int_3 != 0;

	public int Width => int_0;

	public int Height => int_1;

	public float HorizontalResolution
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	public float VerticalResolution
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	public int[] Bits => int_2;

	public void method_0()
	{
		if (int_3 >= 0)
		{
			return;
		}
		int num = 0;
		while (true)
		{
			if (num < int_2.Length)
			{
				if ((int_2[num] & 0xFF000000L) != 4278190080L)
				{
					break;
				}
				num++;
				continue;
			}
			int_3 = 0;
			return;
		}
		int_3 = 1;
	}

	public void method_1()
	{
		int_3 = 1;
	}

	public void method_2()
	{
		int_3 = 0;
	}

	public void method_3()
	{
		int_3 = -1;
	}

	public Class190(int width, int height)
	{
		int_0 = width;
		int_1 = height;
		int_2 = new int[int_0 * int_1];
	}

	static Class190()
	{
		try
		{
			Class194 @class = new Class194();
			Bitmap bitmap = new Bitmap(16, 16, PixelFormat.Format32bppArgb);
			@class.vmethod_0(bitmap);
			class191_0 = @class;
		}
		catch (MethodAccessException ex)
		{
			Class1165.smethod_28(ex);
			class191_0 = new Class193();
		}
	}

	public static Class190 smethod_0(Bitmap bitmap)
	{
		Class190 @class = class191_0.vmethod_0(bitmap);
		@class.float_0 = bitmap.HorizontalResolution;
		@class.float_1 = bitmap.VerticalResolution;
		return @class;
	}

	public Bitmap method_4()
	{
		Bitmap bitmap = class191_0.vmethod_1(this);
		if (float_0 != 0f && float_1 != 0f)
		{
			bitmap.SetResolution(float_0, float_1);
		}
		return bitmap;
	}
}
