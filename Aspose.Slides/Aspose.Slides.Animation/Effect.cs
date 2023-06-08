using ns27;
using ns4;
using ns57;

namespace Aspose.Slides.Animation;

public class Effect : IEffect
{
	internal Sequence sequence_0;

	private Class363 class363_0 = new Class363();

	internal BehaviorCollection behaviorCollection_0 = new BehaviorCollection();

	internal Timing timing_0 = new Timing();

	private Paragraph paragraph_0;

	private Paragraph paragraph_1;

	public ISequence Sequence => sequence_0;

	public ITextAnimation TextAnimation => PPTXUnsupportedProps.TextAnimation;

	public EffectPresetClassType PresetClassType
	{
		get
		{
			return PPTXUnsupportedProps.EffectClassType;
		}
		set
		{
			PPTXUnsupportedProps.EffectClassType = value;
			Effect effect = sequence_0.AddEffect(PPTXUnsupportedProps.ShapeTarget, PPTXUnsupportedProps.TypeInternal, PPTXUnsupportedProps.SubtypeInternal, PPTXUnsupportedProps.EffectClassType, Timing.TriggerType);
			behaviorCollection_0.Clear();
			behaviorCollection_0 = effect.behaviorCollection_0;
			PPTXUnsupportedProps.IterateTimeValue = effect.PPTXUnsupportedProps.IterateTimeValue;
			PPTXUnsupportedProps.IterateType = effect.PPTXUnsupportedProps.IterateType;
			PPTXUnsupportedProps.IterateBackwards = effect.PPTXUnsupportedProps.IterateBackwards;
			PPTXUnsupportedProps.Fill = effect.PPTXUnsupportedProps.Fill;
			switch (value)
			{
			case EffectPresetClassType.Entrance:
				PPTXUnsupportedProps.TnClassType = Enum296.const_1;
				break;
			case EffectPresetClassType.Exit:
				PPTXUnsupportedProps.TnClassType = Enum296.const_2;
				break;
			case EffectPresetClassType.Emphasis:
				PPTXUnsupportedProps.TnClassType = Enum296.const_3;
				break;
			case EffectPresetClassType.Path:
				PPTXUnsupportedProps.TnClassType = Enum296.const_4;
				break;
			case EffectPresetClassType.MediaCall:
				PPTXUnsupportedProps.TnClassType = Enum296.const_6;
				break;
			}
			sequence_0.Remove(effect);
		}
	}

	public EffectType Type
	{
		get
		{
			return PPTXUnsupportedProps.TypeInternal;
		}
		set
		{
			PPTXUnsupportedProps.TypeInternal = value;
			Effect effect = (Effect)sequence_0.AddEffect(PPTXUnsupportedProps.ShapeTarget, PPTXUnsupportedProps.TypeInternal, EffectSubtype.None, Timing.TriggerType);
			behaviorCollection_0.Clear();
			behaviorCollection_0 = effect.behaviorCollection_0;
			PPTXUnsupportedProps.IterateTimeValue = effect.PPTXUnsupportedProps.IterateTimeValue;
			PPTXUnsupportedProps.IterateType = effect.PPTXUnsupportedProps.IterateType;
			PPTXUnsupportedProps.IterateBackwards = effect.PPTXUnsupportedProps.IterateBackwards;
			PPTXUnsupportedProps.Fill = effect.PPTXUnsupportedProps.Fill;
			PPTXUnsupportedProps.EffectClassType = effect.PPTXUnsupportedProps.EffectClassType;
			PPTXUnsupportedProps.SubtypeInternal = effect.PPTXUnsupportedProps.SubtypeInternal;
			sequence_0.Remove(effect);
			switch (PPTXUnsupportedProps.EffectClassType)
			{
			case EffectPresetClassType.Entrance:
				PPTXUnsupportedProps.TnClassType = Enum296.const_1;
				break;
			case EffectPresetClassType.Exit:
				PPTXUnsupportedProps.TnClassType = Enum296.const_2;
				break;
			case EffectPresetClassType.Emphasis:
				PPTXUnsupportedProps.TnClassType = Enum296.const_3;
				break;
			case EffectPresetClassType.Path:
				PPTXUnsupportedProps.TnClassType = Enum296.const_4;
				break;
			case EffectPresetClassType.MediaCall:
				PPTXUnsupportedProps.TnClassType = Enum296.const_6;
				break;
			}
		}
	}

	public EffectSubtype Subtype
	{
		get
		{
			return PPTXUnsupportedProps.SubtypeInternal;
		}
		set
		{
			PPTXUnsupportedProps.SubtypeInternal = value;
			Effect effect = sequence_0.AddEffect(PPTXUnsupportedProps.ShapeTarget, PPTXUnsupportedProps.TypeInternal, PPTXUnsupportedProps.SubtypeInternal, PPTXUnsupportedProps.EffectClassType, Timing.TriggerType);
			behaviorCollection_0.Clear();
			behaviorCollection_0 = effect.behaviorCollection_0;
			PPTXUnsupportedProps.IterateTimeValue = effect.PPTXUnsupportedProps.IterateTimeValue;
			PPTXUnsupportedProps.IterateType = effect.PPTXUnsupportedProps.IterateType;
			PPTXUnsupportedProps.IterateBackwards = effect.PPTXUnsupportedProps.IterateBackwards;
			PPTXUnsupportedProps.Fill = effect.PPTXUnsupportedProps.Fill;
			sequence_0.Remove(effect);
		}
	}

	public IBehaviorCollection Behaviors
	{
		get
		{
			return behaviorCollection_0;
		}
		set
		{
			behaviorCollection_0 = (BehaviorCollection)value;
		}
	}

	public ITiming Timing
	{
		get
		{
			return timing_0;
		}
		set
		{
			timing_0 = (Timing)value;
		}
	}

	internal Paragraph StartParagraph => paragraph_0;

	internal Paragraph EndParagraph => paragraph_1;

	internal Class363 PPTXUnsupportedProps => class363_0;

	private void method_0(object sender, EventArgs0 e)
	{
		if (object.ReferenceEquals(e.Paragraph, paragraph_0) || object.ReferenceEquals(e.Paragraph, paragraph_1))
		{
			paragraph_0 = null;
			paragraph_1 = null;
			((ParagraphCollection)sender).ParagraphRemoved -= method_0;
		}
	}

	internal Effect()
	{
		PPTXUnsupportedProps.GrId = -1;
		PPTXUnsupportedProps.TextAnimation = new TextAnimation();
		behaviorCollection_0 = new BehaviorCollection();
		timing_0 = new Timing();
		PPTXUnsupportedProps.IterateType = Enum276.const_0;
	}

	internal Effect(Sequence parent)
		: this()
	{
		sequence_0 = parent;
		behaviorCollection_0.effect_0 = this;
	}

	internal void method_1(Paragraph startParagraph, Paragraph endParagraph)
	{
		if (!object.ReferenceEquals(startParagraph.paragraphCollection_0, endParagraph.paragraphCollection_0))
		{
			throw new PptxException("Effect start and end paragraphs must belong to the same paragraph collection.");
		}
		paragraph_0 = startParagraph;
		paragraph_1 = endParagraph;
		ParagraphCollection paragraphCollection_ = startParagraph.paragraphCollection_0;
		if (paragraphCollection_ != null)
		{
			paragraphCollection_.ParagraphRemoved += method_0;
		}
	}
}
