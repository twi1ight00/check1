using System;

namespace ns88;

internal class Exception11 : Exception
{
	public Exception11(string message)
		: base(message)
	{
	}

	public Exception11(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
