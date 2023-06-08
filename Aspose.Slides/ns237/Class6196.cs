using System.Drawing;
using ns235;

namespace ns237;

internal class Class6196 : Class6176
{
	private readonly Class6514 class6514_0;

	private bool bool_0;

	public Class6196(Class6514 stream)
	{
		class6514_0 = stream;
	}

	public override void vmethod_7(Class6218 pathFigure)
	{
		bool_0 = true;
	}

	public override void vmethod_8(Class6218 pathFigure)
	{
		if (!bool_0 && pathFigure.IsClosed)
		{
			class6514_0.method_4("h");
		}
	}

	public override void vmethod_9(Class6223 segment)
	{
		if (segment.Points.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < segment.Points.Count; i++)
		{
			if (bool_0)
			{
				method_0(segment.Points[0]);
				bool_0 = false;
			}
			else
			{
				method_1(segment.Points[i]);
			}
		}
	}

	public override void vmethod_10(Class6222 segment)
	{
		if (bool_0)
		{
			method_0(segment.Curve.StartPoint);
			bool_0 = false;
		}
		else
		{
			method_1(segment.Curve.StartPoint);
		}
		method_2(new PointF[3]
		{
			segment.Curve.ControlPoint1,
			segment.Curve.ControlPoint2,
			segment.Curve.EndPoint
		});
	}

	private void method_0(PointF point)
	{
		class6514_0.method_7(point);
		class6514_0.Write(" m ");
	}

	private void method_1(PointF point)
	{
		int num = Class6678.smethod_3(point.X, point.Y);
		string text = Class6678.smethod_2(point.X / (float)num);
		string text2 = Class6678.smethod_2(point.Y / (float)num);
		class6514_0.method_4(text);
		class6514_0.method_4(text2);
		class6514_0.Write("l ");
		while ((float)num > 32767f)
		{
			num = (int)((float)num / 32767f) + 1;
		}
		for (int i = 1; i < num; i++)
		{
			class6514_0.method_4(text);
			class6514_0.method_4(text2);
			class6514_0.Write("l ");
		}
	}

	private void method_2(PointF[] points)
	{
		for (int i = 0; i < points.Length; i++)
		{
			class6514_0.method_7(points[i]);
			if (i < points.Length - 1)
			{
				class6514_0.Write(" ");
			}
		}
		class6514_0.Write(" c ");
	}
}
