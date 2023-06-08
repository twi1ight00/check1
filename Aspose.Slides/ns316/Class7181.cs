using System;

namespace ns316;

internal class Class7181
{
	private static int int_0 = 256;

	private static int int_1 = 255;

	private static int int_2 = 4096;

	private static int[] int_3 = new int[int_0 + int_0 + 2];

	private static double[,,] double_0 = new double[4, 514, 2];

	private static int int_4 = int.MaxValue;

	private static int int_5 = 16807;

	private static int int_6 = 127773;

	private static int int_7 = 2836;

	public static int smethod_0(int lSeed)
	{
		if (lSeed <= 0)
		{
			lSeed = -(lSeed % (int_4 - 1)) + 1;
		}
		if (lSeed > int_4 - 1)
		{
			lSeed = int_4 - 1;
		}
		return lSeed;
	}

	public static int smethod_1(int lSeed)
	{
		int num = int_5 * lSeed % int_6 - int_7 * lSeed / int_6;
		if (num <= 0)
		{
			num += int_4;
		}
		return num;
	}

	public static void smethod_2(int lSeed)
	{
		int i = 0;
		int num = 0;
		int num2 = 0;
		lSeed = smethod_0(lSeed);
		for (num2 = 0; num2 < 4; num2++)
		{
			for (i = 0; i < int_0; i++)
			{
				int_3[i] = i;
				for (num = 0; num < 2; num++)
				{
					double_0[num2, i, num] = (double)((lSeed = smethod_1(lSeed)) % (int_0 + int_0) - int_0) / (double)int_0;
				}
				double num3 = Math.Sqrt(double_0[num2, i, 0] * double_0[num2, i, 0] + double_0[num2, i, 1] * double_0[num2, i, 1]);
				double_0[num2, i, 0] /= num3;
				double_0[num2, i, 1] /= num3;
			}
		}
		while (i >= 0)
		{
			num2 = int_3[i];
			int_3[i] = int_3[num = (lSeed = smethod_1(lSeed)) % int_0];
			int_3[num] = num2;
			i--;
		}
		for (i = 0; i < int_0 + 2; i++)
		{
			int_3[int_0 + i] = int_3[i];
			for (num2 = 0; num2 < 4; num2++)
			{
				for (num = 0; num < 2; num++)
				{
					double_0[num2, int_0 + i, num] = double_0[num2, i, num];
				}
			}
		}
	}

	private static double smethod_3(double size)
	{
		return size * size * (3.0 - 2.0 * size);
	}

	public static double smethod_4(int nChannel, double[] vec, ref Struct256 pStitchInfo)
	{
		double num = vec[0] + (double)int_2;
		int num2 = (int)num;
		int num3 = num2 + 1;
		double num4 = num - (double)(int)num;
		double num5 = num4 - 1.0;
		num = vec[1] + (double)int_2;
		int num6 = (int)num;
		int num7 = num6 + 1;
		double num8 = num - (double)(int)num;
		double num9 = num8 - 1.0;
		if (pStitchInfo.int_0 > 0)
		{
			if (num2 >= pStitchInfo.int_2)
			{
				num2 -= pStitchInfo.int_0;
			}
			if (num3 >= pStitchInfo.int_2)
			{
				num3 -= pStitchInfo.int_0;
			}
			if (num6 >= pStitchInfo.int_3)
			{
				num6 -= pStitchInfo.int_1;
			}
			if (num7 >= pStitchInfo.int_3)
			{
				num7 -= pStitchInfo.int_1;
			}
		}
		num2 &= int_1;
		num3 &= int_1;
		num6 &= int_1;
		num7 &= int_1;
		int num10 = int_3[num2];
		int num11 = int_3[num3];
		int num12 = int_3[num10 + num6];
		int num13 = int_3[num11 + num6];
		int num14 = int_3[num10 + num7];
		int num15 = int_3[num11 + num7];
		double num16 = smethod_3(num4);
		double num17 = smethod_3(num8);
		double num18 = num4 * double_0[nChannel, num12, 0] + num8 * double_0[nChannel, num12, 1];
		double num19 = num5 * double_0[nChannel, num13, 0] + num8 * double_0[nChannel, num13, 1];
		double num20 = num18 + num16 * (num19 - num18);
		num18 = num4 * double_0[nChannel, num14, 0] + num9 * double_0[nChannel, num14, 1];
		num19 = num5 * double_0[nChannel, num15, 0] + num9 * double_0[nChannel, num15, 1];
		double num21 = num18 + num16 * (num19 - num18);
		return num20 + num17 * (num21 - num20);
	}

	public static double smethod_5(int nColorChannel, ref double[] point, double fBaseFreqX, double fBaseFreqY, int nNumOctaves, bool bFractalSum, bool bDoStitching, double fTileX, double fTileY, double fTileWidth, double fTileHeight)
	{
		Struct256 pStitchInfo = default(Struct256);
		if (bDoStitching)
		{
			if (fBaseFreqX != 0.0)
			{
				double num = Math.Floor(fTileWidth * fBaseFreqX) / fTileWidth;
				double num2 = Math.Ceiling(fTileWidth * fBaseFreqX) / fTileWidth;
				fBaseFreqX = ((!(fBaseFreqX / num < num2 / fBaseFreqX)) ? num2 : num);
			}
			if (fBaseFreqY != 0.0)
			{
				double num3 = Math.Floor(fTileHeight * fBaseFreqY) / fTileHeight;
				double num4 = Math.Ceiling(fTileHeight * fBaseFreqY) / fTileHeight;
				fBaseFreqY = ((!(fBaseFreqY / num3 < num4 / fBaseFreqY)) ? num4 : num3);
			}
			pStitchInfo.int_0 = (int)(fTileWidth * fBaseFreqX + 0.5);
			pStitchInfo.int_2 = (int)(fTileX * fBaseFreqX + (double)int_2 + (double)pStitchInfo.int_0);
			pStitchInfo.int_1 = (int)(fTileHeight * fBaseFreqY + 0.5);
			pStitchInfo.int_3 = (int)(fTileY * fBaseFreqY + (double)int_2 + (double)pStitchInfo.int_1);
		}
		double num5 = 0.0;
		double[] array = new double[2]
		{
			point[0] * fBaseFreqX,
			point[1] * fBaseFreqY
		};
		double num6 = 1.0;
		for (int i = 0; i < nNumOctaves; i++)
		{
			num5 = ((!bFractalSum) ? (num5 + Math.Abs(smethod_4(nColorChannel, array, ref pStitchInfo)) / num6) : (num5 + smethod_4(nColorChannel, array, ref pStitchInfo) / num6));
			array[0] *= 2.0;
			array[1] *= 2.0;
			num6 *= 2.0;
			if (pStitchInfo.int_0 > 0)
			{
				pStitchInfo.int_0 *= 2;
				pStitchInfo.int_2 = 2 * pStitchInfo.int_2 - int_2;
				pStitchInfo.int_1 *= 2;
				pStitchInfo.int_3 = 2 * pStitchInfo.int_3 - int_2;
			}
		}
		return num5;
	}
}
