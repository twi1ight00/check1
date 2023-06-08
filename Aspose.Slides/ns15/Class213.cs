using ns16;
using ns18;
using ns56;
using ns57;
using ns63;
using ns64;

namespace ns15;

internal class Class213
{
	public static void smethod_0(Class2301 condElementData, Class2657 timeConditionContainer, Class854 deserializationContext)
	{
		if (timeConditionContainer != null && timeConditionContainer.ConditionAtom != null)
		{
			if (timeConditionContainer.ConditionAtom.TriggerObject == Enum402.const_1)
			{
				Class2306 targetElementData = (Class2306)condElementData.delegate2773_0("tgtEl").Object;
				Class228.smethod_0(targetElementData, timeConditionContainer.VisualElement.VisualElementAtom, deserializationContext);
			}
			else if (timeConditionContainer.ConditionAtom.TriggerObject == Enum402.const_3)
			{
				Class2307 @class = (Class2307)condElementData.delegate2773_0("rtn").Object;
				@class.Val = Enum182.const_3;
			}
			else if (timeConditionContainer.ConditionAtom.TriggerObject == Enum402.const_2)
			{
				Class2308 class2 = (Class2308)condElementData.delegate2773_0("tn").Object;
				class2.Val = (int)timeConditionContainer.ConditionAtom.Id;
			}
			condElementData.Evt = smethod_1(timeConditionContainer.ConditionAtom.TriggerEvent);
			condElementData.Delay = Class225.smethod_18((float)timeConditionContainer.ConditionAtom.Delay / 1000f);
		}
	}

	private static Enum277 smethod_1(uint triggerEventId)
	{
		return triggerEventId switch
		{
			0u => Enum277.const_0, 
			1u => Enum277.const_1, 
			3u => Enum277.const_3, 
			4u => Enum277.const_4, 
			5u => Enum277.const_5, 
			7u => Enum277.const_7, 
			9u => Enum277.const_9, 
			10u => Enum277.const_10, 
			11u => Enum277.const_11, 
			_ => Enum277.const_0, 
		};
	}

	private static uint smethod_2(Enum277 triggerEvent)
	{
		return triggerEvent switch
		{
			Enum277.const_0 => 0u, 
			Enum277.const_1 => 1u, 
			Enum277.const_3 => 3u, 
			Enum277.const_4 => 4u, 
			Enum277.const_5 => 5u, 
			Enum277.const_7 => 7u, 
			Enum277.const_9 => 9u, 
			Enum277.const_10 => 10u, 
			Enum277.const_11 => 11u, 
			_ => 0u, 
		};
	}

	public static void smethod_3(Class2301 conditionElementData, Class2650 timeNodeContainer, Enum396 conditionType, Class234 timelineSerializationContext)
	{
		if (conditionElementData != null)
		{
			Class2657 @class = new Class2657(conditionType);
			timeNodeContainer.Records.Add(@class);
			smethod_4(conditionElementData, @class);
			if (conditionElementData.Trigger != null && conditionElementData.Trigger.Name == "tgtEl")
			{
				Class228.smethod_7((Class2306)conditionElementData.Trigger.Object, @class, timelineSerializationContext);
			}
		}
	}

	private static void smethod_4(Class2301 conditionElementData, Class2657 timeConditionContainer)
	{
		Class2750 @class = new Class2750();
		timeConditionContainer.Records.Add(@class);
		if (conditionElementData.Trigger == null)
		{
			@class.TriggerObject = Enum402.const_0;
		}
		else
		{
			switch (conditionElementData.Trigger.Name)
			{
			case "rtn":
				@class.TriggerObject = Enum402.const_3;
				@class.Id = 2u;
				break;
			case "tn":
			{
				@class.TriggerObject = Enum402.const_2;
				Class2308 class2 = (Class2308)conditionElementData.Trigger.Object;
				@class.Id = (uint)class2.Val;
				break;
			}
			case "tgtEl":
				@class.TriggerObject = Enum402.const_1;
				break;
			default:
				@class.TriggerObject = Enum402.const_0;
				break;
			}
		}
		@class.TriggerEvent = smethod_2(conditionElementData.Evt);
		@class.Delay = Class225.smethod_17(Class1008.smethod_7(conditionElementData.Delay));
	}
}
