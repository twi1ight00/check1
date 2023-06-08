using System;

namespace ns99;

internal class Class4509 : ICloneable
{
	private double[] double_0;

	public double A
	{
		get
		{
			return double_0[0];
		}
		set
		{
			double_0[0] = value;
		}
	}

	public double B
	{
		get
		{
			return double_0[1];
		}
		set
		{
			double_0[1] = value;
		}
	}

	public double C
	{
		get
		{
			return double_0[2];
		}
		set
		{
			double_0[2] = value;
		}
	}

	public double D
	{
		get
		{
			return double_0[3];
		}
		set
		{
			double_0[3] = value;
		}
	}

	public double TX
	{
		get
		{
			return double_0[4];
		}
		set
		{
			double_0[4] = value;
		}
	}

	public double TY
	{
		get
		{
			return double_0[5];
		}
		set
		{
			double_0[5] = value;
		}
	}

	public double this[int index] => double_0[index];

	public Class4509()
	{
		double_0 = new double[6] { 1.0, 0.0, 0.0, 1.0, 0.0, 0.0 };
	}

	public Class4509(double[] matrixArray)
	{
		if (matrixArray.Length != 6)
		{
			throw new ArgumentException();
		}
		double_0 = matrixArray;
	}

	public void method_0(double x, double y, out double x1, out double y1)
	{
		x1 = A * x + C * y + TX;
		y1 = B * x + D * y + TY;
	}

	public void method_1(double x1, double y1, out double x, out double y)
	{
		x = (D * x1 - C * y1 + C * TY) / (A * D - C * B);
		y = (A * y1 - B * x1 + B * TX) / (A * D - C * B);
	}

	public void method_2(double x1, double y1, out double x, out double y)
	{
		x = (D * x1 - C * y1) / (A * D - C * B);
		y = (A * y1 - B * x1) / (A * D - C * B);
	}

	public void method_3(double x, double y, out double x1, out double y1)
	{
		x1 = A * x + C * y;
		y1 = B * x + D * y;
	}

	public Class4509 method_4(Class4509 matrix)
	{
		Class4509 @class = new Class4509();
		@class.A = A * matrix.A + B * matrix.C;
		@class.B = A * matrix.B + B * matrix.D;
		@class.C = C * matrix.A + D * matrix.C;
		@class.D = C * matrix.B + D * matrix.D;
		@class.TX = TX * matrix.A + TY * matrix.C + matrix.TX;
		@class.TY = TX * matrix.B + TY * matrix.D + matrix.TY;
		return @class;
	}

	public double[] ToArray()
	{
		return (double[])double_0.Clone();
	}

	object ICloneable.Clone()
	{
		return new Class4509((double[])double_0.Clone());
	}
}
