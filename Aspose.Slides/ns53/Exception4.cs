using System;

namespace ns53;

internal class Exception4 : Exception
{
	public Exception4()
	{
	}

	public Exception4(string message)
		: base(message)
	{
	}

	public Exception4(string message, Exception exception)
		: base(message, exception)
	{
	}
}
