using System.IO;

namespace ns264;

internal class Class6502
{
	private ushort ushort_0;

	private ushort ushort_1;

	private ushort ushort_2;

	private uint uint_0;

	private ushort ushort_3;

	private uint uint_1;

	private ushort ushort_4;

	internal int ObjectCount => ushort_3;

	internal Class6502()
	{
	}

	internal void Read(BinaryReader reader)
	{
		ushort_0 = reader.ReadUInt16();
		ushort_1 = reader.ReadUInt16();
		ushort_2 = reader.ReadUInt16();
		uint_0 = reader.ReadUInt32();
		ushort_3 = reader.ReadUInt16();
		uint_1 = reader.ReadUInt32();
		ushort_4 = reader.ReadUInt16();
	}
}
