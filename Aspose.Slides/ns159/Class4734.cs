using ns135;
using ns137;

namespace ns159;

internal class Class4734 : Interface140, Interface141
{
	private double[] double_0;

	private double[] double_1;

	private double double_2;

	private double double_3;

	public double[] BlueValues => double_0;

	public double[] OtherBlues => double_1;

	public double BlueScale => double_2;

	public double BlueShift => double_3;

	public Class4734(double[] blueValues, double[] otherBlues, double blueScale, double blueShift)
	{
		if (blueValues != null)
		{
			double_0 = (double[])blueValues.Clone();
		}
		if (otherBlues != null)
		{
			double_1 = (double[])otherBlues.Clone();
		}
		double_2 = blueScale;
		double_3 = blueShift;
	}

	public bool imethod_0(double coordinate)
	{
		int num = 0;
		while (true)
		{
			if (num < double_0.Length)
			{
				int num2 = num;
				int num3 = ++num;
				if ((coordinate >= double_0[num2] - Class4623.Instance.HintOwningPrecision2 && coordinate <= double_0[num3] + Class4623.Instance.HintOwningPrecision2) || (coordinate <= double_0[num2] + Class4623.Instance.HintOwningPrecision2 && !(coordinate < double_0[num3] - Class4623.Instance.HintOwningPrecision2)))
				{
					break;
				}
				num++;
				continue;
			}
			int num4 = 0;
			while (true)
			{
				if (num4 < double_1.Length)
				{
					int num5 = num4;
					int num6 = ++num4;
					if ((coordinate >= double_1[num5] - Class4623.Instance.HintOwningPrecision2 && coordinate <= double_1[num6] + Class4623.Instance.HintOwningPrecision2) || (coordinate <= double_1[num5] + Class4623.Instance.HintOwningPrecision2 && !(coordinate < double_1[num6] - Class4623.Instance.HintOwningPrecision2)))
					{
						break;
					}
					num4++;
					continue;
				}
				return false;
			}
			return true;
		}
		return true;
	}

	public double imethod_1(double coordinate)
	{
		return coordinate;
	}
}
