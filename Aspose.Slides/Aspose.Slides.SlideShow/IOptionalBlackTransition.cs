using System.Runtime.InteropServices;

namespace Aspose.Slides.SlideShow;

[ComVisible(true)]
[Guid("abe804df-5fd5-48d8-b6ff-1012509864a7")]
public interface IOptionalBlackTransition : ITransitionValueBase
{
	bool FromBlack { get; set; }

	ITransitionValueBase AsITransitionValueBase { get; }
}
