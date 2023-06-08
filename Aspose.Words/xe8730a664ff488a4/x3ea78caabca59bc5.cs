using System;
using Aspose;

namespace xe8730a664ff488a4;

[JavaDelete("Using java zip instead.")]
internal sealed class x3ea78caabca59bc5
{
	private const int x5f1f6c759ae65fab = 15;

	private const int x34fdcf86e8d004e7 = 19;

	private const int x9149f7dbf48c8dff = 30;

	private const int x4f96630056849dc0 = 256;

	private const int x53c45999b03c0bd2 = 29;

	internal const int xdb1f7cd17273ab16 = 7;

	internal const int x7d1dca3ecf89891d = 256;

	internal const int x255d699dafddefa2 = 16;

	internal const int x310981460ad9f4c4 = 17;

	internal const int x9d766a864029a6b5 = 18;

	internal const int x37de5270266b2029 = 16;

	private static readonly int xec7cd4898f2b4021 = 286;

	private static readonly int x8ae28d9096d8c0d3 = 2 * xec7cd4898f2b4021 + 1;

	internal static readonly int[] x0cfc2eeecc7d6a9d = new int[29]
	{
		0, 0, 0, 0, 0, 0, 0, 0, 1, 1,
		1, 1, 2, 2, 2, 2, 3, 3, 3, 3,
		4, 4, 4, 4, 5, 5, 5, 5, 0
	};

	internal static readonly int[] xc9e73f383680dd02 = new int[30]
	{
		0, 0, 0, 0, 1, 1, 2, 2, 3, 3,
		4, 4, 5, 5, 6, 6, 7, 7, 8, 8,
		9, 9, 10, 10, 11, 11, 12, 12, 13, 13
	};

	internal static readonly int[] xdc9a394be06f5774 = new int[19]
	{
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 2, 3, 7
	};

	internal static readonly sbyte[] xb846f261abce3fb5 = new sbyte[19]
	{
		16, 17, 18, 0, 8, 7, 9, 6, 10, 5,
		11, 4, 12, 3, 13, 2, 14, 1, 15
	};

	private static readonly sbyte[] _x7a4f584d66f45c71 = new sbyte[512]
	{
		0, 1, 2, 3, 4, 4, 5, 5, 6, 6,
		6, 6, 7, 7, 7, 7, 8, 8, 8, 8,
		8, 8, 8, 8, 9, 9, 9, 9, 9, 9,
		9, 9, 10, 10, 10, 10, 10, 10, 10, 10,
		10, 10, 10, 10, 10, 10, 10, 10, 11, 11,
		11, 11, 11, 11, 11, 11, 11, 11, 11, 11,
		11, 11, 11, 11, 12, 12, 12, 12, 12, 12,
		12, 12, 12, 12, 12, 12, 12, 12, 12, 12,
		12, 12, 12, 12, 12, 12, 12, 12, 12, 12,
		12, 12, 12, 12, 12, 12, 13, 13, 13, 13,
		13, 13, 13, 13, 13, 13, 13, 13, 13, 13,
		13, 13, 13, 13, 13, 13, 13, 13, 13, 13,
		13, 13, 13, 13, 13, 13, 13, 13, 14, 14,
		14, 14, 14, 14, 14, 14, 14, 14, 14, 14,
		14, 14, 14, 14, 14, 14, 14, 14, 14, 14,
		14, 14, 14, 14, 14, 14, 14, 14, 14, 14,
		14, 14, 14, 14, 14, 14, 14, 14, 14, 14,
		14, 14, 14, 14, 14, 14, 14, 14, 14, 14,
		14, 14, 14, 14, 14, 14, 14, 14, 14, 14,
		14, 14, 15, 15, 15, 15, 15, 15, 15, 15,
		15, 15, 15, 15, 15, 15, 15, 15, 15, 15,
		15, 15, 15, 15, 15, 15, 15, 15, 15, 15,
		15, 15, 15, 15, 15, 15, 15, 15, 15, 15,
		15, 15, 15, 15, 15, 15, 15, 15, 15, 15,
		15, 15, 15, 15, 15, 15, 15, 15, 15, 15,
		15, 15, 15, 15, 15, 15, 0, 0, 16, 17,
		18, 18, 19, 19, 20, 20, 20, 20, 21, 21,
		21, 21, 22, 22, 22, 22, 22, 22, 22, 22,
		23, 23, 23, 23, 23, 23, 23, 23, 24, 24,
		24, 24, 24, 24, 24, 24, 24, 24, 24, 24,
		24, 24, 24, 24, 25, 25, 25, 25, 25, 25,
		25, 25, 25, 25, 25, 25, 25, 25, 25, 25,
		26, 26, 26, 26, 26, 26, 26, 26, 26, 26,
		26, 26, 26, 26, 26, 26, 26, 26, 26, 26,
		26, 26, 26, 26, 26, 26, 26, 26, 26, 26,
		26, 26, 27, 27, 27, 27, 27, 27, 27, 27,
		27, 27, 27, 27, 27, 27, 27, 27, 27, 27,
		27, 27, 27, 27, 27, 27, 27, 27, 27, 27,
		27, 27, 27, 27, 28, 28, 28, 28, 28, 28,
		28, 28, 28, 28, 28, 28, 28, 28, 28, 28,
		28, 28, 28, 28, 28, 28, 28, 28, 28, 28,
		28, 28, 28, 28, 28, 28, 28, 28, 28, 28,
		28, 28, 28, 28, 28, 28, 28, 28, 28, 28,
		28, 28, 28, 28, 28, 28, 28, 28, 28, 28,
		28, 28, 28, 28, 28, 28, 28, 28, 29, 29,
		29, 29, 29, 29, 29, 29, 29, 29, 29, 29,
		29, 29, 29, 29, 29, 29, 29, 29, 29, 29,
		29, 29, 29, 29, 29, 29, 29, 29, 29, 29,
		29, 29, 29, 29, 29, 29, 29, 29, 29, 29,
		29, 29, 29, 29, 29, 29, 29, 29, 29, 29,
		29, 29, 29, 29, 29, 29, 29, 29, 29, 29,
		29, 29
	};

