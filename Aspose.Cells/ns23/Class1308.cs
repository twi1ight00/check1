using System;

namespace ns23;

internal class Class1308 : IComparable
{
	public float float_0;

	public float float_1;

	public Class1308()
	{
		float_0 = 0f;
		float_1 = 0f;
	}

	public int CompareTo(object obj)
	{
		Class1308 @class = obj as Class1308;
		int result = 0;
		if (float_1 > @class.float_1)
		{
			result = 1;
		}
		if (float_1 == @class.float_1)
		{
			result = 0;
		}
		if (float_1 < @class.float_1)
		{
			result = -1;
		}
		return result;
	}
}
