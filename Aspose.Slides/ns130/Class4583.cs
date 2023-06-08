using System;

namespace ns130;

internal class Class4583
{
	public Class4584 class4584_0;

	public byte[] byte_0;

	public byte[] byte_1;

	public byte[] byte_2;

	public Class4583(byte[] data)
	{
		class4584_0 = new Class4584(data);
		byte_0 = new byte[class4584_0.int_1 - 10];
		byte_1 = new byte[class4584_0.int_2 - class4584_0.int_1];
		byte_2 = new byte[data.Length - class4584_0.int_2];
		Buffer.BlockCopy(data, 10, byte_0, 0, byte_0.Length);
		Buffer.BlockCopy(data, class4584_0.int_1, byte_1, 0, byte_1.Length);
		Buffer.BlockCopy(data, class4584_0.int_2, byte_2, 0, byte_2.Length);
	}
}
