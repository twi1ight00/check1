using System;
using System.Collections;

namespace x3d94286fe72124a8;

internal class xed704ccd900d004b
{
	internal const float xb4aed8fff53d1e5a = 1E-06f;

	internal const float xc79f8b450e5aa0a7 = 6f;

	private readonly double[] x053586dbe742afc9;

	internal xed704ccd900d004b(double c2, double c1, double c0)
	{
		x053586dbe742afc9 = new double[3];
		x053586dbe742afc9[0] = c0;
		x053586dbe742afc9[1] = c1;
		x053586dbe742afc9[2] = c2;
	}

	internal xed704ccd900d004b(double c3, double c2, double c1, double c0)
	{
		x053586dbe742afc9 = new double[4];
		x053586dbe742afc9[0] = c0;
		x053586dbe742afc9[1] = c1;
		x053586dbe742afc9[2] = c2;
		x053586dbe742afc9[3] = c3;
	}

	internal xed704ccd900d004b(double c4, double c3, double c2, double c1, double c0)
	{
		x053586dbe742afc9 = new double[5];
		x053586dbe742afc9[0] = c0;
		x053586dbe742afc9[1] = c1;
		x053586dbe742afc9[2] = c2;
		x053586dbe742afc9[3] = c3;
		x053586dbe742afc9[4] = c4;
	}

	internal double[] x4869b1f82941a468()
	{
		return x213d213aeccf8448() switch
		{
			0 => new double[0], 
			1 => new double[1] { -1.0 * x053586dbe742afc9[0] / x053586dbe742afc9[1] }, 
			2 => x49e02879c12c5ea5(), 
			3 => x13a183ac9f4a54f7(), 
			4 => x83430fc058f45868(), 
			_ => throw new NotSupportedException("Evaluating roots of that degree is not supported"), 
		};
	}

	internal int x213d213aeccf8448()
	{
		int num = x053586dbe742afc9.Length - 1;
		int num2 = num;
		while (num2 > -1)
		{
			if (Math.Abs(x053586dbe742afc9[num2]) < 9.999999974752427E-07)
			{
				x053586dbe742afc9[num2] = 0.0;
				num2--;
				continue;
			}
			return num2;
		}
		return 0;
	}

	private double[] x49e02879c12c5ea5()
	{
		double[] result = new double[0];
		double num = x053586dbe742afc9[2];
		double num2 = x053586dbe742afc9[1] / num;
		double num3 = x053586dbe742afc9[0] / num;
		double num4 = num2 * num2 - 4.0 * num3;
		if (num4 > 0.0)
		{
			double num5 = Math.Sqrt(num4);
			result = new double[2]
			{
				0.5 * (0.0 - num2 + num5),
				0.5 * (0.0 - num2 - num5)
			};
		}
		else if (num4 == 0.0)
		{
			result = new double[1] { 0.5 * (0.0 - num2) };
		}
		return result;
	}

	private double[] x13a183ac9f4a54f7()
	{
		double num = x053586dbe742afc9[3];
		double num2 = x053586dbe742afc9[2] / num;
		double num3 = x053586dbe742afc9[1] / num;
		double num4 = x053586dbe742afc9[0] / num;
		double num5 = (3.0 * num3 - num2 * num2) / 3.0;
		double num6 = (2.0 * num2 * num2 * num2 - 9.0 * num3 * num2 + 27.0 * num4) / 27.0;
		double num7 = num2 / 3.0;
		double num8 = num6 * num6 / 4.0 + num5 * num5 * num5 / 27.0;
		double num9 = num6 / 2.0;
		if (Math.Abs(num8) <= 9.999999974752427E-07)
		{
			num8 = 0.0;
		}
		if (num8 > 0.0)
		{
			double num10 = Math.Sqrt(num8);
			double num11 = 0.0 - num9 + num10;
			double num12 = ((!(num11 >= 0.0)) ? (0.0 - Math.Pow(0.0 - num11, 1.0 / 3.0)) : Math.Pow(num11, 1.0 / 3.0));
			num11 = 0.0 - num9 - num10;
			num12 = ((!(num11 >= 0.0)) ? (num12 - Math.Pow(0.0 - num11, 1.0 / 3.0)) : (num12 + Math.Pow(num11, 1.0 / 3.0)));
			return new double[1] { num12 - num7 };
		}
		if (num8 < 0.0)
		{
			double num13 = Math.Sqrt((0.0 - num5) / 3.0);
			double num14 = Math.Atan2(Math.Sqrt(0.0 - num8), 0.0 - num9) / 3.0;
			double num15 = Math.Cos(num14);
			double num16 = Math.Sin(num14);
			double num17 = Math.Sqrt(3.0);
			return new double[3]
			{
				2.0 * num13 * num15 - num7,
				(0.0 - num13) * (num15 + num17 * num16) - num7,
				(0.0 - num13) * (num15 - num17 * num16) - num7
			};
		}
		double num18 = ((!(num9 >= 0.0)) ? Math.Pow(0.0 - num9, 1.0 / 3.0) : (0.0 - Math.Pow(num9, 1.0 / 3.0)));
		return new double[2]
		{
			2.0 * num18 - num7,
			0.0 - num18 - num7
		};
	}

