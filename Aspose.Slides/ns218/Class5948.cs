using System;
using System.Collections;
using System.Diagnostics;
using System.Text;

namespace ns218;

[DebuggerStepThrough]
internal static class Class5948
{
	public static readonly byte[] byte_0 = new byte[0];

	public static bool smethod_0(char[] array1, char[] array2)
	{
		if (array1.Length != array2.Length)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < array1.Length)
			{
				if (array1[num] != array2[num])
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

	public static bool smethod_1(byte[] array1, byte[] array2)
	{
		if (array1.Length != array2.Length)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < array1.Length)
			{
				if (array1[num] != array2[num])
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

	public static bool smethod_2(int[] array1, int[] array2)
	{
		if (array1.Length != array2.Length)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < array1.Length)
			{
				if (array1[num] != array2[num])
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

	public static bool smethod_3(float[] array1, float[] array2)
	{
		if (array1.Length != array2.Length)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < array1.Length)
			{
				if (array1[num] != array2[num])
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

	public static string smethod_4(byte[] data)
	{
		if (data != null)
		{
			return smethod_5(data, 0, data.Length);
		}
		return "Null";
	}

	public static string smethod_5(byte[] data, int start, int count)
	{
		if (data == null)
		{
			return "Null";
		}
		StringBuilder stringBuilder = new StringBuilder();
		while (count > 0)
		{
			stringBuilder.AppendFormat("{0:X2} ", data[start]);
			start++;
			count--;
		}
		return stringBuilder.ToString();
	}

	public static string smethod_6(float[] data)
	{
		StringBuilder stringBuilder = new StringBuilder(data.Length * 10);
		stringBuilder.Append("[");
		bool flag = true;
		foreach (float value in data)
		{
			if (!flag)
			{
				stringBuilder.Append(", ");
			}
			else
			{
				flag = false;
			}
			stringBuilder.Append(value);
		}
		stringBuilder.Append("]");
		return stringBuilder.ToString();
	}

	public static int smethod_7(int[] array, int index, int length, int value)
	{
		int num = index;
		int num2 = index + length - 1;
		int num3;
		while (true)
		{
			if (num <= num2)
			{
				num3 = num + num2 >> 1;
				int num4 = array[num3];
				if (num4 == value)
				{
					break;
				}
				if (num4 < value)
				{
					num = num3 + 1;
				}
				else
				{
					num2 = num3 - 1;
				}
				continue;
			}
			return ~num;
		}
		return num3;
	}

	public static void smethod_8(byte[] array, byte value, int offset, int length)
	{
		for (int i = 0; i < length; i++)
		{
			array[i + offset] = value;
		}
	}

	public static bool smethod_9(byte[] array1, byte[] array2, int length)
	{
		int num = 0;
		while (true)
		{
			if (num < length)
			{
				if (array1[num] != array2[num])
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

	public static void smethod_10(char[] array1, char[] array2)
	{
		int num = Math.Min(array1.Length, array2.Length);
		int num2 = 0;
		while (true)
		{
			if (num2 < num)
			{
				if (array1[num2] == array2[num2])
				{
					num2++;
					continue;
				}
				throw new InvalidOperationException($"Array values are different at position 0x{num2:X2}, 0x{array1[num2]:X2}, 0x{array2[num2]:X2}.");
			}
			if (array1.Length != array2.Length)
			{
				throw new InvalidOperationException($"Array lengths are different: {array1.Length} and {array2.Length}.");
			}
			break;
		}
	}

	public static void smethod_11(byte[] array1, byte[] array2)
	{
		int num = Math.Min(array1.Length, array2.Length);
		int num2 = 0;
		while (true)
		{
			if (num2 < num)
			{
				if (array1[num2] == array2[num2])
				{
					num2++;
					continue;
				}
				throw new InvalidOperationException($"Array values are different at position 0x{num2:X2}, 0x{array1[num2]:X2}, 0x{array2[num2]:X2}.");
			}
			if (array1.Length != array2.Length)
			{
				throw new InvalidOperationException($"Array lengths are different: {array1.Length} and {array2.Length}.");
			}
			break;
		}
	}

	public static void smethod_12(short[] array1, short[] array2)
	{
		int num = Math.Min(array1.Length, array2.Length);
		int num2 = 0;
		while (true)
		{
			if (num2 < num)
			{
				if (array1[num2] == array2[num2])
				{
					num2++;
					continue;
				}
				throw new InvalidOperationException($"Array values are different at position 0x{num2:X2}, 0x{array1[num2]:X2}, 0x{array2[num2]:X2}.");
			}
			if (array1.Length != array2.Length)
			{
				throw new InvalidOperationException($"Array lengths are different: {array1.Length} and {array2.Length}.");
			}
			break;
		}
	}

	public static void smethod_13(float[] array1, float[] array2, float delta)
	{
		int num = Math.Min(array1.Length, array2.Length);
		int num2 = 0;
		while (true)
		{
			if (num2 < num)
			{
				if (array1[num2] - array2[num2] <= delta)
				{
					num2++;
					continue;
				}
				throw new InvalidOperationException($"Array values are different at position {num2}: {array1[num2]} vs. {array2[num2]} with delta {delta}.");
			}
			if (array1.Length != array2.Length)
			{
				throw new InvalidOperationException($"Array lengths are different: {array1.Length} and {array2.Length}.");
			}
			break;
		}
	}

	public static void smethod_14(byte[] array1, byte[] array2)
	{
		if (array1.Length != array2.Length)
		{
			throw new InvalidOperationException($"Array lengths are different: {array1.Length} and {array2.Length}.");
		}
		for (int i = 0; i < array1.Length; i++)
		{
		}
	}

	public static byte[] smethod_15(byte[] srcArray, int length)
	{
		byte[] array = new byte[length];
		if (length > srcArray.Length)
		{
			length = srcArray.Length;
		}
		Array.Copy(srcArray, array, length);
		return array;
	}

	public static int[] smethod_16(ArrayList src)
	{
		int[] array = new int[src.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (int)src[i];
		}
		return array;
	}
}
