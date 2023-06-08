using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("0c00fdb2-43a2-4713-83ea-1f4a2d54f8a5")]
public interface IFonts
{
	IFontData LatinFont { get; set; }

	IFontData EastAsianFont { get; set; }

	IFontData ComplexScriptFont { get; set; }
}
