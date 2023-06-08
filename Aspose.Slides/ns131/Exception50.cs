using System;
using System.Runtime.Serialization;

namespace ns131;

internal class Exception50 : Exception49
{
	public Exception50()
	{
	}

	public Exception50(string message)
		: base(message)
	{
	}

	public Exception50(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public Exception50(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
