using System;
using Aspose.Cells.Charts;
using ns22;

namespace ns27;

internal class Class716 : Class538
{
	internal Class716()
	{
		method_2(4127);
		method_0(42);
		byte_0 = new byte[42];
		byte_0[40] = 31;
		byte_0[41] = 1;
	}

	[Attribute0(true)]
	internal void method_4(Axis axis_0)
	{
		try
		{
			if (!axis_0.method_3())
			{
				double num = ((!(axis_0.MinValue is double)) ? ((DateTime)axis_0.MinValue).ToOADate() : ((double)axis_0.MinValue));
				if (axis_0.IsLogarithmic)
				{
					num = Math.Log10(num);
					num = smethod_0(num);
				}
				Array.Copy(BitConverter.GetBytes(num), byte_0, 8);
				byte_0[40] &= 254;
			}
			if (!axis_0.method_6())
			{
				double num2 = ((!(axis_0.MaxValue is double)) ? ((DateTime)axis_0.MaxValue).ToOADate() : ((double)axis_0.MaxValue));
				if (axis_0.IsLogarithmic)
				{
					num2 = Math.Log10(num2);
					num2 = method_5(num2);
				}
				Array.Copy(BitConverter.GetBytes(num2), 0, byte_0, 8, 8);
				byte_0[40] &= 253;
			}
			if (!axis_0.method_7())
			{
				double num3 = axis_0.MajorUnit;
				if (axis_0.IsLogarithmic)
				{
					num3 = Math.Log10(num3);
				}
				Array.Copy(BitConverter.GetBytes(num3), 0, byte_0, 16, 8);
				byte_0[40] &= 251;
			}
			if (!axis_0.method_9())
			{
				double num4 = axis_0.MinorUnit;
				if (axis_0.IsLogarithmic)
				{
					num4 = Math.Log10(num4);
				}
				Array.Copy(BitConverter.GetBytes(num4), 0, byte_0, 24, 8);
				byte_0[40] &= 247;
			}
			if (axis_0.CrossType == CrossType.Custom)
			{
				double num5 = axis_0.CrossAt;
				if (axis_0.IsLogarithmic)
				{
					num5 = Math.Log10(num5);
				}
				Array.Copy(BitConverter.GetBytes(num5), 0, byte_0, 32, 8);
				byte_0[40] &= 239;
			}
			else if (axis_0.CrossType == CrossType.Maximum)
			{
				byte_0[40] |= 128;
			}
			if (axis_0.IsLogarithmic)
			{
				byte_0[40] |= 32;
			}
			if (axis_0.IsPlotOrderReversed)
			{
				byte_0[40] |= 64;
			}
		}
		catch (Exception innerException)
		{
			Exception ex = new Exception("Negative or zero values cannot be plotted correctly on log charts.", innerException);
			throw ex;
		}
	}

	private double method_5(double double_0)
	{
		bool flag = true;
		if (double_0 < 0.0)
		{
			flag = false;
		}
		double_0 = Math.Abs(double_0);
		if (flag)
		{
			double num = (int)Math.Floor(double_0);
			if (num != double_0)
			{
				num += 1.0;
			}
			return num;
		}
		double num2 = (int)Math.Floor(double_0);
		return 0.0 - num2;
	}

	private static double smethod_0(double double_0)
	{
		bool flag = true;
		if (double_0 < 0.0)
		{
			flag = false;
		}
		double_0 = Math.Abs(double_0);
		if (!flag)
		{
			double num = (int)Math.Floor(double_0);
			if (num != double_0)
			{
				num += 1.0;
			}
			return 0.0 - num;
		}
		return (int)Math.Floor(double_0);
	}
}
