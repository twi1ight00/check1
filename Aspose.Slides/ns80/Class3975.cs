using System.Collections.Generic;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3975 : Class3969
{
	public override string PropertyName => "border";

	public override Enum600 PropertyType => Enum600.const_31;

	public override bool IsInheritedProperty => false;

	public override void vmethod_3(Class3726 engine, Interface100 propertyHandler, Interface99 lu, bool important)
	{
		IList<Interface99> units = Class4233.smethod_13(lu);
		method_8(propertyHandler, "border-top", units, important);
		method_8(propertyHandler, "border-right", units, important);
		method_8(propertyHandler, "border-bottom", units, important);
		method_8(propertyHandler, "border-left", units, important);
	}
}
