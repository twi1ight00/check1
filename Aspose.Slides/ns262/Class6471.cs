using System;

namespace ns262;

internal class Class6471 : Interface300
{
	private double double_0;

	private double double_1;

	private double double_2;

	public double Ascent
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

	public double LineSpacing
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

	public double Descent
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

	public double Height => double_0 + double_1;

	public Class6471()
	{
	}

	public Class6471(double ascent, double descent, double lineSpacing)
	{
		double_0 = ascent;
		double_1 = descent;
		double_2 = lineSpacing;
	}

	public void Add(Interface300 measurement)
	{
		double_0 = Math.Max(double_0, measurement.Ascent);
		double_1 = Math.Max(double_1, measurement.Descent);
		double_2 = Math.Max(double_2, measurement.LineSpacing);
	}

	public void Reset()
	{
		double_0 = 0.0;
		double_1 = 0.0;
		double_2 = 0.0;
	}
}
