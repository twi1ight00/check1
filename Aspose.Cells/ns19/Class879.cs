namespace ns19;

internal sealed class Class879
{
	internal Enum89 enum89_0;

	internal long long_0;

	internal long long_1;

	internal long long_2;

	internal string string_0;

	internal bool bool_0;

	private static readonly Class877 class877_0 = new Class877(new string[17]
	{
		"*/", "+-", "+/", "?:", "abs", "at2", "cat2", "cos", "max", "min",
		"mod", "pin", "sat2", "sin", "sqrt", "tan", "val"
	});

	private static readonly int[] int_0 = new int[17]
	{
		3, 3, 3, 3, 1, 2, 3, 2, 2, 2,
		3, 3, 3, 2, 1, 2, 1
	};

	internal Class879(string string_1, Enum89 enum89_1, long long_3, long long_4, long long_5)
	{
		string_0 = string_1;
		enum89_0 = enum89_1;
		long_0 = long_3;
		long_1 = long_4;
		long_2 = long_5;
	}

	internal Class879(string string_1, Enum89 enum89_1, long long_3, long long_4, long long_5, bool bool_1)
		: this(string_1, enum89_1, long_3, long_4, long_5)
	{
		bool_0 = bool_1;
	}
}
