using System;
using System.Drawing;

namespace ns18;

internal class Class1415
{
	private readonly Class1416 class1416_0;

	private float float_0 = float.MaxValue;

	private float float_1 = float.MaxValue;

	private float float_2 = float.MinValue;

	private float float_3 = float.MinValue;

	internal RectangleF Value => RectangleF.FromLTRB(float_0, float_1, float_2, float_3);

	internal Class1415(Class1416 class1416_1)
	{
		class1416_0 = class1416_1;
	}

	internal void method_0(PointF pointF_0, float float_4)
	{
		PointF[] array = new PointF[1] { pointF_0 };
		class1416_0.method_5().method_29().TransformPoints(array);
		pointF_0 = array[0];
		method_4(pointF_0, float_4);
	}

	internal void method_1(PointF[] pointF_0, float float_4)
	{
		class1416_0.method_5().method_29().TransformPoints(pointF_0);
		for (int i = 0; i < pointF_0.Length; i++)
		{
			method_4(pointF_0[i], float_4);
		}
	}

	internal void method_2(PointF[][] pointF_0, float float_4)
	{
		for (int i = 0; i < pointF_0.Length; i++)
		{
			method_1(pointF_0[i], float_4);
		}
	}

	internal void method_3(PointF[] pointF_0, float float_4)
	{
		for (int i = 0; i < pointF_0.Length; i++)
		{
			method_4(pointF_0[i], float_4);
		}
	}

	private void method_4(PointF pointF_0, float float_4)
	{
		float_0 = Math.Min(float_0, pointF_0.X - float_4);
		float_1 = Math.Min(float_1, pointF_0.Y - float_4);
		float_2 = Math.Max(float_2, pointF_0.X + float_4);
		float_3 = Math.Max(float_3, pointF_0.Y + float_4);
	}
}
