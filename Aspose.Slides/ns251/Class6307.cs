using System;
using ns224;

namespace ns251;

internal class Class6307 : Class6293
{
	public override Class5998 imethod_0(Class5998 color)
	{
		return new Class5998(color.A, (int)Math.Round(255.0 * base.Value.Fraction), color.G, color.B);
	}

	protected override Class6293 vmethod_0()
	{
		return new Class6307();
	}
}
