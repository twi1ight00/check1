using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[ComVisible(true)]
[Guid("89c28913-6dc8-42d6-9ea5-028a04063004")]
public interface IThemeEffectiveData
{
	IFontSchemeEffectiveData FontScheme { get; }

	IFormatSchemeEffectiveData FormatScheme { get; }

	IColorSchemeEffectiveData GetColorScheme(Color styleColor);
}
