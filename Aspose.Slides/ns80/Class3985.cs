using System.Collections.Generic;
using ns72;
using ns73;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3985 : Class3969
{
	public override string PropertyName => "font-variant";

	public override Enum600 PropertyType => Enum600.const_119;

	public override bool IsInheritedProperty => true;

	public override void vmethod_3(Class3726 engine, Interface100 propertyHandler, Interface99 lu, bool important)
	{
		Class3548<Class3679> @class = ((Class3850)engine.method_6(Enum600.const_125)).vmethod_3();
		Class3548<Class3679> class2 = ((Class3850)engine.method_6(Enum600.const_120)).vmethod_3();
		Class3548<Class3679> class3 = ((Class3850)engine.method_6(Enum600.const_121)).vmethod_3();
		Class3548<Class3679> class4 = ((Class3850)engine.method_6(Enum600.const_122)).vmethod_3();
		Class3548<Class3679> class5 = ((Class3850)engine.method_6(Enum600.const_123)).vmethod_3();
		Class3548<Class3679> class6 = ((Class3850)engine.method_6(Enum600.const_124)).vmethod_3();
		List<Interface99> list = new List<Interface99>();
		List<Interface99> list2 = new List<Interface99>();
		List<Interface99> list3 = new List<Interface99>();
		List<Interface99> list4 = new List<Interface99>();
		List<Interface99> list5 = new List<Interface99>();
		List<Interface99> list6 = new List<Interface99>();
		IList<Interface99> list7 = Class4233.smethod_13(lu);
		foreach (Interface99 item in list7)
		{
			switch (item.LexicalUnitType)
			{
			case 35:
			{
				string text = item.imethod_5().ToLowerInvariant();
				if (text == "normal")
				{
					list.Add(item);
					list2.Add(item);
					list3.Add(item);
					list4.Add(item);
					list5.Add(item);
					list6.Add(item);
				}
				else if (@class.method_1(text) != null)
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
				else
				{
					if (class6.method_1(text) == null)
					{
						throw method_3(text);
					}
					list6.Add(item);
				}
				break;
			}
			case 12:
				list.Add(item);
				list2.Add(item);
				list3.Add(item);
				list4.Add(item);
				list5.Add(item);
				list6.Add(item);
				break;
			default:
				throw method_1(item.LexicalUnitType);
			}
		}
		method_8(propertyHandler, "font-variant-alternates", list, important);
		method_8(propertyHandler, "font-variant-caps", list2, important);
		method_8(propertyHandler, "font-variant-east-asian", list3, important);
		method_8(propertyHandler, "font-variant-ligatures", list4, important);
		method_8(propertyHandler, "font-variant-numeric", list5, important);
		method_8(propertyHandler, "font-variant-position", list6, important);
	}
}
