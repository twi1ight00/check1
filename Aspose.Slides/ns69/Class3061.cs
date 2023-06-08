using System.Collections.Generic;

namespace ns69;

internal sealed class Class3061
{
	private List<Class3060> list_0;

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

	public Class3060 this[int i]
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

	public Class3061()
	{
		list_0 = new List<Class3060>();
	}

	public Class3061(int capacity)
	{
		list_0 = new List<Class3060>(capacity);
	}

	public void Add(Class3060 vertexList)
	{
		list_0.Add(vertexList);
	}

	public void Remove(Class3060 vertexList)
	{
		list_0.Remove(vertexList);
	}

	public int IndexOf(Class3060 vertexList)
	{
		return list_0.IndexOf(vertexList);
	}

	public void Clear()
	{
		list_0.Clear();
	}
}
