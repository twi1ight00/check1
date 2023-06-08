using System;
using System.Collections;

namespace ns316;

internal class Class7154
{
	private enum Enum974
	{
		const_0,
		const_1,
		const_2
	}

	private const int int_0 = 3;

	private const int int_1 = 2;

	private const int int_2 = 1;

	private const int int_3 = 0;

	private ArrayList arrayList_0;

	public Class7154()
	{
		arrayList_0 = new ArrayList();
	}

	private static int smethod_0(int val, int max)
	{
		val = Math.Max(val, 0);
		return Math.Min(val, max - 1);
	}

	internal static void smethod_1(int[] sourceData, int[] targetData, int width, int height, int stride, int xlen, int ylen, int edgeMode, float[] kernel, float divisor, float bias, bool preserveAlpha, int orderX, int orderY, int targetX, int targetY)
	{
		float[] array = new float[4];
		float[] array2 = array;
		bias = 255f;
		int[] array3 = new int[4] { 2, 1, 0, 3 };
		int num = (preserveAlpha ? 3 : 4);
		for (int i = 0; i < orderY; i++)
		{
			int num2 = ylen + i - targetY;
			bool flag = num2 < 0 || num2 >= height;
			for (int j = 0; j < orderX; j++)
			{
				int num3 = xlen + j - targetX;
				bool flag2 = num3 < 0 || num3 >= width;
				for (int k = 0; k < num; k++)
				{
					if (!flag && !flag2)
					{
						array2[k] += (float)sourceData[num2 * stride + 4 * num3 + array3[k]] * kernel[orderX * i + j];
						continue;
					}
					switch (edgeMode)
					{
					case 0:
						array2[k] += (float)sourceData[smethod_0(num2, height) * stride + smethod_0(num3, width) * 4 + array3[k]] * kernel[orderX * i + j];
						break;
					case 1:
						array2[k] += (float)sourceData[height * stride + width * 4 + array3[k]] * kernel[orderX * i + j];
						break;
					}
				}
			}
		}
		for (int l = 0; l < num; l++)
		{
			targetData[ylen * stride + 4 * xlen + array3[l]] = smethod_0((int)(array2[l] / divisor + bias), 256);
		}
		if (preserveAlpha)
		{
			targetData[ylen * stride + 4 * xlen + 3] = sourceData[ylen * stride + 4 * xlen + 3];
		}
	}
}
