using System.Collections.Generic;

namespace ns68;

internal sealed class Class3009
{
	private List<Class3007> list_0;

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

	public Class3007 this[int i]
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

	public Class3009()
	{
		list_0 = new List<Class3007>();
	}

	public Class3009(int capacity)
	{
		list_0 = new List<Class3007>(capacity);
	}

	public void Add(Class3007 cellVertexRaw1)
	{
		list_0.Add(cellVertexRaw1);
	}

	public void method_0(Class3009 cellVertexRaw1s)
	{
		for (int i = 0; i < cellVertexRaw1s.Count; i++)
		{
			list_0.Add(cellVertexRaw1s[i]);
		}
	}

	public void Remove(Class3007 cellVertexRaw1)
	{
		list_0.Remove(cellVertexRaw1);
	}

	public void RemoveAt(int index)
	{
		list_0.RemoveAt(index);
	}

	public void method_1(IComparer<Class3007> comparer)
	{
		list_0.Sort(comparer);
	}

	public int method_2(Class3007 cellVertexRaw1)
	{
		return list_0.BinarySearch(cellVertexRaw1);
	}

	public void method_3(Class3007[] cellVertexRaw1)
	{
		for (int i = 0; i < cellVertexRaw1.Length; i++)
		{
			list_0.Add(cellVertexRaw1[i]);
		}
	}

	public void Insert(int index, Class3007 insertedCellVertexRaw1)
	{
		list_0.Insert(index, insertedCellVertexRaw1);
	}

	public void method_4(Class3007 cellVertexRaw1)
	{
		int num = method_2(cellVertexRaw1);
		if (num < 0)
		{
			Insert(~num, cellVertexRaw1);
		}
		else
		{
			Insert(num + 1, cellVertexRaw1);
		}
	}

	public void Clear()
	{
		list_0.Clear();
	}
}
