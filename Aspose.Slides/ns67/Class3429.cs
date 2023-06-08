using System.Collections.Generic;

namespace ns67;

internal sealed class Class3429 : Interface49, Interface50
{
	private readonly List<Class3431> list_0 = new List<Class3431>();

	public int ShapeCount => list_0.Count;

	public Class3431[] imethod_0()
	{
		Class3431[] array = new Class3431[list_0.Count];
		for (int i = 0; i < list_0.Count; i++)
		{
			array[i] = list_0[i];
		}
		return array;
	}

	public bool imethod_1(Class3431 child)
	{
		return list_0.Contains(child);
	}

	public void imethod_2(Class3431 child)
	{
		list_0.Remove(child);
		list_0.Add(child);
	}

	public void imethod_3(Class3431 child)
	{
		list_0.Remove(child);
		list_0.Insert(0, child);
	}

	public Class3431 imethod_4(Class3431 child)
	{
		int num = list_0.IndexOf(child) - 1;
		if (0 > num)
		{
			return null;
		}
		return list_0[num];
	}

	public Class3431 imethod_5(Class3431 child)
	{
		int num = list_0.IndexOf(child) + 1;
		if (num >= list_0.Count)
		{
			return null;
		}
		return list_0[num];
	}

	internal void method_0(Class3431 child)
	{
		list_0.Add(child);
	}
}
