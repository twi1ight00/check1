using System;
using ns2;

namespace ns12;

internal class Class420 : Class416
{
	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	private double double_4;

	public override double vmethod_1(double double_5)
	{
		double num = Math.Pow(1.0 + double_5, double_0 - 1.0);
		double num2 = double_2 / (double_5 * double_5);
		double num3 = double_0 * double_1 + double_0 * double_2 * (double_4 + 1.0 / double_5) - double_2 / double_5 - num2;
		return num3 * num + num2;
	}

	public override double vmethod_0(double double_5)
	{
		double num = Math.Pow(1.0 + double_5, double_0);
		return double_1 * num + double_2 * (1.0 + double_5 * double_4) * (num - 1.0) / double_5 + double_3;
	}

	internal object Calculate(double double_5, double double_6, double double_7, double double_8, double double_9, double double_10)
	{
		double_0 = double_5;
		double_2 = double_6;
		double_1 = double_7;
		double_3 = double_8;
		double_4 = double_9;
		int flag = 0;
		object result = method_0(double_10, 1E-07, 20, out flag);
		if (flag == 0)
		{
			return result;
		}
		return "#NUM!";
	}
}
