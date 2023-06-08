using System;

namespace ns232;

internal class Class6127
{
	private class Class6128
	{
		internal int int_0;

		internal Class6128 class6128_0;
	}

	private static int int_0 = 512;

	private static int int_1 = 1;

	private static int int_2 = 3;

	private static int int_3 = 2;

	private static int int_4 = 3;

	private static int int_5 = 3;

	private static int int_6 = int_5 - 1;

	private static int int_7 = 7168;

	private static int int_8 = int.MaxValue;

	private readonly Class6119 class6119_0;

	private readonly bool bool_0;

	private int int_9;

	private int int_10 = int_8;

	private Class6125 class6125_0;

	private Class6125 class6125_1;

	private Class6125 class6125_2;

	private int int_11;

	private int int_12;

	private int int_13;

	private int int_14;

	private int int_15;

	private int int_16;

	private byte[] byte_0;

	private Class6128[] class6128_0;

	private Class6127()
	{
		class6119_0 = new Class6119();
		bool_0 = false;
	}

	private void Write(byte[] dataIn)
	{
		class6119_0.method_1(bool_0);
		int_9 = dataIn.Length;
		method_0(int_9);
		class6125_0 = new Class6125(class6119_0, 1 << int_2);
		class6125_1 = new Class6125(class6119_0, 1 << int_5);
		class6125_2 = new Class6125(class6119_0, int_16);
		byte_0 = new byte[int_7 + int_9];
		Array.Copy(dataIn, 0, byte_0, int_7, int_9);
		method_1();
		class6119_0.Flush();
	}

	private void method_0(int length)
	{
		int_11 = 1;
		for (int_12 = int_1 + (1 << int_2 * int_11) - 1; int_12 < int_9; int_12 = int_1 + (1 << int_2 * int_11) - 1)
		{
			int_11++;
		}
		int_13 = 256 + (1 << int_5) * int_11;
		int_14 = int_13 + 1;
		int_15 = int_14 + 1;
		int_16 = int_15 + 1;
	}

	private void method_1()
	{
		method_2();
		class6119_0.method_2(int_9, 24);
		int num = int_9 + int_7;
		int[] array = new int[1];
		int num2 = int_7;
		while (num2 < num)
		{
			int num3 = num2;
			int num4 = method_3(num2++, array);
			if (num4 > 0)
			{
				int num5 = smethod_0(array[0]);
				method_5(num4, array[0], num5);
				method_7(array[0], num5);
				for (int i = 1; i < num4; i++)
				{
					method_9(num2++);
				}
				continue;
			}
			byte b = byte_0[num3];
			if (num3 >= 2 && b == byte_0[num3 - 2])
			{
				class6125_2.method_5(int_13);
			}
			else if (num3 >= 4 && b == byte_0[num3 - 4])
			{
				class6125_2.method_5(int_14);
			}
			else if (num3 >= 6 && b == byte_0[num3 - 6])
			{
				class6125_2.method_5(int_15);
			}
			else
			{
				class6125_2.method_5(byte_0[num3] & 0xFF);
			}
		}
	}

	private void method_2()
	{
		class6128_0 = new Class6128[65536];
		int num = 0;
		for (int i = 0; i < 32; i++)
		{
			for (int j = 0; j < 96; j++)
			{
				byte_0[num] = (byte)i;
				method_9(num++);
				byte_0[num] = (byte)j;
				method_9(num++);
			}
		}
		int num2 = 0;
		while (num < int_7 && num2 < 256)
		{
			byte_0[num] = (byte)num2;
			method_9(num++);
			byte_0[num] = (byte)num2;
			method_9(num++);
			byte_0[num] = (byte)num2;
			method_9(num++);
			byte_0[num] = (byte)num2;
			method_9(num++);
			num2++;
		}
	}

