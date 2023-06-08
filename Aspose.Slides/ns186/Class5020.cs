using ns176;
using ns187;

namespace ns186;

internal class Class5020 : Class5003
{
	public override int imethod_0()
	{
		return 2;
	}

	public override Class5024 imethod_2(Class5024[] args, Class5750 pInfo)
	{
		Interface181 @interface = args[0].vmethod_10();
		Interface181 interface2 = args[1].vmethod_10();
		if (@interface == null || interface2 == null)
		{
			throw new Exception55("Non numeric operands to min function");
		}
		return (Class5024)Class5747.smethod_16(@interface, interface2);
	}
}
