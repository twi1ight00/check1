using ns72;
using ns73;
using ns74;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3789 : Class3772
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "counter-increment";

	public override Enum600 PropertyType => Enum600.const_83;

	public override bool IsInheritedProperty => false;

	static Class3789()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("none", Class3700.Class3702.class3689_4);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_4;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		Class3691 @class = new Class3691();
		while (lu != null)
		{
			switch (lu.LexicalUnitType)
			{
			case 35:
			{
				Class3679 class2 = vmethod_3().method_1(lu.imethod_5());
				if (class2 == null)
				{
					@class.Add(Class3689.smethod_1(lu.imethod_5()));
					break;
				}
				return Class3700.Class3702.class3689_4;
			}
			case 13:
				@class.Add(new Class3685(lu.imethod_0(), 1));
				break;
			default:
				throw Class4246.smethod_11(lu.LexicalUnitType);
			case 12:
				return Class3700.Class3702.class3695_0;
			}
			lu = lu.NextLexicalUnit;
		}
		return @class;
	}

	public override Class3679 vmethod_2(Interface91 element, Class3726 engine, string pseudoElement, Class4074 map, Class3679 value, int propertyIndex)
	{
		return base.vmethod_2(element, engine, pseudoElement, map, value, propertyIndex);
	}
}
