namespace ns16;

internal class EventArgs2 : EventArgs0
{
	internal EventArgs2()
	{
	}

	private EventArgs2(string string_1, Enum25 enum25_1)
		: base(string_1, enum25_1)
	{
	}

	internal static EventArgs2 smethod_0(string string_1, Class744 class744_1, int int_1)
	{
		EventArgs2 eventArgs = new EventArgs2(string_1, Enum25.const_1);
		eventArgs.method_0(int_1);
		eventArgs.method_1(class744_1);
		return eventArgs;
	}
}
