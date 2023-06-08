using System;

namespace ns3;

internal class Class862
{
	internal static object[][] smethod_0(double[] double_0, double[][] double_1)
	{
		object[][] array = new object[5][];
		int num = double_0.Length;
		int num2 = double_1[0].Length;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		for (int i = 0; i < 5; i++)
		{
			array[i] = new object[num2 + 1];
		}
		double[] array2 = new double[num2];
		for (int j = 0; j < num2; j++)
		{
			double num6 = 0.0;
			for (int k = 0; k < num; k++)
			{
				num6 += double_1[k][j];
			}
			array2[j] = num6 / (double)num;
		}
		for (int l = 0; l < num; l++)
		{
			num5 += double_0[l];
		}
		num5 /= (double)num;
		double[][] array3 = new double[num2][];
		for (int m = 0; m < num2; m++)
		{
			array3[m] = new double[num2];
			for (int n = 0; n < num2; n++)
			{
				double num7 = 0.0;
				for (int num8 = 0; num8 < num; num8++)
				{
					num7 += (double_1[num8][m] - array2[m]) * (double_1[num8][n] - array2[n]);
				}
				array3[m][n] = num7;
			}
		}
		double[] array4 = new double[num2];
		for (int num9 = 0; num9 < num2; num9++)
		{
			array4[num9] = 0.0;
			for (int num10 = 0; num10 < num; num10++)
			{
				array4[num9] += (double_1[num10][num9] - array2[num9]) * (double_0[num10] - num5);
			}
		}
		double[][] array5 = new double[num2][];
		for (int num11 = 0; num11 < num2; num11++)
		{
			array5[num11] = new double[num2 + 1];
			for (int num12 = 0; num12 < num2; num12++)
			{
				array5[num11][num12] = array3[num11][num12];
			}
			array5[num11][num2] = array4[num11];
		}
		double[] array6 = smethod_2(array5);
		int num13 = 0;
		int num14 = array6.Length - 1;
		while (num14 >= 0 && array6[num14] == 0.0)
		{
			num13++;
			num14--;
		}
		double num15 = num5;
		for (int num16 = 0; num16 < array2.Length; num16++)
		{
			num15 -= array6[num16] * array2[num16];
		}
		for (int num17 = 0; num17 < num2; num17++)
		{
			array[0][num17] = array6[num2 - num17 - 1];
		}
		array[0][num2] = num15;
		if (num13 == array6.Length)
		{
			for (int num18 = 0; num18 < num2; num18++)
			{
				array[1][num18] = 0.0;
			}
			array[2][0] = 1.0;
			array[2][1] = 0.0;
			array[3][0] = Enum55.const_5;
			array[3][1] = (double)(num - num2);
			array[4][0] = 0.0;
			array[4][1] = 0.0;
			return array;
		}
		double[] array7 = new double[num];
		for (int num19 = 0; num19 < num; num19++)
		{
			array7[num19] = 0.0;
			for (int num20 = 0; num20 < num2; num20++)
			{
				double num21 = (double)array[0][num2 - num20 - 1];
				array7[num19] += num21 * double_1[num19][num20];
			}
			array7[num19] += (double)array[0][num2];
		}
		for (int num22 = 0; num22 < num; num22++)
		{
			num3 += (double_0[num22] - array7[num22]) * (double_0[num22] - array7[num22]);
			num4 += (num5 - array7[num22]) * (num5 - array7[num22]);
		}
		double num23 = num - num2 - 1 + num13;
		double num24 = num3 / num23;
		double num25 = Math.Sqrt(num24);
		array[2][1] = num25;
		double[][] array8 = new double[double_1.Length][];
		for (int num26 = 0; num26 < double_1.Length; num26++)
		{
			array8[num26] = new double[double_1[num26].Length + 1];
			for (int num27 = 0; num27 < double_1[num26].Length + 1; num27++)
			{
				if (num27 == 0)
				{
					array8[num26][num27] = 1.0;
				}
				else
				{
					array8[num26][num27] = double_1[num26][num27 - 1];
				}
			}
		}
		double[][] double_2 = smethod_4(array8);
		double[][] double_3 = smethod_5(double_2, array8);
		double[][] array9 = smethod_3(double_3);
		for (int num28 = 0; num28 < array9.Length; num28++)
		{
			for (int num29 = 0; num29 < array9[num28].Length; num29++)
			{
				if (num28 == num29)
				{
					double d = array9[num28][num29] * num24;
					d = Math.Sqrt(d);
					array[1][array9.Length - num28 - 1] = d;
				}
			}
		}
		double num30 = num4 / (double)(num2 - num13) / num24;
		array[3][0] = num30;
		array[3][1] = num23;
		array[4][0] = num4;
		array[4][1] = num3;
		double num31 = num4 / (num4 + num3);
		array[2][0] = num31;
		return array;
	}

