using System;
using System.Collections;

namespace ns164;

internal class Class4767
{
	private readonly Hashtable hashtable_0 = new Hashtable();

	public object this[Enum670 type] => hashtable_0[type];

	public int Count => hashtable_0.Count;

	public void Add(Enum670 formatType, object formatValue)
	{
		hashtable_0.Add(formatType, formatValue);
	}

	public bool method_0(Enum670 type)
	{
		return hashtable_0.ContainsKey(type);
	}

	public void method_1(Enum670 type)
	{
		if (!method_0(type))
		{
			throw new ArgumentException("Please report exception.");
		}
		hashtable_0.Remove(type);
	}
}
