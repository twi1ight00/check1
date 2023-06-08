using System;
using ns187;

namespace ns186;

internal class Class5016 : Class5003
{
	public override int imethod_0()
	{
		return 1;
	}

	public override Class5024 imethod_2(Class5024[] args, Class5750 pInfo)
	{
		object obj = args[0].vmethod_9();
		if (obj == null)
		{
			throw new Exception55("Non number operand to ceiling function");
		}
		return Class5048.smethod_0(Math.Ceiling((double)obj));
	}
}
