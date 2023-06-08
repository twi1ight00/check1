using System.IO;

namespace ns57;

internal class Class1327
{
	internal static long smethod_0(uint uint_0, bool bool_0)
	{
		if (bool_0)
		{
			return (uint_0 + 1) * 512;
		}
		return uint_0 * 64;
	}

	internal static uint smethod_1(long long_0, bool bool_0)
	{
		if (bool_0)
		{
			return (uint)(long_0 / 512 - 1);
		}
		return (uint)(long_0 / 64);
	}

	internal static void smethod_2(BinaryWriter binaryWriter_0)
	{
		while (binaryWriter_0.BaseStream.Position % 512 != 0)
		{
			binaryWriter_0.Write(uint.MaxValue);
		}
	}
}
