using System;
using System.Runtime.Serialization;

namespace Aspose.Words;

[Serializable]
public class IncorrectPasswordException : Exception
{
	internal IncorrectPasswordException(string message)
		: base(message)
	{
	}

	[JavaDelete("No exception serialization on Java.")]
	internal IncorrectPasswordException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
