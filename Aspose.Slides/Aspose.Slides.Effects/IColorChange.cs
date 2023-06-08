using System.Runtime.InteropServices;

namespace Aspose.Slides.Effects;

[Guid("2aa4e726-a9c6-4a56-8626-e9bc26c182d3")]
[ComVisible(true)]
public interface IColorChange : IImageTransformOperation
{
	IColorFormat FromColor { get; }

	IColorFormat ToColor { get; }

	IImageTransformOperation AsIImageTransformOperation { get; }
}
