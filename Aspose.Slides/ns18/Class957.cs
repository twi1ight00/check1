using System;
using Aspose.Slides;
using ns56;

namespace ns18;

internal class Class957
{
	public static void smethod_0(IGradientFormat gradientFormat, Class1853 gradientElementData)
	{
		if (gradientElementData == null)
		{
			return;
		}
		GradientFormat gradientFormat2 = (GradientFormat)gradientFormat;
		gradientFormat2.TileFlip = gradientElementData.Flip;
		Class981.smethod_0(gradientFormat2.TileRectangle, gradientElementData.TileRect);
		gradientFormat2.GradientDirection = GradientDirection.NotDefined;
		if (gradientElementData.ShadeProperties != null)
		{
			switch (gradientElementData.ShadeProperties.Name)
			{
			case "path":
			{
				Class1899 class2 = (Class1899)gradientElementData.ShadeProperties.Object;
				switch (class2.Path)
				{
				default:
					gradientFormat2.GradientShape = GradientShape.NotDefined;
					break;
				case Enum312.const_1:
					gradientFormat2.GradientShape = GradientShape.Path;
					break;
				case Enum312.const_2:
					gradientFormat2.GradientShape = GradientShape.Radial;
					break;
				case Enum312.const_3:
					gradientFormat2.GradientShape = GradientShape.Rectangle;
					break;
				}
				if (class2.FillToRect != null)
				{
					gradientFormat2.method_6(class2.FillToRect.L / 100f, class2.FillToRect.T / 100f, 1f - class2.FillToRect.R / 100f - class2.FillToRect.L / 100f, 1f - class2.FillToRect.B / 100f - class2.FillToRect.T / 100f);
				}
				else
				{
					gradientFormat2.method_6(0f, 0f, 1f, 1f);
				}
				break;
			}
			case "lin":
			{
				Class1870 @class = (Class1870)gradientElementData.ShadeProperties.Object;
				gradientFormat2.GradientShape = GradientShape.Linear;
				gradientFormat2.LinearGradientAngle = @class.Ang;
				gradientFormat2.LinearGradientScaled = @class.Scaled;
				break;
			}
			default:
				throw new Exception("Unknown element \"" + gradientElementData.ShadeProperties.Name + "\"");
			}
		}
		gradientFormat2.GradientStops.Clear();
		if (gradientElementData.GsLst != null)
		{
			Class1854[] gsList = gradientElementData.GsLst.GsList;
			Class1854[] array = gsList;
			foreach (Class1854 class3 in array)
			{
				IGradientStop gradientStop = ((GradientStopCollection)gradientFormat2.GradientStops).Add();
				gradientStop.Position = class3.Pos / 100f;
				Class930.smethod_1(gradientStop.Color, class3.Color);
			}
		}
	}

	public static void smethod_1(IGradientFormat gradientFormat, Class1853 gradientElementData)
	{
		if (gradientFormat.GradientStops.Count >= 2)
		{
			Class1855 @class = gradientElementData.delegate1444_0();
			foreach (IGradientStop gradientStop in gradientFormat.GradientStops)
			{
				Class1854 class2 = @class.delegate1441_0();
				class2.Pos = gradientStop.Position * 100f;
				Class930.smethod_4(gradientStop.Color, class2.delegate2773_0);
			}
		}
		gradientElementData.Flip = gradientFormat.TileFlip;
		if (gradientFormat.GradientShape == GradientShape.Linear)
		{
			Class1870 class3 = (Class1870)gradientElementData.delegate2773_0("lin").Object;
			class3.Ang = gradientFormat.LinearGradientAngle;
			class3.Scaled = gradientFormat.LinearGradientScaled;
		}
		else if (gradientFormat.GradientShape != GradientShape.NotDefined)
		{
			Class1899 class4 = (Class1899)gradientElementData.delegate2773_0("path").Object;
			switch (gradientFormat.GradientShape)
			{
			case GradientShape.NotDefined:
				class4.Path = Enum312.const_0;
				break;
			default:
				throw new Exception();
			case GradientShape.Rectangle:
				class4.Path = Enum312.const_3;
				break;
			case GradientShape.Radial:
				class4.Path = Enum312.const_2;
				break;
			case GradientShape.Path:
				class4.Path = Enum312.const_1;
				break;
			}
			Class981.smethod_1(((GradientFormat)gradientFormat).FillToRectangle, class4.delegate1612_0);
		}
		Class981.smethod_1(((GradientFormat)gradientFormat).TileRectangle, gradientElementData.delegate1612_0);
	}
}
