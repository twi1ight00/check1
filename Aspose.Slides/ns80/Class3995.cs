using System.Collections.Generic;
using ns72;
using ns73;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3995 : Class3969
{
	public override string PropertyName => "text-emphasis";

	public override Enum600 PropertyType => Enum600.const_248;

	public override bool IsInheritedProperty => true;

	public override void vmethod_3(Class3726 engine, Interface100 propertyHandler, Interface99 lu, bool important)
	{
		Class3548<Class3679> @class = ((Class3850)engine.method_6(Enum600.const_251)).vmethod_3();
		List<Interface99> list = new List<Interface99>();
		List<Interface99> list2 = new List<Interface99>();
		IList<Interface99> list3 = Class4233.smethod_13(lu);
		foreach (Interface99 item in list3)
		{
			switch (item.LexicalUnitType)
			{
			case 35:
			{
				string key = item.imethod_5().ToLowerInvariant();
				if (@class.ContainsKey(key))
				{
					list.Add(item);
				}
				else
				{
					list2.Add(item);
				}
				break;
			}
			case 36:
				list.Add(item);
				break;
			case 12:
				list.Add(item);
				list2.Add(item);
				break;
			default:
				throw method_1(item.LexicalUnitType);
			}
		}
		method_8(propertyHandler, "text-emphasis-color", list2, important);
		method_8(propertyHandler, "text-emphasis-style", list, important);
	}
}
