using System;
using System.Drawing;

namespace ns316;

internal class Class7147
{
	private int int_0;

	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	internal byte[] byte_0;

	public void method_0(Bitmap source, Bitmap input, Bitmap output)
	{
		int[] array = null;
		int[] array2 = null;
		int x = 0;
		int width = output.Width;
		int num = 0 + output.Height;
		int num2 = 65793;
		int num3 = 8388608;
		for (int i = 0; i < num; i++)
		{
			array = method_10(source, x, i, width);
			array2 = method_10(input, x, i, width);
			int num4 = 0;
			int num5 = width * 4;
			while (num4 < num5)
			{
				int num6 = 255 - array2[num4 + 3];
				int num7 = 255 - array[num4 + 3];
				array2[num4] = smethod_0((array[num4] * num6 + array2[num4] * num7 + array[num4] * array2[num4]) * num2 + num3, 24);
				num4++;
				array2[num4] = smethod_0((array[num4] * num6 + array2[num4] * num7 + array[num4] * array2[num4]) * num2 + num3, 24);
				num4++;
				array2[num4] = smethod_0((array[num4] * num6 + array2[num4] * num7 + array[num4] * array2[num4]) * num2 + num3, 24);
				num4++;
				array2[num4] = array[num4] + array2[num4] - smethod_0(array2[num4] * array[num4] * num2 + num3, 24);
				num4++;
			}
			method_11(ref output, x, i, width, array2);
		}
	}

	public void method_1(int width, int height, int[] source, int adjust, int sp, int[] output, int outOffset, int outputSp, int[] outPixels, int outPixelsOffset, int destSp)
	{
		int num = 65793;
		int num2 = 8388608;
		for (int i = 0; i < height; i++)
		{
			int num3 = destSp + width;
			while (destSp < num3)
			{
				int num4 = source[sp++];
				int num5 = output[outputSp++];
				int num6 = smethod_0(num4, 24);
				int num7 = smethod_0(num5, 24);
				int num8 = (num4 >> 16) & 0xFF;
				int num9 = (num5 >> 16) & 0xFF;
				int num10 = (num4 >> 8) & 0xFF;
				int num11 = (num5 >> 8) & 0xFF;
				int num12 = num4 & 0xFF;
				int num13 = num5 & 0xFF;
				int num14 = 255 - num7;
				int num15 = 255 - num6;
				outPixels[destSp++] = smethod_1(((num8 * num14 + num9 * num15 + num8 * num9) * num + num2) & 0xFF000000L, 8) | smethod_1(((num10 * num14 + num11 * num15 + num10 * num11) * num + num2) & 0xFF000000L, 16) | smethod_0((num12 * num14 + num13 * num15 + num12 * num13) * num + num2, 24) | (num6 + num7 - smethod_0(num6 * num7 * num + num2, 24) << 24);
			}
			sp += adjust;
			outputSp += outOffset;
			destSp += outPixelsOffset;
		}
	}

	public void method_2(Bitmap input, Bitmap image, Bitmap output)
	{
		int[] array = null;
		int[] array2 = null;
		int x = 0;
		int width = output.Width;
		int num = 0 + output.Height;
		int num2 = 65793;
		int num3 = 8388608;
		for (int i = 0; i < num; i++)
		{
			array = method_10(input, x, i, width);
			array2 = method_10(image, x, i, width);
			int num4 = 0;
			int num5 = width * 4;
			while (num4 < num5)
			{
				int num6 = array[num4];
				int num7 = array2[num4];
				array2[num4] = num6 + num7 - smethod_0(num7 * num6 * num2 + num3, 24);
				num4++;
				num6 = array[num4];
				num7 = array2[num4];
				array2[num4] = num6 + num7 - smethod_0(num7 * num6 * num2 + num3, 24);
				num4++;
				num6 = array[num4];
				num7 = array2[num4];
				array2[num4] = num6 + num7 - smethod_0(num7 * num6 * num2 + num3, 24);
				num4++;
				num6 = array[num4];
				num7 = array2[num4];
				array2[num4] = num6 + num7 - smethod_0(num7 * num6 * num2 + num3, 24);
				num4++;
			}
			method_11(ref output, x, i, width, array2);
		}
	}

