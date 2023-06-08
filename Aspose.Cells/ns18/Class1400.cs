using System.IO;

namespace ns18;

internal class Class1400
{
	internal ushort ushort_0 = 19778;

	internal uint uint_0;

	internal ushort ushort_1;

	internal ushort ushort_2;

	internal uint uint_1;

	internal Class1400()
	{
	}

	internal void Write(BinaryWriter binaryWriter_0)
	{
		binaryWriter_0.Write(ushort_0);
		binaryWriter_0.Write(uint_0);
		binaryWriter_0.Write(ushort_1);
		binaryWriter_0.Write(ushort_2);
		binaryWriter_0.Write(uint_1);
	}
}
