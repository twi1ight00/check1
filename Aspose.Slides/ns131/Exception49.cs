using System;
using System.Runtime.Serialization;

namespace ns131;

internal class Exception49 : ApplicationException
{
	public Exception49()
	{
	}

	public Exception49(string message)
		: base(message)
	{
	}

	public Exception49(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public Exception49(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
