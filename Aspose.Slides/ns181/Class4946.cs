using System.Collections;

namespace ns181;

internal class Class4946 : Class4944
{
	private int int_19;

	public void method_53(int width)
	{
		int_19 = width;
	}

	public int method_54()
	{
		return int_19;
	}

	public override int vmethod_1()
	{
		int num = 0;
		foreach (Class4943 item in vmethod_9())
		{
			if (num < item.vmethod_1())
			{
				num = item.vmethod_1();
			}
		}
		return num;
	}

	public override ArrayList vmethod_9()
	{
		int num = method_12() / int_19;
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < num; i++)
		{
			arrayList.AddRange(arrayList_1);
		}
		return arrayList;
	}

	public override bool vmethod_5(double variationFactor, int lineStretch, int lineShrink)
	{
		method_11(method_12() + class4976_0.method_0(variationFactor));
		return false;
	}
}
