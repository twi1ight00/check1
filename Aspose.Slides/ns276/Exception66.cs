using System;
using System.Runtime.Serialization;

namespace ns276;

internal class Exception66 : Exception61
{
	public Exception66()
	{
	}

	public Exception66(string message)
		: base(message)
	{
	}

	public Exception66(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	protected Exception66(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
