using System;
using ns137;
using ns99;

namespace ns138;

internal class Class4611 : ICloneable, Interface143
{
	private double double_0;

	private double double_1;

	private Class4609 class4609_0;

	public double X
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

	public double Y
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

	public Class4611(double x, double y)
	{
		double_0 = x;
		double_1 = y;
	}

	public Interface143 imethod_0()
	{
		return new Class4611(double_0, double_1);
	}

	public void imethod_1(double dx, double dy)
	{
		double_0 += dx;
		double_1 += dy;
	}

	public void imethod_2(Class4509 matrix)
	{
		matrix.method_0(double_0, double_1, out double_0, out double_1);
	}

	public object Clone()
	{
		return new Class4611(double_0, double_1);
	}
}
