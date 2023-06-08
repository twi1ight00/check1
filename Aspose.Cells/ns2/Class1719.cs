using System.Runtime.CompilerServices;

namespace ns2;

internal class Class1719
{
	internal string string_0;

	internal int int_0;

	internal int int_1;

	internal Class1719()
	{
	}

	internal Class1719(string string_1, int int_2)
	{
		string_0 = string_1;
		int_0 = int_2;
	}

	[SpecialName]
	internal bool method_0()
	{
		return !(this is Class1720);
	}

	[SpecialName]
	internal bool method_1()
	{
		return this is Class1720;
	}
}
