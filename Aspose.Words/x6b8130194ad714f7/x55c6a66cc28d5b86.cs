namespace x6b8130194ad714f7;

internal class x55c6a66cc28d5b86
{
	private const double xf360697025d20aae = 100000.0;

	private readonly double x4574aea041dd835f;

	public double xd2f68ee6f47e9dfb => x4574aea041dd835f;

	public double x71c5078172d72420 => x4574aea041dd835f / 100000.0;

	public x55c6a66cc28d5b86()
	{
	}

	public x55c6a66cc28d5b86(double value)
	{
		x4574aea041dd835f = value;
	}

	public static x55c6a66cc28d5b86 x220dcfbc81260c16(double x27b336b929c0851c)
	{
		return new x55c6a66cc28d5b86(x27b336b929c0851c * 100000.0);
	}

	public bool Equals(x55c6a66cc28d5b86 other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		return other.x4574aea041dd835f.Equals(x4574aea041dd835f);
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
		if (obj.GetType() != typeof(x55c6a66cc28d5b86))
		{
			return false;
		}
		return Equals((x55c6a66cc28d5b86)obj);
	}

	public override int GetHashCode()
	{
		return x4574aea041dd835f.GetHashCode();
	}
}
