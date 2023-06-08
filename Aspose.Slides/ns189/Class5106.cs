using System.Drawing;
using ns171;
using ns176;
using ns178;
using ns187;

namespace ns189;

internal class Class5106 : Class5096, Interface222, Interface229
{
	private bool bool_1;

	private bool bool_2;

	private Class5715 class5715_0;

	private Class5703 class5703_0;

	private Class5087 class5087_0;

	private Class5716 class5716_0;

	private Class5717 class5717_0;

	private Class5718 class5718_0;

	private Class5679 class5679_0;

	private int int_1;

	private int int_2;

	private Color color_0;

	private int int_3;

	private Interface181 interface181_0;

	private int int_4;

	private Class5043 class5043_0;

	private Class5043 class5043_1;

	private Class5043 class5043_2;

	private Interface182 interface182_0;

	private int int_5;

	private Class5046 class5046_0;

	private int int_6;

	private int int_7;

	private Interface181 interface181_1;

	private int int_8;

	private int int_9;

	private int int_10;

	private int int_11;

	private Interface182 interface182_1;

	private int int_12;

	private Interface181 interface181_2;

	private int int_13;

	private int int_14;

	private Interface181 interface181_3;

	private int int_15;

	public Class5106(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		class5715_0 = Class5715.smethod_0(pList);
		class5703_0 = pList.method_17();
		class5087_0 = pList.method_18();
		class5716_0 = pList.method_25();
		class5717_0 = pList.method_19();
		class5718_0 = pList.method_20();
		class5679_0 = pList.method_23();
		int_1 = pList.method_5(58).imethod_0();
		int_2 = pList.method_5(59).imethod_0();
		color_0 = pList.method_5(72).vmethod_1(method_2());
		int_3 = pList.method_5(118).imethod_0();
		interface181_0 = pList.method_5(119).vmethod_10();
		int_4 = pList.method_5(130).imethod_0();
		class5043_0 = pList.method_5(131).vmethod_6();
		class5043_1 = pList.method_5(132).vmethod_6();
		class5043_2 = pList.method_5(133).vmethod_6();
		interface182_0 = pList.method_5(135).vmethod_0();
		int_5 = pList.method_5(143).imethod_0();
		class5046_0 = pList.method_5(144).vmethod_5();
		int_6 = pList.method_5(145).imethod_0();
		int_7 = pList.method_5(146).imethod_0();
		interface181_1 = pList.method_5(168).vmethod_10();
		int_8 = pList.method_5(262).imethod_0();
		int_9 = pList.method_5(226).imethod_0();
		int_10 = pList.method_5(245).imethod_0();
		int_11 = pList.method_5(246).imethod_0();
		interface182_1 = pList.method_5(250).vmethod_0();
		int_12 = pList.method_5(261).imethod_0();
		interface181_2 = pList.method_5(263).vmethod_10();
		int_13 = pList.method_5(266).imethod_0();
		int_14 = pList.method_5(273).imethod_0();
		interface181_3 = pList.method_5(269).vmethod_10();
		int_15 = pList.method_5(257).imethod_0();
	}

	internal override void vmethod_10()
	{
		base.vmethod_10();
		vmethod_3().vmethod_16(this);
	}

	internal override void vmethod_11()
	{
		base.vmethod_11();
		vmethod_3().vmethod_17(this);
	}

	public Class5715 imethod_0()
	{
		return class5715_0;
	}

	public Class5718 method_50()
	{
		return class5718_0;
	}

	public Class5703 method_51()
	{
		return class5703_0;
	}

	public Class5087 method_52()
	{
		return class5087_0;
	}

	public Class5716 method_53()
	{
		return class5716_0;
	}

	public Class5717 method_54()
	{
		return class5717_0;
	}

	public int imethod_1()
	{
		return int_1;
	}

	public int imethod_2()
	{
		return int_2;
	}

	public Interface181 method_55()
	{
		return interface181_0;
	}

	public Class5043 method_56()
	{
		return class5043_1;
	}

	public Class5043 method_57()
	{
		return class5043_2;
	}

	public Class5043 method_58()
	{
		return class5043_0;
	}

	public int method_59()
	{
		return interface181_1.imethod_5();
	}

	public int method_60()
	{
		return interface181_2.imethod_5();
	}

	public int method_61()
	{
		return int_7;
	}

	public Color method_62()
	{
		return color_0;
	}

	public Class5046 method_63()
	{
		return class5046_0;
	}

	public int method_64()
	{
		return int_9;
	}

	public int method_65()
	{
		return int_10;
	}

	public int method_66()
	{
		return int_11;
	}

	public Interface182 method_67()
	{
		return interface182_1;
	}

	public Interface182 method_68()
	{
		return interface182_0;
	}

	public int method_69()
	{
		return int_13;
	}

	public Interface181 method_70()
	{
		return interface181_3;
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if (!"http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			return;
		}
		if ("marker".Equals(localName))
		{
			if (bool_1 || bool_2)
			{
				method_9(loc, "fo:marker", "initial-property-set? (#PCDATA|%inline;|%block;)");
			}
		}
		else if ("initial-property-set".Equals(localName))
		{
			if (bool_2)
			{
				method_8(loc, "fo:initial-property-set");
			}
			else if (bool_1)
			{
				method_9(loc, "fo:initial-property-set", "(#PCDATA|%inline;|%block;)");
			}
			else
			{
				bool_2 = true;
			}
		}
		else if (method_35(nsURI, localName))
		{
			bool_1 = true;
		}
		else
		{
			method_11(loc, nsURI, localName);
		}
	}

	public int method_71()
	{
		return int_5;
	}

	public int method_72()
	{
		return int_8;
	}

	public int method_73()
	{
		return int_12;
	}

	public Class5679 method_74()
	{
		return class5679_0;
	}

	public int method_75()
	{
		return int_3;
	}

	public int method_76()
	{
		return int_4;
	}

	public int method_77()
	{
		return int_6;
	}

	public int method_78()
	{
		return int_14;
	}

	public int method_79()
	{
		return int_15;
	}

	public override Class5656 vmethod_17()
	{
		return Class5658.smethod_0();
	}

	public override string vmethod_21()
	{
		return "block";
	}

	public override int vmethod_24()
	{
		return 3;
	}
}
