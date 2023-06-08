using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using ns18;

namespace ns17;

internal class Class1335
{
	internal static Bitmap smethod_0(Bitmap bitmap_0)
	{
		Bitmap bitmap = null;
		if (bitmap_0.PixelFormat != PixelFormat.Format32bppArgb)
		{
			bitmap = new Bitmap(bitmap_0.Width, bitmap_0.Height, PixelFormat.Format32bppArgb);
			bitmap.SetResolution(bitmap_0.HorizontalResolution, bitmap_0.VerticalResolution);
			using Graphics graphics = Graphics.FromImage(bitmap);
			graphics.DrawImageUnscaled(bitmap_0, 0, 0);
		}
		else
		{
			bitmap = bitmap_0;
		}
		int stride = 0;
		Class1344.smethod_0(bitmap, out var bitmapData, out stride);
		Bitmap bitmap2 = new Bitmap((int)((float)bitmap.Width + 1.99f) / 2 * 2, (int)((float)bitmap.Height + 1.99f) / 2 * 2, PixelFormat.Format1bppIndexed);
		bitmap2.SetResolution(bitmap_0.HorizontalResolution, bitmap_0.VerticalResolution);
		BitmapData bitmapData2 = bitmap2.LockBits(new Rectangle(0, 0, bitmap2.Width, bitmap2.Height), ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);
		int num = bitmapData2.Stride * bitmapData2.Height;
		byte[] array = new byte[num];
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		byte b = 0;
		int num5 = 128;
		int height = bitmap.Height;
		int width = bitmap.Width;
		int num6 = 500;
		int num7 = 0;
		float[,] array2 = new float[(width + 3) / 4, (height + 3) / 4];
		for (int i = 0; i < height; i++)
		{
			num2 = i * stride;
			for (int j = 0; j < width; j++)
			{
				num7 = bitmapData[num2 + 1] + bitmapData[num2 + 2] + bitmapData[num2 + 3];
				array2[j / 4, i / 4] += num7;
				num2 += 4;
			}
		}
		for (int k = 0; k < (height + 3) / 4; k++)
		{
			for (int l = 0; l < (width + 3) / 4; l++)
			{
				int num8 = ((k > height / 4 * 4) ? (height % 4) : 4);
				int num9 = ((l > width / 4 * 4) ? (width % 4) : 4);
				num6 = (int)array2[l, k] / (num8 * num9);
				if (num6 == 0)
				{
					num6 = 1;
				}
				if (num6 == 765)
				{
					num6 = 764;
				}
				array2[l, k] = num6;
			}
		}
		for (int m = 0; m < height; m++)
		{
			num2 = m * stride;
			num3 = m * bitmapData2.Stride;
			b = 0;
			num5 = 128;
			for (int n = 0; n < width; n++)
			{
				num4 = bitmapData[num2 + 1] + bitmapData[num2 + 2] + bitmapData[num2 + 3];
				num6 = (int)array2[n / 4, m / 4];
				if (num4 > num6)
				{
					b = (byte)(b + (byte)num5);
				}
				if (num5 == 1)
				{
					array[num3] = b;
					num3++;
					b = 0;
					num5 = 128;
				}
				else
				{
					num5 >>= 1;
				}
				num2 += 4;
			}
			if (num5 != 128)
			{
				array[num3] = b;
			}
		}
		Marshal.Copy(array, 0, bitmapData2.Scan0, num);
		bitmap2.UnlockBits(bitmapData2);
		if (bitmap != bitmap_0)
		{
			bitmap.Dispose();
		}
		return bitmap2;
	}
}
