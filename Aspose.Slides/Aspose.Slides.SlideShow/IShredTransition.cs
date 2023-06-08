using System.Runtime.InteropServices;

namespace Aspose.Slides.SlideShow;

[Guid("BB61FF5D-F3A1-4D5E-9BA7-A252610F0EE3")]
[ComVisible(true)]
public interface IShredTransition : ITransitionValueBase
{
	TransitionInOutDirectionType Direction { get; set; }

	TransitionShredPattern Pattern { get; set; }

	ITransitionValueBase AsITransitionValueBase { get; }
}
