using ns171;
using ns176;
using ns178;
using ns187;

namespace ns189;

internal class Class5159 : Class5094, Interface222, Interface229
{
	private Class5715 class5715_0;

	private Class5703 class5703_0;

	private Class5718 class5718_0;

	private int int_1;

	private int int_2;

	private Class5043 class5043_0;

	private Class5043 class5043_1;

	private Class5043 class5043_2;

	private Interface182 interface182_0;

	private Interface182 interface182_1;

	private bool bool_1;

	public Class5159(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		class5715_0 = Class5715.smethod_0(pList);
		class5703_0 = pList.method_17();
		class5718_0 = pList.method_20();
		int_1 = pList.method_6(Enum679.const_59).imethod_0();
		int_2 = pList.method_6(Enum679.const_60).imethod_0();
		class5043_0 = pList.method_6(Enum679.const_218).vmethod_6();
		class5043_1 = pList.method_6(Enum679.const_219).vmethod_6();
		class5043_2 = pList.method_6(Enum679.const_220).vmethod_6();
		interface182_0 = pList.method_6(Enum679.const_358).vmethod_0();
		interface182_1 = pList.method_6(Enum679.const_359).vmethod_0();
	}

	internal override void vmethod_10()
	{
		base.vmethod_10();
		vmethod_3().vmethod_36(this);
	}

	internal override void vmethod_11()
	{
		if (!bool_1)
		{
			method_13("marker* (list-item)+");
		}
		vmethod_3().vmethod_37(this);
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
				method_9(loc, "fo:marker", "fo:list-item");
			}
		}
		else if (localName.Equals("list-item"))
		{
			bool_1 = true;
		}
		else
		{
			method_11(loc, nsURI, localName);
		}
	}

	public Class5715 imethod_0()
	{
		return class5715_0;
	}

	public Class5718 method_48()
	{
		return class5718_0;
	}

	public Class5703 method_49()
	{
		return class5703_0;
	}

	public int imethod_1()
	{
		return int_1;
	}

	public int imethod_2()
	{
		return int_2;
	}

	public Class5043 method_50()
	{
		return class5043_1;
	}

	public Class5043 method_51()
	{
		return class5043_2;
	}

	public Class5043 method_52()
	{
		return class5043_0;
	}

	public Interface182 method_53()
	{
		return interface182_0;
	}

	public Interface182 method_54()
	{
		return interface182_1;
	}

	public override string vmethod_21()
	{
		return "list-block";
	}

	public override int vmethod_24()
	{
		return 40;
	}
}
