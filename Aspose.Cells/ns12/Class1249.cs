using System;

namespace ns12;

internal class Class1249
{
	private byte[] byte_0;

	private int int_0;

	internal int Length => int_0;

	internal Class1249(int int_1)
	{
		if (int_1 < 16)
		{
			int_1 *= 2;
		}
		byte_0 = new byte[int_1];
		int_0 = 0;
	}

	internal void Write(byte byte_1)
	{
		method_1(1);
		byte_0[int_0++] = byte_1;
	}

	internal void Write(byte[] byte_1, int int_1, int int_2)
	{
		method_1(int_2);
		Array.Copy(byte_1, int_1, byte_0, int_0, int_2);
		int_0 += int_2;
	}

	internal void method_0(int int_1, byte[] byte_1, int int_2, int int_3)
	{
		Array.Copy(byte_1, int_2, byte_0, int_1, int_3);
	}

	internal void Seek(int int_1)
	{
		method_1(int_1);
		int_0 += int_1;
	}

	internal void Read(byte[] byte_1, int int_1)
	{
		Array.Copy(byte_0, 0, byte_1, int_1, int_0);
	}

	private void method_1(int int_1)
	{
		if (int_0 + int_1 > byte_0.Length)
		{
			byte[] destinationArray = new byte[byte_0.Length * 2];
			Array.Copy(byte_0, 0, destinationArray, 0, int_0);
			byte_0 = destinationArray;
		}
	}
}
