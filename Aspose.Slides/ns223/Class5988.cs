using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace ns223;

internal class Class5988 : HashAlgorithm
{
	private const int int_0 = 64;

	private byte[] byte_0;

	private int int_1;

	private long long_0;

	private uint[] uint_0 = new uint[8] { 1779033703u, 3144134277u, 1013904242u, 2773480762u, 1359893119u, 2600822924u, 528734635u, 1541459225u };

	private static uint[] uint_1 = new uint[64]
	{
		1116352408u, 1899447441u, 3049323471u, 3921009573u, 961987163u, 1508970993u, 2453635748u, 2870763221u, 3624381080u, 310598401u,
		607225278u, 1426881987u, 1925078388u, 2162078206u, 2614888103u, 3248222580u, 3835390401u, 4022224774u, 264347078u, 604807628u,
		770255983u, 1249150122u, 1555081692u, 1996064986u, 2554220882u, 2821834349u, 2952996808u, 3210313671u, 3336571891u, 3584528711u,
		113926993u, 338241895u, 666307205u, 773529912u, 1294757372u, 1396182291u, 1695183700u, 1986661051u, 2177026350u, 2456956037u,
		2730485921u, 2820302411u, 3259730800u, 3345764771u, 3516065817u, 3600352804u, 4094571909u, 275423344u, 430227734u, 506948616u,
		659060556u, 883997877u, 958139571u, 1322822218u, 1537002063u, 1747873779u, 1955562222u, 2024104815u, 2227730452u, 2361852424u,
		2428436474u, 2756734187u, 3204031479u, 3329325298u
	};

	public override void Initialize()
	{
		uint_0 = new uint[8] { 1779033703u, 3144134277u, 1013904242u, 2773480762u, 1359893119u, 2600822924u, 528734635u, 1541459225u };
		long_0 = 0L;
		int_1 = 0;
		byte_0 = new byte[64];
	}

	protected override void HashCore(byte[] array, int ibStart, int cbSize)
	{
		if (int_1 > 0)
		{
			if (cbSize < 64 - int_1)
			{
				Array.Copy(array, ibStart, byte_0, int_1, cbSize);
				int_1 += cbSize;
				return;
			}
			int num = 64 - int_1;
			Array.Copy(array, ibStart, byte_0, int_1, num);
			method_0(byte_0, 0);
			long_0 += 64L;
			int_1 = 0;
			ibStart += num;
			cbSize -= num;
		}
		for (int num = 0; num < cbSize - cbSize % 64; num += 64)
		{
			method_0(array, ibStart + num);
			long_0 += 64L;
		}
		int num2 = cbSize % 64;
		if (num2 != 0)
		{
			Array.Copy(array, cbSize - num2 + ibStart, byte_0, 0, num2);
			int_1 = num2;
		}
	}

	protected override byte[] HashFinal()
	{
		return method_1(byte_0, 0, int_1);
	}

	public Class5988()
	{
		HashSizeValue = 256;
		Initialize();
	}

