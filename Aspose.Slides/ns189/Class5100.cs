using ns171;
using ns176;
using ns178;
using ns187;

namespace ns189;

internal class Class5100 : Class5097
{
	private Interface182 interface182_0;

	private int int_1;

	private Interface182 interface182_1;

	private int int_2;

	private Interface182 interface182_2;

	private int int_3;

	private bool bool_1;

	private bool bool_2 = true;

	private Class5024 class5024_0;

	private Interface182 interface182_3;

	private Interface182 interface182_4;

	private Class5024 class5024_1;

	private Class5024 class5024_2;

	private int int_4;

	public Class5024 method_57()
	{
		return class5024_0;
	}

	public int method_58(Interface172 percentBaseContext)
	{
		return interface182_3.imethod_6(percentBaseContext);
	}

	public int method_59(Interface172 percentBaseContext)
	{
		return interface182_4.imethod_6(percentBaseContext);
	}

	public Class5024 method_60()
	{
		return class5024_2;
	}

	public Class5024 method_61()
	{
		return class5024_1;
	}

	public Class5100(Class5088 parent)
		: base(parent)
	{
	}

	public Interface182 method_62()
	{
		return interface182_2;
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		interface182_0 = pList.method_5(3).vmethod_0();
		int_1 = pList.method_5(4).imethod_0();
		interface182_1 = pList.method_5(15).vmethod_0();
		int_2 = pList.method_5(88).imethod_0();
		int_3 = pList.method_5(257).imethod_0();
		interface182_2 = pList.method_5(264).vmethod_0();
		int_4 = pList.method_5(266).imethod_0();
		class5024_0 = pList.method_5(281);
		interface182_3 = pList.method_5(283).vmethod_0();
		interface182_4 = pList.method_5(284).vmethod_0();
		class5024_2 = pList.method_5(286);
		class5024_1 = pList.method_5(287);
	}

	public int method_63()
	{
		return int_4;
	}

	internal override void vmethod_10()
	{
		base.vmethod_10();
		int num = method_37(39);
		int num2 = method_37(24);
		int num3 = method_37(36);
		if (num > 0)
		{
			if (num3 < 0 || (num3 > 0 && num3 > num))
			{
				bool_2 = false;
			}
		}
		else if (num2 > 0 && (num3 < 0 || num3 > num2))
		{
			bool_2 = false;
		}
		vmethod_3().vmethod_20(this);
	}

	internal override void vmethod_11()
	{
		base.vmethod_11();
		vmethod_3().vmethod_21(this);
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
				method_9(loc, "fo:marker", "(#PCDATA|%inline;|%block;)");
			}
		}
		else if (!method_35(nsURI, localName))
		{
			method_11(loc, nsURI, localName);
		}
		else if (!bool_2 && method_33(nsURI, localName) && !method_36(nsURI, localName))
		{
			method_12(loc, method_17(), nsURI, localName, "rule.inlineContent");
		}
		else
		{
			bool_1 = true;
		}
	}

	public Interface182 method_64()
	{
		return interface182_0;
	}

	public int method_65()
	{
		return int_1;
	}

	public Interface182 method_66()
	{
		return interface182_1;
	}

	public int method_67()
	{
		return int_2;
	}

	public int method_68()
	{
		return int_3;
	}

	public override string vmethod_21()
	{
		return "inline";
	}

	public override int vmethod_24()
	{
		return 35;
	}
}
