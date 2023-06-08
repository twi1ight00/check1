using System;

namespace ns130;

internal class Class4580
{
	private class Class4581
	{
		public int int_0;

		public Class4581 class4581_0;
	}

	private const int int_0 = int.MaxValue;

	private Class4577 class4577_0;

	private Class4577 class4577_1;

	private Class4577 class4577_2;

	private Class4582 class4582_0;

	private Class4581[] class4581_0;

	private byte[] byte_0;

	private int int_1;

	private int int_2;

	public Class4580(int maxCopyDistance)
	{
		int_2 = maxCopyDistance;
	}

	public Class4580()
		: this(int.MaxValue)
	{
	}

	public byte[] method_0(byte[] data)
	{
		using Class4575 @class = new Class4575();
		@class.method_1(bit: false);
		int_1 = data.Length;
		class4582_0 = new Class4582(int_1);
		class4577_0 = new Class4577(@class, 8);
		class4577_1 = new Class4577(@class, 8);
		class4577_2 = new Class4577(@class, class4582_0.int_12);
		byte_0 = new byte[7168 + int_1];
		Buffer.BlockCopy(data, 0, byte_0, 7168, int_1);
		method_1(@class);
		@class.Flush();
		return @class.ToArray();
	}

	private void method_1(Class4575 writer)
	{
		method_2();
		writer.method_2(int_1, 24);
		int num = int_1 + 7168;
		int[] array = new int[1];
		int num2 = 7168;
		while (num2 < num)
		{
			int num3 = num2;
			int num4 = method_4(num2++, array);
			if (num4 > 0)
			{
				int num5 = smethod_0(array[0]);
				method_6(num4, array[0], num5);
				method_8(array[0], num5);
				for (int i = 1; i < num4; i++)
				{
					method_3(num2++);
				}
				continue;
			}
			byte b = byte_0[num3];
			if (num3 >= 2 && b == byte_0[num3 - 2])
			{
				class4577_2.method_1(class4582_0.int_8);
			}
			else if (num3 >= 4 && b == byte_0[num3 - 4])
			{
				class4577_2.method_1(class4582_0.int_9);
			}
			else if (num3 >= 6 && b == byte_0[num3 - 6])
			{
				class4577_2.method_1(class4582_0.int_10);
			}
			else
			{
				class4577_2.method_1(byte_0[num3] & 0xFF);
			}
		}
	}

	private void method_2()
	{
		class4581_0 = new Class4581[65536];
		int num = 0;
		for (int i = 0; i < 32; i++)
		{
			for (int j = 0; j < 96; j++)
			{
				byte_0[num] = (byte)i;
				method_3(num++);
				byte_0[num] = (byte)j;
				method_3(num++);
			}
		}
		int num2 = 0;
		while (num < 7168 && num2 < 256)
		{
			byte_0[num] = (byte)num2;
			method_3(num++);
			byte_0[num] = (byte)num2;
			method_3(num++);
			byte_0[num] = (byte)num2;
			method_3(num++);
			byte_0[num] = (byte)num2;
			method_3(num++);
			num2++;
		}
	}

	private void method_3(int index)
	{
		byte b = byte_0[index];
		if (index > 0)
		{
			Class4581 @class = new Class4581();
			byte b2 = byte_0[index - 1];
			int num = ((b2 & 0xFF) << 8) | (b & 0xFF);
			@class.int_0 = index - 1;
			@class.class4581_0 = class4581_0[num];
			class4581_0[num] = @class;
		}
	}

