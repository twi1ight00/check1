using System;
using System.Drawing;

namespace Aspose.Slides;

internal class FloatColor : IFillParamSource
{
	public float float_0 = 1f;

	public float float_1;

	public float float_2;

	public float float_3;

	public static readonly FloatColor floatColor_0 = new FloatColor(0f, 0f, 0f);

	public static readonly FloatColor floatColor_1 = new FloatColor(1f, 1f, 1f);

	public Color Color
	{
		get
		{
			if (!float.IsNaN(float_1) && !float.IsNaN(float_2) && !float.IsNaN(float_3) && !float.IsNaN(float_0))
			{
				return Color.FromArgb((int)Math.Round(smethod_1(float_0) * 255f), (int)Math.Round(smethod_1(float_1) * 255f), (int)Math.Round(smethod_1(float_2) * 255f), (int)Math.Round(smethod_1(float_3) * 255f));
			}
			return Color.Empty;
		}
	}

	public FloatColor(float r, float g, float b)
	{
		float_1 = r;
		float_2 = g;
		float_3 = b;
	}

	public FloatColor(float a, float r, float g, float b)
	{
		float_0 = a;
		float_1 = r;
		float_2 = g;
		float_3 = b;
	}

	public FloatColor(FloatColor color)
	{
		if (color != null)
		{
			float_0 = color.float_0;
			float_1 = color.float_1;
			float_2 = color.float_2;
			float_3 = color.float_3;
		}
		else
		{
			float num = 0f;
			float_3 = 0f;
			float num2 = 0f;
			float_2 = num;
			float_1 = num2;
			float_0 = 1f;
		}
	}

	public FloatColor(Color c)
	{
		if (!c.IsEmpty)
		{
			float_0 = (float)(int)c.A / 255f;
			float_1 = (float)(int)c.R / 255f;
			float_2 = (float)(int)c.G / 255f;
			float_3 = (float)(int)c.B / 255f;
		}
		else
		{
			float num = 0f;
			float_3 = 0f;
			float num2 = 0f;
			float_2 = num;
			float_1 = num2;
			float_0 = 1f;
		}
	}

	public void method_0(float hue, float saturation, float luminance)
	{
		if ((double)saturation < 0.0001)
		{
			float_1 = (float_2 = (float_3 = luminance));
			return;
		}
		float num = (((double)luminance < 0.5) ? (luminance * (1f + saturation)) : (luminance * (1f - saturation) + saturation));
		float p = 2f * luminance - num;
		float_1 = smethod_3(smethod_2(p, num, hue + 120f), 0f, 1f);
		float_2 = smethod_3(smethod_2(p, num, hue), 0f, 1f);
		float_3 = smethod_3(smethod_2(p, num, hue - 120f), 0f, 1f);
	}

	public static FloatColor smethod_0(float hue, float saturation, float luminance)
	{
		FloatColor floatColor = new FloatColor(0f, 0f, 0f);
		floatColor.method_0(hue, saturation, luminance);
		return floatColor;
	}

	public bool Equals(FloatColor fc)
	{
		if (fc != null && float_0 == fc.float_0 && float_1 == fc.float_1 && float_2 == fc.float_2)
		{
			return float_3 == fc.float_3;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj != null && !(GetType() != obj.GetType()))
		{
			return Equals((FloatColor)obj);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return float_0.GetHashCode() ^ float_1.GetHashCode() ^ float_2.GetHashCode() ^ float_3.GetHashCode();
	}

	private static float smethod_1(float value)
	{
		if (value < 0f)
		{
			return 0f;
		}
		if (value > 1f)
		{
			return 1f;
		}
		return value;
	}

	private static float smethod_2(float p, float q, float t)
	{
		if (t < 0f)
		{
			t += 360f;
		}
		if (t >= 360f)
		{
			t -= 360f;
		}
		if (t < 180f)
		{
			if (t < 60f)
			{
				return p + (q - p) * t / 60f;
			}
			return q;
		}
		if (t < 240f)
		{
			return p + (q - p) * (240f - t) / 60f;
		}
		return p;
	}

	public static float smethod_3(float value, float min, float max)
	{
		if (value < min)
		{
			value = min;
		}
		if (value > max)
		{
			value = max;
		}
		return value;
	}
}
