using System;
using System.Runtime.Serialization;

namespace ns103;

internal class Exception35 : Exception29
{
	public Exception35()
	{
	}

	public Exception35(string message)
		: base(message)
	{
	}

	public Exception35(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public Exception35(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
