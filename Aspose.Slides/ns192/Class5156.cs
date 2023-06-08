using System.Collections;
using ns171;
using ns176;
using ns178;
using ns187;

namespace ns192;

internal class Class5156 : Class5149, Interface222, Interface229, Interface233
{
	private Class5715 class5715_0;

	private Class5703 class5703_0;

	private Class5718 class5718_0;

	private Class5045 class5045_0;

	private int int_1;

	private Class5044 class5044_0;

	private int int_2;

	private int int_3;

	private Class5045 class5045_1;

	private Class5043 class5043_0;

	private Class5043 class5043_1;

	private Class5043 class5043_2;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private Interface182 interface182_0;

	private Interface182 interface182_1;

	private ArrayList arrayList_1 = new ArrayList();

	private Class5714 class5714_0 = new Class5714();

	private Class5154 class5154_0;

	private Class5153 class5153_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private Class5627 class5627_0;

	private Class5634 class5634_0;

	public Class5156(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		class5715_0 = Class5715.smethod_0(pList);
		class5703_0 = pList.method_17();
		class5718_0 = pList.method_20();
		class5045_0 = pList.method_5(17).vmethod_3();
		int_1 = pList.method_5(31).imethod_0();
		class5044_0 = pList.method_5(45).vmethod_4();
		int_2 = pList.method_5(58).imethod_0();
		int_3 = pList.method_5(59).imethod_0();
		class5045_1 = pList.method_5(127).vmethod_3();
		class5043_0 = pList.method_5(131).vmethod_6();
		class5043_1 = pList.method_5(132).vmethod_6();
		class5043_2 = pList.method_5(133).vmethod_6();
		int_4 = pList.method_5(239).imethod_0();
		int_5 = pList.method_5(240).imethod_0();
		int_6 = pList.method_5(241).imethod_0();
		int_7 = pList.method_5(267).imethod_0();
		interface182_0 = pList.method_5(271).vmethod_0();
		interface182_1 = pList.method_5(272).vmethod_0();
		class5045_0.method_10(null).method_2();
		if (!method_72() && vmethod_33().method_22(Class5621.smethod_0()))
		{
			Interface245 @interface = Class5754.smethod_0(method_2().method_48());
			@interface.imethod_1(this, method_1());
		}
		class5634_0 = pList;
	}

	internal override void vmethod_10()
	{
		base.vmethod_10();
		vmethod_3().vmethod_22(this);
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if (!"http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			return;
		}
		if ("marker".Equals(localName))
		{
			if (bool_1 || bool_2 || bool_3 || bool_4)
			{
				method_9(loc, "fo:marker", "(table-column*,table-header?,table-footer?,table-body+)");
			}
		}
		else if ("table-column".Equals(localName))
		{
			bool_1 = true;
			if (bool_2 || bool_3 || bool_4)
			{
				method_9(loc, "fo:table-column", "(table-header?,table-footer?,table-body+)");
			}
		}
		else if ("table-header".Equals(localName))
		{
			if (bool_2)
			{
				method_8(loc, "table-header");
				return;
			}
			bool_2 = true;
			if (bool_3 || bool_4)
			{
				method_9(loc, "fo:table-header", "(table-footer?,table-body+)");
			}
		}
		else if ("table-footer".Equals(localName))
		{
			if (bool_3)
			{
				method_8(loc, "table-footer");
				return;
			}
			bool_3 = true;
			if (bool_4)
			{
				if (method_2().method_42())
				{
					method_10(loc, "fo:table-footer", "(table-body+)", canRecover: true);
				}
				if (!method_72())
				{
					Interface245 @interface = Class5754.smethod_0(method_2().method_48());
					@interface.imethod_3(this, method_17(), method_1());
				}
			}
		}
		else if ("table-body".Equals(localName))
		{
			bool_4 = true;
		}
		else
		{
			method_11(loc, nsURI, localName);
		}
	}

	internal override void vmethod_11()
	{
		base.vmethod_11();
		vmethod_3().vmethod_23(this);
	}

	public override void vmethod_14()
	{
		if (!bool_4)
		{
			method_13("(marker*,table-column*,table-header?,table-footer?,table-body+)");
		}
		if (!method_28())
		{
			method_4().vmethod_13(this);
		}
		else if (!vmethod_5())
		{
			class5627_0.vmethod_6();
			int num = arrayList_1.Count;
			while (--num >= 0)
			{
				((Class5158)arrayList_1[num])?.method_62();
			}
			class5634_0 = null;
			class5627_0 = null;
		}
	}

