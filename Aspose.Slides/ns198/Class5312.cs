using ns173;
using ns181;
using ns189;
using ns196;

namespace ns198;

internal class Class5312 : Class5299
{
	public Class5312(Class5107 node)
		: base(node)
	{
	}

	public override Class4943 vmethod_2(Class5687 context)
	{
		Class4943 @class = new Class4943();
		if (class5094_0.method_39())
		{
			Class5677.smethod_21(@class, class5094_0.vmethod_31());
		}
		return @class;
	}

	public override void imethod_9(Class5652 posIter, Class5687 context)
	{
		if (class5094_0.method_39())
		{
			vmethod_1();
			if (interface173_0 is Class5281 && !(interface173_0 is Class5283))
			{
				Class4962 @class = new Class4962();
				Class5677.smethod_21(@class, class5094_0.vmethod_31());
				interface173_0.imethod_8(@class);
			}
			else
			{
				Class4943 childArea = vmethod_4();
				interface173_0.imethod_8(childArea);
			}
		}
		while (posIter.imethod_0())
		{
			posIter.imethod_1();
		}
	}

	internal override void vmethod_1()
	{
		imethod_4().method_29(class5094_0.vmethod_31());
	}
}
