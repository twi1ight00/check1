using ns171;
using ns178;
using ns187;

namespace ns189;

internal class Class5113 : Class5094, Interface222
{
	private Class5715 class5715_0;

	private Class5046 class5046_0;

	public Class5113(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		class5715_0 = Class5715.smethod_0(pList);
		class5046_0 = pList.method_6(Enum679.const_231).vmethod_5();
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			method_11(loc, nsURI, localName);
		}
	}

	public Class5046 method_48()
	{
		return class5046_0;
	}

	public override string vmethod_21()
	{
		return "initial-property-set";
	}

	public override int vmethod_24()
	{
		return 34;
	}

	public Class5715 imethod_0()
	{
		return class5715_0;
	}
}
