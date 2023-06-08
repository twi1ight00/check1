using ns218;

namespace ns252;

internal class Class6330
{
	private int int_0;

	public int Value => int_0;

	public double ValueInPoints => (double)Value / 100.0;

	public double ValueInEmus => Class5955.smethod_38(ValueInPoints);

	public Class6330()
	{
	}

	public Class6330(int value)
	{
		int_0 = value;
	}

	public bool Equals(Class6330 other)
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
		if (obj.GetType() != typeof(Class6330))
		{
			return false;
		}
		return Equals((Class6330)obj);
	}

	public override int GetHashCode()
	{
		return int_0;
	}
}
