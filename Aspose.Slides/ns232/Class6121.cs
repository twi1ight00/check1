using System.IO;

namespace ns232;

internal class Class6121
{
	public uint uint_0;

	public uint uint_1;

	public uint uint_2;

	public uint uint_3;

	public byte[] byte_0;

	public byte byte_1;

	public byte byte_2;

	public uint uint_4;

	public ushort ushort_0;

	public ushort ushort_1;

	public uint[] uint_5;

	public uint[] uint_6;

	public uint uint_7;

	public uint[] uint_8;

	public ushort ushort_2;

	public ushort ushort_3;

	public byte[] byte_3;

	public ushort ushort_4;

	public ushort ushort_5;

	public byte[] byte_4;

	public ushort ushort_6;

	public ushort ushort_7;

	public byte[] byte_5;

	public ushort ushort_8;

	public ushort ushort_9;

	public byte[] byte_6;

	public ushort ushort_10;

	public ushort ushort_11;

	public void Write(BinaryWriter writer)
	{
		writer.Write(uint_0);
		writer.Write(uint_1);
		writer.Write(uint_2);
		writer.Write(uint_3);
		writer.Write(byte_0);
		writer.Write(byte_1);
		writer.Write(byte_2);
		writer.Write(uint_4);
		writer.Write(ushort_0);
		writer.Write(ushort_1);
		uint[] array = uint_5;
		foreach (uint value in array)
		{
			writer.Write(value);
		}
		uint[] array2 = uint_6;
		foreach (uint value2 in array2)
		{
			writer.Write(value2);
		}
		writer.Write(uint_7);
		uint[] array3 = uint_8;
		foreach (uint value3 in array3)
		{
			writer.Write(value3);
		}
		writer.Write(ushort_2);
		writer.Write(ushort_3);
		if (ushort_3 != 0)
		{
			writer.Write(byte_3);
		}
		writer.Write(ushort_4);
		writer.Write(ushort_5);
		if (ushort_5 != 0)
		{
			writer.Write(byte_4);
		}
		writer.Write(ushort_6);
		writer.Write(ushort_7);
		if (ushort_7 != 0)
		{
			writer.Write(byte_5);
		}
		writer.Write(ushort_8);
		writer.Write(ushort_9);
		if (ushort_9 != 0)
		{
			writer.Write(byte_6);
		}
		writer.Write(ushort_10);
		writer.Write(ushort_11);
	}
}
