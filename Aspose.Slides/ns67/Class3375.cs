using System;

namespace ns67;

internal class Class3375
{
	private int int_0;

	public int Value
	{
		get
		{
			return int_0;
		}
		private set
		{
			if (value < 1 || value > 32767)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			int_0 = value;
		}
	}

	public Class3375()
	{
		Value = 1;
	}

	public Class3375(int value)
	{
		Value = value;
	}
}
