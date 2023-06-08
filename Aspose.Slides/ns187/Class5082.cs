using System;
using ns171;
using ns186;

namespace ns187;

internal class Class5082 : Class5048.Class5081
{
	public Class5082(int propId)
		: base(propId)
	{
	}

	public override Class5024 vmethod_4(int subpropId, Class5634 propertyList, bool tryInherit, bool tryDefault)
	{
		Class5024 @class = base.vmethod_4(0, propertyList, tryInherit, tryDefault);
		int num = 0;
		if (@class != null)
		{
			num = @class.vmethod_10().imethod_5();
		}
		if (Math.Abs(num) % 90 != 0 || Math.Abs(num) / 90 > 3)
		{
			throw new Exception55("Illegal property value: reference-orientation=\"" + num + "\" on " + propertyList.method_0().method_17());
		}
		return @class;
	}
}
