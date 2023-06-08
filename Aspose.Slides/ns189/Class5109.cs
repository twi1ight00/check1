using System.Collections;
using ns171;
using ns174;
using ns176;
using ns182;
using ns187;

namespace ns189;

internal abstract class Class5109 : Class5094, Interface222, Interface223, Interface224
{
	private Class5715 class5715_0;

	private Class5703 class5703_0;

	private Interface182 interface182_0;

	private int int_1;

	private Interface182 interface182_1;

	private Class5045 class5045_0;

	private Interface182 interface182_2;

	private Interface182 interface182_3;

	private int int_2;

	private int int_3;

	private Interface182 interface182_4;

	private string string_3;

	private Class5045 class5045_1;

	private Class5043 class5043_0;

	private Class5043 class5043_1;

	private Class5046 class5046_0;

	private int int_4;

	private int int_5;

	private int int_6;

	private Interface182 interface182_5;

	private string string_4;

	private Interface244 interface244_0;

	public Class5109(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		class5715_0 = Class5715.smethod_0(pList);
		class5703_0 = pList.method_17();
		interface182_0 = pList.method_5(3).vmethod_0();
		int_1 = pList.method_5(4).imethod_0();
		interface182_1 = pList.method_5(15).vmethod_0();
		class5045_0 = pList.method_5(17).vmethod_3();
		interface182_2 = pList.method_5(78).vmethod_0();
		interface182_3 = pList.method_5(80).vmethod_0();
		int_2 = pList.method_5(87).imethod_0();
		int_3 = pList.method_5(88).imethod_0();
		interface182_4 = pList.method_5(115).vmethod_0();
		string_3 = pList.method_5(122).vmethod_13();
		class5045_1 = pList.method_5(127).vmethod_3();
		class5043_0 = pList.method_5(132).vmethod_6();
		class5043_1 = pList.method_5(133).vmethod_6();
		class5046_0 = pList.method_5(144).vmethod_5();
		int_4 = pList.method_5(169).imethod_0();
		int_5 = pList.method_5(215).imethod_0();
		int_6 = pList.method_5(245).imethod_0();
		interface182_5 = pList.method_5(264).vmethod_0();
		if (method_2().method_54())
		{
			string_4 = pList.method_5(274).vmethod_13();
			if (string.IsNullOrEmpty(string_4))
			{
				method_5().imethod_26(this, vmethod_21(), method_1());
			}
		}
	}

	public Class5715 imethod_0()
	{
		return class5715_0;
	}

	public override string vmethod_31()
	{
		return string_3;
	}

	public Class5703 method_48()
	{
		return class5703_0;
	}

	public Class5046 method_49()
	{
		return class5046_0;
	}

	public Class5045 imethod_2()
	{
		return class5045_1;
	}

	public Class5045 imethod_3()
	{
		return class5045_0;
	}

	public Interface182 imethod_4()
	{
		return interface182_4;
	}

	public Interface182 imethod_5()
	{
		return interface182_5;
	}

	public Interface182 imethod_6()
	{
		return interface182_2;
	}

	public Interface182 imethod_7()
	{
		return interface182_3;
	}

	public int imethod_8()
	{
		return int_5;
	}

	public int imethod_9()
	{
		return int_4;
	}

	public int imethod_10()
	{
		return int_2;
	}

	public int imethod_11()
	{
		return int_6;
	}

	public Interface182 method_50()
	{
		if (interface182_0.imethod_0() == 9)
		{
			Interface182 @interface = vmethod_34();
			if (@interface != null)
			{
				return @interface;
			}
		}
		return interface182_0;
	}

	public int method_51()
	{
		return int_1;
	}

	public Interface182 method_52()
	{
		return interface182_1;
	}

	public int method_53()
	{
		return int_3;
	}

	public Class5043 method_54()
	{
		return class5043_0;
	}

	public Class5043 method_55()
	{
		return class5043_1;
	}

	public override void vmethod_29(Interface244 structureTreeElement)
	{
		interface244_0 = structureTreeElement;
	}

	public Interface244 imethod_1()
	{
		return interface244_0;
	}

	public string method_56()
	{
		return string_4;
	}

	public abstract int vmethod_32();

	public abstract int vmethod_33();

	public abstract Interface182 vmethod_34();

	public override bool vmethod_26(int boundary)
	{
		return false;
	}

	protected override Stack vmethod_27(Stack ranges, Class5727 currentRange)
	{
		currentRange?.method_2('￼', this);
		return ranges;
	}
}
