using System;
using System.Runtime.Serialization;

namespace ns276;

internal class Exception61 : Exception
{
	public Exception61()
	{
	}

	public Exception61(string message)
		: base(message)
	{
	}

	public Exception61(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	protected Exception61(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
