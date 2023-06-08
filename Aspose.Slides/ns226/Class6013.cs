using System;
using System.IO;

namespace ns226;

internal class Class6013 : Class6012
{
	private static int int_3 = 256;

	private byte[] byte_0;

	public Class6013()
		: base(0, int.MaxValue, growable: true)
	{
		byte_0 = new byte[int_3];
	}

	protected override void vmethod_0(int index, byte b)
	{
		method_12(index + 1);
		byte_0[index] = b;
	}

	protected override int vmethod_1(int index, byte[] b, int offset, int length)
	{
		method_12(index + length);
		Array.Copy(b, offset, byte_0, index, length);
		return length;
	}

	protected override int vmethod_2(int index)
	{
		return byte_0[index];
	}

	protected override int vmethod_3(int index, byte[] b, int offset, int length)
	{
		Array.Copy(byte_0, index, b, offset, length);
		return length;
	}

	public override void Close()
	{
		byte_0 = null;
	}

	public override int CopyTo(StreamWriter os, int offset, int length)
	{
		os.BaseStream.Write(byte_0, offset, length);
		return length;
	}

	private void method_12(int newSize)
	{
		if (newSize > byte_0.Length)
		{
			newSize = Math.Max(newSize, byte_0.Length * 2);
			byte[] destinationArray = new byte[newSize];
			Array.Copy(byte_0, 0, destinationArray, 0, byte_0.Length);
			byte_0 = destinationArray;
		}
	}
}
