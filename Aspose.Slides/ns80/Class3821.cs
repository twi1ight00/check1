using ns72;
using ns73;
using ns74;
using ns76;
using ns79;
using ns84;

namespace ns80;

internal class Class3821 : Class3772
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "volume";

	public override Enum600 PropertyType => Enum600.const_281;

	public override bool IsInheritedProperty => true;

	static Class3821()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("silent", Class3700.Class3702.class3689_174);
		class3548_0.method_0("x-soft", Class3700.Class3702.class3689_64);
		class3548_0.method_0("soft", Class3700.Class3702.class3689_65);
		class3548_0.method_0("medium", Class3700.Class3702.class3689_31);
		class3548_0.method_0("loud", Class3700.Class3702.class3689_66);
		class3548_0.method_0("x-loud", Class3700.Class3702.class3689_67);
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
		Class3681 class2 = null;
		if (@class is Class3682)
		{
			class2 = @class as Class3682;
		}
		if (@class is Class3685)
		{
			class2 = @class as Class3685;
		}
		if (class2 != null)
		{
			float num = class2.vmethod_1(1);
			if (num < 0f || num > 100f)
			{
				return Class3700.Class3702.class3689_31;
			}
		}
		return @class;
	}
}
