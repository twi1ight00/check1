using ns72;
using ns73;
using ns76;
using ns88;

namespace ns79;

internal abstract class Class3862 : Class3854
{
	protected abstract Class3548<Class3679> vmethod_4();

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		if (lu.LexicalUnitType == 35)
		{
			Class3679 @class = vmethod_4().method_1(lu.imethod_5().ToLowerInvariant());
			if (@class != null)
			{
				return @class;
			}
		}
		return base.vmethod_0(lu, engine);
	}
}
