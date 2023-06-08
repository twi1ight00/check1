using System.Collections.Generic;
using System.Drawing;
using ns219;
using ns224;

namespace ns263;

internal class Class6472 : Interface315
{
	public RectangleF method_0(IList<Class6332> dmlNodes)
	{
		if (dmlNodes.Count == 0)
		{
			return default(RectangleF);
		}
		PointF[] boundPoints = smethod_1(dmlNodes);
		return smethod_2(boundPoints);
	}

	public RectangleF imethod_0(Class6473 dmlTransform)
	{
		PointF[] array = new PointF[4];
		smethod_0(array, 0, dmlTransform);
		return smethod_2(array);
	}

	private static void smethod_0(PointF[] points, int baseIndex, Class6473 dmlTransform)
	{
		ref PointF reference = ref points[baseIndex];
		reference = new PointF((float)dmlTransform.X, (float)dmlTransform.Y);
		ref PointF reference2 = ref points[baseIndex + 1];
		reference2 = new PointF((float)(dmlTransform.X + dmlTransform.Width), (float)dmlTransform.Y);
		ref PointF reference3 = ref points[baseIndex + 2];
		reference3 = new PointF((float)(dmlTransform.X + dmlTransform.Width), (float)(dmlTransform.Y + dmlTransform.Length));
		ref PointF reference4 = ref points[baseIndex + 3];
		reference4 = new PointF((float)dmlTransform.X, (float)(dmlTransform.Y + dmlTransform.Length));
		Class6002 @class = dmlTransform.vmethod_2();
		@class.method_1(points, baseIndex, 4);
	}

	private static PointF[] smethod_1(IList<Class6332> dmlNodes)
	{
		PointF[] array = new PointF[dmlNodes.Count * 4];
		for (int i = 0; i < dmlNodes.Count; i++)
		{
			Class6332 @class = dmlNodes[i];
			int baseIndex = i * 4;
			smethod_0(array, baseIndex, @class.vmethod_1());
		}
		return array;
	}

	private static RectangleF smethod_2(PointF[] boundPoints)
	{
		if (boundPoints.Length == 0)
		{
			return default(RectangleF);
		}
		float x = boundPoints[0].X;
		float x2 = boundPoints[0].X;
		float y = boundPoints[0].Y;
		float y2 = boundPoints[0].Y;
		for (int i = 0; i < boundPoints.Length; i++)
		{
			PointF pointF = boundPoints[i];
			if (pointF.X < x)
			{
				x = pointF.X;
			}
			else if (pointF.X > x2)
			{
				x2 = pointF.X;
			}
			if (pointF.Y < y)
			{
				y = pointF.Y;
			}
			else if (pointF.Y > y2)
			{
				y2 = pointF.Y;
			}
		}
		return new RectangleF(x, y, x2 - x, y2 - y);
	}
}
