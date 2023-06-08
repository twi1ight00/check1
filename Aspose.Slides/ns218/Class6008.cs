using System;

namespace ns218;

internal class Class6008
{
	public const int int_0 = 57344;

	public const int int_1 = 0;

	public const int int_2 = 8192;

	public const int int_3 = 16384;

	public const int int_4 = 24576;

	public const int int_5 = 224;

	public const int int_6 = 128;

	public const int int_7 = 96;

	public const int int_8 = 64;

	public const int int_9 = 32;

	public const int int_10 = 0;

	public const int int_11 = 248;

	public const int int_12 = 255;

	public const int int_13 = 0;

	public const int int_14 = 8192;

	public const int int_15 = 8193;

	public const int int_16 = 8208;

	public const int int_17 = 8209;

	public const int int_18 = 8210;

	public const int int_19 = 8211;

	public const int int_20 = 8212;

	public const int int_21 = 8213;

	public const int int_22 = 8214;

	public const int int_23 = 8215;

	public const int int_24 = 8216;

	public const int int_25 = 8217;

	public const int int_26 = 16519;

	public const int int_27 = 16481;

	public const int int_28 = 16475;

	public const int int_29 = 16466;

	public const int int_30 = 16457;

	public const int int_31 = 16416;

	public const int int_32 = 16417;

	public const int int_33 = 16412;

	public const int int_34 = 16403;

	public const int int_35 = 16394;

	public const int int_36 = 16393;

	public const int int_37 = 24576;

	public const int int_38 = 24577;

	public const int int_39 = 24578;

	public const int int_40 = 24579;

	public const int int_41 = 24580;

	public const int int_42 = 16519;

	public static readonly string[] string_0 = new string[25]
	{
		"None", "TextUnknown", "Text", "EmSpace", "EnSpace", "Em14Space", "NonBreakingSpace", "EmDash", "EnDash", "NonBreakingHyphen",
		"OptionalHyphen", "ZeroWidthNonJoiner", "ZeroWidthJoiner", "Story", "Section", "Table", "Row", "Cell", "ParagraphUnknown", "Paragraph",
		"Page", "Column", "Line", "Wrap", "Shape"
	};

	public static readonly int[] int_43 = new int[25]
	{
		0, 8192, 8193, 8208, 8209, 8210, 8211, 8212, 8213, 8214,
		8215, 8216, 8217, 16519, 16481, 16475, 16466, 16457, 16416, 16417,
		16412, 16403, 16394, 16393, 24580
	};

	private static readonly char[] char_0 = new char[2] { ' ', '\t' };

	private Class6008()
	{
	}

	public static bool smethod_0(int value)
	{
		return 8192 == (value & 0xE000);
	}

	public static bool smethod_1(int value)
	{
		if (smethod_0(value))
		{
			return (value & 0xFF) >= 16;
		}
		return false;
	}

	public static bool smethod_2(int value)
	{
		return (value & 0xE000) == 16384;
	}

	public static bool smethod_3(int value)
	{
		if (smethod_2(value))
		{
			return (value & 0xE0) == 0;
		}
		return false;
	}

	public static bool smethod_4(int value)
	{
		if (smethod_2(value))
		{
			return (value & 0xE0) == 128;
		}
		return false;
	}

	public static bool smethod_5(int value)
	{
		if (smethod_2(value))
		{
			return (value & 0xE0) == 96;
		}
		return false;
	}

	public static bool smethod_6(int value)
	{
		if (smethod_2(value))
		{
			return (value & 0xE0) == 64;
		}
		return false;
	}

	public static bool smethod_7(int value)
	{
		if (smethod_2(value))
		{
			return (value & 0xE0) == 32;
		}
		return false;
	}

	public static bool smethod_8(int value)
	{
		return smethod_14(value) < smethod_14(16417);
	}

	public static bool smethod_9(int value)
	{
		return smethod_14(value) >= smethod_14(16481);
	}

	public static bool smethod_10(int value)
	{
		return smethod_14(value) >= smethod_14(16417);
	}

	public static bool smethod_11(int value)
	{
		return smethod_14(value) >= smethod_14(16457);
	}

	public static bool smethod_12(int value)
	{
		return smethod_14(value) >= smethod_14(16466);
	}

	public static bool smethod_13(int value)
	{
		return smethod_14(value) >= smethod_14(16475);
	}

	public static int smethod_14(int value)
	{
		if (!smethod_2(value))
		{
			return 0;
		}
		return value & 0xF8;
	}

	public static bool smethod_15(string value)
	{
		value = value.ToLower().Trim(char_0);
		int num = 0;
		while (true)
		{
			if (num < string_0.Length)
			{
				if (string_0[num].ToLower() == value)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	public static string ToString(int value)
	{
		int num = 0;
		while (true)
		{
			if (num < int_43.Length)
			{
				if (int_43[num] == value)
				{
					break;
				}
				num++;
				continue;
			}
			throw new InvalidOperationException("Invalid value for RunType.");
		}
		return string_0[num];
	}

	public static int smethod_16(string value)
	{
		value = value.ToLower().Trim(char_0);
		int num = 0;
		while (true)
		{
			if (num < string_0.Length)
			{
				if (string_0[num].ToLower() == value)
				{
					break;
				}
				num++;
				continue;
			}
			throw new ArgumentException("Value " + value + " cannot be converted to RunType.");
		}
		return int_43[num];
	}
}
