using System;

namespace ns144;

internal class Class4644
{
	private double double_0;

	private double double_1;

	public double X => double_0;

	public double Y => double_1;

	public void method_0(double x0, double y0, double x1, double y1)
	{
		smethod_0(x1 - x0, y1 - y0, out double_0, out double_1);
	}

	public void method_1(double x, double y)
	{
		smethod_0(x, y, out double_0, out double_1);
	}

	private static void smethod_0(double x, double y, out double outX, out double outY)
	{
		double num = Math.Sqrt(x * x + y * y);
		outX = x / num;
		outY = y / num;
	}
}
