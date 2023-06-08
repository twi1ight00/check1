using System;
using System.Collections;

namespace ns183;

internal class Class5495 : Interface168, Interface208
{
	private ArrayList arrayList_0;

	private int int_0;

	private int int_1 = -1;

	public Class5495(ArrayList arrayList)
	{
		arrayList_0 = arrayList;
	}

	public Class5495(ArrayList arrayList, int pos)
	{
		arrayList_0 = arrayList;
		int_0 = pos;
	}

	public void imethod_6()
	{
		if (int_0 <= 0)
		{
			throw new InvalidOperationException();
		}
		arrayList_0.RemoveAt(int_1);
		int_1 = -1;
		int_0--;
	}

	public void imethod_7(object e)
	{
		arrayList_0[int_0 - 1] = e;
	}

	public void imethod_8(object e)
	{
		arrayList_0.Insert(int_0++, e);
	}

	public bool imethod_0()
	{
		return int_0 < arrayList_0.Count;
	}

	public object imethod_1()
	{
		if (int_0 >= arrayList_0.Count)
		{
			throw new InvalidOperationException();
		}
		int_1 = int_0;
		return arrayList_0[int_0++];
	}

	public bool imethod_2()
	{
		return int_0 > 0;
	}

	public object imethod_3()
	{
		if (int_0 <= 0)
		{
			throw new InvalidOperationException();
		}
		int_1 = int_0 - 1;
		return arrayList_0[--int_0];
	}

	public int imethod_4()
	{
		return int_0;
	}

	public int imethod_5()
	{
		return int_0 - 1;
	}
}
