using System.Drawing;
using ns171;
using ns187;

namespace ns189;

internal abstract class Class5097 : Class5096, Interface222
{
	private Class5715 class5715_0;

	private Class5703 class5703_0;

	private Class5719 class5719_0;

	private Class5716 class5716_0;

	private Color color_0;

	private Class5043 class5043_0;

	private Class5043 class5043_1;

	private Class5046 class5046_0;

	protected Class5097(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		class5715_0 = Class5715.smethod_0(pList);
		class5703_0 = pList.method_17();
		class5719_0 = pList.method_21();
		class5716_0 = pList.method_25();
		color_0 = pList.method_5(72).vmethod_1(method_2());
		class5043_0 = pList.method_5(132).vmethod_6();
		class5043_1 = pList.method_5(133).vmethod_6();
		class5046_0 = pList.method_5(144).vmethod_5();
	}

	public Class5715 imethod_0()
	{
		return class5715_0;
	}

	public Class5719 method_50()
	{
		return class5719_0;
	}

	public Class5703 method_51()
	{
		return class5703_0;
	}

	public Class5716 method_52()
	{
		return class5716_0;
	}

	public Color method_53()
	{
		return color_0;
	}

	public Class5046 method_54()
	{
		return class5046_0;
	}

	public Class5043 method_55()
	{
		return class5043_0;
	}

	public Class5043 method_56()
	{
		return class5043_1;
	}

	public override bool vmethod_26(int boundary)
	{
		return false;
	}
}
