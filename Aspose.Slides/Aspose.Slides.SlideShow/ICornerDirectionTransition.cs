using System.Runtime.InteropServices;

namespace Aspose.Slides.SlideShow;

[Guid("ad1e0310-66fe-41ec-b49b-3849fa89efdc")]
[ComVisible(true)]
public interface ICornerDirectionTransition : ITransitionValueBase
{
	TransitionCornerDirectionType Direction { get; set; }

	ITransitionValueBase AsITransitionValueBase { get; }
}