	private void method_0(byte[] inputBuffer, int inputOffset)
	{
		uint[] array = new uint[64];
		uint num = uint_0[0];
		uint num2 = uint_0[1];
		uint num3 = uint_0[2];
		uint num4 = uint_0[3];
		uint num5 = uint_0[4];
		uint num6 = uint_0[5];
		uint num7 = uint_0[6];
		uint num8 = uint_0[7];
		uint[] array2 = smethod_0(inputBuffer, inputOffset, 64);
		Array.Copy(array2, 0, array, 0, array2.Length);
		for (int i = 16; i < 64; i++)
		{
			array[i] = (((array[i - 2] >> 17) | (array[i - 2] << 15)) ^ ((array[i - 2] >> 19) | (array[i - 2] << 13)) ^ (array[i - 2] >> 10)) + array[i - 7] + (((array[i - 15] >> 7) | (array[i - 15] << 25)) ^ ((array[i - 15] >> 18) | (array[i - 15] << 14)) ^ (array[i - 15] >> 3)) + array[i - 16];
		}
		for (int i = 0; i < 64; i++)
		{
			uint num9 = num8 + (((num5 >> 6) | (num5 << 26)) ^ ((num5 >> 11) | (num5 << 21)) ^ ((num5 >> 25) | (num5 << 7))) + ((num5 & num6) ^ (~num5 & num7)) + uint_1[i] + array[i];
			uint num10 = (((num >> 2) | (num << 30)) ^ ((num >> 13) | (num << 19)) ^ ((num >> 22) | (num << 10))) + ((num & num2) ^ (num & num3) ^ (num2 & num3));
			num8 = num7;
			num7 = num6;
			num6 = num5;
			num5 = num4 + num9;
			num4 = num3;
			num3 = num2;
			num2 = num;
			num = num9 + num10;
		}
		uint_0[0] += num;
		uint_0[1] += num2;
		uint_0[2] += num3;
		uint_0[3] += num4;
		uint_0[4] += num5;
		uint_0[5] += num6;
		uint_0[6] += num7;
		uint_0[7] += num8;
	}

	private byte[] method_1(byte[] inputBuffer, int inputOffset, int inputCount)
	{
		method_2(inputBuffer, inputOffset, inputCount);
		List<byte> list = new List<byte>();
		uint[] array = uint_0;
		foreach (uint num in array)
		{
			byte[] collection = smethod_2(new uint[1] { num }, 0, 1);
			list.AddRange(collection);
		}
		return list.ToArray();
	}

	private void method_2(byte[] inputBuffer, int inputOffset, int inputCount)
	{
		int num = (int)((ulong)(inputCount + long_0) % 64uL);
		num = 56 - num;
		if (num < 1)
		{
			num += 64;
		}
		byte[] array = new byte[inputCount + num + 8];
		Array.Copy(inputBuffer, inputOffset, array, 0, inputCount);
		array[inputCount] = 128;
		ulong num2 = (ulong)((long_0 + inputCount) * 8L);
		byte[] sourceArray = smethod_1(new ulong[1] { num2 }, 0, 1);
		Array.Copy(sourceArray, 0, array, array.Length - 8, 8);
		method_0(array, 0);
		if (array.Length == 128)
		{
			method_0(array, 64);
		}
	}

	private static uint[] smethod_0(byte[] array, int offset, int length)
	{
		if (length + offset > array.Length)
		{
			throw new ArgumentException("OutOfBound");
		}
		if (length % 4 != 0)
		{
			throw new ArgumentException("length");
		}
		uint[] array2 = new uint[length / 4];
		int i = 0;
		int num = offset;
		for (; i < array2.Length; i++)
		{
			array2[i] = (uint)(((array[num++] & 0xFF) << 24) | ((array[num++] & 0xFF) << 16) | ((array[num++] & 0xFF) << 8)) | (array[num++] & 0xFFu);
		}
		return array2;
	}

	private static byte[] smethod_1(ulong[] array, int offset, int length)
	{
		if (length + offset > array.Length)
		{
			throw new ArgumentException("Length and offset values are out of bound");
		}
		if (length > 268435455)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		byte[] array2 = new byte[length * 8];
		for (int i = offset; i < offset + length; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				array2[(i - offset) * 8 + (7 - j)] = (byte)(array[i] >> j * 8);
			}
		}
		return array2;
	}

	private static byte[] smethod_2(uint[] array, int offset, int length)
	{
		if (length + offset > array.Length)
		{
			throw new ArgumentException("OutOfBound");
		}
		if (length > 536870911)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		byte[] array2 = new byte[length * 4];
		for (int i = offset; i < offset + length; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				array2[(i - offset) * 4 + (3 - j)] = (byte)(array[i] >> j * 8);
			}
		}
		return array2;
	}
}
