using System;

namespace ns12;

internal class Class1657
{
	private static double double_0 = Math.Sqrt(2.0);

	private static double double_1 = Math.Sqrt(Math.PI);

	private static double[] double_2;

	private static int int_0 = 32;

	private static int int_1 = 2 * int_0;

	private static double[] double_3 = new double[32]
	{
		1.0, 1.0, 2.0, 6.0, 24.0, 120.0, 720.0, 5040.0, 40320.0, 362880.0,
		3628800.0, 39916800.0, 479001600.0, 6227020800.0, 87178291200.0, 1307674368000.0, 20922789888000.0, 355687428096000.0, 6402373705728000.0, 1.21645100408832E+17,
		2.43290200817664E+18, 5.109094217170944E+19, 1.1240007277776077E+21, 2.585201673888498E+22, 6.204484017332394E+23, 1.5511210043330986E+25, 4.0329146112660565E+26, 1.0888869450418352E+28, 3.0488834461171387E+29, 8.841761993739702E+30,
		2.6525285981219107E+32, 8.222838654177922E+33
	};

	private static double[] double_4 = new double[6] { -39.69683028665376, 220.9460984245205, -275.9285104469687, 138.357751867269, -30.66479806614716, 2.506628277459239 };

	private static double[] double_5 = new double[5] { -54.47609879822406, 161.5858368580409, -155.6989798598866, 66.80131188771972, -13.28068155288572 };

	private static double[] double_6 = new double[6] { -0.007784894002430293, -0.3223964580411365, -2.400758277161838, -2.549732539343734, 4.374664141464968, 2.938163982698783 };

	private static double[] double_7 = new double[4] { 0.007784695709041462, 0.3224671290700398, 2.445134137142996, 3.754408661907416 };

	private static int int_2 = 32;

	private static double[] double_8 = new double[32]
	{
		0.0, 1.0, 1.5, 1.8333333333333333, 2.0833333333333335, 2.283333333333333, 2.45, 2.592857142857143, 2.717857142857143, 2.828968253968254,
		2.9289682539682538, 3.019877344877345, 3.103210678210678, 3.180133755133755, 3.2515623265623264, 3.3182289932289932, 3.3807289932289932, 3.4395525226407577, 3.4951080781963135, 3.547739657143682,
		3.597739657143682, 3.6453587047627294, 3.690813250217275, 3.73429151108684, 3.7759581777535067, 3.8159581777535068, 3.8544197162150455, 3.8914567532520823, 3.927171038966368, 3.961653797587058,
		3.994987130920391, 4.02724519543652
	};

	private static void smethod_0(string string_0, int int_3)
	{
		Console.WriteLine(string_0 + int_3);
	}

	private static double smethod_1(double[] double_9, int int_3, double[] double_10, int int_4, double double_11)
	{
		double num = double_9[int_3 - 1];
		for (int num2 = int_3 - 1; num2 > 0; num2--)
		{
			num = double_11 * num + double_9[num2 - 1];
		}
		double num3 = double_10[int_4 - 1];
		for (int num4 = int_4 - 1; num4 > 0; num4--)
		{
			num3 = double_11 * num3 + double_10[num4 - 1];
		}
		return num / num3;
	}

	private static double smethod_2(double double_9)
	{
		double[] double_10 = new double[8] { 3.3871328727963665, 133.14166789178438, 1971.5909503065513, 13731.69376550946, 45921.95393154987, 67265.7709270087, 33430.57558358813, 2509.0809287301227 };
		double[] double_11 = new double[8] { 1.0, 42.31333070160091, 687.1870074920579, 5394.196021424751, 21213.794301586597, 39307.89580009271, 28729.085735721943, 5226.495278852854 };
		double double_12 = 0.180625 - double_9 * double_9;
		return double_9 * smethod_1(double_10, 8, double_11, 8, double_12);
	}

	private static double smethod_3(double double_9)
	{
		double[] double_10 = new double[8] { 1.4234371107496835, 4.630337846156546, 5.769497221460691, 3.6478483247632045, 1.2704582524523684, 0.2417807251774506, 0.022723844989269184, 0.0007745450142783414 };
		double[] double_11 = new double[8] { 1.0, 2.053191626637759, 1.6763848301838038, 0.6897673349851, 0.14810397642748008, 0.015198666563616457, 0.0005475938084995345, 1.0507500716444169E-09 };
		return smethod_1(double_10, 8, double_11, 8, double_9 - 1.6);
	}

