namespace ns16;

internal class EventArgs1 : EventArgs0
{
	internal EventArgs1()
	{
	}

	private EventArgs1(string string_1, Enum25 enum25_1)
		: base(string_1, enum25_1)
	{
	}

	internal static EventArgs1 smethod_0(string string_1, int int_1)
	{
		EventArgs1 eventArgs = new EventArgs1(string_1, Enum25.const_4);
		eventArgs.method_0(int_1);
		return eventArgs;
	}

	internal static EventArgs1 smethod_1(string string_1, Class744 class744_1, int int_1)
	{
		EventArgs1 eventArgs = new EventArgs1(string_1, Enum25.const_5);
		eventArgs.method_0(int_1);
		eventArgs.method_1(class744_1);
		return eventArgs;
	}

	internal static EventArgs1 smethod_2(string string_1)
	{
		return new EventArgs1(string_1, Enum25.const_3);
	}

	internal static EventArgs1 smethod_3(string string_1, Class744 class744_1, long long_2, long long_3)
	{
		EventArgs1 eventArgs = new EventArgs1(string_1, Enum25.const_7);
		eventArgs.method_1(class744_1);
		eventArgs.method_5(long_2);
		eventArgs.method_6(long_3);
		return eventArgs;
	}

	internal static EventArgs1 smethod_4(string string_1)
	{
		return new EventArgs1(string_1, Enum25.const_6);
	}
}
