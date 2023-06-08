using System.Runtime.InteropServices;

namespace Aspose.Slides.Effects;

[ComVisible(true)]
[Guid("9c7f9b3c-91c6-4174-b095-a9cbb0cc01cc")]
public interface ITint : IImageTransformOperation
{
	IImageTransformOperation AsIImageTransformOperation { get; }
}
