using System;

namespace ns97;

internal class Exception28 : ApplicationException
{
	public Exception28(string message)
		: base(message)
	{
	}

	public Exception28(string message, Exception inner)
		: base(message, inner)
	{
	}
}
