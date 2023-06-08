using Aspose.Slides;
using Aspose.Slides.Theme;
using ns16;
using ns56;

namespace ns18;

internal class Class953
{
	public static void smethod_0(IFormatScheme formatScheme, Class1928 styleMatrixElementData, Class1341 deserializationContext)
	{
		if (styleMatrixElementData != null)
		{
			Class2605[] fillPropertiesList = styleMatrixElementData.FillStyleLst.FillPropertiesList;
			foreach (Class2605 fillPropertiesElementData in fillPropertiesList)
			{
				IFillFormat fillFormat = ((FillFormatCollection)formatScheme.FillStyles).Add();
				Class949.smethod_0(fillFormat, fillPropertiesElementData, deserializationContext);
			}
			Class1875[] lnList = styleMatrixElementData.LnStyleLst.LnList;
			foreach (Class1875 linePropertiesElementData in lnList)
			{
				ILineFormat lineFormat = ((LineFormatCollection)formatScheme.LineStyles).Add();
				Class968.smethod_0(lineFormat, linePropertiesElementData);
			}
			Class1836[] effectStyleList = styleMatrixElementData.EffectStyleLst.EffectStyleList;
			foreach (Class1836 effectStyleElementData in effectStyleList)
			{
				IEffectStyle effectStyle = ((EffectStyleCollection)formatScheme.EffectStyles).Add();
				Class938.smethod_0(effectStyle, effectStyleElementData, deserializationContext);
			}
			Class2605[] fillPropertiesList2 = styleMatrixElementData.BgFillStyleLst.FillPropertiesList;
			foreach (Class2605 fillPropertiesElementData2 in fillPropertiesList2)
			{
				IFillFormat fillFormat2 = ((FillFormatCollection)formatScheme.BackgroundFillStyles).Add();
				Class949.smethod_0(fillFormat2, fillPropertiesElementData2, deserializationContext);
			}
			((FormatScheme)formatScheme).Name = styleMatrixElementData.Name;
		}
	}

	public static void smethod_1(IFormatScheme formatScheme, Class1928 styleMatrixElementData, Class1346 serializationContext)
	{
		foreach (IFillFormat fillStyle in formatScheme.FillStyles)
		{
			Class949.smethod_1(fillStyle, styleMatrixElementData.FillStyleLst.delegate2773_0, serializationContext);
		}
		foreach (ILineFormat lineStyle in formatScheme.LineStyles)
		{
			Class968.smethod_2(lineStyle, styleMatrixElementData.LnStyleLst.delegate1504_0);
		}
		foreach (IEffectStyle effectStyle in formatScheme.EffectStyles)
		{
			Class938.smethod_1(effectStyle, styleMatrixElementData.EffectStyleLst.delegate1387_0, serializationContext);
		}
		foreach (IFillFormat backgroundFillStyle in formatScheme.BackgroundFillStyles)
		{
			Class949.smethod_1(backgroundFillStyle, styleMatrixElementData.BgFillStyleLst.delegate2773_0, serializationContext);
		}
		styleMatrixElementData.Name = ((FormatScheme)formatScheme).Name;
	}

	public static void smethod_2(IFormatScheme formatScheme, Class1928.Delegate1651 addFmtScheme, Class1346 serializationContext)
	{
		if (formatScheme != null)
		{
			Class1928 styleMatrixElementData = addFmtScheme();
			smethod_1(formatScheme, styleMatrixElementData, serializationContext);
		}
	}
}
