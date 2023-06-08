using System;
using System.Runtime.Serialization;

namespace DrawingMLRenderer;

[Serializable]
internal class Exception : System.Exception
{
	public Exception()
	{
	}

	public Exception(string what)
		: base(what)
	{
	}

	public Exception(string what, System.Exception inner)
		: base(what, inner)
	{
	}

	protected Exception(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
