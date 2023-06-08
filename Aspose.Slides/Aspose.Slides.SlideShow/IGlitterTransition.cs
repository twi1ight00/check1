using System.Runtime.InteropServices;

namespace Aspose.Slides.SlideShow;

[Guid("08747224-B633-4179-8168-566950FF6663")]
[ComVisible(true)]
public interface IGlitterTransition : ITransitionValueBase
{
	TransitionSideDirectionType Direction { get; set; }

	TransitionPattern Pattern { get; set; }

	ITransitionValueBase AsITransitionValueBase { get; }
}
