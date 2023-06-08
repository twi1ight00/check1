using System;
using System.Collections;

namespace ns166;

internal class Class4816
{
	internal static double smethod_0(ArrayList observations)
	{
		if (observations != null && observations.Count != 0)
		{
			double num = 0.0;
			foreach (double observation in observations)
			{
				num += observation;
			}
			return num / (double)observations.Count;
		}
		return 0.0;
	}

	internal static void smethod_1(ArrayList observations, out double mean, out double std)
	{
		if (observations != null && observations.Count != 0)
		{
			ArrayList arrayList = new ArrayList(observations.Count);
			foreach (double observation in observations)
			{
				arrayList.Add(observation * observation);
			}
			mean = smethod_0(observations);
			double num2 = ((observations.Count - 1 != 0) ? ((double)(observations.Count / (observations.Count - 1))) : double.MaxValue);
			std = Math.Sqrt((smethod_0(arrayList) - mean * mean) * num2);
		}
		else
		{
			mean = 0.0;
			std = 0.0;
		}
	}

	internal static double smethod_2(ArrayList observations, out double mean, out double std)
	{
		smethod_1(observations, out mean, out std);
		if (mean != 0.0)
		{
			return std / mean;
		}
		return 1.0;
	}
}
