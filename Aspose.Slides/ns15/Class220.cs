using System;
using Aspose.Slides;
using ns16;
using ns56;
using ns63;

namespace ns15;

internal class Class220
{
	public static void smethod_0(Class2270 timeNodeAnimateScaleBehavior, Class2650 timeNodeContainer, Class854 deserializationContext)
	{
		if (timeNodeContainer != null && timeNodeContainer.TimeScaleBehavior != null)
		{
			Class2664 timeScaleBehavior = timeNodeContainer.TimeScaleBehavior;
			Class222.smethod_1(timeNodeAnimateScaleBehavior.CBhvr, timeNodeContainer, timeScaleBehavior.Behavior, deserializationContext);
			if (timeScaleBehavior.ScaleBehaviorAtom.FByPropertyUsed)
			{
				Class2292 @class = timeNodeAnimateScaleBehavior.delegate2623_0();
				@class.X = timeScaleBehavior.ScaleBehaviorAtom.XBy;
				@class.Y = timeScaleBehavior.ScaleBehaviorAtom.YBy;
			}
			if (timeScaleBehavior.ScaleBehaviorAtom.FFromPropertyUsed)
			{
				Class2292 class2 = timeNodeAnimateScaleBehavior.delegate2623_1();
				class2.X = timeScaleBehavior.ScaleBehaviorAtom.XFrom;
				class2.Y = timeScaleBehavior.ScaleBehaviorAtom.YFrom;
			}
			if (timeScaleBehavior.ScaleBehaviorAtom.FToPropertyUsed)
			{
				Class2292 class3 = timeNodeAnimateScaleBehavior.delegate2623_2();
				class3.X = timeScaleBehavior.ScaleBehaviorAtom.XTo;
				class3.Y = timeScaleBehavior.ScaleBehaviorAtom.YTo;
			}
			if (timeScaleBehavior.ScaleBehaviorAtom.FZoomContentsUsed)
			{
				timeNodeAnimateScaleBehavior.ZoomContents = ((timeScaleBehavior.ScaleBehaviorAtom.ZoomContents == 1) ? NullableBool.True : NullableBool.False);
			}
			else
			{
				timeNodeAnimateScaleBehavior.ZoomContents = NullableBool.NotDefined;
			}
			return;
		}
		throw new InvalidOperationException();
	}

	public static void smethod_1(Class2270 animateScaleBehaviorElementData, Class2650 timeNodeContainer, Class234 timelineSerializationContext)
	{
		if (animateScaleBehaviorElementData != null)
		{
			if (timeNodeContainer == null)
			{
				throw new InvalidOperationException();
			}
			Class2664 @class = new Class2664();
			timeNodeContainer.Records.Add(@class);
			smethod_2(animateScaleBehaviorElementData, @class);
			Class2654 class2 = new Class2654();
			@class.Records.Add(class2);
			Class225.smethod_32(animateScaleBehaviorElementData.CBhvr, class2, timelineSerializationContext);
		}
	}

	private static void smethod_2(Class2270 animateScaleBehaviorElementData, Class2664 timeScaleBehaviorContainer)
	{
		if (animateScaleBehaviorElementData == null)
		{
			throw new ArgumentNullException();
		}
		if (timeScaleBehaviorContainer == null)
		{
			throw new ArgumentNullException();
		}
		Class2757 @class = new Class2757();
		timeScaleBehaviorContainer.Records.Add(@class);
		if (animateScaleBehaviorElementData.By != null)
		{
			@class.FByPropertyUsed = true;
			@class.XBy = animateScaleBehaviorElementData.By.X;
			@class.YBy = animateScaleBehaviorElementData.By.Y;
		}
		else
		{
			@class.FByPropertyUsed = false;
		}
		if (animateScaleBehaviorElementData.From != null)
		{
			@class.FFromPropertyUsed = true;
			@class.XFrom = animateScaleBehaviorElementData.From.X;
			@class.YFrom = animateScaleBehaviorElementData.From.Y;
		}
		else
		{
			@class.FFromPropertyUsed = false;
		}
		if (animateScaleBehaviorElementData.To != null)
		{
			@class.FToPropertyUsed = true;
			@class.XTo = animateScaleBehaviorElementData.To.X;
			@class.YTo = animateScaleBehaviorElementData.To.Y;
		}
		else
		{
			@class.FToPropertyUsed = false;
		}
		if (animateScaleBehaviorElementData.ZoomContents != NullableBool.NotDefined)
		{
			@class.FZoomContentsUsed = true;
			@class.ZoomContents = ((animateScaleBehaviorElementData.ZoomContents == NullableBool.True) ? ((byte)1) : ((byte)0));
		}
		else
		{
			@class.FZoomContentsUsed = false;
		}
	}
}