	public void method_3(int width, int height, int[] input, int inputOffset, int inputSp, int[] output, int outputOffset, int outputSp, int[] outputPixels, int outputPixelsOffset, int outputPixelsSp)
	{
		int num = 65793;
		int num2 = 8388608;
		for (int i = 0; i < height; i++)
		{
			int num3 = outputPixelsSp + width;
			while (outputPixelsSp < num3)
			{
				int num4 = input[inputSp++];
				int num5 = output[outputSp++];
				int num6 = smethod_0(num4, 24);
				int num7 = smethod_0(num5, 24);
				int num8 = (num4 >> 16) & 0xFF;
				int num9 = (num5 >> 16) & 0xFF;
				int num10 = (num4 >> 8) & 0xFF;
				int num11 = (num5 >> 8) & 0xFF;
				int num12 = num4 & 0xFF;
				int num13 = num5 & 0xFF;
				outputPixels[outputPixelsSp++] = (num8 + num9 - smethod_0(num8 * num9 * num + num2, 24) << 16) | (num10 + num11 - smethod_0(num10 * num11 * num + num2, 24) << 8) | (num12 + num13 - smethod_0(num12 * num13 * num + num2, 24)) | (num6 + num7 - smethod_0(num6 * num7 * num + num2, 24) << 24);
			}
			inputSp += inputOffset;
			outputSp += outputOffset;
			outputPixelsSp += outputPixelsOffset;
		}
	}

	public void method_4(Bitmap input, Bitmap image, Bitmap output)
	{
		int[] array = null;
		int[] array2 = null;
		int x = 0;
		int width = output.Width;
		int num = 0 + output.Height;
		int num2 = 65793;
		int num3 = 8388608;
		for (int i = 0; i < num; i++)
		{
			array = method_10(input, x, i, width);
			array2 = method_10(image, x, i, width);
			int num4 = 0;
			int num5 = width * 4;
			while (num4 < num5)
			{
				int num6 = 255 - array2[num4 + 3];
				int num7 = 255 - array[num4 + 3];
				int num8 = smethod_0(num6 * array[num4] * num2 + num3, 24) + array2[num4];
				int num9 = smethod_0(num7 * array2[num4] * num2 + num3, 24) + array[num4];
				if (num8 > num9)
				{
					array2[num4] = num9;
				}
				else
				{
					array2[num4] = num8;
				}
				num4++;
				num8 = smethod_0(num6 * array[num4] * num2 + num3, 24) + array2[num4];
				num9 = smethod_0(num7 * array2[num4] * num2 + num3, 24) + array[num4];
				if (num8 > num9)
				{
					array2[num4] = num9;
				}
				else
				{
					array2[num4] = num8;
				}
				num4++;
				num8 = smethod_0(num6 * array[num4] * num2 + num3, 24) + array2[num4];
				num9 = smethod_0(num7 * array2[num4] * num2 + num3, 24) + array[num4];
				if (num8 > num9)
				{
					array2[num4] = num9;
				}
				else
				{
					array2[num4] = num8;
				}
				num4++;
				array2[num4] = array[num4] + array2[num4] - smethod_0(array2[num4] * array[num4] * num2 + num3, 24);
				num4++;
			}
			method_11(ref output, x, i, width, array2);
		}
	}

	public void method_5(int width, int height, int[] source, int offset, int sourcePixels, int[] output, int outputOffset, int outputSp, int[] outputPixels, int ouputPixelsOffset, int ouputPixelsSp)
	{
		int num = 65793;
		int num2 = 8388608;
		for (int i = 0; i < height; i++)
		{
			int num3 = ouputPixelsSp + width;
			while (ouputPixelsSp < num3)
			{
				int num4 = source[sourcePixels++];
				int num5 = output[outputSp++];
				int num6 = smethod_0(num4, 24);
				int num7 = smethod_0(num5, 24);
				int num8 = (255 - num7) * num;
				int num9 = (255 - num6) * num;
				int num10 = num6 + num7 - smethod_0(num6 * num7 * num + num2, 24);
				num6 = (num4 >> 16) & 0xFF;
				num7 = (num5 >> 16) & 0xFF;
				int num11 = smethod_0(num8 * num6 + num2, 24) + num7;
				int num12 = smethod_0(num9 * num7 + num2, 24) + num6;
				if (num11 > num12)
				{
					num11 = num12;
				}
				num6 = (num4 >> 8) & 0xFF;
				num7 = (num5 >> 8) & 0xFF;
				int num13 = smethod_0(num8 * num6 + num2, 24) + num7;
				num12 = smethod_0(num9 * num7 + num2, 24) + num6;
				if (num13 > num12)
				{
					num13 = num12;
				}
				num6 = num4 & 0xFF;
				num7 = num5 & 0xFF;
				int num14 = smethod_0(num8 * num6 + num2, 24) + num7;
				num12 = smethod_0(num9 * num7 + num2, 24) + num6;
				if (num14 > num12)
				{
					num14 = num12;
				}
				num10 &= 0xFF;
				num11 &= 0xFF;
				num13 &= 0xFF;
				num14 &= 0xFF;
				outputPixels[ouputPixelsSp++] = (num10 << 24) | (num11 << 16) | (num13 << 8) | num14;
			}
			sourcePixels += offset;
			outputSp += outputOffset;
			ouputPixelsSp += ouputPixelsOffset;
		}
	}

