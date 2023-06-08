using System.Collections.Generic;

namespace ns69;

internal sealed class Class3041
{
	private List<Class3040> list_0;

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

	public Class3040 this[int i]
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

	public Class3041()
	{
		list_0 = new List<Class3040>();
	}

	public void Add(Class3040 triangle)
	{
		list_0.Add(triangle);
	}

	public void Remove(Class3040 triangle)
	{
		list_0.Remove(triangle);
	}

	public int IndexOf(Class3040 triangle)
	{
		return list_0.IndexOf(triangle);
	}

	public void Clear()
	{
		list_0.Clear();
	}
}
