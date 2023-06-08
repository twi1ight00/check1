using ns73;
using ns74;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3834 : Class3829
{
	public override string PropertyName => "orphans";

	public override Enum600 PropertyType => Enum600.const_186;

	public override bool IsInheritedProperty => true;

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3685_2;
	}

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		return lu.LexicalUnitType switch
		{
			12 => Class3700.Class3702.class3695_0, 
			13 => new Class3685(lu.imethod_0(), 1), 
			_ => throw Class4246.smethod_11(lu.LexicalUnitType), 
		};
	}
}
