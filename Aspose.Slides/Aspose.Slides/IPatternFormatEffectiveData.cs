using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("6e45e978-c1ee-467f-a595-62ab4147c2dd")]
[ComVisible(true)]
public interface IPatternFormatEffectiveData
{
	PatternStyle PatternStyle { get; }

	Color ForeColor { get; }

	Color BackColor { get; }

	Bitmap GetTileImage(Color background, Color foreground);
}
