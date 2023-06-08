using System.Collections;
using ns175;
using ns200;

namespace ns201;

internal class Class5369 : Class5368
{
	private static string[] string_0 = new string[1] { "application/X-fop-ex-aps" };

	public override Interface177 vmethod_0(Class5738 userAgent)
	{
		return new Class5363(userAgent, userAgent.object_0 as ArrayList, userAgent.SplitPages);
	}

	public override Interface202 vmethod_3(Class5738 userAgent)
	{
		return new Class5472(userAgent);
	}

	public override bool vmethod_1()
	{
		return true;
	}

	public override string[] vmethod_2()
	{
		return string_0;
	}
}
