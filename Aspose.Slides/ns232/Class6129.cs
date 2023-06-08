using System;
using System.IO;

namespace ns232;

internal class Class6129
{
	private StreamWriter streamWriter_0;

	private byte byte_0;

	private int int_0;

	public Class6129()
	{
		streamWriter_0 = new StreamWriter(new MemoryStream());
		streamWriter_0.AutoFlush = true;
		int_0 = 0;
		byte_0 = 0;
	}

	private void method_0(int bit)
	{
		byte_0 |= (byte)(bit << int_0);
		int_0++;
		if (int_0 == 8)
		{
			streamWriter_0.BaseStream.WriteByte(byte_0);
			byte_0 = 0;
			int_0 = 0;
		}
	}

	public void method_1(int value)
	{
		if (value == 0)
		{
			method_0(0);
			return;
		}
		int num = Math.Abs(value);
		for (int i = 0; i < num; i++)
		{
			method_0(1);
		}
		method_0(0);
		method_0((value <= 0) ? 1 : 0);
	}

	public void Flush()
	{
		if (int_0 > 0)
		{
			streamWriter_0.BaseStream.WriteByte(byte_0);
			byte_0 = 0;
			int_0 = 0;
		}
	}

	public byte[] method_2()
	{
		return ((MemoryStream)streamWriter_0.BaseStream).ToArray();
	}
}
