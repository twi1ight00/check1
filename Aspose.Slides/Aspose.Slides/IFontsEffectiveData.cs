using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("52117670-cbde-4d8b-8d2b-1b4a8a046b06")]
[ComVisible(true)]
public interface IFontsEffectiveData
{
	IFontData LatinFont { get; }

	IFontData EastAsianFont { get; }

	IFontData ComplexScriptFont { get; }
}
