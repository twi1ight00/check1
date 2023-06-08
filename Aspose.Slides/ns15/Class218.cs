using System;
using ns16;
using ns56;
using ns57;
using ns63;

namespace ns15;

internal class Class218
{
	public static void smethod_0(Class2268 timeNodeAnimateMotion, Class2650 timeNodeContainer, Class854 deserializationContext)
	{
		if (timeNodeContainer != null && timeNodeContainer.TimeMotionBehavior != null)
		{
			Class2659 timeMotionBehavior = timeNodeContainer.TimeMotionBehavior;
			Class222.smethod_1(timeNodeAnimateMotion.CBhvr, timeNodeContainer, timeMotionBehavior.TimeBehavior, deserializationContext);
			if (timeMotionBehavior.MotionBehaviorAtom.FByPropertyUsed)
			{
				Class2292 @class = timeNodeAnimateMotion.delegate2623_0();
				@class.X = timeMotionBehavior.MotionBehaviorAtom.XBy;
				@class.Y = timeMotionBehavior.MotionBehaviorAtom.YBy;
			}
			if (timeMotionBehavior.MotionBehaviorAtom.FFromPropertyUsed)
			{
				Class2292 class2 = timeNodeAnimateMotion.delegate2623_1();
				class2.X = timeMotionBehavior.MotionBehaviorAtom.XFrom;
				class2.Y = timeMotionBehavior.MotionBehaviorAtom.YFrom;
			}
			if (timeMotionBehavior.MotionBehaviorAtom.FToPropertyUsed)
			{
				Class2292 class3 = timeNodeAnimateMotion.delegate2623_2();
				class3.X = timeMotionBehavior.MotionBehaviorAtom.XTo;
				class3.Y = timeMotionBehavior.MotionBehaviorAtom.YTo;
			}
			timeNodeAnimateMotion.Origin = smethod_1(timeMotionBehavior.MotionBehaviorAtom.BehaviorOrigin);
			timeNodeAnimateMotion.Path = ((timeMotionBehavior.VarPath == null) ? null : timeMotionBehavior.VarPath.Value);
			return;
		}
		throw new InvalidOperationException();
	}

	private static Enum282 smethod_1(uint behaviorOrigin)
	{
		switch (behaviorOrigin)
		{
		default:
			return Enum282.const_0;
		case 0u:
		case 1u:
			return Enum282.const_1;
		case 2u:
			return Enum282.const_2;
		}
	}

	private static uint smethod_2(Enum282 behaviorOrigin)
	{
		return behaviorOrigin switch
		{
			Enum282.const_1 => 0u, 
			Enum282.const_2 => 2u, 
			_ => throw new NotImplementedException(), 
		};
	}

	public static void smethod_3(Class2268 animationMotionBehaviorElementData, Class2650 timeNodeContainer, Class234 timelineSerializationContext)
	{
		if (animationMotionBehaviorElementData != null)
		{
			if (timeNodeContainer == null)
			{
				throw new InvalidOperationException();
			}
			Class2659 @class = new Class2659();
			timeNodeContainer.Records.Add(@class);
			smethod_4(animationMotionBehaviorElementData, @class);
			if (!string.IsNullOrEmpty(animationMotionBehaviorElementData.Path))
			{
				Class2764 item = new Class2764(animationMotionBehaviorElementData.Path);
				@class.Records.Add(item);
			}
			Class2654 class2 = new Class2654();
			@class.Records.Add(class2);
			Class225.smethod_32(animationMotionBehaviorElementData.CBhvr, class2, timelineSerializationContext);
		}
	}

	private static void smethod_4(Class2268 animationMotionBehaviorElementData, Class2659 timeMotionBehaviorContainer)
	{
		if (animationMotionBehaviorElementData == null)
		{
			throw new ArgumentNullException();
		}
		if (timeMotionBehaviorContainer == null)
		{
			throw new ArgumentNullException();
		}
		Class2754 @class = new Class2754();
		timeMotionBehaviorContainer.Records.Add(@class);
		if (animationMotionBehaviorElementData.By != null)
		{
			@class.FByPropertyUsed = true;
			@class.XBy = animationMotionBehaviorElementData.By.X;
			@class.YBy = animationMotionBehaviorElementData.By.Y;
		}
		else
		{
			@class.FByPropertyUsed = false;
		}
		if (animationMotionBehaviorElementData.From != null)
		{
			@class.FFromPropertyUsed = true;
			@class.XFrom = animationMotionBehaviorElementData.From.X;
			@class.YFrom = animationMotionBehaviorElementData.From.Y;
		}
		else
		{
			@class.FFromPropertyUsed = false;
		}
		if (animationMotionBehaviorElementData.To != null)
		{
			@class.FToPropertyUsed = true;
			@class.XTo = animationMotionBehaviorElementData.To.X;
			@class.YTo = animationMotionBehaviorElementData.To.Y;
		}
		else
		{
			@class.FToPropertyUsed = false;
		}
		if (animationMotionBehaviorElementData.Origin != Enum282.const_0)
		{
			@class.FOriginPropertyUsed = true;
			@class.BehaviorOrigin = smethod_2(animationMotionBehaviorElementData.Origin);
		}
		else
		{
			@class.FToPropertyUsed = false;
		}
		if (!string.IsNullOrEmpty(animationMotionBehaviorElementData.Path))
		{
			@class.FPathPropertyUsed = true;
		}
		else
		{
			@class.FPathPropertyUsed = false;
		}
		if (animationMotionBehaviorElementData.PathEditMode != Enum283.const_0)
		{
			@class.FEditRotationPropertyUsed = true;
		}
		else
		{
			@class.FEditRotationPropertyUsed = false;
		}
		if (!string.IsNullOrEmpty(animationMotionBehaviorElementData.PtsTypes))
		{
			@class.FPointsTypesPropertyUsed = true;
		}
		else
		{
			@class.FPointsTypesPropertyUsed = false;
		}
	}
}
