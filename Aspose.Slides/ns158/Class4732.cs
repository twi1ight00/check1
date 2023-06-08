using System;

namespace ns158;

internal class Class4732
{
	private bool bool_0;

	private double[][] double_0;

	private double[][] double_1;

	private int int_0;

	private int int_1;

	private int int_2;

	public bool IsRecording => bool_0;

	public double[][] ResultVerticalGroups => double_1;

	public double[][] ResultHorizontalGroups => double_0;

	public Class4732()
	{
		bool_0 = false;
	}

	public void method_0()
	{
		bool_0 = true;
		double_0 = null;
		double_1 = null;
	}

	public void method_1()
	{
		bool_0 = false;
	}

	public void method_2(double num)
	{
		if (double_0 == null)
		{
			int_0 = (int)num;
			double_0 = new double[int_0][];
		}
		else if (int_0 > 0)
		{
			double_0[double_0.Length - int_0][int_2] = Math.Abs(num);
			if (num < 0.0)
			{
				int_0--;
				int_2 = 0;
			}
		}
		else if (double_1 == null)
		{
			int_1 = (int)num;
			double_1 = new double[int_1][];
		}
		else if (int_1 > 0)
		{
			double_1[double_1.Length - int_1][int_2] = Math.Abs(num);
			if (num < 0.0)
			{
				int_1--;
				int_2 = 0;
			}
		}
	}
}
