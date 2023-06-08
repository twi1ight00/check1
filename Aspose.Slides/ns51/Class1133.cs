using System;
using System.Drawing.Drawing2D;
using ns224;

namespace ns51;

internal class Class1133
{
	private float[,] float_0;

	public Class1133(float m11, float m12, float m13, float m14, float m21, float m22, float m23, float m24, float m31, float m32, float m33, float m34, float m41, float m42, float m43, float m44)
	{
		float_0 = new float[4, 4]
		{
			{ m11, m12, m13, m14 },
			{ m21, m22, m23, m24 },
			{ m31, m32, m33, m34 },
			{ m41, m42, m43, m44 }
		};
	}

	public Class1133()
	{
		float_0 = new float[4, 4]
		{
			{ 1f, 0f, 0f, 0f },
			{ 0f, 1f, 0f, 0f },
			{ 0f, 0f, 1f, 0f },
			{ 0f, 0f, 0f, 1f }
		};
	}

	public Class1133(Class1133 transform)
	{
		float_0 = new float[4, 4];
		if (transform == null)
		{
			return;
		}
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				float_0[i, j] = transform.float_0[i, j];
			}
		}
	}

	public Class1133(Class6002 matrix)
		: this()
	{
		float_0[0, 0] = matrix.M11;
		float_0[0, 1] = matrix.M12;
		float_0[1, 0] = matrix.M21;
		float_0[1, 1] = matrix.M22;
		float_0[3, 0] = matrix.M31;
		float_0[3, 1] = matrix.M32;
	}

	public void method_0(Class1133 transform, MatrixOrder order)
	{
		float[,] array = new float[4, 4];
		float[,] array2;
		float[,] array3;
		if (order == MatrixOrder.Append)
		{
			array2 = float_0;
			array3 = transform.float_0;
		}
		else
		{
			array2 = transform.float_0;
			array3 = float_0;
		}
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				array[i, j] = array2[i, 0] * array3[0, j] + array2[i, 1] * array3[1, j] + array2[i, 2] * array3[2, j] + array2[i, 3] * array3[3, j];
			}
		}
		float_0 = array;
	}

	public void method_1(Class1133 transform)
	{
		method_0(transform, MatrixOrder.Prepend);
	}

	public void method_2(Class1134[] points)
	{
		for (int i = 0; i < points.Length; i++)
		{
			Class1134 @class = points[i];
			float num = @class.float_0 * float_0[0, 0] + @class.float_1 * float_0[1, 0] + @class.float_2 * float_0[2, 0] + float_0[3, 0];
			float num2 = @class.float_0 * float_0[0, 1] + @class.float_1 * float_0[1, 1] + @class.float_2 * float_0[2, 1] + float_0[3, 1];
			float num3 = @class.float_0 * float_0[0, 2] + @class.float_1 * float_0[1, 2] + @class.float_2 * float_0[2, 2] + float_0[3, 2];
			float num4 = @class.float_0 * float_0[0, 3] + @class.float_1 * float_0[1, 3] + @class.float_2 * float_0[2, 3] + float_0[3, 3];
			points[i].float_0 = num / num4;
			points[i].float_1 = num2 / num4;
			points[i].float_2 = num3 / num4;
		}
	}

	public void method_3(Class1134[] points)
	{
		for (int i = 0; i < points.Length; i++)
		{
			Class1134 @class = points[i];
			float num = @class.float_0 * float_0[0, 0] + @class.float_1 * float_0[1, 0] + @class.float_2 * float_0[2, 0];
			float num2 = @class.float_0 * float_0[0, 1] + @class.float_1 * float_0[1, 1] + @class.float_2 * float_0[2, 1];
			float num3 = @class.float_0 * float_0[0, 2] + @class.float_1 * float_0[1, 2] + @class.float_2 * float_0[2, 2];
			float num4 = @class.float_0 * float_0[0, 3] + @class.float_1 * float_0[1, 3] + @class.float_2 * float_0[2, 3] + float_0[3, 3];
			points[i].float_0 = num / num4;
			points[i].float_1 = num2 / num4;
			points[i].float_2 = num3 / num4;
		}
	}

	public static Class1133 smethod_0(float x, float y, float z)
	{
		return new Class1133(1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 1f, 0f, x, y, z, 1f);
	}

	public static Class1133 smethod_1(float scaleX, float scaleY, float scaleZ)
	{
		return new Class1133(scaleX, 0f, 0f, 0f, 0f, scaleY, 0f, 0f, 0f, 0f, scaleZ, 0f, 0f, 0f, 0f, 1f);
	}

	public static Class1133 smethod_2(float angle)
	{
		float num = (float)Math.Sin((double)(angle / 180f) * Math.PI);
		float num2 = (float)Math.Cos((double)(angle / 180f) * Math.PI);
		return new Class1133(1f, 0f, 0f, 0f, 0f, num2, num, 0f, 0f, 0f - num, num2, 0f, 0f, 0f, 0f, 1f);
	}

	public static Class1133 smethod_3(float angle)
	{
		float num = (float)Math.Sin((double)(angle / 180f) * Math.PI);
		float num2 = (float)Math.Cos((double)(angle / 180f) * Math.PI);
		return new Class1133(num2, 0f, 0f - num, 0f, 0f, 1f, 0f, 0f, num, 0f, num2, 0f, 0f, 0f, 0f, 1f);
	}

	public static Class1133 smethod_4(float angle)
	{
		float num = (float)Math.Sin((double)(angle / 180f) * Math.PI);
		float num2 = (float)Math.Cos((double)(angle / 180f) * Math.PI);
		return new Class1133(num2, num, 0f, 0f, 0f - num, num2, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 1f);
	}

	public static Class1133 smethod_5(float coef)
	{
		return new Class1133(1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 1f, coef, 0f, 0f, 0f, 1f);
	}

	public static Class1133 smethod_6(float xCoef, float yCoef, float zCoef)
	{
		return new Class1133(1f, 0f, 0f, xCoef, 0f, 1f, 0f, yCoef, 0f, 0f, 1f, zCoef, 0f, 0f, 0f, 1f);
	}
}
