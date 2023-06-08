using System;
using Aspose.Slides;
using ns56;

namespace ns18;

internal class Class967
{
	public static void smethod_0(ILineFillFormat lineFillFormat, Class2605 lineFillPropertiesElementData)
	{
		if (lineFillPropertiesElementData != null)
		{
			lineFillFormat.FillType = FillType.NotDefined;
			switch (lineFillPropertiesElementData.Name)
			{
			case "pattFill":
			{
				Class1900 patternElementData = (Class1900)lineFillPropertiesElementData.Object;
				lineFillFormat.FillType = FillType.Pattern;
				Class973.smethod_0(lineFillFormat.PatternFormat, patternElementData);
				break;
			}
			case "gradFill":
			{
				Class1853 class2 = (Class1853)lineFillPropertiesElementData.Object;
				lineFillFormat.FillType = FillType.Gradient;
				lineFillFormat.RotateWithShape = class2.RotWithShape;
				Class957.smethod_0(lineFillFormat.GradientFormat, class2);
				break;
			}
			case "solidFill":
			{
				Class1924 @class = (Class1924)lineFillPropertiesElementData.Object;
				lineFillFormat.FillType = FillType.Solid;
				Class930.smethod_1(lineFillFormat.SolidFillColor, @class.Color);
				break;
			}
			default:
				throw new Exception("Unknown element \"" + lineFillPropertiesElementData.Name + "\"");
			case "noFill":
				lineFillFormat.FillType = FillType.NoFill;
				break;
			}
		}
	}

	public static void smethod_1(ILineFillFormat lineFillFormat, Class2605.Delegate2773 addLineFillProperties)
	{
		if (lineFillFormat.FillType != FillType.NotDefined)
		{
			switch (lineFillFormat.FillType)
			{
			default:
				throw new Exception();
			case FillType.NoFill:
				addLineFillProperties("noFill");
				break;
			case FillType.Solid:
			{
				Class1924 class2 = (Class1924)addLineFillProperties("solidFill").Object;
				Class930.smethod_4(lineFillFormat.SolidFillColor, class2.delegate2773_0);
				break;
			}
			case FillType.Gradient:
			{
				Class1853 @class = (Class1853)addLineFillProperties("gradFill").Object;
				Class957.smethod_1(lineFillFormat.GradientFormat, @class);
				@class.RotWithShape = lineFillFormat.RotateWithShape;
				break;
			}
			case FillType.Pattern:
			{
				Class1900 patternElementData = (Class1900)addLineFillProperties("pattFill").Object;
				Class973.smethod_1(lineFillFormat.PatternFormat, patternElementData);
				break;
			}
			}
		}
	}
}
