using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("4053a48e-4095-4ef5-a52e-d1411d1a2706")]
[ComVisible(true)]
public interface ISlideSize
{
	SizeF Size { get; set; }

	SlideSizeType Type { get; set; }

	SlideOrienation Orientation { get; set; }
}
