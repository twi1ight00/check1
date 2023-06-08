using System.Collections;
using System.Drawing;
using ns171;
using ns174;
using ns176;
using ns178;
using ns182;
using ns187;

namespace ns189;

internal abstract class Class5120 : Class5094, Interface222, Interface223
{
	private Class5715 class5715_0;

	private Class5703 class5703_0;

	private Class5716 class5716_0;

	private Interface182 interface182_0;

	private int int_1;

	private Interface182 interface182_1;

	private int int_2;

	private Interface244 interface244_0;

	private Class5046 class5046_0;

	private string string_3;

	private Class5720 class5720_0;

	private Color color_0;

	public Class5120(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		class5715_0 = Class5715.smethod_0(pList);
		class5703_0 = pList.method_17();
		class5716_0 = pList.method_25();
		interface182_0 = pList.method_5(3).vmethod_0();
		int_1 = pList.method_5(4).imethod_0();
		interface182_1 = pList.method_5(15).vmethod_0();
		int_2 = pList.method_5(88).imethod_0();
		class5046_0 = pList.method_5(144).vmethod_5();
		string_3 = pList.method_5(198).vmethod_13();
		class5720_0 = pList.method_26();
		color_0 = pList.method_5(72).vmethod_1(method_2());
	}

	public override void vmethod_6(string elementName, Interface243 locator, Interface236 attlist, Class5634 pList)
	{
		base.vmethod_6(elementName, locator, attlist, pList);
		if (!vmethod_5() && string.IsNullOrEmpty(string_3))
		{
			method_15("ref-id");
		}
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			method_11(loc, nsURI, localName);
		}
	}

	public Class5715 imethod_0()
	{
		return class5715_0;
	}

	public Class5716 method_48()
	{
		return class5716_0;
	}

	public Color method_49()
	{
		return color_0;
	}

	public Class5720 method_50()
	{
		return class5720_0;
	}

	public override void vmethod_29(Interface244 structureTreeElement)
	{
		interface244_0 = structureTreeElement;
	}

	public Interface244 imethod_1()
	{
		return interface244_0;
	}

	public Interface182 method_51()
	{
		return interface182_0;
	}

	public int method_52()
	{
		return int_1;
	}

	public Interface182 method_53()
	{
		return interface182_1;
	}

	public int method_54()
	{
		return int_2;
	}

	public Class5703 method_55()
	{
		return class5703_0;
	}

	public Class5046 method_56()
	{
		return class5046_0;
	}

	public string method_57()
	{
		return string_3;
	}

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
