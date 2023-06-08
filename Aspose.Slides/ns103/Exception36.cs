using System;
using System.Runtime.Serialization;

namespace ns103;

internal class Exception36 : Exception29
{
	public Exception36()
	{
	}

	public Exception36(string message)
		: base(message)
	{
	}

	public Exception36(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public Exception36(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
