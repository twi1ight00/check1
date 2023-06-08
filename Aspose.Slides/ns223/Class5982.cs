using System;

namespace ns223;

internal class Class5982
{
	private const byte byte_0 = 3;

	private const byte byte_1 = 7;

	private const byte byte_2 = 11;

	private const byte byte_3 = 19;

	private const byte byte_4 = 3;

	private const byte byte_5 = 5;

	private const byte byte_6 = 9;

	private const byte byte_7 = 13;

	private const byte byte_8 = 3;

	private const byte byte_9 = 9;

	private const byte byte_10 = 11;

	private const byte byte_11 = 15;

	private uint[] uint_0;

	private byte[] byte_12;

	private uint[] uint_1;

	private uint[] uint_2;

	private byte[] byte_13;

	public Class5982()
	{
		uint_0 = new uint[4];
		uint_1 = new uint[2];
		byte_12 = new byte[64];
		byte_13 = new byte[16];
		uint_2 = new uint[16];
		Initialize();
	}

	public byte[] method_0(byte[] array)
	{
		return method_1(array, 0, array.Length);
	}

	public byte[] method_1(byte[] array, int offset, int count)
	{
		HashCore(array, offset, count);
		return HashFinal();
	}

	private void Initialize()
	{
		uint_1[0] = 0u;
		uint_1[1] = 0u;
		uint_0[0] = 1732584193u;
		uint_0[1] = 4023233417u;
		uint_0[2] = 2562383102u;
		uint_0[3] = 271733878u;
		Array.Clear(byte_12, 0, 64);
		Array.Clear(uint_2, 0, 16);
	}

	internal void HashCore(byte[] array, int ibStart, int cbSize)
	{
		int num = (int)((uint_1[0] >> 3) & 0x3F);
		uint_1[0] += (uint)(cbSize << 3);
		if (uint_1[0] < cbSize << 3)
		{
			uint_1[1]++;
		}
		uint_1[1] += (uint)(cbSize >> 29);
		int num2 = 64 - num;
		int i = 0;
		if (cbSize >= num2)
		{
			Array.Copy(array, ibStart, byte_12, num, num2);
			method_2(uint_0, byte_12, 0);
			for (i = num2; i + 63 < cbSize; i += 64)
			{
				method_2(uint_0, array, i);
			}
			num = 0;
		}
		Array.Copy(array, ibStart + i, byte_12, num, cbSize - i);
	}

	internal byte[] HashFinal()
	{
		byte[] array = new byte[8];
		smethod_8(array, uint_1);
		uint num = (uint_1[0] >> 3) & 0x3Fu;
		int num2 = (int)((num < 56) ? (56 - num) : (120 - num));
		HashCore(smethod_0(num2), 0, num2);
		HashCore(array, 0, 8);
		smethod_8(byte_13, uint_0);
		Initialize();
		return byte_13;
	}

	private static byte[] smethod_0(int nLength)
	{
		if (nLength > 0)
		{
			byte[] array = new byte[nLength];
			array[0] = 128;
			return array;
		}
		return null;
	}

	private static uint smethod_1(uint x, uint y, uint z)
	{
		return (x & y) | (~x & z);
	}

	private static uint smethod_2(uint x, uint y, uint z)
	{
		return (x & y) | (x & z) | (y & z);
	}

	private static uint smethod_3(uint x, uint y, uint z)
	{
		return x ^ y ^ z;
	}

	private static uint smethod_4(uint x, byte n)
	{
		return (x << (int)n) | (x >> 32 - n);
	}

	private static void smethod_5(ref uint a, uint b, uint c, uint d, uint x, byte s)
	{
		a += smethod_1(b, c, d) + x;
		a = smethod_4(a, s);
	}

	private static void smethod_6(ref uint a, uint b, uint c, uint d, uint x, byte s)
	{
		a += smethod_2(b, c, d) + x + 1518500249;
		a = smethod_4(a, s);
	}

	private static void smethod_7(ref uint a, uint b, uint c, uint d, uint x, byte s)
	{
		a += smethod_3(b, c, d) + x + 1859775393;
		a = smethod_4(a, s);
	}

	private static void smethod_8(byte[] output, uint[] input)
	{
		int num = 0;
		for (int i = 0; i < output.Length; i += 4)
		{
			output[i] = (byte)input[num];
			output[i + 1] = (byte)(input[num] >> 8);
			output[i + 2] = (byte)(input[num] >> 16);
			output[i + 3] = (byte)(input[num] >> 24);
			num++;
		}
	}

