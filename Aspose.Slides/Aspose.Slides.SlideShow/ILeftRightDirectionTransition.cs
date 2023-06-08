using System.Runtime.InteropServices;

namespace Aspose.Slides.SlideShow;

[ComVisible(true)]
[Guid("A25AD20C-C615-49A3-80FE-3B38C2E38D23")]
public interface ILeftRightDirectionTransition : ITransitionValueBase
{
	TransitionLeftRightDirectionType Direction { get; set; }

	ITransitionValueBase AsITransitionValueBase { get; }
}