	private static double smethod_4(double double_9)
	{
		double[] double_10 = new double[8] { 6.657904643501103, 5.463784911164114, 1.7848265399172913, 0.29656057182850487, 0.026532189526576124, 0.0012426609473880784, 2.7115555687434876E-05, 2.0103343992922881E-07 };
		double[] double_11 = new double[8] { 1.0, 0.599832206555888, 0.1369298809227358, 0.014875361290850615, 0.0007868691311456133, 1.8463183175100548E-05, 1.421511758316446E-07, 2.0442631033899397E-15 };
		return smethod_1(double_10, 8, double_11, 8, double_9 - 5.0);
	}

	private static double smethod_5(double double_9)
	{
		double num = double_9 - 0.5;
		if (double_9 == 1.0)
		{
			return 100000.0;
		}
		if (double_9 == 0.0)
		{
			return -100000.0;
		}
		if (Math.Abs(num) <= 0.425)
		{
			return smethod_2(num);
		}
		double d = ((double_9 < 0.5) ? double_9 : (1.0 - double_9));
		double num2 = Math.Sqrt(0.0 - Math.Log(d));
		double num3 = ((!(num2 <= 5.0)) ? smethod_4(num2) : smethod_3(num2));
		if (double_9 < 0.5)
		{
			return 0.0 - num3;
		}
		return num3;
	}

	public static double smethod_6(int int_3)
	{
		if (int_3 < 0)
		{
			throw new ArgumentOutOfRangeException("value", "ArgumentPositive");
		}
		if (int_3 <= 1)
		{
			return 0.0;
		}
		if (int_3 >= int_1)
		{
			return smethod_8((double)int_3 + 1.0);
		}
		if (double_2 == null)
		{
			double_2 = new double[int_1];
		}
		if (double_2[int_3] == 0.0)
		{
			return double_2[int_3] = smethod_8((double)int_3 + 1.0);
		}
		return double_2[int_3];
	}

	public static double smethod_7(int int_3, int int_4)
	{
		if (int_4 >= 0 && int_3 >= 0 && int_4 <= int_3)
		{
			return Math.Floor(0.5 + Math.Exp(smethod_6(int_3) - smethod_6(int_4) - smethod_6(int_3 - int_4)));
		}
		return 0.0;
	}

	public static double smethod_8(double double_9)
	{
		double[] array = new double[6] { 76.18009172947146, -86.50532032941678, 24.01409824083091, -1.231739572450155, 0.001208650973866179, -5.395239384953E-06 };
		double num;
		double num2 = (num = double_9);
		double num3 = num + 5.5;
		num3 -= (num + 0.5) * Math.Log(num3);
		double num4 = 1.000000000190015;
		for (int i = 0; i <= 5; i++)
		{
			num4 += array[i] / (num2 += 1.0);
		}
		return 0.0 - num3 + Math.Log(2.5066282746310007 * num4 / num);
	}

	public static double smethod_9(double double_9)
	{
		if (double_9 > 0.0)
		{
			return Math.Exp(smethod_8(double_9));
		}
		double num = 1.0 - double_9;
		double num2 = Math.Sin(Math.PI * num);
		if (Class1656.smethod_3(0.0, num2))
		{
			return double.NaN;
		}
		return Math.PI / (num2 * Math.Exp(smethod_8(num)));
	}

