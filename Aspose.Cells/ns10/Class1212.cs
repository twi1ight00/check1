using System;

namespace ns10;

internal class Class1212
{
	private int int_0;

	private byte[] byte_0;

	internal int Position
	{
		set
		{
			int_0 = value;
		}
	}

	internal Class1212(byte[] byte_1)
	{
		byte_0 = byte_1;
	}

	internal int method_0()
	{
		int num = ReadByte();
		if (num >= 128)
		{
			num &= 0x7F;
			num += ReadByte() << 7;
		}
		return num;
	}

	internal int method_1()
	{
		int num = 0;
		byte b = 0;
		for (int i = 0; i < 4; i++)
		{
			b = ReadByte();
			if (b >= 128)
			{
				num += (b & 0x7F) << i * 7;
				continue;
			}
			num += b << i * 7;
			break;
		}
		return num;
	}

	internal byte[] method_2(int int_1)
	{
		byte[] array = new byte[int_1];
		Array.Copy(byte_0, int_0, array, 0, int_1);
		int_0 += int_1;
		return array;
	}

	internal byte ReadByte()
	{
		return byte_0[int_0++];
	}

	internal void Seek(long long_0)
	{
		int_0 += (int)long_0;
	}
}
