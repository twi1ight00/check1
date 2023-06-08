using System.Drawing;
using System.Runtime.InteropServices;

namespace ns38;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct33
{
	private static readonly float float_0 = 0.4f;

	public static Color smethod_0(Enum138 edgeColorType, Color color)
	{
		if (edgeColorType == Enum138.const_7 || edgeColorType == Enum138.const_8)
		{
			edgeColorType = smethod_1(color, edgeColorType);
		}
		float correctionFactor = 0f;
		switch (edgeColorType)
		{
		case Enum138.const_0:
			return Color.Transparent;
		case Enum138.const_1:
			return SystemColors.WindowText;
		case Enum138.const_2:
			return color;
		case Enum138.const_3:
			correctionFactor = 0f - Struct32.float_0;
			goto default;
		case Enum138.const_4:
			correctionFactor = 0f - Struct32.float_1;
			goto default;
		case Enum138.const_5:
			correctionFactor = Struct32.float_0;
			goto default;
		case Enum138.const_6:
			correctionFactor = Struct32.float_1;
			goto default;
		default:
			return Struct32.smethod_0(color, correctionFactor);
		case Enum138.const_9:
			return smethod_2(color);
		}
	}

	private static Enum138 smethod_1(Color color, Enum138 colorType)
	{
		if (color.GetBrightness() > float_0)
		{
			if (colorType == Enum138.const_7)
			{
				return Enum138.const_3;
			}
			return Enum138.const_4;
		}
		if (colorType == Enum138.const_7)
		{
			return Enum138.const_5;
		}
		return Enum138.const_6;
	}

	private static Color smethod_2(Color color)
	{
		if (color.GetBrightness() > float_0)
		{
			return Color.Black;
		}
		return Color.White;
	}
}
