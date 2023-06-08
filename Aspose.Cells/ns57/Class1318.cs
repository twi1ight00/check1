using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace ns57;

internal class Class1318
{
	internal ushort ushort_0;

	internal ushort ushort_1;

	internal ushort ushort_2;

	internal ushort ushort_3;

	internal int int_0;

	internal int int_1;

	internal uint uint_0;

	internal uint uint_1;

	internal uint uint_2;

	internal int int_2;

	internal uint uint_3;

	internal int int_3;

	internal Class1318()
	{
		ushort_0 = 33;
		ushort_1 = 3;
		ushort_2 = 9;
		ushort_3 = 6;
		uint_1 = 4096u;
	}

	internal Class1318(BinaryReader binaryReader_0)
	{
		long num = binaryReader_0.ReadInt64();
		if (num != -2226271756974174256L)
		{
			throw new InvalidOperationException("This is not a structured storage file.");
		}
		binaryReader_0.ReadBytes(16);
		ushort_0 = binaryReader_0.ReadUInt16();
		ushort_1 = binaryReader_0.ReadUInt16();
		if (ushort_1 > 3)
		{
			throw new NotSupportedException("This structured storage version is not supported.");
		}
		binaryReader_0.ReadUInt16();
		ushort_2 = binaryReader_0.ReadUInt16();
		ushort_3 = binaryReader_0.ReadUInt16();
		binaryReader_0.ReadUInt16();
		binaryReader_0.ReadUInt32();
		int_0 = binaryReader_0.ReadInt32();
		int_1 = binaryReader_0.ReadInt32();
		uint_0 = binaryReader_0.ReadUInt32();
		binaryReader_0.ReadUInt32();
		uint_1 = binaryReader_0.ReadUInt32();
		uint_2 = binaryReader_0.ReadUInt32();
		int_2 = binaryReader_0.ReadInt32();
		uint_3 = binaryReader_0.ReadUInt32();
		int_3 = binaryReader_0.ReadInt32();
	}

	internal void Write(BinaryWriter binaryWriter_0)
	{
		binaryWriter_0.Write(-2226271756974174256L);
		binaryWriter_0.Write(new byte[16]);
		binaryWriter_0.Write(ushort_0);
		binaryWriter_0.Write(ushort_1);
		binaryWriter_0.Write((ushort)65534);
		binaryWriter_0.Write(ushort_2);
		binaryWriter_0.Write(ushort_3);
		binaryWriter_0.Write((short)0);
		binaryWriter_0.Write(0);
		binaryWriter_0.Write(int_0);
		binaryWriter_0.Write(int_1);
		binaryWriter_0.Write(uint_0);
		binaryWriter_0.Write(0);
		binaryWriter_0.Write(uint_1);
		binaryWriter_0.Write(uint_2);
		binaryWriter_0.Write(int_2);
		binaryWriter_0.Write(uint_3);
		binaryWriter_0.Write(int_3);
	}

	internal bool method_0(long long_0)
	{
		return long_0 >= uint_1;
	}

	[SpecialName]
	internal int method_1()
	{
		return int_2 * 512;
	}
}
