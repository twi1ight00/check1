using System;
using System.Collections;

namespace ns2;

internal class Class1665
{
	public static double smethod_0(double double_0)
	{
		double num = double_0 - 0.5;
		double num3;
		if (Math.Abs(num) <= 0.425)
		{
			double num2 = 0.180625 - num * num;
			num3 = num * (((((((num2 * 2509.0809287301227 + 33430.57558358813) * num2 + 67265.7709270087) * num2 + 45921.95393154987) * num2 + 13731.69376550946) * num2 + 1971.5909503065513) * num2 + 133.14166789178438) * num2 + 3.3871328727963665) / (((((((num2 * 5226.495278852854 + 28729.085735721943) * num2 + 39307.89580009271) * num2 + 21213.794301586597) * num2 + 5394.196021424751) * num2 + 687.1870074920579) * num2 + 42.31333070160091) * num2 + 1.0);
		}
		else
		{
			double num2 = ((!(num > 0.0)) ? double_0 : (1.0 - double_0));
			num2 = Math.Sqrt(0.0 - Math.Log(num2));
			if (num2 <= 5.0)
			{
				num2 += -1.6;
				num3 = (((((((num2 * 0.0007745450142783414 + 0.022723844989269184) * num2 + 0.2417807251774506) * num2 + 1.2704582524523684) * num2 + 3.6478483247632045) * num2 + 5.769497221460691) * num2 + 4.630337846156546) * num2 + 1.4234371107496835) / (((((((num2 * 1.0507500716444169E-09 + 0.0005475938084995345) * num2 + 0.015198666563616457) * num2 + 0.14810397642748008) * num2 + 0.6897673349851) * num2 + 1.6763848301838038) * num2 + 2.053191626637759) * num2 + 1.0);
			}
			else
			{
				num2 += -5.0;
				num3 = (((((((num2 * 2.0103343992922881E-07 + 2.7115555687434876E-05) * num2 + 0.0012426609473880784) * num2 + 0.026532189526576124) * num2 + 0.29656057182850487) * num2 + 1.7848265399172913) * num2 + 5.463784911164114) * num2 + 6.657904643501103) / (((((((num2 * 2.0442631033899397E-15 + 1.421511758316446E-07) * num2 + 1.8463183175100548E-05) * num2 + 0.0007868691311456133) * num2 + 0.014875361290850615) * num2 + 0.1369298809227358) * num2 + 0.599832206555888) * num2 + 1.0);
			}
			if (num < 0.0)
			{
				num3 = 0.0 - num3;
			}
		}
		return num3;
	}

	public static double smethod_1(double double_0, double double_1, double double_2)
	{
		return smethod_0(double_0) * double_2 + double_1;
	}

	public static double smethod_2(double double_0, double double_1, double double_2, bool bool_0)
	{
		if (!bool_0)
		{
			return smethod_5((double_0 - double_1) / double_2) / double_2;
		}
		return 0.5 + smethod_6((double_0 - double_1) / double_2);
	}

	public static double smethod_3(double double_0)
	{
		return 0.5 + smethod_6(double_0);
	}

	public static double smethod_4(double double_0, ArrayList arrayList_0, ArrayList arrayList_1)
	{
		int count = arrayList_0.Count;
		double num = 0.0;
		double num2 = (double)arrayList_1[0];
		double_0 += 1.0;
		for (int i = 0; i < count; i++)
		{
			num += (double)arrayList_0[i] / Math.Pow(double_0, ((double)arrayList_1[i] - num2) / 365.0);
		}
		return num;
	}

	private static double smethod_5(double double_0)
	{
		return 0.3989422804014327 * Math.Exp((0.0 - double_0 * double_0) / 2.0);
	}

	private static double smethod_6(double double_0)
	{
		double[] double_ = new double[12]
		{
			0.3989422804014327, -0.06649038006690546, 0.00997355701003582, -0.00118732821548045, 0.00011543468761616, -9.4446562595E-06, 6.6596935163E-07, -4.122667415E-08, 2.27352982E-09, 1.1301172E-10,
			5.11243E-12, -2.1218E-13
		};
		double[] double_2 = new double[24]
		{
			0.4772498680518208, 0.05399096651318805, -0.05399096651318805, 0.02699548325659403, -0.00449924720943234, -0.00224962360471617, 0.0013497741628297, -0.0001178374269137, -0.00011515930357476, 3.704737285544E-05,
			2.82690796889E-06, -3.54513195524E-06, 3.7669563126E-07, 1.9202407921E-07, -5.22690859E-08, -4.91799345E-09, 3.66377919E-09, -1.5981997E-10, -1.7381238E-10, 2.624031E-11,
			5.60919E-12, -1.72127E-12, -8.634E-14, 7.894E-14
		};
		double[] double_3 = new double[21]
		{
			0.4999683287581669, 0.00013383022576489, -0.00026766045152977, 0.00033457556441221, -0.00028996548915725, 0.00018178605666397, -8.252863922168E-05, 2.551802519049E-05, -3.91665839292E-06, -7.4018205222E-07,
			6.4422023359E-07, -1.737015534E-07, 9.09595465E-09, 9.44943118E-09, -3.29957075E-09, 2.9492075E-10, 1.1874477E-10, -4.420396E-11, 3.61422E-12, 1.43638E-12,
			-4.5848E-13
		};
		double[] double_4 = new double[5] { -1.0, 1.0, -3.0, 15.0, -105.0 };
		double num = Math.Abs(double_0);
		double num2 = (short)smethod_7(num);
		double num3 = 0.0;
		num3 = ((num2 == 0.0) ? (smethod_9(double_, 11, num * num) * num) : ((num2 >= 1.0 && num2 <= 2.0) ? smethod_9(double_2, 23, num - 2.0) : ((!(num2 >= 3.0) || !(num2 <= 4.0)) ? (0.5 + smethod_5(num) * smethod_9(double_4, 4, 1.0 / (num * num)) / num) : smethod_9(double_3, 20, num - 4.0))));
		if (double_0 < 0.0)
		{
			return 0.0 - num3;
		}
		return num3;
	}

	private static double smethod_7(double double_0)
	{
		double num = Math.Floor(double_0);
		if (smethod_8(double_0 - 1.0, num) && !smethod_8(double_0, num))
		{
			return num + 1.0;
		}
		return num;
	}

	private static bool smethod_8(double double_0, double double_1)
	{
		if (double_0 == double_1)
		{
			return true;
		}
		double num = double_0 - double_1;
		return ((num < 0.0) ? (0.0 - num) : num) < ((double_0 < 0.0) ? (0.0 - double_0) : double_0) * 3.552713678800501E-15;
	}

	private static double smethod_9(double[] double_0, int int_0, double double_1)
	{
		double num = double_0[int_0];
		for (int num2 = int_0 - 1; num2 >= 0; num2--)
		{
			num = double_0[num2] + num * double_1;
		}
		return num;
	}
}