	internal static readonly sbyte[] xc601c46f04cca405 = new sbyte[256]
	{
		0, 1, 2, 3, 4, 5, 6, 7, 8, 8,
		9, 9, 10, 10, 11, 11, 12, 12, 12, 12,
		13, 13, 13, 13, 14, 14, 14, 14, 15, 15,
		15, 15, 16, 16, 16, 16, 16, 16, 16, 16,
		17, 17, 17, 17, 17, 17, 17, 17, 18, 18,
		18, 18, 18, 18, 18, 18, 19, 19, 19, 19,
		19, 19, 19, 19, 20, 20, 20, 20, 20, 20,
		20, 20, 20, 20, 20, 20, 20, 20, 20, 20,
		21, 21, 21, 21, 21, 21, 21, 21, 21, 21,
		21, 21, 21, 21, 21, 21, 22, 22, 22, 22,
		22, 22, 22, 22, 22, 22, 22, 22, 22, 22,
		22, 22, 23, 23, 23, 23, 23, 23, 23, 23,
		23, 23, 23, 23, 23, 23, 23, 23, 24, 24,
		24, 24, 24, 24, 24, 24, 24, 24, 24, 24,
		24, 24, 24, 24, 24, 24, 24, 24, 24, 24,
		24, 24, 24, 24, 24, 24, 24, 24, 24, 24,
		25, 25, 25, 25, 25, 25, 25, 25, 25, 25,
		25, 25, 25, 25, 25, 25, 25, 25, 25, 25,
		25, 25, 25, 25, 25, 25, 25, 25, 25, 25,
		25, 25, 26, 26, 26, 26, 26, 26, 26, 26,
		26, 26, 26, 26, 26, 26, 26, 26, 26, 26,
		26, 26, 26, 26, 26, 26, 26, 26, 26, 26,
		26, 26, 26, 26, 27, 27, 27, 27, 27, 27,
		27, 27, 27, 27, 27, 27, 27, 27, 27, 27,
		27, 27, 27, 27, 27, 27, 27, 27, 27, 27,
		27, 27, 27, 27, 27, 28
	};

	internal static readonly int[] xf224e2f78df7e606 = new int[29]
	{
		0, 1, 2, 3, 4, 5, 6, 7, 8, 10,
		12, 14, 16, 20, 24, 28, 32, 40, 48, 56,
		64, 80, 96, 112, 128, 160, 192, 224, 0
	};

	internal static readonly int[] x829fbae11dc19d07 = new int[30]
	{
		0, 1, 2, 3, 4, 6, 8, 12, 16, 24,
		32, 48, 64, 96, 128, 192, 256, 384, 512, 768,
		1024, 1536, 2048, 3072, 4096, 6144, 8192, 12288, 16384, 24576
	};

	internal short[] x80778d70542dacbe;

	internal int xbcc5a178a370a83c;

	internal x77c5e3c2e7f86c35 x01dd49fc21e7b22e;

