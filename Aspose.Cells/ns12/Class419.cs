using Aspose.Cells;
using ns2;

namespace ns12;

internal class Class419 : Class416
{
	private double double_0;

	private double[] double_1;

	public override double vmethod_1(double double_2)
	{
		double num = 0.0;
		double num2 = (1.0 + double_2) * (1.0 + double_2);
		for (int i = 0; i < double_1.Length; i++)
		{
			num -= (double)(i + 1) * double_1[i] / num2;
			num2 *= 1.0 + double_2;
		}
		return num;
	}

	public override double vmethod_0(double double_2)
	{
		double num = double_0;
		double num2 = 1.0 + double_2;
		for (int i = 0; i < double_1.Length; i++)
		{
			num += double_1[i] / num2;
			num2 *= 1.0 + double_2;
		}
		return num;
	}

	internal object Calculate(double double_2, double[] double_3, double double_4)
	{
		double_0 = double_2;
		double_1 = double_3;
		double num = double_2;
		for (int i = 0; i < double_3.Length; i++)
		{
			num += double_3[i];
		}
		if (num == 0.0)
		{
			return 0.0;
		}
		if (num > 0.0 && double_4 < 0.0)
		{
			double_4 = 0.1;
		}
		double num2 = 0.0;
		int flag = 1;
		num2 = method_0(double_4, 1E-05, 60, out flag);
		if (flag == 2)
		{
			num2 = method_0(double_4 / 2.0, 1E-05, 60, out flag);
		}
		if (flag == 0)
		{
			if (num2 + 1.0 < 0.0)
			{
				return ErrorType.Number;
			}
			return num2;
		}
		return ErrorType.Number;
	}
}
