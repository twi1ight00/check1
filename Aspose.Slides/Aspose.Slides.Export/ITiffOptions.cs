using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Export;

[ComVisible(true)]
[Guid("3cb136f3-42ad-4fee-8f79-cc22e91fc1b7")]
public interface ITiffOptions : ISaveOptions
{
	Size ImageSize { get; set; }

	uint DpiX { get; set; }

	uint DpiY { get; set; }

	TiffCompressionTypes CompressionType { get; set; }

	ISaveOptions AsISaveOptions { get; }
}
