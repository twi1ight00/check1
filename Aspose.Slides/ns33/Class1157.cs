using System;
using System.IO;
using System.Text;

namespace ns33;

internal class Class1157
{
	public const string string_0 = "\r\n";

	private static readonly StringBuilder stringBuilder_0 = new StringBuilder(8);

	private static readonly StringBuilder stringBuilder_1 = new StringBuilder(2);

	private static readonly char[] char_0 = new char[16]
	{
		'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
		'A', 'B', 'C', 'D', 'E', 'F'
	};

	private static readonly int[] int_0 = new int[8] { 28, 24, 20, 16, 12, 8, 4, 0 };

	private Class1157()
	{
	}

	public static void smethod_0(byte[] data, long offset, Stream stream, int index, int length)
	{
		if (index >= 0 && index < data.Length)
		{
			if (stream == null)
			{
				throw new ArgumentException("cannot write to nullstream");
			}
			long num = offset + index;
			StringBuilder stringBuilder = new StringBuilder(74);
			int num2 = Math.Min(data.Length, index + length);
			for (int i = index; i < num2; i += 16)
			{
				int num3 = num2 - i;
				if (num3 > 16)
				{
					num3 = 16;
				}
				stringBuilder.Append(smethod_2(num)).Append(' ');
				for (int j = 0; j < 16; j++)
				{
					if (j < num3)
					{
						stringBuilder.Append(smethod_3(data[j + i]));
					}
					else
					{
						stringBuilder.Append("  ");
					}
					stringBuilder.Append(' ');
				}
				for (int k = 0; k < num3; k++)
				{
					if (data[k + i] >= 32 && data[k + i] < 127)
					{
						stringBuilder.Append((char)data[k + i]);
					}
					else
					{
						stringBuilder.Append('.');
					}
				}
				stringBuilder.Append("\r\n");
				UTF8Encoding uTF8Encoding = new UTF8Encoding();
				byte[] bytes = uTF8Encoding.GetBytes(stringBuilder.ToString());
				stream.Write(bytes, 0, bytes.Length);
				stream.Flush();
				stringBuilder.Length = 0;
				num += num3;
			}
			return;
		}
		throw new IndexOutOfRangeException("illegal index: " + index + " into array of length " + data.Length);
	}

	public static void smethod_1(byte[] data, long offset, Stream stream, int index)
	{
		smethod_0(data, offset, stream, index, data.Length - index);
	}

	private static StringBuilder smethod_2(long value)
	{
		stringBuilder_0.Length = 0;
		for (int i = 0; i < 8; i++)
		{
			stringBuilder_0.Append(char_0[(int)(value >> int_0[i]) & 0xF]);
		}
		return stringBuilder_0;
	}

	private static StringBuilder smethod_3(byte value)
	{
		stringBuilder_1.Length = 0;
		for (int i = 0; i < 2; i++)
		{
			stringBuilder_1.Append(char_0[(value >> int_0[i + 6]) & 0xF]);
		}
		return stringBuilder_1;
	}

	public static string smethod_4(byte[] value)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('[');
		for (int i = 0; i < value.Length; i++)
		{
			stringBuilder.Append(smethod_6(value[i]));
			stringBuilder.Append(", ");
		}
		stringBuilder.Append(']');
		return stringBuilder.ToString();
	}

	public static string smethod_5(short value)
	{
		return smethod_8(value, 4);
	}

	public static string smethod_6(byte value)
	{
		return smethod_8(value, 2);
	}

	public static string smethod_7(int value)
	{
		return smethod_8(value, 8);
	}

	private static string smethod_8(long value, int digits)
	{
		StringBuilder stringBuilder = new StringBuilder(digits);
		for (int i = 0; i < digits; i++)
		{
			stringBuilder.Append(char_0[(int)((value >> int_0[i + (8 - digits)]) & 0xFL)]);
		}
		return stringBuilder.ToString();
	}
}
