using System;
using System.Runtime.Serialization;
using ns103;

namespace ns104;

internal class Exception30 : Exception29
{
	public Exception30()
	{
	}

	public Exception30(string message)
		: base(message)
	{
	}

	public Exception30(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public Exception30(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
