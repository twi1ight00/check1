using ns73;
using ns74;
using ns76;
using ns88;

namespace ns79;

internal abstract class Class3899 : Class3850
{
	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		switch (lu.LexicalUnitType)
		{
		default:
			throw method_1(lu.LexicalUnitType);
		case 35:
		{
			Class3679 @class = vmethod_3().method_1(lu.imethod_5());
			if (@class == null)
			{
				throw method_0(lu.imethod_5());
			}
			return @class;
		}
		case 36:
			return Class3689.smethod_0(lu.imethod_5());
		case 12:
			return Class3700.Class3702.class3695_0;
		}
	}
}
