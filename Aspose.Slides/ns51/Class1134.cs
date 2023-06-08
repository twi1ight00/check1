using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns51;

internal sealed class Class1134
{
	public float float_0;

	public float float_1;

	public float float_2;

	public float VectorLength => (float)Math.Sqrt(float_0 * float_0 + float_1 * float_1 + float_2 * float_2);

	public Class1134(float x, float y, float z)
	{
		float_0 = x;
		float_1 = y;
		float_2 = z;
	}

	public Class1134(PointF point, float z)
		: this(point.X, point.Y, z)
	{
	}

	public Class1134(Point point, float z)
		: this(point.X, point.Y, z)
	{
	}

	public Class1134(PointF point)
		: this(point.X, point.Y, 0f)
	{
	}

	public Class1134(Point point)
		: this(point.X, point.Y, 0f)
	{
	}

	[SpecialName]
	public static Class1134 smethod_0(Class1134 p1, Class1134 p2)
	{
		return new Class1134(p1.float_0 - p2.float_0, p1.float_1 - p2.float_1, p1.float_2 - p2.float_2);
	}

	[SpecialName]
	public static Class1134 smethod_1(Class1134 p1, Class1134 p2)
	{
		return new Class1134(p1.float_0 + p2.float_0, p1.float_1 + p2.float_1, p1.float_2 + p2.float_2);
	}

	public static Class1134 smethod_2(Class1134 p1, Class1134 p2)
	{
		return new Class1134(p1.float_1 * p2.float_2 - p1.float_2 * p2.float_1, p1.float_2 * p2.float_0 - p1.float_0 * p2.float_2, p1.float_0 * p2.float_1 - p1.float_1 * p2.float_0);
	}

	public static float smethod_3(Class1134 p1, Class1134 p2)
	{
		return p1.float_0 * p2.float_0 + p1.float_1 * p2.float_1 + p1.float_2 * p2.float_2;
	}

	public void method_0()
	{
		float vectorLength = VectorLength;
		if (vectorLength != 0f)
		{
			float_0 /= vectorLength;
			float_1 /= vectorLength;
			float_2 /= vectorLength;
		}
	}

	public bool Equals(Class1134 point)
	{
		if (float_0 == point.float_0 && float_1 == point.float_1)
		{
			return float_2 == point.float_2;
		}
		return false;
	}
}
