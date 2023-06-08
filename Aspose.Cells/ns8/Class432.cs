using System.IO;
using Aspose.Cells;

namespace ns8;

internal class Class432 : IStreamProvider
{
	public Stream GetStream(ref string origPath, string parsedPath)
	{
		Directory.CreateDirectory(Path.GetDirectoryName(parsedPath));
		return File.Create(parsedPath);
	}

	public void Close(string origPath, Stream stream)
	{
		stream.Close();
	}
}
