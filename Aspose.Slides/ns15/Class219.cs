using System;
using ns16;
using ns56;
using ns63;

namespace ns15;

internal class Class219
{
	public static void smethod_0(Class2269 timeNodeAnimateRotationBehavior, Class2650 timeNodeContainer, Class854 deserializationContext)
	{
		if (timeNodeContainer != null && timeNodeContainer.TimeRotationBehavior != null)
		{
			Class2663 timeRotationBehavior = timeNodeContainer.TimeRotationBehavior;
			Class222.smethod_1(timeNodeAnimateRotationBehavior.CBhvr, timeNodeContainer, timeRotationBehavior.Behavior, deserializationContext);
			if (timeRotationBehavior.RotationBehaviorAtom.FByPropertyUsed)
			{
				timeNodeAnimateRotationBehavior.By = timeRotationBehavior.RotationBehaviorAtom.By;
			}
			if (timeRotationBehavior.RotationBehaviorAtom.FFromPropertyUsed)
			{
				timeNodeAnimateRotationBehavior.From = timeRotationBehavior.RotationBehaviorAtom.From;
			}
			if (timeRotationBehavior.RotationBehaviorAtom.FToPropertyUsed)
			{
				timeNodeAnimateRotationBehavior.To = timeRotationBehavior.RotationBehaviorAtom.To;
			}
			return;
		}
		throw new InvalidOperationException();
	}

	public static void smethod_1(Class2269 animateRotationBehaviorElementData, Class2650 timeNodeContainer, Class234 timelineSerializationContext)
	{
		if (animateRotationBehaviorElementData != null)
		{
			if (timeNodeContainer == null)
			{
				throw new InvalidOperationException();
			}
			Class2663 @class = new Class2663();
			timeNodeContainer.Records.Add(@class);
			smethod_2(animateRotationBehaviorElementData, @class);
			Class2654 class2 = new Class2654();
			@class.Records.Add(class2);
			Class225.smethod_32(animateRotationBehaviorElementData.CBhvr, class2, timelineSerializationContext);
		}
	}

	private static void smethod_2(Class2269 animateRotationBehaviorElementData, Class2663 timeRotationBehaviorContainer)
	{
		if (animateRotationBehaviorElementData == null)
		{
			throw new ArgumentNullException();
		}
		if (timeRotationBehaviorContainer == null)
		{
			throw new ArgumentNullException();
		}
		Class2756 @class = new Class2756();
		timeRotationBehaviorContainer.Records.Add(@class);
		if (animateRotationBehaviorElementData.By != float.NaN)
		{
			@class.FByPropertyUsed = true;
			@class.By = animateRotationBehaviorElementData.By;
		}
		else
		{
			@class.FByPropertyUsed = false;
		}
		if (animateRotationBehaviorElementData.From != float.NaN)
		{
			@class.FFromPropertyUsed = true;
			@class.From = animateRotationBehaviorElementData.From;
		}
		else
		{
			@class.FFromPropertyUsed = false;
			@class.From = 0f;
		}
		if (animateRotationBehaviorElementData.To != float.NaN)
		{
			@class.FToPropertyUsed = true;
			@class.To = animateRotationBehaviorElementData.To;
		}
		else
		{
			@class.FToPropertyUsed = false;
			@class.To = 360f;
		}
	}
}
