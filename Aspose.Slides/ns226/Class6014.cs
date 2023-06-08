using System;
using System.IO;

namespace ns226;

internal class Class6014 : Class6012
{
	private byte[] byte_0;

	public Class6014(int length)
		: this(new byte[length], 0)
	{
	}

	public Class6014(byte[] b)
		: this(b, b.Length)
	{
	}

	public Class6014(byte[] b, int filledLength)
		: base(filledLength, b.Length)
	{
		byte_0 = b;
	}

	protected override void vmethod_0(int index, byte b)
	{
		byte_0[index] = b;
	}

	protected override int vmethod_1(int index, byte[] b, int offset, int length)
	{
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
}
