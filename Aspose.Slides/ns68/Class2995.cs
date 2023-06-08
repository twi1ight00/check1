using System.Collections.Generic;
using System.Drawing;

namespace ns68;

internal sealed class Class2995
{
	private List<Point> list_0;

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

	public Point this[int i]
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

	public Class2995()
	{
		list_0 = new List<Point>();
	}

	public Class2995(int capacity)
	{
		list_0 = new List<Point>(capacity);
	}

	public void Add(Point point)
	{
		list_0.Add(point);
	}

	public void method_0(Class2995 points)
	{
		for (int i = 0; i < points.Count; i++)
		{
			list_0.Add(points[i]);
		}
	}

	public void Remove(Point point)
	{
		list_0.Remove(point);
	}

	public void RemoveAt(int index)
	{
		list_0.RemoveAt(index);
	}

	public void method_1(IComparer<Point> comparer)
	{
		list_0.Sort(comparer);
	}

	public int method_2(Point point)
	{
		return list_0.BinarySearch(point);
	}

	public void method_3(Point[] point)
	{
		for (int i = 0; i < point.Length; i++)
		{
			list_0.Add(point[i]);
		}
	}

	public void Insert(int index, Point insertedPoint)
	{
		list_0.Insert(index, insertedPoint);
	}

	public void method_4(Point point)
	{
		int num = method_2(point);
		if (num < 0)
		{
			Insert(~num, point);
		}
		else
		{
			Insert(num + 1, point);
		}
	}

	public void Clear()
	{
		list_0.Clear();
	}
}
