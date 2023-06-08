using System;
using ns33;

namespace Aspose.Slides;

public class ColorOperation : IColorOperation
{
	private ColorTransformOperation colorTransformOperation_0;

	private float float_0;

	private static readonly float[,] float_1 = new float[28, 2]
	{
		{ 0f, 1f },
		{ 0f, 1f },
		{ 0f, 0f },
		{ 0f, 0f },
		{ 0f, 0f },
		{ 0f, 1f },
		{ -1f, 1f },
		{ 0f, 2147483f },
		{ 0f, 360f },
		{ -360f, 360f },
		{ 0f, 2147483f },
		{ 0f, 1f },
		{ -1f, 1f },
		{ 0f, 2147483f },
		{ 0f, 1f },
		{ -1f, 1f },
		{ 0f, 2147483f },
		{ 0f, 1f },
		{ -1f, 1f },
		{ 0f, 2147483f },
		{ 0f, 1f },
		{ -1f, 1f },
		{ 0f, 2147483f },
		{ 0f, 1f },
		{ -1f, 1f },
		{ 0f, 2147483f },
		{ 0f, 0f },
		{ 0f, 0f }
	};

	public ColorTransformOperation OperationType => colorTransformOperation_0;

	public float Parameter => float_0;

	private bool ParameterUsed
	{
		get
		{
			float num = 0f;
			float num2 = 0f;
			if (colorTransformOperation_0 >= ColorTransformOperation.Tint && (int)colorTransformOperation_0 < float_1.GetLength(0))
			{
				num = float_1[(int)colorTransformOperation_0, 0];
				num2 = float_1[(int)colorTransformOperation_0, 1];
			}
			return num != num2;
		}
	}

	internal bool IsAlphaOperation
	{
		get
		{
			if (colorTransformOperation_0 >= ColorTransformOperation.SetAlpha)
			{
				return colorTransformOperation_0 <= ColorTransformOperation.MultiplyAlpha;
			}
			return false;
		}
	}

	public ColorOperation(ColorTransformOperation op)
		: this(op, 0f)
	{
	}

	public ColorOperation(ColorTransformOperation op, float parameter)
	{
		colorTransformOperation_0 = op;
		float num = 0f;
		float num2 = 0f;
		if (colorTransformOperation_0 >= ColorTransformOperation.Tint && (int)colorTransformOperation_0 < float_1.GetLength(0))
		{
			num = float_1[(int)colorTransformOperation_0, 0];
			num2 = float_1[(int)colorTransformOperation_0, 1];
		}
		if (parameter < num)
		{
			parameter = num;
		}
		if (parameter > num2)
		{
			parameter = num2;
		}
		float_0 = parameter;
	}

