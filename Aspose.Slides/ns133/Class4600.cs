namespace ns133;

internal class Class4600
{
	private double double_0;

	private double double_1;

	public static Class4600 class4600_0 = new Class4600(double.MinValue, double.MinValue);

	public double X
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public double Y
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public Class4600(double x, double y)
	{
		X = x;
		Y = y;
	}

	public override bool Equals(object obj)
	{
		if (obj is Class4600 @class)
		{
			if (@class.X == X)
			{
				return @class.Y == Y;
			}
			return false;
		}
		return base.Equals(obj);
	}

	public override int GetHashCode()
	{
		return $"{X}_{Y}".GetHashCode();
	}
}
