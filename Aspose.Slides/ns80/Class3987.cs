using System.Collections.Generic;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3987 : Class3969
{
	public override string PropertyName => "margin";

	public override Enum600 PropertyType => Enum600.const_161;

	public override bool IsInheritedProperty => false;

	public override void vmethod_3(Class3726 engine, Interface100 propertyHandler, Interface99 lu, bool important)
	{
		IList<Interface99> list = Class4233.smethod_13(lu);
		switch (list.Count)
		{
		case 1:
			list.Add(list[0]);
			list.Add(list[0]);
			list.Add(list[0]);
			break;
		case 2:
			list.Add(list[0]);
			list.Add(list[1]);
			break;
		case 3:
			list.Add(list[1]);
			break;
		}
		if (list.Count > 4)
		{
			throw method_2(list[4]);
		}
		propertyHandler.imethod_0("margin-top", list[0], important);
		propertyHandler.imethod_0("margin-right", list[1], important);
		propertyHandler.imethod_0("margin-bottom", list[2], important);
		propertyHandler.imethod_0("margin-left", list[3], important);
	}
}
