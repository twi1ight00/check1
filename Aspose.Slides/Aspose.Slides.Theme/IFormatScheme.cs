using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[Guid("e5fa4582-ac6d-4053-bb0f-8816f0d11493")]
[ComVisible(true)]
public interface IFormatScheme : IPresentationComponent, ISlideComponent
{
	IFillFormatCollection FillStyles { get; }

	ILineFormatCollection LineStyles { get; }

	IEffectStyleCollection EffectStyles { get; }

	IFillFormatCollection BackgroundFillStyles { get; }

	ISlideComponent AsISlideComponent { get; }
}
