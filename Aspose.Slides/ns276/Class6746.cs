namespace ns276;

internal sealed class Class6746
{
	private const int int_0 = 32;

	private const int int_1 = 8;

	private const int int_2 = 0;

	private const int int_3 = 1;

	private const int int_4 = 2;

	private const int int_5 = 3;

	private const int int_6 = 4;

	private const int int_7 = 5;

	private const int int_8 = 6;

	private const int int_9 = 7;

	private const int int_10 = 8;

	private const int int_11 = 9;

	private const int int_12 = 10;

	private const int int_13 = 11;

	private const int int_14 = 12;

	private const int int_15 = 13;

	internal int int_16;

	internal Class6756 class6756_0;

	internal int int_17;

	internal long[] long_0 = new long[1];

	internal long long_1;

	internal int int_18;

	private bool bool_0 = true;

	internal int int_19;

	internal Class6744 class6744_0;

	private static byte[] byte_0 = new byte[4] { 0, 0, 255, 255 };

	internal bool HandleRfc1950HeaderBytes
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public Class6746()
	{
	}

	public Class6746(bool expectRfc1950HeaderBytes)
	{
		bool_0 = expectRfc1950HeaderBytes;
	}

	internal int Reset()
	{
		Class6756 @class = class6756_0;
		class6756_0.long_1 = 0L;
		@class.long_0 = 0L;
		class6756_0.string_0 = null;
		int_16 = ((!HandleRfc1950HeaderBytes) ? 7 : 0);
		class6744_0.Reset(null);
		return 0;
	}

	internal int method_0()
	{
		if (class6744_0 != null)
		{
			class6744_0.method_1();
		}
		class6744_0 = null;
		return 0;
	}

	internal int Initialize(Class6756 codec, int w)
	{
		class6756_0 = codec;
		class6756_0.string_0 = null;
		class6744_0 = null;
		if (w >= 8 && w <= 15)
		{
			int_19 = w;
			class6744_0 = new Class6744(codec, HandleRfc1950HeaderBytes ? this : null, 1 << w);
			Reset();
			return 0;
		}
		method_0();
		throw new Exception67("Bad window size.");
	}

