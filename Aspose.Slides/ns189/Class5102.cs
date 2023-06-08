using System;
using System.Collections;
using ns171;
using ns176;
using ns178;
using ns182;
using ns187;

namespace ns189;

internal class Class5102 : Class5097
{
	private Interface182 interface182_0;

	private int int_1;

	private Interface182 interface182_1;

	private int int_2;

	private int int_3;

	private Class5045 class5045_0;

	private int int_4;

	private Interface182 interface182_2;

	private int int_5;

	private Interface182 interface182_3;

	public Class5102(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		interface182_0 = pList.method_5(3).vmethod_0();
		int_1 = pList.method_5(4).imethod_0();
		interface182_1 = pList.method_5(15).vmethod_0();
		int_2 = pList.method_5(88).imethod_0();
		int_3 = pList.method_5(136).imethod_0();
		class5045_0 = pList.method_5(137).vmethod_3();
		int_4 = pList.method_5(138).imethod_0();
		interface182_2 = pList.method_5(139).vmethod_0();
		interface182_3 = Class5094.smethod_9(214).vmethod_7(pList).vmethod_0();
		switch (int_4)
		{
		case 123:
			int_5 = pList.method_5(213).imethod_0();
			interface182_3 = pList.method_5(214).vmethod_0();
			break;
		default:
			throw new Exception("Invalid leader pattern: " + int_4);
		case 35:
		case 134:
		case 158:
			break;
		}
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI) && (localName.Equals("leader") || localName.Equals("inline-container") || localName.Equals("block-container") || localName.Equals("float") || localName.Equals("marker") || !method_34(nsURI, localName)))
		{
			method_11(loc, nsURI, localName);
		}
	}

	public int method_57()
	{
		return int_5;
	}

	public Interface182 method_58()
	{
		return interface182_3;
	}

	public int method_59()
	{
		return int_3;
	}

	public Class5045 method_60()
	{
		return class5045_0;
	}

	public int method_61()
	{
		return int_4;
	}

	public Interface182 method_62()
	{
		return interface182_2;
	}

	public Interface182 method_63()
	{
		return interface182_0;
	}

	public int method_64()
	{
		return int_1;
	}

	public Interface182 method_65()
	{
		return interface182_1;
	}

	public int method_66()
	{
		return int_2;
	}

	public override string vmethod_21()
	{
		return "leader";
	}

	public override int vmethod_24()
	{
		return 39;
	}

	internal override void vmethod_10()
	{
		base.vmethod_10();
		vmethod_3().vmethod_58(this);
	}

	internal override void vmethod_11()
	{
		base.vmethod_11();
		vmethod_3().vmethod_59(this);
	}

	protected override Stack vmethod_27(Stack ranges, Class5727 currentRange)
	{
		if (currentRange != null)
		{
			if (int_4 == 158)
			{
				ranges = base.vmethod_27(ranges, currentRange);
			}
			else
			{
				currentRange.method_2('￼', this);
			}
		}
		return ranges;
	}
}
