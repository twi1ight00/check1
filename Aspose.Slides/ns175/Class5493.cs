using System.Collections;
using ns190;

namespace ns175;

internal class Class5493
{
	private int int_0;

	private ArrayList arrayList_0;

	public int method_0()
	{
		return int_0;
	}

	public ArrayList method_1()
	{
		return arrayList_0;
	}

	public void method_2()
	{
		int_0 = 0;
		if (arrayList_0 != null)
		{
			arrayList_0.Clear();
		}
	}

	public void method_3(Class5125 pageSequence, int pageCounT)
	{
		int_0 += pageCounT;
		if (arrayList_0 == null)
		{
			arrayList_0 = new ArrayList();
		}
		arrayList_0.Add(new Class5491(pageSequence.vmethod_31(), pageCounT));
	}
}
