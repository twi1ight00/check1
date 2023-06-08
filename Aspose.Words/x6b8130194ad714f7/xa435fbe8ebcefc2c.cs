using x6c95d9cf46ff5f25;

namespace x6b8130194ad714f7;

internal class xa435fbe8ebcefc2c
{
	private int x4574aea041dd835f;

	public int xd2f68ee6f47e9dfb => x4574aea041dd835f;

	public double x5842b5fc61b80e47 => (double)xd2f68ee6f47e9dfb / 100.0;

	public double xb6525833a9058091 => x4574ea26106f0edb.x3aa08882c9feaf96(x5842b5fc61b80e47);

	public xa435fbe8ebcefc2c()
	{
	}

	public xa435fbe8ebcefc2c(int value)
	{
		x4574aea041dd835f = value;
	}

	public bool Equals(xa435fbe8ebcefc2c other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		return other.x4574aea041dd835f == x4574aea041dd835f;
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
		if (obj.GetType() != typeof(xa435fbe8ebcefc2c))
		{
			return false;
		}
		return Equals((xa435fbe8ebcefc2c)obj);
	}

	public override int GetHashCode()
	{
		return x4574aea041dd835f;
	}
}
