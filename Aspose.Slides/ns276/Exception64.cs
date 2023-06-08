using System.Runtime.Serialization;

namespace ns276;

internal class Exception64 : Exception61
{
	public Exception64()
	{
	}

	public Exception64(string message)
		: base(message)
	{
	}

	protected Exception64(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
