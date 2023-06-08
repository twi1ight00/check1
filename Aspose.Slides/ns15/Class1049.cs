using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Warnings;
using ns33;
using ns62;
using ns63;

namespace ns15;

internal class Class1049
{
	internal static void smethod_0(Color color, int colorIndex, ColorFormat targetFormat)
	{
		targetFormat.ColorTransform.Clear();
		if (color.A < byte.MaxValue)
		{
			targetFormat.ColorTransform.Add(ColorTransformOperation.SetAlpha, (float)(int)color.A / 255f);
		}
		if (colorIndex < 0)
		{
			targetFormat.Color = color;
		}
		else
		{
			targetFormat.SchemeColor = Class232.smethod_13(colorIndex);
		}
	}

	internal static void smethod_1(IColorFormat targetFormat, uint officeArtCOLORREF, double alpha)
	{
		if ((officeArtCOLORREF & 0x10000000u) != 0)
		{
			int num = (int)(officeArtCOLORREF & 0xFF);
			if (num <= 30)
			{
				targetFormat.SystemColor = (SystemColor)num;
			}
			targetFormat.Color = Color.Black;
			smethod_5(targetFormat, (int)((officeArtCOLORREF >> 8) & 0xFF), (int)((officeArtCOLORREF >> 16) & 0xFF));
		}
		else if ((officeArtCOLORREF & 0x8000000u) != 0)
		{
			targetFormat.SchemeColor = Class232.smethod_13((int)(officeArtCOLORREF & 0xFF));
		}
		else
		{
			targetFormat.Color = Class1165.smethod_7(officeArtCOLORREF);
		}
		targetFormat.ColorTransform.Clear();
		if (alpha < 1.0)
		{
			targetFormat.ColorTransform.Add(ColorTransformOperation.SetAlpha, (float)alpha);
		}
	}

	internal static void smethod_2(IColorFormat targetFormat, Class2670 frame, Enum426 propColorIndex, Enum426 propOpacityIndex, uint defaultColorCode)
	{
		smethod_4(targetFormat, frame, null, propColorIndex, propOpacityIndex, defaultColorCode, 8);
	}

	internal static void smethod_3(ColorFormat targetFormat, Class2670 frame, Class2670 masterFrame, Enum426 propColorIndex, Enum426 propOpacityIndex, uint defaultColorCode)
	{
		smethod_4(targetFormat, frame, masterFrame, propColorIndex, propOpacityIndex, defaultColorCode, 8);
	}

	internal static void smethod_4(IColorFormat targetFormat, Class2670 frame, Class2670 masterFrame, Enum426 propColorIndex, Enum426 propOpacityIndex, uint defaultColorCode, int recursionTTL)
	{
		double alpha = (double)Class2945.smethod_10(frame, masterFrame, propOpacityIndex, 65536u) / 65536.0;
		uint num = Class2945.smethod_10(frame, masterFrame, propColorIndex, defaultColorCode);
		if ((num & 0x10000000u) != 0 && (num & 0xFF) >= 240 && (num & 0xFF) <= 247 && recursionTTL > 0)
		{
			switch (num & 0xFF)
			{
			default:
				smethod_4(targetFormat, frame, masterFrame, Enum426.const_82, propOpacityIndex, 16777215u, recursionTTL - 1);
				break;
			case 241u:
				smethod_4(targetFormat, frame, masterFrame, Enum426.const_120, propOpacityIndex, 0u, recursionTTL - 1);
				break;
			case 242u:
				smethod_4(targetFormat, frame, masterFrame, Enum426.const_120, propOpacityIndex, 0u, recursionTTL - 1);
				break;
			case 243u:
				smethod_4(targetFormat, frame, masterFrame, Enum426.const_296, propOpacityIndex, 0u, recursionTTL - 1);
				break;
			case 244u:
				targetFormat.Color = Color.Black;
				break;
			case 245u:
				smethod_4(targetFormat, frame, masterFrame, Enum426.const_84, propOpacityIndex, 16777215u, recursionTTL - 1);
				break;
			case 246u:
				smethod_4(targetFormat, frame, masterFrame, Enum426.const_122, propOpacityIndex, 16777215u, recursionTTL - 1);
				break;
			case 247u:
				if (smethod_6(frame, masterFrame))
				{
					smethod_4(targetFormat, frame, masterFrame, Enum426.const_82, propOpacityIndex, 16777215u, recursionTTL - 1);
				}
				else
				{
					smethod_4(targetFormat, frame, masterFrame, Enum426.const_120, propOpacityIndex, 0u, recursionTTL - 1);
				}
				break;
			}
			smethod_5(targetFormat, (int)((num >> 8) & 0xFF), (int)((num >> 16) & 0xFF));
		}
		else
		{
			smethod_1(targetFormat, num, alpha);
		}
	}

