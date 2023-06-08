using System.Collections.Generic;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3978 : Class3969
{
	public override string PropertyName => "border-style";

	public override Enum600 PropertyType => Enum600.const_56;

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
		propertyHandler.imethod_0("border-top-style", list[0], important);
		propertyHandler.imethod_0("border-right-style", list[1], important);
		propertyHandler.imethod_0("border-bottom-style", list[2], important);
		propertyHandler.imethod_0("border-left-style", list[3], important);
	}
}