	public void method_6(Bitmap source, Bitmap image, Bitmap output)
	{
		int[] array = null;
		int[] array2 = null;
		int x = 0;
		int width = output.Width;
		int num = 0 + output.Height;
		int num2 = 65793;
		int num3 = 8388608;
		for (int i = 0; i < num; i++)
		{
			array = method_10(source, x, i, width);
			array2 = method_10(image, x, i, width);
			int num4 = 0;
			int num5 = width * 4;
			while (num4 < num5)
			{
				int num6 = 255 - array2[num4 + 3];
				int num7 = 255 - array[num4 + 3];
				int num8 = smethod_0(num6 * array[num4] * num2 + num3, 24) + array2[num4];
				int num9 = smethod_0(num7 * array2[num4] * num2 + num3, 24) + array[num4];
				if (num8 > num9)
				{
					array2[num4] = num8;
				}
				else
				{
					array2[num4] = num9;
				}
				num4++;
				num8 = smethod_0(num6 * array[num4] * num2 + num3, 24) + array2[num4];
				num9 = smethod_0(num7 * array2[num4] * num2 + num3, 24) + array[num4];
				if (num8 > num9)
				{
					array2[num4] = num8;
				}
				else
				{
					array2[num4] = num9;
				}
				num4++;
				num8 = smethod_0(num6 * array[num4] * num2 + num3, 24) + array2[num4];
				num9 = smethod_0(num7 * array2[num4] * num2 + num3, 24) + array[num4];
				if (num8 > num9)
				{
					array2[num4] = num8;
				}
				else
				{
					array2[num4] = num9;
				}
				num4++;
				array2[num4] = array[num4] + array2[num4] - smethod_0(array2[num4] * array[num4] * num2 + num3, 24);
				num4++;
			}
			method_11(ref output, x, i, width, array2);
		}
	}

	public void method_7(int width, int height, int[] source, int offset, int sourceSp, int[] output, int outputOffset, int outputSp, int[] outputPixels, int outputPixelsOffset, int outputPixelsSp)
	{
		int num = 65793;
		int num2 = 8388608;
		for (int i = 0; i < height; i++)
		{
			int num3 = outputPixelsSp + width;
			while (outputPixelsSp < num3)
			{
				int num4 = source[sourceSp++];
				int num5 = output[outputSp++];
				int num6 = smethod_0(num4, 24);
				int num7 = smethod_0(num5, 24);
				int num8 = (255 - num7) * num;
				int num9 = (255 - num6) * num;
				int num10 = num6 + num7 - smethod_0(num6 * num7 * num + num2, 24);
				num6 = (num4 >> 16) & 0xFF;
				num7 = (num5 >> 16) & 0xFF;
				int num11 = smethod_0(num8 * num6 + num2, 24) + num7;
				int num12 = smethod_0(num9 * num7 + num2, 24) + num6;
				if (num11 < num12)
				{
					num11 = num12;
				}
				num6 = (num4 >> 8) & 0xFF;
				num7 = (num5 >> 8) & 0xFF;
				int num13 = smethod_0(num8 * num6 + num2, 24) + num7;
				num12 = smethod_0(num9 * num7 + num2, 24) + num6;
				if (num13 < num12)
				{
					num13 = num12;
				}
				num6 = num4 & 0xFF;
				num7 = num5 & 0xFF;
				int num14 = smethod_0(num8 * num6 + num2, 24) + num7;
				num12 = smethod_0(num9 * num7 + num2, 24) + num6;
				if (num14 < num12)
				{
					num14 = num12;
				}
				num10 &= 0xFF;
				num11 &= 0xFF;
				num13 &= 0xFF;
				num14 &= 0xFF;
				outputPixels[outputPixelsSp++] = (num10 << 24) | (num11 << 16) | (num13 << 8) | num14;
			}
			sourceSp += offset;
			outputSp += outputOffset;
			outputPixelsSp += outputPixelsOffset;
		}
	}

