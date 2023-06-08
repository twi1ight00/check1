using System.Runtime.InteropServices;

namespace Aspose.Slides.Effects;

[ComVisible(true)]
[Guid("ec3a89f7-32f2-46d9-8709-02ca7584c96a")]
public interface IFillOverlayEffectiveData
{
	FillBlendMode Blend { get; }

	IFillFormatEffectiveData FillFormat { get; }
}
