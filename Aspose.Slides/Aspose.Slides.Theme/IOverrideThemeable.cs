using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[Guid("77a9619d-183f-4715-82d4-9dee754aff82")]
[ComVisible(true)]
public interface IOverrideThemeable : IPresentationComponent, ISlideComponent, IThemeable
{
	IOverrideThemeManager ThemeManager { get; }

	IThemeable AsIThemeable { get; }
}
