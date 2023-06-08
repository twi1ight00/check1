using System.Collections;
using System.Collections.Generic;
using ns16;
using ns18;
using ns27;
using ns56;

namespace Aspose.Slides.Animation;

public sealed class Sequence : IEnumerable, ISequence
{
	private AnimationTimeLine animationTimeLine_0;

	private Class364 class364_0 = new Class364();

	internal long long_0;

	internal Shape shape_0;

	internal Class364 PPTXUnsupportedProps => class364_0;

	public int Count => PPTXUnsupportedProps.Effects.Count;

	public IEffect this[int index] => (Effect)PPTXUnsupportedProps.Effects[index];

	public IShape TriggerShape
	{
		get
		{
			return shape_0;
		}
		set
		{
			shape_0 = (Shape)value;
		}
	}

	IEnumerable ISequence.AsIEnumerable => this;

	internal Sequence(AnimationTimeLine parent)
	{
		animationTimeLine_0 = parent;
	}

	public void Remove(IEffect item)
	{
		if (item != null)
		{
			((TextAnimation)item.TextAnimation).PPTXUnsupportedProps.ListEffects.Remove(item);
		}
		PPTXUnsupportedProps.Effects.Remove(item);
	}

	public void RemoveAt(int index)
	{
		if (PPTXUnsupportedProps.Effects[index] != null)
		{
			((TextAnimation)((Effect)PPTXUnsupportedProps.Effects[index]).TextAnimation).PPTXUnsupportedProps.ListEffects.Remove(PPTXUnsupportedProps.Effects[index]);
		}
		PPTXUnsupportedProps.Effects.RemoveAt(index);
	}

	public void Clear()
	{
		List<TextAnimation> list = new List<TextAnimation>();
		foreach (TextAnimation item in animationTimeLine_0.textAnimationCollection_0)
		{
			if (item.SeqOwner == this)
			{
				list.Add(item);
			}
		}
		foreach (TextAnimation item2 in list)
		{
			animationTimeLine_0.textAnimationCollection_0.Animations.Remove(item2);
		}
		PPTXUnsupportedProps.Effects.Clear();
	}

	public IEnumerator GetEnumerator()
	{
		return PPTXUnsupportedProps.Effects.GetEnumerator();
	}

	public void RemoveByShape(IShape shape)
	{
		List<Effect> list = new List<Effect>();
		foreach (Effect effect in PPTXUnsupportedProps.Effects)
		{
			if (effect.PPTXUnsupportedProps.ShapeTarget == shape)
			{
				list.Add(effect);
			}
		}
		foreach (Effect item in list)
		{
			Remove(item);
		}
	}

	public IEffect[] GetEffectsByShape(IShape shape)
	{
		List<IEffect> list = new List<IEffect>();
		foreach (Effect effect in PPTXUnsupportedProps.Effects)
		{
			if (effect.PPTXUnsupportedProps.ShapeTarget == shape)
			{
				list.Add(effect);
			}
		}
		IEffect[] array = new IEffect[list.Count];
		list.CopyTo(array);
		return array;
	}

	internal Effect[] method_0(uint shapeId)
	{
		List<Effect> list = new List<Effect>();
		foreach (Effect effect in PPTXUnsupportedProps.Effects)
		{
			if (((Shape)effect.PPTXUnsupportedProps.ShapeTarget).ShapeId == shapeId)
			{
				list.Add(effect);
			}
		}
		Effect[] array = new Effect[list.Count];
		list.CopyTo(array);
		return array;
	}

	public int GetCount(IShape shape)
	{
		int num = 0;
		foreach (Effect effect in PPTXUnsupportedProps.Effects)
		{
			if (effect.PPTXUnsupportedProps.ShapeTarget == shape)
			{
				num++;
			}
		}
		return num;
	}

	internal Effect AddEffect(IShape shape, EffectType effectType, EffectSubtype subtype, EffectPresetClassType classType, EffectTriggerType triggerType)
	{
		PPTXUnsupportedProps.ShapeRef = shape;
		PPTXUnsupportedProps.TriggerNew = triggerType;
		string format = Class363.smethod_7(effectType, subtype, classType, (Shape)shape);
		string innerXml = string.Format(format, "p", "a");
		Class2304 timeNodeParallelElementData = Class1034.smethod_0(innerXml);
		SortedList<string, ISlideComponent> sortedList = new SortedList<string, ISlideComponent>();
		if (shape is Shape shape2)
		{
			sortedList[shape2.ShapeId.ToString()] = shape;
		}
		Class233 timelineDeserializationContext = new Class233(sortedList);
		Class1019.smethod_2(this, null, timeNodeParallelElementData, timelineDeserializationContext);
		PPTXUnsupportedProps.ShapeRef = null;
		Effect effect = (Effect)PPTXUnsupportedProps.Effects[PPTXUnsupportedProps.Effects.Count - 1];
		effect.Timing.TriggerType = triggerType;
		return effect;
	}

	public IEffect AddEffect(IShape shape, EffectType effectType, EffectSubtype subtype, EffectTriggerType triggerType)
	{
		EffectPresetClassType classType = Class363.smethod_6(effectType, subtype);
		Effect effect = AddEffect(shape, effectType, subtype, classType, triggerType);
		TextAnimation textAnimation = new TextAnimation();
		textAnimation.SeqOwner = this;
		animationTimeLine_0.textAnimationCollection_0.Add(textAnimation);
		textAnimation.PPTXUnsupportedProps.EffectAnimBg = effect;
		textAnimation.PPTXUnsupportedProps.ShapeRef = shape;
		textAnimation.buildType_0 = BuildType.AsOneObject;
		textAnimation.PPTXUnsupportedProps.ListEffects.Add(effect);
		effect.PPTXUnsupportedProps.TextAnimation = textAnimation;
		return effect;
	}

	internal Shape method_1(int shapeIndex)
	{
		foreach (Shape item in animationTimeLine_0.Slide.method_3())
		{
			if (item.ShapeId == shapeIndex)
			{
				return item;
			}
		}
		throw new PptxException("Shape not found!");
	}
}
