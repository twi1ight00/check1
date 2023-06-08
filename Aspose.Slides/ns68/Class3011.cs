using System.Collections.Generic;

namespace ns68;

internal sealed class Class3011
{
	private List<Class3010> list_0;

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

	public Class3010 this[int i]
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

	public Class3011()
	{
		list_0 = new List<Class3010>();
	}

	public Class3011(int capacity)
	{
		list_0 = new List<Class3010>(capacity);
	}

	public void Add(Class3010 cellVertexRaw2)
	{
		list_0.Add(cellVertexRaw2);
	}

	public void method_0(Class3011 cellVertexRaw2s)
	{
		for (int i = 0; i < cellVertexRaw2s.Count; i++)
		{
			list_0.Add(cellVertexRaw2s[i]);
		}
	}

	public void Remove(Class3010 cellVertexRaw2)
	{
		list_0.Remove(cellVertexRaw2);
	}

	public void RemoveAt(int index)
	{
		list_0.RemoveAt(index);
	}

	public void method_1(IComparer<Class3010> comparer)
	{
		list_0.Sort(comparer);
	}

	public int method_2(Class3010 cellVertexRaw2)
	{
		return list_0.BinarySearch(cellVertexRaw2);
	}

	public void method_3(Class3010[] cellVertexRaw2)
	{
		for (int i = 0; i < cellVertexRaw2.Length; i++)
		{
			list_0.Add(cellVertexRaw2[i]);
		}
	}

	public void Insert(int index, Class3010 insertedCellVertexRaw2)
	{
		list_0.Insert(index, insertedCellVertexRaw2);
	}

	public void method_4(Class3010 cellVertexRaw2)
	{
		int num = method_2(cellVertexRaw2);
		if (num < 0)
		{
			Insert(~num, cellVertexRaw2);
		}
		else
		{
			Insert(num + 1, cellVertexRaw2);
		}
	}

	public void Clear()
	{
		list_0.Clear();
	}
}
