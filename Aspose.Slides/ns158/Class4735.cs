using ns135;
using ns137;

namespace ns158;

internal class Class4735 : Interface140, Interface141
{
	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	private double double_4;

	public double X => double_0;

	public double DX => double_1;

	public double Xcorrected
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

	public double DeltaXCorrected
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

	public double DXcorrected
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

	public Class4735(double x, double dx)
	{
		double_0 = x;
		double_1 = dx;
		double_2 = x;
		double_3 = dx;
	}

	public bool imethod_0(double coordinate)
	{
		if (coordinate >= double_0 - Class4623.Instance.HintOwningPrecision && !(coordinate > double_0 + double_1 + Class4623.Instance.HintOwningPrecision))
		{
			return true;
		}
		if (coordinate <= double_0 + Class4623.Instance.HintOwningPrecision)
		{
			return coordinate >= double_0 + double_1 - Class4623.Instance.HintOwningPrecision;
		}
		return false;
	}

	public double imethod_1(double coordinate)
	{
		double num = coordinate + double_4;
		if (double_3 > 0.0)
		{
			if (num > double_2 + double_3)
			{
				num = double_2 + double_3 - Class4623.Instance.RasterizationGridPrecision;
			}
			else if (num < double_2)
			{
				num = double_2 + Class4623.Instance.RasterizationGridPrecision;
			}
		}
		else
		{
			if (num < double_2 + double_3)
			{
				num = double_2 + double_3 + Class4623.Instance.RasterizationGridPrecision;
			}
			if (num > double_2)
			{
				num = double_2 - Class4623.Instance.RasterizationGridPrecision;
			}
		}
		return num;
	}
}
