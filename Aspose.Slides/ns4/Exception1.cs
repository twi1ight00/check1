using System;

namespace ns4;

internal class Exception1 : Exception0
{
	public Exception1()
	{
	}

	public Exception1(string message)
		: base(message)
	{
	}

	public Exception1(string message, Exception exception)
		: base(message, exception)
	{
	}
}
