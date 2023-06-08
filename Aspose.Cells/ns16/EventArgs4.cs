namespace ns16;

internal class EventArgs4 : EventArgs0
{
	private string string_1;

	internal EventArgs4(string string_2, Enum25 enum25_1)
		: base(string_2, enum25_1)
	{
	}

	internal EventArgs4()
	{
	}

	internal static EventArgs4 smethod_0(string string_2, Class744 class744_1, string string_3)
	{
		EventArgs4 eventArgs = new EventArgs4();
		eventArgs.method_4(string_2);
		eventArgs.method_3(Enum25.const_17);
		eventArgs.method_1(class744_1);
		eventArgs.string_1 = string_3;
		return eventArgs;
	}

	internal static EventArgs4 smethod_1(string string_2, Class744 class744_1, string string_3)
	{
		EventArgs4 eventArgs = new EventArgs4();
		eventArgs.method_4(string_2);
		eventArgs.method_3(Enum25.const_19);
		eventArgs.method_1(class744_1);
		eventArgs.string_1 = string_3;
		return eventArgs;
	}

	internal static EventArgs4 smethod_2(string string_2, Class744 class744_1, string string_3)
	{
		EventArgs4 eventArgs = new EventArgs4();
		eventArgs.method_4(string_2);
		eventArgs.method_3(Enum25.const_18);
		eventArgs.method_1(class744_1);
		eventArgs.string_1 = string_3;
		return eventArgs;
	}

	internal static EventArgs4 smethod_3(string string_2, Class744 class744_1, long long_2, long long_3)
	{
		EventArgs4 eventArgs = new EventArgs4(string_2, Enum25.const_20);
		eventArgs.method_4(string_2);
		eventArgs.method_1(class744_1);
		eventArgs.method_5(long_2);
		eventArgs.method_6(long_3);
		return eventArgs;
	}
}
