using System;
using ns16;

namespace ns46;

internal class Class1002 : Class999
{
	internal Class1002(string string_1)
	{
		string_0 = string_1;
	}

	internal override void vmethod_1(ref string string_1)
	{
	}

	internal override void vmethod_0(Class1008 class1008_0)
	{
		Class744 @class = class1008_0.stream6_0.method_18(string_0);
		@class.method_5(DateTime.Now);
		class1008_0.stream6_0.method_23();
		foreach (Class999 item in arrayList_0)
		{
			item.vmethod_0(class1008_0);
		}
	}
}