	internal void method_0(FloatColor color)
	{
		switch (colorTransformOperation_0)
		{
		case ColorTransformOperation.Tint:
		{
			float num = 1f - float_0;
			color.float_1 = smethod_3(smethod_2(color.float_1) * float_0 + num);
			color.float_2 = smethod_3(smethod_2(color.float_2) * float_0 + num);
			color.float_3 = smethod_3(smethod_2(color.float_3) * float_0 + num);
			break;
		}
		case ColorTransformOperation.Shade:
			color.float_1 = smethod_3(smethod_2(color.float_1) * float_0);
			color.float_2 = smethod_3(smethod_2(color.float_2) * float_0);
			color.float_3 = smethod_3(smethod_2(color.float_3) * float_0);
			break;
		case ColorTransformOperation.Complement:
			smethod_0(ref color.float_1, ref color.float_2, ref color.float_3);
			break;
		case ColorTransformOperation.Inverse:
			smethod_1(ref color.float_1, ref color.float_2, ref color.float_3);
			break;
		case ColorTransformOperation.Grayscale:
			color.float_3 = (color.float_2 = (color.float_1 = (color.float_1 * 163f + color.float_2 * 547f + color.float_3 * 54f) / 765f));
			break;
		case ColorTransformOperation.SetAlpha:
			color.float_0 = float_0;
			break;
		case ColorTransformOperation.AddAlpha:
			color.float_0 = FloatColor.smethod_3(color.float_0 + float_0, 0f, 1f);
			break;
		case ColorTransformOperation.MultiplyAlpha:
			color.float_0 = FloatColor.smethod_3(color.float_0 * float_0, 0f, 1f);
			break;
		case ColorTransformOperation.SetHue:
		{
			ColorFormat.smethod_4(color.float_1, color.float_2, color.float_3, out var hue9, out var saturation9, out var luminance9);
			hue9 = float_0;
			color.method_0(hue9, saturation9, luminance9);
			break;
		}
		case ColorTransformOperation.AddHue:
		{
			ColorFormat.smethod_4(color.float_1, color.float_2, color.float_3, out var hue8, out var saturation8, out var luminance8);
			hue8 += float_0;
			hue8 %= 360f;
			if (hue8 < 0f)
			{
				hue8 += 360f;
			}
			color.method_0(hue8, saturation8, luminance8);
			break;
		}
		case ColorTransformOperation.MultiplyHue:
		{
			ColorFormat.smethod_4(color.float_1, color.float_2, color.float_3, out var hue7, out var saturation7, out var luminance7);
			hue7 *= float_0;
			hue7 %= 360f;
			if (hue7 < 0f)
			{
				hue7 += 360f;
			}
			color.method_0(hue7, saturation7, luminance7);
			break;
		}
		case ColorTransformOperation.SetSaturation:
		{
			ColorFormat.smethod_4(color.float_1, color.float_2, color.float_3, out var hue6, out var saturation6, out var luminance6);
			saturation6 = float_0;
			color.method_0(hue6, saturation6, luminance6);
			break;
		}
		case ColorTransformOperation.AddSaturation:
		{
			ColorFormat.smethod_4(color.float_1, color.float_2, color.float_3, out var hue5, out var saturation5, out var luminance5);
			saturation5 += float_0;
			color.method_0(hue5, saturation5, luminance5);
			break;
		}
		case ColorTransformOperation.MultiplySaturation:
		{
			ColorFormat.smethod_4(color.float_1, color.float_2, color.float_3, out var hue4, out var saturation4, out var luminance4);
			saturation4 *= float_0;
			color.method_0(hue4, saturation4, luminance4);
			break;
		}
		case ColorTransformOperation.SetLuminance:
		{
			ColorFormat.smethod_4(color.float_1, color.float_2, color.float_3, out var hue3, out var saturation3, out var luminance3);
			luminance3 = float_0;
			color.method_0(hue3, saturation3, luminance3);
			break;
		}
		case ColorTransformOperation.AddLuminance:
		{
			ColorFormat.smethod_4(color.float_1, color.float_2, color.float_3, out var hue2, out var saturation2, out var luminance2);
			luminance2 += float_0;
			color.method_0(hue2, saturation2, luminance2);
			break;
		}
		case ColorTransformOperation.MultiplyLuminance:
		{
			ColorFormat.smethod_4(color.float_1, color.float_2, color.float_3, out var hue, out var saturation, out var luminance);
			luminance *= float_0;
			color.method_0(hue, saturation, luminance);
			break;
		}
		case ColorTransformOperation.SetRed:
			color.float_1 = float_0;
			break;
		case ColorTransformOperation.AddRed:
			color.float_1 = FloatColor.smethod_3(color.float_1 + float_0, 0f, 1f);
			break;
		case ColorTransformOperation.MultiplyRed:
			color.float_1 = FloatColor.smethod_3(color.float_1 * float_0, 0f, 1f);
			break;
		case ColorTransformOperation.SetGreen:
			color.float_2 = float_0;
			break;
		case ColorTransformOperation.AddGreen:
			color.float_2 = FloatColor.smethod_3(color.float_2 + float_0, 0f, 1f);
			break;
		case ColorTransformOperation.MultiplyGreen:
			color.float_2 = FloatColor.smethod_3(color.float_2 * float_0, 0f, 1f);
			break;
		case ColorTransformOperation.SetBlue:
			color.float_3 = float_0;
			break;
		case ColorTransformOperation.AddBlue:
			color.float_3 = FloatColor.smethod_3(color.float_3 + float_0, 0f, 1f);
			break;
		case ColorTransformOperation.MultiplyBlue:
			color.float_3 = FloatColor.smethod_3(color.float_3 * float_0, 0f, 1f);
			break;
		case ColorTransformOperation.Gamma:
			Class1178.smethod_0(ref color.float_1, ref color.float_2, ref color.float_3);
			break;
		case ColorTransformOperation.InverseGamma:
			Class1178.smethod_1(ref color.float_1, ref color.float_2, ref color.float_3);
			break;
		}
	}

	internal static void smethod_0(ref float r, ref float g, ref float b)
	{
		float num = Math.Max(r, Math.Max(g, b));
		r = num - r;
		g = num - g;
		b = num - b;
	}

	internal static void smethod_1(ref float r, ref float g, ref float b)
	{
		r = 1f - r;
		g = 1f - g;
		b = 1f - b;
	}

	internal static float smethod_2(float component)
	{
		if (component <= 0.04045f)
		{
			return component / 12.92f;
		}
		return (float)Math.Pow(((double)component + 0.055) / 1.055, 2.4);
	}

	internal static float smethod_3(float component)
	{
		if ((double)component <= 0.0031308)
		{
			return component / 12.92f;
		}
		return (float)(Math.Pow(component, 5.0 / 12.0) * 1.055 - 0.055);
	}

	public override bool Equals(object obj)
	{
		if (!(obj is ColorOperation colorOperation))
		{
			return base.Equals(obj);
		}
		if (OperationType == colorOperation.OperationType && (!ParameterUsed || Parameter == colorOperation.Parameter))
		{
			return true;
		}
		return false;
	}

	public override int GetHashCode()
	{
		throw new NotImplementedException();
	}
}
