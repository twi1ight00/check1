using System.Collections.Generic;
using ns72;
using ns73;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3988 : Class3969
{
	public override string PropertyName => "outline";

	public override Enum600 PropertyType => Enum600.const_187;

	public override bool IsInheritedProperty => false;

	public override void vmethod_3(Class3726 engine, Interface100 propertyHandler, Interface99 lu, bool important)
	{
		Class3548<Class3679> @class = ((Class3850)engine.method_6(Enum600.const_188)).vmethod_3();
		Class3548<Class3679> class2 = ((Class3850)engine.method_6(Enum600.const_190)).vmethod_3();
		Class3548<Class3679> class3 = ((Class3772)engine.method_6(Enum600.const_191)).vmethod_3();
		List<Interface99> list = new List<Interface99>();
		List<Interface99> list2 = new List<Interface99>();
		List<Interface99> list3 = new List<Interface99>();
		IList<Interface99> list4 = Class4233.smethod_13(lu);
		foreach (Interface99 item in list4)
		{
			switch (item.LexicalUnitType)
			{
			case 12:
				list.Add(item);
				list2.Add(item);
				list3.Add(item);
				break;
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
			case 23:
				list3.Add(item);
				break;
			case 27:
				list.Add(item);
				break;
			case 35:
			{
				string text = item.imethod_5().ToLowerInvariant();
				if ("invert" == text)
				{
					list.Add(item);
				}
				if (@class.method_1(text) != null)
				{
					list.Add(item);
				}
				if (class2.method_1(text) != null)
				{
					list2.Add(item);
				}
				if (class3.method_1(text) != null)
				{
					list2.Add(item);
				}
				break;
			}
			}
		}
		method_8(propertyHandler, "outline-color", list, important);
		method_8(propertyHandler, "outline-style", list2, important);
		method_8(propertyHandler, "outline-width", list3, important);
	}
}
