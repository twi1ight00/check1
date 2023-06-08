using ns171;
using ns176;
using ns178;
using ns187;
using ns205;

namespace ns189;

internal class Class5161 : Class5094, Interface229, Interface231
{
	private Class5673 class5673_0;

	private Class5703 class5703_0;

	private Class5087 class5087_0;

	private Class5718 class5718_0;

	private Class5045 class5045_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private Class5045 class5045_1;

	private Class5043 class5043_0;

	private Class5043 class5043_1;

	private Class5043 class5043_2;

	private int int_4;

	private Interface181 interface181_0;

	private int int_5;

	private int int_6;

	private Class5678 class5678_0;

	private Interface181 interface181_1;

	private int int_7;

	private Class5025 class5025_0;

	private bool bool_1;

	private bool bool_2;

	public bool IsBodyElement => bool_1;

	public Class5161(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		class5673_0 = pList.method_24();
		class5703_0 = pList.method_17();
		class5087_0 = pList.method_18();
		class5718_0 = pList.method_20();
		class5045_0 = pList.method_6(Enum679.const_18).vmethod_3();
		int_1 = pList.method_6(Enum679.const_59).imethod_0();
		int_2 = pList.method_6(Enum679.const_60).imethod_0();
		class5025_0 = pList.method_27();
		int_3 = pList.method_6(Enum679.const_174).imethod_0();
		class5045_1 = pList.method_6(Enum679.const_214).vmethod_3();
		class5043_0 = pList.method_6(Enum679.const_218).vmethod_6();
		class5043_1 = pList.method_6(Enum679.const_219).vmethod_6();
		class5043_2 = pList.method_6(Enum679.const_220).vmethod_6();
		int_4 = pList.method_6(Enum679.const_256).imethod_0();
		interface181_0 = pList.method_6(Enum679.const_284).vmethod_10();
		int_5 = pList.method_6(Enum679.const_313).imethod_0();
		class5678_0 = new Class5678(Class5445.smethod_1(pList.method_6(Enum679.const_354).imethod_0()));
		int_6 = pList.method_6(Enum679.const_360).imethod_0();
		interface181_1 = pList.method_5(269).vmethod_10();
		int_7 = pList.method_5(257).imethod_0();
		bool_1 = pList.method_5(298).imethod_0() == 149;
	}

	internal override void vmethod_10()
	{
		base.vmethod_10();
		vmethod_3().vmethod_18(this);
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if (!"http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			return;
		}
		if ("marker".Equals(localName))
		{
			if (class5673_0.int_0 == 1 || class5673_0.int_0 == 51)
			{
				method_5().imethod_8(this, interface243_0);
			}
			if (bool_2)
			{
				method_9(loc, "fo:marker", "(%block;)");
			}
		}
		else if (!method_33("http://www.w3.org/1999/XSL/Format", localName))
		{
			method_11(loc, "http://www.w3.org/1999/XSL/Format", localName);
		}
		else
		{
			bool_2 = true;
		}
	}

	internal override void vmethod_11()
	{
		if (!bool_2)
		{
			method_13("marker* (%block;)+");
		}
		vmethod_3().vmethod_19(this);
	}

	public override bool vmethod_30()
	{
		return true;
	}

	public Class5673 method_48()
	{
		return class5673_0;
	}

	public Class5718 method_49()
	{
		return class5718_0;
	}

	public Class5703 method_50()
	{
		return class5703_0;
	}

	public Class5087 method_51()
	{
		return class5087_0;
	}

	public Class5045 method_52()
	{
		return class5045_0;
	}

	public int method_53()
	{
		return int_3;
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
		return class5043_1;
	}

	public Class5043 method_55()
	{
		return class5043_2;
	}

	public Class5043 method_56()
	{
		return class5043_0;
	}

	public Class5045 method_57()
	{
		return class5045_1;
	}

	public int method_58()
	{
		return int_4;
	}

	public int method_59()
	{
		return interface181_0.imethod_5();
	}

	public int method_60()
	{
		return int_5;
	}

	public int method_61()
	{
		return int_6;
	}

	public Class5444 imethod_0()
	{
		return class5678_0.imethod_0();
	}

	public Class5444 imethod_3()
	{
		return class5678_0.imethod_3();
	}

	public Class5444 imethod_4()
	{
		return class5678_0.imethod_4();
	}

	public Class5444 imethod_5()
	{
		return class5678_0.imethod_5();
	}

	public Class5444 imethod_6()
	{
		return class5678_0.imethod_6();
	}

	public Class5445 imethod_7()
	{
		return class5678_0.imethod_7();
	}

	public override string vmethod_21()
	{
		return "block-container";
	}

	public override int vmethod_24()
	{
		return 4;
	}

	public Interface181 method_62()
	{
		return interface181_1;
	}

	public int method_63()
	{
		return int_7;
	}

	public Class4925 method_64()
	{
		if (class5025_0 == null)
		{
			return null;
		}
		if (class5025_0.method_2())
		{
			return null;
		}
		return class5025_0.method_3();
	}
}
