using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns35;
using ns37;

namespace ns38;

internal class Class769 : IDisposable
{
	private GraphicsPath graphicsPath_0 = new GraphicsPath();

	private bool bool_0;

	private static byte[] byte_0 = new byte[4] { 0, 1, 1, 129 };

	public static readonly Class769 class769_0 = new Class769();

	protected Class769()
	{
	}

	public Class769(PointF point1, PointF point2, PointF point3, PointF point4, bool toClose)
	{
		byte[] array = (byte[])byte_0.Clone();
		if (toClose)
		{
			array[3] |= 128;
		}
		graphicsPath_0 = new GraphicsPath(new PointF[4] { point1, point2, point3, point4 }, array);
	}

	~Class769()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!bool_0)
		{
			if (disposing)
			{
				graphicsPath_0.Dispose();
			}
			bool_0 = true;
		}
	}

	public void method_0(Interface32 graphics, Pen pen, Brush brush, Class748 chartPoint)
	{
		if (chartPoint != null && graphicsPath_0.PointCount > 0)
		{
			chartPoint.AreaInternal.method_7(graphicsPath_0, 0.5f);
		}
		if (chartPoint != null && graphicsPath_0.PointCount > 0)
		{
			chartPoint.BorderInternal.method_8(graphicsPath_0);
		}
	}

	public bool Contains(PointF point)
	{
		if (graphicsPath_0.PointCount != 0 && graphicsPath_0.PathPoints.Length != 0)
		{
			return Contains(point, graphicsPath_0.PathPoints);
		}
		return false;
	}

	public static bool Contains(PointF point, PointF[] cornerPoints)
	{
		int num = 0;
		for (int i = 1; i < cornerPoints.Length; i++)
		{
			if (smethod_0(point, cornerPoints[i], cornerPoints[i - 1]))
			{
				num++;
			}
		}
		if (smethod_0(point, cornerPoints[cornerPoints.Length - 1], cornerPoints[0]))
		{
			num++;
		}
		return num % 2 != 0;
	}

	private static bool smethod_0(PointF point, PointF point1, PointF point2)
	{
		float x = point2.X;
		float y = point2.Y;
		float x2 = point1.X;
		float y2 = point1.Y;
		if ((x < point.X && x2 >= point.X) || (x >= point.X && x2 < point.X))
		{
			float num = (y - y2) / (x - x2) * (point.X - x2) + y2;
			return num > point.Y;
		}
		return false;
	}
}
