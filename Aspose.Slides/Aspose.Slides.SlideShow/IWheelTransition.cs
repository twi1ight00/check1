using System.Runtime.InteropServices;

namespace Aspose.Slides.SlideShow;

[Guid("0a5993ec-c7d6-42e8-8209-e30c758f1cd5")]
[ComVisible(true)]
public interface IWheelTransition : ITransitionValueBase
{
	uint Spokes { get; set; }

	ITransitionValueBase AsITransitionValueBase { get; }
}
