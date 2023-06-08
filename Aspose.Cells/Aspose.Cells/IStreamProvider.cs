using System.IO;
using ns22;

namespace Aspose.Cells;

public interface IStreamProvider
{
	[Attribute0(true)]
	Stream GetStream(ref string origPath, string parsedPath);

	[Attribute0(true)]
	void Close(string origPath, Stream stream);
}
