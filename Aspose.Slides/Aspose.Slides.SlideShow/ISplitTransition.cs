using System.Runtime.InteropServices;

namespace Aspose.Slides.SlideShow;

[ComVisible(true)]
[Guid("8ea9326e-5952-4813-8e87-8e3d26689410")]
public interface ISplitTransition : ITransitionValueBase
{
	TransitionInOutDirectionType Direction { get; set; }

	Orientation Orientation { get; set; }

	ITransitionValueBase AsITransitionValueBase { get; }
}
