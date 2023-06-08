using System.Runtime.InteropServices;
using Aspose.Slides.Effects;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("62030cd4-c192-492a-8500-2053c3e34b9b")]
public interface IEffectFormatEffectiveData
{
	bool IsNoEffects { get; }

	IBlurEffectiveData BlurEffect { get; }

	IFillOverlayEffectiveData FillOverlayEffect { get; }

	IGlowEffectiveData GlowEffect { get; }

	IInnerShadowEffectiveData InnerShadowEffect { get; }

	IOuterShadowEffectiveData OuterShadowEffect { get; }

	IPresetShadowEffectiveData PresetShadowEffect { get; }

	IReflectionEffectiveData ReflectionEffect { get; }

	ISoftEdgeEffectiveData SoftEdgeEffect { get; }
}
