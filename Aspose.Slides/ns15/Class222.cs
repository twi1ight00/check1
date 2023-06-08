using System;
using ns56;
using ns57;
using ns60;
using ns63;

namespace ns15;

internal class Class222
{
	public static void smethod_0(Class2281 timeNodeBehaviorElementData, Class2651 timeNodeContainer, Class2654 timeBehaviorContainer, Class854 deserializationContext)
	{
		if (timeNodeContainer != null && timeBehaviorContainer != null)
		{
			Class229.smethod_0(timeNodeBehaviorElementData.CTn, timeNodeBehaviorElementData.CTn.delegate2653_0, timeNodeBehaviorElementData.CTn.delegate2653_1, timeNodeContainer, deserializationContext);
			smethod_2(timeNodeBehaviorElementData, timeBehaviorContainer, deserializationContext);
		}
	}

	public static void smethod_1(Class2281 timeNodeBehaviorElementData, Class2650 timeNodeContainer, Class2654 timeBehaviorContainer, Class854 deserializationContext)
	{
		if (timeNodeContainer != null && timeBehaviorContainer != null)
		{
			Class225.smethod_0(timeNodeBehaviorElementData.CTn, timeNodeBehaviorElementData.CTn.delegate2653_0, timeNodeBehaviorElementData.CTn.delegate2653_1, timeNodeContainer, deserializationContext);
			smethod_2(timeNodeBehaviorElementData, timeBehaviorContainer, deserializationContext);
		}
	}

	private static void smethod_2(Class2281 timeNodeBehaviorElementData, Class2654 timeBehaviorContainer, Class854 deserializationContext)
	{
		if (timeBehaviorContainer == null)
		{
			return;
		}
		Class228.smethod_0(timeNodeBehaviorElementData.TgtEl, timeBehaviorContainer.ClientVisualElement.VisualElementAtom, deserializationContext);
		if (timeBehaviorContainer.StringList != null && timeBehaviorContainer.StringList.Length > 0)
		{
			Class2276 @class = timeNodeBehaviorElementData.delegate2575_0();
			foreach (Class2623 record in timeBehaviorContainer.StringList.Records)
			{
				if (record is Class2764 class2)
				{
					@class.method_3(class2.Value);
				}
			}
		}
		timeNodeBehaviorElementData.Additive = smethod_3(timeBehaviorContainer.BehaviorAtom.BehaviorAdditive);
		timeNodeBehaviorElementData.Accumulate = Enum284.const_0;
		timeNodeBehaviorElementData.XfrmType = Enum287.const_0;
		timeNodeBehaviorElementData.Override = Enum286.const_0;
	}

	private static Enum285 smethod_3(uint behAdditive)
	{
		return behAdditive switch
		{
			0u => Enum285.const_2, 
			1u => Enum285.const_3, 
			_ => Enum285.const_1, 
		};
	}

	private static uint smethod_4(Enum285 additiveType)
	{
		return additiveType switch
		{
			Enum285.const_2 => 0u, 
			Enum285.const_3 => 1u, 
			_ => 0u, 
		};
	}

	public static void smethod_5(Class2281 timeNodeBehaviorElementData, Class2654 timeBehaviorContainer)
	{
		if (timeNodeBehaviorElementData == null)
		{
			throw new InvalidOperationException();
		}
		if (timeBehaviorContainer == null)
		{
			throw new InvalidOperationException();
		}
		Class2747 @class = new Class2747();
		timeBehaviorContainer.Records.Add(@class);
		if (timeNodeBehaviorElementData.Additive != Enum285.const_0)
		{
			@class.FAdditivePropertyUsed = true;
			@class.BehaviorAdditive = smethod_4(timeNodeBehaviorElementData.Additive);
		}
		else
		{
			@class.FAdditivePropertyUsed = false;
			@class.BehaviorAdditive = 0u;
		}
		if (timeNodeBehaviorElementData.AttrNameLst != null && timeNodeBehaviorElementData.AttrNameLst.AttrNameList.Length > 0)
		{
			@class.FAttributeNamesPropertyUsed = true;
		}
		else
		{
			@class.FAttributeNamesPropertyUsed = false;
		}
		@class.BehaviorAccumulate = 0u;
		@class.BehaviorTransform = 0u;
	}

	public static void smethod_6(Class2281 timeNodeBehaviorElementData, Class2654 timeBehaviorContainer)
	{
		Class2666 @class = new Class2666();
		timeBehaviorContainer.Records.Add(@class);
		if (timeNodeBehaviorElementData != null && timeNodeBehaviorElementData.AttrNameLst != null && timeNodeBehaviorElementData.AttrNameLst.AttrNameList.Length != 0)
		{
			if (timeBehaviorContainer == null)
			{
				throw new InvalidOperationException();
			}
			string[] attrNameList = timeNodeBehaviorElementData.AttrNameLst.AttrNameList;
			foreach (string value in attrNameList)
			{
				Class2764 item = new Class2764(value);
				@class.Records.Add(item);
			}
		}
	}
}
