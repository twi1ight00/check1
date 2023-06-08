using System.Collections.Generic;
using ns73;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3991 : Class3969
{
	public override string PropertyName => "pause";

	public override Enum600 PropertyType => Enum600.const_206;

	public override bool IsInheritedProperty => false;

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3685_0;
	}

	public override void vmethod_3(Class3726 engine, Interface100 propertyHandler, Interface99 lu, bool important)
	{
		IList<Interface99> list = Class4233.smethod_13(lu);
		if (list.Count > 2)
		{
			throw method_2(list[2]);
		}
		if (list.Count == 1)
		{
			list.Add(list[0]);
		}
		method_7(propertyHandler, "pause-before", list[0], important);
		method_7(propertyHandler, "pause-after", list[1], important);
	}
}
