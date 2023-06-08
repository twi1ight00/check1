using System.IO;

namespace ns274;

internal class Class6718
{
	internal int int_0;

	internal int int_1;

	internal Class6718(int id, int offset)
	{
		int_0 = id;
		int_1 = offset;
	}

	internal Class6718(BinaryReader reader)
	{
		int_0 = reader.ReadInt32();
		int_1 = reader.ReadInt32();
	}

	internal void Write(BinaryWriter writer)
	{
		writer.Write(int_0);
		writer.Write(int_1);
	}
}
