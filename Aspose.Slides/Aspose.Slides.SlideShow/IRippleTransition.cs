using System.Runtime.InteropServices;

namespace Aspose.Slides.SlideShow;

[ComVisible(true)]
[Guid("C6A7102E-074E-4197-9678-007669F363D4")]
public interface IRippleTransition : ITransitionValueBase
{
	TransitionCornerAndCenterDirectionType Direction { get; set; }

	ITransitionValueBase AsITransitionValueBase { get; }
}
