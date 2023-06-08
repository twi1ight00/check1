using System.Collections;

namespace ns166;

internal class Class4812
{
	internal static double smethod_0(ArrayList observations, out int index)
	{
		if (observations != null && observations.Count != 0)
		{
			index = -1;
			double num = double.NegativeInfinity;
			for (int i = 0; i < observations.Count; i++)
			{
				if ((double)observations[i] > num)
				{
					num = (double)observations[i];
					index = i;
				}
			}
			return num;
		}
		index = -1;
		return double.NegativeInfinity;
	}

	internal static double smethod_1(double[] observations, out int index)
	{
		if (observations != null && observations.Length != 0)
		{
			index = -1;
			double num = double.NegativeInfinity;
			for (int i = 0; i < observations.Length; i++)
			{
				if (observations[i] > num)
				{
					num = observations[i];
					index = i;
				}
			}
			return num;
		}
		index = -1;
		return double.NegativeInfinity;
	}

	internal static double smethod_2(ArrayList observations)
	{
		int index;
		return smethod_0(observations, out index);
	}

	internal static double smethod_3(ArrayList observations)
	{
		int index;
		return smethod_4(observations, out index);
	}

	internal static double smethod_4(ArrayList observations, out int index)
	{
		if (observations != null && observations.Count != 0)
		{
			index = -1;
			double num = double.PositiveInfinity;
			for (int i = 0; i < observations.Count; i++)
			{
				if ((double)observations[i] < num)
				{
					num = (double)observations[i];
					index = i;
				}
			}
			return num;
		}
		index = -1;
		return double.PositiveInfinity;
	}

	internal static double smethod_5(double[] observations, out int index)
	{
		if (observations != null && observations.Length != 0)
		{
			index = -1;
			double num = double.PositiveInfinity;
			for (int i = 0; i < observations.Length; i++)
			{
				if (observations[i] < num)
				{
					num = observations[i];
					index = i;
				}
			}
			return num;
		}
		index = -1;
		return double.PositiveInfinity;
	}
}
