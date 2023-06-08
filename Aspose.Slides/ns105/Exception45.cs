using System;
using System.Runtime.Serialization;

namespace ns105;

internal class Exception45 : Exception39
{
	public Exception45()
	{
	}

	public Exception45(string message)
		: base(message)
	{
	}

	public Exception45(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public Exception45(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
