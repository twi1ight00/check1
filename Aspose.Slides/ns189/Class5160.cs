using System.Collections;
using ns171;
using ns178;
using ns182;
using ns187;

namespace ns189;

internal class Class5160 : Class5094, Interface222, Interface229
{
	private Class5715 class5715_0;

	private Class5703 class5703_0;

	private Class5718 class5718_0;

	private int int_1;

	private int int_2;

	private Class5043 class5043_0;

	private Class5043 class5043_1;

	private Class5043 class5043_2;

	private Class5132 class5132_0;

	private Class5131 class5131_0;

	public Class5160(Class5088 parent)
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
	}

	internal override void vmethod_10()
	{
		base.vmethod_10();
		vmethod_3().vmethod_38(this);
	}

	internal override void vmethod_11()
	{
		if (class5132_0 == null || class5131_0 == null)
		{
			method_13("marker* (list-item-label,list-item-body)");
		}
		vmethod_3().vmethod_39(this);
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if (!"http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			return;
		}
		if (localName.Equals("marker"))
		{
			if (class5132_0 != null)
			{
				method_9(loc, "fo:marker", "fo:list-item-label");
			}
		}
		else if (localName.Equals("list-item-label"))
		{
			if (class5132_0 != null)
			{
				method_8(loc, "fo:list-item-label");
			}
		}
		else if (localName.Equals("list-item-body"))
		{
			if (class5132_0 == null)
			{
				method_9(loc, "fo:list-item-label", "fo:list-item-body");
			}
			else if (class5131_0 != null)
			{
				method_8(loc, "fo:list-item-body");
			}
		}
		else
		{
			method_11(loc, nsURI, localName);
		}
	}

	internal override void vmethod_12(Class5088 child)
	{
		switch (child.vmethod_24())
		{
		case 43:
			class5132_0 = (Class5132)child;
			break;
		case 42:
			class5131_0 = (Class5131)child;
			break;
		case 44:
			method_30((Class5108)child);
			break;
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

	public Class5132 method_53()
	{
		return class5132_0;
	}

	public Class5131 method_54()
	{
		return class5131_0;
	}

	public override string vmethod_21()
	{
		return "list-item";
	}

	public override int vmethod_24()
	{
		return 41;
	}

	protected override Stack vmethod_27(Stack ranges, Class5727 currentRange)
	{
		Class5132 @class = method_53();
		if (@class != null)
		{
			ranges = @class.method_21(ranges);
		}
		Class5131 class2 = method_54();
		if (class2 != null)
		{
			ranges = class2.method_21(ranges);
		}
		return ranges;
	}
}
