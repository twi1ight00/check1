using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using ns56;
using ns57;

namespace ns18;

internal class Class1011
{
	public static void smethod_0(IColorEffect colorEffect, Class2266 nodeBehaviorElementData)
	{
		if (nodeBehaviorElementData == null)
		{
			throw new InvalidOperationException();
		}
		Class930.smethod_0(colorEffect.From, nodeBehaviorElementData.From);
		Class930.smethod_0(colorEffect.To, nodeBehaviorElementData.To);
		colorEffect.Direction = (ColorDirection)nodeBehaviorElementData.Dir;
		colorEffect.ColorSpace = (ColorSpace)nodeBehaviorElementData.ClrSpc;
		if (nodeBehaviorElementData.By == null)
		{
			return;
		}
		switch (nodeBehaviorElementData.By.ColorTransform.Name)
		{
		case "hsl":
		{
			Class1775 class2 = (Class1775)nodeBehaviorElementData.By.ColorTransform.Object;
			colorEffect.By.Value0 = class2.H;
			colorEffect.By.Value0 %= 360f;
			if (colorEffect.By.Value0 < 0f)
			{
				colorEffect.By.Value0 += 360f;
			}
			colorEffect.By.Value1 = class2.S / 100f;
			colorEffect.By.Value2 = class2.L / 100f;
			break;
		}
		case "rgb":
		{
			Class1776 @class = (Class1776)nodeBehaviorElementData.By.ColorTransform.Object;
			colorEffect.By.Value0 = @class.R / 100f;
			colorEffect.By.Value1 = @class.G / 100f;
			colorEffect.By.Value2 = @class.B / 100f;
			break;
		}
		default:
			throw new Exception("Unknown element \"" + nodeBehaviorElementData.By.ColorTransform.Name + "\"");
		}
	}

	public static void smethod_1(IColorEffect colorEffect, Class2605.Delegate2773 addNodeDelegate, ref Class2281 commonBehaviorElementData)
	{
		Class2266 @class = (Class2266)addNodeDelegate("animClr").Object;
		commonBehaviorElementData = @class.CBhvr;
		@class.ClrSpc = (Enum279)colorEffect.ColorSpace;
		if (colorEffect.From.ColorType != ColorType.NotDefined)
		{
			Class1814 colorElementData = @class.delegate1321_0();
			Class930.smethod_3(colorEffect.From, colorElementData);
		}
		if (colorEffect.To.ColorType != ColorType.NotDefined)
		{
			Class1814 colorElementData2 = @class.delegate1321_1();
			Class930.smethod_3(colorEffect.To, colorElementData2);
		}
		@class.Dir = (Enum280)colorEffect.Direction;
		if (float.IsNaN(colorEffect.By.Value0) || float.IsNaN(colorEffect.By.Value1) || float.IsNaN(colorEffect.By.Value2) || @class.ClrSpc == Enum279.const_0)
		{
			return;
		}
		@class.delegate2584_0();
		if (@class.ClrSpc == Enum279.const_2)
		{
			Class1775 class2 = (Class1775)@class.By.delegate2773_0("hsl").Object;
			colorEffect.By.Value0 %= 360f;
			if (colorEffect.By.Value0 < 0f)
			{
				colorEffect.By.Value0 += 360f;
			}
			class2.H = colorEffect.By.Value0;
			class2.S = colorEffect.By.Value1 * 100f;
			class2.L = colorEffect.By.Value2 * 100f;
		}
		else
		{
			Class1776 class3 = (Class1776)@class.By.delegate2773_0("rgb").Object;
			class3.R = colorEffect.By.Value0 * 100f;
			class3.G = colorEffect.By.Value1 * 100f;
			class3.B = colorEffect.By.Value2 * 100f;
		}
	}
}
