using System;

namespace ns170;

internal class Class4862 : IComparable
{
	private float float_0;

	private float float_1;

	public static readonly Class4862 class4862_0 = new Class4862(0f, 0f);

	public float Left
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	public float Right
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	public Class4862(float left, float right)
	{
		float_0 = left;
		float_1 = right;
	}

	public bool Equals(Class4862 other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		return other.float_0.Equals(float_0);
	}

	public override string ToString()
	{
		return $"start: {float_0}; end: {float_1}";
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (obj.GetType() != typeof(Class4862))
		{
			return false;
		}
		return Equals((Class4862)obj);
	}

	public override int GetHashCode()
	{
		return float_0.GetHashCode();
	}

	public int CompareTo(object obj)
	{
		return float_0.CompareTo(((Class4862)obj).float_0);
	}

	public bool method_0()
	{
		return float_1 <= float_0;
	}
}
