using System;

namespace ns16;

internal class EventArgs5 : EventArgs0
{
	private Exception exception_0;

	private EventArgs5()
	{
	}

	internal static EventArgs5 smethod_0(string string_1, Class744 class744_1, Exception exception_1)
	{
		EventArgs5 eventArgs = new EventArgs5();
		eventArgs.method_3(Enum25.const_23);
		eventArgs.method_4(string_1);
		eventArgs.method_1(class744_1);
		eventArgs.exception_0 = exception_1;
		return eventArgs;
	}
}
