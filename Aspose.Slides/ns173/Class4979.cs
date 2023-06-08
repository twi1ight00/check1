using System;
using System.Collections;
using System.Globalization;

namespace ns173;

internal class Class4979
{
	private ArrayList arrayList_0;

	private int int_0;

	protected Class4975 class4975_0;

	public Class4979()
	{
		arrayList_0 = new ArrayList();
	}

	public virtual void vmethod_0(Class4975 pageSequence)
	{
		if (pageSequence == null)
		{
			throw new NullReferenceException("pageSequence must not be null");
		}
		if (class4975_0 != null)
		{
			int_0 += class4975_0.method_12();
		}
		class4975_0 = pageSequence;
		arrayList_0.Add(class4975_0);
	}

	public virtual void vmethod_1(Class4974 page)
	{
		class4975_0.method_11(page);
		page.method_16(int_0 + class4975_0.method_12() - 1);
		page.method_9(class4975_0);
	}

	public virtual void vmethod_2(Interface157 ext)
	{
	}

	public virtual void vmethod_3()
	{
	}

	public Class4975 method_0()
	{
		return class4975_0;
	}

	public int method_1()
	{
		return arrayList_0.Count;
	}

	public int method_2(int seq)
	{
		return ((Class4975)arrayList_0[seq - 1]).method_12();
	}

	public Class4974 method_3(int seq, int count)
	{
		return ((Class4975)arrayList_0[seq - 1]).method_13(count);
	}

	public virtual void vmethod_4(CultureInfo locale)
	{
	}
}
