using ns176;
using ns187;

namespace ns186;

internal class Class5015 : Class5003
{
	public override int imethod_0()
	{
		return 1;
	}

	public override Class5024 imethod_2(Class5024[] args, Class5750 propInfo)
	{
		Interface181 @interface = args[0].vmethod_10();
		if (@interface == null)
		{
			throw new Exception55("Non numeric operand to abs function");
		}
		return (Class5024)Class5747.smethod_10(@interface);
	}
}
