using ns173;
using ns189;
using ns192;
using ns197;

namespace ns198;

internal class Class5288 : Class5287
{
	private Class5098 class5098_0;

	public Class5288(Class5098 link, Class5156 table)
		: base(table)
	{
		class5098_0 = link;
	}

	public override Class4942 imethod_7(Class4942 childArea)
	{
		Class4942 @class = base.imethod_7(childArea);
		if (childArea == null)
		{
			Class5317.smethod_1(@class, class5098_0, imethod_4());
		}
		return @class;
	}
}
