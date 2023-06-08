using System;
using System.Collections;
using System.Collections.Generic;

namespace ns83;

internal abstract class Class7222<T>
{
	protected int int_0;

	protected T gparam_0;

	protected IList<T> ilist_0;

	protected bool bool_0;

	protected string string_0;

	protected Interface387 interface387_0;

	public string Description => string_0;

	public Class7222(Interface387 adaptor, string elementDescription)
	{
		string_0 = elementDescription;
		interface387_0 = adaptor;
	}

	public Class7222(Interface387 adaptor, string elementDescription, T oneElement)
		: this(adaptor, elementDescription)
	{
		Add(oneElement);
	}

	public Class7222(Interface387 adaptor, string elementDescription, IList<T> elements)
		: this(adaptor, elementDescription)
	{
		gparam_0 = default(T);
		ilist_0 = elements;
	}

	[Obsolete("This constructor is for internal use only and might be phased out soon. Use instead the one with IList<T>.")]
	public Class7222(Interface387 adaptor, string elementDescription, IList elements)
		: this(adaptor, elementDescription)
	{
		gparam_0 = default(T);
		ilist_0 = new List<T>();
		if (elements == null)
		{
			return;
		}
		foreach (T element in elements)
		{
			ilist_0.Add(element);
		}
	}

	public void Add(T el)
	{
		if (el != null)
		{
			if (ilist_0 != null)
			{
				ilist_0.Add(el);
				return;
			}
			if (gparam_0 == null)
			{
				gparam_0 = el;
				return;
			}
			ilist_0 = new List<T>(5);
			ilist_0.Add(gparam_0);
			gparam_0 = default(T);
			ilist_0.Add(el);
		}
	}

	public virtual void Reset()
	{
		int_0 = 0;
		bool_0 = true;
	}

	public bool method_0()
	{
		if (gparam_0 != null && int_0 < 1)
		{
			return true;
		}
		if (ilist_0 != null)
		{
			return int_0 < ilist_0.Count;
		}
		return false;
	}

	public virtual object vmethod_0()
	{
		return method_1();
	}

	protected object method_1()
	{
		int num = method_2();
		if (num == 0)
		{
			throw new Exception76(string_0);
		}
		if (int_0 >= num)
		{
			if (num == 1)
			{
				return vmethod_1(gparam_0);
			}
			throw new Exception74(string_0);
		}
		if (gparam_0 != null)
		{
			int_0++;
			return vmethod_1(gparam_0);
		}
		return vmethod_1(ilist_0[int_0++]);
	}

	protected virtual object vmethod_1(T el)
	{
		return el;
	}

	public int method_2()
	{
		if (gparam_0 != null)
		{
			return 1;
		}
		if (ilist_0 != null)
		{
			return ilist_0.Count;
		}
		return 0;
	}
}
