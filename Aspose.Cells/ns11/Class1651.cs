using System;

namespace ns11;

internal class Class1651
{
	private uint uint_0;

	private uint uint_1;

	private byte[] byte_0;

	public Class1651()
	{
		uint_1 = 0u;
		byte_0 = null;
	}

	public void method_0(byte[] byte_1, ushort ushort_0, uint uint_2)
	{
		byte_0 = byte_1;
		uint_1 = ushort_0;
		uint_0 = uint_2 - ushort_0;
	}

	public uint method_1()
	{
		return uint_0 + uint_1;
	}

	public uint Read(byte[] byte_1, int int_0, uint uint_2)
	{
		Array.Copy(byte_0, (int)uint_1, byte_1, int_0, (int)uint_2);
		uint_1 += uint_2;
		return uint_2;
	}
}
