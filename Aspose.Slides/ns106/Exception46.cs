using System;
using System.Runtime.Serialization;
using ns103;

namespace ns106;

internal class Exception46 : Exception29
{
	public Exception46()
	{
	}

	public Exception46(string message)
		: base(message)
	{
	}

	public Exception46(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public Exception46(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
