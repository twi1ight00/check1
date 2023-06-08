using ns16;
using ns56;
using ns63;

namespace ns15;

internal class Class212
{
	public static void smethod_0(Class2302.Delegate2653 addCondLstDelegate, Class2657[] timeConditionsContainers, Class854 deserializationContext)
	{
		if (timeConditionsContainers != null && timeConditionsContainers.Length != 0)
		{
			Class2302 @class = addCondLstDelegate();
			foreach (Class2657 timeConditionContainer in timeConditionsContainers)
			{
				Class2301 condElementData = @class.delegate2650_0();
				Class213.smethod_0(condElementData, timeConditionContainer, deserializationContext);
			}
		}
	}

	public static void smethod_1(Class2302 timeConditionListElementData, Class2650 timeNodeContainer, Enum396 conditionType, Class234 timelineSerializationContext)
	{
		if (timeConditionListElementData != null && timeConditionListElementData.CondList.Length != 0)
		{
			Class2301[] condList = timeConditionListElementData.CondList;
			foreach (Class2301 conditionElementData in condList)
			{
				Class213.smethod_3(conditionElementData, timeNodeContainer, conditionType, timelineSerializationContext);
			}
		}
	}
}
