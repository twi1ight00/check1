using System.Drawing;
using ns235;

namespace ns238;

internal class Class6193 : Class6176
{
	private PointF pointF_0;

	private PointF pointF_1;

	private PointF pointF_2;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2 = true;

	private Class6193()
	{
	}

	public static bool smethod_0(Class6217 path)
	{
		Class6193 @class = new Class6193();
		path.vmethod_0(@class);
		if (!@class.bool_2)
		{
			return path.IsLastFigureClosed;
		}
		return true;
	}

	public override void vmethod_5(Class6217 path)
	{
		bool_0 = true;
	}

	public override void vmethod_7(Class6218 pathFigure)
	{
		bool_1 = true;
	}

	public override void vmethod_9(Class6223 segment)
	{
		if (segment.Points.Count > 0)
		{
			if (bool_0)
			{
				pointF_0 = segment.Points[0];
				pointF_1 = pointF_0;
			}
			if (bool_1 && !bool_0)
			{
				pointF_1 = segment.Points[0];
				bool_2 &= pointF_2.Equals(pointF_1);
			}
			bool_0 = false;
			bool_1 = false;
			pointF_2 = segment.Points[segment.Points.Count - 1];
		}
	}

	public override void vmethod_10(Class6222 segment)
	{
		if (bool_0)
		{
			pointF_0 = segment.Curve.StartPoint;
			pointF_1 = pointF_0;
		}
		if (bool_1 && !bool_0)
		{
			pointF_1 = segment.Curve.StartPoint;
			bool_2 &= pointF_2.Equals(pointF_1);
		}
		bool_0 = false;
		bool_1 = false;
		pointF_2 = segment.Curve.EndPoint;
	}

	public override void vmethod_8(Class6218 pathFigure)
	{
		if (pathFigure.IsClosed)
		{
			pointF_2 = pointF_1;
		}
	}

	public override void vmethod_6(Class6217 path)
	{
		bool_2 &= pointF_2.Equals(pointF_0);
	}
}
