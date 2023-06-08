using System;

namespace ns167;

internal class Class4845
{
	private int int_0 = int_2;

	private int int_1 = int_2;

	private Class4844 class4844_0;

	private static readonly int int_2 = -1;

	internal Class4779 Value
	{
		get
		{
			return class4844_0[int_0][int_1];
		}
		set
		{
			class4844_0[int_0][int_1] = value;
		}
	}

	internal Class4783 ParentPlacementLine => new Class4783(class4844_0[int_0]);

	internal int Row => int_0;

	internal int Column => int_1;

	internal Class4845(int rowIndex, int colIndex, Class4844 parent)
	{
		if (parent == null)
		{
			throw new ArgumentException("parent");
		}
		int_0 = rowIndex;
		int_1 = colIndex;
		class4844_0 = parent;
	}

	internal void Remove()
	{
		Value = new Class4789();
		Value.vmethod_0();
	}

	internal void method_0()
	{
		if (Value is Class4780)
		{
			Class4780 @class = (Class4780)Value;
			if (@class.ChildrenCount == 0)
			{
				Remove();
			}
		}
	}

	internal bool method_1()
	{
		if (!method_2())
		{
			return false;
		}
		if (int_1 >= 0)
		{
			return int_1 < class4844_0[int_0].Count;
		}
		return false;
	}

	internal bool method_2()
	{
		if (int_0 >= 0)
		{
			return int_0 < class4844_0.LineCount;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj != null && !object.ReferenceEquals(obj as Class4845, null))
		{
			Class4845 @class = obj as Class4845;
			if (@class != null)
			{
				if (class4844_0 == @class.class4844_0 && Row == @class.Row)
				{
					return Column == @class.Column;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Row.GetHashCode() ^ Column.GetHashCode() ^ class4844_0.GetHashCode();
	}

	public static bool operator ==(Class4845 left, Class4845 right)
	{
		return left?.Equals(right) ?? ((object)right == null);
	}

	public static bool operator !=(Class4845 left, Class4845 right)
	{
		return !(left == right);
	}
}
