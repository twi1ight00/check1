using System;
using System.Collections;
using System.Drawing;
using ns171;
using ns174;
using ns176;
using ns178;
using ns182;
using ns187;

namespace ns189;

internal class Class5165 : Class5094, Interface223
{
	private class Class5659 : Class5656
	{
		private bool bool_0 = true;

		private Class5165 class5165_0;

		internal Class5659(Class5165 foChar)
		{
			class5165_0 = foChar;
		}

		public override bool imethod_0()
		{
			return bool_0;
		}

		public override char vmethod_0()
		{
			if (!bool_0)
			{
				throw new Exception("The character element not found");
			}
			bool_0 = false;
			return class5165_0.char_0;
		}

		public override void imethod_6()
		{
			class5165_0.class5088_0.vmethod_13(class5165_0);
		}

		public override void vmethod_1(char c)
		{
			class5165_0.char_0 = c;
		}
	}

	private Class5703 class5703_0;

	private Class5716 class5716_0;

	private Class5717 class5717_0;

	private Interface182 interface182_0;

	private int int_1;

	private Interface182 interface182_1;

	private char char_0;

	private Color color_0;

	private int int_2;

	private Class5043 class5043_0;

	private Class5043 class5043_1;

	private Class5024 class5024_0;

	private Class5046 class5046_0;

	private Class5720 class5720_0;

	private Class5024 class5024_1;

	private Interface244 interface244_0;

	public static int int_3 = 0;

	public static int int_4 = 1;

	public Class5165(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		class5703_0 = pList.method_17();
		class5716_0 = pList.method_25();
		class5717_0 = pList.method_19();
		interface182_0 = pList.method_5(3).vmethod_0();
		int_1 = pList.method_5(4).imethod_0();
		interface182_1 = pList.method_5(15).vmethod_0();
		char_0 = pList.method_5(69).vmethod_7();
		color_0 = pList.method_5(72).vmethod_1(method_2());
		int_2 = pList.method_5(88).imethod_0();
		class5043_0 = pList.method_5(132).vmethod_6();
		class5043_1 = pList.method_5(133).vmethod_6();
		class5024_0 = pList.method_5(141);
		class5046_0 = pList.method_5(144).vmethod_5();
		class5720_0 = pList.method_26();
		class5024_1 = pList.method_5(265);
	}

	internal override void vmethod_10()
	{
		base.vmethod_10();
		vmethod_3().vmethod_62(this);
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			method_11(loc, nsURI, localName);
		}
	}

	public override Class5656 vmethod_17()
	{
		return new Class5659(this);
	}

	public Class5703 method_48()
	{
		return class5703_0;
	}

	public Class5716 method_49()
	{
		return class5716_0;
	}

	public Class5717 method_50()
	{
		return class5717_0;
	}

	public char method_51()
	{
		return char_0;
	}

	public Color method_52()
	{
		return color_0;
	}

	public Interface182 method_53()
	{
		return interface182_0;
	}

	public int method_54()
	{
		return int_1;
	}

	public Interface182 method_55()
	{
		return interface182_1;
	}

	public int method_56()
	{
		return int_2;
	}

	public Class5024 method_57()
	{
		return class5024_0;
	}

	public Class5046 method_58()
	{
		return class5046_0;
	}

	public Class5720 method_59()
	{
		return class5720_0;
	}

	public Class5024 method_60()
	{
		return class5024_1;
	}

	public Class5043 method_61()
	{
		return class5043_0;
	}

	public Class5043 method_62()
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

	public override string vmethod_21()
	{
		return "character";
	}

	public override int vmethod_24()
	{
		return 10;
	}

	public override bool vmethod_26(int boundary)
	{
		return false;
	}

	protected override Stack vmethod_27(Stack ranges, Class5727 currentRange)
	{
		currentRange?.method_1(vmethod_17(), this);
		return ranges;
	}
}
