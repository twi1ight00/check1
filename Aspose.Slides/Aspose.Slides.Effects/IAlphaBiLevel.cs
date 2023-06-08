using System.Runtime.InteropServices;

namespace Aspose.Slides.Effects;

[ComVisible(true)]
[Guid("e49cc5e8-f8a9-4521-83fc-3d33d36b1c80")]
public interface IAlphaBiLevel : IImageTransformOperation
{
	float Threshold { get; set; }

	IImageTransformOperation AsIImageTransformOperation { get; }
}
