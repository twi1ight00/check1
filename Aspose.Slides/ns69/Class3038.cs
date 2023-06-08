using System.Collections.Generic;
using ns67;

namespace ns69;

internal sealed class Class3038
{
	private List<Struct159> list_0;

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

	public Struct159 this[int i]
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

	public Class3038(int capacity)
	{
		list_0 = new List<Struct159>(capacity);
	}

	public void Add(Struct159 planePoint)
	{
		list_0.Add(planePoint);
	}

	public void Remove(Struct159 planePoint)
	{
		list_0.Remove(planePoint);
	}

	public int IndexOf(Struct159 planePoint)
	{
		return list_0.IndexOf(planePoint);
	}

	public void Clear()
	{
		list_0.Clear();
	}
}
