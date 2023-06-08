using Aspose.Slides.Theme;
using ns16;
using ns56;

namespace ns18;

internal class Class938
{
	public static void smethod_0(IEffectStyle effectStyle, Class1836 effectStyleElementData, Class1341 deserializationContext)
	{
		if (effectStyleElementData != null)
		{
			Class939.smethod_0(effectStyle.EffectFormat, effectStyleElementData.EffectProperties, deserializationContext);
			Class1007.smethod_0(effectStyle.ThreeDFormat, effectStyleElementData.Scene3d, effectStyleElementData.Sp3d, null);
		}
	}

	public static void smethod_1(IEffectStyle effectStyle, Class1836.Delegate1387 addEffectStyle, Class1346 serializationContext)
	{
		if (effectStyle != null)
		{
			Class1836 @class = addEffectStyle();
			Class939.smethod_2(effectStyle.EffectFormat, (Class1833)@class.delegate2773_0("effectLst").Object, serializationContext);
			Class1007.smethod_1(effectStyle.ThreeDFormat, @class.delegate1615_0, @class.delegate1624_0, null);
		}
	}
}
