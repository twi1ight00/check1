using System.Runtime.InteropServices;

namespace Aspose.Slides.SlideShow;

[Guid("0FC1D3E3-3F7A-4223-AE80-AE12959AAFA2")]
[ComVisible(true)]
public interface IRevealTransition : ITransitionValueBase
{
	TransitionLeftRightDirectionType Direction { get; set; }

	bool ThroughBlack { get; set; }

	ITransitionValueBase AsITransitionValueBase { get; }
}
