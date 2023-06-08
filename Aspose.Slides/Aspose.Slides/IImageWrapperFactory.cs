using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("F776BB4D-EDDD-4BDC-A5C0-01C6C4C8CAF5")]
public interface IImageWrapperFactory
{
	IImageWrapper CreateImageWrapper(Image image);

	IImageWrapper CreateImageWrapper(Stream stream);

	IImageWrapper CreateImageWrapper(string fileName);
}
