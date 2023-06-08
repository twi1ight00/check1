namespace ns99;

internal class Class4508 : Class4506
{
	public static Class4508 class4508_0 = new Class4508(0);

	private int int_0;

	public int Value
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

	public Class4508(int value)
	{
		int_0 = value;
	}

	public override string ToString()
	{
		return int_0.ToString();
	}

	public override bool Equals(object obj)
	{
		if (obj is Class4508 @class)
		{
			return int_0 == @class.int_0;
		}
		return false;
	}

	public static bool operator ==(Class4508 obj1, object obj2)
	{
		if ((object)obj1 != null)
		{
			return obj1.Equals(obj2);
		}
		if (obj2 == null)
		{
			return true;
		}
		return false;
	}

	public static bool operator !=(Class4508 obj1, object obj2)
	{
		if ((object)obj1 != null)
		{
			return !obj1.Equals(obj2);
		}
		if (obj2 == null)
		{
			return false;
		}
		return true;
	}

	public override int GetHashCode()
	{
		return int_0.GetHashCode();
	}
}