	internal static object[][] smethod_1(double[] double_0, double[][] double_1)
	{
		object[][] array = new object[5][];
		int num = double_0.Length;
		int num2 = double_1[0].Length;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		for (int i = 0; i < 5; i++)
		{
			array[i] = new object[num2 + 1];
		}
		double[] array2 = new double[num2];
		for (int j = 0; j < num2; j++)
		{
			double num6 = 0.0;
			for (int k = 0; k < num; k++)
			{
				num6 += double_1[k][j];
			}
			array2[j] = num6 / (double)num;
		}
		for (int l = 0; l < num; l++)
		{
			num5 += double_0[l];
		}
		num5 /= (double)num;
		double[][] array3 = new double[num2][];
		for (int m = 0; m < num2; m++)
		{
			array3[m] = new double[num2];
			for (int n = 0; n < num2; n++)
			{
				double num7 = 0.0;
				for (int num8 = 0; num8 < num; num8++)
				{
					num7 += double_1[num8][n] * double_1[num8][m];
				}
				array3[m][n] = num7;
			}
		}
		double[] array4 = new double[num2];
		for (int num9 = 0; num9 < num2; num9++)
		{
			array4[num9] = 0.0;
			for (int num10 = 0; num10 < num; num10++)
			{
				array4[num9] += double_0[num10] * double_1[num10][num9];
			}
		}
		double[][] array5 = new double[num2][];
		for (int num11 = 0; num11 < num2; num11++)
		{
			array5[num11] = new double[num2 + 1];
			for (int num12 = 0; num12 < num2; num12++)
			{
				array5[num11][num12] = array3[num11][num12];
			}
			array5[num11][num2] = array4[num11];
		}
		double[] array6 = smethod_2(array5);
		double num13 = 0.0;
		for (int num14 = 0; num14 < num2; num14++)
		{
			array[0][num14] = array6[num2 - num14 - 1];
		}
		array[0][num2] = num13;
		double[] array7 = new double[num];
		for (int num15 = 0; num15 < num; num15++)
		{
			array7[num15] = 0.0;
			for (int num16 = 0; num16 < num2; num16++)
			{
				double num17 = (double)array[0][num2 - num16 - 1];
				array7[num15] += num17 * double_1[num15][num16];
			}
			array7[num15] += (double)array[0][num2];
		}
		for (int num18 = 0; num18 < num; num18++)
		{
			num3 += (double_0[num18] - array7[num18]) * (double_0[num18] - array7[num18]);
			num4 += (num5 - array7[num18]) * (num5 - array7[num18]);
		}
		double num19 = num - num2 - 1;
		double num20 = num3 / num19;
		double num21 = Math.Sqrt(num20);
		array[2][1] = num21;
		double[][] array8 = new double[double_1.Length][];
		for (int num22 = 0; num22 < double_1.Length; num22++)
		{
			array8[num22] = new double[double_1[num22].Length + 1];
			for (int num23 = 0; num23 < double_1[num22].Length + 1; num23++)
			{
				if (num23 == 0)
				{
					array8[num22][num23] = 1.0;
				}
				else
				{
					array8[num22][num23] = double_1[num22][num23 - 1];
				}
			}
		}
		double[][] double_2 = smethod_4(array8);
		double[][] double_3 = smethod_5(double_2, array8);
		double[][] array9 = smethod_3(double_3);
		for (int num24 = 0; num24 < array9.Length; num24++)
		{
			for (int num25 = 0; num25 < array9[num24].Length; num25++)
			{
				if (num24 == num25)
				{
					double d = array9[num24][num25] * num20;
					d = Math.Sqrt(d);
					array[1][array9.Length - num24 - 1] = d;
				}
			}
		}
		double num26 = num4 / (double)num2 / num20;
		array[3][0] = num26;
		array[3][1] = num19;
		array[4][0] = num4;
		array[4][1] = num3;
		double num27 = num4 / (num4 + num3);
		array[2][0] = num27;
		return array;
	}

	private static double[] smethod_2(double[][] double_0)
	{
		if (double_0 == null)
		{
			return null;
		}
		int num = double_0.Length;
		int num2 = double_0[0].Length;
		double[] array = new double[num];
		int num3 = 0;
		for (num3 = 0; num3 < num; num3++)
		{
			int num4 = num3;
			double num5 = double_0[num3][num3];
			for (int i = num3 + 1; i < num; i++)
			{
				if (Math.Abs(num5) < Math.Abs(double_0[i][num3]))
				{
					num5 = double_0[i][num3];
					num4 = i;
				}
			}
			if (num3 != num4)
			{
				for (int j = 0; j < num2; j++)
				{
					double num6 = double_0[num3][j];
					double_0[num3][j] = double_0[num4][j];
					double_0[num4][j] = num6;
				}
			}
			for (int k = num3 + 1; k < num; k++)
			{
				if (double_0[k][num3] == 0.0)
				{
					continue;
				}
				double num7 = 0.0 - double_0[k][num3] / num5;
				for (int l = num3; l < num2; l++)
				{
					double_0[k][l] = double_0[k][l] + double_0[num3][l] * num7;
					if (Math.Abs(double_0[k][l]) < 5E-14)
					{
						double_0[k][l] = 0.0;
					}
				}
			}
		}
		for (num3 = num - 1; num3 >= 0; num3--)
		{
			if (num3 == num - 1)
			{
				if (Math.Abs(double_0[num3][num3]) < 5E-14)
				{
					array[num3] = 0.0;
				}
				else
				{
					array[num3] = double_0[num3][num2 - 1] / double_0[num3][num3];
				}
			}
			else if (Math.Abs(double_0[num3][num3]) < 5E-14)
			{
				array[num3] = 0.0;
			}
			else
			{
				double num8 = 0.0;
				for (int m = num3 + 1; m < num2 - 1; m++)
				{
					num8 += double_0[num3][m] * array[m];
				}
				array[num3] = (double_0[num3][num2 - 1] - num8) / double_0[num3][num3];
			}
		}
		return array;
	}

