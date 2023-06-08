using Aspose.Slides;
using Aspose.Slides.Warnings;
using ns16;
using ns24;
using ns56;

namespace ns18;

internal class Class980
{
	public static void smethod_0(Class520 presetTextShape, Class1911 presetTextShapeElementData)
	{
		if (presetTextShapeElementData != null)
		{
			presetTextShape.class341_0 = Class954.smethod_1(presetTextShapeElementData.AvLst, null, out presetTextShape.dictionary_0);
			presetTextShape.TextShapeType = presetTextShapeElementData.Prst;
		}
	}

	public static void smethod_1(Class520 presetTextShape, Class1911.Delegate1600 addPrstTxWarp, Class1346 serializationContext)
	{
		if (presetTextShape.TextShapeType != TextShapeType.NotDefined)
		{
			Class1911 @class = addPrstTxWarp();
			Class954.smethod_7(presetTextShape.class341_0, @class.delegate1429_0());
			if (presetTextShape.TextShapeType == TextShapeType.Custom)
			{
				serializationContext.method_30("PPT serialization of the presetTextShape of type TextShapeType.Custom is not implemented yet.", WarningType.MajorFormattingLoss);
			}
			else
			{
				@class.Prst = presetTextShape.TextShapeType;
			}
		}
	}
}
