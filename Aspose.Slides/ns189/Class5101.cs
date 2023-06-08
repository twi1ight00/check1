using System.Collections;
using ns171;
using ns182;
using ns183;
using ns187;

namespace ns189;

internal class Class5101 : Class5100
{
	private Class5024 class5024_3;

	private Class5024 class5024_4;

	private int int_5;

	private int int_6;

	public Class5101(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		class5024_3 = pList.method_5(141);
		class5024_4 = pList.method_5(265);
		int_5 = pList.method_5(86).imethod_0();
		int_6 = pList.method_5(255).imethod_0();
	}

	public Class5024 method_69()
	{
		return class5024_3;
	}

	public Class5024 method_70()
	{
		return class5024_4;
	}

	public int method_71()
	{
		return int_5;
	}

	public int method_72()
	{
		return int_6;
	}

	public override string vmethod_21()
	{
		return "bidi-override";
	}

	public override int vmethod_24()
	{
		return 2;
	}

	protected override Stack vmethod_27(Stack ranges, Class5727 currentRange)
	{
		char c = '\0';
		char c2 = '\0';
		int num = method_72();
		int num2 = method_71();
		switch (num)
		{
		case 15:
			c = ((num2 == 122) ? '\u202e' : '\u202d');
			c2 = '\u202c';
			break;
		case 38:
			c = ((num2 == 122) ? '\u202b' : '\u202a');
			c2 = '\u202c';
			break;
		}
		if (currentRange != null)
		{
			if (c != 0)
			{
				currentRange.method_2(c, this);
			}
			Interface168 @interface = vmethod_15();
			while (@interface != null && @interface.imethod_0())
			{
				ranges = ((Class5088)@interface.imethod_1()).method_21(ranges);
			}
			if (c2 != 0)
			{
				currentRange.method_2(c2, this);
			}
		}
		return ranges;
	}
}
