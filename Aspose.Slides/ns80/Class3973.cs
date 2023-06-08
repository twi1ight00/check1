using System.Collections.Generic;
using ns72;
using ns73;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3973 : Class3969
{
	public override string PropertyName => "border-image";

	public override Enum600 PropertyType => Enum600.const_40;

	public override bool IsInheritedProperty => false;

	public override void vmethod_3(Class3726 engine, Interface100 propertyHandler, Interface99 lu, bool important)
	{
		Class3548<Class3679> @class = ((Class3850)engine.method_6(Enum600.const_44)).vmethod_3();
		Class3548<Class3679> class2 = ((Class3772)engine.method_6(Enum600.const_43)).vmethod_3();
		Class3548<Class3679> class3 = ((Class3772)engine.method_6(Enum600.const_45)).vmethod_3();
		Class3548<Class3679> class4 = ((Class3850)engine.method_6(Enum600.const_42)).vmethod_3();
		List<Interface99> list = new List<Interface99>();
		List<Interface99> list2 = new List<Interface99>();
		List<Interface99> list3 = new List<Interface99>();
		List<Interface99> list4 = new List<Interface99>();
		List<Interface99> list5 = new List<Interface99>();
		IEnumerator<Interface99> enumerator = Class4233.smethod_13(lu).GetEnumerator();
		int num = 1;
		while (enumerator.MoveNext())
		{
			Interface99 current = enumerator.Current;
			switch (current.LexicalUnitType)
			{
			case 35:
			{
				string key = current.imethod_5().ToLowerInvariant();
				if (@class.method_1(key) != null)
				{
					list.Add(current);
					break;
				}
				if (class2.method_1(key) != null)
				{
					list2.Add(current);
					break;
				}
				if (class3.method_1(key) != null)
				{
					list3.Add(current);
					break;
				}
				if (class4.method_1(key) != null)
				{
					list5.Add(current);
					break;
				}
				throw method_1(current.LexicalUnitType);
			}
			case 4:
				if (enumerator.MoveNext())
				{
					current = enumerator.Current;
					switch (current.LexicalUnitType)
					{
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
						list3.Add(current);
						break;
					default:
						throw method_1(current.LexicalUnitType);
					}
					break;
				}
				throw method_1(current.LexicalUnitType);
			case 12:
				list.Add(current);
				list2.Add(current);
				list3.Add(current);
				list4.Add(current);
				list5.Add(current);
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
				switch (num)
				{
				case 2:
					list2.Add(current);
					break;
				case 3:
					list3.Add(current);
					break;
				case 4:
					list4.Add(current);
					break;
				}
				break;
			case 24:
				list.Add(current);
				break;
			case 27:
				list.Add(current);
				break;
			default:
				throw method_1(current.LexicalUnitType);
			}
			num++;
		}
		method_8(propertyHandler, "border-image-source", list, important);
		method_8(propertyHandler, "border-image-slice", list2, important);
		method_8(propertyHandler, "border-image-width", list3, important);
		method_8(propertyHandler, "border-image-outset", list4, important);
		method_8(propertyHandler, "border-image-repeat", list5, important);
	}
}
