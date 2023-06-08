using System.IO;
using Aspose.Cells;

namespace ns8;

internal class Class431 : IStreamProvider
{
	public Stream GetStream(ref string origPath, string parsedPath)
	{
		if (File.Exists(parsedPath))
		{
			return File.OpenRead(parsedPath);
		}
		return null;
	}

	public void Close(string origPath, Stream stream)
	{
	}
}
