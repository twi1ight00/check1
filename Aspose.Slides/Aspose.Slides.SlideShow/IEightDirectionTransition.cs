using System.Runtime.InteropServices;

namespace Aspose.Slides.SlideShow;

[ComVisible(true)]
[Guid("db442ede-5cf4-4b94-bb3c-ca34c3a08e3d")]
public interface IEightDirectionTransition : ITransitionValueBase
{
	TransitionEightDirectionType Direction { get; set; }

	ITransitionValueBase AsITransitionValueBase { get; }
}
