using System.Drawing;
using ns235;

namespace ns238;

internal class Class6192 : Class6176
{
	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private Class6192()
	{
	}

	public static RectangleF smethod_0(Class6217 path)
	{
		Class6192 @class = new Class6192();
		path.vmethod_0(@class);
		return new RectangleF(@class.float_0, @class.float_1, @class.float_2 - @class.float_0, @class.float_3 - @class.float_1);
	}

	public override void vmethod_9(Class6223 segment)
	{
		for (int i = 0; i < segment.Points.Count; i++)
		{
			PointF point = segment.Points[i];
			method_0(point);
		}
	}

	public override void vmethod_10(Class6222 segment)
	{
		method_0(segment.Curve.StartPoint);
		method_0(segment.Curve.ControlPoint1);
		method_0(segment.Curve.ControlPoint2);
		method_0(segment.Curve.EndPoint);
	}

	private void method_0(PointF point)
	{
		if (point.X > float_2)
		{
			float_2 = point.X;
		}
		if (point.Y > float_3)
		{
			float_3 = point.Y;
		}
		if (point.X < float_0)
		{
			float_0 = point.X;
		}
		if (point.Y < float_1)
		{
			float_1 = point.Y;
		}
	}
}