	private static void smethod_5(IColorFormat targetFormat, int operation, int param)
	{
		if (((uint)operation & 0x80u) != 0)
		{
			targetFormat.ColorTransform.Add(ColorTransformOperation.Grayscale);
		}
		switch (operation & 0xF)
		{
		case 1:
			targetFormat.ColorTransform.Add(ColorTransformOperation.Gamma);
			targetFormat.ColorTransform.Add(ColorTransformOperation.Shade, (float)param / 255f);
			targetFormat.ColorTransform.Add(ColorTransformOperation.InverseGamma);
			break;
		case 2:
			targetFormat.ColorTransform.Add(ColorTransformOperation.Gamma);
			targetFormat.ColorTransform.Add(ColorTransformOperation.Tint, (float)param / 255f);
			targetFormat.ColorTransform.Add(ColorTransformOperation.InverseGamma);
			break;
		case 3:
			targetFormat.ColorTransform.Add(ColorTransformOperation.AddRed, (float)param / 255f);
			targetFormat.ColorTransform.Add(ColorTransformOperation.AddGreen, (float)param / 255f);
			targetFormat.ColorTransform.Add(ColorTransformOperation.AddBlue, (float)param / 255f);
			break;
		case 4:
			targetFormat.ColorTransform.Add(ColorTransformOperation.AddRed, (float)(-param) / 255f);
			targetFormat.ColorTransform.Add(ColorTransformOperation.AddGreen, (float)(-param) / 255f);
			targetFormat.ColorTransform.Add(ColorTransformOperation.AddBlue, (float)(-param) / 255f);
			break;
		case 5:
			targetFormat.ColorTransform.Add(ColorTransformOperation.Inverse);
			targetFormat.ColorTransform.Add(ColorTransformOperation.AddRed, (float)(param - 255) / 255f);
			targetFormat.ColorTransform.Add(ColorTransformOperation.AddGreen, (float)(param - 255) / 255f);
			targetFormat.ColorTransform.Add(ColorTransformOperation.AddBlue, (float)(param - 255) / 255f);
			break;
		}
		if (((uint)operation & 0x20u) != 0)
		{
			targetFormat.ColorTransform.Add(ColorTransformOperation.Inverse);
		}
		if (((uint)operation & 0x40u) != 0)
		{
			targetFormat.ColorTransform.Add(ColorTransformOperation.Inverse);
		}
	}

	internal static bool smethod_6(Class2670 frame, Class2670 masterFrame)
	{
		uint num = 12u;
		Class2911 @class = Class2945.smethod_2(frame, Enum426.const_119) as Class2911;
		Class2911 class2 = null;
		if (masterFrame != null)
		{
			class2 = Class2945.smethod_3(masterFrame, Enum426.const_119);
		}
		if (class2 != null)
		{
			uint num2 = (class2.Value >> 16) & 0xFFFFu;
			num = ((num & ~num2) | (class2.Value & num2)) & 0xFFFFu;
		}
		if (@class != null)
		{
			uint num3 = (@class.Value >> 16) & 0xFFFFu;
			num = ((num & ~num3) | (@class.Value & num3)) & 0xFFFFu;
		}
		return (num & 0x10) != 0;
	}

