using ns72;
using ns73;
using ns76;
using ns88;

namespace ns79;

internal abstract class Class4002 : Class4001
{
	public abstract Class3548<Class3679> vmethod_3();

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		switch (lu.LexicalUnitType)
		{
		default:
			return base.vmethod_0(lu, engine);
		case 35:
		{
			Class3679 @class = vmethod_3().method_1(lu.imethod_5());
			if (@class == null)
			{
				throw method_0(lu.imethod_5());
			}
			return @class;
		}
		case 12:
			return Class3700.Class3702.class3695_0;
		}
	}
}
