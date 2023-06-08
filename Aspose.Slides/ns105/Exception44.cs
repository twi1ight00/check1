using System;
using System.Runtime.Serialization;

namespace ns105;

internal class Exception44 : Exception39
{
	public Exception44()
	{
	}

	public Exception44(string message)
		: base(message)
	{
	}

	public Exception44(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public Exception44(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
