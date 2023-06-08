using System;
using System.Text;

namespace ns227;

internal class Class6116
{
	public static int int_0 = smethod_0(new char[4] { 't', 't', 'c', 'f' });

	public static int int_1 = smethod_0(new char[4] { 'c', 'm', 'a', 'p' });

	public static int int_2 = smethod_0(new char[4] { 'h', 'e', 'a', 'd' });

	public static int int_3 = smethod_0(new char[4] { 'h', 'h', 'e', 'a' });

	public static int int_4 = smethod_0(new char[4] { 'h', 'm', 't', 'x' });

	public static int int_5 = smethod_0(new char[4] { 'm', 'a', 'x', 'p' });

	public static int int_6 = smethod_0(new char[4] { 'n', 'a', 'm', 'e' });

	public static int int_7 = smethod_0(new char[4] { 'O', 'S', '/', '2' });

	public static int int_8 = smethod_0(new char[4] { 'p', 'o', 's', 't' });

	public static int int_9 = smethod_0(new char[4] { 'c', 'v', 't', ' ' });

	public static int int_10 = smethod_0(new char[4] { 'f', 'p', 'g', 'm' });

	public static int int_11 = smethod_0(new char[4] { 'g', 'l', 'y', 'f' });

	public static int int_12 = smethod_0(new char[4] { 'l', 'o', 'c', 'a' });

	public static int int_13 = smethod_0(new char[4] { 'p', 'r', 'e', 'p' });

	public static int int_14 = smethod_0(new char[4] { 'C', 'F', 'F', ' ' });

	public static int int_15 = smethod_0(new char[4] { 'V', 'O', 'R', 'G' });

	public static int int_16 = smethod_0(new char[4] { 'E', 'B', 'D', 'T' });

	public static int int_17 = smethod_0(new char[4] { 'E', 'B', 'L', 'C' });

	public static int int_18 = smethod_0(new char[4] { 'E', 'B', 'S', 'C' });

	public static int int_19 = smethod_0(new char[4] { 'B', 'A', 'S', 'E' });

	public static int int_20 = smethod_0(new char[4] { 'G', 'D', 'E', 'F' });

	public static int int_21 = smethod_0(new char[4] { 'G', 'P', 'O', 'S' });

	public static int int_22 = smethod_0(new char[4] { 'G', 'S', 'U', 'B' });

	public static int int_23 = smethod_0(new char[4] { 'J', 'S', 'T', 'F' });

	public static int int_24 = smethod_0(new char[4] { 'D', 'S', 'I', 'G' });

	public static int int_25 = smethod_0(new char[4] { 'g', 'a', 's', 'p' });

	public static int int_26 = smethod_0(new char[4] { 'h', 'd', 'm', 'x' });

	public static int int_27 = smethod_0(new char[4] { 'k', 'e', 'r', 'n' });

	public static int int_28 = smethod_0(new char[4] { 'L', 'T', 'S', 'H' });

	public static int int_29 = smethod_0(new char[4] { 'P', 'C', 'L', 'T' });

	public static int int_30 = smethod_0(new char[4] { 'V', 'D', 'M', 'X' });

	public static int int_31 = smethod_0(new char[4] { 'v', 'h', 'e', 'a' });

	public static int int_32 = smethod_0(new char[4] { 'v', 'm', 't', 'x' });

	public static int int_33 = smethod_0(new char[4] { 'F', 'F', 'T', 'M' });

	public static int int_34 = smethod_0(new char[4] { 'b', 's', 'l', 'n' });

	public static int int_35 = smethod_0(new char[4] { 'f', 'e', 'a', 't' });

	public static int int_36 = smethod_0(new char[4] { 'l', 'c', 'a', 'r' });

	public static int int_37 = smethod_0(new char[4] { 'm', 'o', 'r', 'x' });

	public static int int_38 = smethod_0(new char[4] { 'o', 'p', 'b', 'd' });

	public static int int_39 = smethod_0(new char[4] { 'p', 'r', 'o', 'p' });

	public static int int_40 = smethod_0(new char[4] { 'F', 'e', 'a', 't' });

	public static int int_41 = smethod_0(new char[4] { 'G', 'l', 'a', 't' });

	public static int int_42 = smethod_0(new char[4] { 'G', 'l', 'o', 'c' });

	public static int int_43 = smethod_0(new char[4] { 'S', 'i', 'l', 'e' });

	public static int int_44 = smethod_0(new char[4] { 'S', 'i', 'l', 'f' });

	public static int int_45 = smethod_0(new char[4] { 'b', 'h', 'e', 'd' });

	public static int int_46 = smethod_0(new char[4] { 'b', 'd', 'a', 't' });

	public static int int_47 = smethod_0(new char[4] { 'b', 'l', 'o', 'c' });

	private Class6116()
	{
	}

	public static int smethod_0(char[] tag)
	{
		return ((byte)tag[0] << 24) | ((byte)tag[1] << 16) | ((byte)tag[2] << 8) | (byte)tag[3];
	}

	public static int smethod_1(byte[] tag)
	{
		return (tag[0] << 24) | (tag[1] << 16) | (tag[2] << 8) | tag[3];
	}

	public static byte[] smethod_2(int tag)
	{
		return new byte[4]
		{
			(byte)(0xFFu & (uint)(tag >> 24)),
			(byte)(0xFFu & (uint)(tag >> 16)),
			(byte)(0xFFu & (uint)(tag >> 8)),
			(byte)(0xFFu & (uint)tag)
		};
	}

	public static string smethod_3(int tag)
	{
		try
		{
			return Encoding.GetEncoding("us-ascii").GetString(smethod_2(tag));
		}
		catch (ArgumentException)
		{
			return string.Empty;
		}
	}

	public static int smethod_4(string s)
	{
		byte[] array = null;
		try
		{
			array = Encoding.GetEncoding("us-ascii").GetBytes(s.Substring(0, 4));
		}
		catch (ArgumentException)
		{
			return 0;
		}
		return smethod_1(array);
	}

	public static bool smethod_5(int tag)
	{
		if (tag != int_2 && tag != int_45)
		{
			return false;
		}
		return true;
	}
}
