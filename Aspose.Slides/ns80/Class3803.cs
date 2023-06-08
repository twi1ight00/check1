using ns72;
using ns73;
using ns74;
using ns76;
using ns79;
using ns84;

namespace ns80;

internal class Class3803 : Class3772
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "line-height";

	public override Enum600 PropertyType => Enum600.const_152;

	public override bool IsInheritedProperty => true;

	static Class3803()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("normal", Class3700.Class3702.class3689_5);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_5;
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
			if (class2.PrimitiveType == 2)
			{
				return Class3700.Class3702.class3689_5;
			}
		}
		return @class;
	}
}
