using System;

namespace ns53;

internal class Exception5 : Exception4
{
	public Exception5()
	{
	}

	public Exception5(string message)
		: base(message)
	{
	}

	public Exception5(string message, Exception exception)
		: base(message, exception)
	{
	}
}
