using System.Collections.Generic;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3982 : Class3969
{
	public override string PropertyName => "columns";

	public override Enum600 PropertyType => Enum600.const_79;

	public override bool IsInheritedProperty => false;

	public override void vmethod_3(Class3726 engine, Interface100 propertyHandler, Interface99 lu, bool important)
	{
		if (lu.NextLexicalUnit == null)
		{
			method_7(propertyHandler, "column-width", lu, important);
			return;
		}
		IList<Interface99> list = Class4233.smethod_13(lu);
		method_7(propertyHandler, "column-width", list[0], important);
		method_7(propertyHandler, "column-count", list[1], important);
	}
}
