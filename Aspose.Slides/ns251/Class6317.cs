using ns224;

namespace ns251;

internal class Class6317 : Class6292
{
	public override Class5998 imethod_0(Class5998 color)
	{
		double num = 0.299 * (double)color.R + 0.587 * (double)color.G + 0.114 * (double)color.B;
		return new Class5998(color.A, (int)num, (int)num, (int)num);
	}

	public override Interface275 Clone()
	{
		return new Class6317();
	}
}
