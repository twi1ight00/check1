using System;
using System.Runtime.Serialization;

namespace Aspose.Words;

[Serializable]
public class UnsupportedFileFormatException : Exception
{
	internal UnsupportedFileFormatException(string message)
		: base(message)
	{
	}

	internal UnsupportedFileFormatException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	[JavaDelete("No exception serialization on Java.")]
	internal UnsupportedFileFormatException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