	private static void smethod_9(uint[] output, byte[] input, int index)
	{
		int num = 0;
		int num2 = index;
		while (num < output.Length)
		{
			output[num] = (uint)(input[num2] | (input[num2 + 1] << 8) | (input[num2 + 2] << 16) | (input[num2 + 3] << 24));
			num++;
			num2 += 4;
		}
	}

	private void method_2(uint[] state, byte[] block, int index)
	{
		uint a = state[0];
		uint a2 = state[1];
		uint a3 = state[2];
		uint a4 = state[3];
		smethod_9(uint_2, block, index);
		smethod_5(ref a, a2, a3, a4, uint_2[0], 3);
		smethod_5(ref a4, a, a2, a3, uint_2[1], 7);
		smethod_5(ref a3, a4, a, a2, uint_2[2], 11);
		smethod_5(ref a2, a3, a4, a, uint_2[3], 19);
		smethod_5(ref a, a2, a3, a4, uint_2[4], 3);
		smethod_5(ref a4, a, a2, a3, uint_2[5], 7);
		smethod_5(ref a3, a4, a, a2, uint_2[6], 11);
		smethod_5(ref a2, a3, a4, a, uint_2[7], 19);
		smethod_5(ref a, a2, a3, a4, uint_2[8], 3);
		smethod_5(ref a4, a, a2, a3, uint_2[9], 7);
		smethod_5(ref a3, a4, a, a2, uint_2[10], 11);
		smethod_5(ref a2, a3, a4, a, uint_2[11], 19);
		smethod_5(ref a, a2, a3, a4, uint_2[12], 3);
		smethod_5(ref a4, a, a2, a3, uint_2[13], 7);
		smethod_5(ref a3, a4, a, a2, uint_2[14], 11);
		smethod_5(ref a2, a3, a4, a, uint_2[15], 19);
		smethod_6(ref a, a2, a3, a4, uint_2[0], 3);
		smethod_6(ref a4, a, a2, a3, uint_2[4], 5);
		smethod_6(ref a3, a4, a, a2, uint_2[8], 9);
		smethod_6(ref a2, a3, a4, a, uint_2[12], 13);
		smethod_6(ref a, a2, a3, a4, uint_2[1], 3);
		smethod_6(ref a4, a, a2, a3, uint_2[5], 5);
		smethod_6(ref a3, a4, a, a2, uint_2[9], 9);
		smethod_6(ref a2, a3, a4, a, uint_2[13], 13);
		smethod_6(ref a, a2, a3, a4, uint_2[2], 3);
		smethod_6(ref a4, a, a2, a3, uint_2[6], 5);
		smethod_6(ref a3, a4, a, a2, uint_2[10], 9);
		smethod_6(ref a2, a3, a4, a, uint_2[14], 13);
		smethod_6(ref a, a2, a3, a4, uint_2[3], 3);
		smethod_6(ref a4, a, a2, a3, uint_2[7], 5);
		smethod_6(ref a3, a4, a, a2, uint_2[11], 9);
		smethod_6(ref a2, a3, a4, a, uint_2[15], 13);
		smethod_7(ref a, a2, a3, a4, uint_2[0], 3);
		smethod_7(ref a4, a, a2, a3, uint_2[8], 9);
		smethod_7(ref a3, a4, a, a2, uint_2[4], 11);
		smethod_7(ref a2, a3, a4, a, uint_2[12], 15);
		smethod_7(ref a, a2, a3, a4, uint_2[2], 3);
		smethod_7(ref a4, a, a2, a3, uint_2[10], 9);
		smethod_7(ref a3, a4, a, a2, uint_2[6], 11);
		smethod_7(ref a2, a3, a4, a, uint_2[14], 15);
		smethod_7(ref a, a2, a3, a4, uint_2[1], 3);
		smethod_7(ref a4, a, a2, a3, uint_2[9], 9);
		smethod_7(ref a3, a4, a, a2, uint_2[5], 11);
		smethod_7(ref a2, a3, a4, a, uint_2[13], 15);
		smethod_7(ref a, a2, a3, a4, uint_2[3], 3);
		smethod_7(ref a4, a, a2, a3, uint_2[11], 9);
		smethod_7(ref a3, a4, a, a2, uint_2[7], 11);
		smethod_7(ref a2, a3, a4, a, uint_2[15], 15);
		state[0] += a;
		state[1] += a2;
		state[2] += a3;
		state[3] += a4;
	}
}
