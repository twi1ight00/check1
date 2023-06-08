using System;
using System.IO;

namespace ns57;

internal class Class1321
{
	private static readonly char[] char_0 = new char[16]
	{
		'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
		'A', 'B', 'C', 'D', 'E', 'F'
	};

	private Class1321()
	{
	}

	public static int smethod_0(long long_0, int int_0)
	{
		long num = long_0 / int_0;
		if (long_0 % int_0 != 0)
		{
			num++;
		}
		return (int)num;
	}

	public static int smethod_1(long long_0, int int_0)
	{
		return smethod_0(long_0, int_0) * int_0;
	}

	public static void smethod_2(Stream stream_0, int int_0)
	{
		int num = smethod_1(stream_0.Position, int_0);
		if (stream_0.Length < num)
		{
			stream_0.SetLength(num);
		}
		stream_0.Position = num;
	}

	public static void smethod_3(Stream stream_0, Stream stream_1)
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
			if (num > 0)
			{
				stream_1.Write(array, 0, num);
				continue;
			}
			break;
		}
	}

	public static DateTime smethod_4(long long_0, string string_0)
	{
		if (long_0 < 0)
		{
			throw new ArgumentOutOfRangeException(string_0);
		}
		long ticks = long_0 + 504911232000000000L;
		return new DateTime(ticks);
	}

	public static long smethod_5(DateTime dateTime_0, string string_0)
	{
		long num = dateTime_0.Ticks - 504911232000000000L;
		if (num < 0)
		{
			throw new ArgumentOutOfRangeException(string_0);
		}
		return num;
	}

	public static bool smethod_6(string string_0)
	{
		if (string_0 != null)
		{
			return string_0.Length > 0;
		}
		return false;
	}

	public static void smethod_7(string string_0, string string_1)
	{
		if (!smethod_6(string_0))
		{
			throw new ArgumentException("The argument cannot be null or empty string.", string_1);
		}
	}
}
