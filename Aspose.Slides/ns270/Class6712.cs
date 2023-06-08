using System;
using System.IO;

namespace ns270;

internal class Class6712
{
	internal const int int_0 = 109;

	internal const int int_1 = 76;

	private const int int_2 = 3;

	private const long long_0 = -2226271756974174256L;

	private const int int_3 = 16;

	internal ushort ushort_0;

	internal ushort ushort_1;

	internal ushort ushort_2;

	internal ushort ushort_3;

	internal int int_4;

	internal int int_5;

	internal uint uint_0;

	internal uint uint_1;

	internal uint uint_2;

	internal int int_6;

	internal uint uint_3;

	internal int int_7;

	internal int MiniFatLength => int_6 * 512;

	internal Class6712()
	{
		ushort_0 = 33;
		ushort_1 = 3;
		ushort_2 = 9;
		ushort_3 = 6;
		uint_1 = 4096u;
	}

	internal Class6712(BinaryReader reader)
	{
		long num = reader.ReadInt64();
		if (num != -2226271756974174256L)
		{
			throw new InvalidOperationException("This is not a structured storage file.");
		}
		reader.ReadBytes(16);
		ushort_0 = reader.ReadUInt16();
		ushort_1 = reader.ReadUInt16();
		if (ushort_1 > 3)
		{
			throw new NotSupportedException("This structured storage version is not supported.");
		}
		reader.ReadUInt16();
		ushort_2 = reader.ReadUInt16();
		ushort_3 = reader.ReadUInt16();
		reader.ReadUInt16();
		reader.ReadUInt32();
		int_4 = reader.ReadInt32();
		int_5 = reader.ReadInt32();
		uint_0 = reader.ReadUInt32();
		reader.ReadUInt32();
		uint_1 = reader.ReadUInt32();
		uint_2 = reader.ReadUInt32();
		int_6 = reader.ReadInt32();
		uint_3 = reader.ReadUInt32();
		int_7 = reader.ReadInt32();
	}

	internal void Write(BinaryWriter writer)
	{
		writer.Write(-2226271756974174256L);
		writer.Write(new byte[16]);
		writer.Write(ushort_0);
		writer.Write(ushort_1);
		writer.Write((ushort)65534);
		writer.Write(ushort_2);
		writer.Write(ushort_3);
		writer.Write((short)0);
		writer.Write(0);
		writer.Write(int_4);
		writer.Write(int_5);
		writer.Write(uint_0);
		writer.Write(0);
		writer.Write(uint_1);
		writer.Write(uint_2);
		writer.Write(int_6);
		writer.Write(uint_3);
		writer.Write(int_7);
	}

	internal bool method_0(long streamLength)
	{
		return streamLength >= uint_1;
	}
}
