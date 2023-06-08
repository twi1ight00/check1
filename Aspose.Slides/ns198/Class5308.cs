using ns173;
using ns181;
using ns189;
using ns196;

namespace ns198;

internal class Class5308 : Class5306
{
	public Class5308(Class5122 node)
		: base(node)
	{
		class5120_0 = node;
	}

	public override Class4943 vmethod_2(Class5687 context)
	{
		class4943_0 = method_34(interface173_0);
		return class4943_0;
	}

	private Class4943 method_34(Interface173 parentLM)
	{
		Class4948 @class = null;
		int num = method_33();
		if (!imethod_4().method_30(class5120_0.method_57()))
		{
			@class = new Class4949(class5120_0.method_57(), class5729_0, Class4949.bool_4);
			imethod_4().method_32(class5120_0.method_57(), (Interface160)@class);
			string str = "MMM";
			int ipD = method_32(str);
			@class.method_16(num);
			@class.method_11(ipD);
			bool_4 = false;
		}
		else
		{
			Class4974 class2 = imethod_4().method_28(class5120_0.method_57());
			string text = class2.method_15();
			@class = new Class4948();
			int ipD2 = method_32(text);
			@class.method_16(num);
			@class.method_62(text, 0, num);
			@class.method_11(ipD2);
			bool_4 = true;
		}
		method_31(@class);
		return @class;
	}
}
