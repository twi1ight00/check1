using System;
using System.Collections;
using System.Drawing;

namespace ns168;

internal class Class4795 : Class4792
{
	private readonly ArrayList arrayList_0;

	internal Class4793 this[int index]
	{
		get
		{
			if (arrayList_0.Count == 0)
			{
				return null;
			}
			return (Class4793)arrayList_0[index];
		}
		set
		{
			if (index >= Count || index < 0)
			{
				throw new ArgumentException("Please report exception. Index out of range.");
			}
			arrayList_0[index] = value;
		}
	}

	internal int Count => arrayList_0.Count;

	internal Class4795()
	{
		arrayList_0 = new ArrayList();
	}

	internal Class4795(int initialSize)
	{
		arrayList_0 = new ArrayList(initialSize);
	}

	public override void vmethod_0(Graphics canvas, PointF topLeft)
	{
		for (int i = 0; i < Count; i++)
		{
			this[i].vmethod_0(canvas, topLeft);
		}
	}

	internal void Add(Class4793 box)
	{
		arrayList_0.Add(box);
	}

	internal void method_0(Class4795 c)
	{
		foreach (Class4793 item in c.arrayList_0)
		{
			Add(item);
		}
	}

	internal void RemoveAt(int index)
	{
		if (index < Count && Count != 0)
		{
			arrayList_0.RemoveAt(index);
		}
	}
}
