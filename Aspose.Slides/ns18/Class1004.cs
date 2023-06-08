using System;
using ns16;
using ns4;
using ns56;

namespace ns18;

internal class Class1004
{
	public static void smethod_0(Class147 themeableEffectFormat, Class2605 effectStyleElementData, Class1341 deserializationContext)
	{
		if (effectStyleElementData != null)
		{
			themeableEffectFormat.EffectStyleIndex = 0u;
			themeableEffectFormat.Source = Enum272.const_0;
			switch (effectStyleElementData.Name)
			{
			case "effectRef":
			{
				Class1929 class2 = (Class1929)effectStyleElementData.Object;
				themeableEffectFormat.Source = Enum272.const_2;
				Class930.smethod_1(themeableEffectFormat.StyleColor, class2.Color);
				themeableEffectFormat.EffectStyleIndex = class2.Idx;
				break;
			}
			default:
				throw new Exception("Unknown element \"" + effectStyleElementData.Name + "\"");
			case "effect":
			{
				Class1834 @class = (Class1834)effectStyleElementData.Object;
				themeableEffectFormat.Source = Enum272.const_1;
				Class939.smethod_0(themeableEffectFormat.EffectFormat, @class.EffectProperties, deserializationContext);
				break;
			}
			}
		}
	}

	public static void smethod_1(Class147 themeableEffectFormat, Class2605.Delegate2773 addEffectStyle, Class1346 serializationContext)
	{
		switch (themeableEffectFormat.Source)
		{
		case Enum272.const_1:
		{
			Class1834 class2 = (Class1834)addEffectStyle("effect").Object;
			Class939.smethod_1(themeableEffectFormat.EffectFormat, class2.delegate2773_0, serializationContext);
			break;
		}
		case Enum272.const_2:
		{
			Class1929 @class = (Class1929)addEffectStyle("effectRef").Object;
			Class930.smethod_4(themeableEffectFormat.StyleColor, @class.delegate2773_0);
			@class.Idx = themeableEffectFormat.EffectStyleIndex;
			break;
		}
		case Enum272.const_0:
			break;
		}
	}
}
