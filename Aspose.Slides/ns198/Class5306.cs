using ns173;
using ns181;
using ns184;
using ns189;
using ns196;

namespace ns198;

internal abstract class Class5306 : Class5299
{
	protected Class5120 class5120_0;

	protected Class5729 class5729_0;

	protected bool bool_4;

	public Class5306(Class5120 node)
		: base(node)
	{
		class5120_0 = node;
	}

	public override void imethod_3()
	{
		Class5730 @class = class5120_0.vmethod_3().vmethod_1();
		Class5732[] array = class5120_0.method_48().method_9(@class);
		class5729_0 = @class.method_12(array[0], class5120_0.method_48().interface182_0.imethod_6(this), array[0].method_4());
		method_26(class5120_0.method_55());
	}

	protected override Class5684 vmethod_5(Class5687 context)
	{
		return new Class5684(class5729_0, class5120_0.method_56().method_10(this).vmethod_0()
			.imethod_6(this), class5120_0.method_51(), class5120_0.method_52(), class5120_0.method_53(), class5120_0.method_54(), context.method_42());
	}

	public override void imethod_9(Class5652 posIter, Class5687 context)
	{
		base.imethod_9(posIter, context);
		if (!bool_4)
		{
			imethod_4().method_32(class5120_0.method_57(), (Interface160)class4943_0);
		}
	}

	protected void method_31(Class4948 text)
	{
		Class5677.smethod_21(text, class5120_0.vmethod_31());
		text.method_13(class5729_0.method_1() - class5729_0.method_3());
		text.method_59(class5729_0.method_1());
		Class5677.smethod_18(text, class5729_0);
		text.method_29(Class5757.int_4, class5120_0.method_49());
		Class5677.smethod_20(text, class5120_0.imethod_1());
		Class5677.smethod_19(text, class5120_0.method_50());
	}

	protected int method_32(string str)
	{
		int num = 0;
		for (int i = 0; i < str.Length; i++)
		{
			num += class5729_0.method_16(str[i]);
		}
		return num;
	}

	protected int method_33()
	{
		return class5120_0.method_41();
	}
}
