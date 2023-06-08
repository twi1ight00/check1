using System.Text;
using ns175;
using ns187;

namespace ns186;

internal class Class5007 : Class5003
{
	public override int imethod_0()
	{
		return 4;
	}

	public override Class5024 imethod_2(Class5024[] args, Class5750 pInfo)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(string.Concat("cmyk(", args[0], ",", args[1], ",", args[2], ",", args[3], ")"));
		Class5738 foUserAgent = ((pInfo == null) ? null : ((pInfo.method_2() == null) ? null : pInfo.method_2().method_2()));
		return Class5040.smethod_0(foUserAgent, stringBuilder.ToString());
	}
}
