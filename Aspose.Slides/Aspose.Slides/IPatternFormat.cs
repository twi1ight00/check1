using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("d18e0abf-4ad5-46fa-8bff-bbf1e3d16e6d")]
public interface IPatternFormat
{
	PatternStyle PatternStyle { get; set; }

	IColorFormat ForeColor { get; }

	IColorFormat BackColor { get; }

	Bitmap GetTileImage(Color background, Color foreground);

	Bitmap GetTileImage(Color styleColor);
}
