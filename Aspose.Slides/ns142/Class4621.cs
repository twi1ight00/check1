using System;

namespace ns142;

internal class Class4621
{
	private byte[,] byte_0;

	private double double_0;

	private int int_0;

	private double double_1;

	private int int_1;

	private int int_2;

	private int int_3;

	public byte[,] Map => byte_0;

	public double FontSizePoints => double_0;

	public double FontSizePixels => double_1;

	public int DeviceDPI => int_0;

	public int Sbx
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public int Sby
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public int Width
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	public Class4621(int deviceDPI, double fontSizePoints)
	{
		double_0 = fontSizePoints;
		int_0 = deviceDPI;
		double_1 = fontSizePoints * (double)deviceDPI / 72.0;
		byte_0 = new byte[(int)Math.Ceiling(double_1 / 8.0), (int)Math.Ceiling(double_1)];
		int_1 = 0;
		int_2 = 0;
	}

	public void method_0(int x, int y)
	{
		int num = x - int_1;
		int num2 = y - int_2;
		if (num >= 0 && num2 >= 0)
		{
			int num3 = 0;
			while (num >= 8)
			{
				num -= 8;
				num3++;
			}
			try
			{
				Map[num3, num2] |= (byte)(1 << num);
			}
			catch (IndexOutOfRangeException)
			{
			}
		}
	}
}
