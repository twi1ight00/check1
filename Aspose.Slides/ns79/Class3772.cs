using ns72;
using ns73;
using ns76;
using ns88;

namespace ns79;

internal abstract class Class3772 : Class3771
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
			string text = lu.imethod_5().ToLowerInvariant();
			Class3679 @class = vmethod_3().method_1(text);
			if (@class != null)
			{
				return @class;
			}
			if ("initial" == text)
			{
				return Class3700.Class3702.class3689_45;
			}
			throw method_0(lu.imethod_5());
		}
		case 12:
			return Class3700.Class3702.class3695_0;
		}
	}
}
