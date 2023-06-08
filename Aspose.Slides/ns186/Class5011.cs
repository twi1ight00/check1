using ns171;
using ns176;
using ns187;
using ns189;

namespace ns186;

internal class Class5011 : Class5003
{
	public override int imethod_0()
	{
		return 0;
	}

	public override Class5024 imethod_2(Class5024[] args, Class5750 pInfo)
	{
		Interface182 @interface = pInfo.method_3().method_6(Enum679.const_282).vmethod_0();
		Interface182 op = pInfo.method_3().method_7(196).vmethod_0();
		Class5634 @class = pInfo.method_3();
		while (@class != null && !(@class.method_0() is Class5160))
		{
			@class = @class.method_2();
		}
		if (@class == null)
		{
			throw new Exception55("label-end() called from outside an fo:list-item");
		}
		Interface182 op2 = @class.method_6(Enum679.const_320).vmethod_0();
		Class5743 lbase = new Class5743(pInfo.method_3(), 4);
		Class5037 op3 = new Class5037(1.0, lbase);
		Interface181 op4 = @interface;
		op4 = Class5747.smethod_0(op4, op2);
		op4 = Class5747.smethod_2(op4, op);
		op4 = Class5747.smethod_2(op3, op4);
		return (Class5024)op4;
	}
}
