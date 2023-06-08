using System;
using System.Drawing;

namespace ns4;

internal sealed class Class15
{
	private static Struct15[] struct15_0 = new Struct15[1]
	{
		new Struct15(0, 0, 21600, 21600)
	};

	public Point[] point_0;

	public ushort[] ushort_0;

	public Struct14[] struct14_0;

	public int[] int_0;

	public Struct15[] struct15_1;

	public int int_1;

	public int int_2;

	public Point[] point_1;

	public Enum5[] enum5_0;

	private static readonly int[] int_3;

	private static readonly int[] int_4;

	private static readonly int[] int_5;

	private static readonly int[] int_6;

	private static readonly int[] int_7;

	private static readonly int[] int_8;

	private static readonly int[] int_9;

	private static readonly int[] int_10;

	private static readonly int[] int_11;

	private static readonly int[] int_12;

	private static readonly int[] int_13;

	private static readonly int[] int_14;

	private static readonly Point[] point_2;

	internal Class15(Point[] point_3, ushort[] ushort_1, Struct14[] struct14_1, int[] int_15, Struct15[] struct15_2, int int_16, int int_17, int int_18, int int_19, Point[] point_4)
		: this(point_3, ushort_1, struct14_1, int_15, struct15_2, int_16, int_17, int_18, int_19, point_4, null)
	{
	}

	internal Class15(Point[] point_3, ushort[] ushort_1, Struct14[] struct14_1, int[] int_15, Struct15[] struct15_2, int int_16, int int_17, int int_18, int int_19, Point[] point_4, Enum5[] enum5_1)
	{
		point_0 = point_3;
		ushort_0 = ushort_1;
		struct14_0 = struct14_1;
		int_0 = int_15;
		if (struct15_2 == null)
		{
			struct15_2 = struct15_0;
		}
		struct15_1 = struct15_2;
		int_1 = int_16;
		int_2 = int_17;
		if (point_4 != null)
		{
			point_1 = point_4;
		}
		else
		{
			point_1 = point_2;
		}
		enum5_0 = enum5_1;
	}

	internal float method_0(short short_0, int[] int_15, ref byte byte_0)
	{
		if (struct14_0 == null)
		{
			throw new ApplicationException("Autoshape haven't calculation data");
		}
		int num = struct14_0[short_0].int_0;
		int[] array = new int[3]
		{
			struct14_0[short_0].int_1,
			struct14_0[short_0].int_2,
			struct14_0[short_0].int_3
		};
		double[] array2 = new double[3]
		{
			struct14_0[short_0].int_1,
			struct14_0[short_0].int_2,
			struct14_0[short_0].int_3
		};
		for (int i = 0; i < 3; i++)
		{
			if ((num & (8192 << i)) == 0)
			{
				continue;
			}
			if (((uint)array[i] & 0x400u) != 0)
			{
				array2[i] = method_0((short)(array[i] & 0xFF), int_15, ref byte_0);
				continue;
			}
			switch (array[i])
			{
			case 320:
				array2[i] = 0.0;
				byte_0 |= 1;
				break;
			case 321:
				array2[i] = 0.0;
				byte_0 |= 4;
				break;
			case 322:
				array2[i] = int_1;
				byte_0 |= 2;
				break;
			case 323:
				array2[i] = int_2;
				byte_0 |= 8;
				break;
			default:
				array2[i] = 0.0;
				break;
			case 327:
			case 328:
			case 329:
			case 330:
			case 331:
			case 332:
			case 333:
			case 334:
			case 335:
			case 336:
				try
				{
					array2[i] = int_15[array[i] - 327];
				}
				catch (IndexOutOfRangeException)
				{
				}
				break;
			}
		}
		switch (num & 0xFF)
		{
		case 128:
			if (array2[2] == 0.0)
			{
				array2[0] = Math.Sqrt(array2[0] * array2[0] + array2[1] * array2[1]);
				break;
			}
			if (array2[0] == 0.0)
			{
				array2[0] = array2[1];
			}
			array2[0] = Math.Sqrt(array2[2] * array2[2] - array2[0] * array2[0]);
			break;
		case 129:
			array2[2] *= 0.0017453292519943296;
			array2[0] = 10800.0 + Math.Cos(array2[2]) * (array2[0] - 10800.0) + Math.Sin(array2[2]) * (array2[1] - 10800.0);
			break;
		case 130:
			array2[2] *= 0.0017453292519943296;
			array2[0] = 10800.0 - Math.Sin(array2[2]) * (array2[0] - 10800.0) + Math.Cos(array2[2]) * (array2[1] - 10800.0);
			break;
		case 0:
			array2[0] += array2[1] - array2[2];
			break;
		case 1:
			if (array2[1] != 0.0)
			{
				array2[0] *= array2[1];
			}
			if (array2[2] != 0.0)
			{
				array2[0] /= array2[2];
			}
			break;
		case 2:
			array2[0] = (array2[0] + array2[1]) / 2.0;
			break;
		case 3:
			array2[0] = Math.Abs(array2[0]);
			break;
		case 4:
			if (array2[0] > array2[1])
			{
				array2[0] = array2[1];
			}
			break;
		case 5:
			if (array2[0] < array2[1])
			{
				array2[0] = array2[1];
			}
			break;
		case 6:
			if (array2[0] > 0.0)
			{
				array2[0] = array2[1];
			}
			else
			{
				array2[0] = array2[2];
			}
			break;
		case 7:
			array2[0] = Math.Sqrt(array2[0] * array2[0] + array2[1] * array2[1] + array2[2] * array2[2]);
			break;
		case 8:
			array2[0] = Class17.smethod_1(Math.Atan2(array2[1], array2[0])) * 65536.0;
			break;
		case 9:
			array2[0] *= Math.Sin(Class17.smethod_0(array2[1]) / 65536.0);
			break;
		case 10:
			array2[0] *= Math.Cos(Class17.smethod_0(array2[1]) / 65536.0);
			break;
		case 11:
			array2[0] *= Math.Cos(Math.Atan2(array2[2], array2[1]));
			break;
		case 12:
			array2[0] *= Math.Sin(Math.Atan2(array2[2], array2[1]));
			break;
		case 13:
			array2[0] = Math.Sqrt(array2[0]);
			break;
		case 14:
			array2[0] += (array2[1] - array2[2]) * 65536.0;
			break;
		case 15:
			if (array2[1] != 0.0)
			{
				array2[0] /= array2[1];
				array2[0] = array2[2] * Math.Sqrt(1.0 - array2[0] * array2[0]);
			}
			break;
		case 16:
			array2[0] *= Math.Tan(array2[1]);
			break;
		}
		return (float)array2[0];
	}

	static Class15()
	{
		int[] array = new int[1];
		int_3 = array;
		int_4 = new int[1] { 1400 };
		int_5 = new int[1] { 1800 };
		int_6 = new int[1] { 2500 };
		int_7 = new int[1] { 2700 };
		int_8 = new int[1] { 3600 };
		int_9 = new int[1] { 3700 };
		int_10 = new int[1] { 5400 };
		int_11 = new int[1] { 8100 };
		int_12 = new int[1] { 10800 };
		int_13 = new int[2] { 16200, 5400 };
		int_14 = new int[2] { 17694720, 0 };
		point_2 = new Point[4]
		{
			new Point(10800, 0),
			new Point(0, 10800),
			new Point(10800, 21600),
			new Point(21600, 10800)
		};
	}
}
