using System;
using System.Collections;

namespace ns264;

internal class Class6489
{
	private const int int_0 = int.MinValue;

	private const int int_1 = 19;

	private readonly Hashtable hashtable_0 = new Hashtable();

	private readonly bool bool_0;

	private int int_2;

	internal Interface318 this[int handle] => (Interface318)hashtable_0[handle];

	internal Class6489(bool isEmf)
	{
		bool_0 = isEmf;
	}

	internal void Add(Interface318 value)
	{
		int num2 = (bool_0 ? ((hashtable_0.Count > 19) ? value.Handle : (value.Handle = int_2++ | int.MinValue)) : ((value != null) ? method_1() : int_2++));
		hashtable_0[num2] = value;
	}

	internal void method_0(int handle)
	{
		if (bool_0)
		{
			if ((handle & int.MinValue) != int.MinValue)
			{
				hashtable_0.Remove(handle);
			}
		}
		else
		{
			hashtable_0[handle] = null;
		}
	}

	private int method_1()
	{
		int num = 0;
		while (true)
		{
			if (num < hashtable_0.Count)
			{
				if (hashtable_0.ContainsKey(num))
				{
					if (hashtable_0[num] == null)
					{
						break;
					}
					num++;
					continue;
				}
				throw new InvalidOperationException("WMF Objects find slot error");
			}
			throw new InvalidOperationException("Object count is out of range.");
		}
		return num;
	}
}