	public int method_8()
	{
		return int_0;
	}

	public float[] method_9()
	{
		if (int_0 != 6)
		{
			return null;
		}
		return new float[4] { float_0, float_1, float_2, float_3 };
	}

	private static int smethod_0(int value, int shift)
	{
		return Convert.ToInt32(Convert.ToUInt32(value) >> shift);
	}

	private static int smethod_1(long value, int shift)
	{
		return Convert.ToInt32(Convert.ToUInt32(value) >> shift);
	}

	private int[] method_10(Bitmap src, int x, int y, int width)
	{
		int[] array = new int[width * 4];
		for (int i = 0; i < width * 4; i += 4)
		{
			Color pixel = src.GetPixel(x + i / 4, y);
			array[i] = pixel.A;
			array[i] = pixel.R;
			array[i] = pixel.G;
			array[i] = pixel.B;
		}
		return array;
	}

	private void method_11(ref Bitmap dest, int x, int y, int width, int[] src)
	{
		for (int i = 0; i < width * 4; i += 4)
		{
			Color color = Color.FromArgb(src[i], src[i + 1], src[i + 2], src[i + 3]);
			dest.SetPixel(x + i / 4, y, color);
		}
	}

	public void method_12(Bitmap source, Bitmap image, Bitmap output)
	{
		int[] array = null;
		int[] array2 = null;
		int x = 0;
		int width = output.Width;
		int num = 0 + output.Height;
		int num2 = 65793;
		int num3 = 8388608;
		for (int i = 0; i < num; i++)
		{
			array = method_10(source, x, i, width);
			array2 = method_10(image, x, i, width);
			int num4 = 0;
			int num5 = width * 4;
			while (num4 < num5)
			{
				int num6 = (255 - array[num4 + 3]) * num2;
				array2[num4] = array[num4] + smethod_0(array2[num4] * num6 + num3, 24);
				num4++;
				array2[num4] = array[num4] + smethod_0(array2[num4] * num6 + num3, 24);
				num4++;
				array2[num4] = array[num4] + smethod_0(array2[num4] * num6 + num3, 24);
				num4++;
				array2[num4] = array[num4] + smethod_0(array2[num4] * num6 + num3, 24);
				num4++;
			}
			method_11(ref output, x, i, width, array2);
		}
	}

	public void method_13(Bitmap source, Bitmap image, Bitmap output)
	{
		int[] array = null;
		int[] array2 = null;
		int x = 0;
		int width = output.Width;
		int num = 0 + output.Height;
		int num2 = 65793;
		int num3 = 8388608;
		for (int i = 0; i < num; i++)
		{
			array = method_10(source, x, i, width);
			array2 = method_10(image, x, i, width);
			int num4 = 0;
			int num5 = 0;
			int num6 = width * 4;
			while (num4 < num6)
			{
				int num7 = (255 - array[num4 + 3]) * num2;
				array2[num5] = array[num4] + smethod_0(array2[num5] * num7 + num3, 24);
				num4++;
				num5++;
				array2[num5] = array[num4] + smethod_0(array2[num5] * num7 + num3, 24);
				num4++;
				num5++;
				array2[num5] = array[num4] + smethod_0(array2[num5] * num7 + num3, 24);
				num4 += 2;
				num5++;
			}
			method_11(ref output, x, i, width, array2);
		}
	}

	public void method_14(int width, int height, int[] source, int offset, int sourceSp, int[] outPixels, int outOffset, int inputSp, int[] outputPixels, int outputPixelsOffset, int outputPixelsSp)
	{
		int num = 65793;
		int num2 = 8388608;
		for (int i = 0; i < height; i++)
		{
			int num3 = outputPixelsSp + width;
			while (outputPixelsSp < num3)
			{
				int num4 = source[sourceSp++];
				int num5 = outPixels[inputSp++];
				int num6 = (255 - Convert.ToInt32(Convert.ToUInt32(num4) >> 24)) * num;
				long value = (num4 & 0xFF000000L) + ((Convert.ToInt32(Convert.ToUInt32(num5) >> 24) * num6 + num2) & 0xFF000000L);
				long value2 = (num4 & 0xFF0000) + Convert.ToInt32(Convert.ToUInt32(((((num5 >> 16) & 0xFF) * num6 + num2) & 0xFF000000L) >> 8));
				long value3 = (num4 & 0xFF00) + Convert.ToInt32(Convert.ToUInt32((((num5 >> 8) & 0xFF) * num6 + num2) & 0xFF000000L) >> 16);
				long value4 = (num4 & 0xFF) + Convert.ToInt32(Convert.ToUInt32((num5 & 0xFF) * num6 + num2) >> 24);
				outputPixels[outputPixelsSp++] = Convert.ToInt32(value) | Convert.ToInt32(value2) | Convert.ToInt32(value3) | Convert.ToInt32(value4);
			}
			sourceSp += offset;
			inputSp += outOffset;
			outputPixelsSp += outputPixelsOffset;
		}
	}

