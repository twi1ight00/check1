using System;
using ns224;

namespace ns251;

internal class Class6297 : Class6293
{
	public override Class5998 imethod_0(Class5998 color)
	{
		return new Class5998(color.A, color.R, color.G, (int)Math.Round(255.0 * base.Value.Fraction));
	}

	protected override Class6293 vmethod_0()
	{
		return new Class6297();
	}
}