	internal override void vmethod_12(Class5088 child)
	{
		int num = child.vmethod_24();
		switch ((Enum679)num)
		{
		default:
			base.vmethod_12(child);
			break;
		case Enum679.const_77:
			bool_5 = true;
			if (!vmethod_5())
			{
				method_54((Class5158)child);
			}
			else
			{
				arrayList_1.Add(child);
			}
			break;
		case Enum679.const_74:
		case Enum679.const_78:
		case Enum679.const_79:
			if (!vmethod_5() && !bool_6)
			{
				bool_6 = true;
				if (bool_5)
				{
					method_51();
					class5627_0 = new Class5628(this);
				}
				else
				{
					class5627_0 = new Class5629(this);
				}
			}
			switch ((Enum679)num)
			{
			default:
				base.vmethod_12(child);
				break;
			case Enum679.const_78:
				class5153_0 = (Class5153)child;
				break;
			case Enum679.const_79:
				class5154_0 = (Class5154)child;
				break;
			}
			break;
		}
	}

	private void method_51()
	{
		for (int i = 0; i < arrayList_1.Count; i++)
		{
			if (arrayList_1[i] == null)
			{
				arrayList_1[i] = method_53(i + 1);
			}
		}
	}

	public Class5715 imethod_0()
	{
		return class5715_0;
	}

	public override Class5156 vmethod_32()
	{
		return this;
	}

	internal void method_52(int columnNumber)
	{
		for (int i = arrayList_1.Count + 1; i <= columnNumber; i++)
		{
			arrayList_1.Add(method_53(i));
		}
	}

	private Class5158 method_53(int colNumber)
	{
		Class5158 @class = new Class5158(this, @implicit: true);
		Class5634 propertyList = new Class5635(@class, class5634_0);
		@class.vmethod_2(propertyList);
		@class.method_55(new Class5038(1.0, @class));
		@class.method_57(colNumber);
		if (!method_72())
		{
			@class.method_51(class5711_0);
		}
		return @class;
	}

	private void method_54(Class5158 col)
	{
		int num = col.method_56();
		int num2 = col.method_58();
		while (arrayList_1.Count < num + num2 - 1)
		{
			arrayList_1.Add(null);
		}
		for (int i = num - 1; i < num + num2 - 1; i++)
		{
			arrayList_1[i] = col;
		}
		class5714_0.method_1(num, num + num2 - 1);
	}

	internal bool method_55()
	{
		return bool_5;
	}

	public bool method_56()
	{
		return int_4 == 9;
	}

	public ArrayList method_57()
	{
		return arrayList_1;
	}

	public Class5158 method_58(int index)
	{
		return (Class5158)arrayList_1[index];
	}

	public int method_59()
	{
		return arrayList_1.Count;
	}

	public Class5154 method_60()
	{
		return class5154_0;
	}

	public Class5153 method_61()
	{
		return class5153_0;
	}

	public bool method_62()
	{
		return int_6 == 149;
	}

	public bool method_63()
	{
		return int_5 == 149;
	}

	public Class5045 method_64()
	{
		return class5045_1;
	}

	public Class5045 method_65()
	{
		return class5045_0;
	}

	public Class5718 method_66()
	{
		return class5718_0;
	}

	public override Class5703 vmethod_33()
	{
		return class5703_0;
	}

	public int imethod_1()
	{
		return int_2;
	}

	public int imethod_2()
	{
		return int_3;
	}

	public Class5043 method_67()
	{
		return class5043_1;
	}

	public Class5043 method_68()
	{
		return class5043_2;
	}

	public Class5043 method_69()
	{
		return class5043_0;
	}

	public bool method_70()
	{
		if (method_69().method_8().method_2())
		{
			return !method_69().method_7().method_2();
		}
		return true;
	}

	public int method_71()
	{
		return int_1;
	}

	public bool method_72()
	{
		return method_71() == 129;
	}

	public Class5044 method_73()
	{
		return class5044_0;
	}

	public int method_74()
	{
		return int_7;
	}

	public Interface182 method_75()
	{
		return interface182_0;
	}

	public Interface182 method_76()
	{
		return interface182_1;
	}

	public override string vmethod_21()
	{
		return "table";
	}

	public override int vmethod_24()
	{
		return 71;
	}

	public override Class5088 vmethod_0(Class5088 parent, bool removeChildren)
	{
		Class5156 @class = (Class5156)base.vmethod_0(parent, removeChildren);
		if (removeChildren)
		{
			@class.arrayList_1 = new ArrayList();
			@class.bool_6 = false;
			@class.class5714_0 = new Class5714();
			@class.class5154_0 = null;
			@class.class5153_0 = null;
			@class.class5627_0 = null;
		}
		return @class;
	}

	public Class5714 imethod_3()
	{
		return class5714_0;
	}

	internal Class5627 method_77()
	{
		return class5627_0;
	}
}