	public void method_15(int width, int height, int[] source, int sourceOffset, int sourceSp, int[] output, int outOffset, int outSp, int[] outputPixels, int outputPixelsOffset, int outputPixelsSp)
	{
		int num = 65793;
		int num2 = 8388608;
		for (int i = 0; i < height; i++)
		{
			int num3 = outputPixelsSp + width;
			while (outputPixelsSp < num3)
			{
				int num4 = source[sourceSp++];
				int num5 = output[outSp++];
				int num6 = (255 - Convert.ToInt32(Convert.ToUInt32(num4) >> 24)) * num;
				outputPixels[outputPixelsSp++] = ((num4 & 0xFF0000) + Convert.ToInt32(Convert.ToUInt32((((num5 >> 16) & 0xFF) * num6 + num2) & 0xFF000000L) >> 8)) | ((num4 & 0xFF00) + Convert.ToInt32(Convert.ToUInt32((((num5 >> 8) & 0xFF) * num6 + num2) & 0xFF000000L) >> 16)) | ((num4 & 0xFF) + Convert.ToInt32(Convert.ToUInt32((num5 & 0xFF) * num6 + num2) >> 24));
			}
			sourceSp += sourceOffset;
			outSp += outOffset;
			outputPixelsSp += outputPixelsOffset;
		}
	}

	public void method_16(int width, int height, int[] sourcePixels, int offset, int sp, int[] output, int outputOffset, int outSp, int[] outPixels, int outOffset, int pixelsSp)
	{
		int num = 65793;
		int num2 = 8388608;
		for (int i = 0; i < height; i++)
		{
			int num3 = pixelsSp + width;
			while (pixelsSp < num3)
			{
				int num4 = sourcePixels[sp++];
				int num5 = output[outSp++];
				int num6 = Convert.ToInt32(Convert.ToUInt32(num4) >> 24) * num;
				int num7 = (255 - Convert.ToInt32(Convert.ToUInt32(num4 >> 24))) * num;
				outPixels[pixelsSp++] = Convert.ToInt32(((num4 & 0xFF000000L) + smethod_0(num5, 24) * num7 + num2) & 0xFF000000L) | smethod_1((((num4 >> 16) & 0xFF) * num6 + ((num5 >> 16) & 0xFF) * num7 + num2) & 0xFF000000L, 8) | smethod_1((((num4 >> 8) & 0xFF) * num6 + ((num5 >> 8) & 0xFF) * num7 + num2) & 0xFF000000L, 16) | smethod_0((num4 & 0xFF) * num6 + (num5 & 0xFF) * num7 + num2, 24);
			}
			sp += offset;
			outSp += outputOffset;
			pixelsSp += outOffset;
		}
	}

	public void method_17(Bitmap source, Bitmap image, Bitmap output)
	{
		int[] array = null;
		int[] array2 = null;
		int x = 0;
		int width = output.Width;
		int num = 0 + output.Height;
		int num2 = 65793;
		int num3 = 8388608;
		for (int i = 0; i < num; i++)
		{
			array = method_10(source, x, i, width);
			array2 = method_10(image, x, i, width);
			int num4 = 0;
			int num5 = width * 4;
			while (num4 < num5)
			{
				int num6 = array2[num4 + 3] * num2;
				array2[num4] = smethod_0(array[num4] * num6 + num3, 24);
				num4++;
				array2[num4] = smethod_0(array[num4] * num6 + num3, 24);
				num4++;
				array2[num4] = smethod_0(array[num4] * num6 + num3, 24);
				num4++;
				array2[num4] = smethod_0(array[num4] * num6 + num3, 24);
				num4++;
			}
			method_11(ref output, x, i, width, array2);
		}
	}

