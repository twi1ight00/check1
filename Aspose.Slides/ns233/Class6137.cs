using System.IO;

namespace ns233;

internal class Class6137
{
	internal const int int_0 = 40;

	internal int int_1 = 40;

	internal int int_2;

	internal int int_3;

	internal ushort ushort_0;

	internal ushort ushort_1;

	internal uint uint_0;

	internal uint uint_1;

	internal int int_4;

	internal int int_5;

	internal uint uint_2;

	internal uint uint_3;

	internal int ColorTableSize
	{
		get
		{
			if (ushort_1 == 32)
			{
				if (uint_0 == 3)
				{
					return 12;
				}
				return 0;
			}
			if (ushort_1 == 24)
			{
				return 0;
			}
			int num = ((uint_2 != 0) ? ((int)uint_2) : (1 << (int)ushort_1));
			return num * 4;
		}
	}

	internal Class6137()
	{
	}

	internal void Read(BinaryReader reader)
	{
		int_1 = reader.ReadInt32();
		switch (int_1)
		{
		default:
			int_2 = reader.ReadInt32();
			int_3 = reader.ReadInt32();
			ushort_0 = reader.ReadUInt16();
			ushort_1 = reader.ReadUInt16();
			uint_0 = reader.ReadUInt32();
			uint_1 = reader.ReadUInt32();
			int_4 = reader.ReadInt32();
			int_5 = reader.ReadInt32();
			uint_2 = reader.ReadUInt32();
			uint_3 = reader.ReadUInt32();
			break;
		case 12:
			int_1 = 40;
			int_2 = reader.ReadUInt16();
			int_3 = reader.ReadUInt16();
			ushort_0 = reader.ReadUInt16();
			ushort_1 = reader.ReadUInt16();
			break;
		}
	}

	internal void Write(BinaryWriter writer)
	{
		writer.Write(int_1);
		writer.Write(int_2);
		writer.Write(int_3);
		writer.Write((short)ushort_0);
		writer.Write((short)ushort_1);
		writer.Write((int)uint_0);
		writer.Write((int)uint_1);
		writer.Write(int_4);
		writer.Write(int_5);
		writer.Write((int)uint_2);
		writer.Write((int)uint_3);
	}
}
