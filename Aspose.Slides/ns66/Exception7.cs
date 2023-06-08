using System;
using System.Runtime.Serialization;

namespace ns66;

internal class Exception7 : Exception
{
	public Exception7()
	{
	}

	public Exception7(string message)
		: base(message)
	{
	}

	public Exception7(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public Exception7(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
