using System.Runtime.InteropServices;

namespace Aspose.Slides.Effects;

[ComVisible(true)]
[Guid("7dad542f-3669-4292-8365-091a3b2976f2")]
public interface IDuotone : IImageTransformOperation
{
	IColorFormat Color1 { get; }

	IColorFormat Color2 { get; }

	IImageTransformOperation AsIImageTransformOperation { get; }
}
