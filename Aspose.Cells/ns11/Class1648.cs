using System;

namespace ns11;

internal class Class1648
{
	private uint[] uint_0 = new uint[4];

	private long long_0;

	private byte[] byte_0 = new byte[64];

	private uint[] uint_1 = new uint[16];

	public Class1648()
	{
		method_0();
	}

	private void method_0()
	{
		uint_0[0] = 1732584193u;
		uint_0[1] = 4023233417u;
		uint_0[2] = 2562383102u;
		uint_0[3] = 271733878u;
		long_0 = 0L;
		for (int i = 0; i < 64; i++)
		{
			byte_0[i] = 0;
		}
	}

	private void method_1(byte[] byte_1, int int_0, int int_1)
	{
		if (int_0 >= 0 && int_1 >= 0 && (long)int_0 + (long)int_1 <= byte_1.Length)
		{
			int num = (int)(long_0 % 64);
			long_0 += int_1;
			int num2 = 64 - num;
			int i = 0;
			if (int_1 >= num2)
			{
				Array.Copy(byte_1, int_0 + i, byte_0, num, num2);
				method_3(ref byte_0, 0);
				for (i = num2; i + 64 - 1 < int_1; i += 64)
				{
					method_3(ref byte_1, int_0 + i);
				}
				num = 0;
			}
			if (i < int_1)
			{
				Array.Copy(byte_1, int_0 + i, byte_0, num, int_1 - i);
			}
			return;
		}
		throw new ArgumentOutOfRangeException();
	}

	private byte[] method_2()
	{
		int num = (int)(long_0 % 64);
		int num2 = ((num < 56) ? (56 - num) : (120 - num));
		byte[] array = new byte[num2 + 8];
		array[0] = 128;
		for (int i = 0; i < 8; i++)
		{
			array[num2 + i] = (byte)(long_0 * 8 >> 8 * i);
		}
		method_1(array, 0, array.Length);
		byte[] array2 = new byte[16];
		for (int j = 0; j < 4; j++)
		{
			for (int k = 0; k < 4; k++)
			{
				array2[j * 4 + k] = (byte)(uint_0[j] >> 8 * k);
			}
		}
		method_0();
		return array2;
	}

	public static byte[] smethod_0(byte[] byte_1)
	{
		Class1648 @class = new Class1648();
		@class.method_1(byte_1, 0, byte_1.Length);
		return @class.method_2();
	}

