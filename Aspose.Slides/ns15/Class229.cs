using ns56;
using ns63;

namespace ns15;

internal class Class229
{
	public static void smethod_0(Class2283 timeNodeElementData, Class2302.Delegate2653 addStCondLstDelegate, Class2302.Delegate2653 addEndCondLstDelegate, Class2651 timeSubNodeContainer, Class854 deserializationContext)
	{
		if (timeSubNodeContainer != null)
		{
			Class225.smethod_15(timeNodeElementData, timeSubNodeContainer.TimeNodeAtom, deserializationContext.DeserializationContext);
			Class225.smethod_1(timeNodeElementData, timeSubNodeContainer.TimePropertyList, deserializationContext.DeserializationContext);
			Class212.smethod_0(addStCondLstDelegate, timeSubNodeContainer.RgBeginTimeCondition, deserializationContext);
			Class212.smethod_0(addEndCondLstDelegate, timeSubNodeContainer.RgEndTimeCondition, deserializationContext);
			Class225.smethod_21(timeNodeElementData, timeSubNodeContainer.RgTimeModifierAtom);
		}
	}
}
