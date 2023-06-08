using System;
using System.Runtime.Serialization;

namespace ns103;

internal class Exception38 : Exception29
{
	public Exception38()
	{
	}

	public Exception38(string message)
		: base(message)
	{
	}

	public Exception38(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public Exception38(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
