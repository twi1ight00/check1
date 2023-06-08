using System;
using System.Drawing;
using Aspose.Slides;
using ns24;
using ns33;
using ns56;

namespace ns18;

internal class Class930
{
	private static readonly Class1151 class1151_0 = new Class1151("tint", "shade", "comp", "inv", "gray", "alpha", "alphaOff", "alphaMod", "hue", "hueOff", "hueMod", "sat", "satOff", "satMod", "lum", "lumOff", "lumMod", "red", "redOff", "redMod", "green", "greenOff", "greenMod", "blue", "blueOff", "blueMod", "gamma", "invGamma");

	public static void smethod_0(IColorFormat colorFormat, Class1814 colorElementData)
	{
		if (colorElementData != null)
		{
			smethod_1(colorFormat, colorElementData.Color);
		}
	}

	public static void smethod_1(IColorFormat colorFormat, Class2605 colorElementData)
	{
		if (colorElementData == null)
		{
			return;
		}
		Class329 pPTXUnsupportedProps = ((ColorFormat)colorFormat).PPTXUnsupportedProps;
		Class2605[] colorTransformList;
		Class2605[] array;
		int num;
		switch (colorElementData.Name)
		{
		case "scrgbClr":
		{
			Class1918 class6 = (Class1918)colorElementData.Object;
			((ColorFormat)colorFormat).method_6(ColorType.RGBPercentage);
			float r = class6.R / 100f;
			float g = class6.G / 100f;
			float b = class6.B / 100f;
			Class1178.smethod_0(ref r, ref g, ref b);
			((ColorFormat)colorFormat).method_7(r);
			((ColorFormat)colorFormat).method_8(g);
			((ColorFormat)colorFormat).method_9(b);
			colorTransformList = class6.ColorTransformList;
			goto IL_02d5;
		}
		case "srgbClr":
		{
			Class1926 class7 = (Class1926)colorElementData.Object;
			((ColorFormat)colorFormat).method_6(ColorType.RGB);
			uint val = class7.Val;
			((ColorFormat)colorFormat).method_7((int)(byte)(val >> 16));
			((ColorFormat)colorFormat).method_8((int)(byte)((val >> 8) & 0xFF));
			((ColorFormat)colorFormat).method_9((int)(byte)(val & 0xFF));
			colorTransformList = class7.ColorTransformList;
			goto IL_02d5;
		}
		case "hslClr":
		{
			Class1863 class4 = (Class1863)colorElementData.Object;
			((ColorFormat)colorFormat).method_6(ColorType.HSL);
			float hue = class4.Hue;
			hue %= 360f;
			if (hue < 0f)
			{
				hue += 360f;
			}
			float data = class4.Sat / 100f;
			float data2 = class4.Lum / 100f;
			((ColorFormat)colorFormat).method_7(hue);
			((ColorFormat)colorFormat).method_8(data);
			((ColorFormat)colorFormat).method_9(data2);
			colorTransformList = class4.ColorTransformList;
			goto IL_02d5;
		}
		case "sysClr":
		{
			Class1931 class3 = (Class1931)colorElementData.Object;
			colorFormat.SystemColor = class3.Val;
			int lastClr = (int)class3.LastClr;
			byte red = (byte)(lastClr >> 16);
			byte green = (byte)((uint)(lastClr >> 8) & 0xFFu);
			byte blue = (byte)((uint)lastClr & 0xFFu);
			pPTXUnsupportedProps.LastColor = Color.FromArgb(red, green, blue);
			colorTransformList = class3.ColorTransformList;
			goto IL_02d5;
		}
		case "schemeClr":
		{
			Class1917 class2 = (Class1917)colorElementData.Object;
			colorFormat.SchemeColor = class2.Val;
			colorTransformList = class2.ColorTransformList;
			goto IL_02d5;
		}
		case "prstClr":
		{
			Class1907 @class = (Class1907)colorElementData.Object;
			colorFormat.PresetColor = @class.Val;
			colorTransformList = @class.ColorTransformList;
			goto IL_02d5;
		}
		default:
			{
				throw new Exception("Unknown element \"" + colorElementData.Name + "\"");
			}
			IL_02d5:
			colorFormat.ColorTransform.Clear();
			array = colorTransformList;
			num = 0;
			while (true)
			{
				if (num >= array.Length)
				{
					return;
				}
				Class2605 class5 = array[num];
				object obj = class1151_0[class5.Name];
				ColorTransformOperation colorTransformOperation = ColorTransformOperation.Tint;
				float parameter;
				if (obj != null)
				{
					colorTransformOperation = ColorTransformOperation.Tint;
					colorTransformOperation = ColorTransformOperation.Tint;
					colorTransformOperation = ColorTransformOperation.Tint;
					colorTransformOperation = (ColorTransformOperation)(int)obj;
					switch (colorTransformOperation)
					{
					case ColorTransformOperation.Complement:
					case ColorTransformOperation.Inverse:
					case ColorTransformOperation.Grayscale:
					case ColorTransformOperation.Gamma:
					case ColorTransformOperation.InverseGamma:
						parameter = 0f;
						goto IL_03c6;
					case ColorTransformOperation.SetHue:
					case ColorTransformOperation.AddHue:
						if (class5.Object is Class1792)
						{
							parameter = (class5.Object as Class1792).Val;
							goto IL_03c6;
						}
						throw new Exception();
					}
				}
				else
				{
					colorTransformOperation = ColorTransformOperation.Tint;
					colorTransformOperation = ColorTransformOperation.Tint;
					colorTransformOperation = ColorTransformOperation.Tint;
					ColorTransformOperation colorTransformOperation2 = ColorTransformOperation.Tint;
				}
				if (!(class5.Object is Class1901))
				{
					break;
				}
				parameter = (class5.Object as Class1901).Val / 100f;
				goto IL_03c6;
				IL_03c6:
				colorFormat.ColorTransform.Add(colorTransformOperation, parameter);
				num++;
			}
			throw new Exception();
		}
	}

