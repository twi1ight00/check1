using ns173;
using ns176;
using ns181;
using ns189;
using ns196;

namespace ns198;

internal class Class5317 : Class5315
{
	public Class5317(Class5098 node)
		: base(node)
	{
	}

	protected override Class4943 vmethod_8(bool bInlineParent)
	{
		Class4943 @class = base.vmethod_8(bInlineParent);
		smethod_1(@class, (Class5098)class5094_0, imethod_4());
		return @class;
	}

	internal static void smethod_1(Class4942 area, Class5098 fobj, Class5322 pslm)
	{
		Class5677.smethod_20(area, fobj.imethod_1());
		if (fobj.method_64())
		{
			string text = fobj.method_62();
			Class5434 @class = new Class5434(text, area);
			@class.method_0(text, pslm.method_27(text));
			if (!@class.imethod_2())
			{
				pslm.method_32(text, @class);
				if (area is Class4945)
				{
					((Class4945)area).method_53(@class);
				}
			}
		}
		else if (fobj.method_65())
		{
			string text2 = Class5409.smethod_0(fobj.method_63());
			bool newWindow = fobj.method_66() == 190;
			if (text2.Length > 0)
			{
				area.method_29(Class5757.int_1, new Class5757.Class5760(text2, newWindow));
			}
		}
	}

	protected override Class4944 vmethod_9()
	{
		return new Class4945();
	}
}
