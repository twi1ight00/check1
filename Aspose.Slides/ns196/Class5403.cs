using System;
using System.Collections;
using ns183;

namespace ns196;

internal class Class5403 : Interface168
{
	protected ArrayList arrayList_0;

	protected int int_0;

	private Interface173 interface173_0;

	public Class5403(Interface173 lp)
	{
		interface173_0 = lp;
		arrayList_0 = lp.imethod_11();
	}

	public virtual bool imethod_0()
	{
		if (int_0 >= arrayList_0.Count)
		{
			return interface173_0.imethod_10(int_0);
		}
		return true;
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
		return arrayList_0[--int_0];
	}

	public object imethod_1()
	{
		if (int_0 >= arrayList_0.Count)
		{
			throw new InvalidOperationException();
		}
		return arrayList_0[int_0++];
	}

	public void imethod_6()
	{
		if (int_0 <= 0)
		{
			throw new InvalidOperationException();
		}
		arrayList_0.Remove(--int_0);
	}

	public void imethod_8(object lm)
	{
		throw new InvalidOperationException("LMiter doesn't support add");
	}

	public void imethod_7(object lm)
	{
		throw new InvalidOperationException("LMiter doesn't support set");
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
