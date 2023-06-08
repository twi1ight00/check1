using System;
using System.Runtime.Serialization;

namespace ns105;

internal class Exception43 : Exception42
{
	public Exception43()
	{
	}

	public Exception43(string message)
		: base(message)
	{
	}

	public Exception43(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public Exception43(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
