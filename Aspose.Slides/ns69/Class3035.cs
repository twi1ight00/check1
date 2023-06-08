using System.Collections.Generic;

namespace ns69;

internal sealed class Class3035
{
	private List<Class3033> list_0;

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

	public Class3033 this[int i]
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

	public Class3035()
	{
		list_0 = new List<Class3033>();
	}

	public Class3035(int capacity)
	{
		list_0 = new List<Class3033>(capacity);
	}

	public void Add(Class3033 edge)
	{
		list_0.Add(edge);
	}

	public void method_0(Class3035 edges)
	{
		for (int i = 0; i < edges.Count; i++)
		{
			list_0.Add(edges[i]);
		}
	}

	public void Remove(Class3033 edge)
	{
		list_0.Remove(edge);
	}

	public void RemoveAt(int index)
	{
		list_0.RemoveAt(index);
	}

	public void method_1(IComparer<Class3033> comparer)
	{
		list_0.Sort(comparer);
	}

	public int method_2(Class3033 edge)
	{
		return list_0.BinarySearch(edge);
	}

	public void method_3(Class3033[] edges)
	{
		for (int i = 0; i < edges.Length; i++)
		{
			list_0.Add(edges[i]);
		}
	}

	public void Insert(int index, Class3033 insertedEdge)
	{
		list_0.Insert(index, insertedEdge);
	}

	public void method_4(Class3033 edge)
	{
		int num = method_2(edge);
		if (num < 0)
		{
			Insert(~num, edge);
		}
		else
		{
			Insert(num + 1, edge);
		}
	}

	public void Clear()
	{
		list_0.Clear();
	}
}
