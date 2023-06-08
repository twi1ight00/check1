using System.Runtime.InteropServices;
using Aspose.Slides.Theme;

namespace Aspose.Slides;

[Guid("498904f5-979c-4c10-917f-bbfa81db0294")]
[ComVisible(true)]
public interface IBaseSlide : IPresentationComponent, ISlideComponent, IThemeable
{
	IShapeCollection Shapes { get; }

	IControlCollection Controls { get; }

	string Name { get; set; }

	uint SlideId { get; }

	ICustomData CustomData { get; }

	IAnimationTimeLine Timeline { get; }

	ISlideShowTransition SlideShowTransition { get; }

	IBackground Background { get; }

	IHyperlinkQueries HyperlinkQueries { get; }

	IThemeable AsIThemeable { get; }

	IShape FindShapeByAltText(string altText);

	void JoinPortionsWithSameFormatting();
}
