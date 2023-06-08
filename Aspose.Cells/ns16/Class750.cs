using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace ns16;

internal static class Class750
{
	public static bool smethod_0(Stream stream_0, ICollection<Class744> icollection_0, uint uint_0, Enum32 enum32_0, string string_0, Class751 class751_0)
	{
		Stream7 stream = stream_0 as Stream7;
		stream?.method_1(bool_2: true);
		long num = 0L;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			foreach (Class744 item in icollection_0)
			{
				if (item.method_26())
				{
					item.method_68(memoryStream);
				}
			}
			byte[] array = memoryStream.ToArray();
			stream_0.Write(array, 0, array.Length);
			num = array.Length;
		}
		long num2 = ((stream_0 is Stream3 stream2) ? stream2.method_4() : stream_0.Position);
		long num3 = num2 - num;
		uint num4 = stream?.method_2() ?? 0;
		long num5 = num2 - num3;
		int num6 = smethod_4(icollection_0);
		bool flag = enum32_0 == Enum32.const_3 || num6 >= 65535 || num5 > uint.MaxValue || num3 > uint.MaxValue;
		byte[] array2 = null;
		if (flag)
		{
			if (enum32_0 == Enum32.const_0)
			{
				StackFrame stackFrame = new StackFrame(1);
				if (stackFrame.GetMethod().DeclaringType == typeof(Class746))
				{
					throw new Exception1("The archive requires a ZIP64 Central Directory. Consider setting the ZipFile.UseZip64WhenSaving property.");
				}
				throw new Exception1("The archive requires a ZIP64 Central Directory. Consider setting the ZipOutputStream.EnableZip64 property.");
			}
			byte[] array3 = smethod_3(num3, num2, num6, uint_0);
			array2 = smethod_2(num3, num2, enum32_0, num6, string_0, class751_0);
			if (num4 != 0)
			{
				uint value = stream.method_7(array3.Length + array2.Length);
				Array.Copy(BitConverter.GetBytes(value), 0, array3, 16, 4);
				Array.Copy(BitConverter.GetBytes(value), 0, array3, 20, 4);
				Array.Copy(BitConverter.GetBytes(value), 0, array3, 60, 4);
				Array.Copy(BitConverter.GetBytes(value), 0, array3, 72, 4);
			}
			stream_0.Write(array3, 0, array3.Length);
		}
		else
		{
			array2 = smethod_2(num3, num2, enum32_0, num6, string_0, class751_0);
		}
		if (num4 != 0)
		{
			ushort value2 = (ushort)stream.method_7(array2.Length);
			Array.Copy(BitConverter.GetBytes(value2), 0, array2, 4, 2);
			Array.Copy(BitConverter.GetBytes(value2), 0, array2, 6, 2);
		}
		stream_0.Write(array2, 0, array2.Length);
		stream?.method_1(bool_2: false);
		return flag;
	}

	private static Encoding smethod_1(Class751 class751_0, string string_0)
	{
		switch (class751_0.method_13())
		{
		case Enum33.const_0:
			return class751_0.method_12();
		default:
		{
			Encoding encoding = class751_0.method_12();
			if (string_0 == null)
			{
				return encoding;
			}
			byte[] bytes = encoding.GetBytes(string_0);
			string @string = encoding.GetString(bytes, 0, bytes.Length);
			if (@string.Equals(string_0))
			{
				return encoding;
			}
			return class751_0.method_11();
		}
		case Enum33.const_3:
			return class751_0.method_11();
		}
	}

	private static byte[] smethod_2(long long_0, long long_1, Enum32 enum32_0, int int_0, string string_0, Class751 class751_0)
	{
		Encoding encoding = smethod_1(class751_0, string_0);
		int num = 0;
		int num2 = 22;
		byte[] array = null;
		short num3 = 0;
		if (string_0 != null && string_0.Length != 0)
		{
			array = encoding.GetBytes(string_0);
			num3 = (short)array.Length;
		}
		num2 += num3;
		byte[] array2 = new byte[num2];
		int num4 = 0;
		byte[] bytes = BitConverter.GetBytes(101010256u);
		Array.Copy(bytes, 0, array2, 0, 4);
		num4 = 0 + 4;
		num4 = 4 + 1;
		array2[4] = 0;
		num4 = 5 + 1;
		array2[5] = 0;
		num4 = 6 + 1;
		array2[6] = 0;
		num4 = 7 + 1;
		array2[7] = 0;
		if (int_0 < 65535 && enum32_0 != Enum32.const_3)
		{
			array2[num4++] = (byte)((uint)int_0 & 0xFFu);
			array2[num4++] = (byte)((int_0 & 0xFF00) >> 8);
			array2[num4++] = (byte)((uint)int_0 & 0xFFu);
			array2[num4++] = (byte)((int_0 & 0xFF00) >> 8);
		}
		else
		{
			for (num = 0; num < 4; num++)
			{
				array2[num4++] = byte.MaxValue;
			}
		}
		long num5 = long_1 - long_0;
		if (num5 < uint.MaxValue && long_0 < uint.MaxValue)
		{
			array2[num4++] = (byte)(num5 & 0xFF);
			array2[num4++] = (byte)((num5 & 0xFF00) >> 8);
			array2[num4++] = (byte)((num5 & 0xFF0000) >> 16);
			array2[num4++] = (byte)((num5 & 0xFF000000u) >> 24);
			array2[num4++] = (byte)(long_0 & 0xFF);
			array2[num4++] = (byte)((long_0 & 0xFF00) >> 8);
			array2[num4++] = (byte)((long_0 & 0xFF0000) >> 16);
			array2[num4++] = (byte)((long_0 & 0xFF000000u) >> 24);
		}
		else
		{
			for (num = 0; num < 8; num++)
			{
				array2[num4++] = byte.MaxValue;
			}
		}
		if (string_0 != null && string_0.Length != 0)
		{
			if (num3 + num4 + 2 > array2.Length)
			{
				num3 = (short)(array2.Length - num4 - 2);
			}
			array2[num4++] = (byte)((uint)num3 & 0xFFu);
			array2[num4++] = (byte)((num3 & 0xFF00) >> 8);
			if (num3 != 0)
			{
				for (num = 0; num < num3 && num4 + num < array2.Length; num++)
				{
					array2[num4 + num] = array[num];
				}
				num4 += num;
			}
		}
		else
		{
			array2[num4++] = 0;
			array2[num4++] = 0;
		}
		return array2;
	}

	private static byte[] smethod_3(long long_0, long long_1, int int_0, uint uint_0)
	{
		byte[] array = new byte[76];
		int num = 0;
		byte[] bytes = BitConverter.GetBytes(101075792u);
		Array.Copy(bytes, 0, array, 0, 4);
		num = 0 + 4;
		Array.Copy(BitConverter.GetBytes(44L), 0, array, 4, 8);
		num = 4 + 8;
		num = 12 + 1;
		array[12] = 45;
		num = 13 + 1;
		array[13] = 0;
		num = 14 + 1;
		array[14] = 45;
		num = 15 + 1;
		array[15] = 0;
		for (int i = 0; i < 8; i++)
		{
			array[num++] = 0;
		}
		long value = int_0;
		Array.Copy(BitConverter.GetBytes(value), 0, array, num, 8);
		num += 8;
		Array.Copy(BitConverter.GetBytes(value), 0, array, num, 8);
		num += 8;
		long value2 = long_1 - long_0;
		Array.Copy(BitConverter.GetBytes(value2), 0, array, num, 8);
		num += 8;
		Array.Copy(BitConverter.GetBytes(long_0), 0, array, num, 8);
		num += 8;
		bytes = BitConverter.GetBytes(117853008u);
		Array.Copy(bytes, 0, array, num, 4);
		num += 4;
		uint value3 = ((uint_0 != 0) ? (uint_0 - 1) : 0u);
		Array.Copy(BitConverter.GetBytes(value3), 0, array, num, 4);
		num += 4;
		Array.Copy(BitConverter.GetBytes(long_1), 0, array, num, 8);
		num += 8;
		Array.Copy(BitConverter.GetBytes(uint_0), 0, array, num, 4);
		num += 4;
		return array;
	}

	private static int smethod_4(ICollection<Class744> icollection_0)
	{
		int num = 0;
		foreach (Class744 item in icollection_0)
		{
			if (item.method_26())
			{
				num++;
			}
		}
		return num;
	}
}
