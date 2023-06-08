using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[ComVisible(true)]
[Guid("34998711-9fe7-496c-85e8-8b0f1cb64993")]
public interface ITextAnimation
{
	BuildType BuildType { get; set; }

	IEffect EffectAnimateBackgroundShape { get; set; }

	IEffect AddEffect(EffectType effectType, EffectSubtype subtype, EffectTriggerType triggerType);
}
