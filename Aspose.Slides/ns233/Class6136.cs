using System.IO;

namespace ns233;

internal class Class6136
{
	public const int int_0 = 14;

	internal ushort ushort_0 = 19778;

	internal uint uint_0;

	internal ushort ushort_1;

	internal ushort ushort_2;

	internal uint uint_1;

	internal Class6136()
	{
	}

	internal void Read(BinaryReader reader)
	{
		ushort_0 = reader.ReadUInt16();
		uint_0 = reader.ReadUInt32();
		ushort_1 = reader.ReadUInt16();
		ushort_2 = reader.ReadUInt16();
		uint_1 = reader.ReadUInt32();
	}

	internal void Write(BinaryWriter writer)
	{
		writer.Write((short)ushort_0);
		writer.Write((int)uint_0);
		writer.Write((short)ushort_1);
		writer.Write((short)ushort_2);
		writer.Write((int)uint_1);
	}
}
