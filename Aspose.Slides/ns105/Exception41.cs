using System;
using System.Runtime.Serialization;

namespace ns105;

internal class Exception41 : Exception39
{
	public Exception41()
	{
	}

	public Exception41(string message)
		: base(message)
	{
	}

	public Exception41(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public Exception41(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
