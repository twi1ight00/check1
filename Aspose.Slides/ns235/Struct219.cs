using System.Collections.Generic;
using System.Drawing;

namespace ns235;

internal struct Struct219
{
	private PointF pointF_0;

	private PointF pointF_1;

	private PointF pointF_2;

	private PointF pointF_3;

	public PointF StartPoint
	{
		get
		{
			return pointF_0;
		}
		set
		{
			pointF_0 = value;
		}
	}

	public PointF ControlPoint1
	{
		get
		{
			return pointF_1;
		}
		set
		{
			pointF_1 = value;
		}
	}

	public PointF ControlPoint2
	{
		get
		{
			return pointF_2;
		}
		set
		{
			pointF_2 = value;
		}
	}

	public PointF EndPoint
	{
		get
		{
			return pointF_3;
		}
		set
		{
			pointF_3 = value;
		}
	}

	public Struct219(PointF quadP0, PointF quadP1, PointF quadP2)
	{
		pointF_0 = quadP0;
		pointF_1 = new PointF(smethod_0(quadP0.X, quadP1.X), smethod_0(quadP0.Y, quadP1.Y));
		pointF_2 = new PointF(smethod_0(quadP2.X, quadP1.X), smethod_0(quadP2.Y, quadP1.Y));
		pointF_3 = quadP2;
	}

	private static float smethod_0(float coord0, float coord1)
	{
		return (coord0 + 2f * coord1) / 3f;
	}

	public Struct221[] method_0()
	{
		return smethod_1(this);
	}

	private static Struct221[] smethod_1(Struct219 originalCurve)
	{
		List<Struct219> list = new List<Struct219>();
		smethod_3(originalCurve, 4, list);
		Struct221[] array = new Struct221[list.Count];
		for (int i = 0; i < list.Count; i++)
		{
			ref Struct221 reference = ref array[i];
			reference = smethod_2(list[i]);
		}
		return array;
	}

	private static Struct221 smethod_2(Struct219 originalCurve)
	{
		Struct221 result = default(Struct221);
		result.StartPoint = originalCurve.StartPoint;
		result.ControlPoint = smethod_5(originalCurve.ControlPoint1, originalCurve.ControlPoint2);
		result.EndPoint = originalCurve.EndPoint;
		return result;
	}

	private static void smethod_3(Struct219 originalCurve, int numberOfSubCurves, List<Struct219> curves)
	{
		Struct219[] array = smethod_4(originalCurve);
		if (numberOfSubCurves > 2)
		{
			int numberOfSubCurves2 = numberOfSubCurves / 2;
			Struct219[] array2 = array;
			foreach (Struct219 originalCurve2 in array2)
			{
				smethod_3(originalCurve2, numberOfSubCurves2, curves);
			}
		}
		else
		{
			Struct219[] array3 = array;
			foreach (Struct219 item in array3)
			{
				curves.Add(item);
			}
		}
	}

	private static Struct219[] smethod_4(Struct219 originalCurve)
	{
		Struct219[] array = new Struct219[2];
		PointF pointF = smethod_5(originalCurve.StartPoint, originalCurve.ControlPoint1);
		PointF pointF2 = smethod_5(originalCurve.ControlPoint1, originalCurve.ControlPoint2);
		PointF pointF3 = smethod_5(originalCurve.ControlPoint2, originalCurve.EndPoint);
		PointF pointF4 = smethod_5(pointF, pointF2);
		PointF pointF5 = smethod_5(pointF2, pointF3);
		PointF pointF6 = smethod_5(pointF4, pointF5);
		array[0] = default(Struct219);
		array[0].StartPoint = originalCurve.StartPoint;
		array[0].ControlPoint1 = pointF;
		array[0].ControlPoint2 = pointF4;
		array[0].EndPoint = pointF6;
		array[1] = default(Struct219);
		array[1].StartPoint = pointF6;
		array[1].ControlPoint1 = pointF5;
		array[1].ControlPoint2 = pointF3;
		array[1].EndPoint = originalCurve.EndPoint;
		return array;
	}

	private static PointF smethod_5(PointF point1, PointF point2)
	{
		return new PointF((point1.X + point2.X) / 2f, (point1.Y + point2.Y) / 2f);
	}
}
