using System;

namespace ns223;

internal class Class5987
{
	private const int int_0 = 64;

	private uint[] uint_0;

	private long long_0;

	private byte[] byte_0;

	private int int_1;

	private uint[] uint_1;

	private byte[] byte_1;

	public Class5987()
	{
		uint_0 = new uint[5];
		byte_0 = new byte[64];
		uint_1 = new uint[80];
		Initialize();
	}

	public byte[] method_0(byte[] input)
	{
		if (input == null)
		{
			throw new ArgumentNullException("input");
		}
		HashCore(input, 0, input.Length);
		byte_1 = HashFinal();
		Initialize();
		return byte_1;
	}

	private void HashCore(byte[] rgb, int start, int size)
	{
		if (int_1 != 0)
		{
			if (size < 64 - int_1)
			{
				Array.Copy(rgb, start, byte_0, int_1, size);
				int_1 += size;
				return;
			}
			int num = 64 - int_1;
			Array.Copy(rgb, start, byte_0, int_1, num);
			method_1(byte_0, 0);
			int_1 = 0;
			start += num;
			size -= num;
		}
		for (int num = 0; num < size - size % 64; num += 64)
		{
			method_1(rgb, start + num);
		}
		if (size % 64 != 0)
		{
			Array.Copy(rgb, size - size % 64 + start, byte_0, 0, size % 64);
			int_1 = size % 64;
		}
	}

