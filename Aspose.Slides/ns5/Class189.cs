using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ns5;

internal static class Class189
{
	public static Bitmap smethod_0(Bitmap bitmap, int radius)
	{
		Bitmap bitmap2 = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format32bppArgb);
		smethod_1(radius, out var kernel, out var kernelSum, out var multiplicationTable);
		Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
		BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);
		int num = bitmapData.Width * bitmapData.Height;
		int[] array = new int[num];
		int[] array2 = new int[num];
		int[] array3 = new int[num];
		int[] array4 = new int[num];
		int[] array5 = new int[num];
		int[] array6 = new int[num];
		int[] array7 = new int[num];
		int[] array8 = new int[num];
		smethod_2(array, array2, array3, array4, bitmapData);
		bitmap.UnlockBits(bitmapData);
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i < bitmapData.Height; i++)
		{
			for (int j = 0; j < bitmapData.Width; j++)
			{
				int num4 = 0;
				int num5 = 0;
				int num6 = 0;
				int num7 = 0;
				int num8 = num3 - radius;
				for (int k = 0; k < kernel.Length; k++)
				{
					if (num8 < num2)
					{
						num7 += multiplicationTable[k, array[num2]];
						num6 += multiplicationTable[k, array2[num2]];
						num5 += multiplicationTable[k, array3[num2]];
						num4 += multiplicationTable[k, array4[num2]];
					}
					else if (num8 > num2 + bitmapData.Width - 1)
					{
						int num9 = num2 + bitmapData.Width - 1;
						num7 += multiplicationTable[k, array[num9]];
						num6 += multiplicationTable[k, array2[num9]];
						num5 += multiplicationTable[k, array3[num9]];
						num4 += multiplicationTable[k, array4[num9]];
					}
					else
					{
						num7 += multiplicationTable[k, array[num8]];
						num6 += multiplicationTable[k, array2[num8]];
						num5 += multiplicationTable[k, array3[num8]];
						num4 += multiplicationTable[k, array4[num8]];
					}
					num8++;
				}
				array5[num3] = num7 / kernelSum;
				array6[num3] = num6 / kernelSum;
				array7[num3] = num5 / kernelSum;
				array8[num3] = num4 / kernelSum;
				num3++;
			}
			num2 += bitmapData.Width;
		}
		BitmapData bitmapData2 = bitmap2.LockBits(rect, ImageLockMode.WriteOnly, bitmap.PixelFormat);
		IntPtr scan = bitmapData2.Scan0;
		int num10 = 0;
		for (int l = 0; l < bitmapData.Height; l++)
		{
			int num11 = l - radius;
			num2 = num11 * bitmapData.Width;
			for (int m = 0; m < bitmapData.Width; m++)
			{
				int num4 = 0;
				int num5 = 0;
				int num6 = 0;
				int num7 = 0;
				int num8 = num2 + m;
				int num12 = num11;
				for (int n = 0; n < kernel.Length; n++)
				{
					if (num12 < 0)
					{
						num7 += multiplicationTable[n, array5[m]];
						num6 += multiplicationTable[n, array6[m]];
						num5 += multiplicationTable[n, array7[m]];
						num4 += multiplicationTable[n, array8[m]];
					}
					else if (num12 > bitmapData.Height - 1)
					{
						int num13 = num - (bitmapData.Width - m);
						num7 += multiplicationTable[n, array5[num13]];
						num6 += multiplicationTable[n, array6[num13]];
						num5 += multiplicationTable[n, array7[num13]];
						num4 += multiplicationTable[n, array8[num13]];
					}
					else
					{
						num7 += multiplicationTable[n, array5[num8]];
						num6 += multiplicationTable[n, array6[num8]];
						num5 += multiplicationTable[n, array7[num8]];
						num4 += multiplicationTable[n, array8[num8]];
					}
					num8 += bitmapData.Width;
					num12++;
				}
				Marshal.WriteByte(scan, num10++, (byte)(num7 / kernelSum));
				Marshal.WriteByte(scan, num10++, (byte)(num6 / kernelSum));
				Marshal.WriteByte(scan, num10++, (byte)(num5 / kernelSum));
				Marshal.WriteByte(scan, num10++, (byte)(num4 / kernelSum));
			}
		}
		bitmap2.UnlockBits(bitmapData2);
		return bitmap2;
	}

	internal static void smethod_1(int radius, out int[] kernel, out int kernelSum, out int[,] multiplicationTable)
	{
		int num = radius * 2 + 1;
		kernel = new int[num];
		kernelSum = 0;
		multiplicationTable = new int[num, 256];
		for (int i = 1; i <= radius; i++)
		{
			int num2 = radius - i;
			int num3 = radius + i;
			kernel[num3] = (kernel[num2] = (num2 + 1) * (num2 + 1));
			kernelSum += kernel[num3] + kernel[num2];
			for (int j = 0; j < 256; j++)
			{
				multiplicationTable[num3, j] = (multiplicationTable[num2, j] = kernel[num3] * j);
			}
		}
		kernel[radius] = (radius + 1) * (radius + 1);
		kernelSum += kernel[radius];
		for (int k = 0; k < 256; k++)
		{
			multiplicationTable[radius, k] = kernel[radius] * k;
		}
	}

	internal static void smethod_2(int[] matrixB, int[] matrixG, int[] matrixR, int[] matrixA, BitmapData sourceRaw)
	{
		IntPtr scan = sourceRaw.Scan0;
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < sourceRaw.Height; i++)
		{
			for (int j = 0; j < sourceRaw.Width; j++)
			{
				matrixB[num] = Marshal.ReadByte(scan, num2++);
				matrixG[num] = Marshal.ReadByte(scan, num2++);
				matrixR[num] = Marshal.ReadByte(scan, num2++);
				matrixA[num] = Marshal.ReadByte(scan, num2++);
				num++;
			}
		}
	}
}