	public static double smethod_10(double double_9, double double_10)
	{
		int num = 1000;
		double num2 = Class1656.double_0;
		double num3 = double.Epsilon / num2;
		if (!(double_9 < 0.0) && double_10 >= 0.0)
		{
			double num4 = smethod_8(double_9);
			if (double_10 < double_9 + 1.0)
			{
				if (double_10 <= 0.0)
				{
					return 0.0;
				}
				double num5 = double_9;
				double num6;
				double num7 = (num6 = 1.0 / double_9);
				for (int i = 0; i < num; i++)
				{
					num5 += 1.0;
					num6 *= double_10 / num5;
					num7 += num6;
					if (Math.Abs(num6) < Math.Abs(num7) * num2 || i == num - 1)
					{
						return num7 * Math.Exp(0.0 - double_10 + double_9 * Math.Log(double_10) - num4);
					}
				}
			}
			else
			{
				double num8 = double_10 + 1.0 - double_9;
				double num9 = 1.0 / num3;
				double num10 = 1.0 / num8;
				double num11 = num10;
				for (int j = 1; j <= num; j++)
				{
					double num12 = (double)(-j) * ((double)j - double_9);
					num8 += 2.0;
					num10 = num12 * num10 + num8;
					if (Math.Abs(num10) < num3)
					{
						num10 = num3;
					}
					num9 = num8 + num12 / num9;
					if (Math.Abs(num9) < num3)
					{
						num9 = num3;
					}
					num10 = 1.0 / num10;
					double num13 = num10 * num9;
					num11 *= num13;
					if (Math.Abs(num13 - 1.0) <= num2 || j == num - 1)
					{
						return 1.0 - Math.Exp(0.0 - double_10 + double_9 * Math.Log(double_10) - num4) * num11;
					}
				}
			}
			throw new ArgumentException("ArgumentTooLargeForIterationLimit", "a");
		}
		throw new ArgumentOutOfRangeException("" + double_9 + " " + double_10);
	}

	internal static double smethod_11(double double_9, double double_10, double double_11)
	{
		if (double_9 < 0.0)
		{
			return 0.0;
		}
		if (double_9 == 0.0)
		{
			if (double_10 == 1.0)
			{
				return 1.0 / double_11;
			}
			return 0.0;
		}
		if (double_10 == 1.0)
		{
			return Math.Exp((0.0 - double_9) / double_11) / double_11;
		}
		double num = smethod_8(double_10);
		return Math.Exp((double_10 - 1.0) * Math.Log(double_9 / double_11) - double_9 / double_11 - num) / double_11;
	}

	public static double smethod_12(double double_9, double double_10, double double_11)
	{
		if (double_9 == 1.0)
		{
			double_9 -= 1E-06;
		}
		else if (double_9 == 0.0)
		{
			return 0.0;
		}
		double num2;
		if (double_9 < 0.05)
		{
			double num = Math.Exp((smethod_8(double_10) + Math.Log(double_9)) / double_10);
			num2 = num;
		}
		else if (double_9 > 0.95)
		{
			double num3 = 0.0 - Math.Log(1.0 - double_9, Math.E) + smethod_8(double_10);
			num2 = num3;
		}
		else
		{
			double num4 = smethod_5(double_9);
			double num5 = ((num4 < -0.5 * Math.Sqrt(double_10)) ? double_10 : (Math.Sqrt(double_10) * num4 + double_10));
			num2 = num5;
		}
		int num6 = 0;
		double num7;
		double num9;
		do
		{
			num7 = double_9 - Class1668.smethod_13(num2, double_10, 1.0);
			double val = smethod_11(num2, double_10, 1.0);
			if (num7 == 0.0 || num6++ > 64)
			{
				break;
			}
			double num8 = num7 / Math.Max(2.0 * Math.Abs(num7 / num2), val);
			num9 = num8;
			double num10 = (0.0 - ((double_10 - 1.0) / num2 - 1.0)) * num8 * num8 / 4.0;
			double num11 = num9;
			if (Math.Abs(num10) < 0.5 * Math.Abs(num9))
			{
				num11 += num10;
			}
			num2 = ((!(num2 + num11 > 0.0)) ? (num2 / 2.0) : (num2 + num11));
		}
		while (!(Math.Abs(num9) <= 1E-10 * num2));
		if (Math.Abs(num7) > 1E-10 * double_9)
		{
			Console.WriteLine("inverse failed to converge");
		}
		return double_11 * num2;
	}

	public static double smethod_13(double double_9, double double_10)
	{
		return Math.Exp(smethod_8(double_9) + smethod_8(double_10) - smethod_8(double_9 + double_10));
	}

	public static double smethod_14(double double_9, double double_10)
	{
		return smethod_8(double_9) + smethod_8(double_10) - smethod_8(double_9 + double_10);
	}

	public static double smethod_15(double double_9, double double_10, double double_11)
	{
		if (double_9 <= 0.0)
		{
			return 0.0;
		}
		if (double_9 >= 1.0)
		{
			return 1.0;
		}
		return smethod_17(1.0, 0.0, double_10, double_11, double_9);
	}

