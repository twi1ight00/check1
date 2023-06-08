using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns235;

namespace ns236;

internal class Class6188 : Class6176
{
	private GraphicsPath graphicsPath_0;

	public GraphicsPath GraphicsPath
	{
		get
		{
			return graphicsPath_0;
		}
		protected set
		{
			graphicsPath_0 = value;
		}
	}

	public override void vmethod_5(Class6217 path)
	{
		graphicsPath_0 = new GraphicsPath(path.FillMode);
	}

	public override void vmethod_7(Class6218 pathFigure)
	{
		graphicsPath_0.StartFigure();
	}

	public override void vmethod_8(Class6218 pathFigure)
	{
		if (pathFigure.IsClosed)
		{
			graphicsPath_0.CloseFigure();
		}
	}

	public override void vmethod_9(Class6223 segment)
	{
		PointF[] array = segment.Points.ToArray();
		if (array != null && array.Length > 1)
		{
			bool flag = true;
			PointF pointF = array[0];
			for (int i = 1; i < array.Length; i++)
			{
				if (pointF != array[i])
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				ref PointF reference = ref array[array.Length - 1];
				reference = new PointF(pointF.X + 0.5f, pointF.Y);
			}
		}
		graphicsPath_0.AddLines(array);
	}

	public override void vmethod_10(Class6222 segment)
	{
		if (Math.Round(segment.Curve.StartPoint.X, 2) == Math.Round(segment.Curve.ControlPoint1.X, 2) && Math.Round(segment.Curve.StartPoint.Y, 2) == Math.Round(segment.Curve.ControlPoint1.Y, 2) && Math.Round(segment.Curve.ControlPoint1.X, 2) == Math.Round(segment.Curve.ControlPoint2.X, 2) && Math.Round(segment.Curve.ControlPoint1.Y, 2) == Math.Round(segment.Curve.ControlPoint2.Y, 2) && Math.Round(segment.Curve.ControlPoint2.X, 2) == Math.Round(segment.Curve.EndPoint.X, 2) && Math.Round(segment.Curve.ControlPoint2.Y, 2) == Math.Round(segment.Curve.EndPoint.Y, 2))
		{
			graphicsPath_0.AddLine(segment.Curve.StartPoint, segment.Curve.EndPoint);
		}
		else
		{
			graphicsPath_0.AddBezier(segment.Curve.StartPoint, segment.Curve.ControlPoint1, segment.Curve.ControlPoint2, segment.Curve.EndPoint);
		}
	}
}
