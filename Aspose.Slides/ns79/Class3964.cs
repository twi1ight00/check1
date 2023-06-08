using ns73;
using ns74;
using ns76;
using ns88;

namespace ns79;

internal abstract class Class3964 : Class3770
{
	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		return lu.LexicalUnitType switch
		{
			28 => new Class3685(lu.imethod_1(), 11), 
			29 => new Class3685(lu.imethod_1(), 13), 
			30 => new Class3685(lu.imethod_1(), 12), 
			_ => throw Class4246.smethod_11(lu.LexicalUnitType), 
		};
	}
}
