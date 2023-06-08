using System.Drawing;

namespace ns253;

internal class Class6449
{
	private int int_0 = 45720;

	private int int_1 = 91440;

	private int int_2 = 91440;

	private int int_3 = 45720;

	public int Top
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	public int Bottom
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public int Left
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public int Right
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public Class6449()
	{
	}

	public Class6449(int left, int top, int right, int bottom)
	{
		int_0 = bottom;
		int_1 = left;
		int_2 = right;
		int_3 = top;
	}

	public static Class6449 smethod_0()
	{
		return new Class6449(0, 0, 0, 0);
	}

	public bool Equals(Class6449 other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		if (other.int_0 == int_0 && other.int_1 == int_1 && other.int_2 == int_2)
		{
			return other.int_3 == int_3;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (object.ReferenceEquals(this, obj))
		{
			return true;
		}
		if (obj.GetType() != typeof(Class6449))
		{
			return false;
		}
		return Equals((Class6449)obj);
	}

	public override int GetHashCode()
	{
		int num = int_0;
		num = (num * 397) ^ int_1;
		num = (num * 397) ^ int_2;
		return (num * 397) ^ int_3;
	}

	public RectangleF method_0(RectangleF input)
	{
		return RectangleF.FromLTRB(input.Left + (float)Left, input.Top + (float)Top, input.Right - (float)Right, input.Bottom - (float)Bottom);
	}
}