	internal static int x9f3add957e5d5ad4(int x090bbc85381ea59f)
	{
		if (x090bbc85381ea59f >= 256)
		{
			return _x7a4f584d66f45c71[256 + x71e71339e29fbf2b.x708a60ec8cfa708b(x090bbc85381ea59f, 7)];
		}
		return _x7a4f584d66f45c71[x090bbc85381ea59f];
	}

	internal void x896a88b460df08e1(xf3d15be056ff8c27 xe4115acdf4fbfccc)
	{
		short[] array = x80778d70542dacbe;
		short[] x7b5ab713bb96aa2a = x01dd49fc21e7b22e.x7b5ab713bb96aa2a;
		int[] xdca5400fbc = x01dd49fc21e7b22e.xdca5400fbc290588;
		int x20cbf09449a = x01dd49fc21e7b22e.x20cbf09449a75540;
		int x95ef8119d9d = x01dd49fc21e7b22e.x95ef8119d9d70648;
		int num = 0;
		for (int i = 0; i <= 15; i++)
		{
			xe4115acdf4fbfccc.xcd60d8e0f0d6d122[i] = 0;
		}
		array[xe4115acdf4fbfccc.xdf8557ca83346167[xe4115acdf4fbfccc.x18b2b0889e654b3c] * 2 + 1] = 0;
		int j;
		for (j = xe4115acdf4fbfccc.x18b2b0889e654b3c + 1; j < x8ae28d9096d8c0d3; j++)
		{
			int num2 = xe4115acdf4fbfccc.xdf8557ca83346167[j];
			int i = array[array[num2 * 2 + 1] * 2 + 1] + 1;
			if (i > x95ef8119d9d)
			{
				i = x95ef8119d9d;
				num++;
			}
			array[num2 * 2 + 1] = (short)i;
			if (num2 <= xbcc5a178a370a83c)
			{
				xe4115acdf4fbfccc.xcd60d8e0f0d6d122[i]++;
				int num3 = 0;
				if (num2 >= x20cbf09449a)
				{
					num3 = xdca5400fbc[num2 - x20cbf09449a];
				}
				short num4 = array[num2 * 2];
				xe4115acdf4fbfccc.x51b9e450706f2111 += num4 * (i + num3);
				if (x7b5ab713bb96aa2a != null)
				{
					xe4115acdf4fbfccc.x11787cfcca84b003 += num4 * (x7b5ab713bb96aa2a[num2 * 2 + 1] + num3);
				}
			}
		}
		if (num == 0)
		{
			return;
		}
		do
		{
			int i = x95ef8119d9d - 1;
			while (xe4115acdf4fbfccc.xcd60d8e0f0d6d122[i] == 0)
			{
				i--;
			}
			xe4115acdf4fbfccc.xcd60d8e0f0d6d122[i]--;
			xe4115acdf4fbfccc.xcd60d8e0f0d6d122[i + 1] = (short)(xe4115acdf4fbfccc.xcd60d8e0f0d6d122[i + 1] + 2);
			xe4115acdf4fbfccc.xcd60d8e0f0d6d122[x95ef8119d9d]--;
			num -= 2;
		}
		while (num > 0);
		for (int i = x95ef8119d9d; i != 0; i--)
		{
			int num2 = xe4115acdf4fbfccc.xcd60d8e0f0d6d122[i];
			while (num2 != 0)
			{
				int num5 = xe4115acdf4fbfccc.xdf8557ca83346167[--j];
				if (num5 <= xbcc5a178a370a83c)
				{
					if (array[num5 * 2 + 1] != i)
					{
						xe4115acdf4fbfccc.x51b9e450706f2111 = (int)(xe4115acdf4fbfccc.x51b9e450706f2111 + ((long)i - (long)array[num5 * 2 + 1]) * array[num5 * 2]);
						array[num5 * 2 + 1] = (short)i;
					}
					num2--;
				}
			}
		}
	}

