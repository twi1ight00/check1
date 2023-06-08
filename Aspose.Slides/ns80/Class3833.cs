using ns73;
using ns74;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3833 : Class3829
{
	public override string PropertyName => "opacity";

	public override Enum600 PropertyType => Enum600.const_184;

	public override bool IsInheritedProperty => false;

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3685_1;
	}

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		return lu.LexicalUnitType switch
		{
			12 => Class3700.Class3702.class3695_0, 
			13 => new Class3685(lu.imethod_0(), 1), 
			14 => new Class3685(lu.imethod_1(), 1), 
			_ => throw Class4246.smethod_11(lu.LexicalUnitType), 
		};
	}

	public override Class3679 vmethod_2(Interface91 element, Class3726 engine, string pseudoElement, Class4074 map, Class3679 value, int propertyIndex)
	{
		Class3685 @class = (Class3685)base.vmethod_2(element, engine, pseudoElement, map, value, propertyIndex);
		float num = @class.vmethod_1(@class.PrimitiveType);
		if (num < 0f)
		{
			return Class3700.Class3702.class3685_0;
		}
		if (num > 1f)
		{
			return Class3700.Class3702.class3685_1;
		}
		return @class;
	}
}
