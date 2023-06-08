using System;
using System.Drawing;
using ns218;

namespace ns235;

internal class Class6173
{
	private const double double_0 = 45.0;

	private PointF pointF_0 = PointF.Empty;

	private SizeF sizeF_0 = SizeF.Empty;

	private double double_1;

	private double double_2;

	public PointF Location
	{
		get
		{
			return pointF_0;
		}
		set
		{
			pointF_0 = value;
		}
	}

	public SizeF Size
	{
		get
		{
			return sizeF_0;
		}
		set
		{
			sizeF_0 = value;
		}
	}

	public double StartAngle
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public double SweepAngle
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	public SizeF HalfSize => new SizeF(Size.Width / 2f, Size.Height / 2f);

	public PointF Center => new PointF(Location.X + HalfSize.Width, Location.Y + HalfSize.Height);

	public Class6173()
	{
	}

	public Class6173(RectangleF bounds, double startAngle, double sweepAngle)
	{
		pointF_0 = bounds.Location;
		sizeF_0 = bounds.Size;
		double_1 = startAngle;
		double_2 = sweepAngle;
	}

	public Class6173(RectangleF bounds)
		: this(bounds, 0.0, 360.0)
	{
	}

	public PointF method_0()
	{
		return method_4(Class5963.smethod_0(StartAngle));
	}

	public PointF method_1()
	{
		return method_4(Class5963.smethod_0(StartAngle + SweepAngle));
	}

	public Struct219[] method_2()
	{
		int num = (int)(Math.Abs(SweepAngle) / 45.0);
		if (SweepAngle % 45.0 != 0.0)
		{
			num++;
		}
		num = Math.Min(num, 8);
		Struct219[] array = new Struct219[num];
		double num2 = StartAngle;
		double num3 = Math.Sign(SweepAngle);
		for (int i = 0; i < num; i++)
		{
			double num4 = Math.Min(45.0, Math.Abs(StartAngle + SweepAngle - num2));
			num4 *= num3;
			ref Struct219 reference = ref array[i];
			reference = method_3(num2, num4);
			num2 += num4;
		}
		return array;
	}

	private Struct219 method_3(double startAngle, double sweepAngle)
	{
		startAngle = Class5963.smethod_0(startAngle);
		sweepAngle = Class5963.smethod_0(sweepAngle);
		double num = method_5(startAngle);
		double num2 = method_5(startAngle + sweepAngle);
		double num3 = num2 - num;
		double a = num3 / 2.0;
		double num4 = Math.Sin(num3) * (Math.Sqrt(4.0 + 3.0 * Math.Pow(Math.Tan(a), 2.0)) - 1.0) / 3.0;
		Struct219 result = default(Struct219);
		result.StartPoint = method_4(startAngle);
		result.EndPoint = method_4(startAngle + sweepAngle);
		result.ControlPoint1 = new PointF((float)((double)result.StartPoint.X - num4 * (double)HalfSize.Width * Math.Sin(num)), (float)((double)result.StartPoint.Y + num4 * (double)HalfSize.Height * Math.Cos(num)));
		result.ControlPoint2 = new PointF((float)((double)result.EndPoint.X + num4 * (double)HalfSize.Width * Math.Sin(num2)), (float)((double)result.EndPoint.Y - num4 * (double)HalfSize.Height * Math.Cos(num2)));
		return result;
	}

	private PointF method_4(double angle)
	{
		double num = method_5(angle);
		return new PointF((float)((double)Center.X + (double)HalfSize.Width * Math.Cos(num)), (float)((double)Center.Y + (double)HalfSize.Height * Math.Sin(num)));
	}

	private double method_5(double angle)
	{
		return Math.Atan2(1.0 / (double)HalfSize.Height * Math.Sin(angle), 1.0 / (double)HalfSize.Width * Math.Cos(angle));
	}
}
