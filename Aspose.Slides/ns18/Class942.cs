using System;
using Aspose.Slides.Effects;
using ns16;
using ns56;

namespace ns18;

internal class Class942
{
	public static void smethod_0(IImageTransformOperationCollection transforms, Class2605[] blipEffectList, Class1341 deserializationContext)
	{
		if (blipEffectList == null)
		{
			return;
		}
		foreach (Class2605 @class in blipEffectList)
		{
			switch (@class.Name)
			{
			case "alphaBiLevel":
			{
				Class1784 class14 = (Class1784)@class.Object;
				transforms.AddAlphaBiLevelEffect(class14.Thresh);
				break;
			}
			case "alphaCeiling":
				transforms.AddAlphaCeilingEffect();
				break;
			case "alphaFloor":
				transforms.AddAlphaFloorEffect();
				break;
			case "alphaInv":
			{
				Class1787 class13 = (Class1787)@class.Object;
				IAlphaInverse alphaInverse = transforms.AddAlphaInverseEffect();
				Class930.smethod_1(((AlphaInverse)alphaInverse).Color, class13.Color);
				break;
			}
			case "alphaMod":
				transforms.AddAlphaModulateEffect();
				break;
			case "alphaModFix":
			{
				Class1789 class12 = (Class1789)@class.Object;
				transforms.AddAlphaModulateFixedEffect(class12.Amt);
				break;
			}
			case "alphaRepl":
			{
				Class1791 class11 = (Class1791)@class.Object;
				transforms.AddAlphaReplaceEffect(class11.A);
				break;
			}
			case "biLevel":
			{
				Class1807 class10 = (Class1807)@class.Object;
				transforms.AddBiLevelEffect(class10.Thresh);
				break;
			}
			case "blur":
			{
				Class1811 class9 = (Class1811)@class.Object;
				transforms.AddBlurEffect(class9.Rad, class9.Grow);
				break;
			}
			case "clrChange":
			{
				Class1813 class8 = (Class1813)@class.Object;
				IColorChange colorChange = transforms.AddColorChangeEffect();
				((ColorChange)colorChange).UseAlpha = class8.UseA;
				Class930.smethod_1(colorChange.FromColor, class8.ClrFrom.Color);
				Class930.smethod_1(colorChange.ToColor, class8.ClrTo.Color);
				break;
			}
			case "clrRepl":
			{
				Class1817 class7 = (Class1817)@class.Object;
				IColorReplace colorReplace = transforms.AddColorReplaceEffect();
				Class930.smethod_1(colorReplace.Color, class7.Color);
				break;
			}
			case "duotone":
			{
				Class1831 class6 = (Class1831)@class.Object;
				IDuotone duotone = transforms.AddDuotoneEffect();
				Class930.smethod_1(duotone.Color1, class6.ColorList[0]);
				Class930.smethod_1(duotone.Color2, class6.ColorList[1]);
				break;
			}
			case "fillOverlay":
			{
				Class1841 class5 = (Class1841)@class.Object;
				IFillOverlay fillOverlay = transforms.AddFillOverlayEffect();
				fillOverlay.Blend = class5.Blend;
				Class949.smethod_0(fillOverlay.FillFormat, class5.FillProperties, deserializationContext);
				break;
			}
			case "grayscl":
				transforms.AddGrayScaleEffect();
				break;
			case "hsl":
			{
				Class1864 class4 = (Class1864)@class.Object;
				transforms.AddHSLEffect(class4.Hue, class4.Sat, class4.Lum);
				break;
			}
			case "lum":
			{
				Class1877 class3 = (Class1877)@class.Object;
				transforms.AddLuminanceEffect(class3.Bright, class3.Contrast);
				break;
			}
			case "tint":
			{
				Class1975 class2 = (Class1975)@class.Object;
				transforms.AddTintEffect(class2.Hue, class2.Amt);
				break;
			}
			default:
				throw new Exception("Unknown element \"" + @class.Name + "\"");
			}
		}
	}

