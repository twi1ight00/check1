using System.Runtime.CompilerServices;

namespace ns19;

internal class Class875
{
	internal string string_0;

	private long long_0;

	internal bool bool_0;

	[SpecialName]
	public long method_0()
	{
		return long_0;
	}

	internal Class875(string string_1, long long_1)
	{
		string_0 = string_1;
		long_0 = long_1;
	}

	internal Class875(Class875 class875_0)
	{
		string_0 = class875_0.string_0;
		long_0 = class875_0.long_0;
		bool_0 = true;
	}
}