	public void method_18(int width, int height, int[] source, int offset, int sp, int[] output, int outOffset, int outSp, int[] outPixels, int outPixelsOffset, int outPixelsSp)
	{
		int num = 65793;
		int num2 = 8388608;
		for (int i = 0; i < height; i++)
		{
			int num3 = outPixelsSp + width;
			while (outPixelsSp < num3)
			{
				int num4 = smethod_0(output[outSp++], 24) * num;
				int num5 = source[sp++];
				outPixels[outPixelsSp++] = Convert.ToInt32((smethod_0(num5, 24) * num4 + num2) & 0xFF000000L) | smethod_1((((num5 >> 16) & 0xFF) * num4 + num2) & 0xFF000000L, 8) | smethod_1((((num5 >> 8) & 0xFF) * num4 + num2) & 0xFF000000L, 16) | smethod_0((num5 & 0xFF) * num4 + num2, 24);
			}
			sp += offset;
			outSp += outOffset;
			outPixelsSp += outPixelsOffset;
		}
	}

	public void method_19(Bitmap source, Bitmap image, Bitmap output)
	{
		int[] array = null;
		int[] array2 = null;
		int x = 0;
		int width = output.Width;
		int num = 0 + output.Height;
		int num2 = 65793;
		int num3 = 8388608;
		for (int i = 0; i < num; i++)
		{
			array = method_10(source, x, i, width);
			array2 = method_10(image, x, i, width);
			int num4 = 0;
			int num5 = width * 4;
			while (num4 < num5)
			{
				int num6 = (255 - array2[num4 + 3]) * num2;
				array2[num4] = smethod_0(array[num4] * num6 + num3, 24);
				num4++;
				array2[num4] = smethod_0(array[num4] * num6 + num3, 24);
				num4++;
				array2[num4] = smethod_0(array[num4] * num6 + num3, 24);
				num4++;
				array2[num4] = smethod_0(array[num4] * num6 + num3, 24);
				num4++;
			}
			method_11(ref output, x, i, width, array2);
		}
	}

	public void method_20(int width, int height, int[] source, int offset, int sp, int[] output, int outputOffset, int outputSp, int[] outputPixels, int outputPixelsOffset, int outputPixelsSp)
	{
		int num = 65793;
		int num2 = 8388608;
		for (int i = 0; i < height; i++)
		{
			int num3 = outputPixelsSp + width;
			while (outputPixelsSp < num3)
			{
				int num4 = (255 - smethod_0(output[outputSp++], 24)) * num;
				int num5 = source[sp++];
				outputPixels[outputPixelsSp++] = Convert.ToInt32((smethod_0(num5, 24) * num4 + num2) & 0xFF000000L) | smethod_1((((num5 >> 16) & 0xFF) * num4 + num2) & 0xFF000000L, 8) | smethod_1((((num5 >> 8) & 0xFF) * num4 + num2) & 0xFF000000L, 16) | smethod_0((num5 & 0xFF) * num4 + num2, 24);
			}
			sp += offset;
			outputSp += outputOffset;
			outputPixelsSp += outputPixelsOffset;
		}
	}

	public void method_21(Bitmap source, Bitmap image, Bitmap output)
	{
		int[] array = null;
		int[] array2 = null;
		int x = 0;
		int width = output.Width;
		int num = 0 + output.Height;
		int num2 = 65793;
		int num3 = 8388608;
		for (int i = 0; i < num; i++)
		{
			array = method_10(source, x, i, width);
			array2 = method_10(image, x, i, width);
			int num4 = 0;
			int num5 = width * 4;
			while (num4 < num5)
			{
				int num6 = array2[num4 + 3] * num2;
				int num7 = (255 - array[num4 + 3]) * num2;
				array2[num4] = smethod_0(array[num4] * num6 + array2[num4] * num7 + num3, 24);
				num4++;
				array2[num4] = smethod_0(array[num4] * num6 + array2[num4] * num7 + num3, 24);
				num4++;
				array2[num4] = smethod_0(array[num4] * num6 + array2[num4] * num7 + num3, 24);
				num4 += 2;
			}
			method_11(ref output, x, i, width, array2);
		}
	}

