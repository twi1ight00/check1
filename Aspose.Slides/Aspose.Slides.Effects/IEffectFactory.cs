using System.Runtime.InteropServices;

namespace Aspose.Slides.Effects;

[Guid("369E1F6C-8544-482A-9C18-003A8A818966")]
[ComVisible(true)]
public interface IEffectFactory
{
	IImageTransformOperationFactory ImageTransformOperationFactory { get; }

	IGlow CreateGlow();

	IInnerShadow CreateInnerShadow();

	IOuterShadow CreateOuterShadow();

	IPresetShadow CreatePresetShadow();

	IReflection CreateReflection();

	ISoftEdge CreateSoftEdge();
}
