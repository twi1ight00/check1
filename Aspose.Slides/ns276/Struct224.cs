using System;

namespace ns276;

internal struct Struct224
{
	private bool bool_0;

	internal long long_0;

	public bool HasValue => bool_0;

	public long Value
	{
		get
		{
			if (!HasValue)
			{
				throw new InvalidOperationException("NullableInt64 doesn't have a value.");
			}
			return long_0;
		}
	}

	public Struct224(long value)
	{
		long_0 = value;
		bool_0 = true;
	}

	public long method_0()
	{
		return long_0;
	}

	public long method_1(long defaultValue)
	{
		if (!HasValue)
		{
			return defaultValue;
		}
		return long_0;
	}

	public override bool Equals(object other)
	{
		if (!HasValue)
		{
			return other == null;
		}
		if (other == null)
		{
			return false;
		}
		return long_0.Equals(other);
	}

	public override int GetHashCode()
	{
		if (!HasValue)
		{
			return 0;
		}
		return long_0.GetHashCode();
	}

	public override string ToString()
	{
		if (!HasValue)
		{
			return string.Empty;
		}
		return long_0.ToString();
	}
}
