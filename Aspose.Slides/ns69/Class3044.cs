using System.Collections.Generic;

namespace ns69;

internal sealed class Class3044
{
	private List<Class3043> list_0;

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

	public Class3043 this[int i]
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

	public Class3044()
	{
		list_0 = new List<Class3043>();
	}

	public void Add(Class3043 trianglesInitData)
	{
		list_0.Add(trianglesInitData);
	}

	public void Remove(Class3043 trianglesInitData)
	{
		list_0.Remove(trianglesInitData);
	}

	public int IndexOf(Class3043 trianglesInitData)
	{
		return list_0.IndexOf(trianglesInitData);
	}

	public void Clear()
	{
		list_0.Clear();
	}
}
