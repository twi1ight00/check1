using System;
using System.Runtime.Serialization;
using x13f1efc79617a47b;

namespace Aspose.Words;

[Serializable]
public class FileCorruptedException : Exception
{
	internal FileCorruptedException(string message)
		: base(message)
	{
	}

	internal FileCorruptedException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	internal FileCorruptedException(Exception innerException)
		: this(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kffdlgmdfgdenbkeofbfggifhfpfgggglfngafehgflhjfcicajiaeajmehjjeojldfkedmkcedlaeklkoamldimddpmbofnacnnaceoinkoibcpbcjpbcaaobhaoboagbfbhbmbfadcbakckladiphdcapdfpfeokmeoodfjokfdpbgapigoopgapghjjnhineiinliajcjjnjjjnakimhkimokgmflcmmljidm", 55719174)), innerException)
	{
	}

	[JavaDelete("No exception serialization on Java.")]
	internal FileCorruptedException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
