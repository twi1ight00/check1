using ns171;
using ns176;
using ns187;
using ns189;

namespace ns186;

internal class Class5005 : Class5003
{
	public override int imethod_0()
	{
		return 0;
	}

	public override Class5024 imethod_2(Class5024[] args, Class5750 pInfo)
	{
		Interface181 op = pInfo.method_3().method_6(Enum679.const_282).vmethod_10();
		Class5634 @class = pInfo.method_3();
		while (@class != null && !(@class.method_0() is Class5160))
		{
			@class = @class.method_2();
		}
		if (@class == null)
		{
			throw new Exception55("body-start() called from outside an fo:list-item");
		}
		Interface181 op2 = @class.method_6(Enum679.const_320).vmethod_10();
		return (Class5024)Class5747.smethod_0(op, op2);
	}
}
