using System.IO;

namespace ns276;

internal class Class6740
{
	private const int int_0 = 8192;

	private long long_0;

	private static uint[] uint_0;

	private uint uint_1 = uint.MaxValue;

	public long TotalBytesRead => long_0;

	public int Crc32Result => (int)(~uint_1);

	public int method_0(Stream input)
	{
		return method_1(input, null);
	}

	public int method_1(Stream input, Stream output)
	{
		if (input == null)
		{
			throw new Exception67("The input stream must not be null.");
		}
		byte[] array = new byte[8192];
		int count = 8192;
		long_0 = 0L;
		int num = input.Read(array, 0, 8192);
		output?.Write(array, 0, num);
		long_0 += num;
		while (num > 0)
		{
			method_3(array, 0, num);
			num = input.Read(array, 0, count);
			output?.Write(array, 0, num);
			long_0 += num;
		}
		return (int)(~uint_1);
	}

	public int method_2(int W, byte B)
	{
		return smethod_0((uint)W, B);
	}

	internal static int smethod_0(uint W, byte B)
	{
		return (int)(uint_0[(W ^ B) & 0xFF] ^ (W >> 8));
	}

	public void method_3(byte[] block, int offset, int count)
	{
		if (block == null)
		{
			throw new Exception67("The data buffer must not be null.");
		}
		for (int i = 0; i < count; i++)
		{
			int num = offset + i;
			uint_1 = (uint_1 >> 8) ^ uint_0[block[num] ^ (uint_1 & 0xFF)];
		}
		long_0 += count;
	}

	static Class6740()
	{
		uint num = 3988292384u;
		uint_0 = new uint[256];
		for (uint num2 = 0u; num2 < 256; num2++)
		{
			uint num3 = num2;
			for (uint num4 = 8u; num4 != 0; num4--)
			{
				num3 = (((num3 & 1) != 1) ? (num3 >> 1) : ((num3 >> 1) ^ num));
			}
			uint_0[num2] = num3;
		}
	}
}