	public void method_22(int width, int height, int[] sourcePixels, int offset, int sp, int[] output, int outputOffset, int outputSp, int[] outputPixels, int outputPixelsOffset, int outputPixelsSp)
	{
		int num = 65793;
		int num2 = 8388608;
		for (int i = 0; i < height; i++)
		{
			int num3 = outputPixelsSp + width;
			while (outputPixelsSp < num3)
			{
				int num4 = sourcePixels[sp++];
				int num5 = output[outputSp++];
				int num6 = smethod_0(num5, 24) * num;
				int num7 = (255 - smethod_0(num4, 24)) * num;
				outputPixels[outputPixelsSp++] = Convert.ToInt32(num5 & 0xFF000000L) | smethod_1((((num4 >> 16) & 0xFF) * num6 + ((num5 >> 16) & 0xFF) * num7 + num2) & 0xFF000000L, 8) | smethod_1((((num4 >> 8) & 0xFF) * num6 + ((num5 >> 8) & 0xFF) * num7 + num2) & 0xFF000000L, 16) | smethod_0((num4 & 0xFF) * num6 + (num5 & 0xFF) * num7 + num2, 24);
			}
			sp += offset;
			outputSp += outputOffset;
			outputPixelsSp += outputPixelsOffset;
		}
	}

	public void method_23(Bitmap source, Bitmap image, Bitmap output)
	{
		int[] array = null;
		int[] array2 = null;
		int x = 0;
		int width = output.Width;
		int num = 0 + output.Height;
		int num2 = 65793;
		int num3 = 8388608;
		for (int i = 0; i < num; i++)
		{
			array = method_10(source, x, i, width);
			array2 = method_10(image, x, i, width);
			int num4 = 0;
			int num5 = width * 4;
			while (num4 < num5)
			{
				int num6 = (255 - array2[num4 + 3]) * num2;
				int num7 = (255 - array[num4 + 3]) * num2;
				array2[num4] = smethod_0(array[num4] * num6 + array2[num4] * num7 + num3, 24);
				num4++;
				array2[num4] = smethod_0(array[num4] * num6 + array2[num4] * num7 + num3, 24);
				num4++;
				array2[num4] = smethod_0(array[num4] * num6 + array2[num4] * num7 + num3, 24);
				num4++;
				array2[num4] = smethod_0(array[num4] * num6 + array2[num4] * num7 + num3, 24);
				num4++;
			}
			method_11(ref output, x, i, width, array2);
		}
	}

	public void method_24(int width, int height, int[] source, int offset, int sp, int[] output, int outputOffset, int outputSp, int[] outputPixels, int outputPixelsOffset, int outputPixelsSp)
	{
		int num = 65793;
		int num2 = 8388608;
		for (int i = 0; i < height; i++)
		{
			int num3 = outputPixelsSp + width;
			while (outputPixelsSp < num3)
			{
				int num4 = source[sp++];
				int num5 = output[outputSp++];
				int num6 = (255 - smethod_0(num5, 24)) * num;
				int num7 = (255 - smethod_0(num4, 24)) * num;
				outputPixels[outputPixelsSp++] = Convert.ToInt32((smethod_0(num4, 24) * num6 + smethod_0(num5, 24) * num7 + num2) & 0xFF000000L) | smethod_1((((num4 >> 16) & 0xFF) * num6 + ((num5 >> 16) & 0xFF) * num7 + num2) & 0xFF000000L, 8) | smethod_1((((num4 >> 8) & 0xFF) * num6 + ((num5 >> 8) & 0xFF) * num7 + num2) & 0xFF000000L, 16) | smethod_0((num4 & 0xFF) * num6 + (num5 & 0xFF) * num7 + num2, 24);
			}
			sp += offset;
			outputSp += outputOffset;
			outputPixelsSp += outputPixelsOffset;
		}
	}

	public void method_25(Bitmap source, Bitmap image, Bitmap output)
	{
		int[] array = null;
		int[] array2 = null;
		int x = 0;
		int width = output.Width;
		int num = 1;
		int num2 = 0 + output.Height;
		float num3 = float_0 / 255f;
		float num4 = float_3 * 255f + 0.5f;
		for (int i = 0; i < num2; i++)
		{
			array = method_10(source, x, i, width);
			array2 = method_10(image, x, i, width);
			for (int j = 0; j < array.Length; j++)
			{
				int num5 = 0;
				int num6 = 1;
				int num7;
				while (num6 < num)
				{
					num7 = (int)(num3 * (float)array[j] * (float)array2[j] + float_1 * (float)array[j] + float_2 * (float)array2[j] + num4);
					if ((num7 & 0xFFFFFF00L) != 0L)
					{
						num7 = (((num7 & 0x80000000L) == 0L) ? 255 : 0);
					}
					if (num7 > num5)
					{
						num5 = num7;
					}
					array2[j] = num7;
					num6++;
					j++;
				}
				num7 = (int)(num3 * (float)array[j] * (float)array2[j] + float_1 * (float)array[j] + float_2 * (float)array2[j] + num4);
				if ((num7 & 0xFFFFFF00L) != 0L)
				{
					num7 = (((num7 & 0x80000000L) == 0L) ? 255 : 0);
				}
				if (num7 > num5)
				{
					array2[j] = num7;
				}
				else
				{
					array2[j] = num5;
				}
			}
			method_11(ref output, x, i, width, array2);
		}
	}

