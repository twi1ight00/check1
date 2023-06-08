using System.Collections.Generic;

namespace ns69;

internal sealed class Class3060
{
	private List<Class3059> list_0;

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

	public Class3059 this[int i]
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

	public Class3060()
	{
		list_0 = new List<Class3059>();
	}

	public Class3060(int capacity)
	{
		list_0 = new List<Class3059>(capacity);
	}

	public Class3060(Class3060 vertices)
	{
		list_0 = new List<Class3059>(vertices.Count);
		method_0(vertices);
	}

	public void Add(Class3059 vertex)
	{
		list_0.Add(vertex);
	}

	public void method_0(Class3060 vertices)
	{
		for (int i = 0; i < vertices.Count; i++)
		{
			list_0.Add(vertices[i]);
		}
	}

	public void method_1(IEnumerable<Class3059> vertices)
	{
		list_0.AddRange(vertices);
	}

	public void Remove(Class3059 vertex)
	{
		list_0.Remove(vertex);
	}

	public void RemoveAt(int index)
	{
		list_0.RemoveAt(index);
	}

	public void method_2(IComparer<Class3059> comparer)
	{
		list_0.Sort(comparer);
	}

	public int IndexOf(Class3059 vertex)
	{
		return list_0.IndexOf(vertex);
	}

	public void Clear()
	{
		list_0.Clear();
	}

	public void Insert(int index, Class3059 vertex)
	{
		list_0.Insert(index, vertex);
	}
}
