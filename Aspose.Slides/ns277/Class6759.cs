using System;
using System.Collections;
using System.Drawing;
using ns284;
using ns290;

namespace ns277;

internal abstract class Class6759
{
	public abstract void vmethod_0(Class6844 box, PointF boxLocation, bool boxType, ref Hashtable pageSet);

	public abstract void vmethod_1(Class6855 box, PointF pos, Interface356 link, bool boxType, ref Hashtable pageSet);

	public abstract void vmethod_2(string imageFileName, float x, float y, float width, float height, bool boxType, ref Hashtable pageSet);

	public abstract void vmethod_3();

	public abstract object vmethod_4();

	protected static Color smethod_0(Color color)
	{
		return smethod_4(color, Color.White, 0.8f);
	}

	protected static Color smethod_1(Color color)
	{
		return smethod_4(color, Color.Black, 0.5f);
	}

	protected static Color smethod_2(Color borderColor, Interface329 style, Enum934 side, string boxType)
	{
		Color result = (borderColor.IsEmpty ? style.Color : borderColor);
		if (boxType == "table")
		{
			switch (side)
			{
			default:
				throw new ArgumentOutOfRangeException("side");
			case Enum934.const_0:
				if (style.BorderTableStyleLeft == Enum951.const_8 || style.BorderTableStyleLeft == Enum951.const_6)
				{
					result = smethod_0(borderColor);
				}
				if (style.BorderTableStyleLeft == Enum951.const_7 || style.BorderTableStyleLeft == Enum951.const_5)
				{
					result = smethod_1(borderColor);
				}
				break;
			case Enum934.const_1:
				if (style.BorderTableStyleTop == Enum951.const_8 || style.BorderTableStyleTop == Enum951.const_6)
				{
					result = smethod_0(borderColor);
				}
				if (style.BorderTableStyleTop == Enum951.const_7 || style.BorderTableStyleTop == Enum951.const_5)
				{
					result = smethod_1(borderColor);
				}
				break;
			case Enum934.const_2:
				if (style.BorderTableStyleRight == Enum951.const_7 || style.BorderTableStyleRight == Enum951.const_5)
				{
					result = smethod_0(borderColor);
				}
				if (style.BorderTableStyleRight == Enum951.const_8 || style.BorderTableStyleRight == Enum951.const_6)
				{
					result = smethod_1(borderColor);
				}
				break;
			case Enum934.const_3:
				if (style.BorderTableStyleBottom == Enum951.const_7 || style.BorderTableStyleBottom == Enum951.const_5)
				{
					result = smethod_0(borderColor);
				}
				if (style.BorderTableStyleBottom == Enum951.const_8 || style.BorderTableStyleBottom == Enum951.const_6)
				{
					result = smethod_1(borderColor);
				}
				break;
			}
		}
		else
		{
			switch (side)
			{
			default:
				throw new ArgumentOutOfRangeException("side");
			case Enum934.const_0:
				if (style.BorderStyleLeft == Enum951.const_8 || style.BorderStyleLeft == Enum951.const_6)
				{
					result = smethod_0(borderColor);
				}
				if (style.BorderStyleLeft == Enum951.const_7 || style.BorderStyleLeft == Enum951.const_5)
				{
					result = smethod_1(borderColor);
				}
				break;
			case Enum934.const_1:
				if (style.BorderStyleTop == Enum951.const_8 || style.BorderStyleTop == Enum951.const_6)
				{
					result = smethod_0(borderColor);
				}
				if (style.BorderStyleTop == Enum951.const_7 || style.BorderStyleTop == Enum951.const_5)
				{
					result = smethod_1(borderColor);
				}
				break;
			case Enum934.const_2:
				if (style.BorderStyleRight == Enum951.const_7 || style.BorderStyleRight == Enum951.const_5)
				{
					result = smethod_0(borderColor);
				}
				if (style.BorderStyleRight == Enum951.const_8 || style.BorderStyleRight == Enum951.const_6)
				{
					result = smethod_1(borderColor);
				}
				break;
			case Enum934.const_3:
				if (style.BorderStyleBottom == Enum951.const_7 || style.BorderStyleBottom == Enum951.const_5)
				{
					result = smethod_0(borderColor);
				}
				if (style.BorderStyleBottom == Enum951.const_8 || style.BorderStyleBottom == Enum951.const_6)
				{
					result = smethod_1(borderColor);
				}
				break;
			}
		}
		return result;
	}

	private static float smethod_3(float start, float end, float amount)
	{
		float num = end - start;
		float num2 = num * amount;
		return start + num2;
	}

	private static Color smethod_4(Color color, Color destColor, float amount)
	{
		float start = (int)color.R;
		float start2 = (int)color.G;
		float start3 = (int)color.B;
		float end = (int)destColor.R;
		float end2 = (int)destColor.G;
		float end3 = (int)destColor.B;
		byte red = (byte)smethod_3(start, end, amount);
		byte green = (byte)smethod_3(start2, end2, amount);
		byte blue = (byte)smethod_3(start3, end3, amount);
		return Color.FromArgb(red, green, blue);
	}
}
