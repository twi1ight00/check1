namespace ns252;

internal class Class6329
{
	private const double double_0 = 100000.0;

	private readonly double double_1;

	public double Value => double_1;

	public double Fraction => double_1 / 100000.0;

	public Class6329()
	{
	}

	public Class6329(double value)
	{
		double_1 = value;
	}

	public static Class6329 smethod_0(double fraction)
	{
		return new Class6329(fraction * 100000.0);
	}

	public bool Equals(Class6329 other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		return other.double_1.Equals(double_1);
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
		if (obj.GetType() != typeof(Class6329))
		{
			return false;
		}
		return Equals((Class6329)obj);
	}

	public override int GetHashCode()
	{
		return double_1.GetHashCode();
	}
}
