using System.IO;

namespace Aspose.Words;

[JavaDelete("not applicable to java")]
public class ComHelper
{
	public Document Open(string fileName)
	{
		return new Document(fileName);
	}

	public Document Open(Stream stream)
	{
		return new Document(stream);
	}
}
