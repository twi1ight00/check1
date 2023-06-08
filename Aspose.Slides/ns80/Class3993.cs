using System.Collections.Generic;
using ns72;
using ns73;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3993 : Class3969
{
	public override string PropertyName => "target";

	public override Enum600 PropertyType => Enum600.const_296;

	public override bool IsInheritedProperty => false;

	public override void vmethod_3(Class3726 engine, Interface100 propertyHandler, Interface99 lu, bool important)
	{
		Class3548<Class3679> @class = ((Class3850)engine.method_6(Enum600.const_295)).vmethod_3();
		Class3548<Class3679> class2 = ((Class3850)engine.method_6(Enum600.const_294)).vmethod_3();
		Class3548<Class3679> class3 = ((Class3850)engine.method_6(Enum600.const_293)).vmethod_3();
		List<Interface99> list = new List<Interface99>();
		List<Interface99> list2 = new List<Interface99>();
		List<Interface99> list3 = new List<Interface99>();
		IList<Interface99> list4 = Class4233.smethod_13(lu);
		foreach (Interface99 item in list4)
		{
			switch (item.LexicalUnitType)
			{
			case 35:
			{
				string key = item.imethod_5().ToLowerInvariant();
				if (@class.method_1(key) != null)
				{
					list.Add(item);
				}
				if (class2.method_1(key) != null)
				{
					list2.Add(item);
				}
				if (class3.method_1(key) != null)
				{
					list3.Add(item);
				}
				break;
			}
			case 36:
				list.Add(item);
				break;
			}
		}
		method_8(propertyHandler, "target-name", list, important);
		method_8(propertyHandler, "target-new", list2, important);
		method_8(propertyHandler, "target-position", list3, important);
	}
}
