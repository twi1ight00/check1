using System;
using System.Runtime.Serialization;

namespace ns276;

internal class Exception63 : Exception61
{
	public Exception63()
	{
	}

	public Exception63(string message)
		: base(message)
	{
	}

	public Exception63(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	protected Exception63(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
