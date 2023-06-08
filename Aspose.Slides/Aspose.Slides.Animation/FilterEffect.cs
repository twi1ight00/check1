using System.Runtime.InteropServices;
using ns27;

namespace Aspose.Slides.Animation;

[ClassInterface(ClassInterfaceType.None)]
[Guid("DD102C99-F6E5-440B-A9E9-978BBAFF6724")]
[ComVisible(true)]
public class FilterEffect : Behavior, IBehavior, IFilterEffect
{
	internal FilterEffectType filterEffectType_0;

	internal FilterEffectSubtype filterEffectSubtype_0;

	internal FilterEffectRevealType filterEffectRevealType_0 = FilterEffectRevealType.NotDefined;

	internal new Class362 PPTXUnsupportedProps => (Class362)base.PPTXUnsupportedProps;

	public FilterEffectRevealType Reveal
	{
		get
		{
			return filterEffectRevealType_0;
		}
		set
		{
			filterEffectRevealType_0 = value;
		}
	}

	public FilterEffectType Type
	{
		get
		{
			return filterEffectType_0;
		}
		set
		{
			filterEffectType_0 = value;
		}
	}

	public FilterEffectSubtype Subtype
	{
		get
		{
			return filterEffectSubtype_0;
		}
		set
		{
			filterEffectSubtype_0 = value;
		}
	}

	IBehavior IFilterEffect.AsIBehavior => this;

	public FilterEffect()
		: base(new Class362())
	{
	}
}
