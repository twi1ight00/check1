using System.Runtime.InteropServices;
using Aspose.Slides.Theme;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("4edce609-ba7d-40ac-8c86-333be2205c3b")]
public interface IFontData
{
	string FontName { get; }

	string GetFontName(IThemeEffectiveData theme);
}
