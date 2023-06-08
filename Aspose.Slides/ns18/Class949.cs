using System;
using Aspose.Slides;
using ns16;
using ns56;

namespace ns18;

internal class Class949
{
	public static void smethod_0(IFillFormat fillFormat, Class2605 fillPropertiesElementData, Class1341 deserializationContext)
	{
		if (fillPropertiesElementData != null)
		{
			switch (fillPropertiesElementData.Name)
			{
			case "noFill":
				fillFormat.FillType = FillType.NoFill;
				break;
			case "solidFill":
			{
				Class1924 class3 = (Class1924)fillPropertiesElementData.Object;
				fillFormat.FillType = FillType.Solid;
				Class930.smethod_1(fillFormat.SolidFillColor, class3.Color);
				break;
			}
			case "gradFill":
			{
				Class1853 class2 = (Class1853)fillPropertiesElementData.Object;
				fillFormat.FillType = FillType.Gradient;
				fillFormat.RotateWithShape = class2.RotWithShape;
				Class957.smethod_0(fillFormat.GradientFormat, class2);
				break;
			}
			case "blipFill":
			{
				Class1810 @class = (Class1810)fillPropertiesElementData.Object;
				fillFormat.FillType = FillType.Picture;
				fillFormat.RotateWithShape = @class.RotWithShape;
				Class974.smethod_0(fillFormat.PictureFillFormat, @class, deserializationContext);
				break;
			}
			case "pattFill":
			{
				Class1900 patternElementData = (Class1900)fillPropertiesElementData.Object;
				fillFormat.FillType = FillType.Pattern;
				Class973.smethod_0(fillFormat.PatternFormat, patternElementData);
				break;
			}
			default:
				throw new Exception("Unknown element \"" + fillPropertiesElementData.Name + "\"");
			case "grpFill":
				fillFormat.FillType = FillType.Group;
				break;
			}
		}
	}

	public static void smethod_1(IFillFormat fillFormat, Class2605.Delegate2773 addFillProperties, Class1346 serializationContext)
	{
		if (fillFormat != null)
		{
			switch (fillFormat.FillType)
			{
			case FillType.NoFill:
				addFillProperties("noFill");
				break;
			case FillType.Solid:
			{
				Class1924 class3 = (Class1924)addFillProperties("solidFill").Object;
				Class930.smethod_4(fillFormat.SolidFillColor, class3.delegate2773_0);
				break;
			}
			case FillType.Gradient:
			{
				Class1853 class2 = (Class1853)addFillProperties("gradFill").Object;
				class2.RotWithShape = fillFormat.RotateWithShape;
				Class957.smethod_1(fillFormat.GradientFormat, class2);
				break;
			}
			case FillType.Pattern:
			{
				Class1900 patternElementData = (Class1900)addFillProperties("pattFill").Object;
				Class973.smethod_1(fillFormat.PatternFormat, patternElementData);
				break;
			}
			case FillType.Picture:
			{
				Class1810 @class = (Class1810)addFillProperties("blipFill").Object;
				@class.RotWithShape = fillFormat.RotateWithShape;
				Class974.smethod_1(fillFormat.PictureFillFormat, @class, serializationContext);
				break;
			}
			case FillType.Group:
				addFillProperties("grpFill");
				break;
			case FillType.NotDefined:
				break;
			}
		}
	}
}
