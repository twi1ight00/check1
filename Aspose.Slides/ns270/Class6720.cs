using System.IO;

namespace ns270;

internal static class Class6720
{
	internal const int int_0 = 512;

	internal const int int_1 = 64;

	internal const int int_2 = 4;

	internal const int int_3 = 128;

	internal const int int_4 = 127;

	internal static long smethod_0(uint sect, bool isNormalSector)
	{
		if (isNormalSector)
		{
			return (sect + 1) * 512;
		}
		return sect * 64;
	}

	internal static uint smethod_1(long offset, bool isNormalSector)
	{
		if (isNormalSector)
		{
			return (uint)(offset / 512L - 1L);
		}
		return (uint)(offset / 64L);
	}

	internal static void smethod_2(BinaryWriter writer)
	{
		while (writer.BaseStream.Position % 512L != 0L)
		{
			writer.Write(uint.MaxValue);
		}
	}
}
