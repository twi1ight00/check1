using System;

namespace ns71;

internal class Exception9 : Exception
{
	public Exception9()
	{
	}

	public Exception9(string message)
		: base(message)
	{
	}

	public Exception9(string message, Exception exception)
		: base(message, exception)
	{
	}
}
