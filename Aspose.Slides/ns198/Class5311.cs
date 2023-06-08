using System.Collections;
using ns173;
using ns181;
using ns184;
using ns189;
using ns196;
using ns205;

namespace ns198;

internal class Class5311 : Class5299
{
	private Class5119 class5119_0;

	private Class5729 class5729_0;

	public Class5311(Class5119 node)
		: base(node)
	{
		class5119_0 = node;
	}

	public override void imethod_3()
	{
		Class5730 @class = class5119_0.vmethod_3().vmethod_1();
		Class5732[] array = class5119_0.method_48().method_9(@class);
		class5729_0 = @class.method_12(array[0], class5119_0.method_48().interface182_0.imethod_6(this), array[0].method_4());
		method_26(class5119_0.method_50());
	}

	protected override Class5684 vmethod_5(Class5687 context)
	{
		return new Class5684(class5729_0, class5119_0.method_56().method_10(this).vmethod_0()
			.imethod_6(this), class5119_0.method_52(), class5119_0.method_53(), class5119_0.method_54(), class5119_0.method_55(), context.method_42());
	}

	public override Class4943 vmethod_2(Class5687 context)
	{
		Class4948 @class = new Class4948();
		string text = method_15().method_15();
		int ipD = method_32(text);
		@class.method_61(text, 0);
		@class.method_11(ipD);
		@class.method_13(class5729_0.method_1() - class5729_0.method_3());
		@class.method_59(class5729_0.method_1());
		Class5677.smethod_18(@class, class5729_0);
		@class.method_29(Class5757.int_4, class5119_0.method_49());
		Class5677.smethod_20(@class, class5119_0.imethod_1());
		Class5677.smethod_19(@class, class5119_0.method_51());
		return @class;
	}

	protected override Class4943 vmethod_4()
	{
		Class4948 @class = (Class4948)class4943_0;
		Class4948 class2 = new Class4948();
		Class5677.smethod_21(class2, class5119_0.vmethod_31());
		class2.method_11(@class.method_12());
		class2.method_13(@class.vmethod_1());
		class2.method_41(@class.method_42());
		class2.method_59(@class.method_58());
		class2.method_29(Class5757.int_4, class5119_0.method_49());
		foreach (DictionaryEntry item in @class.method_31())
		{
			class2.method_31()[item.Key] = item.Value;
		}
		method_31(class2);
		return class2;
	}

	private void method_31(Class4948 area)
	{
		area.method_60();
		area.method_61(method_15().method_15(), 0);
		area.method_47(method_32(area.vmethod_10()) - area.method_12());
		class5327_0.class5746_0 = Class5746.smethod_1(area.method_12());
	}

	private int method_32(string str)
	{
		int num = 0;
		for (int i = 0; i < str.Length; i++)
		{
			num += class5729_0.method_16(str[i]);
		}
		return num;
	}
}
