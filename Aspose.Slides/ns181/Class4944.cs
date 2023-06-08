using System;
using System.Collections;
using ns173;

namespace ns181;

internal class Class4944 : Class4943
{
	internal ArrayList arrayList_1 = new ArrayList();

	protected bool bool_0;

	protected int int_17;

	private int int_18;

	public override void vmethod_2(Class4942 c)
	{
		if (arrayList_1.Count == 0)
		{
			bool_0 = method_12() == 0;
		}
		Class4943 @class = (Class4943)c;
		arrayList_1.Add(@class);
		@class.vmethod_3(this);
		if (bool_0)
		{
			method_40(@class.method_14());
		}
		method_52(@class.method_18());
		int num = @class.vmethod_6();
		int_17 = Math.Min(int_17, num);
		int_18 = Math.Max(int_18, num + @class.vmethod_7());
	}

	internal override int vmethod_6()
	{
		return method_42() + int_17;
	}

	internal override int vmethod_7()
	{
		return int_18 - int_17;
	}

	public virtual ArrayList vmethod_9()
	{
		return arrayList_1;
	}

	public override bool vmethod_5(double variationFactor, int lineStretch, int lineShrink)
	{
		bool flag = false;
		int num = 0;
		int i = 0;
		for (int count = arrayList_1.Count; i < count; i++)
		{
			Class4943 @class = (Class4943)arrayList_1[i];
			flag |= @class.vmethod_5(variationFactor, lineStretch, lineShrink);
			num += @class.method_12();
		}
		method_11(num);
		return flag;
	}

	public override ArrayList vmethod_8(ArrayList runs)
	{
		foreach (Class4943 item in vmethod_9())
		{
			runs = item.vmethod_8(runs);
		}
		return runs;
	}

	public void method_51()
	{
		foreach (Class4943 item in arrayList_1)
		{
			item.method_17();
		}
	}

	private void method_52(int newLevel)
	{
		if (newLevel < 0)
		{
			return;
		}
		int num = method_18();
		if (num >= 0)
		{
			if (newLevel < num)
			{
				method_16(newLevel);
			}
		}
		else
		{
			method_16(newLevel);
		}
	}
}
