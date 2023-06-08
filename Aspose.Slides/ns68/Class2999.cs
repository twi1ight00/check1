using System.Collections.Generic;

namespace ns68;

internal sealed class Class2999
{
	private List<Class2998> list_0;

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

	public Class2998 this[int i]
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

	public Class2999()
	{
		list_0 = new List<Class2998>();
	}

	public Class2999(int capacity)
	{
		list_0 = new List<Class2998>(capacity);
	}

	public void Add(Class2998 structuralEdgeSegmentList)
	{
		list_0.Add(structuralEdgeSegmentList);
	}

	public void method_0(Class2999 structuralEdgeSegmentLists)
	{
		for (int i = 0; i < structuralEdgeSegmentLists.Count; i++)
		{
			list_0.Add(structuralEdgeSegmentLists[i]);
		}
	}

	public void Remove(Class2998 structuralEdgeSegmentList)
	{
		list_0.Remove(structuralEdgeSegmentList);
	}

	public void Insert(int index, Class2998 insertedStructuralEdgeSegmentList)
	{
		list_0.Insert(index, insertedStructuralEdgeSegmentList);
	}

	public void Clear()
	{
		list_0.Clear();
	}
}
