using System;
using System.Runtime.Serialization;

namespace ns104;

internal class Exception31 : Exception30
{
	public Exception31()
	{
	}

	public Exception31(string message)
		: base(message)
	{
	}

	public Exception31(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public Exception31(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
