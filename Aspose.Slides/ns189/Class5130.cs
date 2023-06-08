using ns171;
using ns178;
using ns187;

namespace ns189;

internal abstract class Class5130 : Class5094, Interface222
{
	private Class5715 class5715_0;

	private Class5043 class5043_0;

	private bool bool_1;

	public Class5130(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		class5715_0 = Class5715.smethod_0(pList);
		class5043_0 = pList.method_6(Enum679.const_218).vmethod_6();
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

	internal override void vmethod_11()
	{
		if (!bool_1)
		{
			string contentModel = "marker* (%block;)+";
			method_5().imethod_3(this, method_17(), contentModel, canRecover: true, method_1());
		}
	}

	public Class5715 imethod_0()
	{
		return class5715_0;
	}

	public Class5043 method_48()
	{
		return class5043_0;
	}
}
