using System.Runtime.InteropServices;

namespace Aspose.Slides.SlideShow;

[Guid("C6CB5D47-70FF-42EE-82DB-20958E6E9F9D")]
[ComVisible(true)]
public interface IFlyThroughTransition : ITransitionValueBase
{
	TransitionInOutDirectionType Direction { get; set; }

	bool HasBounce { get; set; }

	ITransitionValueBase AsITransitionValueBase { get; }
}
