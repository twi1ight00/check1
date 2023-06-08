using System;
using System.Runtime.Serialization;
using ns103;

namespace ns105;

internal class Exception39 : Exception29
{
	public Exception39()
	{
	}

	public Exception39(string message)
		: base(message)
	{
	}

	public Exception39(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public Exception39(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
