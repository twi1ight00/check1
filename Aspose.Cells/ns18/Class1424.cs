using System.IO;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class1424
{
	private int int_0;

	private uint uint_0;

	private Enum155 enum155_0;

	private byte[] byte_0;

	private bool bool_0;

	private BinaryReader binaryReader_0;

	internal Enum155 Type => enum155_0;

	internal byte[] Data => byte_0;

	internal void method_0(BinaryReader binaryReader_1)
	{
		uint_0 = binaryReader_1.ReadUInt32();
		enum155_0 = (Enum155)binaryReader_1.ReadUInt16();
		int_0 = (int)((uint_0 - 3) * 2);
		byte_0 = binaryReader_1.ReadBytes(int_0);
	}

	internal void method_1(BinaryReader binaryReader_1)
	{
		if (binaryReader_1.BaseStream.Position + 8 > binaryReader_1.BaseStream.Length)
		{
			enum155_0 = (Enum155)0;
			return;
		}
		enum155_0 = (Enum155)binaryReader_1.ReadUInt32();
		uint_0 = binaryReader_1.ReadUInt32();
		if (uint_0 < 8)
		{
			enum155_0 = (Enum155)0;
			return;
		}
		int_0 = (int)(uint_0 - 8);
		byte_0 = binaryReader_1.ReadBytes(int_0);
		if (Type == Enum155.const_138)
		{
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(byte_0, 0, method_4());
			memoryStream.Position -= method_4();
			binaryReader_0 = new BinaryReader(memoryStream);
			binaryReader_0.ReadInt32();
			int num = binaryReader_0.ReadInt32();
			bool_0 = num == 726027589;
		}
	}

	[SpecialName]
	internal bool method_2()
	{
		return enum155_0 == (Enum155)0;
	}

	[SpecialName]
	internal bool method_3()
	{
		return bool_0;
	}

	[SpecialName]
	internal int method_4()
	{
		return int_0;
	}
}
