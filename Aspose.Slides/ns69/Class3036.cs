using System.Collections.Generic;

namespace ns69;

internal sealed class Class3036
{
	private List<Class3035> list_0;

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

	public Class3035 this[int i]
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

	public Class3036()
	{
		list_0 = new List<Class3035>();
	}

	public Class3036(int capacity)
	{
		list_0 = new List<Class3035>(capacity);
	}

	public void Add(Class3035 edgeList)
	{
		list_0.Add(edgeList);
	}

	public void Remove(Class3035 edgeList)
	{
		list_0.Remove(edgeList);
	}

	public int IndexOf(Class3035 edgeList)
	{
		return list_0.IndexOf(edgeList);
	}

	public void Clear()
	{
		list_0.Clear();
	}
}
