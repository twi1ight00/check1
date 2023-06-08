using System.Collections.Generic;
using ns72;
using ns73;
using ns74;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3960 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "voice-family";

	public override Enum600 PropertyType => Enum600.const_275;

	public override bool IsInheritedProperty => true;

	static Class3960()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("male", Class3700.Class3702.class3689_187);
		class3548_0.method_0("female", Class3700.Class3702.class3689_188);
		class3548_0.method_0("child", Class3700.Class3702.class3689_189);
	}

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		IList<Interface99> list = Class4233.smethod_13(lu);
		List<Class3679> list2 = new List<Class3679>();
		foreach (Interface99 item in list)
		{
			switch (item.LexicalUnitType)
			{
			case 35:
			case 36:
			{
				Class3679 @class = vmethod_3().method_1(item.imethod_5());
				if (@class == null)
				{
					@class = Class3689.smethod_0(item.imethod_5());
				}
				list2.Add(@class);
				break;
			}
			case 0:
				break;
			default:
				throw method_1(item.LexicalUnitType);
			case 12:
				if (list2.Count != 0)
				{
					list2.Clear();
				}
				list2.Add(Class3700.Class3702.class3695_0);
				return new Class3691(list2);
			}
		}
		return new Class3691(list2);
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}

	public override Class3679 vmethod_1()
	{
		return new Class3691();
	}
}
