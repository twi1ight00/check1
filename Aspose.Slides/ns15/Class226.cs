using System;
using Aspose.Slides.Warnings;
using ns16;
using ns56;
using ns63;

namespace ns15;

internal class Class226
{
	public static void smethod_0(Class2293 timeNodeSetBehavior, Class2651 timeNodeContainer, Class854 deserializationContext)
	{
		if (timeNodeContainer == null || timeNodeContainer.TimeSetBehavior == null)
		{
			throw new InvalidOperationException();
		}
		Class2665 timeSetBehavior = timeNodeContainer.TimeSetBehavior;
		Class222.smethod_0(timeNodeSetBehavior.CBhvr, timeNodeContainer, timeSetBehavior.Behavior, deserializationContext);
		smethod_2(timeNodeSetBehavior, timeSetBehavior);
	}

	public static void smethod_1(Class2293 timeNodeSetBehavior, Class2650 timeNodeContainer, Class854 deserializationContext)
	{
		if (timeNodeContainer == null || timeNodeContainer.TimeSetBehavior == null)
		{
			throw new InvalidOperationException();
		}
		Class2665 timeSetBehavior = timeNodeContainer.TimeSetBehavior;
		Class222.smethod_1(timeNodeSetBehavior.CBhvr, timeNodeContainer, timeSetBehavior.Behavior, deserializationContext);
		smethod_2(timeNodeSetBehavior, timeSetBehavior);
	}

	private static void smethod_2(Class2293 timeNodeSetBehavior, Class2665 timeSetBehavior)
	{
		if (timeSetBehavior == null)
		{
			throw new InvalidOperationException();
		}
		if (timeSetBehavior.VarTo != null)
		{
			Class2272 @class = timeNodeSetBehavior.delegate2563_0();
			Class2275 class2 = (Class2275)@class.delegate2773_0("strVal").Object;
			class2.Val = timeSetBehavior.VarTo.Value;
		}
	}

	public static void smethod_3(Class2293 setBehaviorElementData, Class2650 timeNodeContainer, Class234 timelineSerializationContext)
	{
		if (setBehaviorElementData != null)
		{
			if (timeNodeContainer == null)
			{
				throw new InvalidOperationException();
			}
			Class2665 @class = new Class2665();
			timeNodeContainer.Records.Add(@class);
			smethod_4(setBehaviorElementData, @class, timelineSerializationContext);
			if (setBehaviorElementData.To != null && setBehaviorElementData.To.Value != null && setBehaviorElementData.To.Value.Name == "strVal")
			{
				Class2275 class2 = (Class2275)setBehaviorElementData.To.Value.Object;
				Class2764 class3 = new Class2764(class2.Val);
				class3.Header.Instance = 1;
				@class.Records.Add(class3);
			}
			Class2654 class4 = new Class2654();
			@class.Records.Add(class4);
			Class225.smethod_32(setBehaviorElementData.CBhvr, class4, timelineSerializationContext);
		}
	}

	private static void smethod_4(Class2293 setBehaviorElementData, Class2665 timeSetBehaviorContainer, Class234 timelineSerializationContext)
	{
		if (setBehaviorElementData == null)
		{
			throw new ArgumentNullException();
		}
		if (timeSetBehaviorContainer == null)
		{
			throw new ArgumentNullException();
		}
		Class2759 @class = new Class2759();
		timeSetBehaviorContainer.Records.Add(@class);
		if (setBehaviorElementData.To != null && setBehaviorElementData.To.Value != null)
		{
			if (setBehaviorElementData.To.Value.Name == "strVal")
			{
				@class.FToPropertyUsed = true;
				@class.ValueType = Enum397.const_1;
			}
			else
			{
				timelineSerializationContext.method_3("Writing of the animation set behavior failed.", WarningType.DataLoss);
			}
		}
		else
		{
			@class.FToPropertyUsed = false;
			@class.ValueType = Enum397.const_1;
		}
	}
}
