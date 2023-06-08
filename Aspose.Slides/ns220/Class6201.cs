using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using ns221;
using ns234;
using ns235;

namespace ns220;

internal class Class6201 : Class6176
{
	private StringBuilder stringBuilder_0;

	private bool bool_0;

	[Attribute7(true)]
	internal string method_0(Class6217 path)
	{
		stringBuilder_0 = new StringBuilder();
		if (path.FillMode == FillMode.Winding)
		{
			stringBuilder_0.Append("F 1 ");
		}
		path.vmethod_0(this);
		return stringBuilder_0.ToString();
	}

	public override void vmethod_7(Class6218 pathFigure)
	{
		bool_0 = true;
	}

	public override void vmethod_8(Class6218 pathFigure)
	{
		if (pathFigure.IsClosed)
		{
			stringBuilder_0.Append("Z");
		}
	}

	public override void vmethod_9(Class6223 segment)
	{
		if (segment.Points.Count > 0)
		{
			int num = 0;
			if (bool_0)
			{
				method_1(segment.Points[num]);
				num++;
				bool_0 = false;
			}
			for (int i = num; i < segment.Points.Count; i++)
			{
				PointF point = segment.Points[i];
				method_2(point);
			}
		}
	}

	public override void vmethod_10(Class6222 segment)
	{
		if (bool_0)
		{
			method_1(segment.Curve.StartPoint);
			bool_0 = false;
		}
		else
		{
			method_2(segment.Curve.StartPoint);
		}
		method_3(new PointF[3]
		{
			segment.Curve.ControlPoint1,
			segment.Curve.ControlPoint2,
			segment.Curve.EndPoint
		});
	}

	private void method_1(PointF point)
	{
		stringBuilder_0.Append("M");
		method_4(point);
	}

	private void method_2(PointF point)
	{
		stringBuilder_0.Append("L");
		method_4(point);
	}

	private void method_3(PointF[] points)
	{
		stringBuilder_0.Append("C");
		for (int i = 0; i < points.Length; i++)
		{
			method_4(points[i]);
		}
	}

	private void method_4(PointF point)
	{
		stringBuilder_0.Append(Class6159.smethod_43(point.X));
		stringBuilder_0.Append(",");
		stringBuilder_0.Append(Class6159.smethod_43(point.Y));
		stringBuilder_0.Append(" ");
	}
}
