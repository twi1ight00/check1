using System;
using ns2;

namespace ns12;

internal class Class418 : Class416
{
	private DateTime dateTime_0;

	private DateTime dateTime_1;

	private double double_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private double double_1;

	private double double_2;

	public Class418(DateTime dateTime_2, DateTime dateTime_3, double double_3, int int_3, int int_4, int int_5, double double_4, double double_5)
	{
		dateTime_0 = dateTime_2;
		dateTime_1 = dateTime_3;
		double_0 = double_3;
		int_0 = int_3;
		int_1 = int_4;
		int_2 = int_5;
		double_1 = double_4;
		double_2 = double_5;
	}

	public override double vmethod_1(double double_3)
	{
		return (vmethod_0(double_3 + double_2) - vmethod_0(double_3 - double_2)) / (2.0 * double_2);
	}

	public override double vmethod_0(double double_3)
	{
		return (double)Class1378.smethod_50(dateTime_0, dateTime_1, double_0, double_3, int_0, int_1, int_2) - double_1;
	}

	internal object Calculate(double double_3)
	{
		int flag = 0;
		object result = method_0(double_3, 1E-07, 20, out flag);
		if (flag == 0)
		{
			return result;
		}
		return "#NUM!";
	}
}
