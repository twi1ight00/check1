using ns135;
using ns137;

namespace ns158;

internal class Class4736 : Interface140, Interface141
{
	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	private double double_4;

	public double Y => double_0;

	public double DY => double_4;

	public double Ycorrected
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

	public double DeltaYCorrected
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

	public double DYcorrected
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

	public Class4736(double y, double dy)
	{
		double_0 = y;
		double_4 = dy;
		double_1 = y;
		double_2 = dy;
	}

	public bool imethod_0(double coordinate)
	{
		if (coordinate >= double_0 - Class4623.Instance.HintOwningPrecision && !(coordinate > double_0 + double_4 + Class4623.Instance.HintOwningPrecision))
		{
			return true;
		}
		if (coordinate <= double_0 + Class4623.Instance.HintOwningPrecision)
		{
			return coordinate >= double_0 + double_4 - Class4623.Instance.HintOwningPrecision;
		}
		return false;
	}

	public double imethod_1(double coordinate)
	{
		double num = coordinate + double_3;
		if (double_2 > 0.0)
		{
			if (num > double_1 + double_2)
			{
				num = double_1 + double_2 - Class4623.Instance.RasterizationGridPrecision;
			}
			else if (num < double_1)
			{
				num = double_1 + Class4623.Instance.RasterizationGridPrecision;
			}
		}
		else
		{
			if (num < double_1 + double_2)
			{
				num = double_1 + double_2 + Class4623.Instance.RasterizationGridPrecision;
			}
			if (num > double_1)
			{
				num = double_1 - Class4623.Instance.RasterizationGridPrecision;
			}
		}
		return num;
	}
}
