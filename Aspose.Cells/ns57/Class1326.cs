using System.IO;

namespace ns57;

internal class Class1326
{
	internal int int_0;

	internal int int_1;

	internal Class1326(int int_2, int int_3)
	{
		int_0 = int_2;
		int_1 = int_3;
	}

	internal Class1326(BinaryReader binaryReader_0)
	{
		int_0 = binaryReader_0.ReadInt32();
		int_1 = binaryReader_0.ReadInt32();
	}

	internal void Write(BinaryWriter binaryWriter_0)
	{
		binaryWriter_0.Write(int_0);
		binaryWriter_0.Write(int_1);
	}
}
