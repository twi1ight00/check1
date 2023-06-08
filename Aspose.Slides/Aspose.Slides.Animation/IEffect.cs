using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[ComVisible(true)]
[Guid("26a4550e-edf0-413c-9770-2dd7cf36222a")]
public interface IEffect
{
	ISequence Sequence { get; }

	ITextAnimation TextAnimation { get; }

	EffectPresetClassType PresetClassType { get; set; }

	EffectType Type { get; set; }

	EffectSubtype Subtype { get; set; }

	IBehaviorCollection Behaviors { get; set; }

	ITiming Timing { get; set; }
}
