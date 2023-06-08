using System;
using System.Collections.Generic;
using Aspose.Slides;
using ns24;
using ns4;
using ns62;

namespace ns15;

internal class Class1041 : Class1037
{
	internal static void smethod_15(AutoShape targetShape, Class2670 shapeContainer, Class854 slideDeserializationContext)
	{
		Class1037.smethod_12(targetShape, shapeContainer, slideDeserializationContext);
		ShapeType shapeType = Class232.smethod_6((int)shapeContainer.ShapeProp.ShapeType);
		if (shapeType == ShapeType.Custom)
		{
			if (shapeContainer.ShapeProp.ShapeType != 0 && shapeContainer.ShapeProp.ShapeType != Enum425.const_100)
			{
				Class204 domShapeImp = Class204.smethod_4((Enum18)shapeContainer.ShapeProp.ShapeType);
				Class1037.smethod_14(targetShape.Geometry, domShapeImp);
			}
			else
			{
				Class1037.smethod_13(targetShape, shapeContainer);
			}
		}
		else
		{
			targetShape.Geometry.Preset = shapeType;
		}
		Class1052.smethod_0(targetShape.fillFormat_0, shapeContainer, slideDeserializationContext);
		IShapeFrame frame = targetShape.Frame;
		Class1056.smethod_0(targetShape.LineFormat, shapeContainer, slideDeserializationContext, Class232.smethod_7(targetShape.ShapeType), flipLineStyle: false);
		Class875.smethod_0(targetShape.EffectFormat, shapeContainer, slideDeserializationContext);
		Class864.smethod_0(targetShape.ThreeDFormat, shapeContainer.ShapePrimaryOptions, shapeContainer.ShapeTertiaryOptions, slideDeserializationContext);
		if (targetShape.Geometry.Adjustments != null)
		{
			Class204 @class = Class204.smethod_4((Enum18)shapeContainer.ShapeProp.ShapeType);
			int[] array;
			if (@class != null && @class.DefData != null)
			{
				array = new int[Math.Max(targetShape.Geometry.Adjustments.Length, @class.DefData.Length)];
				Array.Copy(@class.DefData, array, @class.DefData.Length);
			}
			else
			{
				array = new int[targetShape.Geometry.Adjustments.Length];
			}
			for (int i = 0; i < array.Length; i++)
			{
				Class2911 class2 = ((shapeContainer.ShapePrimaryOptions != null) ? (shapeContainer.ShapePrimaryOptions.Properties[(Enum426)(i + 327)] as Class2911) : null);
				if (class2 != null)
				{
					array[i] = (int)class2.Value;
				}
			}
			for (int j = 0; j < targetShape.Geometry.Adjustments.Length; j++)
			{
				targetShape.Geometry.Adjustments[j] = new Class341("adj" + j, 0L);
			}
			Class232.smethod_24(targetShape.Geometry.Adjustments, targetShape.Geometry.Preset, array, frame.Width, frame.Height);
			if (shapeType == ShapeType.CurvedArc)
			{
				double num = targetShape.Geometry.Adjustments[0].AngleValue % 360f;
				double num2 = targetShape.Geometry.Adjustments[1].AngleValue % 360f;
				double num3 = num / 180.0 * Math.PI;
				double num4 = num2 / 180.0 * Math.PI;
				double val = Math.Cos(num3) / 2.0 + 0.5;
				double val2 = Math.Sin(num3) / 2.0 + 0.5;
				double val3 = Math.Cos(num4) / 2.0 + 0.5;
				double val4 = Math.Sin(num4) / 2.0 + 0.5;
				double num5 = Math.Min(val, val3);
				double num6 = Math.Min(val2, val4);
				double num7 = Math.Max(val, val3);
				double num8 = Math.Max(val2, val4);
				if (num5 > 0.5)
				{
					num5 = 0.5;
				}
				if (num7 < 0.5)
				{
					num7 = 0.5;
				}
				if (num6 > 0.5)
				{
					num6 = 0.5;
				}
				if (num8 < 0.5)
				{
					num8 = 0.5;
				}
				if (num > num2)
				{
					num2 += 360.0;
				}
				if (num2 > 360.0)
				{
					num7 = 1.0;
				}
				if (num < 90.0 && num2 > 90.0)
				{
					num8 = 1.0;
				}
				if (num < 180.0 && num2 > 180.0)
				{
					num5 = 0.0;
				}
				if (num < 270.0 && num2 > 270.0)
				{
					num6 = 0.0;
				}
				double num9 = (double)frame.Width / (num7 - num5);
				double num10 = (double)frame.Height / (num8 - num6);
				double x = (double)frame.X - num5 * num9;
				double y = (double)frame.Y - num6 * num10;
				targetShape.Frame = new ShapeFrame(x, y, num9, num10, frame.FlipH, frame.FlipV, frame.Rotation);
			}
		}
		slideDeserializationContext.FrameToPlaceholder.TryGetValue(shapeContainer, out var value);
		if (value != null && value.class2951_0 != null)
		{
			targetShape.TextFrameInternal = Class1066.smethod_2(targetShape, shapeContainer, value, slideDeserializationContext);
		}
		else
		{
			targetShape.TextFrameInternal = Class1066.smethod_0(targetShape, shapeContainer, slideDeserializationContext);
		}
		targetShape.method_26();
	}

	internal static void smethod_16(AutoShape autoShape)
	{
		if (autoShape.TextFrameInternal != null && autoShape.TextFrameInternal.textFrameFormat_0.textStyle_0 != null)
		{
			Class1070.smethod_3(smethod_17(autoShape), autoShape.TextFrameInternal.textFrameFormat_0.textStyle_0);
		}
	}

	private static ITextStyle[] smethod_17(AutoShape targetShape)
	{
		IMasterSlide masterSlide = null;
		BaseSlide baseSlide = (BaseSlide)targetShape.Slide;
		if (baseSlide is Slide)
		{
			masterSlide = ((Slide)baseSlide).MasterSlide;
		}
		else if (baseSlide is LayoutSlide)
		{
			masterSlide = ((LayoutSlide)baseSlide).MasterSlide;
		}
		else if (baseSlide is MasterSlide)
		{
			masterSlide = (MasterSlide)baseSlide;
		}
		Presentation presentation = (Presentation)baseSlide.ParentPresentation;
		ITextStyle textStyle = presentation.textStyle_0;
		if (masterSlide != null && targetShape.Placeholder != null)
		{
			switch ((Enum136)TextFrame.class1155_0[targetShape.Placeholder.Type])
			{
			case Enum136.const_1:
				textStyle = masterSlide.TitleStyle;
				break;
			case Enum136.const_2:
				textStyle = masterSlide.BodyStyle;
				break;
			case Enum136.const_3:
				textStyle = masterSlide.OtherStyle;
				break;
			}
		}
		List<ITextStyle> list = new List<ITextStyle>(3);
		if (textStyle != null)
		{
			list.Add(textStyle);
		}
		Shape[] array = targetShape.method_2();
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] is AutoShape autoShape && autoShape.TextFrame != null && autoShape.TextFrame.TextFrameFormat.TextStyle != null)
			{
				list.Add(autoShape.TextFrame.TextFrameFormat.TextStyle);
			}
		}
		return list.ToArray();
	}
}
