using System;
using System.Runtime.Serialization;

namespace ns103;

internal class Exception29 : ApplicationException
{
	public Exception29()
	{
	}

	public Exception29(string message)
		: base(message)
	{
	}

	public Exception29(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public Exception29(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
