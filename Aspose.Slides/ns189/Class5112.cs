using ns171;
using ns178;
using ns187;

namespace ns189;

internal class Class5112 : Class5094, Interface222
{
	private Class5715 class5715_0;

	public Class5112(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		class5715_0 = Class5715.smethod_0(pList);
	}

	internal override void vmethod_10()
	{
		vmethod_3().vmethod_56(this);
	}

	internal override void vmethod_11()
	{
		if (class5088_2 == null)
		{
			method_13("(%block;)+");
		}
		vmethod_3().vmethod_57(this);
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI) && !method_33(nsURI, localName))
		{
			method_11(loc, nsURI, localName);
		}
	}

	public override string vmethod_21()
	{
		return "footnote-body";
	}

	public override int vmethod_24()
	{
		return 25;
	}

	public Class5715 imethod_0()
	{
		return class5715_0;
	}
}
