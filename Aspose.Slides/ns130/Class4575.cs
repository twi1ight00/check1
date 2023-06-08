using System;
using System.IO;

namespace ns130;

internal class Class4575 : IDisposable
{
	private MemoryStream memoryStream_0;

	private BinaryWriter binaryWriter_0;

	private byte byte_0;

	private int int_0;

	private bool bool_0;

	public Class4575()
	{
		memoryStream_0 = new MemoryStream();
		binaryWriter_0 = new BinaryWriter(memoryStream_0);
	}

	public void method_0(int bit)
	{
		byte_0 |= (byte)(bit << 7 - int_0);
		int_0++;
		if (int_0 == 8)
		{
			binaryWriter_0.Write(byte_0);
			byte_0 = 0;
			int_0 = 0;
		}
	}

	public void method_1(bool bit)
	{
		method_0(bit ? 1 : 0);
	}

	public void method_2(int value, int numberOfBits)
	{
		for (int num = numberOfBits - 1; num >= 0; num--)
		{
			method_0((value >> num) & 1);
		}
	}

	public void Flush()
	{
		if (int_0 > 0)
		{
			binaryWriter_0.Write(byte_0);
			byte_0 = 0;
			int_0 = 0;
		}
	}

	public byte[] ToArray()
	{
		return memoryStream_0.ToArray();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	private void Dispose(bool disposing)
	{
		if (!bool_0)
		{
			if (disposing)
			{
				memoryStream_0.Close();
			}
			bool_0 = true;
		}
	}
}
