using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns224;

namespace ns33;

internal sealed class Class1156 : ICloneable
{
	private float[,] float_0 = new float[3, 3]
	{
		{ 1f, 0f, 0f },
		{ 0f, 1f, 0f },
		{ 0f, 0f, 1f }
	};

	public float[,] Elements => float_0;

	public bool IsInvertible => (double)Math.Abs(method_6()) > 0.0001;

	public bool TransformableToMatrix
	{
		get
		{
			if (float_0[0, 2] == 0f)
			{
				return float_0[1, 2] == 0f;
			}
			return false;
		}
	}

	public Class1156()
	{
	}

	public Class1156(Class6002 matrix)
	{
		float_0[0, 0] = matrix.M11;
		float_0[0, 1] = matrix.M12;
		float_0[1, 0] = matrix.M21;
		float_0[1, 1] = matrix.M22;
		float_0[2, 0] = matrix.M31;
		float_0[2, 1] = matrix.M32;
	}

	public Class1156(Class1156 transform)
	{
		if (transform == null)
		{
			return;
		}
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				float_0[i, j] = transform.float_0[i, j];
			}
		}
	}

	public void method_0(Class1156 transform, MatrixOrder order)
	{
		float[,] array = new float[3, 3];
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
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				array[i, j] = array2[i, 0] * array3[0, j] + array2[i, 1] * array3[1, j] + array2[i, 2] * array3[2, j];
			}
		}
		float_0 = array;
	}

	public void method_1(Class1156 transform)
	{
		method_0(transform, MatrixOrder.Prepend);
	}

	public void method_2(Class6002 matrix, MatrixOrder order)
	{
		method_0(new Class1156(matrix), order);
	}

	public void method_3(Class6002 matrix)
	{
		method_0(new Class1156(matrix), MatrixOrder.Prepend);
	}

	public void method_4(PointF[] points)
	{
		for (int i = 0; i < points.Length; i++)
		{
			PointF pointF = points[i];
			float num = pointF.X * float_0[0, 0] + pointF.Y * float_0[1, 0] + float_0[2, 0];
			float num2 = pointF.X * float_0[0, 1] + pointF.Y * float_0[1, 1] + float_0[2, 1];
			float num3 = pointF.X * float_0[0, 2] + pointF.Y * float_0[1, 2] + float_0[2, 2];
			points[i].X = num / num3;
			points[i].Y = num2 / num3;
		}
	}

	public void method_5(Point[] points)
	{
		for (int i = 0; i < points.Length; i++)
		{
			Point point = points[i];
			float num = (float)point.X * float_0[0, 0] + (float)point.Y * float_0[1, 0] + float_0[2, 0];
			float num2 = (float)point.X * float_0[0, 1] + (float)point.Y * float_0[1, 1] + float_0[2, 1];
			float num3 = (float)point.X * float_0[0, 2] + (float)point.Y * float_0[1, 2] + float_0[2, 2];
			points[i].X = (int)(num / num3 + 0.5f);
			points[i].Y = (int)(num2 / num3 + 0.5f);
		}
	}

	private float method_6()
	{
		return float_0[0, 0] * float_0[1, 1] * float_0[2, 2] + float_0[0, 1] * float_0[1, 2] * float_0[2, 0] + float_0[1, 0] * float_0[2, 1] * float_0[0, 2] - float_0[2, 0] * float_0[1, 1] * float_0[0, 2] - float_0[1, 0] * float_0[0, 1] * float_0[2, 2] - float_0[0, 0] * float_0[2, 1] * float_0[1, 2];
	}

	public void method_7()
	{
		float num = method_6();
		if (!((double)Math.Abs(num) < 0.0001))
		{
			float num2 = float_0[0, 1];
			float_0[0, 1] = float_0[1, 0] / num;
			float_0[1, 0] = num2 / num;
			num2 = float_0[0, 2];
			float_0[0, 2] = float_0[2, 0] / num;
			float_0[2, 0] = num2 / num;
			num2 = float_0[1, 2];
			float_0[1, 2] = float_0[2, 1] / num;
			float_0[2, 1] = num2 / num;
			float_0[0, 0] /= num;
			float_0[1, 1] /= num;
			float_0[2, 2] /= num;
		}
	}

	public void method_8()
	{
		float_0 = new float[3, 3]
		{
			{ 1f, 0f, 0f },
			{ 0f, 1f, 0f },
			{ 0f, 0f, 1f }
		};
	}

	public Matrix method_9()
	{
		return new Matrix(float_0[0, 0], float_0[1, 0], float_0[0, 1], float_0[1, 1], float_0[2, 0], float_0[2, 1]);
	}

	public object Clone()
	{
		return new Class1156(this);
	}
}
