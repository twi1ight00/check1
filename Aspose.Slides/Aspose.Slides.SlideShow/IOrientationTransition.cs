using System.Runtime.InteropServices;

namespace Aspose.Slides.SlideShow;

[ComVisible(true)]
[Guid("3c6577b9-4d4f-4292-ae2d-34e5c46e33e7")]
public interface IOrientationTransition : ITransitionValueBase
{
	Orientation Direction { get; set; }

	ITransitionValueBase AsITransitionValueBase { get; }
}
