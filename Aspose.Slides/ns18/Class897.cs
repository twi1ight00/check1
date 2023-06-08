using System;
using Aspose.Slides;
using ns16;
using ns24;
using ns56;

namespace ns18;

internal class Class897
{
	public static void smethod_0(IBackground background, Class2222 backgroundElementData, Class1341 deserializationContext)
	{
		if (backgroundElementData != null)
		{
			Class294 pPTXUnsupportedProps = ((Background)background).PPTXUnsupportedProps;
			pPTXUnsupportedProps.BwMode = backgroundElementData.BwMode;
			switch (backgroundElementData.Background.Name)
			{
			case "bgRef":
			{
				Class1929 class2 = (Class1929)backgroundElementData.Background.Object;
				background.Type = BackgroundType.Themed;
				pPTXUnsupportedProps.Idx = class2.Idx;
				Class930.smethod_1(background.StyleColor, class2.Color);
				break;
			}
			default:
				throw new Exception("Unknown element \"" + backgroundElementData.Background.Name + "\"");
			case "bgPr":
			{
				Class2223 @class = (Class2223)backgroundElementData.Background.Object;
				background.Type = BackgroundType.OwnBackground;
				Class949.smethod_0(background.FillFormat, @class.FillProperties, deserializationContext);
				pPTXUnsupportedProps.EffectProperties = @class.EffectProperties;
				pPTXUnsupportedProps.ShadeToTitle = @class.ShadeToTitle;
				pPTXUnsupportedProps.ExtensionList = @class.ExtLst;
				break;
			}
			}
		}
	}

	public static void smethod_1(IBackground background, Class2222.Delegate2402 addBg, Class1346 serializationContext)
	{
		if (background != null && background.Type != BackgroundType.NotDefined)
		{
			Class294 pPTXUnsupportedProps = ((Background)background).PPTXUnsupportedProps;
			Class2222 @class = addBg();
			@class.BwMode = pPTXUnsupportedProps.BwMode;
			switch (background.Type)
			{
			default:
				throw new Exception();
			case BackgroundType.Themed:
			{
				Class1929 class3 = (Class1929)@class.delegate2773_0("bgRef").Object;
				Class930.smethod_4(background.StyleColor, class3.delegate2773_0);
				class3.Idx = pPTXUnsupportedProps.Idx;
				break;
			}
			case BackgroundType.OwnBackground:
			{
				Class2223 class2 = (Class2223)@class.delegate2773_0("bgPr").Object;
				Class949.smethod_1(background.FillFormat, class2.delegate2773_1, serializationContext);
				class2.EffectProperties = pPTXUnsupportedProps.EffectProperties;
				class2.ShadeToTitle = pPTXUnsupportedProps.ShadeToTitle;
				class2.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
				break;
			}
			}
		}
	}
}
