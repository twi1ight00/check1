using ns73;
using ns74;
using ns76;
using ns88;

namespace ns79;

internal abstract class Class3771 : Class3770
{
	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		return lu.LexicalUnitType switch
		{
			13 => new Class3682(lu.imethod_0(), 1), 
			14 => new Class3685(lu.imethod_1(), 1), 
			15 => new Class3685(lu.imethod_1(), 3), 
			16 => new Class3685(lu.imethod_1(), 4), 
			17 => new Class3685(lu.imethod_1(), 5), 
			18 => new Class3685(lu.imethod_1(), 8), 
			19 => new Class3685(lu.imethod_1(), 6), 
			20 => new Class3685(lu.imethod_1(), 7), 
			21 => new Class3685(lu.imethod_1(), 9), 
			22 => new Class3685(lu.imethod_1(), 10), 
			23 => new Class3685(lu.imethod_1(), 2), 
			_ => throw Class4246.smethod_11(lu.LexicalUnitType), 
		};
	}
}
