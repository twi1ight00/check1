using ns73;
using ns74;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class4000 : Class3770
{
	public override string PropertyName => "pause-before";

	public override Enum600 PropertyType => Enum600.const_208;

	public override bool IsInheritedProperty => false;

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3685_0;
	}

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		return lu.LexicalUnitType switch
		{
			31 => new Class3685(lu.imethod_1(), 14), 
			32 => new Class3685(lu.imethod_1(), 15), 
			23 => new Class3685(lu.imethod_1(), 2), 
			_ => throw Class4246.smethod_11(lu.LexicalUnitType), 
		};
	}
}
