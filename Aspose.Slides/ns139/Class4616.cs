using System;
using ns138;

namespace ns139;

internal class Class4616 : Class4615, ICloneable
{
	public int int_0;

	public ushort[] ushort_0;

	public byte[] byte_0;

	public int int_1;

	public double[] double_0;

	public double[] double_1;

	public bool[] bool_0;

	public bool[] bool_1;

	public byte[] byte_1;

	private Class4616()
	{
	}

	public static Class4616 smethod_0()
	{
		Class4616 @class = new Class4616();
		@class.int_0 = 0;
		@class.ushort_0 = new ushort[@class.int_0];
		@class.byte_0 = new byte[@class.int_0];
		@class.int_1 = 0;
		@class.double_0 = new double[@class.int_0];
		@class.double_1 = new double[@class.int_0];
		@class.bool_0 = new bool[@class.int_0];
		@class.bool_1 = new bool[@class.int_0];
		@class.byte_1 = new byte[@class.int_0];
		return @class;
	}

	public static Class4616 smethod_1()
	{
		return new Class4616();
	}

	public object Clone()
	{
		Class4616 @class = new Class4616();
		@class.ushort_0 = new ushort[ushort_0.Length];
		@class.byte_0 = new byte[byte_0.Length];
		@class.double_0 = new double[double_0.Length];
		@class.double_1 = new double[double_1.Length];
		@class.byte_1 = new byte[byte_1.Length];
		@class.bool_0 = new bool[bool_0.Length];
		@class.bool_1 = new bool[bool_1.Length];
		Buffer.BlockCopy(ushort_0, 0, @class.ushort_0, 0, ushort_0.Length * 2);
		Buffer.BlockCopy(byte_0, 0, @class.byte_0, 0, byte_0.Length);
		Buffer.BlockCopy(double_0, 0, @class.double_0, 0, double_0.Length * 8);
		Buffer.BlockCopy(double_1, 0, @class.double_1, 0, double_1.Length * 8);
		Buffer.BlockCopy(bool_0, 0, @class.bool_0, 0, bool_0.Length);
		Buffer.BlockCopy(bool_1, 0, @class.bool_1, 0, bool_1.Length);
		@class.int_1 = int_1;
		@class.int_0 = int_0;
		return @class;
	}

