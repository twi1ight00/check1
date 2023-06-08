using System.Runtime.InteropServices;

namespace Aspose.Slides.Effects;

[ComVisible(true)]
[Guid("9ba05e52-fe0e-4145-8cf4-1b77b1c115a9")]
public interface IFillOverlay : IImageTransformOperation
{
	FillBlendMode Blend { get; set; }

	IFillFormat FillFormat { get; }

	IImageTransformOperation AsIImageTransformOperation { get; }
}
