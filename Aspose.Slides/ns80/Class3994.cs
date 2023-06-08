using System.Collections.Generic;
using ns72;
using ns73;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3994 : Class3969
{
	public override string PropertyName => "text-decoration";

	public override Enum600 PropertyType => Enum600.const_243;

	public override bool IsInheritedProperty => true;

	public override void vmethod_3(Class3726 engine, Interface100 propertyHandler, Interface99 lu, bool important)
	{
		Class3548<Class3679> @class = ((Class3850)engine.method_6(Enum600.const_244)).vmethod_3();
		Class3548<Class3679> class2 = ((Class3850)engine.method_6(Enum600.const_247)).vmethod_3();
		Class3548<Class3679> class3 = ((Class3850)engine.method_6(Enum600.const_245)).vmethod_3();
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
				string text = item.imethod_5().ToLowerInvariant();
				if (@class.method_1(text) != null)
				{
					list.Add(item);
					break;
				}
				if (class2.method_1(text) != null)
				{
					list2.Add(item);
					break;
				}
				if (class3.method_1(text) != null)
				{
					list3.Add(item);
					break;
				}
				throw method_0(text);
			}
			case 27:
				list.Add(item);
				break;
			case 12:
				list.Add(item);
				list2.Add(item);
				list3.Add(item);
				break;
			}
		}
		method_8(propertyHandler, "text-decoration-color", list, important);
		method_8(propertyHandler, "text-decoration-style", list2, important);
		method_8(propertyHandler, "text-decoration-line", list3, important);
	}
}
