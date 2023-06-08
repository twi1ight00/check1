using System;
using ns187;

namespace ns186;

internal class Class5022 : Class5003
{
	public override int imethod_0()
	{
		return 1;
	}

	public override Class5024 imethod_2(Class5024[] args, Class5750 pInfo)
	{
		double num = (double)args[0].vmethod_9();
		double num2 = Math.Floor(num + 0.5);
		if (num2 == 0.0 && num < 0.0)
		{
			num2 = 0.0 - num2;
		}
		return Class5048.smethod_0(num2);
	}
}
