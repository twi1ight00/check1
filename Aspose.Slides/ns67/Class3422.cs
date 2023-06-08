using System;

namespace ns67;

internal class Class3422 : ICloneable
{
	private readonly int int_0;

	public int Value => int_0;

	public Class3422(int value)
	{
		if (0 > value || 8 < value)
		{
			throw new ArgumentOutOfRangeException("value", "Value should be between 0 and 8.");
		}
		int_0 = value;
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3422 method_0()
	{
		return new Class3422(int_0);
	}
}
