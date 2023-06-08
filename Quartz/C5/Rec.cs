using System;
using System.Runtime.InteropServices;
using System.Text;

namespace C5;

internal struct Rec<T1, T2> : IEquatable<Rec<T1, T2>>, IShowable, IFormattable
{
	[ComVisible(true)]
	public readonly T1 X1;

	[ComVisible(true)]
	public readonly T2 X2;

	[Tested]
	[ComVisible(true)]
	public Rec(T1 x1, T2 x2)
	{
		X1 = x1;
		X2 = x2;
	}

	[Tested]
	[ComVisible(true)]
	public bool Equals(Rec<T1, T2> other)
	{
		bool num;
		if (X1 != null)
		{
			T1 x = X1;
			num = x.Equals(other.X1);
		}
		else
		{
			num = other.X1 == null;
		}
		if (num)
		{
			if (X2 != null)
			{
				T2 x2 = X2;
				return x2.Equals(other.X2);
			}
			return other.X2 == null;
		}
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public override bool Equals(object obj)
	{
		if (!(obj is Rec<T1, T2>))
		{
			return false;
		}
		return Equals((Rec<T1, T2>)obj);
	}

	[Tested]
	[ComVisible(true)]
	public static bool operator ==(Rec<T1, T2> record1, Rec<T1, T2> record2)
	{
		return record1.Equals(record2);
	}

	[Tested]
	[ComVisible(true)]
	public static bool operator !=(Rec<T1, T2> record1, Rec<T1, T2> record2)
	{
		return !record1.Equals(record2);
	}

	[Tested]
	[ComVisible(true)]
	public override int GetHashCode()
	{
		int num;
		if (X1 != null)
		{
			T1 x = X1;
			num = x.GetHashCode();
		}
		else
		{
			num = 0;
		}
		int num2 = num;
		int num3 = num2 * 387281;
		int num4;
		if (X2 != null)
		{
			T2 x2 = X2;
			num4 = x2.GetHashCode();
		}
		else
		{
			num4 = 0;
		}
		return num3 + num4;
	}

	[ComVisible(true)]
	public override string ToString()
	{
		return $"({X1}, {X2})";
	}

	[ComVisible(true)]
	public bool Show(StringBuilder stringbuilder, ref int rest, IFormatProvider formatProvider)
	{
		bool flag = true;
		stringbuilder.Append("(");
		rest -= 2;
		try
		{
			if (flag = !Showing.Show(X1, stringbuilder, ref rest, formatProvider))
			{
				return false;
			}
			stringbuilder.Append(", ");
			rest -= 2;
			if (flag = !Showing.Show(X2, stringbuilder, ref rest, formatProvider))
			{
				return false;
			}
		}
		finally
		{
			if (flag)
			{
				stringbuilder.Append("...");
				rest -= 3;
			}
			stringbuilder.Append(")");
		}
		return true;
	}

	[ComVisible(true)]
	public string ToString(string format, IFormatProvider formatProvider)
	{
		return Showing.ShowString(this, format, formatProvider);
	}
}
internal struct Rec<T1, T2, T3> : IEquatable<Rec<T1, T2, T3>>, IShowable, IFormattable
{
	[ComVisible(true)]
	public readonly T1 X1;

	[ComVisible(true)]
	public readonly T2 X2;

	[ComVisible(true)]
	public readonly T3 X3;

	[Tested]
	[ComVisible(true)]
	public Rec(T1 x1, T2 x2, T3 x3)
	{
		X1 = x1;
		X2 = x2;
		X3 = x3;
	}

	[Tested]
	[ComVisible(true)]
	public bool Equals(Rec<T1, T2, T3> other)
	{
		bool num;
		if (X1 != null)
		{
			T1 x = X1;
			num = x.Equals(other.X1);
		}
		else
		{
			num = other.X1 == null;
		}
		if (num)
		{
			bool num2;
			if (X2 != null)
			{
				T2 x2 = X2;
				num2 = x2.Equals(other.X2);
			}
			else
			{
				num2 = other.X2 == null;
			}
			if (num2)
			{
				if (X3 != null)
				{
					T3 x3 = X3;
					return x3.Equals(other.X3);
				}
				return other.X3 == null;
			}
		}
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public override bool Equals(object obj)
	{
		if (!(obj is Rec<T1, T2, T3>))
		{
			return false;
		}
		return Equals((Rec<T1, T2, T3>)obj);
	}

	[Tested]
	[ComVisible(true)]
	public static bool operator ==(Rec<T1, T2, T3> record1, Rec<T1, T2, T3> record2)
	{
		return record1.Equals(record2);
	}

	[Tested]
	[ComVisible(true)]
	public static bool operator !=(Rec<T1, T2, T3> record1, Rec<T1, T2, T3> record2)
	{
		return !record1.Equals(record2);
	}

	[Tested]
	[ComVisible(true)]
	public override int GetHashCode()
	{
		int num;
		if (X1 != null)
		{
			T1 x = X1;
			num = x.GetHashCode();
		}
		else
		{
			num = 0;
		}
		int num2 = num;
		int num3 = num2 * 387281;
		int num4;
		if (X2 != null)
		{
			T2 x2 = X2;
			num4 = x2.GetHashCode();
		}
		else
		{
			num4 = 0;
		}
		num2 = num3 + num4;
		int num5 = num2 * 387281;
		int num6;
		if (X3 != null)
		{
			T3 x3 = X3;
			num6 = x3.GetHashCode();
		}
		else
		{
			num6 = 0;
		}
		return num5 + num6;
	}

	[ComVisible(true)]
	public override string ToString()
	{
		return $"({X1}, {X2}, {X3})";
	}

	[ComVisible(true)]
	public bool Show(StringBuilder stringbuilder, ref int rest, IFormatProvider formatProvider)
	{
		bool flag = true;
		stringbuilder.Append("(");
		rest -= 2;
		try
		{
			if (flag = !Showing.Show(X1, stringbuilder, ref rest, formatProvider))
			{
				return false;
			}
			stringbuilder.Append(", ");
			rest -= 2;
			if (flag = !Showing.Show(X2, stringbuilder, ref rest, formatProvider))
			{
				return false;
			}
			stringbuilder.Append(", ");
			rest -= 2;
			if (flag = !Showing.Show(X3, stringbuilder, ref rest, formatProvider))
			{
				return false;
			}
		}
		finally
		{
			if (flag)
			{
				stringbuilder.Append("...");
				rest -= 3;
			}
			stringbuilder.Append(")");
		}
		return true;
	}

	[ComVisible(true)]
	public string ToString(string format, IFormatProvider formatProvider)
	{
		return Showing.ShowString(this, format, formatProvider);
	}
}
internal struct Rec<T1, T2, T3, T4> : IEquatable<Rec<T1, T2, T3, T4>>, IShowable, IFormattable
{
	[ComVisible(true)]
	public readonly T1 X1;

