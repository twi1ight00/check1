using ns175;
using ns187;

namespace ns186;

internal class Class5023 : Class5003
{
	public override int imethod_0()
	{
		return 1;
	}

	public override Class5024 imethod_2(Class5024[] args, Class5750 pInfo)
	{
		Class5738 foUserAgent = ((pInfo == null) ? null : ((pInfo.method_2() == null) ? null : pInfo.method_2().method_2()));
		return Class5040.smethod_0(foUserAgent, string.Concat("system-color(", args[0], ")"));
	}
}