	internal int method_1(Enum898 flush)
	{
		int num = 0;
		int num2 = 0;
		int num3 = (int)flush;
		if (class6756_0.byte_0 == null)
		{
			throw new Exception67("InputBuffer is null. ");
		}
		num3 = ((num3 == 4) ? (-5) : 0);
		num = -5;
		while (true)
		{
			switch (int_16)
			{
			case 11:
				if (class6756_0.int_1 != 0)
				{
					num = num3;
					class6756_0.int_1--;
					class6756_0.long_0++;
					long_1 += class6756_0.byte_0[class6756_0.int_0++] & 0xFFL;
					if ((int)long_0[0] != (int)long_1)
					{
						int_16 = 13;
						class6756_0.string_0 = "incorrect data check";
						int_18 = 5;
						continue;
					}
					int_16 = 12;
					break;
				}
				return num;
			case 10:
				if (class6756_0.int_1 != 0)
				{
					num = num3;
					class6756_0.int_1--;
					class6756_0.long_0++;
					long_1 += ((class6756_0.byte_0[class6756_0.int_0++] & 0xFF) << 8) & 0xFF00L;
					int_16 = 11;
					goto case 11;
				}
				return num;
			case 9:
				if (class6756_0.int_1 != 0)
				{
					num = num3;
					class6756_0.int_1--;
					class6756_0.long_0++;
					long_1 += ((class6756_0.byte_0[class6756_0.int_0++] & 0xFF) << 16) & 0xFF0000L;
					int_16 = 10;
					goto case 10;
				}
				return num;
			case 8:
				if (class6756_0.int_1 != 0)
				{
					num = num3;
					class6756_0.int_1--;
					class6756_0.long_0++;
					long_1 = ((class6756_0.byte_0[class6756_0.int_0++] & 0xFF) << 24) & -16777216;
					int_16 = 9;
					goto case 9;
				}
				return num;
			case 7:
				num = class6744_0.method_0(num);
				switch (num)
				{
				case -3:
					int_16 = 13;
					int_18 = 0;
					continue;
				case 0:
					num = num3;
					break;
				}
				if (num == 1)
				{
					num = num3;
					class6744_0.Reset(long_0);
					if (!HandleRfc1950HeaderBytes)
					{
						int_16 = 12;
						continue;
					}
					int_16 = 8;
					goto case 8;
				}
				return num;
			case 1:
				if (class6756_0.int_1 != 0)
				{
					num = num3;
					class6756_0.int_1--;
					class6756_0.long_0++;
					num2 = class6756_0.byte_0[class6756_0.int_0++] & 0xFF;
					if (((int_17 << 8) + num2) % 31 != 0)
					{
						int_16 = 13;
						class6756_0.string_0 = "incorrect header check";
						int_18 = 5;
						continue;
					}
					if ((num2 & 0x20) == 0)
					{
						int_16 = 7;
						continue;
					}
					int_16 = 2;
					goto case 2;
				}
				return num;
			case 0:
				if (class6756_0.int_1 != 0)
				{
					num = num3;
					class6756_0.int_1--;
					class6756_0.long_0++;
					if (((int_17 = class6756_0.byte_0[class6756_0.int_0++]) & 0xF) != 8)
					{
						int_16 = 13;
						class6756_0.string_0 = $"unknown compression method (0x{int_17:X2})";
						int_18 = 5;
						continue;
					}
					if ((int_17 >> 4) + 8 > int_19)
					{
						int_16 = 13;
						class6756_0.string_0 = $"invalid window size ({(int_17 >> 4) + 8})";
						int_18 = 5;
						continue;
					}
					int_16 = 1;
					goto case 1;
				}
				return num;
			default:
				throw new Exception67("Stream error.");
			case 2:
				if (class6756_0.int_1 == 0)
				{
					return num;
				}
				num = num3;
				class6756_0.int_1--;
				class6756_0.long_0++;
				long_1 = ((class6756_0.byte_0[class6756_0.int_0++] & 0xFF) << 24) & -16777216;
				int_16 = 3;
				goto case 3;
			case 3:
				if (class6756_0.int_1 == 0)
				{
					return num;
				}
				num = num3;
				class6756_0.int_1--;
				class6756_0.long_0++;
				long_1 += ((class6756_0.byte_0[class6756_0.int_0++] & 0xFF) << 16) & 0xFF0000L;
				int_16 = 4;
				goto case 4;
			case 4:
				if (class6756_0.int_1 == 0)
				{
					return num;
				}
				num = num3;
				class6756_0.int_1--;
				class6756_0.long_0++;
				long_1 += ((class6756_0.byte_0[class6756_0.int_0++] & 0xFF) << 8) & 0xFF00L;
				int_16 = 5;
				goto case 5;
			case 5:
				if (class6756_0.int_1 == 0)
				{
					return num;
				}
				num = num3;
				class6756_0.int_1--;
				class6756_0.long_0++;
				long_1 += class6756_0.byte_0[class6756_0.int_0++] & 0xFFL;
				class6756_0.long_2 = long_1;
				int_16 = 6;
				return 2;
			case 6:
				int_16 = 13;
				class6756_0.string_0 = "need dictionary";
				int_18 = 0;
				return -2;
			case 13:
				throw new Exception67($"Bad state ({class6756_0.string_0})");
			case 12:
				break;
			}
			break;
		}
		return 1;
	}

	internal int method_2(byte[] dictionary)
	{
		int start = 0;
		int num = dictionary.Length;
		if (int_16 != 6)
		{
			throw new Exception67("Stream error.");
		}
		if (Class6755.smethod_0(1L, dictionary, 0, dictionary.Length) != class6756_0.long_2)
		{
			return -3;
		}
		class6756_0.long_2 = Class6755.smethod_0(0L, null, 0, 0);
		if (num >= 1 << int_19)
		{
			num = (1 << int_19) - 1;
			start = dictionary.Length - num;
		}
		class6744_0.method_2(dictionary, start, num);
		int_16 = 7;
		return 0;
	}

	internal int method_3()
	{
		if (int_16 != 13)
		{
			int_16 = 13;
			int_18 = 0;
		}
		int num;
		if ((num = class6756_0.int_1) == 0)
		{
			return -5;
		}
		int num2 = class6756_0.int_0;
		int num3 = int_18;
		while (num != 0 && num3 < 4)
		{
			num3 = ((class6756_0.byte_0[num2] != byte_0[num3]) ? ((class6756_0.byte_0[num2] == 0) ? (4 - num3) : 0) : (num3 + 1));
			num2++;
			num--;
		}
		class6756_0.long_0 += num2 - class6756_0.int_0;
		class6756_0.int_0 = num2;
		class6756_0.int_1 = num;
		int_18 = num3;
		if (num3 != 4)
		{
			return -3;
		}
		long num4 = class6756_0.long_0;
		long num5 = class6756_0.long_1;
		Reset();
		class6756_0.long_0 = num4;
		class6756_0.long_1 = num5;
		int_16 = 7;
		return 0;
	}

	internal int method_4(Class6756 z)
	{
		return class6744_0.method_3();
	}
}
