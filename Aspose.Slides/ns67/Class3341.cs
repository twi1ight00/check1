using System;

namespace ns67;

internal sealed class Class3341 : ICloneable
{
	private int int_0;

	private int int_1;

	public int DashLength
	{
		get
		{
			return int_0;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			int_0 = value;
		}
	}

	public int SpaceLength
	{
		get
		{
			return int_1;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			int_1 = value;
		}
	}

	public Class3341(int dashLength, int spaceLength)
	{
		DashLength = dashLength;
		SpaceLength = spaceLength;
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3341 method_0()
	{
		return new Class3341(int_0, int_1);
	}
}
