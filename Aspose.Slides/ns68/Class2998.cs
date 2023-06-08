using System.Collections.Generic;

namespace ns68;

internal sealed class Class2998
{
	private List<Class2994> list_0;

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

	public Class2994 this[int i]
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

	public Class2998()
	{
		list_0 = new List<Class2994>();
	}

	public Class2998(int capacity)
	{
		list_0 = new List<Class2994>(capacity);
	}

	public void Add(Class2994 structuralEdgeSegment)
	{
		list_0.Add(structuralEdgeSegment);
	}

	public void method_0(Class2998 structuralEdgeSegments)
	{
		for (int i = 0; i < structuralEdgeSegments.Count; i++)
		{
			list_0.Add(structuralEdgeSegments[i]);
		}
	}

	public void Remove(Class2994 structuralEdgeSegment)
	{
		list_0.Remove(structuralEdgeSegment);
	}

	public void RemoveAt(int index)
	{
		list_0.RemoveAt(index);
	}

	public void method_1(IComparer<Class2994> comparer)
	{
		list_0.Sort(comparer);
	}

	public int method_2(Class2994 structuralEdgeSegment)
	{
		return list_0.BinarySearch(structuralEdgeSegment);
	}

	public void method_3(Class2994[] structuralEdgeSegment)
	{
		for (int i = 0; i < structuralEdgeSegment.Length; i++)
		{
			list_0.Add(structuralEdgeSegment[i]);
		}
	}

	public void Insert(int index, Class2994 insertedStructuralEdgeSegment)
	{
		list_0.Insert(index, insertedStructuralEdgeSegment);
	}

	public void method_4(Class2994 structuralEdgeSegment)
	{
		int num = method_2(structuralEdgeSegment);
		if (num < 0)
		{
			Insert(~num, structuralEdgeSegment);
		}
		else
		{
			Insert(num + 1, structuralEdgeSegment);
		}
	}

	public void Clear()
	{
		list_0.Clear();
	}
}
