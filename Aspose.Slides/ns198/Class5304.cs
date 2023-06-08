using ns173;
using ns189;

namespace ns198;

internal class Class5304 : Class5303
{
	private Class5098 class5098_0;

	public Class5304(Class5098 link, Class5110 graphic)
		: base(graphic)
	{
		class5098_0 = link;
	}

	protected override Class4942 vmethod_6()
	{
		Class4942 @class = base.vmethod_6();
		Class5317.smethod_1(@class, class5098_0, imethod_4());
		return @class;
	}
}
