using System.IO;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class1401
{
	internal uint uint_0 = 40u;

	internal int int_0;

	internal int int_1;

	internal ushort ushort_0;

	internal ushort ushort_1;

	internal uint uint_1;

	internal uint uint_2;

	internal int int_2;

	internal int int_3;

	internal uint uint_3;

	internal uint uint_4;

	internal Class1401()
	{
	}

	internal void Read(BinaryReader binaryReader_0)
	{
		uint_0 = binaryReader_0.ReadUInt32();
		int_0 = binaryReader_0.ReadInt32();
		int_1 = binaryReader_0.ReadInt32();
		ushort_0 = binaryReader_0.ReadUInt16();
		ushort_1 = binaryReader_0.ReadUInt16();
		uint_1 = binaryReader_0.ReadUInt32();
		uint_2 = binaryReader_0.ReadUInt32();
		int_2 = binaryReader_0.ReadInt32();
		int_3 = binaryReader_0.ReadInt32();
		uint_3 = binaryReader_0.ReadUInt32();
		uint_4 = binaryReader_0.ReadUInt32();
	}

	internal void Write(BinaryWriter binaryWriter_0)
	{
		binaryWriter_0.Write(uint_0);
		binaryWriter_0.Write(int_0);
		binaryWriter_0.Write(int_1);
		binaryWriter_0.Write(ushort_0);
		binaryWriter_0.Write(ushort_1);
		binaryWriter_0.Write(uint_1);
		binaryWriter_0.Write(uint_2);
		binaryWriter_0.Write(int_2);
		binaryWriter_0.Write(int_3);
		binaryWriter_0.Write(uint_3);
		binaryWriter_0.Write(uint_4);
	}

	[SpecialName]
	internal int method_0()
	{
		if (ushort_1 == 32)
		{
			if (uint_1 == 3)
			{
				return 12;
			}
			return 0;
		}
		if (ushort_1 == 24)
		{
			return 0;
		}
		int num = ((uint_3 != 0) ? ((int)uint_3) : (1 << (int)ushort_1));
		return num * 4;
	}
}
