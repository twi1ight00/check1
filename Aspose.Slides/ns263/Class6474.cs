using System.Drawing;
using System.Drawing.Drawing2D;
using ns224;

namespace ns263;

internal class Class6474 : Class6473
{
	private double double_4;

	private double double_5;

	private double double_6;

	private double double_7;

	public double ChildWidth
	{
		get
		{
			return double_5;
		}
		set
		{
			double_5 = value;
		}
	}

	public double ChildLength
	{
		get
		{
			return double_4;
		}
		set
		{
			double_4 = value;
		}
	}

	public PointF ChildTopLeft
	{
		get
		{
			return new PointF((float)ChildX, (float)ChildY);
		}
		set
		{
			ChildX = value.X;
			ChildY = value.Y;
		}
	}

	public double ChildX
	{
		get
		{
			return double_6;
		}
		set
		{
			double_6 = value;
		}
	}

	public double ChildY
	{
		get
		{
			return double_7;
		}
		set
		{
			double_7 = value;
		}
	}

	public override double XOffset => base.X - ChildX;

	public override double YOffset => base.Y - ChildY;

	public override float XScale
	{
		get
		{
			float num = 1f;
			return num * method_3();
		}
	}

	public override float YScale
	{
		get
		{
			float num = 1f;
			return num * method_2();
		}
	}

	public PointF ChildrenCenterPoint => new PointF((float)(ChildX + ChildWidth / 2.0), (float)(ChildY + ChildLength / 2.0));

	public Class6002 method_1(double scaleX, double scaleY)
	{
		Class6002 @class = new Class6002();
		PointF childrenCenterPoint = ChildrenCenterPoint;
		PointF centerPoint = CenterPoint;
		@class.method_7(0f - childrenCenterPoint.X, 0f - childrenCenterPoint.Y, MatrixOrder.Append);
		@class.method_5((float)scaleX, (float)scaleY, MatrixOrder.Append);
		@class.method_7(centerPoint.X, centerPoint.Y, MatrixOrder.Append);
		return @class;
	}

	public override Class6002 vmethod_1()
	{
		Class6002 @class = vmethod_0();
		Class6002 tx = vmethod_2();
		@class.method_9(tx, MatrixOrder.Append);
		return @class;
	}

	public override Class6002 vmethod_0()
	{
		float num = method_2();
		float num2 = method_3();
		float m = (float)(base.X - (double)num2 * ChildX);
		float m2 = (float)(base.Y - (double)num * ChildY);
		return new Class6002(num2, 0f, 0f, num, m, m2);
	}

	private float method_2()
	{
		if (base.Length != 0.0 && ChildLength != 0.0)
		{
			return (float)(base.Length / ChildLength);
		}
		return 1f;
	}

	private float method_3()
	{
		if (base.Width != 0.0 && ChildWidth != 0.0)
		{
			return (float)(base.Width / ChildWidth);
		}
		return 1f;
	}

	public void method_4()
	{
		ChildWidth = base.Width;
		ChildLength = base.Length;
		ChildX = base.X;
		ChildY = base.Y;
	}

	public override void vmethod_3(double xscale, double yscale)
	{
		base.vmethod_3(xscale, yscale);
		Class6002 @class = new Class6002();
		PointF centerPoint = CenterPoint;
		@class.method_7(0f - centerPoint.X, 0f - centerPoint.Y, MatrixOrder.Append);
		@class.method_5((float)xscale, (float)yscale, MatrixOrder.Append);
		@class.method_7(centerPoint.X, centerPoint.Y, MatrixOrder.Append);
		ChildTopLeft = @class.method_2(ChildTopLeft);
		double_5 *= xscale;
		double_4 *= yscale;
	}

	public override Class6473 Clone()
	{
		Class6474 @class = new Class6474();
		CopyTo(@class);
		return @class;
	}

	public override void vmethod_4(float dx, float dy)
	{
		base.vmethod_4(dx, dy);
		double_6 += dx;
		double_7 += dy;
	}

	protected void CopyTo(Class6474 target)
	{
		CopyTo((Class6473)target);
		target.double_4 = double_4;
		target.double_5 = double_5;
		target.double_6 = double_6;
		target.double_7 = double_7;
	}
}
