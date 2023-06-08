using System;

namespace ns2;

internal abstract class Class416
{
	public Class416()
	{
	}

	public abstract double vmethod_0(double double_0);

	public abstract double vmethod_1(double double_0);

	public double method_0(double xnew, double tolerance, int imax, out int flag)
	{
		flag = 1;
		for (int i = 0; i < imax; i++)
		{
			double num = xnew;
			double num2 = vmethod_1(num);
			if (Math.Abs(num2) >= double.Epsilon)
			{
				xnew = num - vmethod_0(num) / num2;
				if (!(Math.Abs(xnew - num) > tolerance))
				{
					flag = 0;
					break;
				}
				continue;
			}
			flag = 2;
			return xnew;
		}
		return xnew;
	}
}
