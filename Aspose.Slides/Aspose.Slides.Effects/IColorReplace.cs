using System.Runtime.InteropServices;

namespace Aspose.Slides.Effects;

[ComVisible(true)]
[Guid("774a5364-3ded-489a-90d2-7ad01222a6bf")]
public interface IColorReplace : IImageTransformOperation
{
	IColorFormat Color { get; }

	IImageTransformOperation AsIImageTransformOperation { get; }
}
