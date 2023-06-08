using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using ns16;
using ns18;
using ns25;
using ns56;

namespace ns17;

internal class Class904
{
	public static void smethod_0(IAxisFormat axisFormat, Class1921 spPrElementData, Class1341 deserializationContext)
	{
		if (spPrElementData != null)
		{
			if (spPrElementData.Xfrm != null || spPrElementData.Geometry != null || spPrElementData.Scene3d != null || spPrElementData.Sp3d != null)
			{
				throw new Exception();
			}
			Class949.smethod_0(axisFormat.Fill, spPrElementData.FillProperties, deserializationContext);
			Class968.smethod_0(axisFormat.Line, spPrElementData.Ln);
			Class939.smethod_0(axisFormat.Effect, spPrElementData.EffectProperties, deserializationContext);
			smethod_1(axisFormat, spPrElementData);
		}
	}

	private static void smethod_1(IAxisFormat axisFormat, Class1921 spPrElementData)
	{
		Class306 pPTXUnsupportedProps = ((AxisFormat)axisFormat).PPTXUnsupportedProps;
		pPTXUnsupportedProps.ExtensionList = spPrElementData.ExtLst;
	}

	public static void smethod_2(IAxisFormat axisFormat, Class1921.Delegate1630 addSpPr, Class1346 serializationContext)
	{
		if (smethod_4(axisFormat))
		{
			Class1921 @class = addSpPr();
			Class949.smethod_1(axisFormat.Fill, @class.delegate2773_1, serializationContext);
			Class968.smethod_2(axisFormat.Line, @class.delegate1504_0);
			Class939.smethod_1(axisFormat.Effect, @class.delegate2773_0, serializationContext);
			smethod_3(axisFormat, @class);
		}
	}

	private static void smethod_3(IAxisFormat axisFormat, Class1921 spPrElementData)
	{
		Class306 pPTXUnsupportedProps = ((AxisFormat)axisFormat).PPTXUnsupportedProps;
		spPrElementData.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
	}

	internal static bool smethod_4(IAxisFormat axisFormat)
	{
		if (axisFormat.Fill.FillType == FillType.NotDefined && axisFormat.Line.IsFormatNotDefined)
		{
			return !axisFormat.Effect.IsNoEffects;
		}
		return true;
	}
}