	private static double smethod_16(double double_9, double double_10, double double_11, double double_12)
	{
		int num = 512;
		double num2 = double.NegativeInfinity;
		int i = 0;
		double num3 = 1.0;
		double num4 = 1.0 - (double_9 + double_10) * double_11 / (double_9 + 1.0);
		if (Math.Abs(num4) < num2)
		{
			num4 = double.NaN;
		}
		num4 = 1.0 / num4;
		double num5 = num4;
		for (; i < num; i++)
		{
			int num6 = i + 1;
			double num7 = (double)num6 * (double_10 - (double)num6) * double_11 / ((double_9 - 1.0 + (double)(2 * num6)) * (double_9 + (double)(2 * num6)));
			num4 = 1.0 + num7 * num4;
			num3 = 1.0 + num7 / num3;
			if (Math.Abs(num4) < num2)
			{
				num4 = double.NaN;
			}
			if (Math.Abs(num3) < num2)
			{
				num3 = double.NaN;
			}
			num4 = 1.0 / num4;
			double num8 = num4 * num3;
			num5 *= num8;
			num7 = (0.0 - (double_9 + (double)num6)) * (double_9 + double_10 + (double)num6) * double_11 / ((double_9 + (double)(2 * num6)) * (double_9 + (double)(2 * num6) + 1.0));
			num4 = 1.0 + num7 * num4;
			num3 = 1.0 + num7 / num3;
			if (Math.Abs(num4) < num2)
			{
				num4 = double.NaN;
			}
			if (Math.Abs(num3) < num2)
			{
				num3 = double.NaN;
			}
			num4 = 1.0 / num4;
			num8 = num4 * num3;
			num5 *= num8;
			if (Math.Abs(num8 - 1.0) < 1E-323 || num5 * Math.Abs(num8 - 1.0) < double_12)
			{
				break;
			}
		}
		if (i >= num)
		{
			return double.NaN;
		}
		return num5;
	}

	private static double smethod_17(double double_9, double double_10, double double_11, double double_12, double double_13)
	{
		if (double_13 == 0.0)
		{
			return double_9 * 0.0 + double_10;
		}
		if (double_13 == 1.0)
		{
			return double_9 * 1.0 + double_10;
		}
		if (double_11 > 100000.0 && double_12 < 10.0 && double_13 > double_11 / (double_11 + double_12))
		{
			double num = double_11 + (double_12 - 1.0) / 2.0;
			return double_9 * (1.0 - Class1668.smethod_12(double_12, (0.0 - num) * Math.Log(double_13))) + double_10;
		}
		if (double_12 > 100000.0 && double_11 < 10.0 && double_13 < double_12 / (double_11 + double_12))
		{
			double num2 = double_12 + (double_11 - 1.0) / 2.0;
			return double_9 * Class1668.smethod_12(double_11, (0.0 - num2) * Math.Log(1.0 - double_13)) + double_10;
		}
		double num3 = smethod_14(double_11, double_12);
		double d = 0.0 - num3 + double_11 * Math.Log(double_13) + double_12 * Math.Log(1.0 - double_13);
		double num4 = Math.Exp(d);
		if (double_13 < (double_11 + 1.0) / (double_11 + double_12 + 2.0))
		{
			double double_14 = Math.Abs(double_10 / (double_9 * num4 / double_11)) * double.Epsilon;
			double num5 = smethod_16(double_11, double_12, double_13, double_14);
			return double_9 * (num4 * num5 / double_11) + double_10;
		}
		double double_15 = Math.Abs((double_9 + double_10) / (double_9 * num4 / double_12)) * double.Epsilon;
		double num6 = smethod_16(double_12, double_11, 1.0 - double_13, double_15);
		double num7 = num4 * num6 / double_12;
		if (double_9 == 0.0 - double_10)
		{
			return (0.0 - double_9) * num7;
		}
		return double_9 * (1.0 - num7) + double_10;
	}

	private static double smethod_18(double double_9, double double_10, double double_11, double double_12, double double_13, double double_14)
	{
		double num = 0.0;
		double num2 = 1.0;
		while (true)
		{
			if (Math.Abs(num2 - num) > double_13)
			{
				double num3 = smethod_15(double_9, double_11, double_12);
				if (!(Math.Abs(num3 - double_10) >= double_14))
				{
					break;
				}
				if (num3 < double_10)
				{
					num = double_9;
				}
				else if (num3 > double_10)
				{
					num2 = double_9;
				}
				double_9 = 0.5 * (num + num2);
				continue;
			}
			return double_9;
		}
		return double_9;
	}