	public static void smethod_2(IColorFormat colorFormat, Class1814.Delegate1321 addColor)
	{
		if (colorFormat != null && colorFormat.ColorType != ColorType.NotDefined)
		{
			Class1814 colorElementData = addColor();
			smethod_3(colorFormat, colorElementData);
		}
	}

	public static void smethod_3(IColorFormat colorFormat, Class1814 colorElementData)
	{
		smethod_4(colorFormat, colorElementData.delegate2773_0);
	}

	public static void smethod_4(IColorFormat colorFormat, Class2605.Delegate2773 addColor)
	{
		if (colorFormat == null || colorFormat.ColorType == ColorType.NotDefined)
		{
			return;
		}
		Class2605.Delegate2773 delegate2773_;
		switch (colorFormat.ColorType)
		{
		default:
		{
			Class1926 class5 = (Class1926)addColor("srgbClr").Object;
			delegate2773_ = class5.delegate2773_0;
			class5.Val = (uint)((colorFormat.R << 16) + (colorFormat.G << 8) + colorFormat.B);
			break;
		}
		case ColorType.RGBPercentage:
		{
			Class1918 class6 = (Class1918)addColor("scrgbClr").Object;
			delegate2773_ = class6.delegate2773_0;
			float r = colorFormat.FloatR;
			float g = colorFormat.FloatG;
			float b = colorFormat.FloatB;
			Class1178.smethod_1(ref r, ref g, ref b);
			class6.R = r * 100f;
			class6.G = g * 100f;
			class6.B = b * 100f;
			break;
		}
		case ColorType.HSL:
		{
			Class1863 class4 = (Class1863)addColor("hslClr").Object;
			delegate2773_ = class4.delegate2773_0;
			float hue = colorFormat.Hue;
			hue %= 360f;
			if (hue < 0f)
			{
				hue += 360f;
			}
			class4.Hue = hue;
			class4.Sat = colorFormat.Saturation * 100f;
			class4.Lum = colorFormat.Luminance * 100f;
			break;
		}
		case ColorType.Scheme:
		{
			Class1917 class3 = (Class1917)addColor("schemeClr").Object;
			delegate2773_ = class3.delegate2773_0;
			class3.Val = colorFormat.SchemeColor;
			break;
		}
		case ColorType.System:
		{
			Class1931 class2 = (Class1931)addColor("sysClr").Object;
			delegate2773_ = class2.delegate2773_0;
			class2.Val = colorFormat.SystemColor;
			Color lastColor = ((ColorFormat)colorFormat).PPTXUnsupportedProps.LastColor;
			class2.LastClr = (uint)((lastColor.R << 16) + (lastColor.G << 8) + lastColor.B);
			break;
		}
		case ColorType.Preset:
		{
			Class1907 @class = (Class1907)addColor("prstClr").Object;
			delegate2773_ = @class.delegate2773_0;
			@class.Val = colorFormat.PresetColor;
			break;
		}
		}
		foreach (IColorOperation item in colorFormat.ColorTransform)
		{
			Class2605 class7 = delegate2773_(class1151_0[(int)item.OperationType]);
			switch (item.OperationType)
			{
			default:
				((Class1901)class7.Object).Val = item.Parameter * 100f;
				break;
			case ColorTransformOperation.SetHue:
			case ColorTransformOperation.AddHue:
				((Class1792)class7.Object).Val = item.Parameter;
				break;
			case ColorTransformOperation.Complement:
			case ColorTransformOperation.Inverse:
			case ColorTransformOperation.Grayscale:
			case ColorTransformOperation.Gamma:
			case ColorTransformOperation.InverseGamma:
				break;
			}
		}
	}
}
