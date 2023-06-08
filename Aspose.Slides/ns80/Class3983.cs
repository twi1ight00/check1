using System.Collections.Generic;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3983 : Class3969
{
	public override string PropertyName => "cue";

	public override Enum600 PropertyType => Enum600.const_86;

	public override bool IsInheritedProperty => false;

	public override void vmethod_3(Class3726 engine, Interface100 propertyHandler, Interface99 lu, bool important)
	{
		IList<Interface99> list = Class4233.smethod_13(lu);
		if (list.Count > 2)
		{
			throw Class4246.smethod_13(list[2].ToString());
		}
		if (list.Count == 1)
		{
			list.Add(list[0]);
		}
		propertyHandler.imethod_0("cue-before", list[0], important);
		propertyHandler.imethod_0("cue-after", list[1], important);
	}
}
