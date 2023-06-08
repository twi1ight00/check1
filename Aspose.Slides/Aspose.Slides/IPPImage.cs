using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("b1608de5-d5b6-49be-9fec-3fd45952bbab")]
[ComVisible(true)]
public interface IPPImage
{
	byte[] BinaryData { get; }

	Image SystemImage { get; }

	string ContentType { get; }

	int Width { get; }

	int Height { get; }

	int X { get; }

	int Y { get; }

	void ReplaceImage(byte[] newImageData);

	void ReplaceImage(Image newImage);

	void ReplaceImage(IPPImage newImage);
}
