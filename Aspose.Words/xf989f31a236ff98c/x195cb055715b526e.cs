using System;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace xf989f31a236ff98c;

internal class x195cb055715b526e
{
	private static readonly int[] x84bb3f53542860ef;

	private x195cb055715b526e()
	{
	}

	internal static x88d38775104122b8 xc3bcf5a9ad941428(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		return x719dd765120133bd(x103636c839f725d7(x6c50a99faab7d741));
	}

	internal static x26d9ecb4bdf0456d x5ab07bb8554e00d9(x88d38775104122b8 x268aef2fda7d49d9)
	{
		return xfa7086ee0c6b6330(xed5fd8bd2318f4fa(x268aef2fda7d49d9));
	}

	internal static x88d38775104122b8 x719dd765120133bd(int x69b4976ccc33eed2)
	{
		if (x69b4976ccc33eed2 == -16777216)
		{
			return x88d38775104122b8.x2bca50d746ec73b2;
		}
		double num = double.MaxValue;
		x88d38775104122b8 result = x88d38775104122b8.x89fffa2751fdecbe;
		for (int i = 0; i < x84bb3f53542860ef.Length; i++)
		{
			double num2 = xd2b484c8f01b143b(x84bb3f53542860ef[i], x69b4976ccc33eed2);
			if (num2 <= num)
			{
				result = (x88d38775104122b8)i;
				num = num2;
			}
		}
		return result;
	}

	private static double xd2b484c8f01b143b(int x3f9b02ab39f02fa4, int x5227961f1b13fd45)
	{
		int xb55b340ae3a3e4e = x3f9b02ab39f02fa4 & 0xFF;
		int x4b101060f = (x3f9b02ab39f02fa4 & 0xFF00) >> 8;
		int xe7ebe10fa44d8d = (x3f9b02ab39f02fa4 & 0xFF0000) >> 16;
		int xb55b340ae3a3e4e2 = x5227961f1b13fd45 & 0xFF;
		int x4b101060f2 = (x5227961f1b13fd45 & 0xFF00) >> 8;
		int xe7ebe10fa44d8d2 = (x5227961f1b13fd45 & 0xFF0000) >> 16;
		x01f74f175f4a1d3d x01f74f175f4a1d3d = new x01f74f175f4a1d3d(x26d9ecb4bdf0456d.xd378227c730f388c(xb55b340ae3a3e4e, x4b101060f, xe7ebe10fa44d8d));
		x01f74f175f4a1d3d x01f74f175f4a1d3d2 = new x01f74f175f4a1d3d(x26d9ecb4bdf0456d.xd378227c730f388c(xb55b340ae3a3e4e2, x4b101060f2, xe7ebe10fa44d8d2));
		double num = Math.Abs(x01f74f175f4a1d3d.xcf8335d0074a503e - x01f74f175f4a1d3d2.xcf8335d0074a503e) + Math.Abs(x01f74f175f4a1d3d.x7140fff2ddcc94a1 - x01f74f175f4a1d3d2.x7140fff2ddcc94a1);
		if (!xd1ea73da8c654673(xb55b340ae3a3e4e, x4b101060f, xe7ebe10fa44d8d) && !xd1ea73da8c654673(xb55b340ae3a3e4e2, x4b101060f2, xe7ebe10fa44d8d2))
		{
			num += Math.Abs(x01f74f175f4a1d3d.x771e11bd2ca66cba - x01f74f175f4a1d3d2.x771e11bd2ca66cba);
		}
		return num;
	}

	private static bool xd1ea73da8c654673(int xb55b340ae3a3e4e0, int x4b101060f4767186, int xe7ebe10fa44d8d49)
	{
		if (xb55b340ae3a3e4e0 == x4b101060f4767186)
		{
			return x4b101060f4767186 == xe7ebe10fa44d8d49;
		}
		return false;
	}

	internal static int xed5fd8bd2318f4fa(x88d38775104122b8 x268aef2fda7d49d9)
	{
		if ((int)x268aef2fda7d49d9 < x84bb3f53542860ef.Length)
		{
			return x84bb3f53542860ef[(int)x268aef2fda7d49d9];
		}
		return -16777216;
	}

	internal static int x103636c839f725d7(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		int num = 0;
		num |= x6c50a99faab7d741.xc613adc4330033f3;
		num |= x6c50a99faab7d741.x26463655896fd90a << 8;
		num |= x6c50a99faab7d741.x8e8f6cc6a0756b05 << 16;
		return num | (~x6c50a99faab7d741.xda71bf6f7c07c3bc << 24);
	}

	internal static x26d9ecb4bdf0456d xfa7086ee0c6b6330(int xf5b6377cba813985)
	{
		int r = xf5b6377cba813985 & 0xFF;
		int g = (xf5b6377cba813985 >> 8) & 0xFF;
		int b = (xf5b6377cba813985 >> 16) & 0xFF;
		int num = (xf5b6377cba813985 >> 24) & 0xFF;
		int a = ~num & 0xFF;
		return new x26d9ecb4bdf0456d(a, r, g, b);
	}

	static x195cb055715b526e()
	{
		x84bb3f53542860ef = new int[17]
		{
			-16777216, 0, 16711680, 16776960, 65280, 16711935, 255, 65535, 16777215, 8388608,
			8421376, 32768, 8388736, 128, 32896, 8421504, 12632256
		};
	}
}