	private double[] x83430fc058f45868()
	{
		double[] result = new double[0];
		double num = x053586dbe742afc9[4];
		double num2 = x053586dbe742afc9[3] / num;
		double num3 = x053586dbe742afc9[2] / num;
		double num4 = x053586dbe742afc9[1] / num;
		double num5 = x053586dbe742afc9[0] / num;
		double[] array = new xed704ccd900d004b(1.0, -1.0 * num3, num2 * num4 - 4.0 * num5, -1.0 * num2 * num2 * num5 + 4.0 * num3 * num5 - num4 * num4).x13a183ac9f4a54f7();
		double num6 = array[0];
		double num7 = num2 * num2 / 4.0 - num3 + num6;
		if (Math.Abs(num7) <= 9.999999974752427E-07)
		{
			num7 = 0.0;
		}
		if (num7 > 0.0)
		{
			result = x038bb63414475115(num2, num3, num4, num7);
		}
		else if (!(num7 < 0.0))
		{
			result = xf1d67721e67a3ade(num2, num3, num5, num6);
		}
		return result;
	}

	private static double[] xf1d67721e67a3ade(double x4d24b19fa0071c07, double x360bf7f1eb33feef, double xe0d4e42c58260d99, double x1e218ceaee1bb583)
	{
		double[] array = new double[0];
		double num = x1e218ceaee1bb583 * x1e218ceaee1bb583 - 4.0 * xe0d4e42c58260d99;
		if (num >= -9.999999974752427E-07)
		{
			if (num < 0.0)
			{
				num = 0.0;
			}
			num = 2.0 * Math.Sqrt(num);
			double num2 = 3.0 * x4d24b19fa0071c07 * x4d24b19fa0071c07 / 4.0 - 2.0 * x360bf7f1eb33feef;
			int num3 = ((num2 + num >= 9.999999974752427E-07) ? 2 : 0);
			num3 += ((num2 - num >= 9.999999974752427E-07) ? 2 : 0);
			array = new double[num3];
			int num4 = 0;
			if (num2 + num >= 9.999999974752427E-07)
			{
				double num5 = Math.Sqrt(num2 + num);
				array[num4++] = (0.0 - x4d24b19fa0071c07) / 4.0 + num5 / 2.0;
				array[num4++] = (0.0 - x4d24b19fa0071c07) / 4.0 - num5 / 2.0;
			}
			if (num2 - num >= 9.999999974752427E-07)
			{
				double num6 = Math.Sqrt(num2 - num);
				array[num4++] = (0.0 - x4d24b19fa0071c07) / 4.0 + num6 / 2.0;
				array[num4++] = (0.0 - x4d24b19fa0071c07) / 4.0 - num6 / 2.0;
			}
		}
		return array;
	}

	private static void xf2e9aa9ef93dea3d(double x4d24b19fa0071c07, double x73f821c71fe1e676, ArrayList xd559aa34776631a5)
	{
		xd559aa34776631a5.Add((0.0 - x4d24b19fa0071c07) / 4.0 + x73f821c71fe1e676 / 2.0);
		xd559aa34776631a5.Add((0.0 - x4d24b19fa0071c07) / 4.0 - x73f821c71fe1e676 / 2.0);
	}

	private static double[] x038bb63414475115(double x4d24b19fa0071c07, double x360bf7f1eb33feef, double x17a676523ef9e177, double xb8701e9d1882fa5e)
	{
		double num = Math.Sqrt(xb8701e9d1882fa5e);
		double num2 = 3.0 * x4d24b19fa0071c07 * x4d24b19fa0071c07 / 4.0 - num * num - 2.0 * x360bf7f1eb33feef;
		double num3 = (4.0 * x4d24b19fa0071c07 * x360bf7f1eb33feef - 8.0 * x17a676523ef9e177 - x4d24b19fa0071c07 * x4d24b19fa0071c07 * x4d24b19fa0071c07) / (4.0 * num);
		double num4 = num2 + num3;
		double num5 = num2 - num3;
		if (Math.Abs(num4) <= 9.999999974752427E-07)
		{
			num4 = 0.0;
		}
		if (Math.Abs(num5) <= 9.999999974752427E-07)
		{
			num5 = 0.0;
		}
		int num6 = ((num4 >= 0.0) ? 2 : 0);
		num6 += ((num5 >= 0.0) ? 2 : 0);
		double[] array = new double[num6];
		int num7 = 0;
		if (num4 >= 0.0)
		{
			double num8 = Math.Sqrt(num4);
			array[num7++] = (0.0 - x4d24b19fa0071c07) / 4.0 + (num + num8) / 2.0;
			array[num7++] = (0.0 - x4d24b19fa0071c07) / 4.0 + (num - num8) / 2.0;
		}
		if (num5 >= 0.0)
		{
			double num9 = Math.Sqrt(num5);
			array[num7++] = (0.0 - x4d24b19fa0071c07) / 4.0 + (0.0 - num - num9) / 2.0;
			array[num7++] = (0.0 - x4d24b19fa0071c07) / 4.0 + (num9 - num) / 2.0;
		}
		return array;
	}

	private static void xbbb9bb9ffdc8f888(double x4d24b19fa0071c07, double xfbf34718e704c6bc, double x0078185e1040c523, bool xd04bb563a4875e52, ArrayList xd559aa34776631a5)
	{
		xd559aa34776631a5.Add((0.0 - x4d24b19fa0071c07) / 4.0 + (xd04bb563a4875e52 ? (xfbf34718e704c6bc + x0078185e1040c523) : (0.0 - xfbf34718e704c6bc - x0078185e1040c523)) / 2.0);
		xd559aa34776631a5.Add((0.0 - x4d24b19fa0071c07) / 4.0 + (xd04bb563a4875e52 ? (xfbf34718e704c6bc - x0078185e1040c523) : (x0078185e1040c523 - xfbf34718e704c6bc)) / 2.0);
	}
}