	private void method_3(ref byte[] byte_1, int int_0)
	{
		for (int i = 0; i < 16; i++)
		{
			uint_1[i] = (byte_1[int_0++] & 0xFFu) | (uint)((byte_1[int_0++] & 0xFF) << 8) | (uint)((byte_1[int_0++] & 0xFF) << 16) | (uint)((byte_1[int_0++] & 0xFF) << 24);
		}
		uint uint_ = uint_0[0];
		uint num = uint_0[1];
		uint num2 = uint_0[2];
		uint num3 = uint_0[3];
		uint_ = method_4(uint_, num, num2, num3, uint_1[0], 3);
		num3 = method_4(num3, uint_, num, num2, uint_1[1], 7);
		num2 = method_4(num2, num3, uint_, num, uint_1[2], 11);
		num = method_4(num, num2, num3, uint_, uint_1[3], 19);
		uint_ = method_4(uint_, num, num2, num3, uint_1[4], 3);
		num3 = method_4(num3, uint_, num, num2, uint_1[5], 7);
		num2 = method_4(num2, num3, uint_, num, uint_1[6], 11);
		num = method_4(num, num2, num3, uint_, uint_1[7], 19);
		uint_ = method_4(uint_, num, num2, num3, uint_1[8], 3);
		num3 = method_4(num3, uint_, num, num2, uint_1[9], 7);
		num2 = method_4(num2, num3, uint_, num, uint_1[10], 11);
		num = method_4(num, num2, num3, uint_, uint_1[11], 19);
		uint_ = method_4(uint_, num, num2, num3, uint_1[12], 3);
		num3 = method_4(num3, uint_, num, num2, uint_1[13], 7);
		num2 = method_4(num2, num3, uint_, num, uint_1[14], 11);
		num = method_4(num, num2, num3, uint_, uint_1[15], 19);
		uint_ = method_5(uint_, num, num2, num3, uint_1[0], 3);
		num3 = method_5(num3, uint_, num, num2, uint_1[4], 5);
		num2 = method_5(num2, num3, uint_, num, uint_1[8], 9);
		num = method_5(num, num2, num3, uint_, uint_1[12], 13);
		uint_ = method_5(uint_, num, num2, num3, uint_1[1], 3);
		num3 = method_5(num3, uint_, num, num2, uint_1[5], 5);
		num2 = method_5(num2, num3, uint_, num, uint_1[9], 9);
		num = method_5(num, num2, num3, uint_, uint_1[13], 13);
		uint_ = method_5(uint_, num, num2, num3, uint_1[2], 3);
		num3 = method_5(num3, uint_, num, num2, uint_1[6], 5);
		num2 = method_5(num2, num3, uint_, num, uint_1[10], 9);
		num = method_5(num, num2, num3, uint_, uint_1[14], 13);
		uint_ = method_5(uint_, num, num2, num3, uint_1[3], 3);
		num3 = method_5(num3, uint_, num, num2, uint_1[7], 5);
		num2 = method_5(num2, num3, uint_, num, uint_1[11], 9);
		num = method_5(num, num2, num3, uint_, uint_1[15], 13);
		uint_ = method_6(uint_, num, num2, num3, uint_1[0], 3);
		num3 = method_6(num3, uint_, num, num2, uint_1[8], 9);
		num2 = method_6(num2, num3, uint_, num, uint_1[4], 11);
		num = method_6(num, num2, num3, uint_, uint_1[12], 15);
		uint_ = method_6(uint_, num, num2, num3, uint_1[2], 3);
		num3 = method_6(num3, uint_, num, num2, uint_1[10], 9);
		num2 = method_6(num2, num3, uint_, num, uint_1[6], 11);
		num = method_6(num, num2, num3, uint_, uint_1[14], 15);
		uint_ = method_6(uint_, num, num2, num3, uint_1[1], 3);
		num3 = method_6(num3, uint_, num, num2, uint_1[9], 9);
		num2 = method_6(num2, num3, uint_, num, uint_1[5], 11);
		num = method_6(num, num2, num3, uint_, uint_1[13], 15);
		uint_ = method_6(uint_, num, num2, num3, uint_1[3], 3);
		num3 = method_6(num3, uint_, num, num2, uint_1[11], 9);
		num2 = method_6(num2, num3, uint_, num, uint_1[7], 11);
		num = method_6(num, num2, num3, uint_, uint_1[15], 15);
		uint_0[0] += uint_;
		uint_0[1] += num;
		uint_0[2] += num2;
		uint_0[3] += num3;
	}

	private uint method_4(uint uint_2, uint uint_3, uint uint_4, uint uint_5, uint uint_6, int int_0)
	{
		uint num = uint_2 + ((uint_3 & uint_4) | (~uint_3 & uint_5)) + uint_6;
		return (num << int_0) | (num >> 32 - int_0);
	}

	private uint method_5(uint uint_2, uint uint_3, uint uint_4, uint uint_5, uint uint_6, int int_0)
	{
		uint num = uint_2 + ((uint_3 & (uint_4 | uint_5)) | (uint_4 & uint_5)) + uint_6 + 1518500249;
		return (num << int_0) | (num >> 32 - int_0);
	}

	private uint method_6(uint uint_2, uint uint_3, uint uint_4, uint uint_5, uint uint_6, int int_0)
	{
		uint num = uint_2 + (uint_3 ^ uint_4 ^ uint_5) + uint_6 + 1859775393;
		return (num << int_0) | (num >> 32 - int_0);
	}
}