	public static void smethod_1(IImageTransformOperationCollection transforms, Class2605.Delegate2773 addEffect, Class1346 serializationContext)
	{
		foreach (IImageTransformOperation transform in transforms)
		{
			if (transform is IAlphaBiLevel)
			{
				Class1784 @class = (Class1784)addEffect("alphaBiLevel").Object;
				IAlphaBiLevel alphaBiLevel = (IAlphaBiLevel)transform;
				@class.Thresh = alphaBiLevel.Threshold;
				continue;
			}
			if (transform is IAlphaCeiling)
			{
				addEffect("alphaCeiling");
				continue;
			}
			if (transform is IAlphaFloor)
			{
				addEffect("alphaFloor");
				continue;
			}
			if (transform is IAlphaInverse)
			{
				Class1787 class2 = (Class1787)addEffect("alphaInv").Object;
				IAlphaInverse alphaInverse = (IAlphaInverse)transform;
				Class930.smethod_4(((AlphaInverse)alphaInverse).Color, class2.delegate2773_0);
				continue;
			}
			if (transform is IAlphaModulate)
			{
				addEffect("alphaMod");
				continue;
			}
			if (transform is IAlphaModulateFixed)
			{
				Class1789 class3 = (Class1789)addEffect("alphaModFix").Object;
				IAlphaModulateFixed alphaModulateFixed = (IAlphaModulateFixed)transform;
				class3.Amt = alphaModulateFixed.Amount;
				continue;
			}
			if (transform is IAlphaReplace)
			{
				Class1791 class4 = (Class1791)addEffect("alphaRepl").Object;
				IAlphaReplace alphaReplace = (IAlphaReplace)transform;
				class4.A = ((AlphaReplace)alphaReplace).Alpha;
				continue;
			}
			if (transform is IBiLevel)
			{
				Class1807 class5 = (Class1807)addEffect("biLevel").Object;
				IBiLevel biLevel = (IBiLevel)transform;
				class5.Thresh = ((BiLevel)biLevel).Threshold;
				continue;
			}
			if (transform is IBlur)
			{
				Class1811 class6 = (Class1811)addEffect("blur").Object;
				IBlur blur = (IBlur)transform;
				class6.Rad = blur.Radius;
				class6.Grow = blur.Grow;
				continue;
			}
			if (transform is IColorChange)
			{
				Class1813 class7 = (Class1813)addEffect("clrChange").Object;
				IColorChange colorChange = (IColorChange)transform;
				class7.UseA = ((ColorChange)colorChange).UseAlpha;
				Class930.smethod_4(colorChange.FromColor, class7.ClrFrom.delegate2773_0);
				Class930.smethod_4(colorChange.ToColor, class7.ClrTo.delegate2773_0);
				continue;
			}
			if (transform is IColorReplace)
			{
				Class1817 class8 = (Class1817)addEffect("clrRepl").Object;
				IColorReplace colorReplace = (IColorReplace)transform;
				Class930.smethod_4(colorReplace.Color, class8.delegate2773_0);
				continue;
			}
			if (transform is IDuotone)
			{
				Class1831 class9 = (Class1831)addEffect("duotone").Object;
				IDuotone duotone = (IDuotone)transform;
				Class930.smethod_4(duotone.Color1, class9.delegate2773_0);
				Class930.smethod_4(duotone.Color2, class9.delegate2773_0);
				continue;
			}
			if (transform is IFillOverlay)
			{
				Class1841 class10 = (Class1841)addEffect("fillOverlay").Object;
				IFillOverlay fillOverlay = (IFillOverlay)transform;
				class10.Blend = fillOverlay.Blend;
				Class949.smethod_1(fillOverlay.FillFormat, class10.delegate2773_0, serializationContext);
				continue;
			}
			if (transform is IGrayScale)
			{
				addEffect("grayscl");
				continue;
			}
			if (transform is IHSL)
			{
				Class1864 class11 = (Class1864)addEffect("hsl").Object;
				IHSL iHSL = (IHSL)transform;
				class11.Hue = ((HSL)iHSL).Hue;
				class11.Sat = ((HSL)iHSL).Saturation;
				class11.Lum = ((HSL)iHSL).Luminance;
				continue;
			}
			if (transform is ILuminance)
			{
				Class1877 class12 = (Class1877)addEffect("lum").Object;
				ILuminance luminance = (ILuminance)transform;
				class12.Bright = ((Luminance)luminance).Brightness;
				class12.Contrast = ((Luminance)luminance).Contrast;
				continue;
			}
			if (transform is ITint)
			{
				Class1975 class13 = (Class1975)addEffect("tint").Object;
				ITint tint = (ITint)transform;
				class13.Hue = ((Tint)tint).Hue;
				class13.Amt = ((Tint)tint).Amount;
				continue;
			}
			throw new Exception();
		}
	}
}
