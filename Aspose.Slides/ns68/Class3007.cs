using System.Collections.Generic;

namespace ns68;

internal sealed class Class3007
{
	public class Class3008 : IComparer<Class3007>
	{
		int IComparer<Class3007>.Compare(Class3007 x, Class3007 y)
		{
			if (x.double_0 < y.double_0)
			{
				return -1;
			}
			if (x.double_0 > y.double_0)
			{
				return 1;
			}
			if (x.double_1 < y.double_1)
			{
				return -1;
			}
			if (x.double_1 > y.double_1)
			{
				return 1;
			}
			return 0;
		}
	}

	internal bool bool_0;

	internal Class2998 class2998_0;

	private double double_0;

	private double double_1;

	internal double X => double_0;

	internal double Y => double_1;

	internal Class3007(double x, double y)
	{
		double_0 = x;
		double_1 = y;
		bool_0 = true;
		class2998_0 = new Class2998();
	}
}
