using System.Runtime.CompilerServices;

namespace ns5;

internal class Class882
{
	private int int_0;

	private int int_1;

	internal int Value
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

	[SpecialName]
	internal int method_0()
	{
		return int_1;
	}

	[SpecialName]
	internal void method_1(int int_2)
	{
		int_1 = int_2;
	}
}
