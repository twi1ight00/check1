using System.Runtime.InteropServices;
using Aspose.Slides.Theme;

namespace Aspose.Slides;

[Guid("bce36002-0567-4584-8dea-79afc25ebaf5")]
[ComVisible(true)]
public interface IMasterHandoutSlide : IPresentationComponent, ISlideComponent, IThemeable, IMasterThemeable, IBaseSlide
{
	IBaseSlide AsIBaseSlide { get; }

	IMasterThemeable AsIMasterThemeable { get; }
}