	internal void xd404188d0e1f558f(xf3d15be056ff8c27 xe4115acdf4fbfccc)
	{
		short[] array = x80778d70542dacbe;
		short[] x7b5ab713bb96aa2a = x01dd49fc21e7b22e.x7b5ab713bb96aa2a;
		int x40021148582028be = x01dd49fc21e7b22e.x40021148582028be;
		int num = -1;
		xe4115acdf4fbfccc.xf74bdb7c2ce6f439 = 0;
		xe4115acdf4fbfccc.x18b2b0889e654b3c = x8ae28d9096d8c0d3;
		for (int i = 0; i < x40021148582028be; i++)
		{
			if (array[i * 2] != 0)
			{
				num = (xe4115acdf4fbfccc.xdf8557ca83346167[++xe4115acdf4fbfccc.xf74bdb7c2ce6f439] = i);
				xe4115acdf4fbfccc.x1af9fc7847b7aa2c[i] = 0;
			}
			else
			{
				array[i * 2 + 1] = 0;
			}
		}
		int num2;
		while (xe4115acdf4fbfccc.xf74bdb7c2ce6f439 < 2)
		{
			num2 = (xe4115acdf4fbfccc.xdf8557ca83346167[++xe4115acdf4fbfccc.xf74bdb7c2ce6f439] = ((num < 2) ? (++num) : 0));
			array[num2 * 2] = 1;
			xe4115acdf4fbfccc.x1af9fc7847b7aa2c[num2] = 0;
			xe4115acdf4fbfccc.x51b9e450706f2111--;
			if (x7b5ab713bb96aa2a != null)
			{
				xe4115acdf4fbfccc.x11787cfcca84b003 -= x7b5ab713bb96aa2a[num2 * 2 + 1];
			}
		}
		xbcc5a178a370a83c = num;
		for (int i = xe4115acdf4fbfccc.xf74bdb7c2ce6f439 / 2; i >= 1; i--)
		{
			xe4115acdf4fbfccc.x52c13416ab5c73fa(array, i);
		}
		num2 = x40021148582028be;
		do
		{
			int i = xe4115acdf4fbfccc.xdf8557ca83346167[1];
			xe4115acdf4fbfccc.xdf8557ca83346167[1] = xe4115acdf4fbfccc.xdf8557ca83346167[xe4115acdf4fbfccc.xf74bdb7c2ce6f439--];
			xe4115acdf4fbfccc.x52c13416ab5c73fa(array, 1);
			int num3 = xe4115acdf4fbfccc.xdf8557ca83346167[1];
			xe4115acdf4fbfccc.xdf8557ca83346167[--xe4115acdf4fbfccc.x18b2b0889e654b3c] = i;
			xe4115acdf4fbfccc.xdf8557ca83346167[--xe4115acdf4fbfccc.x18b2b0889e654b3c] = num3;
			array[num2 * 2] = (short)(array[i * 2] + array[num3 * 2]);
			xe4115acdf4fbfccc.x1af9fc7847b7aa2c[num2] = (sbyte)(Math.Max((byte)xe4115acdf4fbfccc.x1af9fc7847b7aa2c[i], (byte)xe4115acdf4fbfccc.x1af9fc7847b7aa2c[num3]) + 1);
			array[i * 2 + 1] = (array[num3 * 2 + 1] = (short)num2);
			xe4115acdf4fbfccc.xdf8557ca83346167[1] = num2++;
			xe4115acdf4fbfccc.x52c13416ab5c73fa(array, 1);
		}
		while (xe4115acdf4fbfccc.xf74bdb7c2ce6f439 >= 2);
		xe4115acdf4fbfccc.xdf8557ca83346167[--xe4115acdf4fbfccc.x18b2b0889e654b3c] = xe4115acdf4fbfccc.xdf8557ca83346167[1];
		x896a88b460df08e1(xe4115acdf4fbfccc);
		xc205fd83ea171579(array, num, xe4115acdf4fbfccc.xcd60d8e0f0d6d122);
	}

	internal static void xc205fd83ea171579(short[] x2ab16cc75cbe6a5d, int xbcc5a178a370a83c, short[] xcd60d8e0f0d6d122)
	{
		short[] array = new short[16];
		short num = 0;
		for (int i = 1; i <= 15; i++)
		{
			num = (array[i] = (short)(num + xcd60d8e0f0d6d122[i - 1] << 1));
		}
		for (int j = 0; j <= xbcc5a178a370a83c; j++)
		{
			int num2 = x2ab16cc75cbe6a5d[j * 2 + 1];
			if (num2 != 0)
			{
				x2ab16cc75cbe6a5d[j * 2] = (short)x2b36ca79ad4a4686(array[num2]++, num2);
			}
		}
	}

	internal static int x2b36ca79ad4a4686(int x9035cf16181332fc, int xb5964a891b6cf7c3)
	{
		int num = 0;
		do
		{
			num |= x9035cf16181332fc & 1;
			x9035cf16181332fc = x71e71339e29fbf2b.x708a60ec8cfa708b(x9035cf16181332fc, 1);
			num <<= 1;
		}
		while (--xb5964a891b6cf7c3 > 0);
		return x71e71339e29fbf2b.x708a60ec8cfa708b(num, 1);
	}
}
