using System;
using System.Runtime.Serialization;

namespace ns104;

internal class Exception32 : Exception31
{
	public Exception32()
	{
	}

	public Exception32(string message)
		: base(message)
	{
	}

	public Exception32(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public Exception32(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
