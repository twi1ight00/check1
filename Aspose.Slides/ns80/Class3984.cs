using System.Collections.Generic;
using System.Drawing;
using ns72;
using ns73;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3984 : Class3969
{
	public override string PropertyName => "font";

	public override Enum600 PropertyType => Enum600.const_112;

	public override bool IsInheritedProperty => true;

	public override void vmethod_3(Class3726 engine, Interface100 propertyHandler, Interface99 lu, bool important)
	{
		Class3548<Class3679> @class = ((Class3850)engine.method_6(Enum600.const_118)).vmethod_3();
		Class3548<Class3679> class2 = ((Class3850)engine.method_6(Enum600.const_125)).vmethod_3();
		Class3548<Class3679> class3 = ((Class3850)engine.method_6(Enum600.const_120)).vmethod_3();
		Class3548<Class3679> class4 = ((Class3850)engine.method_6(Enum600.const_121)).vmethod_3();
		Class3548<Class3679> class5 = ((Class3850)engine.method_6(Enum600.const_122)).vmethod_3();
		Class3548<Class3679> class6 = ((Class3850)engine.method_6(Enum600.const_123)).vmethod_3();
		Class3548<Class3679> class7 = ((Class3850)engine.method_6(Enum600.const_124)).vmethod_3();
		Class3548<Class3679> class8 = ((Class3772)engine.method_6(Enum600.const_126)).vmethod_3();
		Class3548<Class3679> class9 = ((Class3850)engine.method_6(Enum600.const_117)).vmethod_3();
		Class3548<Class3679> class10 = ((Class3772)engine.method_6(Enum600.const_115)).vmethod_3();
		Class3548<Class3679> class11 = ((Class3772)engine.method_6(Enum600.const_152)).vmethod_3();
		List<Interface99> list = new List<Interface99>();
		List<Interface99> list2 = new List<Interface99>();
		List<Interface99> list3 = new List<Interface99>();
		List<Interface99> list4 = new List<Interface99>();
		List<Interface99> list5 = new List<Interface99>();
		List<Interface99> list6 = new List<Interface99>();
		List<Interface99> list7 = new List<Interface99>();
		IEnumerator<Interface99> enumerator = Class4233.smethod_13(lu).GetEnumerator();
		while (enumerator.MoveNext())
		{
			Interface99 current = enumerator.Current;
			switch (current.LexicalUnitType)
			{
			case 35:
			{
				string text = current.imethod_5().ToLowerInvariant();
				if (list.Count == 0 && @class.method_1(text) != null)
				{
					list.Add(current);
				}
				else if (class2.method_1(text) == null && class3.method_1(text) == null && class4.method_1(text) == null && class5.method_1(text) == null && class6.method_1(text) == null && class7.method_1(text) == null)
				{
					if (class8.method_1(text) != null)
					{
						list3.Add(current);
					}
					else if (class9.method_1(text) != null)
					{
						list4.Add(current);
					}
					else if (class10.method_1(text) != null)
					{
						list5.Add(current);
					}
					else if (engine.SystemFonts.method_0(text))
					{
						Font font = engine.SystemFonts.method_1(text);
						list6.Add(Class4233.smethod_0(null, font.FontFamily.Name));
						list5.Add(Class4233.smethod_5(null, 21, font.SizeInPoints));
					}
					else
					{
						list6.Add(current);
					}
				}
				else
				{
					list2.Add(current);
				}
				break;
			}
			case 0:
			case 36:
				list6.Add(current);
				break;
			case 4:
				if (enumerator.MoveNext())
				{
					current = enumerator.Current;
					switch (current.LexicalUnitType)
					{
					case 35:
					{
						string key = current.imethod_5().ToLowerInvariant();
						if (class11.method_1(key) != null)
						{
							list7.Add(current);
							break;
						}
						throw method_1(current.LexicalUnitType);
					}
					case 12:
						list7.Add(current);
						break;
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
						list7.Add(current);
						break;
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
				switch (current.imethod_0())
				{
				case 100:
				case 200:
				case 300:
				case 400:
				case 500:
				case 600:
				case 700:
				case 800:
				case 900:
					list3.Add(current);
					break;
				}
				break;
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
				list5.Add(current);
				break;
			default:
				throw method_1(current.LexicalUnitType);
			}
		}
		method_8(propertyHandler, "font-style", list, important);
		method_8(propertyHandler, "font-variant", list2, important);
		if (list5.Count != 0 && list6.Count != 0 && list3.Count == 0)
		{
			list3.Add(Class4233.smethod_1(null, "normal"));
		}
		method_8(propertyHandler, "font-weight", list3, important);
		method_8(propertyHandler, "font-stretch", list4, important);
		method_8(propertyHandler, "font-size", list5, important);
		method_8(propertyHandler, "font-family", list6, important);
		if (list7.Count != 0)
		{
			method_8(propertyHandler, "line-height", list7, important);
		}
	}
}
