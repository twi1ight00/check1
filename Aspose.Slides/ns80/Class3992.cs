using System.Collections.Generic;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3992 : Class3969
{
	public override string PropertyName => "rest";

	public override Enum600 PropertyType => Enum600.const_217;

	public override bool IsInheritedProperty => false;

	public override void vmethod_3(Class3726 engine, Interface100 propertyHandler, Interface99 lu, bool important)
	{
		if (lu.NextLexicalUnit != null)
		{
			IList<Interface99> list = Class4233.smethod_13(lu);
			method_7(propertyHandler, "rest-before", list[0], important);
			method_7(propertyHandler, "rest-after", list[1], important);
		}
		else
		{
			method_7(propertyHandler, "rest-before", lu, important);
			method_7(propertyHandler, "rest-after", lu, important);
		}
	}
}
