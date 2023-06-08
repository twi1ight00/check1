using ns72;
using ns73;
using ns74;
using ns76;
using ns79;
using ns84;

namespace ns80;

internal class Class3781 : Class3772
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "border-right-width";

	public override Enum600 PropertyType => Enum600.const_54;

	public override bool IsInheritedProperty => false;

	static Class3781()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("thin", Class3700.Class3702.class3689_30);
		class3548_0.method_0("medium", Class3700.Class3702.class3689_31);
		class3548_0.method_0("thick", Class3700.Class3702.class3689_32);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_31;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}

	public override Class3679 vmethod_2(Interface91 element, Class3726 engine, string pseudoElement, Class4074 map, Class3679 value, int propertyIndex)
	{
		Class3679 @class = engine.method_9(element, pseudoElement, engine.method_1(Enum600.const_53));
		if (Class3700.Class3702.class3689_4 != @class && Class3700.Class3702.class3689_102 != @class)
		{
			if (value == Class3700.Class3702.class3689_45)
			{
				return Class3700.Class3702.class3689_31;
			}
			return base.vmethod_2(element, engine, pseudoElement, map, value, propertyIndex);
		}
		return Class3700.Class3702.class3685_0;
	}
}
