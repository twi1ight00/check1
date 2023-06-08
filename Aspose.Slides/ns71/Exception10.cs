using System;

namespace ns71;

internal class Exception10 : Exception9
{
	public Exception10()
	{
	}

	public Exception10(string message)
		: base(message)
	{
	}

	public Exception10(string message, Exception exception)
		: base(message, exception)
	{
	}
}
