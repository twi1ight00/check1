using System;
using System.Collections.Generic;

namespace ns33;

internal class Class1166
{
	public static double smethod_0(double[] polynomial, double argument)
	{
		double num = 0.0;
		double num2 = 1.0;
		int num3 = 0;
		while (num3 < polynomial.Length)
		{
			num += polynomial[num3] * num2;
			num3++;
			num2 *= argument;
		}
		return num;
	}

	public static int smethod_1(double[] polynomial)
	{
		int num = polynomial.Length - 1;
		while (num >= 0 && !(Math.Abs(polynomial[num]) > 0.0))
		{
			num--;
		}
		return num + 1;
	}

	public static double[] smethod_2(double[] polynomial)
	{
		int num = smethod_1(polynomial);
		if (num == polynomial.Length)
		{
			return polynomial;
		}
		double[] array = new double[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = polynomial[i];
		}
		return array;
	}

	public static double[] smethod_3(double[] polynomial)
	{
		int num = smethod_1(polynomial);
		if (num == polynomial.Length)
		{
			return (double[])polynomial.Clone();
		}
		double[] array = new double[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = polynomial[i];
		}
		return array;
	}

	public static double[] smethod_4(double[] polynomial)
	{
		int num = smethod_1(polynomial);
		double[] array = new double[num - 1];
		for (int i = 1; i < num; i++)
		{
			array[i - 1] = polynomial[i] * (double)i;
		}
		return array;
	}

	public static double[] smethod_5(double[] dividend, double[] divisor, out double[] remainder)
	{
		double[] array = smethod_3(dividend);
		double[] array2 = smethod_2(divisor);
		int num = array.Length - array2.Length + 1;
		if (num <= 0)
		{
			remainder = array;
			return new double[0];
		}
		double[] array3 = new double[num];
		for (int num2 = num - 1; num2 >= 0; num2--)
		{
			array3[num2] = array[num2 + array2.Length - 1] / array2[array2.Length - 1];
			for (int i = 0; i < array2.Length; i++)
			{
				array[num2 + i] -= array2[i] * array3[num2];
			}
			array[num2 + array2.Length - 1] = 0.0;
		}
		remainder = smethod_2(array);
		return array3;
	}

	public static double[][] smethod_6(double[] polynomial)
	{
		int num = smethod_1(polynomial);
		if (num < polynomial.Length)
		{
			double[] array = polynomial;
			polynomial = new double[num];
			for (int i = 0; i < num; i++)
			{
				polynomial[i] = array[i];
			}
		}
		double[][] array2 = new double[num][];
		array2[0] = polynomial;
		if (num > 1)
		{
			array2[1] = smethod_4(polynomial);
		}
		int j;
		for (j = 1; j < array2.Length - 1 && array2[j].Length > 1; j++)
		{
			smethod_5(array2[j - 1], array2[j], out array2[j + 1]);
			for (int k = 0; k < array2[j + 1].Length; k++)
			{
				array2[j + 1][k] = 0.0 - array2[j + 1][k];
			}
		}
		if (j < array2.Length && array2[j].Length > 0)
		{
			j++;
		}
		if (j < array2.Length)
		{
			double[][] array3 = array2;
			array2 = new double[j][];
			for (int l = 0; l < j; l++)
			{
				array2[l] = array3[l];
			}
		}
		return array2;
	}

	public static int smethod_7(double[][] sturmSequence)
	{
		int i = 0;
		int num = 0;
		for (; i < sturmSequence.Length; i++)
		{
			num = sturmSequence[i].Length - 1;
			if (sturmSequence[i][num] < 0.0 || sturmSequence[i][num] > 0.0)
			{
				break;
			}
		}
		int num2 = 0;
		int num3 = i;
		int num4 = num;
		if (i < sturmSequence.Length)
		{
			for (int j = num3 + 1; j < sturmSequence.Length; j++)
			{
				int num5 = sturmSequence[j].Length - 1;
				if (sturmSequence[j][num5] != 0.0 && sturmSequence[j][num5] * sturmSequence[num3][num4] > 0.0 == (((num4 ^ num5) & 1) == 1))
				{
					num3 = j;
					num4 = num5;
					num2++;
				}
			}
		}
		int num6 = 0;
		num3 = i;
		num4 = num;
		if (i < sturmSequence.Length)
		{
			for (int k = num3 + 1; k < sturmSequence.Length; k++)
			{
				int num7 = sturmSequence[k].Length - 1;
				if (sturmSequence[k][num7] != 0.0 && sturmSequence[k][num7] * sturmSequence[num3][num4] < 0.0)
				{
					num3 = k;
					num4 = num7;
					num6++;
				}
			}
		}
		return num2 - num6;
	}