	public override Class4618 vmethod_0()
	{
		Class4618 @class = base.vmethod_0();
		double num = 0.0;
		double num2 = 0.0;
		int num3 = -1;
		for (int i = 0; i < int_1; i++)
		{
			byte_0[i] &= 1;
		}
		for (int j = 0; j < ushort_0.Length; j++)
		{
			double x = 0.0;
			double y = 0.0;
			bool flag = false;
			for (int k = num3 + 1; k <= ushort_0[j]; k++)
			{
				if (k == num3 + 1 && !flag)
				{
					if ((byte_0[k] & 1) == 0 && ((uint)byte_0[ushort_0[j]] & (true ? 1u : 0u)) != 0)
					{
						num = double_0[ushort_0[j]];
						num2 = double_1[ushort_0[j]];
						x = num;
						y = num2;
						@class.Segments.Add(new Class4614(num, num2));
						k--;
					}
					else
					{
						num = double_0[k];
						num2 = double_1[k];
						x = num;
						y = num2;
						@class.Segments.Add(new Class4614(num, num2));
					}
					flag = true;
					continue;
				}
				if (((uint)byte_0[k] & (true ? 1u : 0u)) != 0)
				{
					num = double_0[k];
					num2 = double_1[k];
					@class.Segments.Add(new Class4613(num, num2));
					continue;
				}
				int num4 = k - 1;
				int num5 = ((num4 == num3) ? ushort_0[j] : num4);
				int num6 = 0;
				int num7 = 0;
				while (true)
				{
					if (k != ushort_0[j] + 1)
					{
						if ((byte_0[k] & 1) == 0)
						{
							k++;
							num7++;
							continue;
						}
						num6 = k;
						break;
					}
					num6 = num3 + 1;
					break;
				}
				switch (num7)
				{
				case 0:
					num = double_0[num6];
					num2 = double_1[num6];
					@class.Segments.Add(new Class4613(num, num2));
					continue;
				case 1:
					num = double_0[num6];
					num2 = double_1[num6];
					@class.Segments.Add(new Class4612((double_0[num5] + 2.0 * double_0[num4 + 1]) / 3.0, (double_1[num5] + 2.0 * double_1[num4 + 1]) / 3.0, (2.0 * double_0[num4 + 1] + double_0[num6]) / 3.0, (2.0 * double_1[num4 + 1] + double_1[num6]) / 3.0, num, num2));
					continue;
				case 2:
					num = double_0[num6];
					num2 = double_1[num6];
					@class.Segments.Add(new Class4612((0.0 - double_0[num5] + 4.0 * double_0[num4 + 1]) / 3.0, (0.0 - double_1[num5] + 4.0 * double_1[num4 + 1]) / 3.0, (4.0 * double_0[num4 + 2] - double_0[num6]) / 3.0, (4.0 * double_1[num4 + 2] - double_1[num6]) / 3.0, double_0[num6], double_1[num6]));
					continue;
				case 3:
					@class.Segments.Add(new Class4612((double_0[num5] + 2.0 * double_0[num4 + 1]) / 3.0, (double_1[num5] + 2.0 * double_1[num4 + 1]) / 3.0, (5.0 * double_0[num4 + 1] + double_0[num4 + 2]) / 6.0, (5.0 * double_1[num4 + 1] + double_1[num4 + 2]) / 6.0, (double_0[num4 + 1] + double_0[num4 + 2]) / 2.0, (double_1[num4 + 1] + double_1[num4 + 2]) / 2.0));
					@class.Segments.Add(new Class4612((double_0[num4 + 1] + 5.0 * double_0[num4 + 2]) / 6.0, (double_1[num4 + 1] + 5.0 * double_1[num4 + 2]) / 6.0, (5.0 * double_0[num4 + 2] + double_0[num4 + 3]) / 6.0, (5.0 * double_1[num4 + 2] + double_1[num4 + 3]) / 6.0, (double_0[num4 + 3] + double_0[num4 + 2]) / 2.0, (double_1[num4 + 3] + double_1[num4 + 2]) / 2.0));
					num = double_0[num6];
					num2 = double_1[num6];
					@class.Segments.Add(new Class4612((double_0[num4 + 2] + 5.0 * double_0[num4 + 3]) / 6.0, (double_1[num4 + 2] + 5.0 * double_1[num4 + 3]) / 6.0, (2.0 * double_0[num4 + 3] + double_0[num6]) / 3.0, (2.0 * double_1[num4 + 3] + double_1[num6]) / 3.0, num, num2));
					continue;
				}
				int num8 = num4 + num7;
				@class.Segments.Add(new Class4612((double_0[num5] + 2.0 * double_0[num4 + 1]) / 3.0, (double_1[num5] + 2.0 * double_1[num4 + 1]) / 3.0, (5.0 * double_0[num4 + 1] + double_0[num4 + 2]) / 6.0, (5.0 * double_1[num4 + 1] + double_1[num4 + 2]) / 6.0, (double_0[num4 + 1] + double_0[num4 + 2]) / 2.0, (double_1[num4 + 1] + double_1[num4 + 2]) / 2.0));
				for (int l = num4 + 2; l <= num8 - 1; l++)
				{
					@class.Segments.Add(new Class4612((double_0[l - 1] + 5.0 * double_0[l]) / 6.0, (double_1[l - 1] + 5.0 * double_1[l]) / 6.0, (5.0 * double_0[l] + double_0[l + 1]) / 6.0, (5.0 * double_1[l] + double_1[l + 1]) / 6.0, (double_0[l] + double_0[l + 1]) / 2.0, (double_1[l] + double_1[l + 1]) / 2.0));
				}
				num = double_0[num6];
				num2 = double_1[num6];
				@class.Segments.Add(new Class4612((double_0[num8 - 1] + 5.0 * double_0[num8]) / 6.0, (double_1[num8 - 1] + 5.0 * double_1[num8]) / 6.0, (2.0 * double_0[num8] + double_0[num6]) / 3.0, (2.0 * double_1[num8] + double_1[num6]) / 3.0, num, num2));
			}
			num3 = ushort_0[j];
			@class.Segments.Add(new Class4611(x, y));
		}
		return @class;
	}
}
