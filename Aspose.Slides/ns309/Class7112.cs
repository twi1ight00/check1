using System.Drawing;

namespace ns309;

internal class Class7112
{
	internal bool bool_0;

	internal float float_0;

	internal float float_1;

	internal RectangleF rectangleF_0;

	internal byte byte_0;

	public static byte byte_1 = 0;

	public static byte byte_2 = 1;

	public static byte byte_3 = 2;

	public static byte byte_4 = 3;

	public static byte byte_5 = 4;

	public Class7112(float advance, RectangleF bounds, byte glyphType)
	{
		rectangleF_0 = default(RectangleF);
		rectangleF_0 = bounds;
		float_1 = 0f;
		bool_0 = true;
		float_0 = advance;
		byte_0 = glyphType;
	}

	public Class7112(bool horizontal, float levelX, float levelY, RectangleF bounds, byte glyphType)
	{
		rectangleF_0 = default(RectangleF);
		rectangleF_0 = bounds;
		float_0 = levelX;
		float_1 = levelY;
		byte_0 = glyphType;
		bool_0 = horizontal;
	}

	public float method_0()
	{
		if (bool_0)
		{
			return float_0 - rectangleF_0.X - rectangleF_0.Width;
		}
		return float_1 - rectangleF_0.Y - rectangleF_0.Height;
	}

	public int method_1()
	{
		return byte_0;
	}

	public bool method_2()
	{
		return (byte_0 & 3) == byte_1;
	}

	public bool method_3()
	{
		return (byte_0 & 3) == byte_2;
	}

	public bool method_4()
	{
		return (byte_0 & 3) == byte_3;
	}

	public bool method_5()
	{
		return (byte_0 & 3) == byte_4;
	}

	public bool method_6()
	{
		return (byte_0 & 4) == byte_5;
	}

	public float GetLevel()
	{
		if (bool_0)
		{
			return float_0;
		}
		return float_1;
	}

	public float method_7()
	{
		return float_0;
	}

	public float method_8()
	{
		return float_1;
	}

	public RectangleF method_9()
	{
		return new RectangleF(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height);
	}

	public float method_10()
	{
		if (bool_0)
		{
			return rectangleF_0.X;
		}
		return rectangleF_0.Y;
	}
}
