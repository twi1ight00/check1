using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ns8;

internal struct Struct47
{
	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	public double X => Math.Min(double_0, double_2);

	public double Y => Math.Min(double_1, double_3);

	public double Right => X + Width;

	public double Bottom => Y + Height;

	public double StartX => double_0;

	public double StartY => double_1;

	public double EndX => double_2;

	public double EndY => double_3;

	public double Width => Math.Abs(double_2 - double_0);

	public double Height => Math.Abs(double_3 - double_1);

	public Struct46 Center => new Struct46(X + Width / 2.0, Y + Height / 2.0);

	public double Distance => Math.Sqrt(Math.Pow(Width, 2.0) + Math.Pow(Height, 2.0));

	public double AngleInDegrees
	{
		get
		{
			double num = Math.Asin(Height / Distance) * (180.0 / Math.PI);
			if (double_0 <= double_2)
			{
				if (!(double_1 <= double_3))
				{
					return 360.0 - num;
				}
				return num;
			}
			if (!(double_1 <= double_3))
			{
				return 180.0 + num;
			}
			return 180.0 - num;
		}
	}

	public Struct50 Norm
	{
		get
		{
			double distance = Distance;
			return new Struct50((double_0 - double_2) / distance, (double_1 - double_3) / distance);
		}
	}

	public Struct47(double startX, double startY, double endX, double endY)
	{
		double_0 = startX;
		double_1 = startY;
		double_2 = endX;
		double_3 = endY;
	}

	public Struct47(Struct46 start, Struct46 end)
	{
		double_0 = start.X;
		double_1 = start.Y;
		double_2 = end.X;
		double_3 = end.Y;
	}

	public Struct47(Struct50 vector, double length, double width, double height)
	{
		Struct46 @struct = new Struct46(vector.Dx * length, vector.Dy * length);
		double_0 = @struct.X - width / 2.0;
		double_1 = @struct.Y - height / 2.0;
		double_2 = @struct.X + width / 2.0;
		double_3 = @struct.Y + height / 2.0;
	}

	public Struct47(IEnumerable<Struct47> rectangles)
	{
		double_0 = double.MaxValue;
		double_1 = double.MaxValue;
		double_2 = double.MinValue;
		double_3 = double.MinValue;
		bool flag = false;
		foreach (Struct47 rectangle in rectangles)
		{
			if (!flag)
			{
				flag = true;
			}
			double_0 = Math.Min(double_0, rectangle.X);
			double_1 = Math.Min(double_1, rectangle.Y);
			double_2 = Math.Max(double_2, rectangle.X + rectangle.Width);
			double_3 = Math.Max(double_3, rectangle.Y + rectangle.Height);
		}
		if (!flag)
		{
			double num = 0.0;
			double_3 = 0.0;
			double num2 = 0.0;
			double_2 = num;
			double num3 = 0.0;
			double_1 = num2;
			double_0 = num3;
		}
	}

	public List<Struct49> method_0(double x, double y)
	{
		List<Struct49> list = new List<Struct49>(2);
		if (Math.Abs(x - double_0) < 0.0001)
		{
			list.Add(new Struct49(-1, 0));
		}
		else if (Math.Abs(x - double_2) < 0.0001)
		{
			list.Add(new Struct49(1, 0));
		}
		if (Math.Abs(y - double_1) < 0.0001)
		{
			list.Add(new Struct49(0, -1));
		}
		else if (Math.Abs(y - double_3) < 0.0001)
		{
			list.Add(new Struct49(0, 1));
		}
		return list;
	}

	public Struct46[] method_1()
	{
		return new Struct46[4]
		{
			new Struct46(X, Y),
			new Struct46(Right, Y),
			new Struct46(Right, Bottom),
			new Struct46(X, Bottom)
		};
	}

	public Struct46 method_2(Struct46 target)
	{
		Struct46[] array = method_1();
		Struct46 result = array[0];
		double num = Math.Sqrt(Math.Pow(target.X - result.X, 2.0) + Math.Pow(target.Y - result.Y, 2.0));
		for (int i = 1; i < array.Length; i++)
		{
			Struct46 @struct = array[i];
			double num2 = Math.Sqrt(Math.Pow(target.X - @struct.X, 2.0) + Math.Pow(target.Y - @struct.Y, 2.0));
			if (num2 < num)
			{
				num = num2;
				result = @struct;
			}
		}
		return result;
	}

	public Struct47 method_3(double width, double height)
	{
		return new Struct47(X - width, Y - height, Right + width, Bottom + height);
	}

	public Struct47 method_4(double value)
	{
		return method_3(value, value);
	}

	public Struct47 method_5(Struct47 other)
	{
		return new Struct47(Math.Min(X, other.X), Math.Min(Y, other.Y), Math.Max(X + Width, other.X + other.Width), Math.Max(Y + Height, other.Y + other.Height));
	}

	public Struct47 method_6(IList<Struct47> rectangles)
	{
		Struct47 @struct = this;
		for (int i = 1; i < rectangles.Count; i++)
		{
			@struct = smethod_1(@struct, rectangles[i]);
		}
		return @struct;
	}

	public Struct47 method_7(Struct47 other)
	{
		double num = Math.Max(0.0, Math.Min(Right, other.Right) - Math.Max(X, other.X));
		double num2 = Math.Max(0.0, Math.Min(Bottom, other.Bottom) - Math.Max(Y, other.Y));
		if (num > 0.0 && num2 > 0.0)
		{
			double num3 = Math.Min(Right, other.Right);
			double num4 = Math.Min(Bottom, other.Bottom);
			return new Struct47(num3 - num, num4 - num2, num3, num4);
		}
		return default(Struct47);
	}

	public Struct47 method_8(Struct50 diff)
	{
		return method_9(diff.Dx, diff.Dy);
	}

	public Struct47 method_9(double dx, double dy)
	{
		return new Struct47(X + dx, Y + dy, Right + dx, Bottom + dy);
	}

	[SpecialName]
	public static Struct47 smethod_0(Struct47 a, Struct47 b)
	{
		return a.method_7(b);
	}

	[SpecialName]
	public static Struct47 smethod_1(Struct47 a, Struct47 b)
	{
		return a.method_5(b);
	}
}
