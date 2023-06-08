using System.Collections.Generic;

namespace ns68;

internal sealed class Class3013
{
	private List<Class3012> list_0;

	public int Count => list_0.Count;

	public int Capacity
	{
		get
		{
			return list_0.Capacity;
		}
		set
		{
			list_0.Capacity = value;
		}
	}

	public Class3012 this[int i]
	{
		get
		{
			return list_0[i];
		}
		set
		{
			list_0[i] = value;
		}
	}

	public Class3013()
	{
		list_0 = new List<Class3012>();
	}

	public Class3013(int capacity)
	{
		list_0 = new List<Class3012>(capacity);
	}

	public void Add(Class3012 cellVertexRaw3)
	{
		list_0.Add(cellVertexRaw3);
	}

	public void method_0(Class3013 cellVertexRaw3s)
	{
		for (int i = 0; i < cellVertexRaw3s.Count; i++)
		{
			list_0.Add(cellVertexRaw3s[i]);
		}
	}

	public void Remove(Class3012 cellVertexRaw3)
	{
		list_0.Remove(cellVertexRaw3);
	}

	public void method_1(IComparer<Class3012> comparer)
	{
		list_0.Sort(comparer);
	}

	public int method_2(Class3012 cellVertexRaw3)
	{
		return list_0.BinarySearch(cellVertexRaw3);
	}

	public void method_3(Class3012[] cellVertexRaw3)
	{
		for (int i = 0; i < cellVertexRaw3.Length; i++)
		{
			list_0.Add(cellVertexRaw3[i]);
		}
	}

	public void Insert(int index, Class3012 insertedCellVertexRaw3)
	{
		list_0.Insert(index, insertedCellVertexRaw3);
	}

	public void method_4(Class3012 cellVertexRaw3)
	{
		int num = method_2(cellVertexRaw3);
		if (num < 0)
		{
			Insert(~num, cellVertexRaw3);
		}
		else
		{
			Insert(num + 1, cellVertexRaw3);
		}
	}

	public int IndexOf(Class3012 cellVertexRaw3)
	{
		return list_0.IndexOf(cellVertexRaw3);
	}

	public void method_5(int index, int count)
	{
		list_0.RemoveRange(index, count);
	}

	public void method_6()
	{
		list_0.Reverse();
	}

	public void Clear()
	{
		list_0.Clear();
	}
}