	private int method_3(int index, int[] bestDist)
	{
		int[] array = new int[1];
		int[] array2 = new int[1];
		int[] array3 = new int[1];
		int num = index;
		int num2 = method_4(index, array, array2, array3);
		method_9(index++);
		if (array2[0] > 0)
		{
			int[] distOut = new int[1];
			int[] array4 = new int[1];
			int[] array5 = new int[1];
			int num3 = method_4(index, distOut, array4, array5);
			int num4 = class6125_2.method_4(byte_0[num] & 0xFF);
			if (array4[0] >= array2[0] && array3[0] > (array5[0] * num3 + num4) / (num3 + 1))
			{
				num2 = 0;
			}
			else if (num2 > 3)
			{
				num3 = method_4(num + num2, distOut, array4, array5);
				if (num3 >= 2)
				{
					int[] distOut2 = new int[1];
					int[] gainOut = new int[1];
					int[] array6 = new int[1];
					int num5 = method_4(num + num2 - 1, distOut2, gainOut, array6);
					if (num5 > num3 && array6[0] < array5[0])
					{
						int num6 = smethod_0(array[0] + 1);
						int num7 = method_6(num2 - 1, array[0] + 1, num6);
						int num8 = method_8(array[0] + 1, num6);
						int num9 = num7 + num8 + array6[0] * num5;
						int num10 = array3[0] * num2 + array5[0] * num3;
						if (num10 / (num2 + num3) > num9 / (num2 - 1 + num5))
						{
							num2--;
							array[0]++;
						}
					}
				}
			}
			if (num2 == 2)
			{
				if (num >= 2 && byte_0[num] == byte_0[num - 2])
				{
					int num11 = class6125_2.method_4(int_13);
					if (array3[0] * 2 > num11 + class6125_2.method_4(byte_0[num + 1] & 0xFF))
					{
						num2 = 0;
					}
				}
				else if (num >= 1 && num + 1 < byte_0.Length && byte_0[num + 1] == byte_0[num - 1])
				{
					int num12 = class6125_2.method_4(int_13);
					if (array3[0] * 2 > num4 + num12)
					{
						num2 = 0;
					}
				}
			}
		}
		bestDist[0] = array[0];
		return num2;
	}

	private int method_4(int index, int[] distOut, int[] gainOut, int[] costPerByteOut)
	{
		int num = 32;
		int[] array = new int[33];
		int num2 = byte_0.Length - index;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		if (num2 > 1)
		{
			int num8 = ((byte_0[index] & 0xFF) << 8) | (byte_0[index + 1] & 0xFF);
			Class6128 @class = null;
			int num9 = 0;
			Class6128 class2 = class6128_0[num8];
			while (class2 != null)
			{
				int num10 = class2.int_0;
				int num11 = index - num10;
				num9++;
				if (num9 <= 256 && num11 <= int_10)
				{
					int num12 = index - num10;
					if (num2 < num12)
					{
						num12 = num2;
					}
					if (num12 >= int_3)
					{
						num10 += 2;
						int num13 = 2;
						for (num13 = 2; num13 < num12 && byte_0[num10] == byte_0[index + num13]; num13++)
						{
							num10++;
						}
						if (num13 >= int_3)
						{
							num11 = num11 - num13 + 1;
							if (num11 <= int_12 && (num13 != 2 || num11 < int_0) && (num13 > num3 || num11 <= num4 || (num13 > num3 - 2 && (num11 <= num4 << int_2 || (num13 >= num3 && num11 <= num4 << int_2 + 1)))))
							{
								int num14 = 0;
								if (num13 > num7)
								{
									int num15 = num13;
									if (num15 > num)
									{
										num15 = num;
									}
									for (num10 = num7; num10 < num15; num10++)
									{
										byte b = byte_0[index + num10];
										array[num10 + 1] = array[num10] + class6125_2.method_4(b & 0xFF);
									}
									num7 = num15;
									if (num13 > num)
									{
										num14 = array[num];
										num14 += num14 / num * (num13 - num);
									}
									else
									{
										num14 = array[num13];
									}
								}
								else
								{
									num14 = array[num13];
								}
								if (num14 > num5)
								{
									int num16 = smethod_0(num11);
									int num17 = method_6(num13, num11, num16);
									if (num14 - num17 - (num16 << 16) > num5)
									{
										num17 += method_8(num11, num16);
										int num18 = num14 - num17;
										if (num18 > num5)
										{
											num5 = num18;
											num3 = num13;
											num4 = num11;
											num6 = num17;
										}
									}
								}
							}
						}
					}
					@class = class2;
					class2 = class2.class6128_0;
					continue;
				}
				if (class6128_0[num8] == class2)
				{
					class6128_0[num8] = null;
				}
				else
				{
					@class.class6128_0 = null;
				}
				break;
			}
		}
		costPerByteOut[0] = ((num3 > 0) ? (num6 / num3) : 0);
		distOut[0] = num4;
		gainOut[0] = num5;
		return num3;
	}

