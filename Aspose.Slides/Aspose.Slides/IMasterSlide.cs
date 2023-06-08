using System.Runtime.InteropServices;
using Aspose.Slides.Theme;

namespace Aspose.Slides;

[Guid("748835d2-856e-4455-a222-5d32fbcb32c7")]
[ComVisible(true)]
public interface IMasterSlide : IPresentationComponent, ISlideComponent, IThemeable, IMasterThemeable, IBaseSlide
{
	ITextStyle TitleStyle { get; }

	ITextStyle BodyStyle { get; }

	ITextStyle OtherStyle { get; }

	IMasterLayoutSlideCollection LayoutSlides { get; }

	bool Preserve { get; set; }

	bool HasDependingSlides { get; }

	IBaseSlide AsIBaseSlide { get; }

	IMasterThemeable AsIMasterThemeable { get; }

	ISlide[] GetDependingSlides();
}
