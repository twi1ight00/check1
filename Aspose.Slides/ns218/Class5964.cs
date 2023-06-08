using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using ns221;
using ns234;

namespace ns218;

internal class Class5964
{
	private const long long_0 = 504911232000000000L;

	private static readonly char[] char_0 = new char[1] { ';' };

	private static readonly char[] char_1 = new char[1] { ',' };

	private static readonly char[] char_2 = new char[16]
	{
		'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
		'A', 'B', 'C', 'D', 'E', 'F'
	};

	public static readonly byte[] byte_0 = new byte[0];

	private Class5964()
	{
	}

	public static string[] smethod_0(string value, params char[] delimiters)
	{
		if (!smethod_20(value))
		{
			return new string[0];
		}
		List<string> list = new List<string>();
		int num = 0;
		while (num < value.Length)
		{
			int num2 = value.IndexOfAny(delimiters, num);
			if (num2 == num)
			{
				if (value.Substring(num, 1).Trim().Length > 0)
				{
					list.Add(value.Substring(num, 1));
				}
				num++;
				continue;
			}
			if (0 <= num2)
			{
				if (value.Substring(num, num2 - num).Trim().Length > 0)
				{
					list.Add(value.Substring(num, num2 - num));
				}
				if (value.Substring(num2, 1).Trim().Length > 0)
				{
					list.Add(value.Substring(num2, 1));
				}
				num = num2 + 1;
				continue;
			}
			if (value.Substring(num).Trim().Length > 0)
			{
				list.Add(value.Substring(num));
			}
			break;
		}
		return list.ToArray();
	}

	public static void smethod_1(int value, byte[] bytes, int offset)
	{
		for (int i = 0; i < 4; i++)
		{
			bytes[offset + i] = (byte)value;
			value >>= 8;
		}
	}

	public static void smethod_2(uint value, Stream stream)
	{
		for (int i = 0; i < 4; i++)
		{
			stream.WriteByte((byte)value);
			value >>= 8;
		}
	}

	public static void smethod_3(string value, Stream stream)
	{
		for (int i = 0; i < value.Length; i++)
		{
			stream.WriteByte((byte)value[i]);
		}
	}

	public static bool smethod_4(long value)
	{
		return (value & 1L) != 0L;
	}

	public static int smethod_5(long value, int divider)
	{
		long num = value / divider;
		if (value % divider != 0L)
		{
			num++;
		}
		return (int)num;
	}

	public static int smethod_6(long value, int divider)
	{
		return smethod_5(value, divider) * divider;
	}

	public static void smethod_7(Stream stream, int pageSize)
	{
		int num = smethod_6(stream.Position, pageSize);
		if (stream.Length < num)
		{
			stream.SetLength(num);
		}
		stream.Position = num;
	}

	public static byte[] smethod_8(Stream stream, int length)
	{
		long position = stream.Position;
		byte[] array = new byte[length];
		stream.Read(array, 0, array.Length);
		stream.Position = position;
		return array;
	}

	public static void smethod_9(Stream srcStream, Stream dstStream)
	{
		if (srcStream == null)
		{
			throw new ArgumentNullException("srcStream");
		}
		if (dstStream == null)
		{
			throw new ArgumentNullException("dstStream");
		}
		byte[] array = new byte[4096];
		while (true)
		{
			int num = srcStream.Read(array, 0, array.Length);
			if (num > 0)
			{
				dstStream.Write(array, 0, num);
				continue;
			}
			break;
		}
	}

	public static MemoryStream smethod_10(Stream srcStream)
	{
		if (srcStream is MemoryStream result)
		{
			return result;
		}
		MemoryStream memoryStream = new MemoryStream((int)srcStream.Length);
		smethod_9(srcStream, memoryStream);
		return memoryStream;
	}

	public static byte[] smethod_11(Stream srcStream)
	{
		if (srcStream == null)
		{
			throw new ArgumentNullException("srcStream");
		}
		byte[] array = new byte[(int)srcStream.Length];
		using MemoryStream dstStream = new MemoryStream(array);
		srcStream.Position = 0L;
		smethod_9(srcStream, dstStream);
		return array;
	}

	public static void smethod_12(string fileName, Stream dstStream)
	{
		using Stream srcStream = File.OpenRead(fileName);
		smethod_9(srcStream, dstStream);
	}

