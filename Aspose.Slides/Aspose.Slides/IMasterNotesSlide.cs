using System.Runtime.InteropServices;
using Aspose.Slides.Theme;

namespace Aspose.Slides;

[Guid("c30ce610-66b0-490a-afbd-c96497ae7c57")]
[ComVisible(true)]
public interface IMasterNotesSlide : IPresentationComponent, ISlideComponent, IThemeable, IMasterThemeable, IBaseSlide
{
	IBaseSlide AsIBaseSlide { get; }

	IMasterThemeable AsIMasterThemeable { get; }
}
