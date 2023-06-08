using System.Collections;
using System.Text;
using ns227;

namespace ns229;

internal class Class6110
{
	internal class Class6111 : IComparer
	{
		public int Compare(object x, object y)
		{
			return ((Class6110)x).int_1 - ((Class6110)y).int_1;
		}
	}

	internal class Class6112 : IComparer
	{
		public int Compare(object x, object y)
		{
			return ((Class6110)x).int_0 - ((Class6110)y).int_0;
		}
	}

	private int int_0;

	private int int_1;

	private bool bool_0;

	private int int_2;

	private bool bool_1;

	private long long_0;

	private bool bool_2;

	public static Class6111 class6111_0 = new Class6111();

	public static Class6112 class6112_0 = new Class6112();

	public Class6110(int tag, long checksum, int offset, int length)
	{
		int_0 = tag;
		long_0 = checksum;
		bool_2 = true;
		int_1 = offset;
		bool_0 = true;
		int_2 = length;
		bool_1 = true;
	}

	public Class6110(int tag, int length)
	{
		int_0 = tag;
		long_0 = 0L;
		bool_2 = false;
		int_1 = 0;
		bool_0 = false;
		int_2 = length;
		bool_1 = true;
	}

	public Class6110(int tag)
	{
		int_0 = tag;
		long_0 = 0L;
		bool_2 = false;
		int_1 = 0;
		bool_0 = false;
		int_2 = 0;
		bool_1 = true;
	}

	public bool Equals(Class6110 other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		return other.int_0 == int_0;
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
		if (obj.GetType() != typeof(Class6110))
		{
			return false;
		}
		return Equals((Class6110)obj);
	}

	public override int GetHashCode()
	{
		return int_0;
	}

	public static bool operator ==(Class6110 left, Class6110 right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Class6110 left, Class6110 right)
	{
		return !object.Equals(left, right);
	}

	public int method_0()
	{
		return int_0;
	}

	public int method_1()
	{
		return int_1;
	}

	public bool method_2()
	{
		return bool_0;
	}

	public int method_3()
	{
		return int_2;
	}

	public bool method_4()
	{
		return bool_1;
	}

	public long method_5()
	{
		return long_0;
	}

	public bool method_6()
	{
		return bool_2;
	}

	public string method_7()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("[");
		stringBuilder.Append(Class6116.smethod_3(int_0));
		stringBuilder.Append(", ");
		stringBuilder.Append($"{long_0:x}");
		stringBuilder.Append(", ");
		stringBuilder.Append($"{int_1:x}");
		stringBuilder.Append(", ");
		stringBuilder.Append($"{int_2:x}");
		stringBuilder.Append("]");
		return stringBuilder.ToString();
	}
}
