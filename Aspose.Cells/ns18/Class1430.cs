using System.IO;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class1430
{
	private ushort ushort_0;

	private ushort ushort_1;

	private ushort ushort_2;

	private uint uint_0;

	private ushort ushort_3;

	private uint uint_1;

	private ushort ushort_4;

	internal Class1430()
	{
	}

	internal void Read(BinaryReader binaryReader_0)
	{
		ushort_0 = binaryReader_0.ReadUInt16();
		ushort_1 = binaryReader_0.ReadUInt16();
		ushort_2 = binaryReader_0.ReadUInt16();
		uint_0 = binaryReader_0.ReadUInt32();
		ushort_3 = binaryReader_0.ReadUInt16();
		uint_1 = binaryReader_0.ReadUInt32();
		ushort_4 = binaryReader_0.ReadUInt16();
	}

	[SpecialName]
	internal int method_0()
	{
		return ushort_3;
	}
}
