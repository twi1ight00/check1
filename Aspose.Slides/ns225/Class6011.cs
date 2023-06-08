using System;
using System.Collections;

namespace ns225;

internal class Class6011 : Interface256
{
	private ArrayList arrayList_0 = new ArrayList();

	private int int_0 = -1;

	public Class6011(ICollection collection)
	{
		foreach (object item in collection)
		{
			arrayList_0.Add(item);
		}
	}

	public bool imethod_0()
	{
		if (arrayList_0.Count == 0)
		{
			return false;
		}
		return int_0 + 1 < arrayList_0.Count;
	}

	public object imethod_1()
	{
		if (!imethod_0())
		{
			throw new InvalidOperationException();
		}
		return arrayList_0[++int_0];
	}

	public void Remove()
	{
		throw new NotImplementedException();
	}
}
