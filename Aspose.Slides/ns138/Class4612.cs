using System;
using ns137;
using ns99;

namespace ns138;

internal class Class4612 : ICloneable, Interface143
{
	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	private double double_4;

	private double double_5;

	private Class4609 class4609_0;

	public double X1
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public double Y1
	{
		get
		{
			return double_3;
		}
		set
		{
			double_3 = value;
		}
	}

	public double X2
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

	public double Y2
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

	public double X3
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

	public double Y3
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

	internal Class4609 Hints
	{
		get
		{
			return class4609_0;
		}
		set
		{
			class4609_0 = value;
		}
	}

	public Class4612(double x1, double y1, double x2, double y2, double x3, double y3)
	{
		double_0 = x1;
		double_3 = y1;
		double_1 = x2;
		double_4 = y2;
		double_2 = x3;
		double_5 = y3;
	}

	public Interface143 imethod_0()
	{
		return new Class4612(double_0, double_3, double_1, double_4, double_2, double_5);
	}

	public void imethod_1(double dx, double dy)
	{
		double_0 += dx;
		double_3 += dy;
		double_1 += dx;
		double_4 += dy;
		double_2 += dx;
		double_5 += dy;
	}

	public void imethod_2(Class4509 matrix)
	{
		matrix.method_0(double_0, double_3, out double_0, out double_3);
		matrix.method_0(double_1, double_4, out double_1, out double_4);
		matrix.method_0(double_2, double_5, out double_2, out double_5);
	}

	public object Clone()
	{
		return new Class4612(double_0, double_3, double_1, double_4, double_2, double_5);
	}
}
