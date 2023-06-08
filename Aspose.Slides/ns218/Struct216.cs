using System;
using ns224;

namespace ns218;

internal struct Struct216
{
	private float float_0;

	private float float_1;

	private float float_2;

	private int int_0;

	public float H => float_0;

	public float S => float_1;

	public float B
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	public int A => int_0;

	public Class5998 Color => smethod_3(this);

	public Struct216(float h, float s, float b)
		: this(255, h, s, b)
	{
	}

	public Struct216(int a, float h, float s, float b)
	{
		int_0 = a;
		float_0 = Math.Min(Math.Max(h, 0f), 255f);
		float_1 = Math.Min(Math.Max(s, 0f), 255f);
		float_2 = Math.Min(Math.Max(b, 0f), 255f);
	}

	public Struct216(Class5998 color)
	{
		Struct216 @struct = smethod_4(color);
		int_0 = @struct.int_0;
		float_0 = @struct.float_0;
		float_1 = @struct.float_1;
		float_2 = @struct.float_2;
	}

	public static Class5998 smethod_0(Class5998 c, float hueDelta)
	{
		Struct216 hsbColor = smethod_4(c);
		hsbColor.float_0 += hueDelta;
		hsbColor.float_0 = Math.Min(Math.Max(hsbColor.float_0, 0f), 255f);
		return smethod_3(hsbColor);
	}

	public static Class5998 smethod_1(Class5998 c, float saturationDelta)
	{
		Struct216 hsbColor = smethod_4(c);
		hsbColor.float_1 += saturationDelta;
		hsbColor.float_1 = Math.Min(Math.Max(hsbColor.float_1, 0f), 255f);
		return smethod_3(hsbColor);
	}

	public static Class5998 smethod_2(Class5998 c, float brightnessDelta)
	{
		Struct216 hsbColor = smethod_4(c);
		hsbColor.float_2 += brightnessDelta;
		hsbColor.float_2 = Math.Min(Math.Max(hsbColor.float_2, 0f), 255f);
		return smethod_3(hsbColor);
	}

	public static Class5998 smethod_3(Struct216 hsbColor)
	{
		float val = hsbColor.float_2;
		float val2 = hsbColor.float_2;
		float val3 = hsbColor.float_2;
		if (hsbColor.float_1 != 0f)
		{
			float num = hsbColor.float_2;
			float num2 = hsbColor.float_2 * hsbColor.float_1 / 255f;
			float num3 = hsbColor.float_2 - num2;
			float num4 = hsbColor.float_0 * 360f / 255f;
			if (num4 < 60f)
			{
				val = num;
				val2 = num4 * num2 / 60f + num3;
				val3 = num3;
			}
			else if (num4 < 120f)
			{
				val = (0f - (num4 - 120f)) * num2 / 60f + num3;
				val2 = num;
				val3 = num3;
			}
			else if (num4 < 180f)
			{
				val = num3;
				val2 = num;
				val3 = (num4 - 120f) * num2 / 60f + num3;
			}
			else if (num4 < 240f)
			{
				val = num3;
				val2 = (0f - (num4 - 240f)) * num2 / 60f + num3;
				val3 = num;
			}
			else if (num4 < 300f)
			{
				val = (num4 - 240f) * num2 / 60f + num3;
				val2 = num3;
				val3 = num;
			}
			else if (num4 <= 360f)
			{
				val = num;
				val2 = num3;
				val3 = (0f - (num4 - 360f)) * num2 / 60f + num3;
			}
			else
			{
				val = 0f;
				val2 = 0f;
				val3 = 0f;
			}
		}
		return new Class5998(hsbColor.int_0, Class5964.smethod_29(Math.Min(Math.Max(val, 0f), 255f)), Class5964.smethod_29(Math.Min(Math.Max(val2, 0f), 255f)), Class5964.smethod_29(Math.Min(Math.Max(val3, 0f), 255f)));
	}

	public static Struct216 smethod_4(Class5998 color)
	{
		Struct216 result = new Struct216(0f, 0f, 0f);
		result.int_0 = color.A;
		float num = color.R;
		float num2 = color.G;
		float num3 = color.B;
		float num4 = Math.Max(num, Math.Max(num2, num3));
		if (num4 <= 0f)
		{
			return result;
		}
		float num5 = Math.Min(num, Math.Min(num2, num3));
		float num6 = num4 - num5;
		if (num4 > num5)
		{
			if (num2 == num4)
			{
				result.float_0 = (num3 - num) / num6 * 60f + 120f;
			}
			else if (num3 == num4)
			{
				result.float_0 = (num - num2) / num6 * 60f + 240f;
			}
			else if (num3 > num2)
			{
				result.float_0 = (num2 - num3) / num6 * 60f + 360f;
			}
			else
			{
				result.float_0 = (num2 - num3) / num6 * 60f;
			}
			if (result.float_0 < 0f)
			{
				result.float_0 += 360f;
			}
		}
		else
		{
			result.float_0 = 0f;
		}
		result.float_0 *= 17f / 24f;
		result.float_1 = num6 / num4 * 255f;
		result.float_2 = num4;
		return result;
	}
}
