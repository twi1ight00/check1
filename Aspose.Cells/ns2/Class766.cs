using System;
using System.IO;
using ns16;

namespace ns2;

internal class Class766
{
	internal static byte[] smethod_0(byte[] byte_0)
	{
		MemoryStream memoryStream = new MemoryStream();
		Stream12 stream = new Stream12(memoryStream, Enum44.const_0, Enum42.const_12, bool_1: true);
		stream.Write(byte_0, 0, byte_0.Length);
		stream.Close();
		byte_0 = memoryStream.ToArray();
		memoryStream.Close();
		return byte_0;
	}

	internal static byte[] smethod_1(bool bool_0, bool bool_1, int int_0, int int_1, int int_2, byte[] byte_0, int int_3)
	{
		MemoryStream stream_ = new MemoryStream(byte_0);
		Stream12 stream = new Stream12(stream_, Enum44.const_1);
		int num = 0;
		if (bool_0)
		{
			num = 22;
		}
		else if (bool_1)
		{
			num = 512;
		}
		byte[] array = new byte[num + int_3];
		int num2 = 0;
		while (true)
		{
			num2 = stream.Read(array, num, int_3);
			if (num2 == -1 || num + num2 >= array.Length)
			{
				break;
			}
			num += num2;
		}
		if (bool_0)
		{
			Array.Copy(BitConverter.GetBytes(2596720087u), 0, array, 0, 4);
			ushort num3 = 22289;
			num = 10;
			ushort num4 = (ushort)((double)((float)(int_0 * int_2) / 96f) + 0.5);
			Array.Copy(BitConverter.GetBytes(num4), 0, array, 10, 2);
			num3 = (ushort)(0x5711u ^ num4);
			num4 = (ushort)((double)((float)(int_1 * int_2) / 96f) + 0.5);
			Array.Copy(BitConverter.GetBytes(num4), 0, array, 10 + 2, 2);
			num3 = (ushort)(num3 ^ num4);
			num = 10 + 4;
			num4 = (ushort)int_2;
			Array.Copy(BitConverter.GetBytes(num4), 0, array, 14, 2);
			num3 = (ushort)(num3 ^ num4);
			num = 14 + 2;
			num = 16 + 4;
			Array.Copy(BitConverter.GetBytes(num3), 0, array, 20, 2);
		}
		return array;
	}
}
