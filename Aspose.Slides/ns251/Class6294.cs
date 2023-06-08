using System;
using ns224;

namespace ns251;

internal class Class6294 : Class6293
{
	public override Class5998 imethod_0(Class5998 color)
	{
		return new Class5998((int)Math.Round(255.0 * base.Value.Fraction), color);
	}

	protected override Class6293 vmethod_0()
	{
		return new Class6294();
	}
}
