using ns171;
using ns178;
using ns189;

namespace ns190;

internal class Class5099 : Class5097
{
	public Class5099(Class5088 parent)
		: base(parent)
	{
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI) && !method_34(nsURI, localName))
		{
			method_11(loc, nsURI, localName);
		}
	}

	public override string vmethod_21()
	{
		return "title";
	}

	public override int vmethod_24()
	{
		return 80;
	}
}
