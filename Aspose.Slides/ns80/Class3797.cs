using ns72;
using ns73;
using ns74;
using ns76;
using ns79;
using ns84;

namespace ns80;

internal class Class3797 : Class3772
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "font-size";

	public override Enum600 PropertyType => Enum600.const_115;

	public override bool IsInheritedProperty => true;

	static Class3797()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("xx-small", Class3700.Class3702.class3689_51);
		class3548_0.method_0("x-small", Class3700.Class3702.class3689_52);
		class3548_0.method_0("small", Class3700.Class3702.class3689_53);
		class3548_0.method_0("medium", Class3700.Class3702.class3689_31);
		class3548_0.method_0("large", Class3700.Class3702.class3689_54);
		class3548_0.method_0("x-large", Class3700.Class3702.class3689_55);
		class3548_0.method_0("xx-large", Class3700.Class3702.class3689_56);
		class3548_0.method_0("xxx-large", Class3700.Class3702.class3689_57);
		class3548_0.method_0("larger", Class3700.Class3702.class3689_58);
		class3548_0.method_0("smaller", Class3700.Class3702.class3689_59);
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
		Class3679 @class = base.vmethod_2(element, engine, pseudoElement, map, value, propertyIndex);
		if (map.method_6(propertyIndex))
		{
			Class3680 class2 = (Class3680)@class;
			if (class2.PrimitiveType == 2 || class2.PrimitiveType == 3)
			{
				return Class3700.Class3702.class3685_23;
			}
		}
		return @class;
	}
}
