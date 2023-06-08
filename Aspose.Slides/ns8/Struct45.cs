using System;

namespace ns8;

internal struct Struct45
{
	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	private double double_4;

	private bool bool_0;

	private bool bool_1;

	public double Left => double_0 - double_2;

	public double Top => double_1 - double_2;

	public double CenterX => double_0;

	public double CenterY => double_1;

	public double Radius => double_2;

	public double Diameter => double_2 * 2.0;

	public double StartAngle => double_3;

	public double EndAngle => double_4;

	public bool IsReverse => bool_0;

	public bool ForceLongCurve => bool_1;

	public Struct45(double centerX, double centerY, double radius, double startAngle, double endAngle, bool isReverse)
	{
		double_0 = centerX;
		double_1 = centerY;
		double_2 = radius;
		double_3 = startAngle;
		double_4 = endAngle;
		bool_0 = isReverse;
		bool_1 = false;
	}

	public Struct45(double diameter, Struct47 bounds, double begPadding, double endPadding, bool forceLongCurve)
	{
		Struct50 @struct = new Struct50(0.0 - bounds.Norm.Dy, bounds.Norm.Dx);
		if (Math.Abs(diameter) < bounds.Distance)
		{
			diameter = bounds.Distance;
		}
		double num = Math.Abs(diameter / 2.0);
		double num2 = Math.Sqrt(Math.Pow(num, 2.0) - Math.Pow(bounds.Distance / 2.0, 2.0));
		double startX = ((diameter > 0.0) ? (bounds.X + bounds.Width / 2.0 - @struct.Dx * num2) : (bounds.X + bounds.Width / 2.0 + @struct.Dx * num2));
		double startY = ((diameter > 0.0) ? (bounds.Y + bounds.Height / 2.0 - @struct.Dy * num2) : (bounds.Y + bounds.Height / 2.0 + @struct.Dy * num2));
		double num3 = 180.0 * begPadding / (Math.PI * num);
		double num4 = 180.0 * endPadding / (Math.PI * num);
		double[] array = new double[2]
		{
			new Struct47(startX, startY, (diameter > 0.0) ? bounds.StartX : bounds.EndX, (diameter > 0.0) ? bounds.StartY : bounds.EndY).AngleInDegrees,
			new Struct47(startX, startY, (diameter > 0.0) ? bounds.EndX : bounds.StartX, (diameter > 0.0) ? bounds.EndY : bounds.StartY).AngleInDegrees
		};
		if (diameter < 0.0 && forceLongCurve)
		{
			array[0] -= num4;
			array[1] += num3;
		}
		else
		{
			array[0] += ((diameter > 0.0) ? num3 : num4);
			array[1] += ((diameter > 0.0) ? (0.0 - num4) : (0.0 - num3));
		}
		for (int i = 0; i < 2; i++)
		{
			if (array[i] > 360.0)
			{
				array[i] -= 360.0;
			}
			else if (array[i] < 0.0)
			{
				array[i] = 360.0 + array[i];
			}
		}
		double_0 = startX;
		double_1 = startY;
		double_2 = num;
		double_3 = array[0];
		double_4 = array[1];
		bool_0 = diameter < 0.0;
		bool_1 = forceLongCurve;
	}
}
