using System;

namespace ns39;

internal class Class934
{
	internal int int_0;

	internal double[] double_0;

	internal int int_1;

	internal bool bool_0;

	public double this[int int_2] => double_0[int_2];

	public Class934(int int_2, bool bool_1)
	{
		int_0 = int_2;
		bool_0 = bool_1;
		double_0 = new double[int_2];
	}

	public void Add(double double_1)
	{
		if (int_1 == 0)
		{
			double_0[int_1++] = double_1;
			return;
		}
		if (bool_0)
		{
			if (int_0 == 1)
			{
				if (double_0[0] < double_1)
				{
					double_0[0] = double_1;
				}
				return;
			}
			if (double_0[0] <= double_1)
			{
				Insert(0, double_1);
				return;
			}
			if (double_0[int_1 - 1] >= double_1)
			{
				if (int_1 != int_0)
				{
					double_0[int_1++] = double_1;
				}
				return;
			}
			if (int_1 == 2)
			{
				Insert(1, double_1);
				return;
			}
			int num = 1;
			int num2 = int_1 - 2;
			int num3 = 0;
			while (true)
			{
				if (num <= num2)
				{
					num3 = (num + num2) / 2;
					if (double_0[num3] == double_1)
					{
						break;
					}
					if (double_0[num3] > double_1)
					{
						num = num3 + 1;
					}
					else
					{
						num2 = num3 - 1;
					}
					continue;
				}
				if (double_0[num3] > double_1)
				{
					num3++;
				}
				Insert(num3, double_1);
				return;
			}
			Insert(num3, double_1);
			return;
		}
		if (int_0 == 1)
		{
			if (double_0[0] > double_1)
			{
				double_0[0] = double_1;
			}
			return;
		}
		if (double_0[0] >= double_1)
		{
			Insert(0, double_1);
			return;
		}
		if (double_0[int_1 - 1] <= double_1)
		{
			if (int_1 != int_0)
			{
				double_0[int_1++] = double_1;
			}
			return;
		}
		if (int_1 == 2)
		{
			Insert(1, double_1);
			return;
		}
		int num4 = 1;
		int num5 = int_1 - 2;
		int num6 = 0;
		while (true)
		{
			if (num4 <= num5)
			{
				num6 = (num4 + num5) / 2;
				if (double_0[num6] == double_1)
				{
					break;
				}
				if (double_0[num6] > double_1)
				{
					num5 = num6 - 1;
				}
				else
				{
					num4 = num6 + 1;
				}
				continue;
			}
			if (double_0[num6] < double_1)
			{
				num6++;
			}
			Insert(num6, double_1);
			return;
		}
		Insert(num6, double_1);
	}

	private void Insert(int int_2, double double_1)
	{
		if (int_1 == int_0)
		{
			Array.Copy(double_0, int_2, double_0, int_2 + 1, int_1 - int_2 - 1);
		}
		else
		{
			Array.Copy(double_0, int_2, double_0, int_2 + 1, int_1 - int_2);
			int_1++;
		}
		double_0[int_2] = double_1;
	}
}
