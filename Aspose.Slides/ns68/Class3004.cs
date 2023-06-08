using System;

namespace ns68;

internal sealed class Class3004
{
	public static bool smethod_0(Class3007 x, Class3007 y)
	{
		if (Math.Abs(x.X - y.X) <= 1E-07)
		{
			return Math.Abs(x.Y - y.Y) <= 1E-07;
		}
		return false;
	}
}
