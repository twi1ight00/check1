using System;
using System.Runtime.Serialization;

namespace ns106;

internal class Exception47 : Exception46
{
	public Exception47()
	{
	}

	public Exception47(string message)
		: base(message)
	{
	}

	public Exception47(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public Exception47(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
