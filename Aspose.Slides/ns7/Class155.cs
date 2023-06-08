using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;
using ns224;

namespace ns7;

internal sealed class Class155 : Class154
{
	private double double_6;

	private double double_7;

	private double double_8;

	private double double_9;

	private double double_10 = 1.0;

	private double double_11 = 1.0;

	private double double_12;

	private double double_13;

	public double ChildX => double_6;

	public double ChildY => double_7;

	public double ChildWidth => double_8;

	public double ChildHeight => double_9;

	public RectangleF ChildRect
	{
		get
		{
			return new RectangleF((float)double_6, (float)double_7, (float)double_8, (float)double_9);
		}
		set
		{
			method_5(value.X, value.Y, value.Width, value.Height);
		}
	}

	public double ScaleX => double_10;

	public double ScaleY => double_11;

	public double ReferrenceCenterX => double_12;

	public double ReferrenceCenterY => double_13;

	public override void vmethod_0(double x, double y, double width, double height)
	{
		base.vmethod_0(x, y, width, height);
		method_6();
	}

	private Class6002 method_2()
	{
		float scaleX = (float)((Math.Abs(base.Width - ChildWidth) < 0.001) ? 1.0 : (base.Width / ChildWidth));
		float scaleY = (float)((Math.Abs(base.Height - ChildHeight) < 0.001) ? 1.0 : (base.Height / ChildHeight));
		double num = ChildX + ChildWidth / 2.0;
		double num2 = ChildY + ChildHeight / 2.0;
		double num3 = base.X + base.Width / 2.0;
		double num4 = base.Y + base.Height / 2.0;
		Class6002 @class = new Class6002();
		@class.method_7((float)(0.0 - num), (float)(0.0 - num2), MatrixOrder.Append);
		@class.method_5(scaleX, scaleY, MatrixOrder.Append);
		if (base.FlipH == NullableBool.True)
		{
			@class.method_5(-1f, 1f, MatrixOrder.Append);
		}
		if (base.FlipV == NullableBool.True)
		{
			@class.method_5(1f, -1f, MatrixOrder.Append);
		}
		@class.method_11(base.Rotation, MatrixOrder.Append);
		@class.method_7((float)num3, (float)num4, MatrixOrder.Append);
		return @class;
	}

	public ShapeFrame method_3(ShapeFrame frame)
	{
		Class6002 @class = method_2();
		PointF pointF = @class.method_2(new PointF(frame.CenterX, frame.CenterY));
		float num = (float)((Math.Abs(base.Width - ChildWidth) < 0.001) ? 1.0 : (base.Width / ChildWidth));
		float num2 = (float)((Math.Abs(base.Height - ChildHeight) < 0.001) ? 1.0 : (base.Height / ChildHeight));
		double num3 = frame.Width * num;
		double num4 = frame.Height * num2;
		return new ShapeFrame((float)((double)pointF.X - num3 / 2.0), (float)((double)pointF.Y - num4 / 2.0), num3, num4, frame.FlipH, frame.FlipV, ShapeFrame.smethod_0(frame.Rotation + base.Rotation));
	}

	internal PointF method_4(PointF point)
	{
		Class6002 @class = method_2();
		return @class.method_2(point);
	}

	public void method_5(double childX, double childY, double childWidth, double childHeight)
	{
		double_6 = childX;
		double_7 = childY;
		double_8 = childWidth;
		double_9 = childHeight;
		double_12 = double_6 + double_8 / 2.0;
		double_13 = double_7 + double_9 / 2.0;
		method_6();
	}

	public void method_6()
	{
		double_10 = ((Math.Abs(base.Width - double_8) < 0.001 || double_8 == 0.0 || base.Width == 0.0) ? 1.0 : (base.Width / double_8));
		double_11 = ((Math.Abs(base.Height - double_9) < 0.001 || double_9 == 0.0 || base.Height == 0.0) ? 1.0 : (base.Height / double_9));
	}

	public override void Reset()
	{
		base.Reset();
		method_5(0.0, 0.0, 0.0, 0.0);
	}
}