	internal static double[][] smethod_3(double[][] double_0)
	{
		double[][] array = new double[double_0.Length][];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new double[double_0[0].Length + double_0[0].Length];
			for (int j = 0; j < array[i].Length; j++)
			{
				if (j < double_0[0].Length)
				{
					array[i][j] = double_0[i][j];
				}
				else if (j == i + double_0[0].Length)
				{
					array[i][j] = 1.0;
				}
			}
		}
		int num = array.Length;
		int num2 = array[0].Length;
		int num3 = 1;
		do
		{
			double num4 = Math.Abs(array[num3 - 1][num3 - 1]);
			int num5 = num3 - 1;
			for (int k = num3 - 1; k < num; k++)
			{
				if (Math.Abs(array[k][num3 - 1]) > num4)
				{
					num4 = Math.Abs(array[k][num3 - 1]);
					num5 = k;
				}
			}
			if (num5 != num3 - 1)
			{
				for (int l = 0; l < num2; l++)
				{
					double num6 = array[num3 - 1][l];
					array[num3 - 1][l] = array[num5][l];
					array[num5][l] = num6;
				}
			}
			for (int m = num3; m < num; m++)
			{
				if (array[num3 - 1][num3 - 1] != 0.0)
				{
					double num7 = array[m][num3 - 1] / array[num3 - 1][num3 - 1];
					for (int n = 0; n < num2; n++)
					{
						array[m][n] -= num7 * array[num3 - 1][n];
					}
					continue;
				}
				return null;
			}
			num3++;
		}
		while (num3 <= array.Length);
		num3 = array.Length - 2;
		do
		{
			int num8 = num3;
			while (num8 >= 0)
			{
				if (array[num3 + 1][num3 + 1] != 0.0)
				{
					double num9 = array[num8][num3 + 1] / array[num3 + 1][num3 + 1];
					if (Math.Abs(array[num3 + 1][num3 + 1]) < 5E-14)
					{
						num9 = 0.0;
					}
					for (int num10 = 0; num10 < num2; num10++)
					{
						array[num8][num10] -= num9 * array[num3 + 1][num10];
					}
					num8--;
					continue;
				}
				return null;
			}
			num3--;
		}
		while (num3 >= 0);
		for (int num11 = 0; num11 < num; num11++)
		{
			double num12 = array[num11][num11];
			if (Math.Abs(num12) < 5E-14)
			{
				for (int num13 = 0; num13 < num2; num13++)
				{
					array[num11][num13] = 0.0;
				}
			}
			else
			{
				for (int num14 = 0; num14 < num2; num14++)
				{
					array[num11][num14] /= num12;
				}
			}
		}
		double[][] array2 = new double[double_0.Length][];
		for (int num15 = 0; num15 < num; num15++)
		{
			array2[num15] = new double[num];
			for (int num16 = 0; num16 < num; num16++)
			{
				array2[num15][num16] = array[num15][num16 + num];
			}
		}
		return array2;
	}

	internal static double[][] smethod_4(double[][] double_0)
	{
		if (double_0 == null)
		{
			return null;
		}
		int num = double_0.Length;
		int num2 = double_0[0].Length;
		double[][] array = new double[num2][];
		for (int i = 0; i < num2; i++)
		{
			array[i] = new double[num];
		}
		for (int j = 0; j < num2; j++)
		{
			for (int k = 0; k < num; k++)
			{
				array[j][k] = double_0[k][j];
			}
		}
		return array;
	}

	internal static double[][] smethod_5(double[][] double_0, double[][] double_1)
	{
		if (double_0 != null && double_1 != null)
		{
			int num = double_0.Length;
			int num2 = double_0[0].Length;
			int num3 = double_1[0].Length;
			double[][] array = new double[num][];
			for (int i = 0; i < num; i++)
			{
				array[i] = new double[num3];
			}
			for (int j = 0; j < num; j++)
			{
				for (int k = 0; k < num3; k++)
				{
					array[j][k] = 0.0;
					for (int l = 0; l < num2; l++)
					{
						array[j][k] += double_0[j][l] * double_1[l][k];
					}
				}
			}
			return array;
		}
		return null;
	}
}
