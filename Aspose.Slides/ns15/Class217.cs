using System;
using Aspose.Slides.Warnings;
using ns16;
using ns56;
using ns57;
using ns63;

namespace ns15;

internal class Class217
{
	public static void smethod_0(Class2267 timeNodeAnimateEffectBehavior, Class2650 timeNodeContainer, Class854 deserializationContext)
	{
		if (timeNodeContainer == null || timeNodeContainer.TimeEffectBehavior == null)
		{
			throw new InvalidOperationException();
		}
		Class222.smethod_1(timeNodeAnimateEffectBehavior.CBhvr, timeNodeContainer, timeNodeContainer.TimeEffectBehavior.Behavior, deserializationContext);
		timeNodeAnimateEffectBehavior.Transition = smethod_1(timeNodeContainer.TimeEffectBehavior);
		timeNodeAnimateEffectBehavior.Filter = smethod_3(timeNodeContainer.TimeEffectBehavior);
	}

	private static Enum281 smethod_1(Class2658 timeEffectBehavior)
	{
		if (timeEffectBehavior.EffectBehaviorAtom != null && timeEffectBehavior.EffectBehaviorAtom.FTransitionPropertyUsed)
		{
			return timeEffectBehavior.EffectBehaviorAtom.EffectTransition switch
			{
				0u => Enum281.const_2, 
				1u => Enum281.const_3, 
				_ => Enum281.const_0, 
			};
		}
		return Enum281.const_0;
	}

	private static uint smethod_2(Enum281 transition, Class234 timelineSerializationContext)
	{
		switch (transition)
		{
		default:
			timelineSerializationContext.method_3("Writing of the animation effect behavior transition failed.", WarningType.DataLoss);
			return 0u;
		case Enum281.const_2:
			return 0u;
		case Enum281.const_3:
			return 1u;
		}
	}

	private static string smethod_3(Class2658 timeEffectBehavior)
	{
		if (timeEffectBehavior.EffectBehaviorAtom != null && timeEffectBehavior.EffectBehaviorAtom.FTypePropertyUsed)
		{
			return timeEffectBehavior.VarType?.Value;
		}
		return null;
	}

	public static void smethod_4(Class2267 animateEffectBehaviorElementData, Class2650 timeNodeContainer, Class234 timelineSerializationContext)
	{
		if (animateEffectBehaviorElementData != null)
		{
			if (timeNodeContainer == null)
			{
				throw new InvalidOperationException();
			}
			Class2658 @class = new Class2658();
			timeNodeContainer.Records.Add(@class);
			smethod_5(animateEffectBehaviorElementData, @class, timelineSerializationContext);
			if (!string.IsNullOrEmpty(animateEffectBehaviorElementData.Filter))
			{
				Class2764 class2 = new Class2764(animateEffectBehaviorElementData.Filter);
				class2.Header.Instance = 1;
				@class.Records.Add(class2);
			}
			if (animateEffectBehaviorElementData.Progress != null && animateEffectBehaviorElementData.Progress.Value != null && animateEffectBehaviorElementData.Progress.Value.Name == "fltVal")
			{
				Class2273 class3 = (Class2273)animateEffectBehaviorElementData.Progress.Value.Object;
				Class2762 item = new Class2762(class3.Val);
				@class.Records.Add(item);
			}
			Class2654 class4 = new Class2654();
			@class.Records.Add(class4);
			Class225.smethod_32(animateEffectBehaviorElementData.CBhvr, class4, timelineSerializationContext);
		}
	}

	private static void smethod_5(Class2267 animateEffectBehaviorElementData, Class2658 timeEffectBehaviorContainer, Class234 timelineSerializationContext)
	{
		if (animateEffectBehaviorElementData == null)
		{
			throw new ArgumentNullException();
		}
		if (timeEffectBehaviorContainer == null)
		{
			throw new ArgumentNullException();
		}
		Class2751 @class = new Class2751();
		timeEffectBehaviorContainer.Records.Add(@class);
		if (animateEffectBehaviorElementData.Transition != Enum281.const_0)
		{
			@class.FTransitionPropertyUsed = true;
			@class.EffectTransition = smethod_2(animateEffectBehaviorElementData.Transition, timelineSerializationContext);
		}
		else
		{
			@class.FTransitionPropertyUsed = false;
			@class.EffectTransition = 0u;
		}
		if (!string.IsNullOrEmpty(animateEffectBehaviorElementData.Filter))
		{
			@class.FTypePropertyUsed = true;
		}
		else
		{
			@class.FTypePropertyUsed = false;
		}
		if (animateEffectBehaviorElementData.Progress != null && animateEffectBehaviorElementData.Progress.Value != null)
		{
			if (animateEffectBehaviorElementData.Progress.Value.Name == "fltVal")
			{
				@class.FProgressPropertyUsed = true;
			}
			else
			{
				@class.FProgressPropertyUsed = false;
				timelineSerializationContext.method_3("Writing of the animation effect behavior failed.", WarningType.DataLoss);
			}
		}
		else
		{
			@class.FProgressPropertyUsed = false;
		}
		@class.FRuntimeContextObsolete = false;
	}
}
