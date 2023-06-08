using ns224;
using ns252;

namespace ns251;

internal class Class6313 : Class6293
{
	public Class6313()
	{
	}

	public Class6313(Class6329 value)
	{
		base.Value = value;
	}

	public override Class5998 imethod_0(Class5998 color)
	{
		int r = method_0(color.R);
		int g = method_0(color.G);
		int b = method_0(color.B);
		return new Class5998(color.A, r, g, b);
	}

	private int method_0(int i)
	{
		double num = Class6322.smethod_0(i);
		num *= base.Value.Fraction;
		if (num < 0.0)
		{
			num = 0.0;
		}
		if (num > 1.0)
		{
			num = 1.0;
		}
		return Class6322.smethod_1(num);
	}

	protected override Class6293 vmethod_0()
	{
		return new Class6313();
	}
}
