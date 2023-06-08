using System;
using System.Collections;
using System.Drawing;
using ns167;

namespace ns168;

internal class Class4857
{
	private bool bool_0 = true;

	private Class4780 class4780_0;

	private RectangleF rectangleF_0;

	private Class4797 class4797_0;

	private Class4797 class4797_1;

	private Class4797 class4797_2;

	private Class4797 class4797_3;

	private bool bool_1;

	private Class4857 class4857_0;

	private readonly ArrayList arrayList_0 = new ArrayList();

	private readonly bool bool_2;

	internal Class4857 this[int index] => (Class4857)arrayList_0[index];

	internal int Count => arrayList_0.Count;

	internal bool IsColumn => bool_2;

	internal Class4797 Left => class4797_0;

	internal Class4797 Right => class4797_1;

	internal Class4797 Top => class4797_2;

	internal Class4797 Bottom => class4797_3;

	internal RectangleF BoundingBox => rectangleF_0;

	internal Class4780 TextContainer
	{
		get
		{
			if (class4780_0 == null)
			{
				throw new ArgumentNullException("Please report exception.");
			}
			return class4780_0;
		}
		set
		{
			class4780_0 = value;
		}
	}

	internal bool HasBoundary
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public bool IsDummy
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	internal Class4857(Class4797 l, Class4797 t, Class4797 r, Class4797 b, bool isColumn)
	{
		class4797_0 = l;
		class4797_1 = r;
		class4797_2 = t;
		class4797_3 = b;
		bool_2 = isColumn;
		rectangleF_0 = RectangleF.FromLTRB(l.LeftVertex.X, t.TopVertex.Y, r.RightVertex.X, b.BottomVertex.Y);
	}

	internal void Add(Class4857 child)
	{
		arrayList_0.Add(child);
		child.class4857_0 = this;
	}
}
