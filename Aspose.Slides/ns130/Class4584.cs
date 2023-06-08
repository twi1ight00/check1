using System;

namespace ns130;

internal class Class4584
{
	public const byte byte_0 = 10;

	public byte byte_1;

	public int int_0;

	public int int_1;

	public int int_2;

	public Class4584(byte[] data)
	{
		byte_1 = data[0];
		if (byte_1 != 3)
		{
			throw new InvalidOperationException("Version number must be 3. Maybe data is corrupted");
		}
		int_0 = (data[1] << 16) | (data[2] << 8) | data[3];
		int_1 = (data[4] << 16) | (data[5] << 8) | data[6];
		int_2 = (data[7] << 16) | (data[8] << 8) | data[9];
		if (int_1 > int_2)
		{
			throw new InvalidOperationException("Offset of second block is more than offset of third block. Maybe data is corrupted");
		}
		if (int_2 > data.Length)
		{
			throw new InvalidOperationException("Offset of third block is more total file length. Maybe data is corrupted");
		}
	}
}
