using System.Drawing;
using ns218;
using ns235;

namespace ns238;

internal class Class6194 : Class6176
{
	private PointF pointF_0 = PointF.Empty;

	private readonly Class6581 class6581_0;

	private bool bool_0;

	public Class6194(Class6567 context)
		: this(new Class6581(context))
	{
	}

	public Class6194(Class6581 shapeRecordWriter)
	{
		class6581_0 = shapeRecordWriter;
	}

	public void Write(Class6217 path)
	{
		path.vmethod_0(this);
	}

	public override void vmethod_7(Class6218 pathFigure)
	{
		bool_0 = true;
	}

	public override void vmethod_8(Class6218 pathFigure)
	{
		if (pathFigure.IsClosed)
		{
			method_3();
		}
	}

	public override void vmethod_9(Class6223 segment)
	{
		if (segment.Points.Count > 0)
		{
			if (bool_0)
			{
				pointF_0 = segment.Points[0];
				method_0(pointF_0);
				bool_0 = false;
			}
			for (int i = 0; i < segment.Points.Count; i++)
			{
				PointF point = segment.Points[i];
				method_1(point);
			}
		}
	}

	public override void vmethod_10(Class6222 segment)
	{
		if (bool_0)
		{
			pointF_0 = segment.Curve.StartPoint;
			method_0(pointF_0);
			bool_0 = false;
		}
		else
		{
			method_1(segment.Curve.StartPoint);
		}
		Struct221[] array = segment.Curve.method_0();
		Struct221[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			Struct221 @struct = array2[i];
			method_2(@struct.ControlPoint, @struct.EndPoint);
		}
	}

	private void method_0(PointF point)
	{
		class6581_0.method_1(Class5964.smethod_29(point.X), Class5964.smethod_29(point.Y));
	}

	private void method_1(PointF point)
	{
		int num = Class5964.smethod_29(point.X) - class6581_0.CurrentX;
		int num2 = Class5964.smethod_29(point.Y) - class6581_0.CurrentY;
		if (num != 0 || num2 != 0)
		{
			class6581_0.method_5(num, num2);
		}
	}

	private void method_2(PointF controlPoint, PointF endPoint)
	{
		int controldx = Class5964.smethod_29(controlPoint.X) - class6581_0.CurrentX;
		int controldy = Class5964.smethod_29(controlPoint.Y) - class6581_0.CurrentY;
		int anchordx = Class5964.smethod_29(endPoint.X) - Class5964.smethod_29(controlPoint.X);
		int anchordy = Class5964.smethod_29(endPoint.Y) - Class5964.smethod_29(controlPoint.Y);
		class6581_0.method_4(controldx, controldy, anchordx, anchordy);
	}

	private void method_3()
	{
		class6581_0.method_5(Class5964.smethod_29(pointF_0.X) - class6581_0.CurrentX, Class5964.smethod_29(pointF_0.Y) - class6581_0.CurrentY);
	}
}
