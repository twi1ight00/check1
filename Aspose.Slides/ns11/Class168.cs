using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns235;

namespace ns11;

internal class Class168
{
	private Class168()
	{
	}

	internal static void smethod_0(ref Class6217 path, PointF[] points, PathPointType[] pointTypes, bool closed)
	{
		Class6218 @class = new Class6218();
		path.Add(@class);
		if (closed)
		{
			@class.IsClosed = closed;
			PointF[] array = new PointF[pointTypes.Length + 1];
			PathPointType[] array2 = new PathPointType[pointTypes.Length + 1];
			points.CopyTo(array, 0);
			ref PointF reference = ref array[pointTypes.Length];
			reference = points[0];
			pointTypes.CopyTo(array2, 0);
			array2[pointTypes.Length] = pointTypes[pointTypes.Length - 1];
			pointTypes[pointTypes.Length - 1] &= PathPointType.PathTypeMask;
		}
		List<PointF> list = null;
		PathPointType pathPointType = PathPointType.Start;
		for (int i = 0; i < points.Length; i++)
		{
			if (pointTypes[i] == PathPointType.Start)
			{
				list = new List<PointF>();
			}
			if (pathPointType != 0 && pathPointType != pointTypes[i])
			{
				smethod_1(@class, list, pathPointType);
				list = new List<PointF>();
				if (i > 0)
				{
					list.Add(points[i - 1]);
				}
			}
			list?.Add(points[i]);
			pathPointType = pointTypes[i];
			if (i == points.Length - 1 && list != null)
			{
				smethod_1(@class, list, pathPointType);
			}
		}
	}

	private static void smethod_1(Class6218 figure, List<PointF> pointsList, PathPointType pointType)
	{
		switch (pointType & PathPointType.PathTypeMask)
		{
		case PathPointType.Line:
			figure.method_1(pointsList.ToArray());
			break;
		case PathPointType.Bezier:
			figure.method_4(pointsList.ToArray());
			break;
		case (PathPointType)2:
			break;
		}
	}
}
