using System.Collections;
using System.Runtime.CompilerServices;
using ns59;

namespace ns27;

internal class Class624 : Class538
{
	private ArrayList arrayList_0;

	private long long_0;

	internal Class624()
	{
		method_2(215);
	}

	[SpecialName]
	internal void method_4(ArrayList arrayList_1)
	{
		arrayList_0 = arrayList_1;
	}

	internal override void vmethod_0(Class1725 class1725_0)
	{
		long_0 = class1725_0.method_10();
		if (arrayList_0.Count > 0)
		{
			method_0((short)(2 * arrayList_0.Count));
			class1725_0.method_7(method_1());
			class1725_0.method_7(base.Length);
			int count = arrayList_0.Count;
			for (int i = 0; i < count; i++)
			{
				uint num = (uint)arrayList_0[i];
				if (i == 0)
				{
					class1725_0.method_4((uint)(int)long_0 - num);
				}
				else if (i > 1)
				{
					class1725_0.method_6((ushort)(num - (uint)arrayList_0[i - 1]));
				}
			}
		}
		else
		{
			class1725_0.method_7(method_1());
			class1725_0.method_8(4);
			class1725_0.method_5(0);
		}
	}
}
