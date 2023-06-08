using System;
using System.Drawing;
using System.IO;

namespace ns18;

internal class Class1015
{
	private Class1015()
	{
	}

	public static int smethod_0(int int_0)
	{
		return (int)smethod_1((uint)int_0);
	}

	public static uint smethod_1(uint uint_0)
	{
		return ((uint_0 & 0xFF) << 24) | ((uint_0 & 0xFF00) << 8) | ((uint_0 & 0xFF0000) >> 8) | ((uint_0 & 0xFF000000u) >> 24);
	}

	public static short smethod_2(short short_0)
	{
		return (short)smethod_3((ushort)short_0);
	}

	public static ushort smethod_3(ushort ushort_0)
	{
		return (ushort)(((ushort_0 & 0xFF) << 8) | ((ushort_0 & 0xFF00) >> 8));
	}

	public static void smethod_4(int int_0, byte[] byte_0, int int_1)
	{
		for (int i = 0; i < 4; i++)
		{
			byte_0[int_1 + i] = (byte)int_0;
			int_0 >>= 8;
		}
	}

	public static bool smethod_5(long long_0)
	{
		return (long_0 & 1) != 0;
	}

	public static int smethod_6(long long_0, int int_0)
	{
		long num = long_0 / int_0;
		if (long_0 % int_0 != 0)
		{
			num++;
		}
		return (int)num;
	}

	public static int smethod_7(long long_0, int int_0)
	{
		return smethod_6(long_0, int_0) * int_0;
	}

	public static void smethod_8(Stream stream_0, int int_0)
	{
		int num = smethod_7(stream_0.Position, int_0);
		if (stream_0.Length < num)
		{
			stream_0.SetLength(num);
		}
		stream_0.Position = num;
	}

	public static void smethod_9(Stream stream_0, Stream stream_1)
	{
		if (stream_0 == null)
		{
			throw new ArgumentNullException("srcStream");
		}
		if (stream_1 == null)
		{
			throw new ArgumentNullException("dstStream");
		}
		byte[] array = new byte[4096];
		while (true)
		{
			int num = stream_0.Read(array, 0, array.Length);
			if (num != 0)
			{
				stream_1.Write(array, 0, num);
				continue;
			}
			break;
		}
	}

	public static void smethod_10(string string_0, Stream stream_0)
	{
		using Stream stream_ = File.OpenRead(string_0);
		smethod_9(stream_, stream_0);
	}

	public static bool smethod_11(string string_0)
	{
		if (string_0 != null)
		{
			return string_0 != "";
		}
		return false;
	}

	public static void smethod_12(string string_0, string string_1)
	{
		if (!smethod_11(string_0))
		{
			throw new ArgumentException("The argument cannot be null or empty string.", string_1);
		}
	}

	public static int smethod_13(double double_0)
	{
		return (int)Math.Round(double_0);
	}

	public static int smethod_14(char char_0)
	{
		if (char_0 > '9')
		{
			return ((char_0 <= 'F') ? (char_0 - 65) : (char_0 - 97)) + 10;
		}
		return char_0 - 48;
	}

	public static bool smethod_15(char char_0)
	{
		if ((char_0 >= '0' && char_0 <= '9') || (char_0 >= 'A' && char_0 <= 'F'))
		{
			return true;
		}
		if (char_0 >= 'a')
		{
			return char_0 <= 'f';
		}
		return false;
	}

	public static bool smethod_16(string string_0, string string_1)
	{
		return string.Compare(string_0, string_1, ignoreCase: true) == 0;
	}

	public static bool smethod_17(SizeF sizeF_0, SizeF sizeF_1, double double_0)
	{
		if ((double)Math.Abs(sizeF_0.Width - sizeF_1.Width) <= double_0 && (double)Math.Abs(sizeF_0.Height - sizeF_1.Height) <= double_0)
		{
			return true;
		}
		if ((double)Math.Abs(sizeF_0.Width - sizeF_1.Height) <= double_0 && (double)Math.Abs(sizeF_0.Height - sizeF_1.Width) <= double_0)
		{
			return true;
		}
		return false;
	}
}
