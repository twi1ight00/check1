using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[Guid("e5974423-3820-4f98-a492-c9dedc2605cf")]
[ComVisible(true)]
public interface IMasterThemeable : IPresentationComponent, ISlideComponent, IThemeable
{
	IMasterThemeManager ThemeManager { get; }

	IThemeable AsIThemeable { get; }
}
