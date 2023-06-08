using System;
using x6c95d9cf46ff5f25;

namespace x6b8130194ad714f7;

internal class xd4583a58cd9d2194
{
	private double x4574aea041dd835f;

	public double xd2f68ee6f47e9dfb => x4574aea041dd835f;

	public double xb99590eecb6a46e1 => x4574ea26106f0edb.xabc7127d76567c74(xd2f68ee6f47e9dfb);

	public double x95bb1b6b5e161bbe => x4574ea26106f0edb.xb7a17dcef81f1c64(xd2f68ee6f47e9dfb);

	public xd4583a58cd9d2194()
	{
		x4574aea041dd835f = 0.0;
	}

	public xd4583a58cd9d2194(double value)
	{
		x4574aea041dd835f = value;
	}

	public static xd4583a58cd9d2194 x2f498af763c53ba4(double xbcea506a33cf9111)
	{
		xd4583a58cd9d2194 xd4583a58cd9d2195 = new xd4583a58cd9d2194(xbcea506a33cf9111);
		xd4583a58cd9d2195.x37bba7c72ab9ad63();
		return xd4583a58cd9d2195;
	}

	public static xd4583a58cd9d2194 xbc04d857cda98514(double x08d0a6023d4ad136)
	{
		return new xd4583a58cd9d2194(x4574ea26106f0edb.x61473648fd740ec5(x08d0a6023d4ad136));
	}

	public bool Equals(xd4583a58cd9d2194 other)
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
		if (obj.GetType() != typeof(xd4583a58cd9d2194))
		{
			return false;
		}
		return Equals((xd4583a58cd9d2194)obj);
	}

	public override int GetHashCode()
	{
		return x4574aea041dd835f.GetHashCode();
	}

	private void x37bba7c72ab9ad63()
	{
		double num = x4574ea26106f0edb.x61473648fd740ec5(360.0);
		if (Math.Abs(x4574aea041dd835f) > num)
		{
			x4574aea041dd835f %= num;
		}
		while (x4574aea041dd835f < 0.0)
		{
			x4574aea041dd835f += num;
		}
	}
}