	private byte[] HashFinal()
	{
		byte[] array = new byte[20];
		method_2(byte_0, 0, int_1);
		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				array[i * 4 + j] = (byte)(uint_0[i] >> 8 * (3 - j));
			}
		}
		return array;
	}

	private void Initialize()
	{
		long_0 = 0L;
		int_1 = 0;
		uint_0[0] = 1732584193u;
		uint_0[1] = 4023233417u;
		uint_0[2] = 2562383102u;
		uint_0[3] = 271733878u;
		uint_0[4] = 3285377520u;
	}

	private void method_1(byte[] inputBuffer, int inputOffset)
	{
		long_0 += 64L;
		for (int i = 0; i < 16; i++)
		{
			int num = inputOffset + 4 * i;
			uint_1[i] = (uint)((inputBuffer[num] << 24) | (inputBuffer[num + 1] << 16) | (inputBuffer[num + 2] << 8) | inputBuffer[num + 3]);
		}
		for (int i = 16; i < 80; i++)
		{
			uint num2 = uint_1[i - 3] ^ uint_1[i - 8] ^ uint_1[i - 14] ^ uint_1[i - 16];
			uint num3 = num2 << 1;
			uint num4 = num2 >> 31;
			uint_1[i] = num3 | num4;
		}
		uint num5 = uint_0[0];
		uint num6 = uint_0[1];
		uint num7 = uint_0[2];
		uint num8 = uint_0[3];
		uint num9 = uint_0[4];
		num9 += ((num5 << 5) | (num5 >> 27)) + (((num7 ^ num8) & num6) ^ num8) + 1518500249 + uint_1[0];
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += ((num9 << 5) | (num9 >> 27)) + (((num6 ^ num7) & num5) ^ num7) + 1518500249 + uint_1[1];
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += ((num8 << 5) | (num8 >> 27)) + (((num5 ^ num6) & num9) ^ num6) + 1518500249 + uint_1[2];
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += ((num7 << 5) | (num7 >> 27)) + (((num9 ^ num5) & num8) ^ num5) + 1518500249 + uint_1[3];
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += ((num6 << 5) | (num6 >> 27)) + (((num8 ^ num9) & num7) ^ num9) + 1518500249 + uint_1[4];
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += ((num5 << 5) | (num5 >> 27)) + (((num7 ^ num8) & num6) ^ num8) + 1518500249 + uint_1[5];
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += ((num9 << 5) | (num9 >> 27)) + (((num6 ^ num7) & num5) ^ num7) + 1518500249 + uint_1[6];
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += ((num8 << 5) | (num8 >> 27)) + (((num5 ^ num6) & num9) ^ num6) + 1518500249 + uint_1[7];
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += ((num7 << 5) | (num7 >> 27)) + (((num9 ^ num5) & num8) ^ num5) + 1518500249 + uint_1[8];
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += ((num6 << 5) | (num6 >> 27)) + (((num8 ^ num9) & num7) ^ num9) + 1518500249 + uint_1[9];
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += ((num5 << 5) | (num5 >> 27)) + (((num7 ^ num8) & num6) ^ num8) + 1518500249 + uint_1[10];
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += ((num9 << 5) | (num9 >> 27)) + (((num6 ^ num7) & num5) ^ num7) + 1518500249 + uint_1[11];
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += ((num8 << 5) | (num8 >> 27)) + (((num5 ^ num6) & num9) ^ num6) + 1518500249 + uint_1[12];
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += ((num7 << 5) | (num7 >> 27)) + (((num9 ^ num5) & num8) ^ num5) + 1518500249 + uint_1[13];
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += ((num6 << 5) | (num6 >> 27)) + (((num8 ^ num9) & num7) ^ num9) + 1518500249 + uint_1[14];
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += ((num5 << 5) | (num5 >> 27)) + (((num7 ^ num8) & num6) ^ num8) + 1518500249 + uint_1[15];
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += ((num9 << 5) | (num9 >> 27)) + (((num6 ^ num7) & num5) ^ num7) + 1518500249 + uint_1[16];
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += ((num8 << 5) | (num8 >> 27)) + (((num5 ^ num6) & num9) ^ num6) + 1518500249 + uint_1[17];
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += ((num7 << 5) | (num7 >> 27)) + (((num9 ^ num5) & num8) ^ num5) + 1518500249 + uint_1[18];
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += ((num6 << 5) | (num6 >> 27)) + (((num8 ^ num9) & num7) ^ num9) + 1518500249 + uint_1[19];
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += ((num5 << 5) | (num5 >> 27)) + (num6 ^ num7 ^ num8) + 1859775393 + uint_1[20];
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += ((num9 << 5) | (num9 >> 27)) + (num5 ^ num6 ^ num7) + 1859775393 + uint_1[21];
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += ((num8 << 5) | (num8 >> 27)) + (num9 ^ num5 ^ num6) + 1859775393 + uint_1[22];
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += ((num7 << 5) | (num7 >> 27)) + (num8 ^ num9 ^ num5) + 1859775393 + uint_1[23];
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += ((num6 << 5) | (num6 >> 27)) + (num7 ^ num8 ^ num9) + 1859775393 + uint_1[24];
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += ((num5 << 5) | (num5 >> 27)) + (num6 ^ num7 ^ num8) + 1859775393 + uint_1[25];
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += ((num9 << 5) | (num9 >> 27)) + (num5 ^ num6 ^ num7) + 1859775393 + uint_1[26];
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += ((num8 << 5) | (num8 >> 27)) + (num9 ^ num5 ^ num6) + 1859775393 + uint_1[27];
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += ((num7 << 5) | (num7 >> 27)) + (num8 ^ num9 ^ num5) + 1859775393 + uint_1[28];
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += ((num6 << 5) | (num6 >> 27)) + (num7 ^ num8 ^ num9) + 1859775393 + uint_1[29];
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += ((num5 << 5) | (num5 >> 27)) + (num6 ^ num7 ^ num8) + 1859775393 + uint_1[30];
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += ((num9 << 5) | (num9 >> 27)) + (num5 ^ num6 ^ num7) + 1859775393 + uint_1[31];
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += ((num8 << 5) | (num8 >> 27)) + (num9 ^ num5 ^ num6) + 1859775393 + uint_1[32];
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += ((num7 << 5) | (num7 >> 27)) + (num8 ^ num9 ^ num5) + 1859775393 + uint_1[33];
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += ((num6 << 5) | (num6 >> 27)) + (num7 ^ num8 ^ num9) + 1859775393 + uint_1[34];
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += ((num5 << 5) | (num5 >> 27)) + (num6 ^ num7 ^ num8) + 1859775393 + uint_1[35];
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += ((num9 << 5) | (num9 >> 27)) + (num5 ^ num6 ^ num7) + 1859775393 + uint_1[36];
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += ((num8 << 5) | (num8 >> 27)) + (num9 ^ num5 ^ num6) + 1859775393 + uint_1[37];
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += ((num7 << 5) | (num7 >> 27)) + (num8 ^ num9 ^ num5) + 1859775393 + uint_1[38];
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += ((num6 << 5) | (num6 >> 27)) + (num7 ^ num8 ^ num9) + 1859775393 + uint_1[39];
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += (uint)((int)(((num5 << 5) | (num5 >> 27)) + ((num6 & num7) | (num6 & num8) | (num7 & num8))) + -1894007588 + (int)uint_1[40]);
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += (uint)((int)(((num9 << 5) | (num9 >> 27)) + ((num5 & num6) | (num5 & num7) | (num6 & num7))) + -1894007588 + (int)uint_1[41]);
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += (uint)((int)(((num8 << 5) | (num8 >> 27)) + ((num9 & num5) | (num9 & num6) | (num5 & num6))) + -1894007588 + (int)uint_1[42]);
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += (uint)((int)(((num7 << 5) | (num7 >> 27)) + ((num8 & num9) | (num8 & num5) | (num9 & num5))) + -1894007588 + (int)uint_1[43]);
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += (uint)((int)(((num6 << 5) | (num6 >> 27)) + ((num7 & num8) | (num7 & num9) | (num8 & num9))) + -1894007588 + (int)uint_1[44]);
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += (uint)((int)(((num5 << 5) | (num5 >> 27)) + ((num6 & num7) | (num6 & num8) | (num7 & num8))) + -1894007588 + (int)uint_1[45]);
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += (uint)((int)(((num9 << 5) | (num9 >> 27)) + ((num5 & num6) | (num5 & num7) | (num6 & num7))) + -1894007588 + (int)uint_1[46]);
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += (uint)((int)(((num8 << 5) | (num8 >> 27)) + ((num9 & num5) | (num9 & num6) | (num5 & num6))) + -1894007588 + (int)uint_1[47]);
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += (uint)((int)(((num7 << 5) | (num7 >> 27)) + ((num8 & num9) | (num8 & num5) | (num9 & num5))) + -1894007588 + (int)uint_1[48]);
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += (uint)((int)(((num6 << 5) | (num6 >> 27)) + ((num7 & num8) | (num7 & num9) | (num8 & num9))) + -1894007588 + (int)uint_1[49]);
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += (uint)((int)(((num5 << 5) | (num5 >> 27)) + ((num6 & num7) | (num6 & num8) | (num7 & num8))) + -1894007588 + (int)uint_1[50]);
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += (uint)((int)(((num9 << 5) | (num9 >> 27)) + ((num5 & num6) | (num5 & num7) | (num6 & num7))) + -1894007588 + (int)uint_1[51]);
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += (uint)((int)(((num8 << 5) | (num8 >> 27)) + ((num9 & num5) | (num9 & num6) | (num5 & num6))) + -1894007588 + (int)uint_1[52]);
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += (uint)((int)(((num7 << 5) | (num7 >> 27)) + ((num8 & num9) | (num8 & num5) | (num9 & num5))) + -1894007588 + (int)uint_1[53]);
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += (uint)((int)(((num6 << 5) | (num6 >> 27)) + ((num7 & num8) | (num7 & num9) | (num8 & num9))) + -1894007588 + (int)uint_1[54]);
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += (uint)((int)(((num5 << 5) | (num5 >> 27)) + ((num6 & num7) | (num6 & num8) | (num7 & num8))) + -1894007588 + (int)uint_1[55]);
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += (uint)((int)(((num9 << 5) | (num9 >> 27)) + ((num5 & num6) | (num5 & num7) | (num6 & num7))) + -1894007588 + (int)uint_1[56]);
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += (uint)((int)(((num8 << 5) | (num8 >> 27)) + ((num9 & num5) | (num9 & num6) | (num5 & num6))) + -1894007588 + (int)uint_1[57]);
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += (uint)((int)(((num7 << 5) | (num7 >> 27)) + ((num8 & num9) | (num8 & num5) | (num9 & num5))) + -1894007588 + (int)uint_1[58]);
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += (uint)((int)(((num6 << 5) | (num6 >> 27)) + ((num7 & num8) | (num7 & num9) | (num8 & num9))) + -1894007588 + (int)uint_1[59]);
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += (uint)((int)(((num5 << 5) | (num5 >> 27)) + (num6 ^ num7 ^ num8)) + -899497514 + (int)uint_1[60]);
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += (uint)((int)(((num9 << 5) | (num9 >> 27)) + (num5 ^ num6 ^ num7)) + -899497514 + (int)uint_1[61]);
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += (uint)((int)(((num8 << 5) | (num8 >> 27)) + (num9 ^ num5 ^ num6)) + -899497514 + (int)uint_1[62]);
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += (uint)((int)(((num7 << 5) | (num7 >> 27)) + (num8 ^ num9 ^ num5)) + -899497514 + (int)uint_1[63]);
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += (uint)((int)(((num6 << 5) | (num6 >> 27)) + (num7 ^ num8 ^ num9)) + -899497514 + (int)uint_1[64]);
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += (uint)((int)(((num5 << 5) | (num5 >> 27)) + (num6 ^ num7 ^ num8)) + -899497514 + (int)uint_1[65]);
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += (uint)((int)(((num9 << 5) | (num9 >> 27)) + (num5 ^ num6 ^ num7)) + -899497514 + (int)uint_1[66]);
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += (uint)((int)(((num8 << 5) | (num8 >> 27)) + (num9 ^ num5 ^ num6)) + -899497514 + (int)uint_1[67]);
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += (uint)((int)(((num7 << 5) | (num7 >> 27)) + (num8 ^ num9 ^ num5)) + -899497514 + (int)uint_1[68]);
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += (uint)((int)(((num6 << 5) | (num6 >> 27)) + (num7 ^ num8 ^ num9)) + -899497514 + (int)uint_1[69]);
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += (uint)((int)(((num5 << 5) | (num5 >> 27)) + (num6 ^ num7 ^ num8)) + -899497514 + (int)uint_1[70]);
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += (uint)((int)(((num9 << 5) | (num9 >> 27)) + (num5 ^ num6 ^ num7)) + -899497514 + (int)uint_1[71]);
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += (uint)((int)(((num8 << 5) | (num8 >> 27)) + (num9 ^ num5 ^ num6)) + -899497514 + (int)uint_1[72]);
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += (uint)((int)(((num7 << 5) | (num7 >> 27)) + (num8 ^ num9 ^ num5)) + -899497514 + (int)uint_1[73]);
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += (uint)((int)(((num6 << 5) | (num6 >> 27)) + (num7 ^ num8 ^ num9)) + -899497514 + (int)uint_1[74]);
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += (uint)((int)(((num5 << 5) | (num5 >> 27)) + (num6 ^ num7 ^ num8)) + -899497514 + (int)uint_1[75]);
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += (uint)((int)(((num9 << 5) | (num9 >> 27)) + (num5 ^ num6 ^ num7)) + -899497514 + (int)uint_1[76]);
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += (uint)((int)(((num8 << 5) | (num8 >> 27)) + (num9 ^ num5 ^ num6)) + -899497514 + (int)uint_1[77]);
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += (uint)((int)(((num7 << 5) | (num7 >> 27)) + (num8 ^ num9 ^ num5)) + -899497514 + (int)uint_1[78]);
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += (uint)((int)(((num6 << 5) | (num6 >> 27)) + (num7 ^ num8 ^ num9)) + -899497514 + (int)uint_1[79]);
		num7 = (num7 << 30) | (num7 >> 2);
		uint_0[0] += num5;
		uint_0[1] += num6;
		uint_0[2] += num7;
		uint_0[3] += num8;
		uint_0[4] += num9;
	}

	private void method_2(byte[] inputBuffer, int inputOffset, int inputCount)
	{
		long num = long_0 + inputCount;
		int num2 = 56 - (int)(num % 64L);
		if (num2 < 1)
		{
			num2 += 64;
		}
		byte[] array = new byte[inputCount + num2 + 8];
		for (int i = 0; i < inputCount; i++)
		{
			array[i] = inputBuffer[i + inputOffset];
		}
		array[inputCount] = 128;
		for (int j = inputCount + 1; j < inputCount + num2; j++)
		{
			array[j] = 0;
		}
		long length = num << 3;
		smethod_0(length, array, inputCount + num2);
		method_1(array, 0);
		if (inputCount + num2 + 8 == 128)
		{
			method_1(array, 64);
		}
	}

	internal static void smethod_0(long length, byte[] buffer, int position)
	{
		buffer[position++] = (byte)(length >> 56);
		buffer[position++] = (byte)(length >> 48);
		buffer[position++] = (byte)(length >> 40);
		buffer[position++] = (byte)(length >> 32);
		buffer[position++] = (byte)(length >> 24);
		buffer[position++] = (byte)(length >> 16);
		buffer[position++] = (byte)(length >> 8);
		buffer[position] = (byte)length;
	}
}
