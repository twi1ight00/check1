namespace ns16;

internal class EventArgs3 : EventArgs0
{
	private int int_1;

	internal EventArgs3(string string_1, bool bool_1, int int_2, int int_3, Class744 class744_1)
		: base(string_1, bool_1 ? Enum25.const_9 : Enum25.const_10)
	{
		method_0(int_2);
		method_1(class744_1);
		int_1 = int_3;
	}

	internal EventArgs3()
	{
	}

	internal EventArgs3(string string_1, Enum25 enum25_1)
		: base(string_1, enum25_1)
	{
	}

	internal static EventArgs3 smethod_0(string string_1, Class744 class744_1, long long_2, long long_3)
	{
		EventArgs3 eventArgs = new EventArgs3(string_1, Enum25.const_16);
		eventArgs.method_4(string_1);
		eventArgs.method_1(class744_1);
		eventArgs.method_5(long_2);
		eventArgs.method_6(long_3);
		return eventArgs;
	}

	internal static EventArgs3 smethod_1(string string_1)
	{
		return new EventArgs3(string_1, Enum25.const_8);
	}

	internal static EventArgs3 smethod_2(string string_1)
	{
		return new EventArgs3(string_1, Enum25.const_11);
	}
}
