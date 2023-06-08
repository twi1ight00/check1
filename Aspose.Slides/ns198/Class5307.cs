using ns173;
using ns181;
using ns189;
using ns196;

namespace ns198;

internal class Class5307 : Class5306
{
	public Class5307(Class5121 node)
		: base(node)
	{
	}

	public override Class4943 vmethod_2(Class5687 context)
	{
		class4943_0 = method_34();
		return class4943_0;
	}

	private Class4943 method_34()
	{
		Class4974 @class = imethod_4().method_27(class5120_0.method_57());
		Class4948 class2 = null;
		int num = method_33();
		if (@class != null)
		{
			string text = @class.method_15();
			class2 = new Class4948();
			int ipD = method_32(text);
			class2.method_16(num);
			class2.method_62(text, 0, num);
			class2.method_11(ipD);
			bool_4 = true;
		}
		else
		{
			class2 = new Class4949(class5120_0.method_57(), class5729_0);
			string str = "MMM";
			int ipD2 = method_32(str);
			class2.method_16(num);
			class2.method_11(ipD2);
			bool_4 = false;
		}
		method_31(class2);
		return class2;
	}
}