	[ComVisible(true)]
	public readonly T2 X2;

	[ComVisible(true)]
	public readonly T3 X3;

	[ComVisible(true)]
	public readonly T4 X4;

	[Tested]
	[ComVisible(true)]
	public Rec(T1 x1, T2 x2, T3 x3, T4 x4)
	{
		X1 = x1;
		X2 = x2;
		X3 = x3;
		X4 = x4;
	}

	[Tested]
	[ComVisible(true)]
	public bool Equals(Rec<T1, T2, T3, T4> other)
	{
		bool num;
		if (X1 != null)
		{
			T1 x = X1;
			num = x.Equals(other.X1);
		}
		else
		{
			num = other.X1 == null;
		}
		if (num)
		{
			bool num2;
			if (X2 != null)
			{
				T2 x2 = X2;
				num2 = x2.Equals(other.X2);
			}
			else
			{
				num2 = other.X2 == null;
			}
			if (num2)
			{
				bool num3;
				if (X3 != null)
				{
					T3 x3 = X3;
					num3 = x3.Equals(other.X3);
				}
				else
				{
					num3 = other.X3 == null;
				}
				if (num3)
				{
					if (X4 != null)
					{
						T4 x4 = X4;
						return x4.Equals(other.X4);
					}
					return other.X4 == null;
				}
			}
		}
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public override bool Equals(object obj)
	{
		if (!(obj is Rec<T1, T2, T3, T4>))
		{
			return false;
		}
		return Equals((Rec<T1, T2, T3, T4>)obj);
	}

	[Tested]
	[ComVisible(true)]
	public static bool operator ==(Rec<T1, T2, T3, T4> record1, Rec<T1, T2, T3, T4> record2)
	{
		return record1.Equals(record2);
	}

	[Tested]
	[ComVisible(true)]
	public static bool operator !=(Rec<T1, T2, T3, T4> record1, Rec<T1, T2, T3, T4> record2)
	{
		return !record1.Equals(record2);
	}

	[Tested]
	[ComVisible(true)]
	public override int GetHashCode()
	{
		int num;
		if (X1 != null)
		{
			T1 x = X1;
			num = x.GetHashCode();
		}
		else
		{
			num = 0;
		}
		int num2 = num;
		int num3 = num2 * 387281;
		int num4;
		if (X2 != null)
		{
			T2 x2 = X2;
			num4 = x2.GetHashCode();
		}
		else
		{
			num4 = 0;
		}
		num2 = num3 + num4;
		int num5 = num2 * 387281;
		int num6;
		if (X3 != null)
		{
			T3 x3 = X3;
			num6 = x3.GetHashCode();
		}
		else
		{
			num6 = 0;
		}
		num2 = num5 + num6;
		int num7 = num2 * 387281;
		int num8;
		if (X4 != null)
		{
			T4 x4 = X4;
			num8 = x4.GetHashCode();
		}
		else
		{
			num8 = 0;
		}
		return num7 + num8;
	}

	[ComVisible(true)]
	public override string ToString()
	{
		return $"({X1}, {X2}, {X3}, {X4})";
	}

	[ComVisible(true)]
	public bool Show(StringBuilder stringbuilder, ref int rest, IFormatProvider formatProvider)
	{
		bool flag = true;
		stringbuilder.Append("(");
		rest -= 2;
		try
		{
			if (flag = !Showing.Show(X1, stringbuilder, ref rest, formatProvider))
			{
				return false;
			}
			stringbuilder.Append(", ");
			rest -= 2;
			if (flag = !Showing.Show(X2, stringbuilder, ref rest, formatProvider))
			{
				return false;
			}
			stringbuilder.Append(", ");
			rest -= 2;
			if (flag = !Showing.Show(X3, stringbuilder, ref rest, formatProvider))
			{
				return false;
			}
			stringbuilder.Append(", ");
			rest -= 2;
			if (flag = !Showing.Show(X4, stringbuilder, ref rest, formatProvider))
			{
				return false;
			}
		}
		finally
		{
			if (flag)
			{
				stringbuilder.Append("...");
				rest -= 3;
			}
			stringbuilder.Append(")");
		}
		return true;
	}

	[ComVisible(true)]
	public string ToString(string format, IFormatProvider formatProvider)
	{
		return Showing.ShowString(this, format, formatProvider);
	}
}
