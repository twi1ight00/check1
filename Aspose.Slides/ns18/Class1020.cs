using Aspose.Slides.Animation;
using ns56;

namespace ns18;

internal class Class1020
{
	public static void smethod_0(ISetEffect setEffect, Class2293 setBehaviorElementData)
	{
		if (setBehaviorElementData.To != null)
		{
			setEffect.To = Class1016.smethod_0(setBehaviorElementData.To);
		}
	}

	public static void smethod_1(ISetEffect setEffect, Class2605.Delegate2773 addNodeDelegate, ref Class2281 commonBehaviorElementData)
	{
		Class2293 @class = (Class2293)addNodeDelegate("set").Object;
		commonBehaviorElementData = @class.CBhvr;
		if (setEffect.To != null)
		{
			@class.delegate2563_0();
			Class1016.smethod_1(setEffect.To, @class.To);
		}
	}
}
