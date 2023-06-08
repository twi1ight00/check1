using System;
using System.Runtime.Serialization;

namespace ns105;

internal class Exception42 : Exception39
{
	public Exception42()
	{
	}

	public Exception42(string message)
		: base(message)
	{
	}

	public Exception42(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public Exception42(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
