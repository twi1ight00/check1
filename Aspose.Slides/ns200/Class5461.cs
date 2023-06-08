using System.IO;
using ns175;
using ns184;

namespace ns200;

internal class Class5461 : Interface193
{
	private Class5738 class5738_0;

	public Class5461(Class5738 userAgent)
	{
		class5738_0 = userAgent;
	}

	public Stream imethod_0(string href)
	{
		return class5738_0.method_28(href, class5738_0.method_0().method_51().method_0());
	}

	public bool imethod_1()
	{
		return class5738_0.method_51();
	}
}
