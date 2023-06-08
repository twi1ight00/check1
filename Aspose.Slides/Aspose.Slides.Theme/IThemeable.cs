using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[ComVisible(true)]
[Guid("071d61e7-9aa5-482d-a82f-3b4ac288751a")]
public interface IThemeable : IPresentationComponent, ISlideComponent
{
	ISlideComponent AsISlideComponent { get; }

	IThemeEffectiveData CreateThemeEffective();
}