	public static byte[] smethod_13(string fileName)
	{
		using Stream srcStream = File.OpenRead(fileName);
		return smethod_11(srcStream);
	}

	[Attribute7(true)]
	public static Stream smethod_14()
	{
		return Class6166.smethod_0("Aspose.Resources.NoImage.png");
	}

	[Attribute7(true)]
	public static byte[] smethod_15()
	{
		using Stream srcStream = smethod_14();
		return smethod_11(srcStream);
	}

	public static DateTime smethod_16(int year, int month, int day, int hour, int min, int sec, int msec)
	{
		try
		{
			return new DateTime(year, month, day, hour, min, sec, msec);
		}
		catch (Exception)
		{
			return DateTime.MinValue;
		}
	}

	public static DateTime smethod_17(long fileTime, string paramName)
	{
		if (fileTime < 0L)
		{
			throw new ArgumentOutOfRangeException(paramName);
		}
		long ticks = fileTime + 504911232000000000L;
		return new DateTime(ticks);
	}

	public static long smethod_18(DateTime value, string paramName)
	{
		long num = value.Ticks - 504911232000000000L;
		if (num < 0L)
		{
			throw new ArgumentOutOfRangeException(paramName);
		}
		return num;
	}

	[Attribute2("Don't need this logging method in Java.")]
	public static string smethod_19(object obj, string name)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("{0} Start\n", name);
		Type type = obj.GetType();
		FieldInfo[] fields = type.GetFields();
		FieldInfo[] array = fields;
		foreach (FieldInfo fieldInfo in array)
		{
			stringBuilder.AppendFormat("{0}:{1}, 0x{2:X}\n", fieldInfo.Name, fieldInfo.GetValue(obj), fieldInfo.GetValue(obj));
		}
		stringBuilder.AppendFormat("{0} End", name);
		return stringBuilder.ToString();
	}

	public static bool smethod_20(string value)
	{
		if (value != null)
		{
			return value.Length > 0;
		}
		return false;
	}

	public static bool smethod_21(string text)
	{
		int num = 0;
		while (true)
		{
			if (num < text.Length)
			{
				if (text[num] > '\u007f')
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	public static string smethod_22(string s, int length)
	{
		if (s != null && s.Length > 3)
		{
			return $"{s.Substring(0, length - 3)}...";
		}
		return s;
	}

	public static string smethod_23(string value)
	{
		if (value == null)
		{
			return string.Empty;
		}
		return value;
	}

	public static void smethod_24(string value, string paramName)
	{
		if (!smethod_20(value))
		{
			throw new ArgumentException("The argument cannot be null or empty string.", paramName);
		}
	}

	public static void smethod_25(object value, string paramName)
	{
		if (value == null)
		{
			throw new ArgumentNullException(paramName);
		}
	}

	public static void smethod_26(int value, int min, int max, string paramName)
	{
		if (value < min || value > max)
		{
			throw new ArgumentOutOfRangeException(paramName, $"Expected a value between {min} and {max}.");
		}
	}

	public static void smethod_27(int value, string paramName)
	{
		if (value <= 0)
		{
			throw new ArgumentOutOfRangeException(paramName, "Expected a positive value.");
		}
	}

	public static double smethod_28(double value, double minMargin, double minSaturation, double maxMargin, double maxSaturation, bool isThrow, string paramName)
	{
		if (value < minMargin)
		{
			if (isThrow)
			{
				throw new ArgumentOutOfRangeException(paramName);
			}
			return minSaturation;
		}
		if (value > maxMargin)
		{
			if (isThrow)
			{
				throw new ArgumentOutOfRangeException(paramName);
			}
			return maxSaturation;
		}
		return value;
	}

	public static int smethod_29(double value)
	{
		return (int)Math.Round(value);
	}

	public static int smethod_30(double value)
	{
		long num = (long)value;
		return (int)num;
	}

	public static bool smethod_31(string text)
	{
		int num = 0;
		while (true)
		{
			if (num < text.Length)
			{
				if (text[num] > '\u007f')
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	public static bool Contains(string text, string searchStr, bool ignoreCase)
	{
		if (ignoreCase)
		{
			text = text.ToUpper();
			searchStr = searchStr.ToUpper();
		}
		return text.IndexOf(searchStr) >= 0;
	}

	public static bool smethod_32(string text)
	{
		int length = text.Length;
		int num = 0;
		while (true)
		{
			if (num < length)
			{
				if (text[num] != ' ')
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	public static char[] CopyTo(StringBuilder builder)
	{
		int length = builder.Length;
		char[] array = new char[length];
		builder.CopyTo(0, array, 0, builder.Length);
		return array;
	}

	public static bool smethod_33(string text)
	{
		int num = 0;
		while (true)
		{
			if (num < text.Length)
			{
				if (!char.IsWhiteSpace(text[num]))
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	public static bool smethod_34(string text)
	{
		int num = 0;
		while (true)
		{
			if (num < text.Length)
			{
				if (char.IsWhiteSpace(text[num]))
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

	public static int smethod_35(char digit)
	{
		if (digit > '9')
		{
			return ((digit <= 'F') ? (digit - 65) : (digit - 97)) + 10;
		}
		return digit - 48;
	}

	public static bool smethod_36(char ch)
	{
		if ((ch >= '0' && ch <= '9') || (ch >= 'A' && ch <= 'F'))
		{
			return true;
		}
		if (ch >= 'a')
		{
			return ch <= 'f';
		}
		return false;
	}

	public static bool smethod_37(string value)
	{
		int num = 0;
		while (true)
		{
			if (num < value.Length)
			{
				char ch = value[num];
				if (!smethod_48(ch))
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	public static bool smethod_38(string value)
	{
		int num = 0;
		while (true)
		{
			if (num < value.Length)
			{
				char ch = value[num];
				if (!smethod_36(ch))
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	public static string smethod_39(byte[] bytes, int startIndex, int length, bool reversed)
	{
		StringBuilder stringBuilder = new StringBuilder(length * 2);
		int num = ((!reversed) ? 1 : (-1));
		if (reversed)
		{
			startIndex += length - 1;
		}
		for (int i = 0; i < length; i++)
		{
			stringBuilder.Append(smethod_40(bytes[startIndex]));
			startIndex += num;
		}
		return stringBuilder.ToString();
	}

	public static char[] smethod_40(byte b)
	{
		return new char[2]
		{
			char_2[(b >> 4) & 0xF],
			char_2[b & 0xF]
		};
	}

	public static string smethod_41(byte[] bytes)
	{
		return smethod_39(bytes, 0, bytes.Length, reversed: false);
	}

	public static bool smethod_42(string a, string b)
	{
		return Class6165.smethod_0(a, b);
	}

	public static bool smethod_43(SizeF size1, SizeF size2, double tolerance)
	{
		if ((double)Math.Abs(size1.Width - size2.Width) <= tolerance && (double)Math.Abs(size1.Height - size2.Height) <= tolerance)
		{
			return true;
		}
		if ((double)Math.Abs(size1.Width - size2.Height) <= tolerance && (double)Math.Abs(size1.Height - size2.Width) <= tolerance)
		{
			return true;
		}
		return false;
	}

	public static bool[] smethod_44(byte input)
	{
		bool[] array = new bool[8];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (input & (1 << i)) != 0;
		}
		return array;
	}

	public static byte[] smethod_45(Guid guid)
	{
		byte[] array = guid.ToByteArray();
		Array.Reverse(array, 0, 4);
		Array.Reverse(array, 4, 2);
		Array.Reverse(array, 6, 2);
		return array;
	}

	public static char[] smethod_46()
	{
		return Class6159.smethod_50() switch
		{
			',' => char_0, 
			_ => char_1, 
		};
	}

	public static bool smethod_47(BinaryReader reader, int bytesCount)
	{
		return bytesCount <= reader.BaseStream.Length - reader.BaseStream.Position;
	}

	private static bool smethod_48(char ch)
	{
		if (ch >= '0')
		{
			return ch <= '9';
		}
		return false;
	}

	public static PointF[] smethod_49(RectangleF rect)
	{
		return new PointF[4]
		{
			new PointF(rect.Left, rect.Top),
			new PointF(rect.Right, rect.Top),
			new PointF(rect.Right, rect.Bottom),
			new PointF(rect.Left, rect.Bottom)
		};
	}
}
