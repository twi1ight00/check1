using ns73;
using ns74;
using ns76;
using ns88;

namespace ns79;

internal abstract class Class4001 : Class3770
{
	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		return lu.LexicalUnitType switch
		{
			33 => new Class3685(lu.imethod_1(), 16), 
			34 => new Class3685(lu.imethod_1(), 17), 
			_ => throw Class4246.smethod_11(lu.LexicalUnitType), 
		};
	}
}
