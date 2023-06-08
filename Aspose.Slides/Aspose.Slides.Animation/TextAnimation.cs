using System.Runtime.InteropServices;
using ns27;

namespace Aspose.Slides.Animation;

[Guid("59738259-8eae-43c8-9706-3f497d83c51f")]
[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
public class TextAnimation : ITextAnimation
{
	internal BuildType buildType_0;

	internal int int_0 = -1;

	private Sequence sequence_0;

	private Class365 class365_0 = new Class365();

	internal bool bool_0;

	public BuildType BuildType
	{
		get
		{
			return buildType_0;
		}
		set
		{
			buildType_0 = value;
		}
	}

	public IEffect EffectAnimateBackgroundShape
	{
		get
		{
			return PPTXUnsupportedProps.EffectAnimBg;
		}
		set
		{
			if (PPTXUnsupportedProps.EffectAnimBg != null)
			{
				SeqOwner.PPTXUnsupportedProps.Effects.Remove(PPTXUnsupportedProps.EffectAnimBg);
				PPTXUnsupportedProps.ListEffects.Remove(PPTXUnsupportedProps.EffectAnimBg);
				PPTXUnsupportedProps.EffectAnimBg = null;
			}
			if (value != null)
			{
				PPTXUnsupportedProps.EffectAnimBg = value;
				SeqOwner.PPTXUnsupportedProps.Effects.Insert(0, value);
				PPTXUnsupportedProps.ListEffects.Insert(0, value);
			}
			method_0();
		}
	}

	internal Sequence SeqOwner
	{
		get
		{
			return sequence_0;
		}
		set
		{
			sequence_0 = value;
		}
	}

	internal Class365 PPTXUnsupportedProps => class365_0;

	public IEffect AddEffect(EffectType effectType, EffectSubtype subtype, EffectTriggerType triggerType)
	{
		EffectPresetClassType classType = Class363.smethod_6(effectType, subtype);
		Effect effect = SeqOwner.AddEffect(PPTXUnsupportedProps.ShapeRef, effectType, subtype, classType, triggerType);
		PPTXUnsupportedProps.ListEffects.Add(effect);
		method_0();
		return effect;
	}

	internal void method_0()
	{
		foreach (Effect listEffect in PPTXUnsupportedProps.ListEffects)
		{
			listEffect.PPTXUnsupportedProps.TextAnimation = this;
		}
	}
}
