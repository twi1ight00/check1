using System;

namespace ns4;

internal class Exception0 : Exception
{
	public Exception0()
	{
	}

	public Exception0(string message)
		: base(message)
	{
	}

	public Exception0(string message, Exception exception)
		: base(message, exception)
	{
	}
}
