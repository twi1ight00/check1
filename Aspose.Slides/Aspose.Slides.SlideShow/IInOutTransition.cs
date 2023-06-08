using System.Runtime.InteropServices;

namespace Aspose.Slides.SlideShow;

[ComVisible(true)]
[Guid("3917eac4-b3f8-4a85-9d7d-f99356555946")]
public interface IInOutTransition : ITransitionValueBase
{
	TransitionInOutDirectionType Direction { get; set; }

	ITransitionValueBase AsITransitionValueBase { get; }
}
