using ns73;
using ns74;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3839 : Class3829
{
	public override string PropertyName => "pitch-range";

	public override Enum600 PropertyType => Enum600.const_212;

	public override bool IsInheritedProperty => true;

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3685_4;
	}

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		Class3679 @class = base.vmethod_0(lu, engine);
		if (@class == Class3700.Class3702.class3695_0)
		{
			return @class;
		}
		Class3680 class2 = (Class3680)@class;
		if (class2.PrimitiveType != 1)
		{
			throw method_3(class2.ToString());
		}
		return @class;
	}

	public override Class3679 vmethod_2(Interface91 element, Class3726 engine, string pseudoElement, Class4074 map, Class3679 value, int propertyIndex)
	{
		if (value == null)
		{
			return base.vmethod_2(element, engine, pseudoElement, map, value, propertyIndex);
		}
		Class3681 @class = (Class3681)value;
		float num = @class.vmethod_1(1);
		if (!(num < 0f) && num <= 100f)
		{
			return @class;
		}
		return Class3700.Class3702.class3685_4;
	}
}
