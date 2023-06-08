using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ns316;

internal class Class7140 : Class7138
{
	private double double_0;

	private double double_1;

	private Class7138 class7138_0;

	private Rectangle rectangle_0;

	private float[] float_1;

	public Class7140(object source, Rectangle litRegion, Interface382 light, double diffuseConstant, double surfaceScale, double[] length)
	{
		method_11(diffuseConstant);
		method_8(surfaceScale);
		method_4(litRegion);
		method_13(length);
	}

	public object method_0()
	{
		return new object();
	}

	public void method_1(object src)
	{
	}

	public Rectangle method_2()
	{
		return rectangle_0;
	}

	public Rectangle method_3()
	{
		return method_2();
	}

	public void method_4(Rectangle litRegion)
	{
		rectangle_0 = litRegion;
	}

	public Class7138 method_5()
	{
		return class7138_0;
	}

	public void method_6(Class7138 light)
	{
		class7138_0 = light;
	}

	public double method_7()
	{
		return double_0;
	}

	public void method_8(double surfaceScale)
	{
		double_0 = surfaceScale;
	}

	public Image method_9()
	{
		RectangleF rectangleF = method_2();
		RectangleF.Intersect(rectangleF, method_2());
		Matrix matrix = new Matrix();
		RectangleF rectangleF2 = rectangleF;
		Image result = new Bitmap(rectangle_0.Width, rectangle_0.Height);
		if (rectangleF2.Width != 0f && rectangleF2.Height != 0f)
		{
			_ = matrix.OffsetX;
			_ = matrix.OffsetY;
			double num = Math.Sqrt(2.0);
			double num2 = Math.Sqrt(2.0);
			if (num != 0.0 && num2 != 0.0)
			{
				if (float_1 != null)
				{
					if (float_1[0] > 0f && num > (double)(1f / float_1[0]))
					{
						num = 1f / float_1[0];
					}
					if (float_1[1] > 0f && num2 > (double)(1f / float_1[1]))
					{
						num2 = 1f / float_1[1];
					}
				}
				Matrix matrix2 = new Matrix();
				matrix2.Scale((float)num, (float)num2);
				PointF[] array = new PointF[2]
				{
					new PointF(rectangleF2.X, rectangleF2.Y),
					new PointF(rectangleF2.X + rectangleF2.Width, rectangleF2.Y + rectangleF2.Height)
				};
				matrix2.TransformPoints(array);
				rectangleF2.X = array[0].X;
				rectangleF2.Y = array[0].Y;
				rectangleF2.Width = rectangleF2.X + array[1].X;
				rectangleF2.Height = rectangleF2.Y + array[1].Y;
				rectangleF.X = (float)((double)rectangleF.X - 2.0 / num);
				rectangleF.Y = (float)((double)rectangleF.Y - 2.0 / num2);
				rectangleF.Width = (float)((double)rectangleF.Width + 4.0 / num);
				rectangleF.Height = (float)((double)rectangleF.Height + 4.0 / num2);
				return result;
			}
			return null;
		}
		return null;
	}

	public double method_10()
	{
		return double_1;
	}

	public void method_11(double constant)
	{
		double_1 = constant;
	}

	public double[] method_12()
	{
		if (float_1 == null)
		{
			return null;
		}
		return new double[2]
		{
			float_1[0],
			float_1[1]
		};
	}

	public void method_13(double[] length)
	{
		if (length == null)
		{
			float_1 = null;
			return;
		}
		if (float_1 == null)
		{
			float_1 = new float[2];
		}
		float_1[0] = (float)length[0];
		float_1[1] = (float)length[1];
	}
}