	public static int smethod_8(double[][] sturmSequence, double intervalBegin, double intervalEnd)
	{
		int num = 0;
		int num2 = 0;
		double num3 = 0.0;
		foreach (double[] polynomial in sturmSequence)
		{
			double num4 = smethod_0(polynomial, intervalBegin);
			if (num4 * num3 < -1E-05)
			{
				num3 = num4;
				num++;
			}
			if (num3 == 0.0)
			{
				num3 = num4;
			}
		}
		num3 = 0.0;
		foreach (double[] polynomial2 in sturmSequence)
		{
			double num5 = smethod_0(polynomial2, intervalEnd);
			if (num5 * num3 < -1E-05)
			{
				num3 = num5;
				num2++;
			}
			if (num3 == 0.0)
			{
				num3 = num5;
			}
		}
		return num - num2;
	}

	public static double[] smethod_9(double[] polynomialEquation, double beginInterval, double endInterval)
	{
		double num = 1E-08;
		double num2 = 0.001;
		List<double> list = new List<double>();
		double[] remainder;
		while (smethod_0(polynomialEquation, beginInterval) == 0.0)
		{
			polynomialEquation = smethod_5(polynomialEquation, new double[2]
			{
				0.0 - beginInterval,
				1.0
			}, out remainder);
			list.Add(beginInterval);
		}
		while (smethod_0(polynomialEquation, endInterval) == 0.0)
		{
			polynomialEquation = smethod_5(polynomialEquation, new double[2]
			{
				0.0 - endInterval,
				1.0
			}, out remainder);
			list.Add(endInterval);
		}
		double[][] array = smethod_6(polynomialEquation);
		for (int num3 = smethod_8(array, beginInterval, endInterval); num3 > 0; num3 = smethod_8(array, beginInterval, endInterval))
		{
			double[] polynomial = array[1];
			double num4 = (beginInterval + endInterval) / 2.0;
			double num5 = 1E+300;
			double num6 = 0.0;
			do
			{
				num6 = num5;
				num5 = (0.0 - smethod_0(polynomialEquation, num4)) / smethod_0(polynomial, num4);
				num4 += num5;
			}
			while (!(Math.Abs(num6) < Math.Abs(num5)) && !(Math.Abs(num5) < num));
			if (!(Math.Abs(num5) < num) || !(Math.Abs(smethod_0(polynomialEquation, num4)) < num2))
			{
				break;
			}
			do
			{
				polynomialEquation = smethod_5(polynomialEquation, new double[2]
				{
					0.0 - num4,
					1.0
				}, out remainder);
				if (beginInterval <= num4 && num4 <= endInterval)
				{
					list.Add(num4);
				}
			}
			while (Math.Abs(smethod_0(polynomialEquation, num4)) < num2);
			array = smethod_6(polynomialEquation);
		}
		list.Sort();
		return list.ToArray();
	}

	public static double smethod_10(double[,] matrix)
	{
		if (matrix.GetUpperBound(0) - matrix.GetLowerBound(0) != matrix.GetUpperBound(1) - matrix.GetLowerBound(1))
		{
			return 0.0;
		}
		double num = 0.001;
		double[,] array = (double[,])matrix.Clone();
		int lowerBound = array.GetLowerBound(0);
		int upperBound = array.GetUpperBound(0);
		int lowerBound2 = array.GetLowerBound(1);
		int upperBound2 = array.GetUpperBound(1);
		int num2 = upperBound - lowerBound + 1;
		double num3 = 1.0;
		int num4 = 0;
		while (true)
		{
			if (num4 < num2)
			{
				if (Math.Abs(array[lowerBound + num4, lowerBound2 + num4]) < num)
				{
					for (int i = num4 + 1; i < num2; i++)
					{
						if (!(Math.Abs(array[lowerBound + i, lowerBound2 + num4]) < num))
						{
							num3 = 0.0 - num3;
							for (int j = lowerBound2; j <= upperBound2; j++)
							{
								double num5 = array[lowerBound + num4, j];
								array[lowerBound + num4, j] = array[lowerBound + i, j];
								array[lowerBound + i, j] = num5;
							}
							break;
						}
					}
				}
				if (!(Math.Abs(array[lowerBound + num4, lowerBound2 + num4]) >= num))
				{
					break;
				}
				double num6 = array[lowerBound + num4, lowerBound2 + num4];
				for (int k = 0; k < num2; k++)
				{
					if (num4 != k)
					{
						double num7 = array[lowerBound + k, lowerBound2 + num4] / num6;
						for (int l = lowerBound2; l <= upperBound2; l++)
						{
							array[lowerBound + k, l] -= array[lowerBound + num4, l] * num7;
						}
					}
				}
				num3 *= num6;
				num4++;
				continue;
			}
			return num3;
		}
		return 0.0;
	}
}
