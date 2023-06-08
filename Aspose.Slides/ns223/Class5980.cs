namespace ns223;

internal class Class5980
{
	private int int_0 = 16;

	private long long_0 = 4129L;

	private int int_1 = 1;

	private long long_1 = 65535L;

	private long long_2;

	private int int_2;

	private int int_3;

	private long long_3;

	private long long_4;

	private long long_5;

	private long long_6;

	private long[] long_7 = new long[256];

	private Enum745 enum745_0;

	public Enum745 Encoding => enum745_0;

	public Class5980()
		: this(Enum745.const_1)
	{
	}

	public Class5980(Enum745 encoding)
	{
		method_0(encoding);
	}

	private void method_0(Enum745 encoding)
	{
		enum745_0 = encoding;
		switch (encoding)
		{
		case Enum745.const_0:
			int_0 = 16;
			int_1 = 1;
			long_0 = 32773L;
			long_1 = 0L;
			long_2 = 0L;
			int_2 = 1;
			int_3 = 1;
			break;
		default:
			int_0 = 32;
			int_1 = 1;
			long_0 = 79764919L;
			long_1 = 4294967295L;
			long_2 = 4294967295L;
			int_2 = 1;
			int_3 = 1;
			break;
		case Enum745.const_2:
			int_0 = 16;
			int_1 = 1;
			long_0 = 4129L;
			long_1 = 65535L;
			long_2 = 0L;
			int_2 = 0;
			int_3 = 0;
			break;
		case Enum745.const_3:
			int_0 = 16;
			int_1 = 1;
			long_0 = 4129L;
			long_1 = 0L;
			long_2 = 0L;
			int_2 = 1;
			int_3 = 1;
			break;
		}
		long_3 = ((1L << int_0 - 1) - 1L << 1) | 1L;
		long_4 = 1L << int_0 - 1;
		method_2();
		long num;
		if (int_1 == 0)
		{
			long_6 = long_1;
			num = long_1;
			for (int i = 0; i < int_0; i++)
			{
				long num2 = num & long_4;
				num <<= 1;
				if (num2 != 0L)
				{
					num ^= long_0;
				}
			}
			num &= long_3;
			long_5 = num;
			return;
		}
		long_5 = long_1;
		num = long_1;
		for (int i = 0; i < int_0; i++)
		{
			long num2 = num & 1L;
			if (num2 != 0L)
			{
				num ^= long_0;
			}
			num >>= 1;
			if (num2 != 0L)
			{
				num |= long_4;
			}
		}
		long_6 = num;
	}

	public int method_1(byte[] p)
	{
		long num = long_5;
		if (int_2 != 0)
		{
			num = smethod_0(num, int_0);
		}
		if (int_2 == 0)
		{
			for (int i = 0; i < p.Length; i++)
			{
				num = (num << 8) ^ long_7[(int)(((num >> int_0 - 8) & 0xFFL) ^ p[i])];
			}
		}
		else
		{
			for (int j = 0; j < p.Length; j++)
			{
				num = (num >> 8) ^ long_7[(int)((num & 0xFFL) ^ p[j])];
			}
		}
		if ((int_3 ^ int_2) != 0)
		{
			num = smethod_0(num, int_0);
		}
		num ^= long_2;
		num &= long_3;
		return (int)num;
	}

	private static long smethod_0(long crc, int bitnum)
	{
		long num = 1L;
		long num2 = 0L;
		for (long num3 = 1L << bitnum - 1; num3 != 0L; num3 >>= 1)
		{
			if ((crc & num3) != 0L)
			{
				num2 |= num;
			}
			num <<= 1;
		}
		return num2;
	}

	private void method_2()
	{
		for (int i = 0; i < 256; i++)
		{
			long num = i;
			if (int_2 != 0)
			{
				num = smethod_0(num, 8);
			}
			num <<= int_0 - 8;
			for (int j = 0; j < 8; j++)
			{
				long num2 = num & long_4;
				num <<= 1;
				if (num2 != 0L)
				{
					num ^= long_0;
				}
			}
			if (int_2 != 0)
			{
				num = smethod_0(num, int_0);
			}
			num &= long_3;
			long_7[i] = num;
		}
	}
}
