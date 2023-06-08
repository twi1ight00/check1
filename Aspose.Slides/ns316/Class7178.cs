using System;
using System.Drawing;

namespace ns316;

internal class Class7178
{
	private const float float_0 = 0.5f;

	private Bitmap bitmap_0;

	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	private Class7138 class7138_0;

	private Rectangle rectangle_0;

	private bool bool_0;

	public Class7178(Bitmap map, Rectangle region, double lightConst, double exponent, Class7138 light, double xScale, double yScale, bool isLinear)
	{
		bitmap_0 = map;
		rectangle_0 = region;
		double_0 = xScale;
		double_2 = lightConst;
		double_3 = exponent;
		class7138_0 = light;
		double_1 = yScale;
		bool_0 = isLinear;
		int width = region.Width;
		int height = region.Height;
		int num = 8;
		if (width > 8)
		{
			width = num;
		}
		if (height > num)
		{
			height = num;
		}
	}

	public void method_0(Bitmap image)
	{
		float[] array = class7138_0.imethod_3(bool_0);
		int width = image.Width;
		int height = image.Height;
		double num = double_0;
		double num2 = double_1;
		int num3 = 0;
		int num4 = 0;
		int[] array2 = new int[width * height];
		for (int i = 0; i < height; i++)
		{
			for (int j = 0; j < width; j++)
			{
				array2[i * width + j] = Class7177.smethod_2(image.GetPixel(j, i));
			}
		}
		int num5 = 0;
		int num6 = 0;
		int width2 = image.Width;
		int num7 = width2 - width;
		int num8 = 0;
		int num9 = 0;
		double num10 = num * (double)num3;
		double num11 = num2 * (double)num4;
		float num12 = 0f;
		int num13 = 0;
		double num14 = ((array[0] > array[1]) ? array[0] : array[1]);
		num14 = ((num14 > (double)array[2]) ? num14 : ((double)array[2]));
		double num15 = 255.0 / num14;
		num13 = (int)((double)array[0] * num15 + 0.5);
		int num16 = (int)((double)array[1] * num15 + 0.5);
		num13 = (num13 << 8) | num16;
		num16 = (int)((double)array[2] * num15 + 0.5);
		num13 = (num13 << 8) | num16;
		num14 *= 255.0 * double_2;
		float[][][] array3 = new float[height][][];
		for (int k = 0; k < height; k++)
		{
			array3[k] = new float[width][];
			for (int l = 0; l < width; l++)
			{
				array3[k][l] = new float[3];
			}
		}
		if (!class7138_0.IsConstant)
		{
			float[][] array4 = new float[width][];
			for (int m = 0; m < width; m++)
			{
				array4[m] = new float[4];
			}
			for (num5 = 0; num5 < height; num5++)
			{
				float[][] array5 = array3[num5];
				for (int n = 0; n < height; n++)
				{
					array5[n] = new float[4];
				}
				class7138_0.imethod_2((float)num10, (float)(num11 + (double)num5 * num2), (float)num, width, array5, array4);
				for (num6 = 0; num6 < width; num6++)
				{
					float[] array6 = array5[num6];
					float[] array7 = array4[num6];
					array7[2] += 1f;
					num12 = array7[0] * array7[0] + array7[1] * array7[1] + array7[2] * array7[2];
					num12 = (float)Math.Sqrt(num12);
					double num17 = array6[0] * array7[0] + array6[1] * array7[1] + array6[2] * array7[2];
					num12 = (float)Math.Pow(num17 / (double)num12, double_3);
					num9 = (int)(num14 * (double)num12 + 0.5);
					if ((num9 & 0xFFFFFF00L) != 0L)
					{
						num9 = (((num9 & 0x80000000L) == 0L) ? 255 : 0);
					}
					array2[num8++] = (num9 << 24) | num13;
				}
				num8 += num7;
			}
			return;
		}
		if (class7138_0 is Class7142)
		{
			Class7142 @class = (Class7142)class7138_0;
			float[][] array8 = new float[width][];
			for (num5 = 0; num5 < height; num5++)
			{
				float[][] array9 = (float[][])array3[num5].GetValue(0);
				@class.imethod_2((float)num10, (float)(num11 + (double)num5 * num2), (float)num, width, array9, array8);
				for (num6 = 0; num6 < width; num6++)
				{
					float[] array10 = array9[num6];
					float[] array11 = array8[num6];
					double num18 = array11[3];
					if (num18 == 0.0)
					{
						num9 = 0;
					}
					else
					{
						array11[2] += 1f;
						num12 = array11[0] * array11[0] + array11[1] * array11[1] + array11[2] * array11[2];
						num12 = (float)Math.Sqrt(Convert.ToDouble(num12));
						double num19 = array10[0] * array11[0] + array10[1] * array11[1] + array10[2] * array11[2];
						num18 *= Math.Pow(num19 / (double)num12, double_3);
						num9 = (int)(num14 * num18 + 0.5);
						if ((num9 & 0xFFFFFF00L) != 0L)
						{
							num9 = (((num9 & 0x80000000L) == 0L) ? 255 : 0);
						}
					}
					array2[num8++] = (num9 << 24) | num13;
				}
				num8 += num7;
			}
			return;
		}
		float[] array12 = new float[3];
		class7138_0.imethod_0(0f, 0f, 0f, array12);
		array12[2] += 1f;
		num12 = (float)Math.Sqrt(array12[0] * array12[0] + array12[1] * array12[1] + array12[2] * array12[2]);
		if (num12 > 0f)
		{
			array12[0] /= num12;
			array12[1] /= num12;
			array12[2] /= num12;
		}
		for (num5 = 0; num5 < height; num5++)
		{
			float[][] array13 = array3[num5];
			for (num6 = 0; num6 < width; num6++)
			{
				float[] array14 = array13[num6];
				num9 = (int)(num14 * Math.Pow(array14[0] * array12[0] + array14[1] * array12[1] + array14[2] * array12[2], double_3) + 0.5);
				if ((num9 & 0xFFFFFF00L) != 0L)
				{
					num9 = (((num9 & 0x80000000L) == 0L) ? 255 : 0);
				}
				array2[num8++] = (num9 << 24) | num13;
			}
			num8 += num7;
		}
	}
}
