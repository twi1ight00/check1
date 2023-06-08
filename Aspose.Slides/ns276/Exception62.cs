using System;
using System.Runtime.Serialization;

namespace ns276;

internal class Exception62 : Exception61
{
	public Exception62()
	{
	}

	public Exception62(string message)
		: base(message)
	{
	}

	public Exception62(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	protected Exception62(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
