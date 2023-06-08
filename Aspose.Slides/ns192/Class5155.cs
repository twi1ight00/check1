using ns171;
using ns176;
using ns178;
using ns187;

namespace ns192;

internal class Class5155 : Class5150, Interface229
{
	private Class5045 class5045_0;

	private Class5703 class5703_0;

	private int int_1;

	private int int_2;

	private Interface182 interface182_0;

	private Class5043 class5043_0;

	private Class5043 class5043_1;

	private Class5043 class5043_2;

	public Class5155(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		class5045_0 = pList.method_5(17).vmethod_3();
		class5703_0 = pList.method_17();
		int_1 = pList.method_5(58).imethod_0();
		int_2 = pList.method_5(59).imethod_0();
		interface182_0 = pList.method_5(115).vmethod_0();
		class5043_0 = pList.method_5(131).vmethod_6();
		class5043_1 = pList.method_5(132).vmethod_6();
		class5043_2 = pList.method_5(133).vmethod_6();
		base.vmethod_2(pList);
	}

	public override void vmethod_6(string elementName, Interface243 locatoR, Interface236 attlist, Class5634 pList)
	{
		base.vmethod_6(elementName, locatoR, attlist, pList);
		if (!vmethod_5())
		{
			Class5151 @class = (Class5151)class5088_0;
			arrayList_1 = @class.arrayList_1;
			class5714_0 = @class.class5714_0;
		}
	}

	internal override void vmethod_12(Class5088 child)
	{
		if (!vmethod_5())
		{
			Class5157 cell = (Class5157)child;
			Class5151 @class = (Class5151)method_4();
			method_51(cell, @class.method_56(this));
		}
		base.vmethod_12(child);
	}

	internal override void vmethod_10()
	{
		base.vmethod_10();
		vmethod_3().vmethod_32(this);
	}

	internal override void vmethod_11()
	{
		base.vmethod_11();
		vmethod_3().vmethod_33(this);
	}

	public override void vmethod_14()
	{
		if (class5088_2 == null)
		{
			method_13("(table-cell+)");
		}
		if (!vmethod_5())
		{
			arrayList_1 = null;
			class5714_0 = null;
		}
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if (!"http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			return;
		}
		if ("marker".Equals(localName))
		{
			if (class5088_2 != null)
			{
				method_9(loc, "fo:marker", "(table-cell+)");
			}
		}
		else if (!"table-cell".Equals(localName))
		{
			method_11(loc, nsURI, localName);
		}
	}

	internal override Class5151 vmethod_34()
	{
		return (Class5151)class5088_0;
	}

	private bool method_53()
	{
		return true;
	}

	public int imethod_1()
	{
		return int_1;
	}

	public int imethod_2()
	{
		return int_2;
	}

	public Class5043 method_54()
	{
		return class5043_2;
	}

	public Class5043 method_55()
	{
		return class5043_1;
	}

	public Class5043 method_56()
	{
		return class5043_0;
	}

	public bool method_57()
	{
		if (method_56().method_8().method_2())
		{
			return !method_56().method_7().method_2();
		}
		return true;
	}

	public bool method_58()
	{
		if (method_55().method_8().method_2())
		{
			return !method_55().method_7().method_2();
		}
		return true;
	}

	public bool method_59()
	{
		if (method_54().method_8().method_2())
		{
			return !method_54().method_7().method_2();
		}
		return true;
	}

	public Class5045 method_60()
	{
		return class5045_0;
	}

	public Interface182 method_61()
	{
		return interface182_0;
	}

	public override Class5703 vmethod_33()
	{
		return class5703_0;
	}

	public override string vmethod_21()
	{
		return "table-row";
	}

	public override int vmethod_24()
	{
		return 79;
	}
}
