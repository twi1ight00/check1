using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace ns33;

internal class Class1165
{
	private static readonly bool[] bool_0 = smethod_18(128, 32, 35, 37, 38, 91, 93, 94, 96, 123, 125, 127);

	public static bool smethod_0(float a, float b)
	{
		bool flag = float.IsNaN(a);
		bool flag2 = float.IsNaN(b);
		if (flag == flag2)
		{
			if (flag)
			{
				return true;
			}
			bool flag3;
			if ((flag3 = float.IsInfinity(a)) == float.IsInfinity(b))
			{
				if (flag3)
				{
					return a < 0f == b < 0f;
				}
				return a == b;
			}
			return false;
		}
		return false;
	}

	public static bool smethod_1(double a, double b)
	{
		bool flag = double.IsNaN(a);
		bool flag2 = double.IsNaN(b);
		if (flag == flag2)
		{
			if (flag)
			{
				return true;
			}
			bool flag3;
			if ((flag3 = double.IsInfinity(a)) == double.IsInfinity(b))
			{
				if (flag3)
				{
					return a < 0.0 == b < 0.0;
				}
				return a == b;
			}
			return false;
		}
		return false;
	}

	public static bool smethod_2(object obj1, object obj2)
	{
		if (obj1 == null && obj2 == null)
		{
			return true;
		}
		return obj1?.Equals(obj2) ?? false;
	}

	public static bool smethod_3(byte[] array1, byte[] array2)
	{
		if (array1 == null && array2 == null)
		{
			return true;
		}
		if (array1 != null && array2 != null)
		{
			if (array1.Length != array2.Length)
			{
				return false;
			}
			bool result = true;
			for (int i = 0; i < array1.Length; i++)
			{
				if (array1[i] != array2[i])
				{
					result = false;
					break;
				}
			}
			return result;
		}
		return false;
	}

	public static int smethod_4(int value, int minValue, int maxValue)
	{
		if (value < minValue)
		{
			value = minValue;
		}
		else if (value > maxValue)
		{
			value = maxValue;
		}
		return value;
	}

	public static float smethod_5(float value, float minValue, float maxValue)
	{
		if (value < minValue)
		{
			value = minValue;
		}
		else if (value > maxValue)
		{
			value = maxValue;
		}
		return value;
	}

	public static double smethod_6(double value, double minValue, double maxValue)
	{
		if (value < minValue)
		{
			value = minValue;
		}
		else if (value > maxValue)
		{
			value = maxValue;
		}
		return value;
	}

	public static Color smethod_7(uint clr)
	{
		return Color.FromArgb((int)(clr & 0xFF), (int)((clr >> 8) & 0xFF), (int)((clr >> 16) & 0xFF));
	}

	public static Color smethod_8(int alpha, uint clr)
	{
		return Color.FromArgb(alpha, (int)(clr & 0xFF), (int)((clr >> 8) & 0xFF), (int)((clr >> 16) & 0xFF));
	}

	public static uint smethod_9(Color color)
	{
		return (uint)((color.B << 16) | (color.G << 8) | color.R);
	}

	public static long smethod_10(DateTime datetime)
	{
		long num = datetime.ToFileTimeUtc();
		return ((num & 0xFFFFFFFFL) << 32) | ((num >> 32) & 0xFFFFFFFFL);
	}

	public static DateTime smethod_11(long value)
	{
		long fileTime = ((value & 0xFFFFFFFFL) << 32) | ((value >> 32) & 0xFFFFFFFFL);
		return DateTime.FromFileTimeUtc(fileTime);
	}

	public static uint smethod_12(Color color)
	{
		return (uint)((double)((float)(int)color.A * 65536f / 255f) + 0.5);
	}

	public static int smethod_13(long fpoint)
	{
		return (int)((double)((float)fpoint * 255f / 65536f) + 0.5);
	}

	internal static byte[] smethod_14(byte[] value)
	{
		byte[] array = new byte[value.Length];
		for (int i = 0; i < value.Length; i++)
		{
			array[i] = (byte)(value[i] ^ (i * i));
		}
		return array;
	}

	public static void smethod_15(byte[] array, byte value)
	{
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = value;
		}
	}

	public static void smethod_16(int[] array, int value)
	{
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = value;
		}
	}

	public static string smethod_17(string url)
	{
		try
		{
			Uri uri = new Uri(url);
			if (!uri.IsFile)
			{
				return uri.AbsoluteUri;
			}
			StringBuilder stringBuilder = new StringBuilder("file:///");
			string localPath = uri.LocalPath;
			foreach (char c in localPath)
			{
				if ((uint)c < 128u && bool_0[(uint)c])
				{
					stringBuilder.AppendFormat("%{0:x2}", (uint)c);
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}
		catch (Exception ex)
		{
			smethod_28(ex);
			return url;
		}
	}

	private static bool[] smethod_18(int length, params int[] indexToSet)
	{
		bool[] array = new bool[length];
		for (int i = 0; i < indexToSet.Length; i++)
		{
			array[indexToSet[i]] = true;
		}
		return array;
	}

	public static uint smethod_19(uint value)
	{
		uint num = value - ((value >> 1) & 0x55555555);
		num = (num & 0x33333333) + ((num >> 2) & 0x33333333);
		return ((num + (num >> 4)) & 0xF0F0F0F) * 16843009 >> 24;
	}

	public static IDictionary smethod_20(params object[] elements)
	{
		IDictionary dictionary = new Hashtable();
		for (int i = 0; i < elements.Length; i++)
		{
			dictionary.Add(elements[i], elements[i]);
		}
		return dictionary;
	}

	public static bool smethod_21(byte[] a, byte[] b)
	{
		if (a.Length != b.Length)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < a.Length)
			{
				if (a[num] != b[num])
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

	internal static int smethod_22(byte[] data, int start, int length, byte[] pattern)
	{
		int num = start + length;
		if (data.Length < num)
		{
			num = data.Length;
		}
		int num2 = num - pattern.Length;
		int num3 = start;
		while (true)
		{
			if (num3 <= num2)
			{
				int i;
				for (i = 0; i < pattern.Length && data[num3 + i] == pattern[i]; i++)
				{
				}
				if (i == pattern.Length)
				{
					break;
				}
				num3++;
				continue;
			}
			return -1;
		}
		return num3;
	}

	[Conditional("DEBUG")]
	public static void smethod_23(string message)
	{
		Console.WriteLine(". " + message);
	}

	[Conditional("DEBUG")]
	public static void smethod_24(string message, object arg0, object arg1)
	{
		Console.Error.WriteLine(". " + message, arg0, arg1);
	}

	[Conditional("DEBUG")]
	public static void smethod_25(Hashtable table)
	{
		Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.fffff") + ": > Show HashTable -------------------------------");
		Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.fffff") + ": > Records count: " + table.Count);
	}

	[Conditional("DEBUG")]
	public static void smethod_26(bool condition)
	{
		if (!condition)
		{
			throw new ApplicationException("Debug assertion failed.");
		}
	}

	public static void smethod_27(bool condition, string mess)
	{
		if (!condition)
		{
			throw new ApplicationException("Debug assertion failed.\n" + mess);
		}
	}

	public static void smethod_28(Exception ex)
	{
	}
}
