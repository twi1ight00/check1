using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[ComVisible(true)]
[Guid("A3C08970-949B-41C1-AE5A-97F6189A3E10")]
public interface IFilterEffect : IBehavior
{
	FilterEffectRevealType Reveal { get; set; }

	FilterEffectType Type { get; set; }

	FilterEffectSubtype Subtype { get; set; }

	IBehavior AsIBehavior { get; }
}
