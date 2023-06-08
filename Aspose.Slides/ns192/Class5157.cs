using System;
using ns171;
using ns176;
using ns178;
using ns187;

namespace ns192;

internal class Class5157 : Class5149, Interface222
{
	private Class5715 class5715_0;

	private Class5703 class5703_0;

	private Class5045 class5045_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private Interface182 interface182_0;

	private bool bool_1;

	public Class5157(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		class5715_0 = Class5715.smethod_0(pList);
		class5703_0 = pList.method_17();
		class5045_0 = pList.method_5(17).vmethod_3();
		int_2 = pList.method_5(87).imethod_0();
		int_3 = pList.method_5(90).imethod_0();
		int_7 = pList.method_5(235).imethod_0();
		if (method_58() && method_4().vmethod_24() != 79)
		{
			((Class5151)method_4()).method_57();
		}
		int_4 = pList.method_5(92).imethod_0();
		int_1 = pList.method_5(76).vmethod_10().imethod_5();
		int_5 = pList.method_5(165).vmethod_10().imethod_5();
		int_6 = pList.method_5(166).vmethod_10().imethod_5();
		interface182_0 = pList.method_5(264).vmethod_0();
	}

	internal override void vmethod_10()
	{
		base.vmethod_10();
		vmethod_3().vmethod_34(this);
	}

	internal override void vmethod_11()
	{
		base.vmethod_11();
		vmethod_3().vmethod_35(this);
	}

	public override void vmethod_14()
	{
		if (!bool_1)
		{
			method_14("marker* (%block;)+", canRecover: true);
		}
		if ((method_58() || method_59()) && method_4().vmethod_24() == 79)
		{
			Interface245 @interface = Class5754.smethod_0(method_2().method_48());
			@interface.imethod_4(this, method_1());
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

	public override bool vmethod_30()
	{
		return true;
	}

	public Class5715 imethod_0()
	{
		return class5715_0;
	}

	public override Class5703 vmethod_33()
	{
		return class5703_0;
	}

	public int method_51()
	{
		return int_1;
	}

	public bool method_52()
	{
		return int_3 == 130;
	}

	public int method_53()
	{
		return Math.Max(int_5, 1);
	}

	public int method_54()
	{
		return Math.Max(int_6, 1);
	}

	public Class5045 method_55()
	{
		return class5045_0;
	}

	public int method_56()
	{
		return int_2;
	}

	public Interface182 method_57()
	{
		return interface182_0;
	}

	public bool method_58()
	{
		return int_7 == 149;
	}

	public bool method_59()
	{
		return int_4 == 149;
	}

	public override string vmethod_21()
	{
		return "table-cell";
	}

	public override int vmethod_24()
	{
		return 75;
	}
}