	private static int smethod_0(int dist)
	{
		int num = Class6125.smethod_0(dist - int_1);
		return (num + int_2 - 1) / int_2;
	}

	private void method_5(int value, int dist, int numDistRanges)
	{
		value = ((dist < int_0) ? (value - int_3) : (value - int_4));
		int num = Class6125.smethod_0(value);
		int i;
		for (i = int_6; i < num; i += int_6)
		{
		}
		int num2 = 1 << i - 1;
		int num3 = ((num > int_6) ? 2 : 0);
		if ((value & num2) != 0)
		{
			num3 |= 1;
		}
		num2 >>= 1;
		num3 <<= 1;
		if ((value & num2) != 0)
		{
			num3 |= 1;
		}
		num2 >>= 1;
		class6125_2.method_5(256 + num3 + (numDistRanges - 1) * (1 << int_5));
		for (i = num - int_6; i >= 1; i -= int_6)
		{
			num3 = ((i > int_6) ? 2 : 0);
			if ((value & num2) != 0)
			{
				num3 |= 1;
			}
			num2 >>= 1;
			num3 <<= 1;
			if ((value & num2) != 0)
			{
				num3 |= 1;
			}
			num2 >>= 1;
			class6125_1.method_5(num3);
		}
	}

	private int method_6(int value, int dist, int numDistRanges)
	{
		value = ((dist < int_0) ? (value - int_3) : (value - int_4));
		int num = Class6125.smethod_0(value);
		int i;
		for (i = int_6; i < num; i += int_6)
		{
		}
		int num2 = 1 << i - 1;
		int num3 = ((num > int_6) ? 2 : 0);
		if ((value & num2) != 0)
		{
			num3 |= 1;
		}
		num2 >>= 1;
		num3 <<= 1;
		if ((value & num2) != 0)
		{
			num3 |= 1;
		}
		num2 >>= 1;
		int num4 = class6125_2.method_4(256 + num3 + (numDistRanges - 1) * (1 << int_5));
		for (i = num - int_6; i >= 1; i -= int_6)
		{
			num3 = ((i > int_6) ? 2 : 0);
			if ((value & num2) != 0)
			{
				num3 |= 1;
			}
			num2 >>= 1;
			num3 <<= 1;
			if ((value & num2) != 0)
			{
				num3 |= 1;
			}
			num2 >>= 1;
			num4 += class6125_1.method_4(num3);
		}
		return num4;
	}

	private void method_7(int value, int distRanges)
	{
		value -= int_1;
		int num = (1 << int_2) - 1;
		for (int num2 = (distRanges - 1) * int_2; num2 >= 0; num2 -= int_2)
		{
			class6125_0.method_5((value >> num2) & num);
		}
	}

	private int method_8(int value, int distRanges)
	{
		int num = 0;
		value -= int_1;
		int num2 = (1 << int_2) - 1;
		for (int num3 = (distRanges - 1) * int_2; num3 >= 0; num3 -= int_2)
		{
			num += class6125_0.method_4((value >> num3) & num2);
		}
		return num;
	}

	private void method_9(int index)
	{
		byte b = byte_0[index];
		if (index > 0)
		{
			Class6128 @class = new Class6128();
			byte b2 = byte_0[index - 1];
			int num = ((b2 & 0xFF) << 8) | (b & 0xFF);
			@class.int_0 = index - 1;
			@class.class6128_0 = class6128_0[num];
			class6128_0[num] = @class;
		}
	}

	private byte[] method_10()
	{
		return class6119_0.method_3();
	}

	public static byte[] smethod_1(byte[] dataIn)
	{
		Class6127 @class = new Class6127();
		@class.Write(dataIn);
		return @class.method_10();
	}

	public static int smethod_2()
	{
		return int_7;
	}
}
