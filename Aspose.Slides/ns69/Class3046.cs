using System.Collections.Generic;

namespace ns69;

internal sealed class Class3046
{
	private List<Class3057> list_0;

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

	public Class3057 this[int i]
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

	public Class3046()
	{
		list_0 = new List<Class3057>();
	}

	public Class3046(int capacity)
	{
		list_0 = new List<Class3057>(capacity);
	}

	public void Add(Class3057 connectedTriangulatedRegion)
	{
		list_0.Add(connectedTriangulatedRegion);
	}

	public void Remove(Class3057 connectedTriangulatedRegion)
	{
		list_0.Remove(connectedTriangulatedRegion);
	}

	public int IndexOf(Class3057 connectedTriangulatedRegion)
	{
		return list_0.IndexOf(connectedTriangulatedRegion);
	}

	public void Clear()
	{
		list_0.Clear();
	}
}
