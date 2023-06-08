using System.Runtime.InteropServices;
using Aspose.Slides.Effects;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("228dc587-c5e7-4bd7-bf73-1501a0091b40")]
public interface ISlidesPicture : IPresentationComponent
{
	IPPImage Image { get; set; }

	string LinkPathLong { get; set; }

	IImageTransformOperationCollection ImageTransform { get; }

	IPresentationComponent AsIPresentationComponent { get; }
}
