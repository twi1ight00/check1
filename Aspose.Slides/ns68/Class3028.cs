using System.Collections.Generic;

namespace ns68;

internal sealed class Class3028
{
	private List<Class3024> list_0;

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

	public Class3024 this[int i]
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

	public Class3028()
	{
		list_0 = new List<Class3024>();
	}

	public Class3028(int capacity)
	{
		list_0 = new List<Class3024>(capacity);
	}

	public void Add(Class3024 step2Primitive)
	{
		list_0.Add(step2Primitive);
	}

	public void method_0(Class3028 step2Primitives)
	{
		for (int i = 0; i < step2Primitives.Count; i++)
		{
			list_0.Add(step2Primitives[i]);
		}
	}

	public void Remove(Class3024 step2Primitive)
	{
		list_0.Remove(step2Primitive);
	}

	public void RemoveAt(int index)
	{
		list_0.RemoveAt(index);
	}

	public void method_1(IComparer<Class3024> comparer)
	{
		list_0.Sort(comparer);
	}

	public int method_2(Class3024 step2Primitive)
	{
		return list_0.BinarySearch(step2Primitive);
	}

	public void method_3(Class3024[] step2Primitive)
	{
		for (int i = 0; i < step2Primitive.Length; i++)
		{
			list_0.Add(step2Primitive[i]);
		}
	}

	public void Insert(int index, Class3024 insertedStep2Primitive)
	{
		list_0.Insert(index, insertedStep2Primitive);
	}

	public void method_4(Class3024 step2Primitive)
	{
		int num = method_2(step2Primitive);
		if (num < 0)
		{
			Insert(~num, step2Primitive);
		}
		else
		{
			Insert(num + 1, step2Primitive);
		}
	}

	public void Clear()
	{
		list_0.Clear();
	}
}
