using System;
using System.Runtime.Serialization;

namespace ns104;

internal class Exception34 : Exception30
{
	public Exception34()
	{
	}

	public Exception34(string message)
		: base(message)
	{
	}

	public Exception34(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public Exception34(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
