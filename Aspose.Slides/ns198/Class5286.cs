using ns173;
using ns189;
using ns196;

namespace ns198;

internal class Class5286 : Class5285
{
	private Class5098 class5098_0;

	public Class5286(Class5098 link, Class5161 blockContainer)
		: base(blockContainer)
	{
		class5098_0 = link;
	}

	public override Class4942 imethod_7(Class4942 childArea)
	{
		Class4942 @class = base.imethod_7(childArea);
		Class5317.smethod_1(@class, class5098_0, imethod_4());
		return @class;
	}
}
