using System.Collections.Generic;
using ns72;
using ns73;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3970 : Class3969
{
	public override string PropertyName => "background";

	public override Enum600 PropertyType => Enum600.const_16;

	public override bool IsInheritedProperty => false;

	public override void vmethod_3(Class3726 engine, Interface100 propertyHandler, Interface99 lu, bool important)
	{
		Class3548<Class3679> @class = ((Class3850)engine.method_6(Enum600.const_17)).vmethod_3();
		Class3548<Class3679> class2 = ((Class3850)engine.method_6(Enum600.const_19)).vmethod_3();
		Class3548<Class3679> class3 = ((Class3850)engine.method_6(Enum600.const_20)).vmethod_3();
		Class3548<Class3679> class4 = ((Class3772)engine.method_6(Enum600.const_22)).vmethod_3();
		Class3548<Class3679> class5 = ((Class3850)engine.method_6(Enum600.const_23)).vmethod_3();
		List<Interface99> list = new List<Interface99>();
		List<Interface99> list2 = new List<Interface99>();
		List<Interface99> list3 = new List<Interface99>();
		List<Interface99> list4 = new List<Interface99>();
		List<Interface99> list5 = new List<Interface99>();
		IList<Interface99> list6 = Class4233.smethod_13(lu);
		foreach (Interface99 item in list6)
		{
			switch (item.LexicalUnitType)
			{
			case 35:
			{
				string text = item.imethod_5().ToLowerInvariant();
				if (@class.method_1(text) != null)
				{
					list.Add(item);
				}
				else if (class2.method_1(text) != null)
				{
					list2.Add(item);
				}
				else if (class3.method_1(text) != null)
				{
					list3.Add(item);
				}
				else if (class4.method_1(text) != null)
				{
					list4.Add(item);
				}
				else if (class5.method_1(text) != null)
				{
					list5.Add(item);
				}
				else if (!("auto" == text))
				{
					throw method_1(item.LexicalUnitType);
				}
				break;
			}
			case 12:
				list.Add(item);
				list2.Add(item);
				list3.Add(item);
				list4.Add(item);
				list5.Add(item);
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
				list4.Add(item);
				break;
			case 24:
				list3.Add(item);
				break;
			case 27:
				list2.Add(item);
				break;
			case 4:
				break;
			default:
				throw method_1(item.LexicalUnitType);
			}
		}
		if (list2.Count == 0)
		{
			list2.Add(Class4233.smethod_1(null, "initial"));
		}
		method_8(propertyHandler, "background-attachment", list, important);
		method_8(propertyHandler, "background-color", list2, important);
		method_8(propertyHandler, "background-image", list3, important);
		method_8(propertyHandler, "background-position", list4, important);
		method_8(propertyHandler, "background-repeat", list5, important);
	}
}
