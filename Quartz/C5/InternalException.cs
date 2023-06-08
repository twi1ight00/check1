using System;

namespace C5;

internal class InternalException : Exception
{
	internal InternalException(string message)
		: base(message)
	{
	}
}
