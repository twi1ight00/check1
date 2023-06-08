using System;

namespace ns53;

internal class Exception6 : Exception5
{
	public Exception6()
	{
	}

	public Exception6(string message)
		: base(message)
	{
	}

	public Exception6(string message, Exception exception)
		: base(message, exception)
	{
	}
}
