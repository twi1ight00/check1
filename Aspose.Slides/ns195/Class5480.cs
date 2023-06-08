using System.Collections;

namespace ns195;

internal class Class5480
{
	private ArrayList arrayList_0;

	private int int_0;

	internal Class5480(ArrayList arrayList, int from, int to)
	{
		arrayList_0 = arrayList.GetRange(from, to - from);
		int_0 = from;
	}

	internal ArrayList method_0()
	{
		return arrayList_0;
	}

	internal void method_1()
	{
		if (arrayList_0.Count > 0)
		{
			arrayList_0.InsertRange(int_0, arrayList_0);
		}
	}
}
