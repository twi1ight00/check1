using System;
using System.Drawing;
using ns218;

namespace ns235;

internal class Class6174
{
	public Class6173 method_0(RectangleF bounds, PointF start, PointF end)
	{
		return method_1(bounds, start, end, Enum795.const_2);
	}

	public Class6173 method_1(RectangleF bounds, PointF start, PointF end, Enum795 arcRotationDirection)
	{
		SizeF sizeF = new SizeF(bounds.Width / 2f, bounds.Height / 2f);
		PointF pointF = new PointF(bounds.X + sizeF.Width, bounds.Y + sizeF.Height);
		double num = Math.Atan2(start.Y - pointF.Y, start.X - pointF.X);
		double endAngle = Math.Atan2(end.Y - pointF.Y, end.X - pointF.X);
		double sweepAngle = smethod_0(num, endAngle, arcRotationDirection);
		num = Class5963.smethod_1(num);
		return new Class6173(bounds, num, sweepAngle);
	}

	private static double smethod_0(double startAngle, double endAngle, Enum795 arcRotationDirection)
	{
		double num = smethod_2(startAngle, endAngle, arcRotationDirection);
		if (num == 0.0)
		{
			return 360.0;
		}
		if (arcRotationDirection == Enum795.const_2)
		{
			num = smethod_1(num);
		}
		return Class5963.smethod_1(num);
	}

	private static double smethod_1(double delta)
	{
		if (delta > Math.PI)
		{
			delta -= Math.PI * 2.0;
		}
		else if (delta < -Math.PI)
		{
			delta += Math.PI * 2.0;
		}
		return delta;
	}

	private static double smethod_2(double startAngle, double endAngle, Enum795 arcRotationDirection)
	{
		switch (arcRotationDirection)
		{
		case Enum795.const_0:
			if (endAngle < startAngle)
			{
				endAngle += Math.PI * 2.0;
			}
			break;
		case Enum795.const_1:
			if (endAngle > startAngle)
			{
				startAngle += Math.PI * 2.0;
			}
			break;
		}
		return endAngle - startAngle;
	}
}
