using ns171;
using ns176;
using ns178;
using ns187;
using ns190;

namespace ns191;

internal class Class5126 : Class5125, Interface224
{
	private Class5045 class5045_0;

	private Interface182 interface182_0;

	private Interface182 interface182_1;

	private int int_5;

	private Interface182 interface182_2;

	private Class5045 class5045_1;

	private int int_6;

	private int int_7;

	private string string_7;

	private int int_8;

	private Interface182 interface182_3;

	public Class5126(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		class5045_0 = pList.method_6(Enum679.const_18).vmethod_3();
		interface182_0 = pList.method_6(Enum679.const_79).vmethod_0();
		interface182_1 = pList.method_6(Enum679.const_81).vmethod_0();
		int_5 = pList.method_6(Enum679.const_174).imethod_0();
		interface182_2 = pList.method_6(Enum679.const_202).vmethod_0();
		class5045_1 = pList.method_6(Enum679.const_214).vmethod_3();
		int_6 = pList.method_6(Enum679.const_256).imethod_0();
		int_7 = pList.method_6(Enum679.const_302).imethod_0();
		int_8 = pList.method_6(Enum679.const_332).imethod_0();
		interface182_3 = pList.method_6(Enum679.const_351).vmethod_0();
		string_7 = pList.method_6(Enum679.const_319).vmethod_13();
		if (string_7 == null || string_7.Length == 0)
		{
			method_15("src");
		}
	}

	internal override void vmethod_10()
	{
		base.vmethod_10();
		vmethod_3().vmethod_64(this);
	}

	internal override void vmethod_11()
	{
		vmethod_3().vmethod_65(this);
		base.vmethod_11();
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		method_11(loc, nsURI, localName);
	}

	public string method_53()
	{
		return string_7;
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
		return interface182_2;
	}

	public Interface182 imethod_5()
	{
		return interface182_3;
	}

	public Interface182 imethod_6()
	{
		return interface182_0;
	}

	public Interface182 imethod_7()
	{
		return interface182_1;
	}

	public int imethod_8()
	{
		return int_7;
	}

	public int imethod_9()
	{
		return int_6;
	}

	public int imethod_10()
	{
		return int_5;
	}

	public int imethod_11()
	{
		return int_8;
	}

	public override string vmethod_23()
	{
		return "http://xmlgraphics.apache.org/fop/extensions";
	}

	public override string vmethod_22()
	{
		return "fox";
	}

	public override string vmethod_21()
	{
		return "external-document";
	}
}
