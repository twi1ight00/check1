using System;
using System.Runtime.Serialization;

namespace ns103;

internal class Exception37 : Exception29
{
	public Exception37()
	{
	}

	public Exception37(string message)
		: base(message)
	{
	}

	public Exception37(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public Exception37(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
