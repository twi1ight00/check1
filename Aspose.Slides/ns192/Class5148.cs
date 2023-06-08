using ns171;
using ns178;
using ns187;

namespace ns192;

internal class Class5148 : Class5094, Interface222
{
	private Class5715 class5715_0;

	private bool bool_1;

	private static bool bool_2;

	public Class5148(Class5088 parent)
		: base(parent)
	{
		if (!bool_2)
		{
			method_5().imethod_13(this, method_17(), "fo:table-caption", method_1());
			bool_2 = true;
		}
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		class5715_0 = Class5715.smethod_0(pList);
	}

	internal override void vmethod_11()
	{
		if (class5088_2 == null)
		{
			method_13("marker* (%block;)");
		}
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if (!"http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			return;
		}
		if (localName.Equals("marker"))
		{
			if (bool_1)
			{
				method_9(loc, "fo:marker", "(%block;)");
			}
		}
		else if (!method_33(nsURI, localName))
		{
			method_11(loc, nsURI, localName);
		}
		else
		{
			bool_1 = true;
		}
	}

	public override string vmethod_21()
	{
		return "table-caption";
	}

	public override int vmethod_24()
	{
		return 74;
	}

	public Class5715 imethod_0()
	{
		return class5715_0;
	}
}