	private static double smethod_19(double double_9, double double_10, double double_11)
	{
		if (!(double_9 < 0.0) && double_9 <= 1.0)
		{
			double num = smethod_8(double_10 + double_11);
			double num2 = smethod_8(double_10);
			double num3 = smethod_8(double_11);
			if (double_9 != 0.0 && double_9 != 1.0)
			{
				return Math.Exp(num - num2 - num3 + Math.Log(double_9) * (double_10 - 1.0) + Math.Log(1.0 - double_9) * (double_11 - 1.0));
			}
			return Math.Exp(num - num2 - num3) * Math.Pow(double_9, double_10 - 1.0) * Math.Pow(1.0 - double_9, double_11 - 1.0);
		}
		return 0.0;
	}

	public static double smethod_20(double double_9, double double_10, double double_11)
	{
		if (double_9 < 0.0 || double_9 > 1.0)
		{
			smethod_0("P must be in range 0 < P < 1", 1);
		}
		if (double_10 < 0.0)
		{
			smethod_0("a < 0", 1);
		}
		if (double_11 < 0.0)
		{
			smethod_0("b < 0", 1);
		}
		if (double_9 == 0.0)
		{
			return 0.0;
		}
		if (double_9 == 1.0)
		{
			return 1.0;
		}
		if (double_9 > 0.5)
		{
			return smethod_21(1.0 - double_9, double_10, double_11);
		}
		double num = double_10 / (double_10 + double_11);
		double num6;
		if (double_9 < 0.1)
		{
			double num2 = smethod_8(double_10 + double_11);
			double num3 = smethod_8(double_10);
			double num4 = smethod_8(double_11);
			double num5 = (Math.Log(double_10) + num3 + num4 - num2 + Math.Log(double_9)) / double_10;
			if (num5 <= 0.0)
			{
				num6 = Math.Exp(num5);
				num6 *= Math.Pow(1.0 - num6, (0.0 - (double_11 - 1.0)) / double_10);
			}
			else
			{
				num6 = num;
			}
			if (num6 > num)
			{
				num6 = num;
			}
		}
		else
		{
			num6 = num;
		}
		num6 = smethod_18(num6, double_9, double_10, double_11, 0.01, 0.01);
		int num7 = 0;
		double num8;
		double num10;
		do
		{
			num8 = double_9 - smethod_15(num6, double_10, double_11);
			double val = smethod_19(num6, double_10, double_11);
			if (num8 == 0.0 || num7++ > 64)
			{
				break;
			}
			double num9 = num8 / Math.Max(2.0 * Math.Abs(num8 / num6), val);
			num10 = num9;
			double num11 = (0.0 - ((double_10 - 1.0) / num6 - (double_11 - 1.0) / (1.0 - num6))) * num9 * num9 / 2.0;
			double num12 = num10;
			num12 = ((!(Math.Abs(num11) < Math.Abs(num10))) ? (num12 * (2.0 * Math.Abs(num10 / num11))) : (num12 + num11));
			num6 = ((!(num6 + num12 > 0.0) || !(num6 + num12 < 1.0)) ? (Math.Sqrt(num6) * Math.Sqrt(num)) : (num6 + num12));
		}
		while (!(Math.Abs(num10) <= 1E-10 * num6));
		if (Math.Abs(num8) > 1E-10 * double_9)
		{
			smethod_0("inverse failed to converge", 1);
		}
		return num6;
	}

	public static double smethod_21(double double_9, double double_10, double double_11)
	{
		if (double_9 < 0.0 || double_9 > 1.0)
		{
			smethod_0("Q must be inside range 0 < Q < 1", 1);
		}
		if (double_10 < 0.0)
		{
			smethod_0("a < 0", 1);
		}
		if (double_11 < 0.0)
		{
			smethod_0("b < 0", 1);
		}
		if (double_9 == 0.0)
		{
			return 1.0;
		}
		if (double_9 == 1.0)
		{
			return 0.0;
		}
		if (double_9 > 0.5)
		{
			return smethod_20(1.0 - double_9, double_10, double_11);
		}
		return 1.0 - smethod_20(double_9, double_11, double_10);
	}
}
