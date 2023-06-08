using ns171;
using ns176;
using ns178;
using ns187;
using ns205;

namespace ns189;

internal class Class5114 : Class5094
{
	private Interface182 interface182_0;

	private int int_1;

	private Interface182 interface182_1;

	private Class5045 class5045_0;

	private Class5703 class5703_0;

	private Class5719 class5719_0;

	private int int_2;

	private int int_3;

	private int int_4;

	private Class5045 class5045_1;

	private Class5043 class5043_0;

	private Class5046 class5046_0;

	private int int_5;

	private Interface181 interface181_0;

	private Class5678 class5678_0;

	private bool bool_1;

	public Class5114(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		interface182_0 = pList.method_6(Enum679.const_4).vmethod_0();
		int_1 = pList.method_6(Enum679.const_5).imethod_0();
		interface182_1 = pList.method_6(Enum679.const_16).vmethod_0();
		class5045_0 = pList.method_6(Enum679.const_18).vmethod_3();
		class5703_0 = pList.method_17();
		class5719_0 = pList.method_21();
		int_2 = pList.method_6(Enum679.const_72).imethod_0();
		int_3 = pList.method_6(Enum679.const_174).imethod_0();
		int_4 = pList.method_6(Enum679.const_175).imethod_0();
		class5045_1 = pList.method_6(Enum679.const_214).vmethod_3();
		class5043_0 = pList.method_6(Enum679.const_218).vmethod_6();
		class5046_0 = pList.method_6(Enum679.const_231).vmethod_5();
		int_5 = pList.method_6(Enum679.const_256).imethod_0();
		interface181_0 = pList.method_6(Enum679.const_284).vmethod_10();
		class5678_0 = new Class5678(Class5445.smethod_1(pList.method_6(Enum679.const_354).imethod_0()));
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
			method_13("marker* (%block;)+");
		}
	}

	public Interface182 method_48()
	{
		return interface182_0;
	}

	public int method_49()
	{
		return int_1;
	}

	public Interface182 method_50()
	{
		return interface182_1;
	}

	public Class5045 method_51()
	{
		return class5045_0;
	}

	public int method_52()
	{
		return int_2;
	}

	public Class5703 method_53()
	{
		return class5703_0;
	}

	public Class5719 method_54()
	{
		return class5719_0;
	}

	public int method_55()
	{
		return int_3;
	}

	public int method_56()
	{
		return int_4;
	}

	public Class5043 method_57()
	{
		return class5043_0;
	}

	public Class5045 method_58()
	{
		return class5045_1;
	}

	public Class5046 method_59()
	{
		return class5046_0;
	}

	public int method_60()
	{
		return int_5;
	}

	public int method_61()
	{
		return interface181_0.imethod_5();
	}

	public Class5444 method_62()
	{
		return class5678_0.imethod_0();
	}

	public Class5444 method_63()
	{
		return class5678_0.imethod_3();
	}

	public Class5444 method_64()
	{
		return class5678_0.imethod_4();
	}

	public Class5444 method_65()
	{
		return class5678_0.imethod_5();
	}

	public Class5444 method_66()
	{
		return class5678_0.imethod_6();
	}

	public Class5445 method_67()
	{
		return class5678_0.imethod_7();
	}

	public override string vmethod_21()
	{
		return "inline-container";
	}

	public override int vmethod_24()
	{
		return 36;
	}

	public override bool vmethod_26(int boundary)
	{
		return false;
	}
}
