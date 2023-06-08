using System;
using System.Runtime.Serialization;

namespace ns104;

internal class Exception33 : Exception30
{
	public Exception33()
	{
	}

	public Exception33(string message)
		: base(message)
	{
	}

	public Exception33(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public Exception33(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
