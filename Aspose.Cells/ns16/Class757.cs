using System.Runtime.CompilerServices;

namespace ns16;

internal sealed class Class757
{
	private enum Enum39
	{
		const_0,
		const_1,
		const_2,
		const_3,
		const_4,
		const_5,
		const_6,
		const_7,
		const_8,
		const_9,
		const_10,
		const_11,
		const_12,
		const_13
	}

	private Enum39 enum39_0;

	internal Class765 class765_0;

	internal int int_0;

	internal uint uint_0;

	internal uint uint_1;

	internal int int_1;

	private bool bool_0 = true;

	internal int int_2;

	internal Class754 class754_0;

	private static readonly byte[] byte_0 = new byte[4] { 0, 0, 255, 255 };

	[SpecialName]
	internal bool method_0()
	{
		return bool_0;
	}

	public Class757()
	{
	}

	public Class757(bool bool_1)
	{
		bool_0 = bool_1;
	}

	internal int Reset()
	{
		Class765 @class = class765_0;
		class765_0.long_1 = 0L;
		@class.long_0 = 0L;
		class765_0.string_0 = null;
		enum39_0 = ((!method_0()) ? Enum39.const_7 : Enum39.const_0);
		class754_0.Reset();
		return 0;
	}

	internal int method_1()
	{
		if (class754_0 != null)
		{
			class754_0.method_0();
		}
		class754_0 = null;
		return 0;
	}

	internal int Initialize(Class765 class765_1, int int_3)
	{
		class765_0 = class765_1;
		class765_0.string_0 = null;
		class754_0 = null;
		if (int_3 >= 8 && int_3 <= 15)
		{
			int_2 = int_3;
			class754_0 = new Class754(class765_1, method_0() ? this : null, 1 << int_3);
			Reset();
			return 0;
		}
		method_1();
		throw new Exception5("Bad window size.");
	}

	internal int method_2(Enum41 enum41_0)
	{
		if (class765_0.byte_0 == null)
		{
			throw new Exception5("InputBuffer is null. ");
		}
		int num = 0;
		int num2 = -5;
		while (true)
		{
			switch (enum39_0)
			{
			case Enum39.const_11:
				if (class765_0.int_1 != 0)
				{
					num2 = num;
					class765_0.int_1--;
					class765_0.long_0++;
					uint_1 += (uint)(class765_0.byte_0[class765_0.int_0++] & 0xFF);
					if (uint_0 != uint_1)
					{
						enum39_0 = Enum39.const_13;
						class765_0.string_0 = "incorrect data check";
						int_1 = 5;
						break;
					}
					enum39_0 = Enum39.const_12;
					return 1;
				}
				return num2;
			case Enum39.const_10:
				if (class765_0.int_1 != 0)
				{
					num2 = num;
					class765_0.int_1--;
					class765_0.long_0++;
					uint_1 += (uint)((class765_0.byte_0[class765_0.int_0++] << 8) & 0xFF00);
					enum39_0 = Enum39.const_11;
					break;
				}
				return num2;
			case Enum39.const_9:
				if (class765_0.int_1 != 0)
				{
					num2 = num;
					class765_0.int_1--;
					class765_0.long_0++;
					uint_1 += (uint)((class765_0.byte_0[class765_0.int_0++] << 16) & 0xFF0000);
					enum39_0 = Enum39.const_10;
					break;
				}
				return num2;
			case Enum39.const_8:
				if (class765_0.int_1 != 0)
				{
					num2 = num;
					class765_0.int_1--;
					class765_0.long_0++;
					uint_1 = (uint)((class765_0.byte_0[class765_0.int_0++] << 24) & 0xFF000000u);
					enum39_0 = Enum39.const_9;
					break;
				}
				return num2;
			case Enum39.const_7:
				num2 = class754_0.Process(num2);
				switch (num2)
				{
				case -3:
					enum39_0 = Enum39.const_13;
					int_1 = 0;
					goto end_IL_05b9;
				case 0:
					num2 = num;
					break;
				}
				if (num2 == 1)
				{
					num2 = num;
					uint_0 = class754_0.Reset();
					if (method_0())
					{
						enum39_0 = Enum39.const_8;
						break;
					}
					enum39_0 = Enum39.const_12;
					return 1;
				}
				return num2;
			case Enum39.const_4:
				if (class765_0.int_1 != 0)
				{
					num2 = num;
					class765_0.int_1--;
					class765_0.long_0++;
					uint_1 += (uint)((class765_0.byte_0[class765_0.int_0++] << 8) & 0xFF00);
					enum39_0 = Enum39.const_5;
					break;
				}
				return num2;
			case Enum39.const_3:
				if (class765_0.int_1 != 0)
				{
					num2 = num;
					class765_0.int_1--;
					class765_0.long_0++;
					uint_1 += (uint)((class765_0.byte_0[class765_0.int_0++] << 16) & 0xFF0000);
					enum39_0 = Enum39.const_4;
					break;
				}
				return num2;
			case Enum39.const_2:
				if (class765_0.int_1 != 0)
				{
					num2 = num;
					class765_0.int_1--;
					class765_0.long_0++;
					uint_1 = (uint)((class765_0.byte_0[class765_0.int_0++] << 24) & 0xFF000000u);
					enum39_0 = Enum39.const_3;
					break;
				}
				return num2;
			case Enum39.const_1:
				if (class765_0.int_1 != 0)
				{
					num2 = num;
					class765_0.int_1--;
					class765_0.long_0++;
					int num3 = class765_0.byte_0[class765_0.int_0++] & 0xFF;
					if (((int_0 << 8) + num3) % 31 != 0)
					{
						enum39_0 = Enum39.const_13;
						class765_0.string_0 = "incorrect header check";
						int_1 = 5;
					}
					else
					{
						enum39_0 = (((num3 & 0x20) == 0) ? Enum39.const_7 : Enum39.const_2);
					}
					break;
				}
				return num2;
			case Enum39.const_0:
				if (class765_0.int_1 != 0)
				{
					num2 = num;
					class765_0.int_1--;
					class765_0.long_0++;
					if (((int_0 = class765_0.byte_0[class765_0.int_0++]) & 0xF) != 8)
					{
						enum39_0 = Enum39.const_13;
						class765_0.string_0 = $"unknown compression method (0x{int_0:X2})";
						int_1 = 5;
					}
					else if ((int_0 >> 4) + 8 > int_2)
					{
						enum39_0 = Enum39.const_13;
						class765_0.string_0 = $"invalid window size ({(int_0 >> 4) + 8})";
						int_1 = 5;
					}
					else
					{
						enum39_0 = Enum39.const_1;
					}
					break;
				}
				return num2;
			default:
				throw new Exception5("Stream error.");
			case Enum39.const_5:
				if (class765_0.int_1 == 0)
				{
					return num2;
				}
				num2 = num;
				class765_0.int_1--;
				class765_0.long_0++;
				uint_1 += (uint)(class765_0.byte_0[class765_0.int_0++] & 0xFF);
				class765_0.uint_0 = uint_1;
				enum39_0 = Enum39.const_6;
				return 2;
			case Enum39.const_6:
				enum39_0 = Enum39.const_13;
				class765_0.string_0 = "need dictionary";
				int_1 = 0;
				return -2;
			case Enum39.const_13:
				throw new Exception5($"Bad state ({class765_0.string_0})");
			case Enum39.const_12:
				{
					return 1;
				}
				end_IL_05b9:
				break;
			}
		}
	}
}
