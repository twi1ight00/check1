using ns171;

namespace ns187;

internal class Class5726 : Class5723
{
	public Class5726(Class5052 baseMaker)
		: base(baseMaker)
	{
	}

	public override Class5024 vmethod_1(Class5634 propertyList)
	{
		Class5024 @class = base.vmethod_1(propertyList);
		if (@class != null && @class is Class5046)
		{
			((Class5046)@class).method_12(Class5042.smethod_0(118, "RETAIN"), bIsDefault: false);
		}
		return @class;
	}
}
