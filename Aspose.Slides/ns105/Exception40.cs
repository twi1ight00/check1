using System;
using System.Runtime.Serialization;

namespace ns105;

internal class Exception40 : Exception39
{
	public Exception40()
	{
	}

	public Exception40(string message)
		: base(message)
	{
	}

	public Exception40(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public Exception40(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
