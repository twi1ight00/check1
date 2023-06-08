using ns171;
using ns178;

namespace ns189;

internal class Class5117 : Class5094
{
	private static bool bool_1;

	public Class5117(Class5088 parent)
		: base(parent)
	{
		if (!bool_1)
		{
			method_5().imethod_13(this, method_17(), method_17(), method_1());
			bool_1 = true;
		}
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			method_11(loc, nsURI, localName);
		}
	}

	public override string vmethod_21()
	{
		return "multi-property-set";
	}

	public override int vmethod_24()
	{
		return 47;
	}
}