	internal static uint smethod_7(IColorFormat colorFormat, Class856 serializationContext)
	{
		uint result;
		switch (colorFormat.ColorType)
		{
		case ColorType.RGBPercentage:
		{
			float r = colorFormat.FloatR;
			float g = colorFormat.FloatG;
			float b = colorFormat.FloatB;
			Class1178.smethod_1(ref r, ref g, ref b);
			result = Convert.ToUInt32((byte)(r * 100f) | ((byte)(g * 100f) << 8) | ((byte)(b * 100f) << 16));
			break;
		}
		case ColorType.HSL:
			result = Convert.ToUInt32(8355711);
			serializationContext.method_15("ColorType ColorType.HSL is not supported for saving yet", WarningType.MajorFormattingLoss);
			break;
		case ColorType.Scheme:
		{
			Class2966.Enum441 @enum = smethod_11(colorFormat.SchemeColor);
			result = ((@enum == Class2966.Enum441.const_8) ? Convert.ToUInt32(colorFormat.R | (colorFormat.G << 8) | (colorFormat.B << 16)) : Convert.ToUInt32((byte)@enum | 0x8000000));
			break;
		}
		case ColorType.System:
			result = Convert.ToUInt32((byte)colorFormat.SystemColor | 0x10000000);
			break;
		default:
			result = Convert.ToUInt32(colorFormat.R | (colorFormat.G << 8) | (colorFormat.B << 16));
			break;
		}
		return result;
	}

	internal static void smethod_8(IColorFormat colorFormat, Class2944 propertyList, Enum426 propColorIndex, Enum426 propOpacityIndex, Class856 serializationContext)
	{
		if (colorFormat == null || colorFormat.ColorType == ColorType.NotDefined)
		{
			return;
		}
		Class2911 property = new Class2911(propColorIndex, smethod_7(colorFormat, serializationContext));
		propertyList.method_0(property);
		foreach (IColorOperation item in colorFormat.ColorTransform)
		{
			ColorTransformOperation operationType = item.OperationType;
			if (operationType == ColorTransformOperation.SetAlpha)
			{
				uint value = (uint)(item.Parameter * 65536f);
				Class2911 property2 = new Class2911(propOpacityIndex, value);
				propertyList.method_0(property2);
			}
			else
			{
				serializationContext.method_15(string.Concat("ColorOperation #", item.OperationType, " is not implemented yet."), WarningType.MajorFormattingLoss);
			}
		}
	}

	internal static void smethod_9(IColorFormat targetFormat, Class2966 colorIndexStruct)
	{
		if (colorIndexStruct.Index == Class2966.Enum441.const_9)
		{
			((ColorFormat)targetFormat).Clear();
		}
		else if (colorIndexStruct.Index == Class2966.Enum441.const_8)
		{
			targetFormat.Color = colorIndexStruct.Color;
		}
		else
		{
			targetFormat.SchemeColor = Class232.smethod_13((byte)colorIndexStruct.Index);
		}
	}

	internal static Class2966 smethod_10(IColorFormat domColor)
	{
		if (domColor != null && domColor.ColorType != ColorType.NotDefined)
		{
			if (domColor.ColorType == ColorType.Scheme)
			{
				Class2966.Enum441 @enum = smethod_11(domColor.SchemeColor);
				if (@enum < Class2966.Enum441.const_8)
				{
					return new Class2966(@enum, Color.Black);
				}
				return new Class2966(Class2966.Enum441.const_8, domColor.Color);
			}
			return new Class2966(Class2966.Enum441.const_8, domColor.Color);
		}
		return new Class2966(Class2966.Enum441.const_9, Color.Empty);
	}

	internal static Class2966.Enum441 smethod_11(SchemeColor domColor)
	{
		return domColor switch
		{
			SchemeColor.Background1 => Class2966.Enum441.const_0, 
			SchemeColor.Text1 => Class2966.Enum441.const_1, 
			SchemeColor.Background2 => Class2966.Enum441.const_2, 
			SchemeColor.Text2 => Class2966.Enum441.const_3, 
			SchemeColor.Accent1 => Class2966.Enum441.const_4, 
			SchemeColor.Accent2 => Class2966.Enum441.const_5, 
			SchemeColor.Hyperlink => Class2966.Enum441.const_6, 
			SchemeColor.FollowedHyperlink => Class2966.Enum441.const_7, 
			_ => Class2966.Enum441.const_8, 
		};
	}
}
