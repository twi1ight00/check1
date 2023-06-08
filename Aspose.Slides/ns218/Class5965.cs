using System;
using System.Collections;
using System.Collections.Generic;

namespace ns218;

internal class Class5965
{
	private readonly Class5962 class5962_0 = new Class5962();

	private readonly IList ilist_0 = new List<object>();

	public int StartPosition => class5962_0[0];

	public int EndPosition
	{
		get
		{
			if (class5962_0.Count > 0)
			{
				return class5962_0[class5962_0.Count - 1];
			}
			return 0;
		}
		set
		{
			class5962_0[class5962_0.Count - 1] = value;
		}
	}

	public int PositionCount => class5962_0.Count;

	public int ItemCount => ilist_0.Count;

	public int Add(int start, int end, object item)
	{
		if (class5962_0.Count == 0)
		{
			class5962_0.Add(start);
		}
		return Add(end, item);
	}

	public int Add(int start, object item)
	{
		class5962_0.Add(start);
		return ilist_0.Add(item);
	}

	public void Add(int position)
	{
		class5962_0.Add(position);
	}

	public void RemoveAt(int index)
	{
		class5962_0.RemoveAt(index);
		ilist_0.RemoveAt(index);
	}

	public void Clear()
	{
		class5962_0.Clear();
		ilist_0.Clear();
	}

	public int method_0(int position)
	{
		int num = method_8(position, isExact: false);
		if (num < 0)
		{
			if (class5962_0.Count <= 1)
			{
				throw new InvalidOperationException("Cannot find an entry for the specified position in the PLCF.");
			}
			num = class5962_0.Count - 2;
		}
		return num;
	}

	public int method_1(int position)
	{
		return method_8(position, isExact: true);
	}

	public int method_2(int position)
	{
		return class5962_0.vmethod_1(position);
	}

	public int method_3(int position)
	{
		int num = method_1(position);
		if (num < 0)
		{
			throw new InvalidOperationException("Cannot find an entry for the specified position in the PLCF.");
		}
		return num;
	}

	public Class5966 method_4(int position)
	{
		int num = 0;
		while (true)
		{
			if (num < class5962_0.Count)
			{
				if (class5962_0[num] >= position)
				{
					break;
				}
				num++;
				continue;
			}
			return new Class5966(this, int.MaxValue, int.MaxValue);
		}
		return new Class5966(this, num, class5962_0[num]);
	}

	public int method_5(int index)
	{
		return class5962_0[index];
	}

	public void method_6(int index, int position)
	{
		class5962_0[index] = position;
	}

	public object method_7(int index)
	{
		return ilist_0[index];
	}

	public override string ToString()
	{
		return class5962_0.ToString();
	}

	private int method_8(int pos, bool isExact)
	{
		int num = 0;
		int num2 = class5962_0.Count - 1;
		num2--;
		int num3;
		int num4;
		while (true)
		{
			if (num <= num2)
			{
				num3 = num + num2 >> 1;
				num4 = class5962_0[num3];
				int num5 = class5962_0[num3 + 1];
				if (pos < num4)
				{
					num2 = num3 - 1;
					continue;
				}
				if (pos < num5)
				{
					break;
				}
				num = num3 + 1;
				continue;
			}
			return ~num;
		}
		if (pos == num4)
		{
			return num3;
		}
		if (!isExact)
		{
			return num3;
		}
		return ~num;
	}
}
