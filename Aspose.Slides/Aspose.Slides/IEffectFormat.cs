using System.Runtime.InteropServices;
using Aspose.Slides.Effects;

namespace Aspose.Slides;

[Guid("1b7b9dda-82cf-44d4-b422-db2dc70b9b55")]
[ComVisible(true)]
public interface IEffectFormat
{
	bool IsNoEffects { get; }

	IBlur BlurEffect { get; set; }

	IFillOverlay FillOverlayEffect { get; set; }

	IGlow GlowEffect { get; set; }

	IInnerShadow InnerShadowEffect { get; set; }

	IOuterShadow OuterShadowEffect { get; set; }

	IPresetShadow PresetShadowEffect { get; set; }

	IReflection ReflectionEffect { get; set; }

	ISoftEdge SoftEdgeEffect { get; set; }

	void SetBlurEffect(double radius, bool grow);

	void EnableFillOverlayEffect();

	void EnableGlowEffect();

	void EnableInnerShadowEffect();

	void EnableOuterShadowEffect();

	void EnablePresetShadowEffect();

	void EnableReflectionEffect();

	void EnableSoftEdgeEffect();

	void DisableBlurEffect();

	void DisableFillOverlayEffect();

	void DisableGlowEffect();

	void DisableInnerShadowEffect();

	void DisableOuterShadowEffect();

	void DisablePresetShadowEffect();

	void DisableReflectionEffect();

	void DisableSoftEdgeEffect();
}
