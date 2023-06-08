using System;
using System.Drawing;

namespace ns316;

internal class Class7149
{
	private float[,] float_0;

	private Bitmap bitmap_0;

	private int int_0;

	private static float[,] float_1 = new float[4, 5]
	{
		{ 0f, 0f, 0f, 0f, 0f },
		{ 0f, 0f, 0f, 0f, 0f },
		{ 0f, 0f, 0f, 0f, 0f },
		{ 0.2125f, 0.7154f, 0.0721f, 0f, 0f }
	};

	public static Class7149 smethod_0(float[][] values)
	{
		if (values != null && values.Length == 4)
		{
			float[,] array = new float[4, 5];
			int num = 0;
			while (true)
			{
				if (num < 4)
				{
					float[] array2 = values[num];
					if (array2 == null || array2.Length != 5)
					{
						break;
					}
					for (int i = 0; i < 5; i++)
					{
						array[num, i] = array2[i];
					}
					num++;
					continue;
				}
				Class7149 @class = new Class7149();
				@class.int_0 = 0;
				@class.float_0 = array;
				return @class;
			}
			return new Class7149();
		}
		return new Class7149();
	}

	public Bitmap method_0()
	{
		return bitmap_0;
	}

	public static Class7149 smethod_1()
	{
		Class7149 @class = new Class7149();
		@class.int_0 = 3;
		@class.float_0 = float_1;
		return @class;
	}

	public int method_1()
	{
		return int_0;
	}

	public float[,] method_2()
	{
		return float_0;
	}

	public static Class7149 smethod_2(float sat)
	{
		Class7149 @class = new Class7149();
		@class.int_0 = 1;
		@class.float_0 = new float[4, 5]
		{
			{
				0.213f + 0.787f * sat,
				0.715f - 0.715f * sat,
				0.072f - 0.072f * sat,
				0f,
				0f
			},
			{
				0.213f - 0.213f * sat,
				0.715f + 0.285f * sat,
				0.072f - 0.072f * sat,
				0f,
				0f
			},
			{
				0.213f - 0.213f * sat,
				0.715f - 0.715f * sat,
				0.072f + 0.928f * sat,
				0f,
				0f
			},
			{ 0f, 0f, 0f, 1f, 0f }
		};
		return @class;
	}

	public void method_3(Bitmap src)
	{
	}

	public static Class7149 smethod_3(float angle)
	{
		Class7149 @class = new Class7149();
		@class.int_0 = 2;
		float num = (float)Math.Cos(angle);
		float num2 = (float)Math.Sin(angle);
		float num3 = 0.213f + num * 0.787f - num2 * 0.213f;
		float num4 = 0.213f - num * 0.212f + num2 * 0.143f;
		float num5 = 0.213f - num * 0.213f - num2 * 0.787f;
		float num6 = 0.715f - num * 0.715f - num2 * 0.715f;
		float num7 = 0.715f + num * 0.285f + num2 * 0.14f;
		float num8 = 0.715f - num * 0.715f + num2 * 0.715f;
		float num9 = 0.072f - num * 0.072f + num2 * 0.928f;
		float num10 = 0.072f - num * 0.072f - num2 * 0.283f;
		float num11 = 0.072f + num * 0.928f + num2 * 0.072f;
		@class.float_0 = new float[4, 5]
		{
			{ num3, num6, num9, 0f, 0f },
			{ num4, num7, num10, 0f, 0f },
			{ num5, num8, num11, 0f, 0f },
			{ 0f, 0f, 0f, 1f, 0f }
		};
		return @class;
	}
}