	public void method_26(int width, int height, int[] source, int offset, int sp, int[] output, int outOffset, int outSp, int[] outPixels, int outPixelsOffset, int outPixelsSp)
	{
		for (int i = 0; i < height; i++)
		{
			int num = outPixelsSp + width;
			while (outPixelsSp < num)
			{
				int num2 = source[sp++];
				int num3 = output[outSp++];
				int num4 = (int)((float)(smethod_0(num2, 24) * smethod_0(num3, 24)) * float_0 + (float)smethod_0(num2, 24) * float_1 + (float)smethod_0(num3, 24) * float_2 + float_3);
				if ((num4 & 0xFFFFFF00L) != 0L)
				{
					num4 = (((num4 & 0x80000000L) == 0L) ? 255 : 0);
				}
				int num5 = (int)((float)(((num2 >> 16) & 0xFF) * ((num3 >> 16) & 0xFF)) * float_0 + (float)((num2 >> 16) & 0xFF) * float_1 + (float)((num3 >> 16) & 0xFF) * float_2 + float_3);
				if ((num5 & 0xFFFFFF00L) != 0L)
				{
					num5 = (((num5 & 0x80000000L) == 0L) ? 255 : 0);
				}
				if (num4 < num5)
				{
					num4 = num5;
				}
				int num6 = (int)((float)(((num2 >> 8) & 0xFF) * ((num3 >> 8) & 0xFF)) * float_0 + (float)((num2 >> 8) & 0xFF) * float_1 + (float)((num3 >> 8) & 0xFF) * float_2 + float_3);
				if ((num6 & 0xFFFFFF00L) != 0L)
				{
					num6 = (((num6 & 0x80000000L) == 0L) ? 255 : 0);
				}
				if (num4 < num6)
				{
					num4 = num6;
				}
				int num7 = (int)((float)((num2 & 0xFF) * (num3 & 0xFF)) * float_0 + (float)(num2 & 0xFF) * float_1 + (float)(num3 & 0xFF) * float_2 + float_3);
				if ((num7 & 0xFFFFFF00L) != 0L)
				{
					num7 = (((num7 & 0x80000000L) == 0L) ? 255 : 0);
				}
				if (num4 < num7)
				{
					num4 = num7;
				}
				outPixels[outPixelsSp++] = (num4 << 24) | (num5 << 16) | (num6 << 8) | num7;
			}
			sp += offset;
			outSp += outOffset;
			outPixelsSp += outPixelsOffset;
		}
	}

	public void method_27(int width, int height, int[] source, int offset, int sp, int[] output, int outputOffset, int outputSp, int[] outputPixels, int outputPixelsOffset, int outputPixelsSp)
	{
		byte[] array = byte_0;
		for (int i = 0; i < height; i++)
		{
			int num = outputPixelsSp + width;
			while (outputPixelsSp < num)
			{
				int num2 = source[sp++];
				int num3 = output[outputSp++];
				int num4 = 0xFF & array[((num2 >> 16) & 0xFF00) | smethod_0(num3, 24)];
				int num5 = 0xFF & array[((num2 >> 8) & 0xFF00) | ((num3 >> 16) & 0xFF)];
				int num6 = 0xFF & array[(num2 & 0xFF00) | ((num3 >> 8) & 0xFF)];
				int num7 = 0xFF & array[((num2 << 8) & 0xFF00) | (num3 & 0xFF)];
				if (num5 > num4)
				{
					num4 = num5;
				}
				if (num6 > num4)
				{
					num4 = num6;
				}
				if (num7 > num4)
				{
					num4 = num7;
				}
				outputPixels[outputPixelsSp++] = (num4 << 24) | (num5 << 16) | (num6 << 8) | num7;
			}
			sp += offset;
			outputSp += outputOffset;
			outputPixelsSp += outputPixelsOffset;
		}
	}
}
