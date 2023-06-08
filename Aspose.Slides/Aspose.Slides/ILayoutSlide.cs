using System.Runtime.InteropServices;
using Aspose.Slides.Theme;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("26eff09d-21a8-446c-9c55-729c3792f5ec")]
public interface ILayoutSlide : IPresentationComponent, ISlideComponent, IThemeable, IOverrideThemeable, IBaseSlide
{
	IMasterSlide MasterSlide { get; set; }

	SlideLayoutType LayoutType { get; }

	bool HasDependingSlides { get; }

	IBaseSlide AsIBaseSlide { get; }

	IOverrideThemeable AsIOverrideThemeable { get; }

	ISlide[] GetDependingSlides();

	void Remove();
}
