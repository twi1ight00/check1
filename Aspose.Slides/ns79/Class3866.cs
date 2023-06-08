using ns73;
using ns74;
using ns76;
using ns88;

namespace ns79;

internal abstract class Class3866 : Class3850
{
	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		switch (lu.LexicalUnitType)
		{
		default:
			throw Class4246.smethod_11(lu.LexicalUnitType);
		case 35:
		{
			Class3679 @class = vmethod_3().method_1(lu.imethod_5().ToLowerInvariant());
			if (@class == null)
			{
				throw method_0(lu.imethod_5());
			}
			return @class;
		}
		case 24:
		case 36:
			return new Class3690(lu.imethod_5());
		case 12:
			return Class3700.Class3702.class3695_0;
		}
	}
}
