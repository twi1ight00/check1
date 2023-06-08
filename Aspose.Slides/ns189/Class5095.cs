using ns171;
using ns178;
using ns187;

namespace ns189;

internal class Class5095 : Class5094
{
	private int int_1;

	private int int_2;

	private Class5043 class5043_0;

	private Class5043 class5043_1;

	private Class5043 class5043_2;

	public Class5095(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		int_1 = pList.method_5(95).imethod_0();
		class5043_0 = pList.method_5(133).vmethod_6();
		class5043_1 = pList.method_5(131).vmethod_6();
		class5043_2 = pList.method_5(132).vmethod_6();
	}

	public Class5043 method_48()
	{
		return class5043_0;
	}

	public Class5043 method_49()
	{
		return class5043_1;
	}

	public Class5043 method_50()
	{
		return class5043_2;
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI) && !method_33(nsURI, localName))
		{
			method_11(loc, nsURI, localName);
		}
	}

	internal override void vmethod_11()
	{
		if (class5088_2 == null)
		{
			method_13("(%block;)+");
		}
	}

	public override string vmethod_21()
	{
		return "float";
	}

	public override int vmethod_24()
	{
		return 15;
	}

	public int method_51()
	{
		return int_2;
	}

	public int method_52()
	{
		return int_1;
	}
}
