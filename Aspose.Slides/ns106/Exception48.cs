using System;
using System.Runtime.Serialization;

namespace ns106;

internal class Exception48 : Exception46
{
	public Exception48()
	{
	}

	public Exception48(string message)
		: base(message)
	{
	}

	public Exception48(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public Exception48(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
