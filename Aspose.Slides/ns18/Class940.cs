using Aspose.Slides.Effects;
using ns16;
using ns56;

namespace ns18;

internal class Class940
{
	public static void smethod_0(IFillOverlay fillOverlay, Class1841 fillOverlayEffectElementData, Class1341 deserializationContext)
	{
		if (fillOverlayEffectElementData != null)
		{
			fillOverlay.Blend = fillOverlayEffectElementData.Blend;
			Class949.smethod_0(fillOverlay.FillFormat, fillOverlayEffectElementData.FillProperties, deserializationContext);
		}
	}

	public static void smethod_1(IFillOverlay fillOverlay, Class1841.Delegate1402 addFillOverlay, Class1346 serializationContext)
	{
		if (fillOverlay != null)
		{
			Class1841 @class = addFillOverlay();
			@class.Blend = fillOverlay.Blend;
			Class949.smethod_1(fillOverlay.FillFormat, @class.delegate2773_0, serializationContext);
		}
	}
}
