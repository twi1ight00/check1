using System.Runtime.InteropServices;

namespace Aspose.Slides.SlideShow;

[Guid("e78a9629-10f1-4e0e-b189-cffb5e06f689")]
[ComVisible(true)]
public interface ISideDirectionTransition : ITransitionValueBase
{
	TransitionSideDirectionType Direction { get; set; }

	ITransitionValueBase AsITransitionValueBase { get; }
}
