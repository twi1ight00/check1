using System;

namespace ns316;

internal class Class7180
{
	private double double_0 = 0.0625;

	private double double_1 = 1.0;

	private double double_2 = 0.65;

	private int int_0 = 4;

	public double StartFrequency
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

	public double StartAmplitude
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

	public double Persistance
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

	public int Octaves
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = Math.Max(1, value);
		}
	}

	public Class7180()
	{
	}

	public Class7180(double initFrequency, double initAmplitude, double persistance, int octaves)
	{
		double_0 = initFrequency;
		double_1 = initAmplitude;
		double_2 = persistance;
		int_0 = octaves;
	}

	public double method_0(double xaxis)
	{
		double num = double_0;
		double num2 = double_1;
		double num3 = 0.0;
		for (int i = 0; i < int_0; i++)
		{
			num3 += method_4(xaxis * num) * num2;
			num *= 2.0;
			num2 *= double_2;
		}
		return num3;
	}

	public double method_1(double xaxis, double yaxis)
	{
		double num = double_0;
		double num2 = double_1;
		double num3 = 0.0;
		for (int i = 0; i < int_0; i++)
		{
			num3 += method_6(xaxis * num, yaxis * num) * num2;
			num *= 2.0;
			num2 *= double_2;
		}
		return num3;
	}

	internal double method_2(int xaxis)
	{
		int num = (xaxis << 13) ^ xaxis;
		return 1.0 - (double)((num * (num * num * 15731 + 789221) + 1376312589) & 0x7FFFFFFF) / 1073741824.0;
	}

	internal double method_3(int xaxis, int yaxis)
	{
		int num = xaxis + yaxis * 57;
		num = (num << 13) ^ num;
		return 1.0 - (double)((num * (num * num * 15731 + 789221) + 1376312589) & 0x7FFFFFFF) / 1073741824.0;
	}

	internal double method_4(double xaxis)
	{
		int num = (int)xaxis;
		double c = xaxis - (double)num;
		return method_5(method_2(num), method_2(num + 1), c);
	}

	internal double method_5(double a, double b, double c)
	{
		double num = (1.0 - Math.Cos(c * Math.PI)) * 0.5;
		return a * (1.0 - num) + b * num;
	}

	internal double method_6(double xaxis, double yaxis)
	{
		int num = (int)xaxis;
		int num2 = (int)yaxis;
		double c = xaxis - (double)num;
		double c2 = yaxis - (double)num2;
		double a = method_3(num, num2);
		double b = method_3(num + 1, num2);
		double a2 = method_3(num, num2 + 1);
		double b2 = method_3(num + 1, num2 + 1);
		double a3 = method_5(a, b, c);
		double b3 = method_5(a2, b2, c);
		return method_5(a3, b3, c2);
	}
}
