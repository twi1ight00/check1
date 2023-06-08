using System;
using System.Collections;
using ns22;

namespace ns18;

internal class Class1408 : Hashtable
{
	private readonly bool bool_0;

	private uint uint_0;

	internal Interface46 this[uint uint_1]
	{
		get
		{
			if (base.ContainsKey(uint_1))
			{
				return base[uint_1] as Interface46;
			}
			return null;
		}
	}

	internal Class1408(bool bool_1)
	{
		bool_0 = bool_1;
	}

	internal void Add(Interface46 interface46_0)
	{
		uint num;
		if (!bool_0)
		{
			num = ((interface46_0 != null) ? method_1() : uint_0++);
		}
		else if (base.Count <= 19)
		{
			num = uint_0++ | 0x80000000u;
			interface46_0.imethod_1(num);
		}
		else
		{
			num = interface46_0.imethod_0();
		}
		base[num] = interface46_0;
	}

	internal void method_0(uint uint_1)
	{
		if (bool_0)
		{
			if ((uint_1 & 0x80000000u) != 2147483648u)
			{
				base.Remove(uint_1);
			}
		}
		else
		{
			base[uint_1] = null;
		}
	}

	[Attribute0(true)]
	private uint method_1()
	{
		uint num = 0u;
		while (true)
		{
			if (num < base.Count)
			{
				if (base.ContainsKey(num))
				{
					if (base[num] == null)
					{
						break;
					}
					num++;
					continue;
				}
				throw new Exception("WMF Objects find slot error");
			}
			throw new Exception("Object count is out of range.");
		}
		return num;
	}
}
