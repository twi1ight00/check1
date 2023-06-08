using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using ns16;
using ns18;
using ns25;
using ns56;

namespace ns17;

internal class Class921
{
	public static void smethod_0(IFormat format, Class1921 spPrElementData, Class1341 deserializationContext)
	{
		if (spPrElementData != null)
		{
			if (spPrElementData.Xfrm != null || spPrElementData.Geometry != null)
			{
				throw new Exception();
			}
			Class949.smethod_0(format.Fill, spPrElementData.FillProperties, deserializationContext);
			Class968.smethod_0(format.Line, spPrElementData.Ln);
			Class939.smethod_0(format.Effect, spPrElementData.EffectProperties, deserializationContext);
			Class1007.smethod_0(format.Effect3D, spPrElementData.Scene3d, spPrElementData.Sp3d, null);
			Class323 pPTXUnsupportedProps = ((Format)format).PPTXUnsupportedProps;
			pPTXUnsupportedProps.ExtensionList = spPrElementData.ExtLst;
		}
	}

	public static void smethod_1(IFormat format, Class1921.Delegate1630 addSpPr, Class1346 serializationContext)
	{
		if (smethod_2(format))
		{
			Class1921 @class = addSpPr();
			Class949.smethod_1(format.Fill, @class.delegate2773_1, serializationContext);
			Class968.smethod_2(format.Line, @class.delegate1504_0);
			Class939.smethod_1(format.Effect, @class.delegate2773_0, serializationContext);
			Class1007.smethod_1(format.Effect3D, @class.delegate1615_0, @class.delegate1624_0, null);
			Class323 pPTXUnsupportedProps = ((Format)format).PPTXUnsupportedProps;
			@class.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
		}
	}

	internal static bool smethod_2(IFormat format)
	{
		if (format.Fill.FillType == FillType.NotDefined && format.Line.IsFormatNotDefined && format.Effect.IsNoEffects)
		{
			return Class1007.smethod_2(format.Effect3D, shape3d: true);
		}
		return true;
	}
}
