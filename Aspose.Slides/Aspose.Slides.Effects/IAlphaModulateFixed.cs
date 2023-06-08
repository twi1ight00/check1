using System.Runtime.InteropServices;

namespace Aspose.Slides.Effects;

[Guid("107b41b0-7080-45fc-9b68-857e9a75a5c4")]
[ComVisible(true)]
public interface IAlphaModulateFixed : IImageTransformOperation
{
	float Amount { get; set; }

	IImageTransformOperation AsIImageTransformOperation { get; }
}