	private int method_4(int index, int[] bestDist)
	{
		int[] array = new int[1];
		int[] array2 = new int[1];
		int[] array3 = new int[1];
		int num = index;
		int num2 = method_5(index, array, array2, array3);
		method_3(index++);
		if (array2[0] > 0)
		{
			int[] distOut = new int[1];
			int[] array4 = new int[1];
			int[] array5 = new int[1];
			int num3 = method_5(index, distOut, array4, array5);
			int num4 = class4577_2.method_0(byte_0[num] & 0xFF);
			if (array4[0] >= array2[0] && array3[0] > (array5[0] * num3 + num4) / (num3 + 1))
			{
				num2 = 0;
			}
			else if (num2 > 3)
			{
				num3 = method_5(num + num2, distOut, array4, array5);
				if (num3 >= 2)
				{
					int[] distOut2 = new int[1];
					int[] gainOut = new int[1];
					int[] array6 = new int[1];
					int num5 = method_5(num + num2 - 1, distOut2, gainOut, array6);
					if (num5 > num3 && array6[0] < array5[0])
					{
						int num6 = smethod_0(array[0] + 1);
						int num7 = method_7(num2 - 1, array[0] + 1, num6);
						int num8 = method_9(array[0] + 1, num6);
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
					int num11 = class4577_2.method_0(class4582_0.int_8);
					if (array3[0] * 2 > num11 + class4577_2.method_0(byte_0[num + 1] & 0xFF))
					{
						num2 = 0;
					}
				}
				else if (num >= 1 && num + 1 < byte_0.Length && byte_0[num + 1] == byte_0[num - 1])
				{
					int num12 = class4577_2.method_0(class4582_0.int_8);
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

	private int method_5(int index, int[] distOut, int[] gainOut, int[] costPerByteOut)
	{
		int[] array = new int[33];
		int num = byte_0.Length - index;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		if (num > 1)
		{
			int num7 = ((byte_0[index] & 0xFF) << 8) | (byte_0[index + 1] & 0xFF);
			Class4581 @class = null;
			int num8 = 0;
			Class4581 class2 = class4581_0[num7];
			while (class2 != null)
			{
				int num9 = class2.int_0;
				int num10 = index - num9;
				num8++;
				if (num8 <= 256 && num10 <= int_2)
				{
					int num11 = index - num9;
					if (num < num11)
					{
						num11 = num;
					}
					if (num11 >= 2)
					{
						num9 += 2;
						int num12 = 2;
						for (num12 = 2; num12 < num11 && byte_0[num9] == byte_0[index + num12]; num12++)
						{
							num9++;
						}
						if (num12 >= 2)
						{
							num10 = num10 - num12 + 1;
							if (num10 <= class4582_0.int_11 && (num12 != 2 || num10 < 512) && (num12 > num2 || num10 <= num3 || (num12 > num2 - 2 && (num10 <= num3 << 3 || (num12 >= num2 && num10 <= num3 << 4)))))
							{
								int num13 = 0;
								if (num12 > num6)
								{
									int num14 = num12;
									if (num14 > 32)
									{
										num14 = 32;
									}
									for (num9 = num6; num9 < num14; num9++)
									{
										byte b = byte_0[index + num9];
										array[num9 + 1] = array[num9] + class4577_2.method_0(b & 0xFF);
									}
									num6 = num14;
									if (num12 > 32)
									{
										num13 = array[32];
										num13 += num13 / 32 * (num12 - 32);
									}
									else
									{
										num13 = array[num12];
									}
								}
								else
								{
									num13 = array[num12];
								}
								if (num13 > num4)
								{
									int num15 = smethod_0(num10);
									int num16 = method_7(num12, num10, num15);
									if (num13 - num16 - (num15 << 16) > num4)
									{
										num16 += method_9(num10, num15);
										int num17 = num13 - num16;
										if (num17 > num4)
										{
											num4 = num17;
											num2 = num12;
											num3 = num10;
											num5 = num16;
										}
									}
								}
							}
						}
					}
					@class = class2;
					class2 = class2.class4581_0;
					continue;
				}
				if (class4581_0[num7] == class2)
				{
					class4581_0[num7] = null;
				}
				else
				{
					@class.class4581_0 = null;
				}
				break;
			}
		}
		costPerByteOut[0] = ((num2 > 0) ? (num5 / num2) : 0);
		distOut[0] = num3;
		gainOut[0] = num4;
		return num2;
	}

	private static int smethod_0(int dist)
	{
		int num = Class4578.smethod_0(dist - 1);
		return (num + 3 - 1) / 3;
	}

	private void method_6(int value, int dist, int numDistRanges)
	{
		value = ((dist < 512) ? (value - 2) : (value - 3));
		int num = Class4578.smethod_0(value);
		int i;
		for (i = 2; i < num; i += 2)
		{
		}
		int num2 = 1 << i - 1;
		int num3 = ((num > 2) ? 2 : 0);
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
		class4577_2.method_1(256 + num3 + (numDistRanges - 1) * 8);
		for (i = num - 2; i >= 1; i -= 2)
		{
			num3 = ((i > 2) ? 2 : 0);
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
			class4577_1.method_1(num3);
		}
	}

	private int method_7(int value, int dist, int numDistRanges)
	{
		value = ((dist < 512) ? (value - 2) : (value - 3));
		int num = Class4578.smethod_0(value);
		int i;
		for (i = 2; i < num; i += 2)
		{
		}
		int num2 = 1 << i - 1;
		int num3 = ((num > 2) ? 2 : 0);
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
		int num4 = class4577_2.method_0(256 + num3 + (numDistRanges - 1) * 8);
		for (i = num - 2; i >= 1; i -= 2)
		{
			num3 = ((i > 2) ? 2 : 0);
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
			num4 += class4577_1.method_0(num3);
		}
		return num4;
	}

	private void method_8(int value, int distRanges)
	{
		value--;
		int num = 7;
		for (int num2 = (distRanges - 1) * 3; num2 >= 0; num2 -= 3)
		{
			class4577_0.method_1((value >> num2) & num);
		}
	}

	private int method_9(int value, int distRanges)
	{
		int num = 0;
		value--;
		int num2 = 7;
		for (int num3 = (distRanges - 1) * 3; num3 >= 0; num3 -= 3)
		{
			num += class4577_0.method_0((value >> num3) & num2);
		}
		return num;
	}
}
