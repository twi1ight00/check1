using System;
using System.Text;

namespace ns2;

internal class Class937
{
	internal static string smethod_0(byte[] byte_0, int int_0, bool bool_0, int int_1)
	{
		string text = null;
		if (!bool_0)
		{
			return Encoding.Unicode.GetString(byte_0, int_0, int_1 * 2);
		}
		byte[] array = new byte[2 * int_1];
		for (int i = 0; i < int_1; i++)
		{
			array[2 * i] = byte_0[int_0 + i];
		}
		return Encoding.Unicode.GetString(array, 0, array.Length);
	}

	internal static string smethod_1(byte[] byte_0, int int_0)
	{
		int num = BitConverter.ToUInt16(byte_0, int_0);
		string text = null;
		if (byte_0[int_0 + 2] == 1)
		{
			text = Encoding.Unicode.GetString(byte_0, int_0 + 3, num * 2);
			int_0 += 3 + num * 2;
		}
		else
		{
			byte[] array = new byte[2 * num];
			for (int i = 0; i < num; i++)
			{
				array[2 * i] = byte_0[int_0 + 3 + i];
			}
			text = Encoding.Unicode.GetString(array, 0, array.Length);
			int_0 += 3 + num;
		}
		return text;
	}

	internal static byte[] smethod_2(string string_0)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(string_0);
		int num = bytes.Length / 2;
		int num2 = 0;
		while (true)
		{
			if (num2 < num)
			{
				if (bytes[2 * num2 + 1] != 0)
				{
					break;
				}
				num2++;
				continue;
			}
			byte[] array = new byte[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = bytes[2 * i];
			}
			return array;
		}
		return bytes;
	}

	internal static string smethod_3(byte[] byte_0, int int_0, int int_1)
	{
		byte[] array = new byte[2 * int_1];
		for (int i = 0; i < int_1; i++)
		{
			array[2 * i] = byte_0[int_0 + i];
		}
		return Encoding.Unicode.GetString(array);
	}

	internal static int smethod_4(byte[] byte_0, int int_0, string string_0)
	{
		byte[] array = Class1677.smethod_15(string_0);
		bool flag = array.Length == string_0.Length;
		byte_0[int_0++] = (byte)((!flag) ? 1 : 0);
		Array.Copy(array, 0, byte_0, int_0, array.Length);
		return 1 + array.Length;
	}

	internal static int smethod_5(byte[] byte_0, ref int int_0, string string_0)
	{
		int num = 0;
		if (string_0 == null)
		{
			byte_0[int_0++] = byte.MaxValue;
			byte_0[int_0++] = byte.MaxValue;
			return 2;
		}
		Array.Copy(BitConverter.GetBytes((short)string_0.Length), 0, byte_0, int_0, 2);
		int_0 += 2;
		int num2 = smethod_4(byte_0, int_0, string_0);
		int_0 += num2;
		return 2 + num2;
	}

	internal static int smethod_6(byte[] byte_0, int int_0, string string_0, int int_1, byte byte_1)
	{
		int num = int_0;
		int num2 = string_0.Length + 1;
		if (int_1 == 1)
		{
			byte_0[num] = (byte)num2;
		}
		else
		{
			if (int_1 != 2)
			{
				throw new ArgumentException();
			}
			Array.Copy(BitConverter.GetBytes((short)num2), 0, byte_0, num, 2);
		}
		num += int_1;
		byte[] array = Class1677.smethod_15(string_0);
		bool flag = array.Length == string_0.Length;
		byte_0[num++] = (byte)((!flag) ? 1 : 0);
		byte_0[num++] = byte_1;
		Array.Copy(array, 0, byte_0, num, array.Length);
		num += array.Length;
		if (flag)
		{
			byte_0[num++] = 0;
		}
		else if (int_1 == 2)
		{
			Array.Copy(BitConverter.GetBytes((short)0), 0, byte_0, num, 2);
			num += 2;
		}
		return num - int_0;
	}
}
